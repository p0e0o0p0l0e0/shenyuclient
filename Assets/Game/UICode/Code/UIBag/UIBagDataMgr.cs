using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;


public class UIBagDataMgr : DataManagerBase<UIBagDataMgr>, IRelease
{





    bool isArrer = false;

    /// <summary>
    /// 本地item位置
    /// </summary>
    private List<int> severItemIndex = new List<int>();

    //排序实例
    private AllSort allSort = new AllSort();
    private EquipSort equipSort = new EquipSort();
    private ConsumeSort consumeSort = new ConsumeSort();
    private OtherSort otherSort = new OtherSort();
    //   private SortCount sortCount = new SortCount();
    private SortNum sortNum = new SortNum();

    private List<ExUITexture> textureList = new List<ExUITexture>();

    public UIBagDataMgr()
    {
        for (int i = 0; i < (int)TickType.Buff; i++)
        {
            ItemCDTypeList.Add(new ItemCD((TickType)i));
        }
    }
    public List<int> GetItemList()
    {
        return severItemIndex;
    }
    public void Set(bool arrer)
    {
        isArrer = arrer;
    }

    public int GetAllCountByID(int id)
    {
        int count = 0;
        for (int i = 0; i < Player.Instance.Property.Inventory.Array.Count; i++)
        {
            if (Player.Instance.Property.Inventory.Array[i].Property.Info.Value.ID == id)
                count += Player.Instance.Property.Inventory.Array[i].Property.StackCount;
        }
        return count;
    }


    public void SetTagStage(UIBagWin.ClickType type)
    {
        switch (type)
        {
            case UIBagWin.ClickType.Total:
                GetAllItemList();
                break;
            case UIBagWin.ClickType.Equip:
                GetEquipList();
                break;
            case UIBagWin.ClickType.Consume:
                GetConsumeList();
                break;
            case UIBagWin.ClickType.Other:
                GetOtherList();
                break;
        }
    }
    private List<int> GetAllItemList()
    {
        severItemIndex.Clear();
        for (int i = 0; i < Player.Instance.Property.Inventory.Array.Count; i++)
        {
            severItemIndex.Add(i);
        }
      //  severItemIndex.Sort(allSort);
      //  severItemIndex.Sort(sortCount);
        return severItemIndex;
    }


    private List<int> GetEquipList()
    {
        severItemIndex.Clear();
        for (int i = 0; i < Player.Instance.Property.Inventory.Array.Count; i++)
        {
            int type = ViSealedDB<ItemStruct>.Data(Player.Instance.Property.Inventory.Array[i].Property.Info).Type.Value;
            if (type == (int)ItemType.ARMOR)
                severItemIndex.Add(i);
        }
        severItemIndex.Sort(equipSort);
        //   severItemIndex.Sort(sortCount);
        return severItemIndex;
    }

    private List<int> GetConsumeList()
    {
        severItemIndex.Clear();
        for (int i = 0; i < Player.Instance.Property.Inventory.Array.Count; i++)
        {
            int type = ViSealedDB<ItemStruct>.Data(Player.Instance.Property.Inventory.Array[i].Property.Info).Type.Value;
            if (type == (int)ItemType.CONSUMABLE || type == (int)ItemType.BUFF_ITEM
                || type == (int)ItemType.DRAWING || type == (int)ItemType.XP_STONE || type == (int)ItemType.MOUNT
                || type == (int)ItemType.RIDING
                || type == (int)ItemType.GIFT)
            {
                severItemIndex.Add(i);
            }
        }
        severItemIndex.Sort(consumeSort);
        //  severItemIndex.Sort(sortCount);
        return severItemIndex;
    }

    private List<int> GetOtherList()
    {
        severItemIndex.Clear();
        for (int i = 0; i < Player.Instance.Property.Inventory.Array.Count; i++)
        {
            int type = ViSealedDB<ItemStruct>.Data(Player.Instance.Property.Inventory.Array[i].Property.Info).Type.Value;
            if (type == (int)ItemType.MAKE_STONE || type == (int)ItemType.ENHANCE_STONE
                || type == (int)ItemType.GEM)
                severItemIndex.Add(i);
        }
        severItemIndex.Sort(otherSort);
        //  severItemIndex.Sort(sortCount);
        return severItemIndex;
    }


