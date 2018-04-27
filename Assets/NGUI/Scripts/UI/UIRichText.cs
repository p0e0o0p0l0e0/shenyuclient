#if !UNITY_EDITOR && (UNITY_IPHONE || UNITY_ANDROID || UNITY_WP8 || UNITY_WP_8_1 || UNITY_BLACKBERRY || UNITY_WINRT || UNITY_METRO)
#define MOBILE
#endif

using UnityEngine;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Label, can be selected words, can not be changed
/// </summary>

[AddComponentMenu("NGUI/RichText")]
public class UIRichText : MonoBehaviour
{
#if UNITY_EDITOR
	public enum KeyboardType
	{
		Default = (int)TouchScreenKeyboardType.Default,
		ASCIICapable = (int)TouchScreenKeyboardType.ASCIICapable,
		NumbersAndPunctuation = (int)TouchScreenKeyboardType.NumbersAndPunctuation,
		URL = (int)TouchScreenKeyboardType.URL,
		NumberPad = (int)TouchScreenKeyboardType.NumberPad,
		PhonePad = (int)TouchScreenKeyboardType.PhonePad,
		NamePhonePad = (int)TouchScreenKeyboardType.NamePhonePad,
		EmailAddress = (int)TouchScreenKeyboardType.EmailAddress,
	}
#else
	public enum KeyboardType
	{
		Default = 0,
		ASCIICapable = 1,
		NumbersAndPunctuation = 2,
		URL = 3,
		NumberPad = 4,
		PhonePad = 5,
		NamePhonePad = 6,
		EmailAddress = 7,
	}
#endif

	/// <summary>
	/// Currently active input field. Only valid during callbacks.
	/// </summary>

	static public UIRichText current;

	/// <summary>
	/// Currently selected input field, if any.
	/// </summary>

	static public UIRichText selection;

	/// <summary>
	/// Text label used to display the input's value.
	/// </summary>

	public UILabel label;

	/// <summary>
	/// Keyboard type applies to mobile keyboards that get shown.
	/// </summary>

	public KeyboardType keyboardType = KeyboardType.Default;

	/// <summary>
	/// Whether the input will be hidden on mobile platforms.
	/// </summary>

	public bool hideInput = false;

	/// <summary>
	/// Whether all text will be selected when the input field gains focus.
	/// </summary>

	[System.NonSerialized]
	public bool selectAllTextOnFocus = true;

	/// <summary>
	/// Maximum number of characters allowed before input no longer works.
	/// </summary>

	public int characterLimit = 0;

	/// <summary>
	/// Don't use this anymore. Attach UIKeyNavigation instead.
	/// </summary>

	[HideInInspector]
	[SerializeField]
	GameObject selectOnTab;

	/// <summary>
	/// Color used by the caret symbol.
	/// </summary>

	public Color caretColor = new Color(1f, 1f, 1f, 0.8f);

	/// <summary>
	/// Color used by the selection rectangle.
	/// </summary>

	public Color selectionColor = new Color(1f, 223f / 255f, 141f / 255f, 0.5f);

	/// <summary>
	/// Input field's value.
	/// </summary>

	[SerializeField]
	[HideInInspector]
	protected string mValue;

	[System.NonSerialized]
	protected float mPosition = 0f;
	[System.NonSerialized]
	protected bool mDoInit = true;
	[System.NonSerialized]
	protected NGUIText.Alignment mAlignment = NGUIText.Alignment.Left;

