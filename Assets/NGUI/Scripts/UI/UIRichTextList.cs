#if !UNITY_3_5 && !UNITY_FLASH
#define DYNAMIC_FONT
#endif

using UnityEngine;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Rich Text list can be used with a UILabel to create a scrollable multi-line text field that's
/// easy to add new entries to. Optimal use: chat window.
/// </summary>

[AddComponentMenu("NGUI/UI/Rich Text List")]
public class UIRichTextList : MonoBehaviour
{
	public enum Style
	{
		Text,
		Chat,
	}

	/// <summary>
	/// Rich Textl the contents of which will be modified with the chat entries.
	/// </summary>

	public UIRichText RichText;

	/// <summary>
	/// Vertical scroll bar associated with the text list.
	/// </summary>

	public UIProgressBar scrollBar;

	public float ScrollScale = 1.0f;

	/// <summary>
	/// Text style. Text entries go top to bottom. Chat entries go bottom to top.
	/// </summary>

	public Style style = Style.Text;

	/// <summary>
	/// Maximum number of chat log entries to keep before discarding them.
	/// </summary>

	public int paragraphHistory = 100;

	// Text list is made up of paragraphs
	protected class Paragraph
	{
		public string text;		// Original text
		public string[] lines;	// Split lines
	}

	protected char[] mSeparator = new char[] { '\n' };
	protected float mScroll = 0f;
	protected int mTotalLines = 0;
	protected int mLastWidth = 0;
	protected int mLastHeight = 0;
	BetterList<Paragraph> mParagraphs;

	/// <summary>
	/// Chat history is in a dictionary so that there can be multiple chat window tabs, each with its own text list.
	/// The dictionary is static so that it travels from one scene to another without losing chat history.
	/// </summary>

	static Dictionary<string, BetterList<Paragraph>> mHistory = new Dictionary<string, BetterList<Paragraph>>();

	/// <summary>
	/// Paragraphs belonging to this text list.
	/// </summary>

	protected BetterList<Paragraph> paragraphs
	{
		get
		{
			if (mParagraphs == null)
			{
				if (!mHistory.TryGetValue(name, out mParagraphs))
				{
					mParagraphs = new BetterList<Paragraph>();
					mHistory.Add(name, mParagraphs);
				}
			}
			return mParagraphs;
		}
	}

	/// <summary>
	/// Whether the text list is usable.
	/// </summary>

#if DYNAMIC_FONT
	public bool isValid { get { return RichText.label != null && RichText.label.ambigiousFont != null; } }
#else
	public bool isValid { get { return RichText.label != null && RichText.label.bitmapFont != null; } }
#endif

	/// <summary>
	/// Relative (0-1 range) scroll value, with 0 being the oldest entry and 1 being the newest entry.
	/// </summary>

	public float scrollValue
	{
		get
		{
			return mScroll;
		}
		set
		{
			value = Mathf.Clamp01(value);

			if (isValid && mScroll != value)
			{
				if (scrollBar != null)
				{
					scrollBar.value = value;
				}
				else
				{
					mScroll = value;
					UpdateVisibleText();
				}
			}
		}
	}

	/// <summary>
	/// Height of each line.
	/// </summary>

	protected float lineHeight { get { return (RichText.label != null) ? RichText.label.fontSize + RichText.label.effectiveSpacingY : 20f; } }

	/// <summary>
	/// Height of the scrollable area (outside of the visible area's bounds).
	/// </summary>

	protected int scrollHeight
	{
		get
		{
			if (!isValid) return 0;
			int maxLines = Mathf.FloorToInt((float)RichText.label.height / lineHeight);
			return Mathf.Max(0, mTotalLines - maxLines);
		}
	}

	/// <summary>
	/// Clear the text.
	/// </summary>

	public void Clear ()
	{
		paragraphs.Clear();
		UpdateVisibleText();
	}

	/// <summary>
	/// Automatically find the values if none were specified.
	/// </summary>

	void Start ()
	{
		if (RichText == null)
		{
			RichText = GetComponentInChildren<UIRichText>();
		}
		if (RichText.label == null)
			RichText.label = GetComponentInChildren<UILabel>();

		if (scrollBar != null)
			EventDelegate.Add(scrollBar.onChange, OnScrollBar);

		RichText.label.overflowMethod = UILabel.Overflow.ClampContent;

		if (style == Style.Chat)
		{
			RichText.label.pivot = UIWidget.Pivot.BottomLeft;
			scrollValue = 1f;
		}
		else
		{
			RichText.label.pivot = UIWidget.Pivot.TopLeft;
			scrollValue = 0f;
		}
	}

