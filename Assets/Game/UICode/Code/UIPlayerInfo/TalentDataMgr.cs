using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;
using UnityEngine;


public class TalentDataMgr : DataManagerBase<TalentDataMgr>, IRelease
{
    public void Release()
    {

    }
    public Dictionary<int, List<OwnSpellStruct>> spellDic = new Dictionary<int, List<OwnSpellStruct>>();

    public TalentDataMgr()
    {
        var allList = ViSealedDB<OwnSpellStruct>.Array;
        int heroClass = CellHero.LocalHero.LogicInfo.HeroClass.Value;
        heroClass = 1;  //asd  临时写死

        for (int i = 0; i < allList.Count; i++)
        {
            if (heroClass == allList[i].m_eClass)
            {
                if (spellDic.ContainsKey(allList[i].Floor))
                {
                    spellDic[allList[i].Floor].Add(allList[i]);
                }
                else
                {
                    List<OwnSpellStruct> list = new List<OwnSpellStruct>();
                    list.Add(allList[i]);
                    spellDic.Add(allList[i].Floor, list);
                }
            }
        }
    }

    public List<OwnSpellStruct> GetSpellByFloor(int floor)
    {
        if (spellDic.ContainsKey(floor))
            return spellDic[floor];
        Debug.LogError("spell not found  ui floor error"+floor);
        return new List<OwnSpellStruct>();
    }

    public OwnSpellStruct GetEquipSpellByIndex(int index)
    {
        var list = CellHero.LocalHero.Property.SpellList;
        for (int i = 0; i < list.Count; i++)
        {
            var pro = list[i];
            var spellProperty = pro.Property;
            if (spellProperty.SetupIdx == index)
                return list[i].Property.Info.Value;
        }
        return null;    
    }
    public ReceiveDataHeroSpellProperty GetSpellReceiveDataByIndex(int index)
    {
        var list = CellHero.LocalHero.Property.SpellList;
        for (int i = 0; i < list.Count; i++)
        {
            var pro = list[i];
            var spellProperty = pro.Property;
            if (spellProperty.SetupIdx == index)
                return list[i].Property;
        }
        return null;    
    }

    public string GetSpellType(int type)
    {
        if (type == 0)
            return I18NManager.Instance.GetWord("tips_1");
        if(type == 1)
            return I18NManager.Instance.GetWord("tips_2");
        if(type == 2)
            return I18NManager.Instance.GetWord("tips_3");
        if(type == 3)
            return I18NManager.Instance.GetWord("tips_4");
        return string.Empty;
    }

    /// <summary>
    /// 曝气技能
    /// </summary>
    public bool IsSuperSpell(int type)
    {
        return type == 1;
    }

    public List<ViReceiveDataArrayNode<ReceiveDataHeroSpellProperty>> learnedSpellList
    {
        get { return Player.Instance.Property.StudySpellList.Array; }
    }

    public bool SpellGridLock(int index)
    {
        var list = ViSealedDB<SpellLimitStruct>.Array;
        if (index >= list.Count)
        {
            ViDebuger.Error(string.Format("技能孔开启等级配置错误，当前索引{0}，配置个数{1}", index, list.Count));
            return false;
        }
        return CellHero.LocalHero.Property.Level < list[index].Level;
    }

    public int SpellGridUnlockLevel(int index)
    {
        var list = ViSealedDB<SpellLimitStruct>.Array;
        if (index >= list.Count)
        {
            ViDebuger.Error(string.Format("技能孔开启等级配置错误，当前索引{0}，配置个数{1}", index, list.Count));
            return 0;
        }
        return list[index].Level;
    }

    public string GetSpellLockTips(int index)
    {
        string level = SpellGridUnlockLevel(index).ToString();
        return string.Format(I18NManager.Instance.GetWord("tips_138"),level);
    }

    public bool IsEquiped(int id)
    {
        var list = CellHero.LocalHero.Property.SpellList;
        for (int i = 0; i < list.Count; i++)
        {
            var pro = list[i];
            var spellProperty = pro.Property;
            if (list[i].Property.WorkingInfo.Value.ID == id)
                return true;
        }
        return false;
    }
}
