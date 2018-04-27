//----------------------------------------------
//    Custom Popup List (Clip)
//----------------------------------------------

using UnityEngine;
using System.Collections.Generic;
using System.Collections;

/// <summary>
/// Popup list can be used to display pop-up menus and drop-down lists.
/// </summary>

[ExecuteInEditMode]
[AddComponentMenu("NGUI/Interaction/Popup List Ex (Clip)")]
public class UIPopupListEx_Clip : UIPopupList
{
	public int LimitHeight = 0;
	//
	public UIAtlas ScrollBarAtlas;
	public string ScrollBarBG;
	public string ScrollBarFG;
	public int ScrollBarWidth = 30;
	public int ScrollBarFGPaddingLeft = 2;
	public int ScrollBarFGPaddingRight = -2;
	public int ScrollBarFGPaddingTop = -2;
	public int ScrollBarFGPaddingBottom = 2;

	//protected override void OnSelect(bool isSelected)
	//{
	//    _selected = isSelected;
	//    StartCoroutine("ClosePopupList");
	//}

	IEnumerator ClosePopupList()
	{
		yield return 1;
		//
		if (!_selected)
		{
			base.CloseSelf();
			_scrollView = null;
			_scrollPanel = null;
		}
	}

	public override void CloseSelf()
	{
		if (enabled && NGUITools.GetActive(gameObject))
		{
			StopCoroutine("CloseIfUnselected");
			StartCoroutine("ClosePopupList");
		}
	}

