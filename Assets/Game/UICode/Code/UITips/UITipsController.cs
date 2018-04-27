using System;

public class UITipsController : UIController<UITipsController, UITipsWindow>
{
    private int showId;
    public ushort bagPos { get; private set; }

    public bool IsEquipWearing { get; private set; }
    public bool isItemInBag { get; private set; }

    public bool ShowEquipCompare
    {
        get
        {
            return false;
            //var item = GetItem();
            //var equips = Player.Instance.Property.Equipments;
            //for (int i = 0; i < equips.Count; i++)
            //{
            //    if (item.EquipSlot.Value == equips[i].Property.Info.Value.EquipSlot)
            //        return true;
            //}
            //return false;
        }
    }

    private string showUid;
    protected override void Initial()
    {
        base.Initial();
    }
    public override void Show()
    {
        base.Show();
    }
    public override void Hide()
    {
        showId = -1;
        showUid = null;
        base.Hide();
    }

    public void SetId(bool isEquip, int id,ushort pos,bool inbag)
    {
        IsEquipWearing = !isEquip;
        showId = id;
        bagPos = pos;
        isItemInBag = inbag;
    }

    public ItemStruct GetItem()
    {
        return View_ItemAssisstant.GetItemStruct(showId);
    }

    public ItemStruct GetCompareEquip()
    {
        var item = GetItem();
        var equips = Player.Instance.Property.Equipments;
        for (int i = 0; i < equips.Count; i++)
        {
            if (item.EquipSlot.Value == equips[i].Property.Info.Value.EquipSlot)
                return equips[i].Property.Info.Value;
        }
        return null;
    }

    public string GetCompareValue(int type,int sValue)
    {
        if (IsEquipWearing)
            return string.Empty;

        var item = GetCompareEquip();
        if (item.Null())
            return string.Empty;

        for (int i = 0; i < item.Value.Data.Value.Array.Length; i++)
        {
            if (item.Value.Data.Value.Array[i].Type.Value == type)
            {
                int value = sValue - item.Value.Data.Value.Array[i].Value;
                value /= 100;
                if (value > 0)
                    return string.Format("+{0}", value);
                if(value < 0)
                    return string.Format("{0}", value);
                return string.Empty;
            }
        }
        return string.Empty;
    }

    public void ShowTips()
    {
        var type = View_ItemAssisstant.GetItemType(showId);
        if(type == ItemType.ARMOR)
            _mWinHandler.ShowEquip();
        else
        {
            if (isItemInBag)
                _mWinHandler.ShowBagItem();
            else
                _mWinHandler.ShowNormalItem();
        }
        return;

        switch (type)
        {
            case ItemType.ARMOR:
                _mWinHandler.ShowEquip();
                break;
            case ItemType.JUNK:
                break;
            
            case ItemType.DRESS:
                break;
            case ItemType.CONSUMABLE:
                break;
            case ItemType.ELEMENT:
                break;
            case ItemType.GEM:
                break;
            case ItemType.GIFT:
                break;
            case ItemType.XP_STONE:
                break;
            case ItemType.HERO_XP_STONE:
                break;
            case ItemType.HERO_KID_XP_STONE:
                break;
            case ItemType.ITEM_FRAGMENT:
                break;
            case ItemType.YINPIAO_STONE:
                break;
            case ItemType.JINPIAO_STONE:
                break;
            case ItemType.POWER_STONE:
                break;
            case ItemType.FAKE_ARENA_HONR_STONE:
                break;
            case ItemType.FRIEND_HONR_STONE:
                break;
            case ItemType.QUEST_STONE:
                break;
            case ItemType.VIP_STONE:
                break;
            case ItemType.LOOT_FRAGMENT:
                break;
            case ItemType.LINK_STONE:
                break;
            case ItemType.LEVEL_UP_STONE:
                break;
            case ItemType.CDKEY_STONE:
                break;
            case ItemType.SPACE_TICKET:
                break;
            case ItemType.PRIVATE_SHARE_SPACE_CREATE_STONE:
                break;
            case ItemType.PRIVATE_SHARE_SPACE_ENTER_STONE:
                break;
            case ItemType.FAKE_ARENA_STONE:
                break;
            case ItemType.TOTAL:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    /// <summary>
    /// 带有随机属性的物品
    /// </summary>
    public void Show(string id)
    {
    }

    public ItemValueStruct GetItemValue(int id)
    {
        var item = ViSealedDB<ItemStruct>.Data(id);
        var itemValue = View_ItemAssisstant.GetItemAttribute(item);
        XLColorDebug.LogBattle(itemValue);
        return null;
    }

    public string GetQualityBackName()
    {
        var item = View_ItemAssisstant.GetItemStruct(showId);
        switch ((ItemQualityEnum)item.Quality.Data.ItemQualityEnum.Value)
        {
            case ItemQualityEnum.BLUE:
                return "bg_blue";
            case ItemQualityEnum.ORANGE:
                return "bg_orange";
            case ItemQualityEnum.PURPLE:
                return "bg_purple";
            case ItemQualityEnum.WHITE:
                return "bg_white";
            case ItemQualityEnum.NONE:
                return "bg_white";
        }
        return "";
    }

    public string GetRankSpName()
    {
        return "a";
    }

    public string GetRankNum()
    {
        return "111";
    }

    public bool ItemCanUse()
    {
        var item = GetItem();
        return item.Use.UseType.Value == 1;
    }
}
