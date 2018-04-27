using System;
using System.Collections.Generic;

public class SpellVisualProccess
{
	public bool IsLoop { get { return _loop; } }
	public GameUnit Entity { get { return _entity; } }
	public ViExpressOwnList<ViExpressInterface> ExpressList { get { return _ownExpressList; } }

	public void Start(GameUnit entity)
	{
		_entity = entity;
	}
	public void End()
	{
		_ownExpressList.End();
		_expressList.Clear();
		_durationEffect.End(true);
		_sendTimeNode.Detach();
		_entity = null;
	}

	public struct Express
	{
		public ViProvider<ViVector3> Pos;
		public UnityEngine.Transform EndAttachedTarget;
		public ViTravelExpressStruct Info;
		public string SwitchLayer;
	}

	public void OnceExec(GameUnit gameUnit, VisualSpellProcStruct info)
	{
		EndExec(gameUnit, true);
		//
		_info = info;
		if (!info.Anim[0].IsEmpty())
		{
			gameUnit.VisualBody.PlayActionAnim(info.Anim[0].res, true);
		}
		//
		if (info.attackTipsDuration > 0)
		{
			GameObjectCloneExpressEx express = new GameObjectCloneExpressEx();
			ViSimpleProvider<ViVector3> posProvider = new ViSimpleProvider<ViVector3>(gameUnit.VisualBody.RootTran.position.Convert());
			express.SwitchLayer = EntityAssisstant.GetFactionColor(gameUnit, null);
			express.Start(GlobalGameObject.Instance.AOIEffect.GameObject, posProvider, gameUnit.Yaw, info.attackTipsDelayTime, info.attackTipsDuration, new ViVector3(0.0f, 0.0f, 0.01f), info.casterEffectRange);
			_ownExpressList.Add(express);
		}
		//
		for (int iter = 0; iter < info.Express.Length; ++iter)
		{
			ViAttachExpressStruct iterInfo = info.Express[iter];
			if (iterInfo.IsEmpty())
			{
				continue;
			}
			gameUnit.OnEffectVisual(gameUnit, iterInfo, ViVector3.ZERO, null, _ownExpressList);
		}
		//
		for (int iter = 0; iter < info.Shake.Length; ++iter)
		{
			VisualSpellProcStruct.CameraShake iterShake = info.Shake[iter];
			if (iterShake.Broadcast == (UInt32)BoolValue.FALSE && !gameUnit.IsLocal)
			{
				continue;
			}
			ViCameraShakeStruct iterInfo = iterShake.Shake.PData;
			if (iterInfo != null)
			{
				ShakeExpressEx express = new ShakeExpressEx();
				express.SetProvider(gameUnit.PosProvider);
				express.Start(iterShake.DelayTime * 0.01f, iterInfo);
				_ownExpressList.Add(express);
			}
		}
		//
		for (int iter = 0; iter < info.sound.Length; ++iter)
		{
			ViSoundStruct iterInfo = info.sound[iter];
			if (!iterInfo.IsEmpty())
			{
				AttachedSpaceExpress express = new AttachedSpaceExpress();
				express.Start(iterInfo.Resource.Data, iterInfo.delayTime * 0.01f, gameUnit.VisualBody.RootTran, ViVector3.ZERO);
				express.SoundDuration = true;
				_ownExpressList.Add(express);
			}
		}
		//
		for (int iter = 0; iter < info.BodyPartState.Length; ++iter)
		{
			VisualSpellProcStruct.BodyPartActive bodyPart = info.BodyPartState[iter];
			if (bodyPart.BodyPartName != string.Empty)
			{
				Int32 delayTime = bodyPart.DelayTime;
				string childName = bodyPart.BodyPartName;
				bool active = bodyPart.Active.Value == (UInt32)BoolValue.TRUE ? true : false;
				UnityEngine.Transform childTran = UnityAssisstant.GetChildRecursively(gameUnit.VisualBody.RootTran, childName);
				if (childTran != null)
				{
					BodyPartActiveExpressEx express = new BodyPartActiveExpressEx();
					express.Start(childTran, delayTime, active, bodyPart.DurationTime);
					_ownExpressList.Add(express);
				}
			}
		}
		//
		ViVisualAuraStruct auraVisual = info.DurationEffect.PData;
		if (auraVisual != null)
		{
			_durationEffect.Start(gameUnit, gameUnit.VisualBody, auraVisual, EntityAssisstant.GetFactionColor(gameUnit, null));
			_durationEffect.SetDuartion(info.DurationEffectDuration * 0.01f);
		}
		//
		if (!string.IsNullOrEmpty(info.FaceTo) && gameUnit.VisualBody.Face != null)
		{
			gameUnit.VisualBody.Face.Play(info.FaceTo, info.FaceDuration*0.01f);
		}
	}

