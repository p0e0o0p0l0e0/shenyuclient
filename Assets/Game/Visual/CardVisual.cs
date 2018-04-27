using System;
using System.Collections.Generic;
using UnityEngine;


public class CardVisual
{
	public static ViConstValue<float> VALUE_CardShowScale = new ViConstValue<float>("CardShowScale", 1.5f);

	public delegate void DeleComplete(CardVisual card);
	public DeleComplete CompleteCallback;

	public ViVector3 Position { get { return Root.transform.position.Convert(); } }
	public ViVector3 VisualPosition
	{
		get
		{
			if (_visual != null)
			{
				return _visual.transform.position.Convert();
			}
			else
			{
				return _root.transform.position.Convert();
			}
		}
	}
	public GameObject Root { get { return _root; } }
	public GameObject Visual { get { return _visual; } }
	public Collider Collider { get { return _collider; } }

	public void SetScale(float scale)
	{
		SetScale(scale, false);
	}
	public void SetScale(float scale, bool immediate)
	{
		_scale = scale;
		//
		if (immediate)
		{
			_scaleInterprolation.StopAt(_scale);
			_root.transform.localScale = Vector3.one * scale;
		}
	}

	public void Start(string name, PathFileStruct res)
	{
		_root = new GameObject("CardFaction_" + name);

        mResLoader.Start(res.Path + "/" + res.File, res.File, OnLoad);
		_tickNode.Attach(this._Tick);

		_positionInterprolation.SetSample(1.0f, 0.3f);
		_rotationInterprolation.SetSample(180.0f, 0.5f);
		_scaleInterprolation.SetSample(1.0f, 0.1f);
	}

	public void SetPos(Vector3 pos, Quaternion rot, bool immediate)
	{
		_position = pos;
		_rotation = rot;
		//
		if (immediate)
		{
			Root.transform.position = pos;
			Root.transform.rotation = rot;
			_positionInterprolation.StopAt(_position);
			_rotationInterprolation.StopAt(_rotation);
		}
	}

	public void SetPos(Transform pos, bool immediate)
	{
		if (pos != null)
		{
			SetPos(pos.position, pos.rotation, immediate);
		}
	}

	public bool Pick(ViVector3 pos)
	{
		if (_collider == null)
		{
			return false;
		}
		//
		pos.z += 10.0f;
		Ray ray = new Ray(pos.Convert(), new Vector3(0, -1.0f, 0));
		RaycastHit hitResult;
		if (_collider.Raycast(ray, out hitResult, 100.0f))
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	void OnLoad(UnityEngine.Object pAsset)
	{
		if (_visual != null)
		{
			UnityAssisstant.Destroy(ref _visual);
		}
		//
		_visual = UnityAssisstant.InstantiateAsChild(pAsset as GameObject, _root.transform);
		//
		//_visual.AddComponent<UIPanel>();
		//_AddUILabel(_visual, "CostLabel", 20, UILabel.Overflow.ResizeFreely);
		//_AddUILabel(_visual, "AttackLabel", 20, UILabel.Overflow.ResizeFreely);
		//_AddUILabel(_visual, "HPLabel", 20, UILabel.Overflow.ResizeFreely);
		//_AddUILabel(_visual, "NameLabel", 12, UILabel.Overflow.ResizeFreely);
		//_AddUILabel(_visual, "DescLabel", 12, UILabel.Overflow.ResizeHeight);
		//_AddUILabel(_visual, "TypeLabel", 12, UILabel.Overflow.ResizeFreely);
		//
		_collider = Visual.GetComponent<Collider>();
		//
		if (CompleteCallback != null)
		{
			CompleteCallback(this);
		}
	}

	//void _AddUILabel(GameObject root, string nodeName, int fontSize, UILabel.Overflow flow)
	//{
	//    Transform tran = root.transform.Find(nodeName);
	//    if (tran != null)
	//    {
	//        UILabel label = tran.gameObject.AddComponent<UILabel>();
	//        label.trueTypeFont = GlobalGameObject.Instance.CardFont;
	//        label.overflowMethod = flow;
	//        label.fontSize = fontSize;
	//        label.effectStyle = UILabel.Effect.Outline;
	//        if (flow != UILabel.Overflow.ResizeFreely)
	//        {
	//            label.width = 80;
	//        }
	//    }
	//}

	public void End()
	{
        mResLoader.End();
        _tickNode.Detach();
		//
		if (_root != null)
		{
			UnityAssisstant.Destroy(ref _root);
		}
		_visual = null;
		//
		CompleteCallback = null;
	}

	public void SetCardCost(string text)
	{
		//UIHelp.UpdateLabel(_visual, "CostLabel", text);
	}
	public void SetCardName(string text)
	{
		//UIHelp.UpdateLabel(_visual, "NameLabel", text);
	}
	public void SetCardDesc(string text)
	{
		//UIHelp.UpdateLabel(_visual, "DescLabel", text);
	}
	public void SetCardType(string text)
	{
		//UIHelp.UpdateLabel(_visual, "TypeLabel", text);
	}
	public void SetCardAttack(string text)
	{
		//UIHelp.UpdateLabel(_visual, "AttackLabel", text);
	}
	public void SetCardHP(string text)
	{
		//UIHelp.UpdateLabel(_visual, "HPLabel", text);
	}

	ViTickNode _tickNode = new ViTickNode();
	void _Tick(float deltaTime)
	{
		bool updated = false;
		if (_positionInterprolation.Update(_position, deltaTime))
		{
			updated = true;
		}
		if (_rotationInterprolation.Update(_rotation, deltaTime))
		{
			updated = true;
		}
		if (_scaleInterprolation.Update(_scale, deltaTime))
		{
			updated = true;
		}
		if (updated)
		{
			_root.transform.position = _positionInterprolation.Value;
			_root.transform.rotation = _rotationInterprolation.Value;
			_root.transform.localScale = Vector3.one * _scaleInterprolation.Value;
		}
	}

	GameObject _root;
	GameObject _visual;
	Collider _collider;
	//
	Vector3 _position = Vector3.zero;
	Vector3Interpolation _positionInterprolation = new Vector3Interpolation();
	Quaternion _rotation = Quaternion.identity;
	QuaternionInterpolation _rotationInterprolation = new QuaternionInterpolation();
	float _scale = 1.0f;
	ViValueInterpolation _scaleInterprolation = new ViValueInterpolation();
    ResourceRequest mResLoader = new ResourceRequest();
}