	static protected int mDrawStart = 0;
	static protected string mLastIME = "";

#if MOBILE
	// Unity fails to compile if the touch screen keyboard is used on a non-mobile device
	static protected TouchScreenKeyboard mKeyboard;
	static bool mWaitForKeyboard = false;
#endif
	[System.NonSerialized]
	protected int mSelectionStart = 0;
	[System.NonSerialized]
	protected int mSelectionEnd = 0;
	[System.NonSerialized]
	protected UITexture mHighlight = null;
	[System.NonSerialized]
	protected UITexture mCaret = null;
	[System.NonSerialized]
	protected Texture2D mBlankTex = null;
	[System.NonSerialized]
	protected float mNextBlink = 0f;
	[System.NonSerialized]
	protected float mLastAlpha = 0f;
	[System.NonSerialized]
	protected string mCached = "";
	[System.NonSerialized]
	protected int mSelectMe = -1;
	[System.NonSerialized]
	protected int mSelectTime = -1;

	/// <summary>
	/// Should the input be hidden?
	/// </summary>

	public bool inputShouldBeHidden
	{
		get
		{
			return hideInput && label != null && !label.multiLine;
		}
	}

	/// <summary>
	///  current text value.
	/// </summary>

	public string value
	{
		get
		{
#if UNITY_EDITOR
			if (!Application.isPlaying) return "";
#endif
			if (mDoInit) Init();
			return mValue;
		}
		set
		{
#if UNITY_EDITOR
			if (!Application.isPlaying) return;
#endif
			if (mDoInit) Init();
			mDrawStart = 0;

			// BB10's implementation has a bug in Unity
#if UNITY_4_3
			if (Application.platform == RuntimePlatform.BB10Player)
#else
			if (Application.platform == RuntimePlatform.BlackBerryPlayer)
#endif
				value = value.Replace("\\b", "\b");

#if MOBILE
			if (isSelected && mKeyboard != null && mCached != value)
			{
				mKeyboard.text = value;
				mCached = value;
			}
#endif
			if (mValue != value)
			{
				mValue = value;

				if (string.IsNullOrEmpty(value))
				{
					mSelectionStart = 0;
					mSelectionEnd = 0;
				}
				else
				{
					mSelectionStart = value.Length;
					mSelectionEnd = mSelectionStart;
				}

				UpdateLabel();
			}
		}
	}

	/// <summary>
	/// Whether the input is currently selected.
	/// </summary>

	public bool isSelected
	{
		get
		{
			return selection == this;
		}
		set
		{
			if (!value) { if (isSelected) UICamera.selectedObject = null; }
			else UICamera.selectedObject = gameObject;
		}
	}

	/// <summary>
	/// Current position of the cursor.
	/// </summary>

	public int cursorPosition
	{
		get
		{
#if MOBILE
			if (mKeyboard != null && !inputShouldBeHidden) return value.Length;
#endif
			return isSelected ? mSelectionEnd : value.Length;
		}
		set
		{
			if (isSelected)
			{
#if MOBILE
				if (mKeyboard != null && !inputShouldBeHidden) return;
#endif
				mSelectionEnd = value;
				UpdateLabel();
			}
		}
	}

	/// <summary>
	/// Index of the character where selection begins.
	/// </summary>

	public int selectionStart
	{
		get
		{
#if MOBILE
			if (mKeyboard != null && !inputShouldBeHidden) return 0;
#endif
			return isSelected ? mSelectionStart : value.Length;
		}
		set
		{
			if (isSelected)
			{
#if MOBILE
				if (mKeyboard != null && !inputShouldBeHidden) return;
#endif
				mSelectionStart = value;
				UpdateLabel();
			}
		}
	}

	/// <summary>
	/// Index of the character where selection ends.
	/// </summary>

	public int selectionEnd
	{
		get
		{
#if MOBILE
			if (mKeyboard != null && !inputShouldBeHidden) return value.Length;
#endif
			return isSelected ? mSelectionEnd : value.Length;
		}
		set
		{
			if (isSelected)
			{
#if MOBILE
				if (mKeyboard != null && !inputShouldBeHidden) return;
#endif
				mSelectionEnd = value;
				UpdateLabel();
			}
		}
	}

	/// <summary>
	/// Caret, in case it's needed.
	/// </summary>

	public UITexture caret { get { return mCaret; } }

