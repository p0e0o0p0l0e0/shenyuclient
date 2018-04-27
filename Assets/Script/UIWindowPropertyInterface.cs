using System;
using System.Collections.Generic;
using UnityEngine;

public class UIWindowPropertyInterface : MonoBehaviour
{
	public UIButton CloseBtn;
	public GameObject ScaleTweener;
	public UIPanel BackEffectPanel;

	public virtual void Initialize()
	{
	}

	public T AddUIScript<T>() where T : MonoBehaviour
	{
		return gameObject.AddComponent<T>();
	}

	public void SendInitMessage()
	{
		gameObject.SendMessage("Initialize", this, SendMessageOptions.DontRequireReceiver);
	}

	public void Hide()
	{
		gameObject.SetActive(false);
	}
}
