using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class ExUITexture_Extend
{
    public static ViConstValue<float> CycleScale = new ViConstValue<float>("CycleScale", 0.75f);
    public static ViConstValue<float> RectScale = new ViConstValue<float>("RectScale", 0.92f);
    public enum IconStyle
    {
        CYCLE,
        RECT,
    }
    public static void LoadIcon(this ExUITexture targetTex, string icon, ItemQualityEnum quality, IconStyle iconStyle)
    {
        float scale = (iconStyle == IconStyle.CYCLE? CycleScale: RectScale);
        ItemQualityStruct itemStruct = ViSealedDB<ItemQualityStruct>.GetData((Int32)quality);
        string qualityName = itemStruct.Icon;
        qualityName = (iconStyle == IconStyle.CYCLE? (qualityName + "_circle") : qualityName);
        targetTex.IsNeedAutoMatertial = false;
        targetTex.IsVisible = false;
        //load icon
        UITextureManager.Instance.Load(icon, (string name, object go) =>
        {
            Texture tex = go as Texture;
            if (tex != null)
            {
                Material mat = new Material(Shader.Find(UIDefine.UI_SHADER_ITEM));
                targetTex.UpdateMaterial(mat);
                targetTex.material.SetTexture("_SencondTex", tex);//icon               
                targetTex.material.SetFloat("_SecondScale", scale);
                targetTex.LoadResName.Add(name);
            }
            //load quality icon

            UITextureManager.Instance.Load(qualityName, (string resName, object texture) =>
            {
                Texture iconText = texture as Texture;
                if (tex != null)
                {
                    targetTex.material.SetTexture("_MainTex", iconText);
                    targetTex.texture = iconText;
                    targetTex.LoadResName.Add(name);
                }
                targetTex.IsVisible = true;
            });
        });
    }
    public static void UnLoadIcon(this ExUITexture targetTex)
    {
        if (targetTex.LoadResName.Count > 0)
        {
            for (int i = 0; i < targetTex.LoadResName.Count; ++i)
            {
                string resName = targetTex.LoadResName[i];
                if (!string.IsNullOrEmpty(resName))
                    UITextureManager.Instance.UnLoad(resName);
            }
            targetTex.LoadResName.Clear();
        }
    }
}