	public override void Show()
	{
		if (enabled && NGUITools.GetActive(gameObject) && popupListObj == null && atlas != null && isValid && items.Count > 0)
		{
			mLabelList.Clear();
			StopCoroutine("CloseIfUnselected");
			StopCoroutine("ClosePopupList");

			// Ensure the popup's source has the selection
			UICamera.selectedObject = gameObject;
			mSelection = UICamera.selectedObject;
			source = UICamera.selectedObject;

			if (source == null)
			{
				Debug.LogError("Popup list needs a source object...");
				return;
			}

			mOpenFrame = Time.frameCount;

			// Automatically locate the panel responsible for this object
			if (mParentPanel == null)
			{
				mParentPanel = UIPanel.Find(transform);
				if (mParentPanel == null) return;
			}

			// Calculate the dimensions of the object triggering the popup list so we can position it below it
			Vector3 min;
			Vector3 max;

			// Create the root object for the list
			popupListObj = new GameObject("Drop-down List");
			popupListObj.layer = gameObject.layer;
			//
			UIPanel subPanel = null;
			if (separatePanel)
			{
				if (GetComponent<Collider>() != null)
				{
					Rigidbody rb = popupListObj.AddComponent<Rigidbody>();
					rb.isKinematic = true;
				}
				else if (GetComponent<Collider2D>() != null)
				{
					Rigidbody2D rb = popupListObj.AddComponent<Rigidbody2D>();
					rb.isKinematic = true;
				}
				subPanel = popupListObj.AddComponent<UIPanel>();
				subPanel.depth = 1000000;
			}
			current = this;
			//
			Transform popupListTran = popupListObj.transform;
			popupListTran.parent = mParentPanel.cachedTransform;
			Vector3 pos;

			// Manually triggered popup list on some other game object
			if (openOn == OpenOn.Manual && mSelection != gameObject)
			{
				pos = UICamera.lastEventPosition;
				min = mParentPanel.cachedTransform.InverseTransformPoint(mParentPanel.anchorCamera.ScreenToWorldPoint(pos));
				max = min;
				popupListTran.localPosition = min;
				pos = popupListTran.position;
			}
			else
			{
				Bounds bounds = NGUIMath.CalculateRelativeWidgetBounds(mParentPanel.cachedTransform, transform, false, false);
				min = bounds.min;
				max = bounds.max;
				popupListTran.localPosition = min;
				pos = popupListTran.position;
			}

			StartCoroutine("CloseIfUnselected");

			popupListTran.localRotation = Quaternion.identity;
			popupListTran.localScale = Vector3.one;

			// Add a sprite for the background
			mBackground = NGUITools.AddSprite(popupListObj, atlas, backgroundSprite, separatePanel ? 0 : NGUITools.CalculateNextDepth(mParentPanel.gameObject));
			mBackground.pivot = UIWidget.Pivot.TopLeft;
			mBackground.color = backgroundColor;
			//
			GameObject mChildObj = new GameObject("Child");
			mChildObj.layer = gameObject.layer;
			mChildObj.transform.parent = mBackground.transform;
			mChildObj.transform.localRotation = Quaternion.identity;
			mChildObj.transform.localScale = Vector3.one;
			mChildObj.transform.localPosition = Vector3.zero;

			// We need to know the size of the background sprite for padding purposes
			Vector4 bgPadding = mBackground.border;
			mBgBorder = bgPadding.y;
			mBackground.cachedTransform.localPosition = new Vector3(0f, bgPadding.y, 0f);

			// Add a sprite used for the selection
			mHighlight = NGUITools.AddSprite(mChildObj, atlas, highlightSprite, mBackground.depth + 1);
			mHighlight.pivot = UIWidget.Pivot.TopLeft;
			mHighlight.color = highlightColor;

			UISpriteData hlsp = mHighlight.GetAtlasSprite();
			if (hlsp == null) return;

			float fontHeight = activeFontSize;
			float dynScale = activeFontScale;
			float labelHeight = fontHeight * dynScale;
			float x = 0f, y = -padding.y;
			List<UILabel> labels = new List<UILabel>();

			// Clear the selection if it's no longer present
			if (!items.Contains(mSelectedItem))
				mSelectedItem = null;

			// Run through all items and create labels for each one
			for (int i = 0, imax = items.Count; i < imax; ++i)
			{
				string s = items[i];

				UILabel lbl = NGUITools.AddWidget<UILabel>(mChildObj, mBackground.depth + 2);
				lbl.name = i.ToString();
				lbl.pivot = UIWidget.Pivot.TopLeft;
				lbl.bitmapFont = bitmapFont;
				lbl.trueTypeFont = trueTypeFont;
				lbl.fontSize = fontSize;
				lbl.fontStyle = fontStyle;
				lbl.text = isLocalized ? Localization.Get(s) : s;
				lbl.color = textColor;
				lbl.cachedTransform.localPosition = new Vector3(bgPadding.x + padding.x - lbl.pivotOffset.x, y, -1f);
				lbl.overflowMethod = UILabel.Overflow.ResizeFreely;
				lbl.alignment = alignment;
				labels.Add(lbl);

				y -= labelHeight;
				y -= padding.y;
				x = Mathf.Max(x, lbl.printedSize.x);

				// Add an event listener
				UIEventListener listener = UIEventListener.Get(lbl.gameObject);
				listener.onHover = OnItemHover;
				listener.onPress = OnItemPress;
				listener.parameter = s;

				// Move the selection here if this is the right label
				if (mSelectedItem == s || (i == 0 && string.IsNullOrEmpty(mSelectedItem)))
					Highlight(lbl, true);

				// Add this label to the list
				mLabelList.Add(lbl);
			}

			// The triggering widget's width should be the minimum allowed width
			x = Mathf.Max(x, (max.x - min.x) - (bgPadding.x + padding.x) * 2f);

			float cx = x;
			Vector3 bcCenter = new Vector3(cx * 0.5f, -labelHeight * 0.5f, 0f);
			Vector3 bcSize = new Vector3(cx, (labelHeight + padding.y), 1f);

			// Run through all labels and add colliders
			for (int i = 0, imax = labels.Count; i < imax; ++i)
			{
				UILabel lbl = labels[i];
				NGUITools.AddWidgetCollider(lbl.gameObject);
				lbl.autoResizeBoxCollider = false;
				BoxCollider bc = lbl.GetComponent<BoxCollider>();

				if (bc != null)
				{
					bcCenter.z = bc.center.z;
					bc.center = bcCenter;
					bc.size = bcSize;
				}
				else
				{
					BoxCollider2D b2d = lbl.GetComponent<BoxCollider2D>();
#if UNITY_4_3 || UNITY_4_5 || UNITY_4_6
					b2d.center = bcCenter;
#else
					b2d.offset = bcCenter;
#endif
					b2d.size = bcSize;
				}
			}

			int lblWidth = Mathf.RoundToInt(x);
			x += (bgPadding.x + padding.x) * 2f;
			y -= bgPadding.y;

			// Scale the background sprite to envelop the entire set of items
			mBackground.width = Mathf.RoundToInt(x);
			int actualHeight = Mathf.RoundToInt(-y + bgPadding.y);
			bool needClipPanel = LimitHeight > 0 && actualHeight > LimitHeight;
			if (needClipPanel)
			{
				mBackground.height = LimitHeight;
				//
				_scrollPanel = mChildObj.AddComponent<UIPanel>();
				_scrollPanel.depth = separatePanel ? subPanel.depth + 1 : 1000000;
				_scrollPanel.clipping = UIDrawCall.Clipping.SoftClip;
				_scrollPanel.clipSoftness = new Vector2(1f, 1f);
				_scrollPanel.SetAnchor(mBackground.gameObject, 2, 10, -2, -10);
				_scrollPanel.updateAnchors = UIRect.AnchorUpdate.OnUpdate;
				//
				_scrollView = mChildObj.AddComponent<UIScrollView>();
				_scrollView.movement = UIScrollView.Movement.Vertical;
				_scrollView.dragEffect = UIScrollView.DragEffect.MomentumAndSpring;
				_scrollView.contentPivot = UIWidget.Pivot.Top;
				_scrollView.scrollWheelFactor = 2f;
				//+
				CreateScrollBar();
			}
			else
			{
				mBackground.height = actualHeight;
			}
			// Scale the highlight sprite to envelop a single item
			float scaleFactor = 2f * atlas.pixelSize;
			float w = x - (bgPadding.x + padding.x) * 2f + hlsp.borderLeft * scaleFactor;
			float h = labelHeight + hlsp.borderTop * scaleFactor;
			mHighlight.width = Mathf.RoundToInt(w);
			mHighlight.height = Mathf.RoundToInt(h);

			// Set the label width to make alignment work
			for (int i = 0, imax = labels.Count; i < imax; ++i)
			{
				UILabel lbl = labels[i];
				lbl.overflowMethod = UILabel.Overflow.ShrinkContent;
				lbl.width = lblWidth;
				//
				if (needClipPanel)
				{
					UIDragScrollView dargView = lbl.gameObject.AddComponent<UIDragScrollView>();
					dargView.scrollView = _scrollView;
				}
			}
			//
			bool placeAbove = (position == Position.Above);

			if (position == Position.Auto)
			{
				UICamera cam = UICamera.FindCameraForLayer(mSelection.layer);

				if (cam != null)
				{
					Vector3 viewPos = cam.cachedCamera.WorldToViewportPoint(pos);
					placeAbove = (viewPos.y < 0.5f);
				}
			}

			// If the list should be animated, let's animate it by expanding it
			if (isAnimated)
			{
				AnimateColor(mBackground);

				if (Time.timeScale == 0f || Time.timeScale >= 0.1f)
				{
					float bottom = y + labelHeight;
					Animate(mHighlight, placeAbove, bottom);
					for (int i = 0, imax = labels.Count; i < imax; ++i)
						Animate(labels[i], placeAbove, bottom);
					AnimateScale(mBackground, placeAbove, bottom);
				}
			}

			// If we need to place the popup list above the item, we need to reposition everything by the size of the list
			if (placeAbove)
			{
				min.y = max.y - bgPadding.y;
				max.y = min.y + mBackground.height;
				max.x = min.x + mBackground.width;
				popupListTran.localPosition = new Vector3(min.x, max.y - bgPadding.y, min.z);
			}
			else
			{
				max.y = min.y + bgPadding.y;
				min.y = max.y - mBackground.height;
				max.x = min.x + mBackground.width;
			}

			Transform pt = mParentPanel.cachedTransform.parent;

			if (pt != null)
			{
				min = mParentPanel.cachedTransform.TransformPoint(min);
				max = mParentPanel.cachedTransform.TransformPoint(max);
				min = pt.InverseTransformPoint(min);
				max = pt.InverseTransformPoint(max);
			}

			// Ensure that everything fits into the panel's visible range

			Vector3 offset = mParentPanel.hasClipping ? Vector3.zero : mParentPanel.CalculateConstrainOffset(min, max);
			pos = popupListTran.localPosition + offset;
			pos.x = Mathf.Round(pos.x);
			pos.y = Mathf.Round(pos.y);
			popupListTran.localPosition = pos;
			//
		}
		else OnSelect(false);
	}