	public void EndExec(GameUnit gameUnit, bool breakVisual)
	{
		if (_info == null)
		{
			return;
		}
		if (breakVisual)
		{
			if (gameUnit.VisualBody.Face != null)
			{
				gameUnit.VisualBody.Face.Stop();
			}
            if (_info.Anim[0].res != null)
            {
                gameUnit.VisualBody.StopActionAnim(_info.Anim[0].res);
            }
			_ownExpressList.End();
			_sendTimeNode.Detach();
			_expressList.Clear();
			_durationEffect.End(false);
		}
		//
		_info = null;
	}

	public void StopLoopAnim(GameUnit gameUnit)
	{
		if (_info == null)
		{
			return;
		}
		if (gameUnit.VisualBody.IsLoopAnim(_info.Anim[0].res))
		{
			gameUnit.VisualBody.StopActionAnim(_info.Anim[0].res);
		}
	}

	public void DetachExpressToWorld()
	{
		ViRefList2<ViExpressInterface> list = _ownExpressList.List;
		list.BeginIterator();
		while (!list.IsEnd())
		{
			ViRefNode2<ViExpressInterface> iterNode = list.CurrentNode;
			list.Next();
			//
			AttachedSpaceExpress iterExpress = iterNode.Data as AttachedSpaceExpress;
			if (iterExpress != null)
			{
				iterExpress.DetachToWorld();
			}
		}
	}

	public void SetSendTime(float delayTime, float duration)
	{
		ViTimerInstance.SetTime(_sendTimeNode, delayTime, this._OnSend);
		_travelDuration = duration;
	}
	public void AddTravel(ViProvider<ViVector3> pos, ViTravelExpressStruct info, string switchLayer)
	{
		Express express = new Express();
		express.Pos = pos;
		express.Info = info;
		express.SwitchLayer = switchLayer;
		_expressList.Add(express);
	}
	public void AddTravel(ViProvider<ViVector3> pos, ViTravelExpressStruct info, string switchLayer, UnityEngine.Transform endAttachedTarget)
	{
		Express express = new Express();
		express.Pos = pos;
		express.Info = info;
		express.SwitchLayer = switchLayer;
		express.EndAttachedTarget = endAttachedTarget;
		_expressList.Add(express);
	}

	void _OnSend(ViTimeNodeInterface node)
	{
		foreach (Express express in _expressList)
		{
			Entity.MakeExpress(express.Pos, express.Info, _travelDuration, express.SwitchLayer, express.EndAttachedTarget);
		}
		_expressList.Clear();
	}
	ViTimeNode1 _sendTimeNode = new ViTimeNode1();
	List<Express> _expressList = new List<Express>();
	DurationExpressEx _durationEffect = new DurationExpressEx();
	ViExpressOwnList<ViExpressInterface> _ownExpressList = new ViExpressOwnList<ViExpressInterface>();

	GameUnit _entity;
	VisualSpellProcStruct _info;
	bool _loop = false;
	float _travelDuration;
}