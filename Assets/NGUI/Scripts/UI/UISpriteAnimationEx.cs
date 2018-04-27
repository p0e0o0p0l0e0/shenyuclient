//----------------------------------------------
//           
//----------------------------------------------

using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Very simple sprite animation. Attach to a sprite and specify a common prefix such as "idle" and it will cycle through them.
/// </summary>

[ExecuteInEditMode]
[RequireComponent(typeof(UISprite))]
[AddComponentMenu("NGUI/UI/Sprite Animation Ex")]
public class UISpriteAnimationEx : UISpriteAnimation
{
	[HideInInspector]
	[SerializeField]
	protected List<float> mSpriteDurationList = new List<float>();

	public List<float> SpriteDuringList
	{
		get { return mSpriteDurationList; }
		set
		{
			mSpriteDurationList = value;
			mIndex = 0;
		}
	}

	
	/// <summary>
	/// Advance the sprite animation process.
	/// </summary>

	protected override void Update ()
	{
		if (!Application.isPlaying)
		{
			return;
		}
		//
		if (mActive && mSpriteNames.Count > 1 && mSpriteDurationList.Count == mSpriteNames.Count)
		{
			mDelta += RealTime.deltaTime;
			//
			if (mDelta > mSpriteDurationList[mIndex])
			{
				if (++mIndex >= mSpriteNames.Count)
				{
					mIndex = 0;
					mActive = mLoop;
				}
				mDelta = 0f;
			}
			//
			if (mActive)
			{
				mSprite.spriteName = mSpriteNames[mIndex];
				if (mSnap) mSprite.MakePixelPerfect();
			}
		}
		else if (mSpriteNames.Count == 1)
		{
			mSprite.spriteName = mSpriteNames[0];
			if (mSnap) mSprite.MakePixelPerfect();
		}
	}


}
