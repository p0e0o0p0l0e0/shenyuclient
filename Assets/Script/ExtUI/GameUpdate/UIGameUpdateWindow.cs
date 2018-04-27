using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class UIGameUpdateWindow : MonoBehaviour
{

	public delegate void ClickDele();
	public ClickDele OnOKCallback;
	public ClickDele OnCancelCallback;

	public UISprite BgSprite;
	public GameObject ConfirmPart;
	public UILabel LoadContent;
	public UILabel NetLabel;
	public UILabel CanceLabel;
	public UILabel OKLabel;
	public GameObject LoadingPart;
	public UISlider LoadingSlider;
	public UILabel LoadingLabel;
	public UILabel LoadingPercent;

	public void ResizeBG(UIRoot root)
	{
		BgSprite.MakePixelPerfect();
		float scale = 1f * BgSprite.width / BgSprite.height;
		int height = Screen.height;
		BgSprite.height = Mathf.RoundToInt(height * root.pixelSizeAdjustment);
		BgSprite.width = Mathf.RoundToInt(height * scale * root.pixelSizeAdjustment);
	}

	public void SetConfirmVisible(bool visible)
	{
		ConfirmPart.SetActive(visible);
	}

	public void SetLoadContent(string text)
	{
		LoadContent.text = text;
	}

	public void SetNetState(string text)
	{
		NetLabel.text = text;
	}

	public void SetCancelButtonText(string cancelText)
	{
		CanceLabel.text = cancelText;
	}
	public void SetOKButtonText(string okText)
	{
		OKLabel.text = okText;
	}

	public void SetLoadingVisible(bool visible)
	{
		LoadingPart.SetActive(visible);
	}

	public void SetLoadingState(string text)
	{
		LoadingLabel.text = text;
	}

	public void SetLoadingPercent(float percent, string text)
	{
		LoadingSlider.value = percent;
		LoadingPercent.text = text;
	}

	public void OnOkLoadingMsg()
	{
		if (OnOKCallback != null)
		{
			OnOKCallback();
		}
	}

	public void OnCancelLoadingMsg()
	{
		if (OnCancelCallback != null)
		{
			OnCancelCallback();
		}
	}


}