	/// <summary>
	/// Automatically set the value by loading it from player prefs if possible.
	/// </summary>

	void Start()
	{
		if (selectOnTab != null)
		{
			UIKeyNavigation nav = GetComponent<UIKeyNavigation>();

			if (nav == null)
			{
				nav = gameObject.AddComponent<UIKeyNavigation>();
				nav.onDown = selectOnTab;
			}
			selectOnTab = null;
			NGUITools.SetDirty(this);
		}
		value = mValue.Replace("\\n", "\n");
	}

	/// <summary>
	/// Labels used for input shouldn't support rich text.
	/// </summary>

	protected void Init()
	{
		if (mDoInit && label != null)
		{
			mDoInit = false;
			label.supportEncoding = false;
			mEllipsis = label.overflowEllipsis;

			if (label.alignment == NGUIText.Alignment.Justified)
			{
				label.alignment = NGUIText.Alignment.Left;
				Debug.LogWarning("Input fields using labels with justified alignment are not supported at this time", this);
			}

			mAlignment = label.alignment;
			mPosition = label.cachedTransform.localPosition.x;
			UpdateLabel();
		}
	}

#if !MOBILE
	[System.NonSerialized]
	UIRichTextOnGUI mOnGUI;
#endif
	[System.NonSerialized]
	UICamera mCam;
	/// <summary>
	/// Selection event, sent by the EventSystem.
	/// </summary>

	protected virtual void OnSelect(bool isSelected)
	{
		if (isSelected)
		{
#if !MOBILE
			if (mOnGUI == null)
				mOnGUI = gameObject.AddComponent<UIRichTextOnGUI>();
#endif
			OnSelectEvent();
		}
		else
		{
#if !MOBILE
			if (mOnGUI != null)
			{
				Destroy(mOnGUI);
				mOnGUI = null;
			}
#endif
			OnDeselectEvent();
		}
	}

	/// <summary>
	/// Notification of the input field gaining selection.
	/// </summary>

	protected void OnSelectEvent()
	{
		mSelectTime = Time.frameCount;
		selection = this;
		if (mDoInit) Init();

		if (label != null)
		{
			mEllipsis = label.overflowEllipsis;
			label.overflowEllipsis = false;
		}

		// Unity has issues bringing up the keyboard properly if it's in "hideInput" mode and you happen
		// to select one input in the same Update as de-selecting another.
		if (label != null && NGUITools.GetActive(this)) mSelectMe = Time.frameCount;
	}

	[System.NonSerialized]
	bool mEllipsis = false;

	/// <summary>
	/// Notification of the input field losing selection.
	/// </summary>

	protected void OnDeselectEvent()
	{
		if (mDoInit) Init();

		if (label != null) label.overflowEllipsis = mEllipsis;

		if (label != null && NGUITools.GetActive(this))
		{
			mValue = value;
#if MOBILE
			if (mKeyboard != null)
			{
				mWaitForKeyboard = false;
				mKeyboard.active = false;
				mKeyboard = null;
			}
#endif
			label.text = mValue;

			Input.imeCompositionMode = IMECompositionMode.Auto;
			label.alignment = mAlignment;
		}

		selection = null;
		UpdateLabel();
	}

	/// <summary>
	/// Update the text based on input.
	/// </summary>