	void CreateScrollBar()
	{
		if (ScrollBarAtlas != null && _scrollView != null && _scrollPanel != null)
		{
			UIScrollBar scrollBar = NGUITools.AddChild<UIScrollBar>(mBackground.gameObject);
			GameObject scrollBarObj = scrollBar.gameObject;
			//
			UIPanel panel = scrollBarObj.AddComponent<UIPanel>();
			panel.depth = _scrollPanel.depth + 1;
			//
			UISprite background = NGUITools.AddSprite(scrollBarObj, ScrollBarAtlas, ScrollBarBG, 0);
			background.width = ScrollBarWidth;
			background.height = LimitHeight;
			background.pivot = UIWidget.Pivot.Top;
			background.transform.localPosition = Vector3.zero;
			BoxCollider collider = background.gameObject.AddComponent<BoxCollider>();
			collider.size = new Vector3(background.width, background.height, 1f);
			UISprite foreground = NGUITools.AddSprite(scrollBarObj, ScrollBarAtlas, ScrollBarFG, 1);
			foreground.pivot = UIWidget.Pivot.Top;
			foreground.SetAnchor(background.gameObject, ScrollBarFGPaddingLeft, ScrollBarFGPaddingBottom, ScrollBarFGPaddingRight, ScrollBarFGPaddingTop);
			collider = foreground.gameObject.AddComponent<BoxCollider>();
			collider.size = new Vector3(foreground.width, foreground.height, 1f);
			//
			scrollBar.foregroundWidget = foreground;
			scrollBar.backgroundWidget = background;
			scrollBar.fillDirection = UIProgressBar.FillDirection.TopToBottom;
			//
			_scrollView.verticalScrollBar = scrollBar;
			//_scrollView.showScrollBars = UIScrollView.ShowCondition.Always;
			//
			Vector3 pos = new Vector3(mBackground.width + ScrollBarWidth * 0.5f, 0f, 0f);
			scrollBarObj.transform.localPosition = pos;
			//
			StartCoroutine("RefreshScrollBar");
		}
	}

	IEnumerator RefreshScrollBar()
	{
		yield return new WaitForSeconds(0.12f);
		//
		_scrollView.InvalidateBounds();
		_scrollView.RestrictWithinBounds(true);
		_scrollView.UpdateScrollbars(true);
		_scrollView.verticalScrollBar.backgroundWidget.ResizeCollider();
		UIEventListener listener = UIEventListener.Get(_scrollView.verticalScrollBar.backgroundWidget.gameObject);
		listener.onSelect = this.OnSelectScrollBar;
		listener = UIEventListener.Get(_scrollView.verticalScrollBar.foregroundWidget.gameObject);
		listener.onSelect = this.OnSelectScrollBar;
	}

	void OnSelectScrollBar(GameObject obj, bool select)
	{
		_selected = select;
		if (!select)
		{
			CloseSelf();
		}
	}


	UIPanel _scrollPanel;
	UIScrollView _scrollView;
	bool _selected = false;
}
