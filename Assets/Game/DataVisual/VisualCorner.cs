using System;
using System.Collections;
using System.Collections.Generic;

public class VisualCorner : ViSealedData
{
    public string iconName; //方形icon
    public string professionName;//职业名称
    public string professionIcon;//职业图标
    public int professionNameColorsR;
    public int professionNameColorsG;
    public int professionNameColorsB;
    public string description;//职业描述 
    public string descriptionIcon;//职业描述Icon


    public ViStaticArray<ViForeignKeyStruct<OwnSpellStruct>> Spell = new ViStaticArray<ViForeignKeyStruct<OwnSpellStruct>>(3);
    public ViStaticArray<ViForeignKeyStruct<VisualCornerList>> Hair = new ViStaticArray<ViForeignKeyStruct<VisualCornerList>>(5);  //初始可选发型, male
    public ViStaticArray<ViForeignKeyStruct<VisualCornerList>> Face = new ViStaticArray<ViForeignKeyStruct<VisualCornerList>>(5);  //初始可选脸型, male
    public ViStaticArray<ViForeignKeyStruct<VisualCornerList>> Hair_Fight = new ViStaticArray<ViForeignKeyStruct<VisualCornerList>>(5);    //战斗中可选发型, male
    public ViStaticArray<ViForeignKeyStruct<VisualCornerList>> Face_Fight = new ViStaticArray<ViForeignKeyStruct<VisualCornerList>>(5);  //战斗中可选脸型, female
    public ViForeignKey<ItemStruct> Weapon1;   //角色展示武器
    public ViForeignKey<ItemStruct> SubWeapon1;    //角色展示副手
    public ViForeignKey<ItemStruct> Shoulder; //角色展示肩膀
    public ViForeignKey<ItemStruct> Jacket; //角色展示衣服
    public ViForeignKey<ItemStruct> Pants; //角色展示下身衣服
    public ViForeignKey<PathFileResStruct> Body;



}