	protected virtual void Update()
	{
#if UNITY_EDITOR
		if (!Application.isPlaying) return;
#endif
		if (!isSelected || mSelectTime == Time.frameCount) return;

		if (mDoInit) Init();
#if MOBILE
		// Wait for the keyboard to open. Apparently mKeyboard.active will return 'false' for a while in some cases.
		if (mWaitForKeyboard)
		{
			if (mKeyboard != null && !mKeyboard.active) return;
			mWaitForKeyboard = false;
		}
#endif
		// Unity has issues bringing up the keyboard properly if it's in "hideInput" mode and you happen
		// to select one input in the same Update as de-selecting another.
		if (mSelectMe != -1 && mSelectMe != Time.frameCount)
		{
			mSelectMe = -1;
			mSelectionEnd = string.IsNullOrEmpty(mValue) ? 0 : mValue.Length;
			mDrawStart = 0;
			mSelectionStart = selectAllTextOnFocus ? 0 : mSelectionEnd;
#if MOBILE
			RuntimePlatform pf = Application.platform;
			if (pf == RuntimePlatform.IPhonePlayer
				|| pf == RuntimePlatform.Android
				|| pf == RuntimePlatform.WP8Player
#if UNITY_4_3
				|| pf == RuntimePlatform.BB10Player
#else
				|| pf == RuntimePlatform.BlackBerryPlayer
				|| pf == RuntimePlatform.MetroPlayerARM
				|| pf == RuntimePlatform.MetroPlayerX64
				|| pf == RuntimePlatform.MetroPlayerX86
#endif
			)
			{
				string val;
				TouchScreenKeyboardType kt;

				if (inputShouldBeHidden)
				{
					TouchScreenKeyboard.hideInput = true;
					kt = (TouchScreenKeyboardType)((int)keyboardType);
					val = "|";
				}
				else
				{
					TouchScreenKeyboard.hideInput = false;
					kt = (TouchScreenKeyboardType)((int)keyboardType);
					val = mValue;
					mSelectionStart = mSelectionEnd;
				}

				mWaitForKeyboard = true;
				mKeyboard = TouchScreenKeyboard.Open(val, kt, !inputShouldBeHidden,
						label.multiLine && !hideInput, false, false, "");
#if UNITY_METRO
				mKeyboard.active = true;
#endif
			}
			else
#endif // MOBILE
			{
				Vector2 pos = (UICamera.current != null && UICamera.current.cachedCamera != null) ?
					UICamera.current.cachedCamera.WorldToScreenPoint(label.worldCorners[0]) :
					label.worldCorners[0];
				pos.y = Screen.height - pos.y;
				Input.imeCompositionMode = IMECompositionMode.On;
				Input.compositionCursorPos = pos;
			}

			UpdateLabel();
			if (string.IsNullOrEmpty(Input.inputString)) return;
		}
#if MOBILE
		if (mKeyboard != null)
		{
			string text = (mKeyboard.done || !mKeyboard.active) ? mCached : mKeyboard.text;
 
			if (inputShouldBeHidden)
			{
				if (text != "|")
				{
					mKeyboard.text = "|";
				}
			}
			else if (mCached != text)
			{
				mCached = text;
				if (!mKeyboard.done && mKeyboard.active) value = text;
			}

			if (mKeyboard.done || !mKeyboard.active)
			{
				mKeyboard = null;
				isSelected = false;
				mCached = "";
			}
		}
		else
#endif // MOBILE

		// Blink the caret
		if (mCaret != null && mNextBlink < RealTime.time)
		{
			mNextBlink = RealTime.time + 0.5f;
			mCaret.enabled = !mCaret.enabled;
		}

		// If the label's final alpha changes, we need to update the drawn geometry,
		// or the highlight widgets (which have their geometry set manually) won't update.
		if (isSelected && mLastAlpha != label.finalAlpha)
			UpdateLabel();

		// Cache the camera
		if (mCam == null) mCam = UICamera.FindCameraForLayer(gameObject.layer);

		// Having this in OnGUI causes issues because Input.inputString gets updated *after* OnGUI, apparently...
		if (mCam != null)
		{

			if (!mCam.useKeyboard && UICamera.GetKeyUp(KeyCode.Tab))
				OnKey(KeyCode.Tab);
		}
	}

	static int mIgnoreKey = 0;

