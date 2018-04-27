using System;
using UnityEngine;

public class AimHint
{
	public RenderLine Line { get { return _line; } }
	public void Start(PathFileResStruct res)
	{
        mResLoader.Start(res, _OnResLoaded);
	}

	public void End()
	{
        mResLoader.End();
        _line = null;
		UnityAssisstant.Destroy(ref _obj);
	}

	public void Update(ViVector3 fromPos, ViVector3 toPos)
	{
		if (_obj != null)
		{
			_obj.transform.localPosition = fromPos.Convert();
			if (_line != null)
			{
				_line.To.transform.localPosition = (toPos - fromPos).Convert();
			}
		}
	}

	void _OnResLoaded(UnityEngine.Object pAsset)
	{
		_obj = UnityAssisstant.Instantiate(pAsset as GameObject);
		_line = UnityAssisstant.GetComponentRecursively<RenderLine>(_obj);
	}

	RenderLine _line;
	GameObject _obj;
    ResourceRequest mResLoader = new ResourceRequest();
}