using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StoryCDModelGroup : StoryCDGroup
{
    protected override void Operate<T>(T t, object obj = null)
    {
        if (t != null && obj  != null)
        {
            StoryCDModelItem item = t as StoryCDModelItem;
            StoryCDModelGroupInfo info = obj as StoryCDModelGroupInfo;
            if (item != null && info != null)
            {
                item.SetInfo(info);
            }
        }
    }
}


[System.Serializable]
public class StoryCDModelGroupInfo
{
    public CharacterType Type;

    public LeaderProfession Profession;

    public Gender Gender;

    public StoryCDModelGroupInfo(CharacterType type)
    {
        Type = type;
    }
}
public enum CharacterType
{
    Undefine,
    Player,
    NPC,
}