	void OnKey(KeyCode key)
	{
		int frame = Time.frameCount;

		if (mIgnoreKey == frame) return;

		if (mCam != null && (key == mCam.cancelKey0 || key == mCam.cancelKey1))
		{
			mIgnoreKey = frame;
			isSelected = false;
		}
		else if (key == KeyCode.Tab)
		{
			mIgnoreKey = frame;
			isSelected = false;
			UIKeyNavigation nav = GetComponent<UIKeyNavigation>();
			if (nav != null) nav.OnKey(KeyCode.Tab);
		}
	}

#if !MOBILE
	/// <summary>
	/// Handle the specified event.
	/// </summary>

	public virtual bool ProcessEvent(Event ev)
	{
		if (label == null) return false;

		RuntimePlatform rp = Application.platform;

		bool isMac = (
			rp == RuntimePlatform.OSXEditor ||
			rp == RuntimePlatform.OSXPlayer);

		bool ctrl = isMac ?
			((ev.modifiers & EventModifiers.Command) != 0) :
			((ev.modifiers & EventModifiers.Control) != 0);

		// http://www.tasharen.com/forum/index.php?topic=10780.0
		if ((ev.modifiers & EventModifiers.Alt) != 0) ctrl = false;

		bool shift = ((ev.modifiers & EventModifiers.Shift) != 0);

		switch (ev.keyCode)
		{
			case KeyCode.LeftArrow:
				{
					ev.Use();

					if (!string.IsNullOrEmpty(mValue))
					{
						mSelectionEnd = Mathf.Max(mSelectionEnd - 1, 0);
						if (!shift) mSelectionStart = mSelectionEnd;
						UpdateLabel();
					}
					return true;
				}

			case KeyCode.RightArrow:
				{
					ev.Use();

					if (!string.IsNullOrEmpty(mValue))
					{
						mSelectionEnd = Mathf.Min(mSelectionEnd + 1, mValue.Length);
						if (!shift) mSelectionStart = mSelectionEnd;
						UpdateLabel();
					}
					return true;
				}

			case KeyCode.PageUp:
				{
					ev.Use();

					if (!string.IsNullOrEmpty(mValue))
					{
						mSelectionEnd = 0;
						if (!shift) mSelectionStart = mSelectionEnd;
						UpdateLabel();
					}
					return true;
				}

			case KeyCode.PageDown:
				{
					ev.Use();

					if (!string.IsNullOrEmpty(mValue))
					{
						mSelectionEnd = mValue.Length;
						if (!shift) mSelectionStart = mSelectionEnd;
						UpdateLabel();
					}
					return true;
				}

			case KeyCode.Home:
				{
					ev.Use();

					if (!string.IsNullOrEmpty(mValue))
					{
						if (label.multiLine)
						{
							mSelectionEnd = label.GetCharacterIndex(mSelectionEnd, KeyCode.Home);
						}
						else mSelectionEnd = 0;

						if (!shift) mSelectionStart = mSelectionEnd;
						UpdateLabel();
					}
					return true;
				}

			case KeyCode.End:
				{
					ev.Use();

					if (!string.IsNullOrEmpty(mValue))
					{
						if (label.multiLine)
						{
							mSelectionEnd = label.GetCharacterIndex(mSelectionEnd, KeyCode.End);
						}
						else mSelectionEnd = mValue.Length;

						if (!shift) mSelectionStart = mSelectionEnd;
						UpdateLabel();
					}
					return true;
				}

			case KeyCode.UpArrow:
				{
					ev.Use();

					if (!string.IsNullOrEmpty(mValue))
					{
						mSelectionEnd = label.GetCharacterIndex(mSelectionEnd, KeyCode.UpArrow);
						if (mSelectionEnd != 0) mSelectionEnd += mDrawStart;
						if (!shift) mSelectionStart = mSelectionEnd;
						UpdateLabel();
					}
					return true;
				}

			case KeyCode.DownArrow:
				{
					ev.Use();

					if (!string.IsNullOrEmpty(mValue))
					{
						mSelectionEnd = label.GetCharacterIndex(mSelectionEnd, KeyCode.DownArrow);
						if (mSelectionEnd != label.processedText.Length) mSelectionEnd += mDrawStart;
						else mSelectionEnd = mValue.Length;
						if (!shift) mSelectionStart = mSelectionEnd;
						UpdateLabel();
					}
					return true;
				}

			// Select all
			case KeyCode.A:
				{
					if (ctrl)
					{
						ev.Use();
						mSelectionStart = 0;
						mSelectionEnd = mValue.Length;
						UpdateLabel();
					}
					return true;
				}

			// Copy
			case KeyCode.C:
				{
					if (ctrl)
					{
						ev.Use();
						NGUITools.clipboard = GetSelection();
					}
					return true;
				}
		}
		return false;
	}
#endif

