using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class UIBagWin : UIWindow<UIBagWin, UIBagController>
{
    public enum ClickType
    {
        Total,
        Equip,
        Consume,
        Other,
        Null
    }
    #region UI路径
    private const string ShowRoot = "UIKnapsackWindow/EquipList";
    private const string TotalSelect = "UIKnapsackWindow/PlayerKnapsack/TotalText";
    private const string EquipSelect = "UIKnapsackWindow/PlayerKnapsack/EquipText";
    private const string ConsumeSelect = "UIKnapsackWindow/PlayerKnapsack/ConsumeText";
    private const string OtherSelect = "UIKnapsackWindow/PlayerKnapsack/OtherText";
    private const string SelectObj = "/SelectText";
    private const string SliverNum = "UIKnapsackWindow/PlayerKnapsack/SilverBg/SilverText";
    private const string SilverBtn = "UIKnapsackWindow/PlayerKnapsack/SilverBg/AddButton";
    private const string GoldNum = "UIKnapsackWindow/PlayerKnapsack/GoldBg/GoldText";
    private const string GoldBtn = "UIKnapsackWindow/PlayerKnapsack/GoldBg/AddButton";
    private const string DiamondNum = "UIKnapsackWindow/PlayerKnapsack/DiamondBg/DiamondText";
    private const string DiamondBtn = "UIKnapsackWindow/PlayerKnapsack/DiamondBg/AddButton";
    private const string ItemList = "UIKnapsackWindow/PlayerKnapsack/EquipList";
    private const string ItemListContent = "/Content";
    private const string EquipQuality = "/EquipQuality";
    private const string CD = "/CD";
    private const string EquipNum = "/EquipNumText";
    private const string ArrangeBtn = "UIKnapsackWindow/PlayerKnapsack/ClearupBtn";
    private const string NowCount = "/ClearNumText";
    private const string WearEquip = "/Equip";
    private const string CloseBtn = "UIKnapsackWindow/CloseBtn";
    private const string DragTexture = "UIKnapsackWindow/EquipList/DragTexture";
    private const string ModelRoot = "UIKnapsackWindow/EquipList/ModelRoot";
    private const string ModelCamera = "UIKnapsackWindow/EquipList/Camera";
    private const string ModelTexture = "UIKnapsackWindow/EquipList/ModelTexture";
    #endregion

    ClickType _currectSelcet = ClickType.Null;
    List<int> severItemIndex;
    List<ushort> sortList = new List<ushort>(); //整理暂存的list
    private UIPointerListener modelListener;
    Avatar _avatar = null;
    protected override void Initial()
    {
        base.Initial();
        ExUIButton totalBtn = this.GetComponent<ExUIButton>(TotalSelect);
        totalBtn.Id = 0;
        totalBtn.onClickEx = ClickTitleTag;

        ExUIButton equipBtn = this.GetComponent<ExUIButton>(EquipSelect);
        equipBtn.Id = 1;
        equipBtn.onClickEx = ClickTitleTag;

        ExUIButton consumeBtn = this.GetComponent<ExUIButton>(ConsumeSelect);
        consumeBtn.Id = 2;
        consumeBtn.onClickEx = ClickTitleTag;
        ExUIButton otherBtn = this.GetComponent<ExUIButton>(OtherSelect);
        otherBtn.Id = 3;
        otherBtn.onClickEx = ClickTitleTag;

        LoopVerticalScrollRect loop = this.GetComponent<LoopVerticalScrollRect>(ItemList);
        loop.Init(RushList, 200);
        ExUIButton silverBtn = this.GetComponent<ExUIButton>(SilverBtn);
        silverBtn.onClick.AddListener(ClickSilver);
        ExUIButton goldBen = this.GetComponent<ExUIButton>(GoldBtn);
        goldBen.onClick.AddListener(ClickGold);
        ExUIButton diamondBtn = this.GetComponent<ExUIButton>(DiamondBtn);
        diamondBtn.onClick.AddListener(ClickDiamond);
        ExUIButton arrangeBtn = this.GetComponent<ExUIButton>(ArrangeBtn);
        arrangeBtn.onClick.AddListener(ClickArrer);
        severItemIndex = new List<int>();
        for (int i = 0; i < 8; i++)
        {
            ExUIButton btn = this.GetComponent<ExUIButton>(ShowRoot + WearEquip + i);
            btn.Id = UIBagDataMgr.GetInstance.GetWearTypeByItemId(i);
            btn.onClickEx = ClickWearEquip;
        }
        Camera modelCamera = this.GetComponent<Camera>(ModelCamera);
        modelListener = this.GetComponent<UIPointerListener>(DragTexture);
        modelListener.OnDragCallBack = OnDrag;
        ExUITexture modelTexture = this.GetComponent<ExUITexture>(ModelTexture);
        RenderTexture renderTexture = new RenderTexture(800, 800, 0);
        modelCamera.forceIntoRenderTexture = true;
        modelCamera.targetTexture = renderTexture;
        modelTexture.texture = renderTexture;
        modelTexture.color = new Color(modelTexture.color.r, modelTexture.color.g, modelTexture.color.b, 1);
        ExUIButton closeBtn = this.GetComponent<ExUIButton>(CloseBtn);
        closeBtn.onClickEx = Close;
        modelListener = this.GetComponent<UIPointerListener>(DragTexture);
        modelListener.OnDragCallBack = OnDrag;
    }

    public override void Show()
    {
        base.Show();
      //  SetCameraAndModel(true);
        ShowAvatar();
        RushWearEquip();
        ClickTitleTag(0, null);
    }

    public override void Hide()
    {
        UIBagDataMgr.GetInstance.ClearAllSprite();
     //   SetCameraAndModel(false);
        base.Hide();
        _currectSelcet = ClickType.Null;
    }

    public override void Destroy()
    {
        base.Destroy();
        UIBagDataMgr.GetInstance.UnLoadTexture();
    }
    public void ShowAvatar()
    {
        if (_avatar == null)
        {
            VisualHeroStruct visualInfo = ViSealedDB<VisualHeroStruct>.Data(1);
            SimpleAvatarStruct avatarInfo = visualInfo.Avatar.Data;
            _avatar = new Avatar();
            _avatar.LoadCallback = this._OnAvatarLoaded;
            AvatarCreator.Create(_avatar, avatarInfo.BodyResource.Resource, 1.0f, avatarInfo.PartResource);
        }
        else
        {
            _OnAvatarLoaded(_avatar);
        }
    }

    private void _OnAvatarLoaded(Avatar avatar)
    {
        int id = -1;
        Transform parent = this.FindTransform(ModelRoot);
        avatar.RootTran.parent = parent;
        UnityAssisstant.SetLayerRecursively(avatar.Root, (int)UnityLayer.UI_Model);
        avatar.Root.name = "HeroAvatar";
        avatar.RootTran.localPosition = new Vector3(0, -220, 0);
        avatar.RootTran.localRotation = Quaternion.Euler(0, 180, 0);
        avatar.RootTran.localScale = new Vector3(150, 150, 150);
        avatar.PlayActionAnim(AnimationData.Idle, true);
        avatar.ChangeUIShander();
    }
    private void OnDrag(int id, object vec)
    {
        PointerEventData data = vec as PointerEventData;
        if (_avatar != null)
        {
            _avatar.Root.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, _avatar.Root.transform.localRotation.eulerAngles.y - data.delta.x, 0.0f));
        }
    }
    /// <summary>
    /// 刷新页签内容
    /// </summary>
    /// <param name="id"></param>
    /// <param name="obj"></param>
    private void ClickTitleTag(int id, object obj)
    {
        if ((int)_currectSelcet != id)
        {
            _currectSelcet = (ClickType)id;
            ShowTag();
            UIBagDataMgr.GetInstance.ClearAllSprite();
            UIBagDataMgr.GetInstance.SetTagStage(_currectSelcet);
            RushSilverAndGoldAndDia();
            RushArrerBtnCount(UIBagDataMgr.GetInstance.GetItemList().Count);
            LoopVerticalScrollRect loop = this.GetComponent<LoopVerticalScrollRect>(ItemList);
            loop.RefillCells();
        }
    }

    /// <summary>
    /// 展示页签切换
    /// </summary>
    private void ShowTag()
    {
        this.FindTransform(TotalSelect + SelectObj).SetActive(_currectSelcet == ClickType.Total ? true : false);
        this.FindTransform(EquipSelect + SelectObj).SetActive(_currectSelcet == ClickType.Equip ? true : false);
        this.FindTransform(ConsumeSelect + SelectObj).SetActive(_currectSelcet == ClickType.Consume ? true : false);
        this.FindTransform(OtherSelect + SelectObj).SetActive(_currectSelcet == ClickType.Other ? true : false);
    }


    ReceiveDataItemProperty item;
    ExUITexture tex;
    ExUIButton button;
    Text text;
    /// <summary>
    /// 刷新格子
    /// </summary>
    /// <param name="name"></param>
    /// <param name="id"></param>
    private void RushList(string name, int id)
    {
        string quality = ItemList + ItemListContent + "/" + name + EquipQuality;
        if (id < UIBagDataMgr.GetInstance.GetItemList().Count)
        {
            this.FindTransform(quality).SetActive(true);
            item = Player.Instance.Property.Inventory.Array[UIBagDataMgr.GetInstance.GetItemList()[id]].Property;
            tex = this.GetComponent<ExUITexture>(quality);
            UIBagDataMgr.GetInstance.SetItemIconAndQuality(ref tex, item.Info, ExUITexture_Extend.IconStyle.RECT);
            button = this.GetComponent<ExUIButton>(quality);
            button.Id = id;
            button.onClickEx = ClickItem;
            text = this.GetComponent<Text>(quality + EquipNum);
            text.text = item.StackCount.Value.ToString();
            ItemStruct str = ViSealedDB<ItemStruct>.Data(item.Info);
            int index = UIBagDataMgr.GetInstance.GetIndexByItemType(str.Type);
            if (index >= 0 && UIBagDataMgr.GetInstance.GetIsUnsing(index))
            {
                ExUISprite sprite = this.GetComponent<ExUISprite>(quality + CD);
                sprite.SetActive(true);
                UIBagDataMgr.GetInstance.AddSprite(index, sprite);
            }
            else
            {
                this.FindTransform(quality + CD).SetActive(false);
            }
        }
        else
        {
            this.FindTransform(quality).SetActive(false);
        }
    }

    /// <summary>
    /// 资源点击
    /// </summary>
    /// <param name="id"></param>
    /// <param name="obj"></param>
    private void ClickItem(int id, object obj)
    {
        ReceiveDataItemProperty inventoryPro = Player.Instance.Property.Inventory.Array[UIBagDataMgr.GetInstance.GetItemList()[id]].Property;
        ItemStruct str = ViSealedDB<ItemStruct>.Data(inventoryPro.Info);
        int index = UIBagDataMgr.GetInstance.GetIndexByItemType(str.Type);
        if (index >= 0 && UIBagDataMgr.GetInstance.GetIsUnsing(index))
        {

        }
        else
        {
            UIManagerUtility.ShowTips(true, inventoryPro.Info, inventoryPro.Slot.Slot, true);
        }
    }

    private void ClickSilver()
    {

    }
    private void ClickGold()
    {

    }
    private void ClickDiamond()
    {

    }

    private void ClickArrer()
    {
        if (UIBagDataMgr.GetInstance.GetItemList().Count > 0)
        {
            sortList.Clear();
            for (int i = 0; i < Player.Instance.Property.Inventory.Count; i++)
                sortList.Add(Player.Instance.Property.Inventory.Array[i].Property.Slot.Slot);
            UIBagDataMgr.GetInstance.Set(true);
            PlayerServerInvoker.SortBagItem(Player.Instance, sortList);

        }
    }

    public void CallBackClickArrer()
    {
        ClickType type = _currectSelcet;
        _currectSelcet = ClickType.Null;
        ClickTitleTag((int)type, null);
    }
    /// <summary>
    /// 刷新金币 银币和钻石数据
    /// </summary>
    private void RushSilverAndGoldAndDia()
    {
        this.GetComponent<Text>(SliverNum).text = Player.Instance.Property.YinPiao.Value.ToCHS();
        this.GetComponent<Text>(GoldNum).text = Player.Instance.Property.JinPiao.Value.ToCHS();
        this.GetComponent<Text>(DiamondNum).text = Player.Instance.Property.JinZiInAccount.Value.ToCHS();
    }


    private void RushArrerBtnCount(int num)
    {
        this.GetComponent<Text>(ArrangeBtn + NowCount).text = num + "/200";
    }

    private void OnAddItem()
    {
        //PlayerServerInvoker.AddItem()
    }

    public void RushAllFromZero()
    {
        UIBagDataMgr.GetInstance.SetTagStage(_currectSelcet);
        RushSilverAndGoldAndDia();
        RushArrerBtnCount(UIBagDataMgr.GetInstance.GetItemList().Count);
        LoopVerticalScrollRect loop = this.GetComponent<LoopVerticalScrollRect>(ItemList);
        loop.RefreshAllCells();
    }


    #region 装备穿戴
    public void RushWearEquip()
    {
        for (int i = 0; i < 8; i++)
        {
            this.FindTransform(ShowRoot + WearEquip + i).gameObject.SetActive(false);
        }
        for (int i = 0; i < Player.Instance.Property.Equipments.Count; i++)
        {
            // Debug.Log(i+"---->"+Player.Instance.Property.Equipments[i].Property.Info);
            string path = ShowRoot + "/" + UIBagDataMgr.GetInstance.GetWearItemName(Player.Instance.Property.Equipments[i].Property.Info.Value.EquipSlot);
            Transform trans = this.FindTransform(path);
            if (trans != null)
            {
                trans.gameObject.SetActive(true);
                ExUITexture tex = this.GetComponent<ExUITexture>(path);
                UIBagDataMgr.GetInstance.SetItemIconAndQuality(ref tex, Player.Instance.Property.Equipments[i].Property.Info, ExUITexture_Extend.IconStyle.CYCLE);
            }
        }
    }

    private void ClickWearEquip(int id, object obj)
    {
        for (int i = 0; i < Player.Instance.Property.Equipments.Count; i++)
        {
            if (Player.Instance.Property.Equipments.Array[i].Property.Info.Value.EquipSlot == id)
            {
                UIManagerUtility.ShowTips(false, Player.Instance.Property.Equipments.Array[i].Property.Info, Player.Instance.Property.Equipments.Array[i].Property.Slot.Slot, false);
                break;
            }
        }
    }

    private void Close(int val, object obj)
    {
        UIManager.Instance.Hide(UIControllerDefine.WIN_Bag);
    }
    #endregion

    /// <summary>
    /// 设置摄像机和模型状态
    /// </summary>
    /// <param name="show"></param>
    public void SetCameraAndModel(bool show)
    {
        Camera modelCamera = this.GetComponent<Camera>(ModelCamera);
        if (modelCamera != null)
            modelCamera.enabled = show;

        if(_avatar!=null)
        {
            int layer;
            if (show)
                layer = (int)UnityLayer.UI_Model;
            else
                layer = (int)UnityLayer.UI_Invisible;
            _avatar.RootTran.gameObject.SetModelAndChildrenLayer( layer);
        }
    }

}
