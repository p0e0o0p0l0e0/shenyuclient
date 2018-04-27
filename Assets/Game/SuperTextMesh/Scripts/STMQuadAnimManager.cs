using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STMQuadAnimManager:MonoBehaviour
{
    public static Dictionary<string, STMQuadAnimData> QuadAnimDatas = new Dictionary<string, STMQuadAnimData>();

    public static STMQuadAnimData CreateSTMQuadAnim(string key, UIAtlas atlas, string[] sprites, float delta = 0f)
    {
        if (!QuadAnimDatas.ContainsKey(key) && atlas != null)
        {
            STMQuadAnimData newAnimData = new STMQuadAnimData();
            newAnimData.CreateAnim(atlas, sprites, delta);
            QuadAnimDatas.Add(key, newAnimData);
            return newAnimData;
        }
        return null;
    }
    public static STMQuadAnimData GetSTMQuadAnim(string key)
    {
        STMQuadAnimData stmQuadAnimData = null;
        if (!QuadAnimDatas.TryGetValue(key, out stmQuadAnimData))
            ViDebuger.Warning("GetSTMQuadAnim " + key + " failed");
        return stmQuadAnimData;
    }
    public static void DeleteSTMQuadAnim(string key)
    {
        STMQuadAnimData stmQuadAnimData = null;
        if (QuadAnimDatas.TryGetValue(key, out stmQuadAnimData))
            stmQuadAnimData.DeleteAnim();
        QuadAnimDatas.Remove(key);
    }
    void Update()
    {
        if (QuadAnimDatas.Count > 0)
        {
            HashSet<SuperTextMesh> rebuildSTM = null;
            foreach (KeyValuePair<string, STMQuadAnimData> kvp in QuadAnimDatas)
            {
                bool isNeedRebuild = kvp.Value.UpdateSTMQuadData(Time.deltaTime);
                if (isNeedRebuild && kvp.Value.Owner != null)
                {//可能非常消耗CPU
                    if (rebuildSTM == null)
                        rebuildSTM = new HashSet<SuperTextMesh>();
                    if (!rebuildSTM.Contains(kvp.Value.Owner))
                        rebuildSTM.Add(kvp.Value.Owner);
                }
            }
            if (rebuildSTM != null && rebuildSTM.Count > 0)
            {
                foreach (SuperTextMesh stm in rebuildSTM)
                    stm.Rebuild();
            }
        }
    }
}
