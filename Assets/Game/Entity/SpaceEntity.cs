using System;
using System.Collections.Generic;
using UnityEngine;

public class SpaceEntity : ViGeographicObject, TickInterface, ViGeographicInterface, PickalbeInterface
{
	public static ViConstValue<float> VALUE_PhysicsIKStandardForce = new ViConstValue<float>("PhysicsIKStandardForce", 3000.0f);
	public static ViConstValue<ViVector3> VALUE_PhysicsGravity = new ViConstValue<ViVector3>("PhysicsGravity", new ViVector3(0, 0, -15));
	public static ViConstValue<float> VALUE_EntityCameraOffsetDuration = new ViConstValue<float>("EntityCameraOffsetDuration", 1.0f);
	public static ViConstValue<float> VALUE_AttackColorScale = new ViConstValue<float>("AttackColorScale", 0.5f);
	public static ViConstValue<float> VALUE_AttackColorSpan = new ViConstValue<float>("AttackColorSpan", 0.2f);
	//
	public Client Client { get { return _client; } set { _client = value; } }
	public virtual bool IsLocal { get { return false; } }
	public Avatar VisualBody { get { return _visualBody; } }
	public Colorize Colorizer { get { return _colorize; } }
	public virtual string Name { get { return "SpaceEntity"; } }
	public ViPriorityValue<float> MoveAnimStantardSpeed { get { return _moveAnimStandardSpeed; } }
	public ViPriorityValue<float> YawCursorDuration { get { return _yawCursorDuration; } }
	public virtual float AnimationSpeed { get { return 1.0f; } }
	public ViPriorityValue<float> Scale { get { return _scale; } }
	public BodyPhysics Physics { get { return _bodyPhysics; } }
	public override float BodyRadius { get { return 0.5f; } }
	public virtual bool VisualRotate { get { return false; } }
	public override float Yaw
	{
		get { return _yaw; }
		set
		{
			_yaw = value;
			ViAngle.Normalize(ref _yaw);
		}
	}
	public override ViVector3 Position
	{
		get { return Physics.Position; }
		set { SetPos(value); }
	}
	public ViProvider<ViVector3> PosProvider { get { return Physics.PosProvider; } }
	public ViProvider<ViVector3> CameraPosProvider { get { return PosProvider; } }
	public ViSimpleProvider<ViAngle> CameraYawProvider { get { return _cameraYawProvider; } }
	public ViProvider<ViVector3> HeadPosProvider { get { return new ViOffSetVector3Provider(PosProvider, new ViVector3(0, 0, BodyHeight)); } }
	public ViProvider<ViVector3> CenterPosProvider { get { return new ViOffSetVector3Provider(PosProvider, new ViVector3(0, 0, BodyHeight * 0.6f)); } }
	public ViVector3 CenterPosition { get { return Physics.Position + new ViVector3(0, 0, BodyHeight * 0.6f); } }
	public virtual float BodyHeight { get { return 2.0f; } }

	public ViPriorityValue<bool> VisualActive { get { return _visuable; } }
	public bool IsVisualReady { get { return !_visualBody.Loading; } }
	public ViPriorityValue<AvatarDestroyType> DestroyType { get { return _destroyType; } }
	public ViPriorityValue<string> DestroyAnim { get { return _destroyAnim; } }
	public ViPriorityValue<bool> PickActive { get { return _pickable; } }

	public List<Rigidbody> RigidbodyList { get { return _rigidbodyList; } }
	public List<Collider> CollderList { get { return _collderList; } }
	public List<CharacterJoint> JiontList { get { return _jiontList; } }

	public void Init()
	{
		VisualActive.UpdatedExec = this.OnVisuableUpdated;
		Scale.UpdatedExec = this.onScaleUpdated;
	}

	public void Clear()
	{
		TickManager.Detach(_updateNode);
        //

        _pickableNode.End();


        CharactorExplosion.End(_visualBody.Root, _rigidbodyList, _collderList, _jiontList);
		_colorize.End();
		//
		if (!string.IsNullOrEmpty(DestroyAnim.Value))
		{
			_visualBody.PlayStateAnim(DestroyAnim.Value);
		}
		switch (DestroyType.Value)
		{
			case AvatarDestroyType.EXIT:
				_visualBody.Clear(0.0f);
				break;
			case AvatarDestroyType.DROP:
				_visualBody.Clear(1.0f);
				break;
			case AvatarDestroyType.DISSOLVE:
				_visualBody.Clear(0.0f);
				break;
			default:
				_visualBody.Clear();
				break;
		}
		//
		VisualActive.UpdatedExec = null;
		//
		//ResHolder.End();
		_ClearReference();
	}