	/// <summary>
	/// Get currently selected text.
	/// </summary>

	protected string GetSelection()
	{
		if (string.IsNullOrEmpty(mValue) || mSelectionStart == mSelectionEnd)
		{
			return "";
		}
		else
		{
			int min = Mathf.Min(mSelectionStart, mSelectionEnd);
			int max = Mathf.Max(mSelectionStart, mSelectionEnd);
			return mValue.Substring(min, max - min);
		}
	}

	/// <summary>
	/// Helper function that retrieves the index of the character under the mouse.
	/// </summary>

	protected int GetCharUnderMouse()
	{
		if (string.IsNullOrEmpty(value))
		{
			return 0;
		}
		Vector3[] corners = label.worldCorners;
		Ray ray = UICamera.currentRay;
		Plane p = new Plane(corners[0], corners[1], corners[2]);
		float dist;
		return p.Raycast(ray, out dist) ? mDrawStart + label.GetCharacterIndexAtPosition(ray.GetPoint(dist), false) : 0;
	}

	/// <summary>
	/// Move the caret on press.
	/// </summary>

	protected virtual void OnPress(bool isPressed)
	{
		if (isPressed && isSelected && label != null &&
			(UICamera.currentScheme == UICamera.ControlScheme.Mouse ||
			 UICamera.currentScheme == UICamera.ControlScheme.Touch))
		{
#if !UNITY_EDITOR && (UNITY_WP8 || UNITY_WP_8_1)
			if (mKeyboard != null) mKeyboard.active = true;
#endif
			selectionEnd = GetCharUnderMouse();
			if (!Input.GetKey(KeyCode.LeftShift) &&
				!Input.GetKey(KeyCode.RightShift)) selectionStart = mSelectionEnd;
		}
	}

	/// <summary>
	/// Drag selection.
	/// </summary>

	protected virtual void OnDrag(Vector2 delta)
	{
		if (label != null &&
			(UICamera.currentScheme == UICamera.ControlScheme.Mouse ||
			 UICamera.currentScheme == UICamera.ControlScheme.Touch))
		{
			selectionEnd = GetCharUnderMouse();
		}
	}

	/// <summary>
	/// Ensure we've released the dynamically created resources.
	/// </summary>

	void OnDisable() { Cleanup(); }

	/// <summary>
	/// Cleanup.
	/// </summary>

	protected virtual void Cleanup()
	{
		if (mHighlight) mHighlight.enabled = false;
		if (mCaret) mCaret.enabled = false;

		if (mBlankTex)
		{
			NGUITools.Destroy(mBlankTex);
			mBlankTex = null;
		}
	}

	/// <summary>
	/// Update the visual text label.
	/// </summary>

