using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class UIExpress : ViExpressInterface
{
	static readonly int DELTA_Q = 100;

	public delegate void LoadDele();
	public LoadDele OnCompleteLoadCallback;

	public GameObject Root { get { return _root; } }
	public GameObject RealObj { get { return _realObj; } }

	public bool UseParticleClip = false;
	public bool LODLow = false;

	public void Start(PathFileResStruct res, UIWidget widget)
	{
		Start(res, widget, DELTA_Q);
	}
	public void Start(PathFileResStruct res, UIWidget widget, int deltaQ)
	{
		Load(res);
		//
		_renderQWidget = widget;
		Init(widget.transform, deltaQ);
	}

	public void Start(PathFileResStruct res, UIPanel renderPanel)
	{
		Start(res, renderPanel, DELTA_Q);
	}
	public void Start(PathFileResStruct res, UIPanel renderPanel, int deltaQ)
	{
		Load(res);
		//
		_renderQPanel = renderPanel;
		Init(renderPanel.transform, deltaQ);
	}

	void Init(Transform parent, int deltaQ)
	{
		_root.transform.parent = parent;
		_root.transform.localPosition = Vector3.zero;
		_root.transform.localRotation = Quaternion.identity;
		_root.layer = parent.gameObject.layer;
		_deltaQ = deltaQ;
	}

	void Load(PathFileResStruct res)
	{
		_root = new GameObject("Particle_" + res.AssetBundleSectionName);
        //
        mResLoader.Start(res, _OnResLoaded);
	}

	public void SetParent(Transform parent)
	{
		SetParent(parent, Vector3.zero);
	}
	public void SetParent(Transform parent, Vector3 pos)
	{
		_root.transform.parent = parent;
		_root.transform.localPosition = pos;
	}

	public override void End()
	{
        mResLoader.End();
        _rednerQTimeNode.Detach();
		_renderQWidget = null;
		_renderQPanel = null;
		if (_root != null)
		{
			UnityAssisstant.DelComponent<UIPanelClipToParticle>(_root);
			_particleClipScript = null;
		}
		UnityAssisstant.Destroy(ref _root);
	}

	protected virtual void _OnResLoaded(UnityEngine.Object pAsset)
	{
		if (_root == null)
		{
			ViDebuger.Warning("Resource Root is Null!");
			return;
		}
		_realObj = UnityAssisstant.InstantiateAsChild(pAsset as GameObject, _root.transform);
		UnityAssisstant.SetLayerRecursively(_root, _root.layer);
		//
		if (_renderQWidget != null)
		{
			_renderQWidget.onRender = _OnRenderQUpdateCallback;
		}
		else if (_renderQPanel != null)
		{
			UpdateRenderQ(_renderQPanel.startingRenderQueue);
			ViTimerInstance.SetTime(_rednerQTimeNode, 0.2f, this._OnRenderQTime);
		}
		//
		if (UseParticleClip)
		{
			_particleClipScript = _root.AddComponent<UIPanelClipToParticle>();
		}
		//_root.transform.localScale *= (float)580.0f / ((float)UIRoot.list[0].activeHeight);
		if (OnCompleteLoadCallback != null)
		{
			OnCompleteLoadCallback();
		}
		//
	}
	void _OnRenderQUpdateCallback(Material srcMat)
	{
		UpdateRenderQ(srcMat.renderQueue);
	}
	//
	ViTimeNode1 _rednerQTimeNode = new ViTimeNode1();
	void _OnRenderQTime(ViTimeNodeInterface node)
	{
		_rednerQTimeNode.Detach();
		UpdateRenderQ(_renderQPanel.startingRenderQueue);
	}


	void UpdateRenderQ(int startValue)
	{
		UnityComponentList<Renderer>.Begin(_root, true);
		for (int iter = 0; iter < UnityComponentList<Renderer>.List.Count; ++iter)
		{
			Renderer iterRender = UnityComponentList<Renderer>.List[iter];
			Material[] materials = iterRender.materials;
			for (int index = 0; index < materials.Length; ++index)
			{
				Material material = materials[index];
				material.renderQueue = startValue + _deltaQ;
			}
		}
		UnityComponentList<Renderer>.End();
	}

	public void ModObjectRenderQ(string objPath, int deltaQ)
	{
		if (Root == null || RealObj == null)
		{
			return;
		}
		GameObject obj = RealObj.GetChild(objPath);
		if (obj != null)
		{
			UnityComponentList<Renderer>.Begin(obj, true);
			for (int iter = 0; iter < UnityComponentList<Renderer>.List.Count; ++iter)
			{
				Renderer iterRender = UnityComponentList<Renderer>.List[iter];
				Material[] materials = iterRender.materials;
				for (int index = 0; index < materials.Length; ++index)
				{
					Material material = materials[index];
					material.renderQueue += deltaQ;
				}
			}
			UnityComponentList<Renderer>.End();
		}
	}

	protected GameObject _root;
	GameObject _realObj;
	//
	UIWidget _renderQWidget;
	UIPanel _renderQPanel;
	int _deltaQ;
	//
	UIPanelClipToParticle _particleClipScript = null;
    ResourceRequest mResLoader = new ResourceRequest();
}

public class UIExpressWithAnimator : UIExpress
{
	protected override void _OnResLoaded(UnityEngine.Object pAsset)
	{
		base._OnResLoaded(pAsset);
		_animator = _root.GetComponentInChildren<Animator>();
	}

	public override void End()
	{
		_animator = null;
		base.End();
	}

	public void PlayAnimNormalize(string anim, float normailizeTime)
	{
		if (_animator != null)
		{
			_animator.speed = 0f;
			_animator.Play(anim, -1, normailizeTime);
		}
	}

	public void PlayAnim(string anim)
	{
		if (_animator != null)
		{
			_animator.Play(anim);
		}
	}

	Animator _animator = null;
}
