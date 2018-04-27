using System;
using System.Collections.Generic;
using UnityEngine;

public class SoundGroupController
{
	public SoundGroupController()
	{
		
	}

	public void Start()
	{
		//_soundStruct.UpdatedExec = this.OnSoundUpdated;
	}

	public void Add(ViSoundStruct info)
	{
		//_soundStruct.Add(GameKeyWord.Default, 0, info);
	}

	public void Del(string name)
	{
		//_soundStruct.Del(name);
	}

	public void End()
	{
		//_soundStruct.Clear();
		//_gameObjectRes.End();
		//UnityAssisstant.Destroy(ref _obj);
	}

	public void SetVolume(float value)
	{
		//_volume = value;
	}

	//void OnSoundUpdated(ViSoundStruct oldValue, ViSoundStruct newValue)
	//{
	//    if (_obj != null)
	//    {
	//        GameObject.Destroy(_obj);
	//        _obj = null;
	//    }
	//    //
	//    _gameObjectRes.End();
	//    ViSoundResStruct sound = _soundStruct.Value.Resource.Data;
	//    if (sound != null && !sound.Default.IsEmpty())
	//    {
	//        _gameObjectRes.Start(sound.Default.Path, sound.Default.File, this._OnResLoaded);
	//    }
	//}

	//void _OnResLoaded(ResourceRequestInterface loader)
	//{
	//    _obj = UnityAssisstant.Instantiate(_gameObjectRes.TObject);
	//    UnityAssisstant.UpdateSoundVolume(_obj, _volume);
	//    UnityAssisstant.SetSoundLoop(_obj, false);
	//}

	//float _volume = 1.0f;
	//ResourceRequest<GameObject> _gameObjectRes = new ResourceRequest<GameObject>();
	//GameObject _obj;
	//ViPriorityValue<ViSoundStruct> _soundStruct = new ViPriorityValue<ViSoundStruct>();
}