	public void UpdateLabel()
	{
		if (label != null)
		{
			if (mDoInit) Init();
			bool selected = isSelected;
			string fullText = value;
			string processed = fullText;
			// Start with text leading up to the selection
			int selPos = selected ? Mathf.Min(processed.Length, cursorPosition) : 0;
			string left = processed.Substring(0, selPos);

			// Append the composition string and the cursor character
			if (selected) left += Input.compositionString;

			// Append the text from the selection onwards
			processed = left + processed.Substring(selPos, processed.Length - selPos);

			// Clamped content needs to be adjusted further
			if (selected && label.overflowMethod == UILabel.Overflow.ClampContent && label.maxLineCount == 1)
			{
				// Determine what will actually fit into the given line
				int offset = label.CalculateOffsetToFit(processed);

				if (offset == 0)
				{
					mDrawStart = 0;
					label.alignment = mAlignment;
				}
				else if (selPos < mDrawStart)
				{
					mDrawStart = selPos;
					label.alignment = NGUIText.Alignment.Left;
				}
				else if (offset < mDrawStart)
				{
					mDrawStart = offset;
					label.alignment = NGUIText.Alignment.Left;
				}
				else
				{
					offset = label.CalculateOffsetToFit(processed.Substring(0, selPos));

					if (offset > mDrawStart)
					{
						mDrawStart = offset;
						label.alignment = NGUIText.Alignment.Right;
					}
				}

				// If necessary, trim the front
				if (mDrawStart != 0)
					processed = processed.Substring(mDrawStart, processed.Length - mDrawStart);
			}
			else
			{
				mDrawStart = 0;
				label.alignment = mAlignment;
			}

			label.text = processed;
#if MOBILE
			if (selected && (mKeyboard == null || inputShouldBeHidden))
#else
			if (selected)
#endif
			{
				int start = mSelectionStart - mDrawStart;
				int end = mSelectionEnd - mDrawStart;

				// Blank texture used by selection and caret
				if (mBlankTex == null)
				{
					mBlankTex = new Texture2D(2, 2, TextureFormat.ARGB32, false);
					for (int y = 0; y < 2; ++y)
						for (int x = 0; x < 2; ++x)
							mBlankTex.SetPixel(x, y, Color.white);
					mBlankTex.Apply();
				}

				// Create the selection highlight
				if (start != end)
				{
					if (mHighlight == null)
					{
						mHighlight = NGUITools.AddWidget<UITexture>(label.cachedGameObject);
						mHighlight.name = "Input Highlight";
						mHighlight.mainTexture = mBlankTex;
						mHighlight.fillGeometry = false;
						mHighlight.pivot = label.pivot;
						mHighlight.SetAnchor(label.cachedTransform);
					}
					else
					{
						mHighlight.pivot = label.pivot;
						mHighlight.mainTexture = mBlankTex;
						mHighlight.MarkAsChanged();
						mHighlight.enabled = true;
					}
				}

				// Create the carter
				if (mCaret == null)
				{
					mCaret = NGUITools.AddWidget<UITexture>(label.cachedGameObject);
					mCaret.name = "Input Caret";
					mCaret.mainTexture = mBlankTex;
					mCaret.fillGeometry = false;
					mCaret.pivot = label.pivot;
					mCaret.SetAnchor(label.cachedTransform);
				}
				else
				{
					mCaret.pivot = label.pivot;
					mCaret.mainTexture = mBlankTex;
					mCaret.MarkAsChanged();
					mCaret.enabled = true;
				}

				if (start != end)
				{
					label.PrintOverlay(start, end, mCaret.geometry, mHighlight.geometry, caretColor, selectionColor);
					mHighlight.enabled = mHighlight.geometry.hasVertices;
				}
				else
				{
					label.PrintOverlay(start, end, mCaret.geometry, null, caretColor, selectionColor);
					if (mHighlight != null) mHighlight.enabled = false;
				}

				// Reset the blinking time
				mNextBlink = RealTime.time + 0.5f;
				mLastAlpha = label.finalAlpha;
			}
			else Cleanup();
		}
	}

	/// <summary>
	/// Convenience function to be used as a callback that will clear the input field's focus.
	/// </summary>

	public void RemoveFocus() { isSelected = false; }

}
