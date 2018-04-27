using UnityEngine;
using UnityEditor;
using System;

[CustomEditor(typeof(StoryCDModelItem))]
public class StoryCDModelItemInspector : Editor
{
    public static string[] TypeMenu = {"未定义","玩家","剧情人物" };
    //private string[] professionMenu = { "牧师", "战士", "弓手", "盗贼", "法师", "骑士" };
    //private string[] genderMenu = { "男性", "女性" };

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        serializedObject.Update();
        
        StoryCDModelItem item = base.serializedObject.targetObject as StoryCDModelItem;

        item.Info.Type = (CharacterType)EditorGUILayout.Popup("人物类型:", (int)item.Info.Type, TypeMenu);

        //switch (item.Info.Type)
        //{
        //    case CharacterType.Undefine:
        //        break;
        //    case CharacterType.Player:
        //        {
        //            item.Info.Profession = (LeaderProfession)EditorGUILayout.Popup("人物职业:", (int)item.Info.Profession, professionMenu);

        //            item.Info.Gender = (Gender)EditorGUILayout.Popup("人物性别:", (int)item.Info.Gender, genderMenu);
        //        }
        //        break;
        //    case CharacterType.NPC:
        //        break;
        //    default:
        //        break;
        //}

        serializedObject.ApplyModifiedProperties();
    }
}