	ViDoubleLinkNode2<TickInterface> _updateNode = new ViDoubleLinkNode2<TickInterface>();
	public void Update(float deltaTime)
	{
		Physics.Update(deltaTime);
        //
        Physics.SetYaw(_yaw);
        //
		_yawCursor.Update(deltaTime, _yaw);
        //
        _cameraYawProvider.SetValue(new ViAngle(_yawCursor.Direction));
		//
		_colorize.Update(deltaTime);
		//
		UpdateTransform(0.0f);
		//
		UpdateProvider();
        VisualBody.UpdateShadow(Physics.Position.z);

    }

	public virtual void OnVisuableUpdated()
	{
		_visualBody.Active = VisualActive.Value;
	}

	public void OnVisuableUpdated(bool oldValue, bool newValue)
	{
		OnVisuableUpdated();
	}

	public void onScaleUpdated(float oldValue, float newValue)
	{
		_visualBody.RootTran.localScale = Vector3.one * Scale.Value;
	}

	public void SetTickState(string tag, int weight, bool value)
	{
		_tickable.Add(tag, weight, value);
		UpdateTickState();
	}
	public void ClearTickState(string tag)
	{
		_tickable.Del(tag);
		UpdateTickState();
	}
	void UpdateTickState()
	{
		if (_tickable.Value)
		{
			TickManager.PushBack(_updateNode, this, false);
		}
		else
		{
			_updateNode.Detach();
		}
	}

	#region Geo

	public void OnMoveTo(ViVector3 Pos)
	{
		Physics.MoveTo(Pos, true, true);
		Physics.GetDestOnceEventor.Attach(_getDestCallbackNode, this.OnMoveGetDest);
        //
        OnMoveToAnim();

    }

	public void OnMoveTo(List<ViVector3> PosList)
	{
		Physics.MoveTo(PosList, true, true);
		Physics.GetDestOnceEventor.Attach(_getDestCallbackNode, this.OnMoveGetDest);
        //
        OnMoveToAnim();

    }

    virtual public void OnMoveToAnim()
    {
        VisualBody.AnimController.MoveLayer.Play(VisualBody.Anim, AnimationData.Run03, true);
        VisualBody.MoveAnimMixer.SetActive(VisualBody.Anim, true);
    }

	public void OnBreakMove(ViVector3 pos, float yaw)
	{
		_yaw = yaw;
		Physics.BreakMove();
		Physics.SetPos(pos);
		VisualBody.AnimController.MoveLayer.Stop(VisualBody.Anim);
		VisualBody.MoveAnimMixer.SetActive(VisualBody.Anim, false);
        BreakMove();
    }

	public void OnBreakMove(float yaw)
	{
		_yaw = yaw;
		Physics.BreakMove();
		VisualBody.AnimController.MoveLayer.Stop(VisualBody.Anim);
		VisualBody.MoveAnimMixer.SetActive(VisualBody.Anim, false);
        BreakMove();
    }

	ViCallback _getDestCallbackNode = new ViCallback();
	void OnMoveGetDest(UInt32 eventID)
	{
		VisualBody.AnimController.MoveLayer.Stop(VisualBody.Anim);
		VisualBody.MoveAnimMixer.SetActive(VisualBody.Anim, false);

        OnMoveEnd();
    }
    virtual public void OnMoveEnd()
    {

    }
    virtual public void BreakMove()
    {

    }
    public void OnUpdateYaw(float value)
	{
		_yaw = value;
	}

	public void OnUpdatePosYaw(ViVector3 pos, float yaw)
	{
		_yaw = yaw;
		Physics.SetPos(pos);
		VisualBody.AnimController.MoveLayer.Stop(VisualBody.Anim);
		VisualBody.MoveAnimMixer.SetActive(VisualBody.Anim, false);
	}

	public void SetPos(ViVector3 pos, float yaw)
	{
		_yaw = yaw;
		Physics.SetPos(pos);
		VisualBody.AnimController.MoveLayer.Stop(VisualBody.Anim);
		VisualBody.MoveAnimMixer.SetActive(VisualBody.Anim, false);
	}

