using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AnimationControllerExProperty))]
public class AnimationControllerEx : MonoBehaviour
{
	public static bool EnterAnimationShowed = false;

	void Awake()
	{
		_property = GetComponent<AnimationControllerExProperty>();
	}

	public bool HasAnimationName(string animationName)
	{
		for (Int32 iter = 0; iter < _property.AnimationClips.Count; ++iter)
		{
			AnimationClipEx iterClip = _property.AnimationClips[iter];
			if (iterClip.AnimationName == animationName)
			{
				return true;
			}
		}
		//
		return false;
	}

	public void Play(string animationName, Avatar avater)
	{
		_End();
		for (Int32 iter = 0; iter < _property.AnimationClips.Count; ++iter)
		{
			AnimationClipEx iterClip = _property.AnimationClips[iter];
			if (iterClip.AnimationName == animationName)
			{
				avater.PlayActionAnim(animationName, true);
				_PlayAnimationEvent(avater.VisualTran, iterClip);
				break;
			}
		}
	}

	public void PlayAnimator(string animationName, GameObject obj)
	{
		_End();
		for (Int32 iter = 0; iter < _property.AnimationClips.Count; ++iter)
		{
			AnimationClipEx iterClip = _property.AnimationClips[iter];
			if (iterClip.AnimationName == animationName)
			{
				Animator animator = obj.GetComponentInChildren<Animator>();
				if (animator != null)
				{
					animator.Play(animationName);
				}
				//
				_PlayAnimationEvent(obj.transform, iterClip);
				break;
			}
		}
	}

	void _PlayAnimationEvent(Transform tran, AnimationClipEx iterClip)
	{
		for (Int32 iter = 0; iter < iterClip.AnimationEvents.Count; ++iter)
		{
			AnimationEventEx iterEvent = iterClip.AnimationEvents[iter];
			FunctionExpressEx express = new FunctionExpressEx();
			Transform iterTran = UnityAssisstant.GetChildRecursively(tran, iterEvent.NodeName);
			if (iterTran == null)
			{
				return;
			}
			//
			if (iterEvent.Enable && iterEvent.Destory)
			{
				GameObject obj = UnityAssisstant.Instantiate(iterTran.gameObject);
				if (iterEvent.Sound)
				{
					AudioSource audioSource = obj.GetComponentInChildren<AudioSource>();
					if (audioSource != null)
					{
						audioSource.volume = ApplicationSetting.Instance.SoundVolumeScale;
					}
				}
				//
				obj.transform.parent = UnityAssisstant.GetChildRecursively(tran, iterEvent.ParentName);
				obj.transform.position = iterTran.position;
				obj.transform.rotation = iterTran.rotation;
				obj.transform.localScale = iterTran.localScale;
				obj.layer = iterTran.gameObject.layer;
				express.Start(obj.transform, iterEvent);
			}
			else
			{
				if (iterEvent.Sound)
				{
					AudioSource audioSource = iterTran.GetComponentInChildren<AudioSource>();
					if (audioSource != null)
					{
						audioSource.volume = ApplicationSetting.Instance.SoundVolumeScale;
					}
				}
				//
				express.Start(iterTran, iterEvent);
			}
			//
			_ownExpressList.Add(express);
		}
	}

	void OnDestroy()
	{
		_End();
	}

	void OnDisable()
	{
		_End();
	}

	void _End()
	{
		_ownExpressList.End();
	}

	AnimationControllerExProperty _property;
	ViExpressOwnList<ViExpressInterface> _ownExpressList = new ViExpressOwnList<ViExpressInterface>();
}
