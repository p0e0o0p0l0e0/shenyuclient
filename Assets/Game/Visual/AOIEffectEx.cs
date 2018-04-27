using UnityEngine;
using System.Collections;

public class AOIEffectEx
{
	public AOIEffect AOIEffect
	{
		get
		{
			return _aoiEffect;
		}
	}

	public ViSpellStruct LogicInfo { get { return _spellStruct; } }
	public VisualSpellStruct VisualInfo { get { return _visualSpell; } }
	public Vector3 Offset;

	public void Init(ViProvider<ViVector3> rootPos, float yaw, ViSpellStruct logicInfo, VisualSpellStruct visualSpell, string faction)
	{
		_spellStruct = logicInfo;
		_visualSpell = visualSpell;
		if (visualSpell.Selector.Position.Value != (int)SpellPositionSelectType.SELF)
		{
			GameObject spellRangeObj = UnityAssisstant.Instantiate(GlobalGameObject.Instance.SpellRangeEffect.GameObject);
			_spellRangeEffect = UnityAssisstant.CreateComponent<SpellRangeEffect>(spellRangeObj);
			_spellRangeEffect.SetPos(rootPos);
			_spellRangeEffect.UpdateRadius(_spellStruct.proc.Range.Sup * 0.01f * 2.0f);
			GameObject aoiEffectObj = UnityAssisstant.Instantiate(GlobalGameObject.Instance.AOIEffect.GameObject);
			_aoiEffect = UnityAssisstant.CreateComponent<AOIEffect>(aoiEffectObj);
			_aoiEffect.Initialization(visualSpell.Selector.casterEffectRange, faction);
			ViVector3 direction = ViVector3.ZERO;
			ViGeographicObject.GetRotate(yaw, ref direction.x, ref direction.y);
			_UpdateDir(direction.Convert());
			_UpdateOffset((SpellPositionSelectType)visualSpell.Selector.Position.Value, direction.Convert(), Vector3.zero);
			_aoiEffect.SetPos(rootPos);
            _UpdateSpellRangeEffectColor(new Color(0.07f, 0.33f, 0.67f,0.80f));

        }
	}

	void UpdateOffset(Vector3 offset)
	{
		if (_aoiEffect != null)
		{
			_aoiEffect.UpdateOffset(offset);
		}
	}

	public void UpdateTagertPos(Vector3 tagertPos)
	{
		if (_aoiEffect != null)
		{
			Offset = tagertPos - _aoiEffect.Pos.Value.Convert();
			if (_visualSpell != null)
			{
				SpellPositionSelectType type = (SpellPositionSelectType)_visualSpell.Selector.Position.Value;
				_UpdateOffset(type, Offset.normalized, Offset);
			}
		}
	}

	void _UpdateOffset(SpellPositionSelectType type, Vector3 dir, Vector3 offset)
	{
		if (_visualSpell == null)
		{
			return;
		}
		//
		if (type == SpellPositionSelectType.YAW)
        {
            _UpdateDir(dir);

            offset = Vector3.zero;
			if (_visualSpell.Selector.casterEffectRange.type == (int)ViAreaType.RECT)
			{
				offset = _visualSpell.Selector.casterEffectRange.maxRange * 0.01f * 0.5f * dir;
			}
		}
		if (type == SpellPositionSelectType.POS)
		{
			float distanceSup = _spellStruct.proc.Range.Sup * 0.01f;
			if (distanceSup < offset.magnitude)
			{
				offset =  dir * distanceSup;
			}
		}
		//
		UpdateOffset(offset);
	}

	public void _UpdateSpellRangeEffectColor(Color color)
	{
		if (_spellRangeEffect != null)
		{
			_spellRangeEffect.UpdateColor(color);
		}
        if(_aoiEffect != null)
        {
            _aoiEffect.UpdateColor(color);
        }
	}

	void _UpdateDir(Vector3 dir)
	{
		if (_aoiEffect != null)
		{
			ViAngle angle = new ViAngle(ViGeographicObject.GetDirection(dir.x, dir.z));
			Quaternion ration = Quaternion.AngleAxis(ViMathDefine.Radius2Degree(angle.Value), Vector3.up);
			_aoiEffect.UpdateDir(ration);
		}

	}

	public void End()
	{
		if (_aoiEffect != null)
		{
			GameObject aoiEffectObj = _aoiEffect.gameObject;
			UnityAssisstant.Destroy(ref aoiEffectObj);
		}
		if (_spellRangeEffect != null)
		{
			GameObject spellRangeEffect = _spellRangeEffect.gameObject;
			UnityAssisstant.Destroy(ref spellRangeEffect);
		}
	}

	AOIEffect _aoiEffect;
	SpellRangeEffect _spellRangeEffect;
	VisualSpellStruct _visualSpell;
	ViSpellStruct _spellStruct;
}
