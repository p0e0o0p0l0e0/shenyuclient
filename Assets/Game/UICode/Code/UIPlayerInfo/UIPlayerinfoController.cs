using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlayerInfoController : UIController<UIPlayerInfoController, UIPlayerInfoWindow>
{
    public enum WinType
    {
        None,
        Prop,
        Talent,
        Wing,
    }

    public enum BasicPropType
    {
        MaxHp,
        PhysicsAttack,
        MagicAttack,
        PhysicsDefence,
        MagicDefence
    }

    ViCallback<ReceiveDataHeroSpellProperty> _hintListCallback = new ViCallback<ReceiveDataHeroSpellProperty>();

    private WinType _curType;

    public WinType curType
    {
        get { return _curType; }
        set
        {
            if (_curType == value)
                return;
            if (_curType == WinType.None)
            {
                _curType = value;
            }
            else
            {
                if (_curType != WinType.None)
                    _mWinHandler.HideByType(_curType);
                _curType = value;
                _mWinHandler.ShowByType(_curType);
            }
        }
    }

    public override void Show()
    {
        
        Player.Instance.Property.StudySpellList.UpdateArrayCallbackList.Attach(_hintListCallback, (id, param0) =>
        {
            if (IsShow)
                RefreshTalent();
        } );
        base.Show();
    }
    
    public override void Hide()
    {
        _hintListCallback.End();
        base.Hide();
    }

    public void GetBasicAttr(int index,out string name,out string num)
    {
        var hero = CellHero.LocalHero;
        var prop = hero.Property;
        switch (index)
        {
            case (int)BasicPropType.MaxHp:
                name = "生命值";
                num = prop.HPMax0.Value.ToString();
                break;
            case (int)BasicPropType.PhysicsAttack:
                name = "物理强度";
                num = (prop.PhysicsAttack0.Value).ToString();
                break;
            case (int)BasicPropType.MagicAttack:
                name = "法术强度";
                num = (prop.MagicAttack0.Value).ToString();
                break;
            case (int)BasicPropType.PhysicsDefence:
                name = "物理防御";
                num = (prop.PhysicsDefence0.Value).ToString();
                break;
            case (int)BasicPropType.MagicDefence:
                name = "法术防御";
                num = (prop.MagicDefence0.Value).ToString();
                break;
            default:
                name = "未知属性";
                num = "";
                break;
        }
    }

    public void UpdateHp(float curHp, float maxHp, float rate)
    {
        if(_curType == WinType.Prop)
            _mWinHandler.attrWin.UpdateHp(curHp,maxHp,rate);
    }

    public void RefreshAttr()
    {
        var hero = CellHero.LocalHero;
        _mWinHandler.attrWin.SetConstInfo(hero.Property);
        _mWinHandler.attrWin.RefreshLevel(hero.Property);
        _mWinHandler.attrWin.UpdateEquipGrade();
        float hp = 1.0f * hero.Property.HP.Value / hero.Property.HPMax0.Value;
        _mWinHandler.attrWin.UpdateHp(hero.Property.HP,hero.Property.HPMax0, hp);
        _mWinHandler.attrWin.UpdateExp(hero.Property.XP,Player.Instance.LevelUpXP);
        _mWinHandler.attrWin.RefreshBaseAttr();
    }

    public void RefreshTalent()
    {
        bool closeRight = Player.Instance.Property.StudySpellList.Count == 0  && CellHero.LocalHero.Property.SpellList.Count == 0;
        XLColorDebug.LogUI("已学技能数据变化  当前技能数" + Player.Instance.Property.StudySpellList.Count);
        _mWinHandler.talentWin.Refresh();
        if (closeRight)
            _mWinHandler.talentWin.CloseRight();
        else
            _mWinHandler.talentWin.UpdateInfo();
    }



    public string GetEquipBtnName(OwnSpellStruct spell,out bool canUse,out bool canLearn)
    {
        canUse = false;
        canLearn = false;
        if (CellHero.LocalHero.Property.Level < spell.NeedLevel)
            return "未解锁";

        if (spell.EffectType != 0) //asd  判断可装备的类型
            return "不可装备";

        var learnList = TalentDataMgr.GetInstance.learnedSpellList;
        for (int i = 0; i < learnList.Count; ++i)
        {
            ReceiveDataHeroSpellProperty spellProperty = learnList[i].Property;
            OwnSpellStruct ownSpellInfo = spellProperty.Info.Value;
            if (spell.ID == ownSpellInfo.ID)
            {
                canUse = true;
                return "装备";
            }
        }
        var floorList = TalentDataMgr.GetInstance.GetSpellByFloor(spell.Floor);
        for (int i = 0; i < floorList.Count; i++)
        {
            for (int j = 0; j < learnList.Count; j++)
            {
                ReceiveDataHeroSpellProperty spellProperty = learnList[j].Property;
                OwnSpellStruct ownSpellInfo = spellProperty.Info.Value;
                if (floorList[i].ID == ownSpellInfo.ID)
                {
                    return "不可学";
                }
            }
        }
        canUse = true;
        canLearn = true;
        return "学习";
    }

    public bool SpellUnlock(int id)
    {
        OwnSpellStruct spell = ViSealedDB<OwnSpellStruct>.GetData(id);
        if (CellHero.LocalHero.Property.Level < spell.NeedLevel)
            return true;
        return false;
    }

    //aaa 爆气技能延后
    public bool SpellEquiped(int id)
    {
        for (int i = 0; i < spellGridCount&& i < CellHero.LocalHero.Property.SpellList.Count; i++)
        {
            var spell = CellHero.LocalHero.Property.SpellList[i];
            if (spell.NotNull() && spell.Property.Info.Value.ID == id)
                return true;
        }
        return false;
    }

    public bool SpellUnEquiped(int id)
    {
        var learnList = TalentDataMgr.GetInstance.learnedSpellList;
        for (int i = 0; i < learnList.Count; i++)
        {
            var spell = learnList[i];
            if (spell.Property.Info.Value.ID == id)
                return true;
        }
        return false;
    }

    public bool SpellCanLearn(int id)
    {
        var learnList = TalentDataMgr.GetInstance.learnedSpellList;
        var spellInfo = ViSealedDB<OwnSpellStruct>.GetData(id);
        var floorSpell = TalentDataMgr.GetInstance.GetSpellByFloor(spellInfo.Floor);
        for (int i = 0; i < floorSpell.Count; i++)
        {
            for (int j = 0; j < learnList.Count; j++)
            {
                var spell = learnList[j];
                if (spell.Property.Info.Value.ID == floorSpell[i].ID)
                    return false;
            }
        }
        return true;
    }

    public void RushWearEquip()
    {
        _mWinHandler.RushWearEquip();
    }
    private const int spellGridCount = 4;
}
