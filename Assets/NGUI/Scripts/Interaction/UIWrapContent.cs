//----------------------------------------------
//            NGUI: Next-Gen UI kit
// Copyright © 2011-2015 Tasharen Entertainment
//----------------------------------------------

using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// This script makes it possible for a scroll view to wrap its content, creating endless scroll views.
/// Usage: simply attach this script underneath your scroll view where you would normally place a UIGrid:
/// 
/// + Scroll View
/// |- UIWrappedContent
/// |-- Item 1
/// |-- Item 2
/// |-- Item 3
/// </summary>

[AddComponentMenu("NGUI/Interaction/Wrap Content")]
public class UIWrapContent : MonoBehaviour
{
	public enum Sorting
	{
		None,
		Alphabetic,
		Horizontal,
		Vertical,
		Custom,
	}

	public delegate void OnInitializeItem(GameObject go, int wrapIndex, int realIndex);

	/// <summary>
	/// Width or height of the child items for positioning purposes.
	/// </summary>

	public int itemSize = 100;

	/// <summary>
	/// Whether the content will be automatically culled. Enabling this will improve performance in scroll views that contain a lot of items.
	/// </summary>

	public bool cullContent = true;

	/// <summary>
	/// Minimum allowed index for items. If "min" is equal to "max" then there is no limit.
	/// For vertical scroll views indices increment with the Y position (towards top of the screen).
	/// </summary>

	public int minIndex = 0;

	/// <summary>
	/// Maximum allowed index for items. If "min" is equal to "max" then there is no limit.
	/// For vertical scroll views indices increment with the Y position (towards top of the screen).
	/// </summary>

	public int maxIndex = 0;

	/// <summary>
	/// How to sort the grid's elements.
	/// </summary>

	public Sorting sorting = Sorting.None;

	public bool CenterArrange = false;

	public Vector2 Offest = Vector2.zero;

	/// <summary>
	/// Callback that will be called every time an item needs to have its content updated.
	/// The 'wrapIndex' is the index within the child list, and 'realIndex' is the index using position logic.
	/// </summary>

	public OnInitializeItem onInitializeItem;

	protected Transform mTrans;
	protected UIPanel mPanel;
	protected UIScrollView mScroll;
	protected bool mHorizontal = false;
	protected bool mFirstTime = true;
	protected List<Transform> mChildren = new List<Transform>();

	/// <summary>
	/// Initialize everything and register a callback with the UIPanel to be notified when the clipping region moves.
	/// </summary>

	protected virtual void Start()
	{
		Reposition();
		if (mScroll != null) mScroll.GetComponent<UIPanel>().onClipMove = OnMove;
		mFirstTime = false;
	}

	/// <summary>
	/// Callback triggered by the UIPanel when its clipping region moves (for example when it's being scrolled).
	/// </summary>

	protected virtual void OnMove(UIPanel panel)
	{
		//Vector3 size = NGUIMath.CalculateRelativeWidgetBounds(transform).size;
		//Vector4 clip = mPanel.finalClipRegion;
		//if (mHorizontal)
		//{
		//    if (clip.z < size.x)
		//    {
		//        WrapContent();
		//    }
		//}
		//else
		//{
		//    if (clip.w < size.y)
		//    {
		//        WrapContent();
		//    }
		//}
		WrapContent();
	}


	/// <summary>
	/// Immediately reposition all children.
	/// </summary>

	[ContextMenu("Reposition")]
	public virtual void Reposition()
	{
		if (!CacheScrollView()) return;

		mChildren.Clear();
		for (int i = 0; i < mTrans.childCount; ++i)
			mChildren.Add(mTrans.GetChild(i));
		// Sort the list using the desired sorting logic
		if (sorting != Sorting.None)
		{
			if (sorting == Sorting.Alphabetic) mChildren.Sort(UIGrid.SortByName);
			else if (sorting == Sorting.Horizontal) mChildren.Sort(UIGrid.SortHorizontal);
			else if (sorting == Sorting.Vertical) mChildren.Sort(UIGrid.SortVertical);
			//else if (onCustomSort != null) mChildren.Sort(onCustomSort);
			//else Sort(list);
		}
		//
		ResetChildPositions();
		//
		OnMove(null);
	}



	/// <summary>
	/// Cache the scroll view and return 'false' if the scroll view is not found.
	/// </summary>

	protected bool CacheScrollView()
	{
		mTrans = transform;
		mPanel = NGUITools.FindInParents<UIPanel>(gameObject);
		mScroll = mPanel.GetComponent<UIScrollView>();
		if (mScroll == null) return false;
		if (mScroll.movement == UIScrollView.Movement.Horizontal) mHorizontal = true;
		else if (mScroll.movement == UIScrollView.Movement.Vertical) mHorizontal = false;
		else return false;
		return true;
	}

	/// <summary>
	/// Helper function that resets the position of all the children.
	/// </summary>

	protected virtual void ResetChildPositions()
	{
		for (int i = 0, imax = mChildren.Count; i < imax; ++i)
		{
			Transform t = mChildren[i];
			t.localPosition = mHorizontal ? new Vector3(i * itemSize, 0f, 0f) : new Vector3(0f, -i * itemSize, 0f);
			UpdateItem(t, i);
		}
		//
		if (CenterArrange)
		{
			UpdateArrangement();
		}
	}
	void UpdateArrangement()
	{
		Vector3 pos = transform.localPosition;
		Vector4 clip = mPanel.finalClipRegion;
		Vector2 clipOffest = mPanel.clipOffset;
		if (mHorizontal)
		{
			if (mChildren.Count * itemSize >= clip.z)
			{
				pos.x = Mathf.Round(-clip.z * 0.5f + itemSize * 0.5f - clipOffest.x);
			}
			else
			{
				pos.x = Mathf.Round(-(mChildren.Count - 1) * itemSize * 0.5f);
			}
		}
		else
		{
			if (mChildren.Count * itemSize >= clip.w)
			{
				pos.y = Mathf.Round(clip.w * 0.5f - itemSize * 0.5f + clipOffest.y);
			}
			else
			{
				pos.y = Mathf.Round((mChildren.Count - 1) * itemSize * 0.5f);
			}
		}
		transform.localPosition = pos;
	}

