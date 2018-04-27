using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class SpellAssisstant
{
	public static string GetSpellDescription(HeroSpellProperty spellProperty)
	{
		return spellProperty.Info.Data.Description;
	}

	//public static string GetSpellDescriptionEx(HeroSpellProperty spellProperty)
	//{
	//    OwnSpellStruct ownSpell = spellProperty.Info;
	//    string description = ownSpell.DescriptionEx;
	//    if (string.IsNullOrEmpty(description))
	//    {
	//        return string.Empty;
	//    }
	//    //AttributeModifyStruct atrModStruct = ownSpell.AttributeModifyStart.GetData(spellProperty.Level);
	//    //
	//    StringBuilder sb = new StringBuilder();
	//    List<string> splitStr = new List<string>(1);
	//    splitStr.Add(_hitEffectFlag);
	//    string[] splitArray = description.Split(splitStr.ToArray(), StringSplitOptions.RemoveEmptyEntries);
	//    sb.Append(splitArray[0]);
	//    for (Int32 iter = 1; iter < splitArray.Length; ++iter)
	//    {
	//        string subDescription = splitArray[iter];
	//        Int32 endIndex = subDescription.IndexOf(_endFlag, 0);
	//        string hitEffectIdxStr = subDescription.Substring(0, endIndex);
	//        Int32 hitEffectIdx = 0;
	//        if (!Int32.TryParse(hitEffectIdxStr, out hitEffectIdx))
	//        {
	//            ViDebuger.Warning("visualSpell" + spellProperty.Info + "技能描述有问题!");
	//            sb.Append(string.Empty);
	//            continue;
	//        }
	//        //
	//        ViHitEffectStruct hitEffect = ViSealedDB<ViHitEffectStruct>.Data(hitEffectIdx);
	//        Int32 levelValue = ViMathDefine.IntNear((hitEffect.LevelValueScale * 0.01f) * spellProperty.LevelValue);
	//        sb.Append(levelValue.ToString());
	//        sb.Append(subDescription.Remove(0, endIndex + 1));
	//    }
	//    description = sb.ToString();
	//    sb = new StringBuilder();
	//    splitStr.Clear();
	//    splitStr.Add(_auraFlag);
	//    splitArray = description.Split(splitStr.ToArray(), StringSplitOptions.RemoveEmptyEntries);
	//    sb.Append(splitArray[0]);
	//    for (Int32 iter = 1; iter < splitArray.Length; ++iter)
	//    {
	//        string subDescription = splitArray[iter];
	//        Int32 endIndex = subDescription.IndexOf(_endFlag, 0);
	//        string auratIdxStr = subDescription.Substring(0, endIndex);
	//        Int32 auraIdx = 0;
	//        if (!Int32.TryParse(auratIdxStr, out auraIdx))
	//        {
	//            ViDebuger.Warning("visualSpell" + spellProperty.Info + "技能描述有问题!");
	//            sb.Append(string.Empty);
	//            continue;
	//        }
	//        //
	//        ViAuraStruct auraInfo = ViSealedDB<ViAuraStruct>.Data(auraIdx);
	//        Int32 levelValue = ViMathDefine.IntNear((auraInfo.LevelValueScale * 0.01f) * spellProperty.LevelValue);
	//        sb.Append(levelValue.ToString());
	//        sb.Append(subDescription.Remove(0, endIndex + 1));
	//    }
	//    //
	//    description = sb.ToString();
	//    sb = new StringBuilder();
	//    splitStr.Clear();
	//    splitStr.Add(_hitComputeFlag);
	//    splitArray = description.Split(splitStr.ToArray(), StringSplitOptions.RemoveEmptyEntries);
	//    sb.Append(splitArray[0]);
	//    for (Int32 iter = 1; iter < splitArray.Length; ++iter)
	//    {
	//        string subDescription = splitArray[iter];
	//        Int32 endIndex = subDescription.IndexOf(_endFlag, 0);
	//        Int32 middleIndex = subDescription.IndexOf("$", 0);
	//        string coustomValueStr = subDescription.Substring(0, middleIndex);
	//        string auratIdxStr = subDescription.Substring(middleIndex + 1, endIndex - middleIndex - 1);
	//        Int32 hitId = 0;
	//        Int32 coustomValue = 0;
	//        if (!Int32.TryParse(auratIdxStr, out hitId))
	//        {
	//            ViDebuger.Warning("visualSpell" + spellProperty.Info + "技能描述有问题!");
	//            sb.Append(string.Empty);
	//            continue;
	//        }
	//        //
	//        if (!Int32.TryParse(coustomValueStr, out coustomValue))
	//        {
	//            ViDebuger.Warning("visualSpell" + spellProperty.Info + "技能描述有问题!");
	//            sb.Append(string.Empty);
	//            continue;
	//        }
	//        //
	//        ViHitEffectStruct auraInfo = ViSealedDB<ViHitEffectStruct>.Data(hitId);
	//        Int32 levelValue = ViMathDefine.IntNear((auraInfo.LevelValueScale * 0.01f) * spellProperty.LevelValue);
	//        if (!subDescription.Contains(_scale))
	//        {
	//            sb.Append((levelValue + coustomValue).ToString());
	//        }
	//        else
	//        {
	//            subDescription = subDescription.Replace(_scale, string.Empty);
	//            float value = levelValue * 1.0f / 100 + coustomValue * 1.0f / 100;
	//            sb.Append(value.ToString() + _percentageFlag);
	//        }
	//        //
	//        sb.Append(subDescription.Remove(0, endIndex + 1));
	//    }
	//    //
	//    description = sb.ToString();
	//    sb = new StringBuilder();
	//    splitStr.Clear();
	//    splitStr.Add(_auraComputeFlag);
	//    splitArray = description.Split(splitStr.ToArray(), StringSplitOptions.RemoveEmptyEntries);
	//    sb.Append(splitArray[0]);
	//    for (Int32 iter = 1; iter < splitArray.Length; ++iter)
	//    {
	//        string subDescription = splitArray[iter];
	//        Int32 endIndex = subDescription.IndexOf(_endFlag, 0);
	//        Int32 middleIndex = subDescription.IndexOf("$", 0);
	//        string coustomValueStr = subDescription.Substring(0, middleIndex);
	//        string auratIdxStr = subDescription.Substring(middleIndex + 1, endIndex - middleIndex - 1);
	//        Int32 auraIdx = 0;
	//        Int32 coustomValue = 0;
	//        if (!Int32.TryParse(auratIdxStr, out auraIdx))
	//        {
	//            ViDebuger.Warning("visualSpell" + spellProperty.Info + "技能描述有问题!");
	//            sb.Append(string.Empty);
	//            continue;
	//        }
	//        //
	//        if (!Int32.TryParse(coustomValueStr, out coustomValue))
	//        {
	//            ViDebuger.Warning("visualSpell" + spellProperty.Info + "技能描述有问题!");
	//            sb.Append(string.Empty);
	//            continue;
	//        }
	//        //
	//        ViAuraStruct auraInfo = ViSealedDB<ViAuraStruct>.Data(auraIdx);
	//        Int32 levelValue = ViMathDefine.IntNear((auraInfo.LevelValueScale * 0.01f) * spellProperty.LevelValue);
	//        if (!subDescription.Contains(_scale))
	//        {
	//            sb.Append((levelValue + coustomValue).ToString());
	//        }
	//        else
	//        {
	//            subDescription = subDescription.Replace(_scale, string.Empty);
	//            float value = levelValue * 1.0f / 100 + coustomValue * 1.0f / 100;
	//            sb.Append(value.ToString() + _percentageFlag);
	//        }
	//        //
	//        sb.Append(subDescription.Remove(0, endIndex + 1));
	//    }
	//    //
	//    if (atrModStruct == null)
	//    {
	//        return sb.ToString();
	//    }
	//    else
	//    {
	//        return _ReplaceAttribute(sb.ToString(), atrModStruct);
	//    }
	//}

	static string _ReplaceAttribute(string str, AttributeModifyStruct atrModStruct)
	{
        /*
		if (str.Contains(_moveSpeed))
		{
			str = str.Replace(_moveSpeed, atrModStruct.Value.MoveSpeed.ToString());
		}
		if (str.Contains(_hpMax))
		{
			str = str.Replace(_hpMax, atrModStruct.Value.HPMax.ToString());
		}
		if (str.Contains(_hpRecover))
		{
			str = str.Replace(_hpRecover, atrModStruct.Value.HPRecover.ToString());
		}
		if (str.Contains(_criticalPower))
		{
			float criticalPower = atrModStruct.Value.CriticalPower * 1.0f / 100;
			str = str.Replace(_criticalPower, criticalPower.ToString() + _percentageFlag);
		}
		if (str.Contains(_criticalOutScale))
		{
			str = str.Replace(_criticalOutScale, atrModStruct.Value.CriticalOutScale.ToString());
		}
		if (str.Contains(_damageOutRecoverHPRating))
		{
			str = str.Replace(_damageOutRecoverHPRating, atrModStruct.Value.DamageOutRecoverHPRating.ToString());
		}
		if (str.Contains(_damageOutRecoverHPScale))
		{
			str = str.Replace(_damageOutRecoverHPScale, atrModStruct.Value.DamageOutRecoverHPScale.ToString());
		}
		if (str.Contains(_damageOutRecoverHP))
		{
			str = str.Replace(_damageOutRecoverHP, atrModStruct.Value.DamageOutRecoverHP.ToString());
		}
		if (str.Contains(_damageInReflectionRating))
		{
			str = str.Replace(_damageInReflectionRating, atrModStruct.Value.DamageInReflectionRating.ToString());
		}
		if (str.Contains(_damageInReflectionScale))
		{
			str = str.Replace(_damageInReflectionScale, atrModStruct.Value.DamageInReflectionScale.ToString());
		}
		if (str.Contains(_damageInReflection))
		{
			str = str.Replace(_damageInReflection, atrModStruct.Value.DamageInReflection.ToString());
		}
		//
        */
        return str;
	}

	static readonly string _hitEffectFlag = "{Hit$";
	static readonly string _auraFlag = "{Aura$";
	static readonly string _hitComputeFlag = "{HitCompute";
	static readonly string _auraComputeFlag = "{AuraCompute";
	static readonly string _endFlag = "}";
	static readonly string _percentageFlag = "%";
	static readonly string _scale = "Scale100";
	//
	static readonly string _moveSpeed = "{MoveSpeed}";
	static readonly string _hpMax = "{HPMax}";
	static readonly string _hpRecover = "{HPRecover}";
	static readonly string _hitRating = "{HitRating}";
	static readonly string _dodgePower = "{DodgePower}";
	static readonly string _criticalPower = "{CriticalPower}";
	static readonly string _criticalOutScale = "{CriticalOutScale}";
	static readonly string _physicsDamageIn = "{PhysicsDamageIn}";
	static readonly string _magicDamageIn = "{MagicDamageIn}";
	static readonly string _damageOutRecoverHPRating = "{DamageOutRecoverHPRating}";
	static readonly string _damageOutRecoverHPScale = "{DamageOutRecoverHPScale}";
	static readonly string _damageOutRecoverHP = "{DamageOutRecoverHP}";
	static readonly string _damageInReflectionRating = "{DamageInReflectionRating}";
	static readonly string _damageInReflectionScale = "{DamageInReflectionScale}";
	static readonly string _damageInReflection = "{DamageInReflection}";
}
