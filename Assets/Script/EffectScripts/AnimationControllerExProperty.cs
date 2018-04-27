using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


[Serializable]
public class AnimationEventEx
{
	public float DelayTime;
	public bool Destory;
	public bool Sound;
	public string ParentName;
	public string NodeName;
	public bool Enable;
	public float Duration;
	public bool EndEnable;
}

[Serializable]
public class AnimationClipEx
{
	public string AnimationName;
	public List<AnimationEventEx> AnimationEvents = new List<AnimationEventEx>();
}

[Serializable]
public class AnimationControllerExProperty : MonoBehaviour
{
	public List<AnimationClipEx> AnimationClips = new List<AnimationClipEx>();

	void Awake()
	{
		UnityComponentCreator.Create(gameObject, "AnimationControllerEx");
	}
}
