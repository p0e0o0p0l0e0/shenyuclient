using System;
using System.Collections.Generic;

public class VisualAuraWatcher : ViReceiveDataArrayNodeWatcher<ReceiveDataVisualAuraProperty>
{
	public static Int64 GetReserveDuration(ReceiveDataVisualAuraProperty property)
	{
		return property.EndTime + CellRecord.Instance.Property.StartTime - ViTimerInstance.Time;
	}

	public Int64 Duration { get { return GetReserveDuration(Property); } }
	public Int64 EndTime { get { return Property.EndTime + CellRecord.Instance.Property.StartTime; } }
	public ViAuraStruct LogicInfo { get { return _logicInfo; } }
	public ViVisualAuraStruct VisualInfo { get { return _visualInfo; } }

    public int ID
    {
        get
        {
            if (_logicInfo != null)
            {
                return _logicInfo.ID;
            }
            if (_visualInfo != null)
            {
                return _visualInfo.ID;
            }
            return 0;
        }
    }

    public bool IsVisualAuraState
    {
        get
        {
            return _visualInfo.IsNotNull() &&
            _visualInfo.effectStruct.IsNotNull() &&
            (ViAuraEffectConditionType)_visualInfo.effectStruct.effectConditionType.Value != ViAuraEffectConditionType.NONE;
        }
    }
    public bool IsRage { get { return IsVisualAuraState && (ViAuraEffectConditionType)_visualInfo.effectStruct.effectConditionType.Value == ViAuraEffectConditionType.RAGE; } }

	public override void OnStart(ReceiveDataVisualAuraProperty property, ViEntity entity)
	{
		GameUnit gameUnit = (GameUnit)entity;
		_logicInfo = ViSealedDB<ViAuraStruct>.Data(property.Effect);
		_visualInfo = ViSealedDB<ViVisualAuraStruct>.Data(property.Effect);
		if (gameUnit.IsVisualReady)
		{
			VisualStart(property, gameUnit, _visualInfo);
			//
			if (_visualInfo.animStart.res != string.Empty)
			{
				gameUnit.VisualBody.PlayActionAnim(_visualInfo.animStart.res, true);
			}
            //
            //if (!string.IsNullOrEmpty(_visualInfo.materialAnim))
            //{
            //    UnityComponentList<MaterialPropertyAnimation>.Begin(gameUnit.RealBody.RootObject);
            //    MaterialPropertyAnimation.SetState(UnityComponentList<MaterialPropertyAnimation>.List, _visualInfo.materialAnim, true);
            //    MaterialPropertyAnimation.SetStartValue(UnityComponentList<MaterialPropertyAnimation>.List, _visualInfo.materialAnim);
            //    UnityComponentList<MaterialPropertyAnimation>.End();
            //}
        }

        if (IsVisualAuraState)
            gameUnit.AddVisualAuraState(_visualInfo.effectStruct.effectConditionType);
        if (IsRage)
        {
            _summonEntity = new LocalSummonEntity();
            _summonEntity.ID = (ulong)_visualInfo.ID;
            _summonEntity.LoadedCallBack = _OnSummonEntityLoaded;
            _summonEntity.SetScale(_visualInfo.effectStruct.effectAvatar.Scale);
            _summonEntity.SetVisual(_visualInfo.effectStruct.effectAvatar.res, null);
            _summonEntity.Start(gameUnit.GetTransform(_visualInfo.effectStruct.effectAvatar.attachPos));
        }
    }
    private void _OnSummonEntityLoaded()
    {
        if (_summonEntity != null)
        {
            _summonEntity.PlayActionAnim(_visualInfo.effectStruct.effectAnimStart.res);
        }
    }

	public void OnVisualReady(ReceiveDataVisualAuraProperty property, GameUnit entity)
	{
		_express.End(false);
		_linkExpressList.End();
		//
		VisualStart(property, entity, _visualInfo);
		//
		//if (!string.IsNullOrEmpty(_visualInfo.materialAnim))
		//{
		//    UnityComponentList<MaterialPropertyAnimation>.Begin(entity.RealBody.RootObject);
		//    MaterialPropertyAnimation.SetState(UnityComponentList<MaterialPropertyAnimation>.List, _visualInfo.materialAnim, true);
		//    MaterialPropertyAnimation.SetEndValue(UnityComponentList<MaterialPropertyAnimation>.List, _visualInfo.materialAnim);
		//    UnityComponentList<MaterialPropertyAnimation>.End();
		//}
	}