	/// <summary>
	/// Wrap all content, repositioning all children as needed.
	/// </summary>

	public virtual void WrapContent()
	{
		//Debug.Log("WrapContent");
		float extents = itemSize * mChildren.Count * 0.5f;
		Vector3[] corners = mPanel.worldCorners;

		for (int i = 0; i < 4; ++i)
		{
			Vector3 v = corners[i];
			v = mTrans.InverseTransformPoint(v);
			corners[i] = v;
		}

		Vector3 center = Vector3.Lerp(corners[0], corners[2], 0.5f);
		bool allWithinRange = true;
		float ext2 = extents * 2f;

		if (mHorizontal)
		{
			float min = corners[0].x - itemSize;
			float max = corners[2].x + itemSize;

			for (int i = 0, imax = mChildren.Count; i < imax; ++i)
			{
				Transform t = mChildren[i];
				float distance = t.localPosition.x - center.x;

				if (distance < -extents)
				{
					Vector3 pos = t.localPosition;
					pos.x += ext2;
					distance = pos.x - center.x;
					int realIndex = Mathf.RoundToInt(pos.x / itemSize);

					if (minIndex == maxIndex || (minIndex <= realIndex && realIndex <= maxIndex))
					{
						t.localPosition = pos;
						UpdateItem(t, i);
					}
					else allWithinRange = false;
				}
				else if (distance > extents)
				{
					Vector3 pos = t.localPosition;
					pos.x -= ext2;
					distance = pos.x - center.x;
					int realIndex = Mathf.RoundToInt(pos.x / itemSize);

					if (minIndex == maxIndex || (minIndex <= realIndex && realIndex <= maxIndex))
					{
						t.localPosition = pos;
						UpdateItem(t, i);
					}
					else allWithinRange = false;
				}
				else if (mFirstTime) UpdateItem(t, i);

				if (cullContent)
				{
					distance += mPanel.clipOffset.x - mTrans.localPosition.x;
					if (!UICamera.IsPressed(t.gameObject))
						NGUITools.SetActive(t.gameObject, (distance > min && distance < max), false);
				}
			}
		}
		else
		{
			float min = corners[0].y - itemSize;
			float max = corners[2].y + itemSize;

			for (int i = 0, imax = mChildren.Count; i < imax; ++i)
			{
				Transform t = mChildren[i];
				float distance = t.localPosition.y - center.y;

				if (distance < -extents)
				{
					Vector3 pos = t.localPosition;
					pos.y += ext2;
					distance = pos.y - center.y;
					int realIndex = Mathf.RoundToInt(pos.y / itemSize);

					if (minIndex == maxIndex || (minIndex <= realIndex && realIndex <= maxIndex))
					{
						t.localPosition = pos;
						UpdateItem(t, i);
					}
					else allWithinRange = false;
				}
				else if (distance > extents)
				{
					Vector3 pos = t.localPosition;
					pos.y -= ext2;
					distance = pos.y - center.y;
					int realIndex = Mathf.RoundToInt(pos.y / itemSize);

					if (minIndex == maxIndex || (minIndex <= realIndex && realIndex <= maxIndex))
					{
						t.localPosition = pos;
						UpdateItem(t, i);
					}
					else allWithinRange = false;
				}
				else if (mFirstTime) UpdateItem(t, i);
				//
				UpdatePosEx(t, center, corners[2].y - corners[0].y);
				//
				if (cullContent)
				{
					distance += mPanel.clipOffset.y - mTrans.localPosition.y;
					if (!UICamera.IsPressed(t.gameObject))
						NGUITools.SetActive(t.gameObject, (distance > min && distance < max), false);
				}
			}
		}
		mScroll.restrictWithinPanel = !allWithinRange;
	}

	void UpdatePosEx(Transform itemTran, Vector3 center, float size)
	{
		size *= 0.5f;
		if (mHorizontal)
		{
			if (Offest.y != 0)
			{
				Vector3 pos = itemTran.localPosition;
				float distance = Mathf.Abs(pos.x - center.x);
				float y = Mathf.Lerp(0f, Offest.y, distance / size);
				pos.y = y;
				itemTran.localPosition = pos;
			}
		}
		else
		{
			if (Offest.x != 0)
			{
				Vector3 pos = itemTran.localPosition;
				float distance = Mathf.Abs(pos.y - center.y);
				float x = Mathf.Lerp(0f, Offest.x, distance / size);
				pos.x = x;
				itemTran.localPosition = pos;
			}
		}
	}

	/// <summary>
	/// Sanity checks.
	/// </summary>

	void OnValidate()
	{
		if (maxIndex < minIndex)
			maxIndex = minIndex;
		if (minIndex > maxIndex)
			maxIndex = minIndex;
	}

	/// <summary>
	/// Want to update the content of items as they are scrolled? Override this function.
	/// </summary>

	protected virtual void UpdateItem(Transform item, int index)
	{
		if (onInitializeItem != null)
		{
			int realIndex = (mScroll.movement == UIScrollView.Movement.Vertical) ?
				Mathf.RoundToInt(item.localPosition.y / itemSize) :
				Mathf.RoundToInt(item.localPosition.x / itemSize);
			onInitializeItem(item.gameObject, index, realIndex);
		}
	}
}
