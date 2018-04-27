using System;
using System.Collections.Generic;
using UnityEngine;

public class AOIEffect : MonoBehaviour
{
	public ViProvider<ViVector3> Pos { get { return _pos; } }
	public Vector3 Offset
	{
		get
		{
			return _offset;
		}
	}

	public void SetPos(ViProvider<ViVector3> pos)
	{
		_pos = pos;
		_UpdatePos();
	}

	public void UpdateDir(Quaternion dir)
	{
		gameObject.transform.localRotation = dir;
	}

	public void UpdateOffset(Vector3 offset)
	{
		_offset = offset;
	}

	public void Initialization(ViAreaStruct area, string level)
	{
		_UpdateShape(area, level);
        GetComponentsInChildren<Renderer>(true, _renders);
    }

	public void Initialization(ViAreaStruct area, string level, float duration)
	{
		_UpdateShape(area, level);
		UnityComponentList<FXCurveAnimation_Base>.Begin(gameObject);
		for (int iter = 0; iter < UnityComponentList<FXCurveAnimation_Base>.List.Count; ++iter)
		{
			FXCurveAnimation_Base iterCurve = UnityComponentList<FXCurveAnimation_Base>.List[iter];
			iterCurve.DurationTime = duration * 0.01f;
		}
		UnityComponentList<FXCurveAnimation_Base>.End();
	}

	void _UpdateShape(ViAreaStruct area, string level)
	{
		level = "Blue";
		_info = area;
		float width = 1.0f;
		float height = 1.0f;
		ViAreaType type = (ViAreaType)area.type.Value;
		switch (type)
		{
			case ViAreaType.RECT:
				{
					width = area.minRange * 0.01f;
					height = area.maxRange * 0.01f;
					gameObject.transform.localScale = Vector3.Scale(gameObject.transform.localScale, new Vector3(width, 1.0f, height));
					_UpdateCircleInfo(gameObject, level);
					break;
				}
			case ViAreaType.ROUND:
				{
					float scale = area.maxRange * 0.02f;
					gameObject.transform.localScale *= scale;
					_UpdateCircleInfo(gameObject, level + "_circle");
					break;
				}
			case ViAreaType.SECTOR:
				{
					float scale = area.maxRange * 0.01f;
					gameObject.transform.localScale *= scale;
					_UpdateSectorInfo(gameObject, level + "_sector", 60.0f * area.minRange * 0.01f / ViMathDefine.PI);
					break;
		}
		}
	}

	void _UpdateCircleInfo(GameObject obj, string level)
	{
		if (obj == null)
		{
			return;
		}
		//
		if (obj.name.Equals(level, StringComparison.CurrentCultureIgnoreCase))
		{
			obj.SetActive(true);
		}
		else
		{
			for (int iter = 0; iter < obj.transform.childCount; ++iter)
			{
				Transform iterTran = obj.transform.GetChild(iter);
				_UpdateCircleInfo(iterTran.gameObject, level);
			}
		}
	}
    public void UpdateColor(Color color)
    {
        for (int iter = 0; iter < _renders.Count; ++iter)
        {
            Renderer iterRender = _renders[iter];
            if (iterRender != null && iterRender.material != null)
            {
                iterRender.material.SetColor(GetMaterialColorName(iterRender.material), color);
            }
        }
    }

    public string GetMaterialColorName(Material mat)
    {
        if (mat == null)
        {
            return string.Empty;
        }
        //
        for (int iter = 0; iter < propertyNames.Length; ++iter)
        {
            string iterName = propertyNames[iter];
            if (mat.HasProperty(iterName))
            {
                return iterName;
            }
        }
        //
        return string.Empty;
    }



    void _UpdateSectorInfo(GameObject obj, string level, float angle)
	{
		if (obj == null)
		{
			return;
		}
		//
		if (obj.name.StartsWith(level, StringComparison.CurrentCultureIgnoreCase))
		{
			obj.SetActive(true);
			UnityComponentList<FXCurveAnimation_Rotation>.Begin(obj);
			for (int iter = 0; iter < UnityComponentList<FXCurveAnimation_Rotation>.List.Count; ++iter)
			{
				FXCurveAnimation_Rotation iterCurve = UnityComponentList<FXCurveAnimation_Rotation>.List[iter];
				iterCurve.ValueScale = iterCurve.ValueScale * (angle - 45);
			}
			UnityComponentList<FXCurveAnimation_Rotation>.End();
		}
		else
		{
			for (int iter = 0; iter < obj.transform.childCount; ++iter)
			{
				Transform iterTran = obj.transform.GetChild(iter);
				_UpdateSectorInfo(iterTran.gameObject, level, angle);
			}
		}
	}

	void Update()
	{
		_UpdatePos();
	}

	void _UpdatePos()
	{
		if (_pos != null)
		{
			gameObject.transform.position = _pos.Value.Convert() + _heightOffset + _offset;
		}
	}

	Vector3 _heightOffset = new Vector3(0.0f, 0.2f, 0.0f);
    string[] propertyNames = { "_Color", "_TintColor", "_EmisColor" };
    List<Renderer> _renders = new List<Renderer>();
    ViAreaStruct _info;
	ViProvider<ViVector3> _pos;
	Vector3 _offset = Vector3.zero;
}