	public override void OnUpdate(ReceiveDataVisualAuraProperty property, ViEntity entity)
	{
		GameUnit gameUnit = (GameUnit)entity;
		if (gameUnit.IsLocal && _visualInfo.progressBar != 0)
		{
			VisualProgressBarStruct progressBarInfo = ViSealedDB<VisualProgressBarStruct>.GetData(_visualInfo.progressBar);
			if (progressBarInfo != null)
			{
				//ViewControllerManager.AddProgress((UInt32)progressBarInfo.ID, ViTimerInstance.Time, EndTime);
			}
		}
	}
	public override void OnEnd(ReceiveDataVisualAuraProperty property, ViEntity entity)
	{
		GameUnit gameUnit = (GameUnit)entity;
		//
		LinkEnd();
		//
		if (_visualInfo.animEnd.res != string.Empty)
		{
			gameUnit.VisualBody.PlayActionAnim(_visualInfo.animEnd.res, true);
		}
		//
		_express.End(!entity.Active);
		//
		if (gameUnit.IsLocal && _visualInfo.progressBar != 0)
		{
			VisualProgressBarStruct progressBarInfo = ViSealedDB<VisualProgressBarStruct>.GetData(_visualInfo.progressBar);
			if (progressBarInfo != null)
			{
				//ViewControllerManager.DelProgress((UInt32)progressBarInfo.ID);
			}
		}
		//
		_casterEntityEventNode.End();
		//
		if (!VisualInfo.vanishVisual.IsEmpty() && !property.Caster.Value.Empty)
		{
			GameUnit caster = Client.Current.EntityManager.GetEntity<GameUnit>(property.Caster.Value.Data.Value);
			gameUnit.OnEffectVisual(caster, VisualInfo.vanishVisual, ViVector3.ZERO, null);
		}
        //
        //if (!string.IsNullOrEmpty(_visualInfo.materialAnim))
        //{
        //    UnityComponentList<MaterialPropertyAnimation>.Begin(gameUnit.RealBody.RootObject);
        //    MaterialPropertyAnimation.SetStartValue(UnityComponentList<MaterialPropertyAnimation>.List, _visualInfo.materialAnim);
        //    MaterialPropertyAnimation.SetState(UnityComponentList<MaterialPropertyAnimation>.List, _visualInfo.materialAnim, false);
        //    UnityComponentList<MaterialPropertyAnimation>.End();
        //}

        if (IsVisualAuraState)
        {
            gameUnit.RemoveVisualAuraState(_visualInfo.effectStruct.effectConditionType);
            for (int i = 0; i < _timeNode1List.Count; i++)
            {
                _timeNode1List[i].Detach();
                _timeNode1List[i] = null;
            }
            _timeNode1List.Clear();
            _timeNode1List = null;
        }
        if (IsRage)
        {
            if (_summonEntity != null)
            {
                _summonEntity.PlayActionAnim(_visualInfo.effectStruct.effectAnimEnd.res);
                _summonEntity.End();
                UnityEngine.GameObject.Destroy(_summonEntity.VisualBody.Root);
            }
            _summonEntity = null;
        }
    }

