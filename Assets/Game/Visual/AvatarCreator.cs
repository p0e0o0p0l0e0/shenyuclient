using System;
using System.Collections.Generic;


/// <summary>
///  创建人物
/// </summary>
public static class AvatarCreator
{
    /// <summary>
    /// 创建新接口（创建人）
    /// </summary>
    /// <param name="ava"></param>
    /// <param name="gender"></param>
    /// <param name="profession"></param>职业 id
    /// <param name="partScale"></param>
    /// <param name="ItemIdList"></param>
    /// <param name="hairId"></param>
    /// <param name="faceId"></param>
    public static void Create(Avatar ava, byte gender, int profession, float partScale, List<int> ItemIdList, int hairId = 0, int faceId = 0)
    {
        if (ViSealedDB<VisualCorner>.Data(profession).Body.PData != null)
            Create(ava, gender, ViSealedDB<VisualCorner>.Data(profession).Body.PData, partScale, ItemIdList, hairId, faceId);
        else
            ViDebuger.Note("传入职业错误 profession ==" + profession);
    }

    public static void Create(Avatar ava, byte gender, int profession, float partScale, ViReceiveDataArray<ReceiveDataItemProperty, ItemProperty> ItemIdList, int hairId = 0, int faceId = 0)
    {
        List<int> itemList = new List<int>();
        for(int i=0;i< ItemIdList.Count; i++)
        {
            itemList.Add((int)ItemIdList[i].Property.ID.Value);
        }
        Create(ava, gender, profession, partScale, itemList, hairId, hairId);
    }
        /// <summary>
    /// 创建新接口（可以创建人物和怪）
    /// </summary>
    /// <param name="ava"></param>
    /// <param name="gender"></param>创建怪的时候可以填任意值
    /// <param name="body"></param> 身体路径
    /// <param name="partScale"></param>
    /// <param name="ItemIdList"></param> 装备id
    /// <param name="hairId"></param>
    /// <param name="faceId"></param>

    public static void Create(Avatar ava, byte gender, PathFileResStruct body,float partScale, List<int> ItemIdList, int hairId=0 , int faceId=0)
    {
        ava.SetBody(body);
        ava.SetPart(ItemIdList, gender);
        ava.SetFaceOrFair(faceId);
        ava.SetFaceOrFair(hairId);
    }

 

    /// <summary>
    /// 老接口（逐渐弃用）(可以创建怪，不能创建人物)
    /// </summary>
    /// <param name="avatar"></param>
    /// <param name="body"></param>
    /// <param name="partScale"></param>
    /// <param name="partList"></param>
	public static void Create(Avatar avatar, PathFileResStruct body, float partScale, List<ViForeignKeyStruct<PathFileResStruct>> partList)
    {
        avatar.SetBody(body);
        avatar.PartScale = partScale;       
    }
   
    /// <summary>
    /// 老接口逐渐弃用(可以创建怪，不能创建人物)
    /// </summary>
    /// <param name="avatar"></param>
    /// <param name="body"></param>
    /// <param name="partScale"></param>
    /// <param name="partList"></param>
	public static void Create(Avatar avatar, PathFileResStruct body, float partScale, ViStaticArray<ViForeignKeyStruct<PathFileResStruct>> partList)
    {
        avatar.SetBody(body);
    }

    public static void UpdatePart(Avatar avatar, float partScale, List<ViForeignKeyStruct<PathFileResStruct>> partList)
    {
        for (int iter = 0; iter < partList.Count; ++iter)
        {
            if (partList[iter].NotEmpty())
            {
                //avatar.SetPart(iter, AvatarPartType.LINK, partList[iter].Data);
            }
            else
            {
                avatar.ClearPart(iter, AvatarPartType.LINK);
            }
        }
    }

    public static void Create(Avatar avatar, SimpleAvatarStruct info)
    {
        Create(avatar, info.BodyResource.Resource, info.GetPartScale(), info.PartResource);
    }

    public static void AddAvatarDurationVisual(Avatar avatar, ViAvatarDurationVisualStruct info, Int32 weight)
    {
        avatar.DurationVisualOwnList.Add(null, avatar, info, weight);
        //
        //if (info.hitVisual != 0)
        //{
        //    OnHitEffectVisual(caster, info.hitVisual);
        //}
    }

    public static void MergePart(ViStaticArray<ViForeignKeyStruct<PathFileResStruct>> from, List<ViForeignKeyStruct<PathFileResStruct>> to)
    {
        for (int iter = 0; iter < ViMathDefine.Min(from.Length, to.Count); ++iter)
        {
            if (from[iter].NotEmpty())
            {
                to[iter] = (from[iter]);
            }
        }
        for (int iter = ViMathDefine.Min(from.Length, to.Count); iter < from.Length; ++iter)
        {
            to.Add(from[iter]);
        }
    }


    /// <summary>
    /// 创建初始模型临时方法(存在正确数据后干掉)(假数据)
    /// </summary>
    public static List<int> GetAllEquip()
    {
        VisualCorner cor = ViSealedDB<VisualCorner>.Data(1);
        List<int> item = new List<int>();
        if (cor.Weapon1 != 0)
            item.Add(cor.Weapon1);
        if (cor.SubWeapon1 != 0)
            item.Add(cor.SubWeapon1);
        if (cor.Shoulder != 0)
            item.Add(cor.Shoulder);
        if (cor.Jacket != 0)
            item.Add(cor.Jacket);
        if (cor.Pants != 0)
            item.Add(cor.Pants);

        return item;
    }

    
    /// <summary>
    /// 临时假数据
    /// </summary>
    /// <returns></returns>
    public static int GetFaceId()
    {
        VisualCorner cor = ViSealedDB<VisualCorner>.Data(1);
        return cor.Face[0];
    }
    /// <summary>
    /// 临时假数据
    /// </summary>
    /// <returns></returns>
    public static int GetHairId()
    {
        VisualCorner cor = ViSealedDB<VisualCorner>.Data(1);
        return cor.Hair[0];
    }
}