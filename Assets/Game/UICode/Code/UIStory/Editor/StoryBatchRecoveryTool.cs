using UnityEngine;
using UnityEditor;
using System.IO;

/********************************************************************
	created:	2017/10/13
	created:	13:10:2017   12:00
	filename: 	D:\Project\trunk\Program\Program\Client\Assets\Game\UICode\Code\UIStory\Editor\StoryBatchRecoveryTool.cs
	file path:	D:\Project\trunk\Program\Program\Client\Assets\Game\UICode\Code\UIStory\Editor
	file base:	StoryBatchRecoveryTool
	file ext:	cs
	author:		zlj
	
	purpose:	
*********************************************************************/

public class StoryBatchRecoveryTool  : Editor
{
    //StoryControl.cs.meta
    //BattleStoryData.cs.meta
    //StoryCondition.cs.meta,
    //StoryFunttion.cs.meta,
    //StoryFunBackMusic.cs.meta,
    //StoryFunDisplacement.cs.meta,
    //StoryFunGameSpeed.cs.meta,
    //StoryConditionData.cs.meta,
    //StoryFunctionData.cs.meta
    private static string[] OldGUID = {
        "101a7bf8e5db21447beac6d387e7faa3",
        "3d7453dfc1bf8d4408fe1be109999c05",
        "3bfa1eadb3d014a4eafc44e22367cb36",
        "a3cd14605d520c84997e03db3a955865",
        "a60e86f664d57dd4d9160dfd56f36352",
        "bc23d8ddcd599db4a93c19ddb90b08b9",
        "0e9a60d1aedadb141b7ebc395debb249",
        "0bd0963dd85d49247aca8d6bde68a604",
        "ec8accee6ad38084ea4692c3fd164439"};
    private static string[] NewGUID = {
        "de96457805f60fc41a67bac6529c4f6b",
        "680b4175f84caad46a31779f042759c5",
        "fff5bbadbd15ee3429a20d3d14b91b16",
        "54d2b6b4d94552a4cae1b6eff55999cf",
        "74331dc7a26e946469034d499e085da5",
        "28af626bdc4cd50438d0a95e1c18be5e",
        "d3de69bbde8fc684f802f31d43e78eef",
        "4d3b47fb538e62044808c97ab2d93b86",
        "fd244fe129b00874ba0d507f5eeb7d0c" };

    [MenuItem("Tools/StoryTool/BatchRecovery", false, 210)]
    public static void BatchRecovery()
    {
         Object[] storyObjs = Selection.objects;

        if (storyObjs != null && storyObjs.Length > 0)
        {
            string path = string.Empty;
            string context = string.Empty;
            for (int i = 0; i < storyObjs.Length; i++)
            {
                path = AssetDatabase.GetAssetPath(storyObjs[i]);
                context = File.ReadAllText(path);
                for (int j = 0; j < OldGUID.Length; j++)
                    context = context.Replace(OldGUID[j], NewGUID[j]);
                File.WriteAllText(path,context);
            }
        }
        AssetDatabase.SaveAssets();
        UConsole.Log("BatchRecovery end");
    }
}
