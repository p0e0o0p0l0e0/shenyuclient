using UnityEngine;
using System.Collections.Generic;
using System;

public class StoryCharacterFactory 
{
    public static Dictionary<LocalBirthInfo, IStoryCharacter> StoryCharacterDict { get { return storyCharacterDict; } }
    private static Dictionary<LocalBirthInfo, IStoryCharacter> storyCharacterDict = new Dictionary<LocalBirthInfo, IStoryCharacter>();
    public static Dictionary<ulong, FollowCharacter> CharacterBubblingDict { get { return characterBubblingDict; } }
    private static Dictionary<ulong, FollowCharacter> characterBubblingDict = new Dictionary<ulong, FollowCharacter>();

    private static IStoryCharacter PlayerCharacter = null;
    private static float HightOffset = 3.5f;
    private static int Layer;
    private static Camera Cam = null;

    /// <summary>
    /// 创建本地主角
    /// </summary>
    /// <returns></returns>
    public static IStoryCharacter Generate(Vector3 position, Vector3 angle)
    {
        if (PlayerCharacter != null)
        {
            return PlayerCharacter;
        }
        VisualHeroStruct visualInfo = ViSealedDB<VisualHeroStruct>.Data(CellHero.LocalHero.LogicInfo.ID);
        SimpleAvatarStruct avatarInfo = visualInfo.Avatar.Data;
        LocalSpaceEntity entity = new LocalSpaceEntity();
        entity.VisualBody.LoadCallback = (Avatar avatar) =>
        {
            entity.ID = CellHero.LocalHeroID;
            entity.Name = "Local_" + CellHero.LocalHero.LogicInfo.ID;
            entity.SetNavigator(GameSpace.ActiveInstance.Navigator);
            entity.SetScale(CellHero.LocalHero.Scale.Value);
            //entity.SetPos(position.Equals(Vector3.zero) ? CellHero.LocalHero.Position : position.ToViV3());
            entity.transform.position = position;
            entity.transform.localScale = Vector3.one * CellHero.LocalHero.Scale.Value;
            if (!angle.Equals(Vector3.zero))
                entity.transform.eulerAngles = angle;
            else
                entity.SetYaw(CellHero.LocalHero.Yaw);
            entity.IsReinforcements = false;
            entity.Start(visualInfo.Avatar);
        };
        AvatarCreator.Create(entity.VisualBody, avatarInfo.BodyResource.Resource, 1.0f, avatarInfo.PartResource);
        PlayerCharacter = entity;
        //TODO zlj 得穿上现在的装备
        return entity;
    }
    public static IStoryCharacter GetStoryCharacter()
    {
        return PlayerCharacter;
    }
    public static void DestoryStoryCharacter()
    {
        if (PlayerCharacter != null)
        {
            (PlayerCharacter as LocalSpaceEntity).End();
            GameObject.DestroyImmediate(PlayerCharacter.gameObject);
            PlayerCharacter = null;
        }
    }
    public static IStoryCharacter Generate(StoryRoleData data)
    {
        if (data == null)
        {
            UConsole.LogError("  Generate   data == null");
            return null;
        }
        return Generate(data.npcBirthPositionID,
                        data.npcBirthPositionIndex,
                        data.position,
                        data.angle,
                        data.controlType == StoryRoleData.ROLETYPE.SceneNPC);
    }
    /// <summary>
    /// 创建NPC和援军
    /// </summary>
    /// <param name="birthPosID"></param>
    /// <param name="birthPosIndex"></param>
    /// <param name="isReinforcements">是否是援军</param>
    /// <returns></returns>
    public static IStoryCharacter Generate(Int32 birthPosID, Int32 birthPosIndex, Vector3 position,Vector3 angle,bool isReinforcements = false)
    {
        if (birthPosIndex <= 0)
        {
            UConsole.LogError("  Generate   birthPosIndex <= 0");
            return null;
        }
        IStoryCharacter character = GetStoryCharacter(birthPosID,birthPosIndex);
        if (character != null)
        {
            LocalSpaceEntity localEntity = character as LocalSpaceEntity;
            if (isReinforcements && !localEntity.IsReinforcements)
            {
                localEntity.IsReinforcements = true;
                localEntity.ResetAI();
            }
            else if (!isReinforcements && localEntity.IsReinforcements)
            {
                localEntity.IsReinforcements = false;
                localEntity.ResetAI();
            }
            return character;
        }
        NPCBirthPositionStruct npcPosConfig = ViSealedDB<NPCBirthPositionStruct>.Data(birthPosID);
        if (npcPosConfig == null)
        {
            return null;
        }
        VisualNPCStruct visNpcConfig = ViSealedDB<VisualNPCStruct>.Data(npcPosConfig.NPC);
        if (visNpcConfig == null || visNpcConfig.Avatar.PData == null)
        {
            return null;
        }
        LocalSpaceEntity entity = new LocalSpaceEntity();
        entity.ID = (ulong)(birthPosID * 100 + birthPosIndex);
        entity.BirthID = birthPosID;
        entity.Name = "Local_" + birthPosID + "_" + birthPosIndex;
        entity.SetScale(visNpcConfig.GetBodyScale());
        entity.SetPos(position.Equals(Vector3.zero) ? npcPosConfig.Position : position.ToViV3());
        if (!angle.Equals(Vector3.zero))
        {
            entity.SetYaw(angle.y * 3.14f / 180);
        }
        else
            entity.SetYaw(npcPosConfig.Yaw / 100f);

        entity.SetVisual(visNpcConfig.Avatar.PData.BodyResource.Resource, visNpcConfig.Avatar.PData.PartResource);
        entity.SetNavigator(GameSpace.ActiveInstance.Navigator);
        entity.IsReinforcements = isReinforcements;
        entity.FollowDistance = visNpcConfig.FollowDistance;
        entity.Start(visNpcConfig.Avatar, npcPosConfig.NPC);
        storyCharacterDict.Add(new LocalBirthInfo() { BirthPosID = birthPosID, BirthPosIndex = birthPosIndex },entity);
        return entity;
    }
    public static LocalBirthInfo GetStoryCharacterInfo(Int32 birthPosID, Int32 birthPosIndex)
    {
        foreach (KeyValuePair<LocalBirthInfo, IStoryCharacter> item in storyCharacterDict)
        {
            if (item.Key.IsEqual(birthPosID, birthPosIndex))
                return item.Key;
        }
        return null;
    }
    public static IStoryCharacter GetStoryCharacter(Int32 birthPosID, Int32 birthPosIndex)
    {
        foreach (KeyValuePair<LocalBirthInfo, IStoryCharacter> item in storyCharacterDict)
        {
            if (item.Key.IsEqual(birthPosID, birthPosIndex))
                return item.Value;
        }
        return null;
    }
    public static void HideStoryCharacter(Int32 birthPosID, Int32 birthPosIndex)
    {
        LocalBirthInfo info = GetStoryCharacterInfo(birthPosID, birthPosIndex);
        if (info != null)
        {
            IStoryCharacter character = storyCharacterDict[info];
            character.gameObject.SetActive(false);
        }
    }
    public static void DestoryStoryCharacter(Int32 birthPosID, Int32 birthPosIndex)
    {
        LocalBirthInfo info = GetStoryCharacterInfo(birthPosID, birthPosIndex);
        if (info != null)
        {
            IStoryCharacter character = storyCharacterDict[info];
            (character as LocalSpaceEntity).End();
            GameObject.DestroyImmediate(character.gameObject);
            storyCharacterDict.Remove(info);
            character = null;
        }
    }
    public static void ClearStoryCharacter()
    {
        foreach (KeyValuePair<LocalBirthInfo, IStoryCharacter> item in storyCharacterDict)
        {
            IStoryCharacter character = item.Value;
            (character as LocalSpaceEntity).End();
            GameObject.Destroy(character.gameObject);
            character = null;
        }
        storyCharacterDict.Clear();
        DestoryStoryCharacter();
    }
    public static GameObject CreateCharacterBubbling(ulong id,Transform trans)
    {
        if (characterBubblingDict.ContainsKey(id) && characterBubblingDict[id] != null)
        {
            return characterBubblingDict[id].gameObject;
        }
        else
        {
            GameObject bubbling = StoryManager.GetInstance.UIController.CreateBubblingChild();
            if (bubbling != null)
            {
                FollowCharacter follow = bubbling.AddComponent<FollowCharacter>();
                follow.Init(id, StoryManager.GetInstance.GetMainCamera(), StoryManager.GetInstance.GetUICamera(), trans);
                follow.SetLayer(Layer, HightOffset);
                follow.SetWorldCamera(Cam);
                if (characterBubblingDict.ContainsKey(id))
                    characterBubblingDict[id] = follow;
                else
                    characterBubblingDict.Add(id, follow);
            }
            return bubbling;
        }
    }
    public static void DestroyCharacterBubbling(ulong id)
    {
        if (characterBubblingDict.ContainsKey(id))
        {
            if (characterBubblingDict[id] != null)
                GameObject.DestroyImmediate(characterBubblingDict[id].gameObject);
            characterBubblingDict.Remove(id);
        }
    }
    public static void DestroyCharacterBubbling(IStoryCharacter character)
    {
        UConsole.Log("DestroyCharacterBubbling:" + character.ID);
        if (characterBubblingDict.ContainsKey(character.ID))
        {
            GameObject.DestroyImmediate(character.GetDialogText());
            characterBubblingDict.Remove(character.ID);
        }
    }
    public static void ChangeCharacterBubblingLayer(int layer,Camera cam,float highOffset)
    {
        HightOffset = highOffset;
        Layer = layer;
        Cam = cam;
        foreach (KeyValuePair<ulong, FollowCharacter> item in characterBubblingDict)
        {
            if (item.Value.IsNull())
                continue;
            item.Value.SetLayer(layer, highOffset);
            item.Value.SetWorldCamera(cam);
        }
    }
    public class LocalBirthInfo
    {
        public Int32 BirthPosID;
        public Int32 BirthPosIndex;

        public bool IsEqual(Int32 birthPosID, Int32 birthPosIndex)
        {
            return BirthPosID == birthPosID && BirthPosIndex == birthPosIndex;
        }
    }
}