    public void UpdateAuraEffect(ReceiveDataVisualAuraProperty property, GameUnit entity ,ViVector3 targetPos)
    {
        UpdateAuraEffect(property,entity,(ViAuraEffectConditionType)_visualInfo.effectStruct.effectConditionType.Value, targetPos);
    }
    public void UpdateAuraEffect(ReceiveDataVisualAuraProperty property, GameUnit entity, ViAuraEffectConditionType type, ViVector3 targetPos,uint index = 0)
    {
        if (_visualInfo.IsNull() || _visualInfo.effectStruct.IsNull())
        {
            return;
        }
        if ((ViAuraEffectConditionType)_visualInfo.effectStruct.effectConditionType.Value != type)
        {
            return;
        }
        switch (type)
        {
            case ViAuraEffectConditionType.RAGE:
                {
                    //狂暴，主角普攻，特效普攻
                    //获取巨像模型，播放动画，播放巨像特效
                    if (_summonEntity != null)
                    {
                        _summonEntity.PlayEffectVisual(_visualInfo.effectStruct,index);
                    }
                }
                break;
            case ViAuraEffectConditionType.BLOCK:
                {
                    //格挡，无敌buff，被击打出现格挡特效
                    PlayEffectVisual(_visualInfo.effectStruct,entity.VisualBody);
                }
                break;
        }
    }
    public void PlayEffectVisual(ViVisualAuraStruct.EffectStruct effectStruct,Avatar avatar)
    {
        if (effectStruct == null)
        {
            return;
        }
        switch ((ViEffectPlayType)effectStruct.effectPlayType.Value)
        {
            case ViEffectPlayType.PUSHALL:
                {
                    int flag = 0;
                    foreach (ViAttachExpressStruct expressInfo in effectStruct.express.Array)
                    {
                        _timeNode1List[flag].Value1 = avatar;
                        _timeNode1List[flag].Value2 = expressInfo;
                        if ((ViAuraEffectAnimType)effectStruct.effectAnimType.Value == ViAuraEffectAnimType.CONDITION)
                            _timeNode1List[flag].Value3 = effectStruct.effectAnim[flag];
                        ViTimerInstance.SetTime<Avatar,ViAttachExpressStruct, ViAnimStruct>(_timeNode1List[flag], effectStruct.effectAnimDelayTime[flag],_OnWaitDelayCallBack);
                        flag++;
                    }
                }
                break;
            case ViEffectPlayType.ONEBYONE:
                {
                    int flag = 0;
                    int delayTime = 0;
                    foreach (ViAttachExpressStruct expressInfo in effectStruct.express.Array)
                    {
                        if (flag == 0)
                            delayTime = effectStruct.effectAnimDelayTime[flag];
                        _timeNode1List[flag].Value1 = avatar;
                        _timeNode1List[flag].Value2 = expressInfo;
                        if ((ViAuraEffectAnimType)effectStruct.effectAnimType.Value == ViAuraEffectAnimType.CONDITION)
                            _timeNode1List[flag].Value3 = effectStruct.effectAnim[flag];
                        ViTimerInstance.SetTime<Avatar, ViAttachExpressStruct, ViAnimStruct>(_timeNode1List[flag], delayTime, _OnWaitDelayCallBack);
                        flag++;
                        delayTime += effectStruct.effectAnimDelayTime[flag];
                    }
                }
                break;
            case ViEffectPlayType.RANDOM:
                {
                    int flag = UnityEngine.Random.Range(0, effectStruct.Reserve_1);
                    if (flag < effectStruct.express.Array.Length)
                    {
                        _timeNode1List[flag].Value1 = avatar;
                        _timeNode1List[flag].Value2 = effectStruct.express.Array[flag];
                        if ((ViAuraEffectAnimType)effectStruct.effectAnimType.Value == ViAuraEffectAnimType.CONDITION)
                            _timeNode1List[flag].Value3 = effectStruct.effectAnim[flag];
                        ViTimerInstance.SetTime<Avatar, ViAttachExpressStruct, ViAnimStruct>(_timeNode1List[flag], effectStruct.effectAnimDelayTime[flag], _OnWaitDelayCallBack);
                    }
                }
                break;
        }
    }
    private void _OnWaitDelayCallBack(ViTimeNodeInterface node,Avatar avatar, ViAttachExpressStruct expressInfo, ViAnimStruct animInfo)
    {
        if (avatar == null)
        {
            return;
        }
        if (!expressInfo.IsEmpty())
        {
            AttachedSpaceExpress express = new AttachedSpaceExpress();
            express.CameraAnim = false;
            express.AttachMask = (UInt32)expressInfo.attachMask;
            ViVector3 offset = new ViVector3(0, 0, _visualInfo.height * 0.01f);
            express.Start(expressInfo.res.Data, 0.0f, avatar.Property.GetAttachPos(expressInfo.attachPos), offset);
            _expressList.Add(express);
        }
        if (!animInfo.IsEmpty())
        {
            avatar.PlayActionAnim(animInfo.res,true);
        }
    }

    void VisualStart(ReceiveDataVisualAuraProperty property, GameUnit gameUnit, ViVisualAuraStruct visualInfo)
	{
		GameUnit caster = null;
		if (!property.Caster.Value.Empty)
		{
			caster = Client.Current.EntityManager.GetEntity<GameUnit>(property.Caster.Value.Data.Value);
			Client.Current.EntityManager.AttachEventNode(_casterEntityEventNode, property.Caster.Value.Data.Value, this.OnCasterEntityEvent);
		}
		string visualLevel = EntityAssisstant.GetFactionColor(caster, gameUnit);
		//
		_express.Start(gameUnit, gameUnit.VisualBody, visualInfo, visualLevel);
		//
		if (gameUnit.IsLocal && visualInfo.progressBar != 0)
		{
			VisualProgressBarStruct progressBarInfo = ViSealedDB<VisualProgressBarStruct>.GetData(visualInfo.progressBar);
			if (progressBarInfo != null)
			{
				//PlayerController.Instance.AddProgress((UInt32)progressBarInfo.ID, ViTimerInstance.Time, property.EndTime);
			}
		}
		//
		if (caster != null)
		{
			LinkStart(caster);
		}
		//
	}

