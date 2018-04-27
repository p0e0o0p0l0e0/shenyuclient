/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class AvatarStage
{
	public delegate void LoadDele();
	public LoadDele OnCompleteLoadCallback;

	public GameObject Root { get { return _root; } }

	public void Load(PathFileResStruct res)
	{
		_root = new GameObject("Stage");
        //
        mResLoader.Start(res, _OnResLoaded);
	}

	public void End()
	{
        mResLoader.End();
        UnityAssisstant.Destroy(ref _root);
	}

	protected virtual void _OnResLoaded(UnityEngine.Object pAsset)
	{
		if (_root == null)
		{
			ViDebuger.Warning("Resource Root is Null!");
			return;
		}
		UnityAssisstant.InstantiateAsChild(pAsset as GameObject, _root.transform);
		//
		if (OnCompleteLoadCallback != null)
		{
			OnCompleteLoadCallback();
		}
	}
    
	GameObject _root;
    ResourceRequest mResLoader = new ResourceRequest();
}

public class UnitRender2UI
{
	public Avatar Avatar { get { return _avatar; } }
	public Camera RTTCamera { get { return _RTTCamera; } }
	//


	public UnitRender2UI()
	{
		_layer = (int)UnityLayer.RTT_HERO;
	}

	public virtual void RenderToUI(UIWidget parentWidget, RTTStruct pram, PathFileResStruct avatarRes, ViStaticArray<ViForeignKeyStruct<PathFileResStruct>> partList)
	{
		if (parentWidget == null || avatarRes == null)
		{
			return;
		}
		//
		_root = UnityAssisstant.CreateChild(GlobalGameObject.Instance.RTTRoot.transform, avatarRes.AssetBundleSectionName, true);
		//
		_parentWidget = parentWidget;
		_RttConfig = pram;
		_avatar = new Avatar();
		_avatar.LoadCallback = this.OnAvatarLoaded;
		AvatarCreator.Create(_avatar, avatarRes, 1.0f,partList);
		//
		if (_RttConfig.StageRes.NotEmpty())
		{
			_stage = new AvatarStage();
			_stage.OnCompleteLoadCallback = this._OnStageLoaded;
			_stage.Load(_RttConfig.StageRes.Data);
		}
		//
		RenderToUI();
	}

	protected void RenderToUI()
	{
		_RTTScript = _parentWidget.GetComponent<UIRTT>();
		if (_RTTScript == null)
		{
			_RTTScript = _parentWidget.gameObject.AddComponent<UIRTT>();
		}
		_RTTScript.Depth = _parentWidget.depth;
		_RTTScript.RenderSize = new Vector2(_parentWidget.width, _parentWidget.height);
		//
		_InitCamera(_layer);
		//
		_RTTScript.RenderToTexture(_RTTCamera);
	}

	void _InitCamera(int layer)
	{
		if (_RTTCamera == null)
		{
			GameObject obj = UnityAssisstant.InstantiateAsChild(GlobalGameObject.Instance.RTTCameraPrefab, _root.transform);
			_RTTCamera = obj.GetComponent<Camera>();
		}
		if (_RTTCamera == null)
		{
			ViDebuger.AssertWarning(_RTTCamera);
			return;
		}
		UnityAssisstant.SetLayerRecursively(_RTTCamera.gameObject, layer);
		UnityAssisstant.SetComponentState<BloomOptimized>(_RTTCamera.gameObject, ApplicationSetting.Instance.GraphicsBloom != 0);
		UnityAssisstant.SetComponentState<ColorCorrectionCurves>(_RTTCamera.gameObject, ApplicationSetting.Instance.GraphicsColorEnhance != 0);
		_RTTCamera.cullingMask = 1 << layer;
		_RTTCamera.transform.localPosition = ((ViVector3)_RttConfig.CameraPos).Convert();
		_RTTCamera.transform.localRotation = Quaternion.Euler(((ViVector3)_RttConfig.CameraOri).Convert());
	}

