using UnityEngine;
using System.Collections;

public class StoryCDModelItem : StoryCDItem
{
    [HideInInspector]
    public StoryCDModelGroupInfo Info;
    private Avatar mLeaderAvatar = null;

    public bool IsPlayer
    {
        get
        {
            if (Info == null)
            {
                return false;
            }
            return Info.Type == CharacterType.Player;
        }
    }

    [ContextMenu("Init")]
    public override void Init()
    {
        if (Info == null)
        {
            return;
        }
        switch (Info.Type)
        {
            case CharacterType.Undefine:
                break;
            case CharacterType.Player:
                CreatePlayer();
                break;
            case CharacterType.NPC:
                break;
            default:
                break;
        }
    }

    public override void Clear()
    {

        if (mLeaderAvatar != null)
        {
            mLeaderAvatar.Clear();
            mLeaderAvatar = null;
        }
        Info = null;
    }

    public void SetInfo(StoryCDModelGroupInfo info)
    {
        Info = info;
    }

    private void CreatePlayer()
    {
        if (CellHero.LocalHero.IsNotNull())
        {
            mLeaderAvatar = new Avatar();
            mLeaderAvatar.LoadCallback = (Avatar avatar) =>
            {
                avatar.Root.name = "Player";
                avatar.RootTran.SetParent(transform);
                avatar.RootTran.localPosition = Vector3.zero;
                avatar.RootTran.localScale = Vector3.one;
                avatar.RootTran.eulerAngles = Vector3.zero;
                Layers.SetlayerRecursively(avatar.Root, Layers.Story);
            };
            AvatarCreator.Create(mLeaderAvatar,
                                (byte)CellHero.LocalHero.Property.Info.Value.Gender.Value,
                                (byte)CellHero.LocalHero.Property.Info.Value.HeroClass.Value,
                                1,
                                Player.Instance.Property.Equipments);
            mLeaderAvatar.Root.transform.SetParent(transform);
        }
        else
        {
            int id = 1;
            VisualHeroStruct visualInfo = ViSealedDB<VisualHeroStruct>.Data(id);
            if (visualInfo.ID > 0)
            {
                SimpleAvatarStruct avatarInfo = visualInfo.Avatar.Data;
                mLeaderAvatar = new Avatar();
                mLeaderAvatar.LoadCallback = (Avatar avatar) =>
                {
                    avatar.Root.name = id.ToString();
                    avatar.RootTran.SetParent(transform);
                    avatar.RootTran.localPosition = Vector3.zero;
                    avatar.RootTran.localScale = Vector3.one;
                    avatar.RootTran.eulerAngles = Vector3.zero;
                    Layers.SetlayerRecursively(avatar.Root, Layers.Story);
                };
                AvatarCreator.Create(mLeaderAvatar, avatarInfo.BodyResource.Resource, 1.0f, avatarInfo.PartResource);
                mLeaderAvatar.Root.transform.SetParent(transform);
            }
            else
            {
                UConsole.LogError("CreatePlayer Faild.");
            }
        }
    }
}