	public void SetPos(ViVector3 pos)
	{
		Physics.SetPos(pos);
		VisualBody.AnimController.MoveLayer.Stop(VisualBody.Anim);
		VisualBody.MoveAnimMixer.SetActive(VisualBody.Anim, false);
	}

	public void SetYaw(float value)
	{
		_yaw = value;
	}

	#endregion

	#region Visual

	public void SetVisual(GameObject res)
	{
		//_visualBody.SetVisual(res);
		_visualBody.Name = "Entity_" + Name;
		_visualBody.RootTran.localScale = Vector3.one * Scale.Value;
		_visualBody.LoadCallback = null;
		//
		_yawCursor.Direction = Yaw;
		//
		UpdateTickState();
		//
		OnVisualLoad(_visualBody);
	}

	public void SetVisual(PathFileResStruct body, List<ViForeignKeyStruct<PathFileResStruct>> partList)
	{
		_visualBody.LODLevel = EntityAssisstant.AvatarLODLevel(this);
        AvatarCreator.Create(_visualBody, body,1.0f, partList);

        _visualBody.Name = "Entity_" + Name;
		_visualBody.RootTran.localScale = Vector3.one * Scale.Value;
		_visualBody.LoadCallback = this.OnVisualLoad;
		_yawCursorDuration.UpdatedExec = this.UpdateYawCursorDuration;
        _yawCursor.Direction = Yaw;
        _yawCursor.SetSample(3.14f, _yawCursorDuration.Value);
		//
		UpdateTranPath();
		UpdateTransform(0.0f);
		//
		UpdateTickState();
	}

	public void UpdateTransform(float animRot)
	{
		GroundWinger.Update(Position, _yawCursor.Direction + animRot, ViVector3.UNIT_Z, _rootPosTran, _rootRotTran);
	}

	public void UpdateGlobalTransform(float yaw)
	{
		GroundWinger.Update(Position, yaw, ViVector3.UNIT_Z, _rootPosTran, _rootRotTran);
	}

	public void UpdateTranPath()
	{
		_rootPosTran = _visualBody.RootTran;
		//
		if (VisualRotate)
		{
			if (_visualBody.Property != null)
			{
				_rootRotTran = _visualBody.Property.MoveMix;
			}
			else
			{
				_rootRotTran = null;
			}
		}
		else
		{
			_rootRotTran = _visualBody.RootTran;
		}
	}

	public bool IsLeftDir
	{
		get { return Yaw < 0; }
	}

	public void ForceYawCursor()
	{
		_yawCursor.Direction = Yaw;
	}

	public void PlayActionAnim(string name)
	{
		VisualBody.PlayActionAnim(name, true);
	}
	public void PlayStateAnim(string name)
	{
		VisualBody.PlayStateAnim(name);
	}
	public void StopStateAnim(string name)
	{
		VisualBody.StopStateAnim(name);
	}

	public virtual void OnVisualLoad0() { }
	public virtual void OnVisualLoad1() { }
	void OnVisualLoad(Avatar avatar)
	{
		for (int iter = 0; iter < _providerList.Length; ++iter)
		{
			ProviderNode iterProvider = _providerList[iter];
			if (iterProvider != null)
			{
				Transform iterTran = VisualBody.Property.GetAttachPos(iter);
				iterProvider.Tran = iterTran;
				iterProvider.Provider = new ViSimpleProvider<ViVector3>(iterTran.position.Convert());
			}
		}
		//
		_yawCursor.Direction = Yaw;
		_colorize.Start(_visualBody.Root);
		_visualBody.Active = VisualActive.Value;
		if (_visualBody.Property.BodyLow != null)
		{
			_visualBody.Property.BodyLow.SetActive(EntityAssisstant.ActiveMirrorShadowBody(this));
		}
		//
		UpdateTranPath();
		UpdateTransform(0.0f);
		//
		OnVisualLoad0();
		OnVisualLoad1();


        // set pickable
        _pickableNode.Start(_visualBody.Visual, this);

    }

	static float GetRunAnim(float localWeistYaw, out string animName)
	{
		ViAngle.Normalize(ref localWeistYaw);
        animName = "";
        //
        if (localWeistYaw < -ViMathDefine.PI * 0.75f)
		{
			//animName = AnimationData.RunBackward;
			return -ViMathDefine.PI;
		}
		else if (localWeistYaw < -ViMathDefine.PI * 0.25f)
		{
			//animName = AnimationData.RunLeft;
			return -ViMathDefine.PI * 0.5f;
		}
		else if (localWeistYaw < ViMathDefine.PI * 0.25)
		{
			//animName = AnimationData.RunForward;
			return 0.0f;
		}
		else if (localWeistYaw < ViMathDefine.PI * 0.75f)
		{
			//animName = AnimationData.RunRight;
			return ViMathDefine.PI * 0.5f;
		}
		else
		{
			//animName = AnimationData.RunBackward;
			return ViMathDefine.PI;
		}
	}