	public void UpdateCameraSetting()
	{
		if (_RTTCamera != null)
		{
			UnityAssisstant.SetComponentState<BloomOptimized>(_RTTCamera.gameObject, ApplicationSetting.Instance.GraphicsBloom != 0);
			UnityAssisstant.SetComponentState<ColorCorrectionCurves>(_RTTCamera.gameObject, ApplicationSetting.Instance.GraphicsColorEnhance != 0);
		}
	}

	public void ModCameraFieldView(float delta, float inf, float sup)
	{
		if (_RTTCamera != null)
		{
			float value = ViMathDefine.Clamp(_RTTCamera.fieldOfView + delta, inf, sup);
			_RTTCamera.fieldOfView = value;
		}
	}

	protected virtual void OnAvatarLoaded(Avatar avatar)
	{
		_avatar.RootTran.parent = _root.transform;
		UnityAssisstant.SetLayerRecursively(_avatar.Root, _layer);
		_avatar.Root.name = "HeroRTT";
		//
		_avatar.RootTran.localPosition = ((ViVector3)_RttConfig.AvatarPos).Convert();
		_avatar.RootTran.localRotation = Quaternion.Euler(((ViVector3)_RttConfig.AvatarOri).Convert());
		//int scale = ViMathDefine.Max(1, _RttConfig.AvatarScale);
		//_avatar.RootTran.localScale = Vector3.one * scale * 0.01f;
	}

	protected void _OnStageLoaded()
	{
		_stage.Root.transform.parent = _root.transform;
		UnityAssisstant.SetLayerRecursively(_stage.Root, _layer);
	}

	public void End()
	{
		_Clear();
		if (_avatar != null)
		{
			_avatar.Clear();
			_avatar = null;
		}
		_parentWidget = null;
		_RttConfig = null;
		_RTTCamera = null;
		if (_stage != null)
		{
			_stage.End();
			_stage = null;
		}
		UnityAssisstant.Destroy(ref _root);
	}

	protected virtual void _Clear()
	{
		if (_RTTScript != null)
		{
			_RTTScript.End();
		}
		if (_RTTCamera != null)
		{
			NGUITools.Destroy(_RTTCamera.gameObject);
		}
	}

	public void RotateAvatar(float angle)
	{
		if (_avatar != null)
		{
			_avatar.RootTran.Rotate(0, angle, 0);
		}
	}

	public void ModAvatarPos_Y(float delta)
	{
		if (_avatar != null)
		{
			float y = ((ViVector3)_RttConfig.AvatarPos).Convert().y;
			Vector3 pos = _avatar.RootTran.localPosition;
			pos.y = ViMathDefine.Clamp(pos.y + delta, y - 0.5f, y + 0.5f);
			_avatar.RootTran.localPosition = pos;
		}
	}

	public void SetAutoRotateEnable(bool enable)
	{
		if (_avatar != null)
		{
			FXCurveAnimation_Rotation script = _avatar.Root.GetComponentInChildren<FXCurveAnimation_Rotation>();
			if (script != null)
			{
				script.enabled = enable;
			}
		}
	}

	public virtual void PlayAvatarShow()
	{
		//PlayAnim(AnimationData.Show);
	}

	public void PlayAnim(string anim)
	{
		if (Avatar == null)
		{
			return;
		}
		if (Avatar.Visual == null)
		{
			return;
		}
		if (Avatar.IsActionAnimPlaying())
		{
			return;
		}
		//
		AnimationControllerEx kanBanNiang = Avatar.Visual.GetComponent<AnimationControllerEx>();
		if (kanBanNiang != null && kanBanNiang.HasAnimationName(anim))
		{
			kanBanNiang.Play(anim, Avatar);
		}
		else
		{
			Avatar.PlayActionAnim(anim, true);
		}
	}

	int _layer = (int)UnityLayer.SUP;
	UIWidget _parentWidget = null;
	RTTStruct _RttConfig = null;
	//
	Camera _RTTCamera = null;
	GameObject _root = null;
	Avatar _avatar = null;
	AvatarStage _stage = null;
	//
	UIRTT _RTTScript;

}
*/