    /// <summary>
    /// 设置资源图片
    /// </summary>
    /// <param name="tex"></param>
    /// <param name="id"></param>//物体id
    public void SetItemIconAndQuality(ref ExUITexture tex, int id, ExUITexture_Extend.IconStyle style)
    {
        tex.LoadIcon(ViSealedDB<VisualItemStruct>.Data(id).Icon, GetQualityByQualityId(id), style);
        if (!textureList.Contains(tex))
            textureList.Add(tex);
    }



    /// <summary>
    /// 卸载已经加载的texture
    /// </summary
    public void UnLoadTexture()
    {
        if (textureList != null)
        {
            for (int i = 0; i < textureList.Count; i++)
            {
                textureList[i].UnLoadIcon();
            }
        }
        textureList.Clear();
    }

    /// <summary>
    ///通过物品id获得品质框
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public ItemQualityEnum GetQualityByQualityId(int id)
    {
        if (ViSealedDB<ItemStruct>.Data(id).Quality.NotEmpty())
        {
            switch (ViSealedDB<ItemStruct>.Data(id).Quality.PData.ID)
            {
                case 0:
                    return ItemQualityEnum.WHITE;
                case 1:
                    return ItemQualityEnum.WHITE;
                case 2:
                    return ItemQualityEnum.BLUE;
                case 3:
                    return ItemQualityEnum.PURPLE;
                case 4:
                    return ItemQualityEnum.ORANGE;
                default:
                    return ItemQualityEnum.NONE;
            }
        }

        return ItemQualityEnum.WHITE;

    }



    public class AllSort : IComparer<int>
    {
        public int Compare(int y, int x)
        {
            //之前按照种类排
            //int typeX = ViSealedDB<ItemStruct>.Data(Player.Instance.Property.Inventory.Array[x].Property.Info).Type.Value;
            //int typeY = ViSealedDB<ItemStruct>.Data(Player.Instance.Property.Inventory.Array[y].Property.Info).Type.Value;
            //if (typeX > typeY)
            //    return -1;
            //else
            //    return 0;
            ItemStruct typeX = ViSealedDB<ItemStruct>.Data(Player.Instance.Property.Inventory.Array[x].Property.Info);
            ItemStruct typeY = ViSealedDB<ItemStruct>.Data(Player.Instance.Property.Inventory.Array[y].Property.Info);

            if (typeX.Quality.PData.ID < typeY.Quality.PData.ID)
                return -1;
            else if (typeX.Quality.PData.ID > typeY.Quality.PData.ID)
                return 1;
            if (typeX.ID > typeY.ID)
                return -1;
            else if (typeX.ID < typeY.ID)
                return 1;
            return 0;
        }
    }

    public class EquipSort : IComparer<int>
    {
        public int Compare(int y, int x)
        {
            ItemStruct itemX = ViSealedDB<ItemStruct>.Data(Player.Instance.Property.Inventory.Array[x].Property.Info);
            ItemStruct itemY = ViSealedDB<ItemStruct>.Data(Player.Instance.Property.Inventory.Array[y].Property.Info);
            if (itemX.Level < itemY.Level)
                return -1;
            if (itemX.Quality.PData.ID < itemY.Quality.PData.ID)
                return -1;
            else
                return 0;
        }
    }

    public class ConsumeSort : IComparer<int>
    {
        public int Compare(int y, int x)
        {
            ItemStruct itemX = ViSealedDB<ItemStruct>.Data(Player.Instance.Property.Inventory.Array[x].Property.Info);
            ItemStruct itemY = ViSealedDB<ItemStruct>.Data(Player.Instance.Property.Inventory.Array[y].Property.Info);
            if (itemX.Type.Value > itemY.Type.Value)
                return -1;
            if (itemX.Quality.PData.ID < itemY.Quality.PData.ID)
                return -1;
            else
                return 0;
        }
    }

    public class OtherSort : IComparer<int>
    {
        public int Compare(int y, int x)
        {
            ItemStruct itemX = ViSealedDB<ItemStruct>.Data(Player.Instance.Property.Inventory.Array[x].Property.Info);
            ItemStruct itemY = ViSealedDB<ItemStruct>.Data(Player.Instance.Property.Inventory.Array[y].Property.Info);
            if (itemX.Type.Value > itemY.Type.Value)
                return -1;
            if (itemX.Quality.PData.ID < itemY.Quality.PData.ID)
                return -1;
            else
                return 0;
        }
    }