	#endregion

	void UpdateYawCursorDuration(float oldValue, float newValue)
	{
        _yawCursor.SetSample(3.14f, _yawCursorDuration.Value);
	}

	public void AddLookYaw(float value)
	{
		
	}
	public void DelLookYaw()
	{
		
	}
	public void AddMoveYaw(float value)
	{
        
    }
	public void DelMoveYaw()
	{

	}

	#region Provider

	class ProviderNode
	{
		public Transform Tran;
		public ViSimpleProvider<ViVector3> Provider;
	}

	public Transform GetTransform(int pos)
	{
		if (VisualBody.Property != null)
		{
			return VisualBody.Property.GetAttachPos(pos);
		}
		else
		{
			return VisualBody.RootTran;
		}
	}

	public ViProvider<ViVector3> GetPosProvider(int pos)
	{
		if (VisualBody.Loading)
		{
			return PosProvider;
		}
		else
		{
			return GetProvider(pos).Provider;
		}
	}

	ProviderNode GetProvider(int pos)
	{
		pos = ViMathDefine.Clamp(pos, 0, (int)AvatarAttachNode.TOTAL - 1);
		ProviderNode node = _providerList[pos];
		if (node == null)
		{
			node = new ProviderNode();
			Transform tran = GetTransform(pos);
			node.Tran = tran;
			node.Provider = new ViSimpleProvider<ViVector3>(tran.position.Convert());
			_providerList[pos] = node;
		}
		//
		return node;
	}

	void UpdateProvider()
	{
		for (int iter = 0; iter < _providerList.Length; ++iter)
		{
			ProviderNode iterProvider = _providerList[iter];
			if (iterProvider != null)
			{
				iterProvider.Provider.SetValue(iterProvider.Tran.position.Convert());
			}
		}
	}

    public void OnFocusOn()
    {
        //throw new NotImplementedException();
        //if (_client.LocalHero != null)
        //    _client.LocalHero.FocusEntity(this);
    }

    public void OnFocusOff()
    {
        //throw new NotImplementedException();
    }

    public void OnPressed()
    {
        //throw new NotImplementedException();
    }

    public void OnReleased()
    {
        //throw new NotImplementedException();
    }

    public void OnMove()
    {
        //throw new NotImplementedException();
    }

    #endregion

    Client _client;
	//
	Avatar _visualBody = new Avatar();
	Transform _rootPosTran;
	Transform _rootRotTran;
	Colorize _colorize = new Colorize();
	BodyPhysics _bodyPhysics = new BodyPhysics();
	//
	float _yaw;
    ViAngleCursor2 _yawCursor = new ViAngleCursor2();
    //ViActiveValue<float> _yawValue = new ViActiveValue<float>();
	ViPriorityValue<float> _yawCursorDuration = new ViPriorityValue<float>(0.2f);
	//
	ViSimpleProvider<ViAngle> _cameraYawProvider = new ViSimpleProvider<ViAngle>();
	//
	ViPriorityValue<bool> _tickable = new ViPriorityValue<bool>(true);
	ViPriorityValue<bool> _visuable = new ViPriorityValue<bool>(true);
	ViPriorityValue<bool> _pickable = new ViPriorityValue<bool>(true);
	ViPriorityValue<float> _moveAnimStandardSpeed = new ViPriorityValue<float>(5.0f);
	ViPriorityValue<float> _scale = new ViPriorityValue<float>(1.0f);
	ViPriorityValue<AvatarDestroyType> _destroyType = new ViPriorityValue<AvatarDestroyType>(AvatarDestroyType.DEFAULT);
	ViPriorityValue<string> _destroyAnim = new ViPriorityValue<string>(string.Empty);
	ProviderNode[] _providerList = new ProviderNode[(int)AvatarAttachNode.TOTAL];
	//
	List<Rigidbody> _rigidbodyList = new List<Rigidbody>();
	List<Collider> _collderList = new List<Collider>();
	List<CharacterJoint> _jiontList = new List<CharacterJoint>();

    PickableNode _pickableNode = new PickableNode();
}