	/// <summary>
	/// Keep an eye on the size of the label, and if it changes -- rebuild everything.
	/// </summary>

	void Update ()
	{
		if (isValid && (RichText.label.width != mLastWidth || RichText.label.height != mLastHeight))
			Rebuild();
	}

	/// <summary>
	/// Allow scrolling of the text list.
	/// </summary>

	public void OnScroll (float val)
	{
		int sh = scrollHeight;
		if (sh != 0)
		{
			//if (ScrollScale != 0)
			{
				val *= ScrollScale;
			}
			//
			val *= lineHeight;
			scrollValue = mScroll - val / sh;
		}
	}

	/// <summary>
	/// Allow dragging of the text list.
	/// </summary>

	public void OnDrag (Vector2 delta)
	{
		int sh = scrollHeight;

		if (sh != 0)
		{
			float val = delta.y / lineHeight;
			scrollValue = mScroll + val / sh;
		}
	}

	/// <summary>
	/// Delegate function called when the scroll bar's value changes.
	/// </summary>

	void OnScrollBar ()
	{
		mScroll = UIScrollBar.current.value;
		UpdateVisibleText();
	}

	/// <summary>
	/// Add a new paragraph.
	/// </summary>

	public void Add (string text) { Add(text, true); }

	/// <summary>
	/// Add a new paragraph.
	/// </summary>

	protected void Add (string text, bool updateVisible)
	{
		Paragraph ce = null;

		if (paragraphs.size < paragraphHistory)
		{
			ce = new Paragraph();
		}
		else
		{
			ce = mParagraphs[0];
			mParagraphs.RemoveAt(0);
		}

		ce.text = text;
		mParagraphs.Add(ce);
		Rebuild();
	}

	/// <summary>
	/// Rebuild the visible text.
	/// </summary>

	protected void Rebuild ()
	{
		if (isValid)
		{
			mLastWidth = RichText.label.width;
			mLastHeight = RichText.label.height;

			// Although we could simply use UILabel.Wrap, it would mean setting the same data
			// over and over every paragraph, which is not ideal. It's faster to only do it once
			// and then do wrapping ourselves in the 'for' loop below.
			RichText.label.UpdateNGUIText();
			NGUIText.rectHeight = 1000000;
			NGUIText.regionHeight = 1000000;
			mTotalLines = 0;

			for (int i = 0; i < paragraphs.size; ++i)
			{
				string final;
				Paragraph p = mParagraphs.buffer[i];
				NGUIText.WrapText(p.text, out final, false, true);
				p.lines = final.Split('\n');
				mTotalLines += p.lines.Length;
			}

			// Recalculate the total number of lines
			mTotalLines = 0;
			for (int i = 0, imax = mParagraphs.size; i < imax; ++i)
				mTotalLines += mParagraphs.buffer[i].lines.Length;

			// Update the bar's size
			if (scrollBar != null)
			{
				UIScrollBar sb = scrollBar as UIScrollBar;
				if (sb != null) sb.barSize = (mTotalLines == 0) ? 1f : 1f - (float)scrollHeight / mTotalLines;
			}

			// Update the visible text
			UpdateVisibleText();
		}
	}

	/// <summary>
	/// Refill the text label based on what's currently visible.
	/// </summary>

	protected void UpdateVisibleText ()
	{
		if (isValid)
		{
			if (mTotalLines == 0)
			{
				mCurrentText = string.Empty;
				RichText.value = mCurrentText;
				return;
			}

			int maxLines = Mathf.FloorToInt((float)RichText.label.height / lineHeight);
			int sh = Mathf.Max(0, mTotalLines - maxLines);
			int offset = Mathf.RoundToInt(mScroll * sh);
			if (offset < 0) offset = 0;

			StringBuilder final = new StringBuilder();

			for (int i = 0, imax = paragraphs.size; maxLines > 0 && i < imax; ++i)
			{
				Paragraph p = mParagraphs.buffer[i];

				for (int b = 0, bmax = p.lines.Length; maxLines > 0 && b < bmax; ++b)
				{
					string s = p.lines[b];

					if (offset > 0)
					{
						--offset;
					}
					else
					{
						if (final.Length > 0) final.Append("\n");
						final.Append(s);
						--maxLines;
					}
				}
			}
			mCurrentText = final.ToString();
			RichText.value = mCurrentText;
		}
	}

	[ContextMenu("Execute Append Text")]
	void Reposition()
	{
		string text = RichText.label.text;
		if (mCurrentText.Length < text.Length)
		{
			text = text.Substring(mCurrentText.Length);
			Add(text, true);
		}
	}
	string mCurrentText = string.Empty;
}