	void LinkStart(GameUnit caster)
	{
		_linkExpressList.End();
		//
		GameUnit self = (GameUnit)Entity;
		//
		for (int idx = 0; idx < _visualInfo.linkExpress.Length; ++idx)
		{
			ViLinkExpressStruct linkExpressInfo = _visualInfo.linkExpress[idx];
			if (!linkExpressInfo.IsEmpty())
			{
				LinkExpress iterLinkExpress = new LinkExpress();
				iterLinkExpress.Start(caster.GetPosProvider(linkExpressInfo.fromPos), self.GetPosProvider(linkExpressInfo.toPos), linkExpressInfo.res.Data, 0.0f);
				_linkExpressList.Add(iterLinkExpress);
			}
		}
		//
		if (self.ID != Property.Caster.Value.Data.Value)
		{
			//switch ((ViAuraLookAtType)_visualInfo.lookAtCaster.Value)
			//{
			//    case ViAuraLookAtType.YAW:
			//        self.StartAimProvider(caster.PosProvider);
			//        break;
			//    case ViAuraLookAtType.ATTACH:
			//        self.RootVisual.AddParent(GameKeyWord.LinkAttach, 10, caster.GetTransform(_visualInfo.linkExpress[0].fromPos));
			//        self.SetTickState(GameKeyWord.LinkAttach, 10, false);
			//        break;
			//    default:
			//        break;
			//}
		}
	}

	void LinkEnd()
	{
		_linkExpressList.End();
		//
		GameUnit self = (GameUnit)Entity;
		if (self.ID != Property.Caster.Value.Data.Value)
		{
			//switch ((ViAuraLookAtType)_visualInfo.lookAtCaster.Value)
			//{
			//    case ViAuraLookAtType.YAW:
			//        self.EndAimProvider();
			//        break;
			//    case ViAuraLookAtType.ATTACH:
			//        self.RootVisual.DelParent(GameKeyWord.LinkAttach);
			//        self.ClearTickState(GameKeyWord.LinkAttach);
			//        break;
			//    default:
			//        break;
			//}
		}
	}

	ViEntityManager.EventNode _casterEntityEventNode = new ViEntityManager.EventNode();
	void OnCasterEntityEvent(ViEntityManager.Event eventID, ViEntity entity)
	{
		switch (eventID)
		{
			case ViEntityManager.Event.CREATE:
				LinkStart((GameUnit)entity);
				break;
			case ViEntityManager.Event.BODY_UPDATE:
				LinkStart((GameUnit)entity);
				break;
			case ViEntityManager.Event.DESTROY:
				LinkEnd();
				break;
			default:
				break;
		}
	}
	//
	ViAuraStruct _logicInfo;
	ViVisualAuraStruct _visualInfo;
	DurationExpress _express = new DurationExpress();
	ViExpressOwnList<ViExpressInterface> _linkExpressList = new ViExpressOwnList<ViExpressInterface>();
    LocalSummonEntity _summonEntity;

    ViExpressOwnList<ViExpressInterface> _expressList = new ViExpressOwnList<ViExpressInterface>();
    List<ViTimeNodeEx3<Avatar,ViAttachExpressStruct, ViAnimStruct>> _timeNode1List = new List<ViTimeNodeEx3<Avatar,ViAttachExpressStruct, ViAnimStruct>>(5)
    {
        new ViTimeNodeEx3<Avatar,ViAttachExpressStruct, ViAnimStruct>(),
        new ViTimeNodeEx3<Avatar,ViAttachExpressStruct, ViAnimStruct>(),
        new ViTimeNodeEx3<Avatar,ViAttachExpressStruct, ViAnimStruct>(),
        new ViTimeNodeEx3<Avatar,ViAttachExpressStruct, ViAnimStruct>(),
        new ViTimeNodeEx3<Avatar,ViAttachExpressStruct, ViAnimStruct>()
    };
}