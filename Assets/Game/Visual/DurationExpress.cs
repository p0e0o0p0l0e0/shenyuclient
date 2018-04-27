using System;

using ViEntityID = System.UInt64;

public class DurationExpress
{
	public ViVisualAuraStruct Info { get { return _info; } }
	public void Start(ViEntity entity, Avatar avatar, ViVisualAuraStruct info, string visualLevel)
	{
		if (avatar.Visual == null)
		{
			return;
		}
		//
		foreach (ViAttachExpressStruct expressInfo in info.express.Array)
		{
			if (!expressInfo.IsEmpty())
			{
				if (expressInfo.notBroadcast == (Int32)BoolValue.FALSE || entity.IsLocal)
				{
					AttachedSpaceExpress express = new AttachedSpaceExpress();
					express.CameraAnim = entity.IsLocal;
					express.AttachMask = (UInt32)expressInfo.attachMask;
					ViVector3 offset = new ViVector3(0, 0, info.height * 0.01f);
					express.Start(expressInfo.res.Data, 0.0f, avatar.Property.GetAttachPos(expressInfo.attachPos), offset);
					_expressList.Add(express);
				}
			}
		}
		//
		foreach (ViForeignKeyStruct<ViAvatarDurationVisualStruct> durationVisual in info.durationVisual.Array)
		{
			ViAvatarDurationVisualStruct durationVisualInfo = durationVisual.PData;
			if (durationVisualInfo != null)
			{
				_durationVisualList.Add(entity, avatar, durationVisualInfo, info.priority);
			}
		}
		//
		if (info.animLoop.res != string.Empty)
		{
			DurationVisual_StateAnimation visualAnimation = new DurationVisual_StateAnimation();
			visualAnimation.animationName = info.animLoop.res;
			_durationVisualList.Add(entity, avatar, visualAnimation, ViSealedDB<ViAvatarDurationVisualStruct>.Data(0), info.priority);
		}
		//
		for (int iter = 0; iter < info.sound.Length; ++iter)
		{
			ViSoundStruct iterInfo = info.sound[iter];
			if (!iterInfo.IsEmpty())
			{
				AttachedSpaceExpress express = new AttachedSpaceExpress();
				express.Start(iterInfo.Resource.Data, iterInfo.delayTime * 0.01f, avatar.VisualTran.root, ViVector3.ZERO);
				express.SoundDuration = true;
				_expressList.Add(express);
			}
		}
		//
		_avatar = avatar;
		_info = info;
	}

	public void End(bool destroying)
	{
		if (_avatar != null)
		{
			_durationVisualList.Clear(_avatar, destroying);
			_expressList.End();
			_avatar = null;
		}
		_info = null;
	}

	ViExpressOwnList<ViExpressInterface> _expressList = new ViExpressOwnList<ViExpressInterface>();

	ViVisualAuraStruct _info;
	Avatar _avatar;
	ViAvatarDurationVisualOwnList<Avatar> _durationVisualList = new ViAvatarDurationVisualOwnList<Avatar>();
}

public class DurationExpressEx : DurationExpress
{
	public void SetDuartion(float duration)
	{
		ViTimerInstance.SetTime(_endTimeNode, duration, this.OnEndTime);
	}
	void OnEndTime(ViTimeNodeInterface node)
	{
		End(false);
	}
	ViTimeNode1 _endTimeNode = new ViTimeNode1();
}