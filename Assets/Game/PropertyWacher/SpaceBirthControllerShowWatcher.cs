
using System;
using System.Collections.Generic;
using UnityEngine;

public class SpaceBirthControllerShowWatcher : ViReceiveDataDictionaryNodeWatcher<UInt32, ReceiveDataSpaceBirthControllerShowProperty>
{
	public SpaceBirthControllerShowStruct Info { get { return _info; } }

	public override void OnStart(UInt32 ID, ReceiveDataSpaceBirthControllerShowProperty property, ViEntity entity)
	{
		_info = ViSealedDB<SpaceBirthControllerShowStruct>.Data(property.Show);
		//
		_gameObject = new GameObject(Info.Name);
		ViVector3 pos = property.Position;
		_gameObject.transform.localPosition = pos.Convert();
		//
		if (_info.Res.NotEmpty())
		{
			AttachedSpaceExpress iterExpress = new AttachedSpaceExpress();
			iterExpress.CameraAnim = true;
			iterExpress.Start(Info.Res.Data, _gameObject.transform);
			_expressList.Add(iterExpress);
		}
		//
		if (Info.EnterCameraShake.NotEmpty())
		{
			ViCameraShakeStruct cameraShake = Info.EnterCameraShake.PData;
			if (cameraShake != null)
			{
				ShakeExpressEx shakeExpress = new ShakeExpressEx();
				shakeExpress.SetProvider(new ViSimpleProvider<ViVector3>(pos));
				shakeExpress.Start(0.0f, cameraShake);
			}
		}
	}

	public override void OnUpdate(UInt32 ID, ReceiveDataSpaceBirthControllerShowProperty property, ViEntity entity)
	{
		
	}

	public override void OnEnd(UInt32 ID, ReceiveDataSpaceBirthControllerShowProperty property, ViEntity entity)
	{
		_expressList.End();
		//
		if (_gameObject != null)
		{
			UnityAssisstant.Destroy(ref _gameObject);
		}
		//
		if (Info.ExitCameraShake.NotEmpty())
		{
			ViCameraShakeStruct cameraShake = Info.ExitCameraShake.PData;
			if (cameraShake != null)
			{
				ViVector3 pos = property.Position;
				ShakeExpressEx shakeExpress = new ShakeExpressEx();
				shakeExpress.SetProvider(new ViSimpleProvider<ViVector3>(pos));
				shakeExpress.Start(0.0f, cameraShake);
			}
		}
	}

	GameObject _gameObject;
	SpaceBirthControllerShowStruct _info;
	ViExpressOwnList<ViExpressInterface> _expressList = new ViExpressOwnList<ViExpressInterface>();
}