    public class SortCount : IComparer<int>
    {
        public int Compare(int y, int x)
        {
            if (Player.Instance.Property.Inventory.Array[x].Property.Info == Player.Instance.Property.Inventory.Array[y].Property.Info)
            {
                if (Player.Instance.Property.Inventory.Array[x].Property.StackCount < Player.Instance.Property.Inventory.Array[y].Property.StackCount)
                    return -1;
            }
            return 1;
        }
    }


    public void OnItemDateChange(ViReceiveDataNode before, object after)
    {

        ViReceiveDataArray<ReceiveDataItemProperty, ItemProperty> bef = before as ViReceiveDataArray<ReceiveDataItemProperty, ItemProperty>;
        ViReceiveDataArray<ReceiveDataItemProperty, ItemProperty> aft = after as ViReceiveDataArray<ReceiveDataItemProperty, ItemProperty>;
        UIBagController bagController = UIManager.Instance.GetController<UIBagController, UIBagWin>(UIControllerDefine.WIN_Bag);
        if (bagController != null && bagController.IsShow)
        {
            if (isArrer)
            {
                bagController.SortBagItem();
                isArrer = false;
            }
            else
                bagController.CountChange();

            //if (isArrer)
            //{
            //    bagController.SortBagItem();
            //    isArrer = false;
            //}
            //else //减少 增加 都伴随数量改变
            //{
            //    List<int> deList = new List<int>();
            //    List<int> changeCountLsit = new List<int>();
            //    List<int> addList = new List<int>();
            //    bool isHaveSolt = false;
            //    for (int i = 0; i < severItemIndex.Count; i++)
            //    {
            //        isHaveSolt = false;
            //        ReceiveDataItemProperty pro = bef.Array[severItemIndex[i]].Property;
            //        for (int j = 0; j < aft.Array.Count; j++)
            //        {
            //            if (pro.Slot == aft.Array[j].Property.Slot)
            //            {
            //                if (pro.StackCount != aft.Array[j].Property.StackCount)
            //                    changeCountLsit.Add(i);
            //                 isHaveSolt = true;
            //                break;
            //            }
            //        }
            //        if (!isHaveSolt)
            //            deList.Add(i);
            //    }
            //    for(int i=0;i< aft.Array.Count; i++)
            //    {
            //        for(int j = 0; j < bef.Array.Count; j++)
            //        {
            //            if (aft[i].Property.Slot.Slot== bef[j].Property.Slot.Slot&&)
            //            {
            //                addList.Add(i);
            //            }
            //        }
            //    }

            //    if (changeCountLsit.Count > 0)
            //        changeCountLsit.Sort(sortCount);
            //    if (deList.Count > 0)
            //    {
            //        deList.Sort(sortCount);
            //        for (int i = 0; i < deList.Count; i++)
            //        {
            //            severItemIndex.Remove(i);
            //        }
            //    }
            //    if()
        }
    }
    public void OnWearEquipDateChange(ViReceiveDataNode before, object after)
    {
        ViReceiveDataArray<ReceiveDataItemProperty, ItemProperty> aft = after as ViReceiveDataArray<ReceiveDataItemProperty, ItemProperty>;
        UIBagController bagController = UIManager.Instance.GetController<UIBagController, UIBagWin>(UIControllerDefine.WIN_Bag);

        if (bagController != null && bagController.IsShow)
        {
            bagController.RushWearEquip();
            return;
        }
        UIPlayerInfoController uiPlayer = UIManager.Instance.GetController<UIPlayerInfoController, UIPlayerInfoWindow>(UIControllerDefine.WIN_PlayerInfo);
        if (uiPlayer != null && uiPlayer.IsShow)
        {
            uiPlayer.RushWearEquip();
        }
    }


    public class SortNum : IComparer<int>
    {
        public int Compare(int y, int x)
        {
            if (x > y)
                return -1;
            return 0;
        }
    }


    public string GetWearItemName(int type)
    {
        switch (type)
        {
            case 0:
                return "Equip0";
            case 14:
                return "Equip1";
            case 9:
                return "Equip2";
            case 11:
                return "Equip3";
            case 7:
                return "Equip4";
            case 4:
                return "Equip5";
            case 2:
                return "Equip6";
            case 1:
                return "Equip7";
            default:
                return "";
        }
    }

