using System;
using System.Collections.Generic;
using UnityEngine;

public class MusicElapseNode
{
	public static void End(ViDoubleLink2<MusicElapseNode> list)
	{
		while (list.IsNotEmpty())
		{
			MusicElapseNode iterNode = list.GetHead().Data;
			iterNode.End();
		}
	}

	public static void Update(ViDoubleLink2<MusicElapseNode> list, float deltaTime)
	{
		ViDoubleLinkNode2<MusicElapseNode> iter = list.GetHead();
		while (!list.IsEnd(iter))
		{
			MusicElapseNode iterNode = iter.Data;
			ViDoubleLink2<MusicElapseNode>.Next(ref iter);
			//
			iterNode._reserveDuration -= deltaTime;
			if (iterNode._reserveDuration > 0)
			{
				iterNode.Update();
			}
			else
			{
				iterNode.End();
			}
		}
	}

	public void Start(ViDoubleLink2<MusicElapseNode> list, GameObject obj, float duration, float volume)
	{
		_node.Data = this;
		list.PushBack(_node);
		//
		_obj = obj;
		obj.GetComponentsInChildren<AudioSource>(true, _sourceList);
		//
		_volume = volume;
		_duration = duration;
		_reserveDuration = duration;
	}

	public void End()
	{
		_node.Data = null;
		_node.Detach();
		//
		_sourceList.Clear();
		UnityAssisstant.Destroy(ref _obj);
	}

	void Update()
	{
		float volume = _reserveDuration / _duration * _volume;
		for (int iter = 0; iter < _sourceList.Count; ++iter)
		{
			_sourceList[iter].volume = volume;
		}
	}

	float _volume;
	float _duration;
	float _reserveDuration;
	GameObject _obj;
	List<AudioSource> _sourceList = new List<AudioSource>();
	ViDoubleLinkNode2<MusicElapseNode> _node = new ViDoubleLinkNode2<MusicElapseNode>();
}

public class MusicManager
{
	public static ViConstValue<float> VALUE_MusicElapseDuration = new ViConstValue<float>("MusicElapseDuration", 1.0f);
	public static ViConstValue<float> VALUE_MusicEnterDuration = new ViConstValue<float>("MusicEnterDuration", 1.0f);

	public MusicManager()
	{

	}

	public void Start()
	{
		_musicValue.DefaultValue = ViSealedDB<MusicStruct>.Data(0);
		_musicValue.UpdatedExec = this.OnMusicUpdated;
	}

	public void ClearElapseList()
	{
		MusicElapseNode.End(_elapseList);
	}

	public void End()
	{
        mResLoader.End();
        _musicValue.Clear();
		UnityAssisstant.Destroy(ref _obj);
		MusicElapseNode.End(_elapseList);
	}

	public void Update(float deltaTime)
	{
		MusicElapseNode.Update(_elapseList, deltaTime);
		//
		if (_obj != null)
		{
			if (_volumeProgress < 1.0f)
			{
				_volumeProgress += deltaTime / VALUE_MusicElapseDuration;
				_volumeProgress = ViMathDefine.Min(_volumeProgress, 1.0f);
				//
				UnityAssisstant.UpdateSoundVolume(_obj, _volume * _volumeProgress * _musicValue.Value.GetVolume());
			}
		}
	}

	public void SetVolume(float value)
	{
		_volume = value;
		if (_obj != null)
		{
			UnityAssisstant.UpdateSoundVolume(_obj, _volume * _musicValue.Value.GetVolume());
		}
	}

	public void Add(string name, Int32 weight, MusicStruct info)
	{
		_musicValue.Add(name, weight, info);
	}

	public void Del(string name)
	{
		_musicValue.Del(name);
	}

	void OnMusicUpdated(MusicStruct oldValue, MusicStruct newValue)
	{
		if (_obj != null)
		{
			MusicElapseNode newNode = new MusicElapseNode();
			newNode.Start(_elapseList, _obj, VALUE_MusicElapseDuration, _volume * _volumeProgress * oldValue.GetVolume());
			_obj = null;
		}
		if (_musicValue.Value.Res.NotEmpty())
		{
            mResLoader.Start(_musicValue.Value.Res.Data, _OnResLoaded);
		}
	}

	void _OnResLoaded(UnityEngine.Object pAsset)
	{
		_volumeProgress = 0.0f;
		_obj = UnityAssisstant.Instantiate(pAsset as GameObject);
		UnityAssisstant.UpdateSoundVolume(_obj, _volume * _volumeProgress * _musicValue.Value.GetVolume());
		UnityAssisstant.SetSoundLoop(_obj, true);
	}

	float _volume = 1.0f;
	float _volumeProgress;
	ViPriorityValue<MusicStruct> _musicValue = new ViPriorityValue<MusicStruct>();
	GameObject _obj;
	ViDoubleLink2<MusicElapseNode> _elapseList = new ViDoubleLink2<MusicElapseNode>();
    ResourceRequest mResLoader = new ResourceRequest();
}


public class AudioListenerManager
{
	public ViPriorityValue<ViProvider<ViVector3>> PosValue { get { return _posValue; } }
	public ViPriorityValue<Transform> RotValue { get { return _rotValue; } }

	public void Start(Transform tran)
	{
		_listener = tran;
	}

	public void End()
	{
		_listener = null;
		_posValue.Clear();
		_rotValue.Clear();
	}

	public void Update()
	{
		if (_listener != null)
		{
			if (_posValue.Value != null)
			{
				_listener.position = _posValue.Value.Value.Convert();
			}
			else
			{
				_listener.position = Vector3.zero;
			}
			//
			if (_rotValue.Value != null)
			{
				_listener.rotation = _rotValue.Value.rotation;
			}
			else
			{
				_listener.rotation = Quaternion.identity;
			}
		}
	}

	Transform _listener;
	ViPriorityValue<ViProvider<ViVector3>> _posValue = new ViPriorityValue<ViProvider<ViVector3>>();
	ViPriorityValue<Transform> _rotValue = new ViPriorityValue<Transform>();
}