    public int GetWearTypeByItemId(int id)
    {
        switch (id)
        {
            case 0:
                return 0;
            case 1:
                return 14;
            case 2:
                return 9;
            case 3:
                return 11;
            case 4:
                return 7;
            case 5:
                return 4;
            case 6:
                return 2;
            case 7:
                return 1;
            default:
                return -1;
        }
    }
    public void Release()
    {
        severItemIndex = null;
    }


    public void ClearAllSprite()
    {
        for (int i = 0; i < ItemCDTypeList.Count; i++)
        {
            ItemCDTypeList[i].ClearSprite();
        }
    }


    public bool GetIsUnsing(int index)
    {
        if (index < ItemCDTypeList.Count)
            return ItemCDTypeList[index].isCding;
        else
            return false;
    }
    public void AddSprite(int index, ExUISprite sprite)
    {
        for (int i = 0; i < ItemCDTypeList.Count; i++)
        {
            if (i != index)
                ItemCDTypeList[i].RemoveSprite(sprite);
        }
        ItemCDTypeList[index].AddSprite(sprite);
    }
    /// <summary>
    /// 接收物品使用成功消息
    /// </summary>
    public void ReceiveItemUseSuccess(UInt32 itemID)
    {
        ItemStruct item = ViSealedDB<ItemStruct>.Data(itemID);
        if(item==null)
        {
            return;
        }
        float time = item.Use.CoolChannel.PData.Duration/100;

        if (item.Type.Value == (int)ItemType.CONSUMABLE)
        {
            ItemCDTypeList[0].StartTick(time, time);
        }
        else if (item.Type.Value == (int)ItemType.MAGIC_ITEM)
        {
            ItemCDTypeList[1].StartTick(time, time);
        }
        else if (item.Type.Value == (int)ItemType.BUFF_ITEM)
        {
            ItemCDTypeList[2].StartTick(time, time);
        }
        UIBagController controller = UIManager.Instance.GetController<UIBagController, UIBagWin>(UIControllerDefine.WIN_Bag);
        if (controller.IsShow)
        {
            controller.CountChange();
        }
    }

    public int GetIndexByItemType(int type)
    {
        if (type == (int)ItemType.CONSUMABLE)
            return 0;
        else if (type == (int)ItemType.MAGIC_ITEM)
            return 1;
        else if (type == (int)ItemType.BUFF_ITEM)
            return 2;
        else
            return -1;
    }


    public enum TickType
    {
        Hp,
        Mp,
        Buff
    }


    List<ItemCD> ItemCDTypeList = new List<ItemCD>();
    public class ItemCD
    {
        public TickType tickType { get; private set; }
        public bool isCding { get; private set; }
        ViTickNode tick;
        float leftTime;
        float allTime;
        public List<ExUISprite> spriteList = new List<ExUISprite>();
        public ItemCD(TickType type)
        {
            tickType = type;
        }
        public void StartTick(float alone, float all)
        {
            spriteList.Clear();
            if (all == 0)
                return;
            isCding = true;
            leftTime = alone;
            allTime = all;
            if (tick == null)
                tick = new ViTickNode();
            tick.Attach(TickAttach);
        }
        private void TickAttach(float time)
        {
            leftTime -= time;
            if (spriteList.Count > 0)
            {
                float so = leftTime / allTime;
                for (int i = 0; i < spriteList.Count; i++)
                {
                    spriteList[i].fillAmount =so;
                }
            }
            if (leftTime <= 0)
            {
                StopTick();
            }
        }

        private void StopTick()
        {
            isCding = false;
            for (int i = 0; i < spriteList.Count; i++)
            {
                if (spriteList[i] != null)
                    spriteList[i].SetActive(false);
            }
            spriteList.Clear();
        }

        public void AddSprite(ExUISprite sprite)
        {
            if (!spriteList.Contains(sprite))
            {
                spriteList.Add(sprite);
                sprite.fillClockwise = false;
            }
              
        }

        public void RemoveSprite(ExUISprite sprite)
        {
            if (spriteList.Contains(sprite))
                spriteList.Remove(sprite);
        }
        public void ClearSprite()
        {
            spriteList.Clear();
        }
    }
}


