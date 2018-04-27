using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;
using UnityEngine.UI;
using System.Text;

public class UIUtility
{

    public static Vector3 ScreenToLocalPosition(Transform baseTran, Vector3 pos)
    {
        Vector3 ret = baseTran.parent.InverseTransformPoint(UIManager.Instance.UICamera.ScreenToWorldPoint(pos));
        return new Vector3(ret.x, ret.y, 0);
    }
    public static void SetSprite(ExUISprite sprite, IconData icon)
    {
        if (icon.Atlas != null)
        {
            sprite.Atlas = icon.Atlas;
            sprite.SpriteName = icon.Sprite;
            sprite.material = icon.Atlas.spriteMaterial;
            sprite.gameObject.SetActive(true);
        }
        else
        {
            sprite.gameObject.SetActive(false);
            ViDebuger.Record("SetSprite error["+ icon.AtlasName+", "+icon.Sprite+"]");
        }
    }
    public static void SetSprite(ExCircleSprite sprite, IconData icon)
    {
        if (icon.Atlas != null)
        {
            sprite.Atlas = icon.Atlas;
            sprite.SpriteName = icon.Sprite;
            sprite.material = icon.Atlas.spriteMaterial;
            sprite.gameObject.SetActive(true);
        }
        else
        {
            sprite.gameObject.SetActive(false);
            ViDebuger.Record("SetSprite error[" + icon.AtlasName + ", " + icon.Sprite + "]");
        }
    }
    public static void SetSprite(ExUISprite sprite, string name, string atlasName = "")
    {
        if (!string.IsNullOrEmpty(atlasName))
        {
            UIAtlas atlas = UIAtlasManager.Instance.GetAtlas(atlasName);
            sprite.Atlas = atlas;
            sprite.material = atlas.spriteMaterial;
        }       
        sprite.SpriteName = name;        
    }
    public static void SwitchGray(ExUISprite sprite, bool isGray)
    {
        Color oldCol = sprite.color;
        sprite.color = new Color(oldCol.r, oldCol.g, oldCol.b, 0.0009f);
    }
    public static void SwitchGray(ExUITexture texture, bool isGray)
    {
        Color oldCol = texture.color;
        texture.color = new Color(oldCol.r, oldCol.g, oldCol.b, 1f);
    }
    public static IconData GetUnitIconDataByUintId(UInt64 uintId)
    {
        IconData data = null;
        GameUnit unit = Client.Current.EntityManager.GetEntity<GameUnit>(uintId);
        if (unit != null)
        {
            data = GetIconDataByGameUint(unit);
        }
        return data;
    }
    public static IconData GetUnitIconDataByPackId(UInt32 packId)
    {
        IconData data = null;
        GameUnit unit = Client.Current.EntityManager.GetPackEntity<GameUnit>(packId);
        if (unit != null)
        {
            data = GetIconDataByGameUint(unit);
        }
        return data;
    }
    public static string GetUnitNameByUnitId(UInt64 uintId)
    {
        GameUnit unit = Client.Current.EntityManager.GetEntity<GameUnit>(uintId);
        if (unit != null)
        {
            return GetUnitNameByUnit(unit);
        }

        return "";
    }
    public static string GetUnitNameByPackId(UInt32 packId)
    {
        GameUnit unit = Client.Current.EntityManager.GetPackEntity<GameUnit>(packId);
        if (unit != null)
        {
            return GetUnitNameByUnit(unit);
        }
        return "";
    }
    public static string GetUnitLevelByUnitId(UInt64 uintId)
    {
        GameUnit unit = Client.Current.EntityManager.GetEntity<GameUnit>(uintId);
        if (unit != null)
        {
            return GetUnitLevelByUnit(unit);
        }

        return "";
    }
    public static string GetUnitLevelByPackId(UInt32 packId)
    {
        GameUnit unit = Client.Current.EntityManager.GetPackEntity<GameUnit>(packId);
        if (unit != null)
        {
            return GetUnitLevelByUnit(unit);
        }
        return "";
    }
    public static string GetUnitNameByUnit(GameUnit unit)
    {
        string name = "";
        if (unit is CellNPC)
        {
            CellNPC npcUnit = unit as CellNPC;
            name = npcUnit.VisualInfo.Name;
        }
        else if (unit is CellHero)
        {
            CellHero heroUnit = unit as CellHero;
            name = heroUnit.Property.NameAlias;
        }
        return name;
    }
    public static string GetUnitLevelByUnit(GameUnit unit)
    {
        string level = "";
        if (unit is CellNPC)
        {
            CellNPC npcUnit = unit as CellNPC;
            level = npcUnit.Property.Level.Value.ToString();
        }
        else if (unit is CellHero)
        {
            CellHero heroUnit = unit as CellHero;
            level = heroUnit.Property.Level.Value.ToString();
        }
        return level;
    }
    public static IconData GetIconDataByGameUint(GameUnit unit)
    {
        IconData data = null;
        if (unit is CellNPC)
        {
            CellNPC npcUnit = unit as CellNPC;
            data = IconDataManager.GetIcon(npcUnit.VisualInfo.Hint.Data.Icon);
        }
        else if (unit is CellHero)
        {
            CellHero heroUnit = unit as CellHero;
            data = IconDataManager.GetIcon(heroUnit.VisualInfo.PhotoA);
        }
        return data;
    }
    public static bool IsHostile(GameUnit unit)
    {
        if (CellHero.LocalHeroID == unit.ID) return false;
        return !EntityRelationChecker.IsFriend(CellHero.LocalHero, unit);
    }
    public static Tweener TweenScale(Transform trans, float startScale, float endScale, float time, TweenCallback callBack, bool playForward, int loopCount = 1, LoopType lt = LoopType.Restart, Ease ease = Ease.Unset)
    {
        Vector3 vStart = new Vector3(startScale, startScale, startScale);
        Vector3 vEnd = new Vector3(endScale, endScale, endScale);
        return TweenScale(trans, vStart, vEnd, time, callBack, playForward, loopCount,lt, ease);
    }
    public static Tweener TweenScale(Transform trans, Vector3 startScale, Vector3 endScale, float time,TweenCallback callBack, bool playForward, int loopCount = 1, LoopType lt = LoopType.Restart, Ease ease = Ease.Unset)
    {
        trans.localScale = playForward?startScale: endScale;
        Tweener tween = trans.DOScale(playForward?endScale: startScale, time);
        if(ease != Ease.Unset)
            tween.SetEase(ease);
        tween.SetLoops(loopCount, lt);
        if (callBack != null)
            tween.OnComplete(callBack);
        return tween;
    }
    public static Tweener TweenAlpha(MaskableGraphic g, float startAlpha, float endAlpha, float time, TweenCallback callBack,bool playForward, int loopCount = 1, LoopType lt = LoopType.Restart, Ease ease = Ease.Unset)
    {
        Color sColor = new Color(g.color.r, g.color.g, g.color.b,startAlpha);
        Color eColor = new Color(g.color.r, g.color.g, g.color.b, endAlpha);
        return TweenAlpha(g, sColor, eColor, time, callBack, playForward, loopCount, lt, ease);
    }
    public static Tweener TweenAlpha(MaskableGraphic g, Color startColor, Color endColor, float time, TweenCallback callBack, bool playForward, int loopCount = 1, LoopType lt = LoopType.Restart, Ease ease = Ease.Unset)
    {
        g.color = playForward?startColor:endColor;
        Tweener tween = g.DOColor(playForward?endColor: startColor, time);
        if (ease != Ease.Unset)
            tween.SetEase(ease);
        tween.SetLoops(loopCount, lt);
        if (callBack != null)
            tween.OnComplete(callBack);
        return tween;
    }
    public static string MakeNameBillBoardStr_NPC(string name, string title)
    {
        StringBuilder retStr = new StringBuilder();
        retStr.Append("<a=center><c=ffca86><s=0.7>");
        retStr.Append(name);
        retStr.Append("</s></c></a><br><a=center><c=ffe486><s=0.6>");
        retStr.Append(title);
        retStr.Append("</s></c></a>");
        return retStr.ToString();
    }
    public static string MakeNameBillBoardStr_Hostile(string name, string title)
    {
        StringBuilder retStr = new StringBuilder();
        retStr.Append("<a=center><c=ff433e><s=0.7>");
        retStr.Append(name);
        retStr.Append("</s></c></a><br><a=center><c=ffe486><s=0.6>");
        retStr.Append(title);
        retStr.Append("</s></c></a>");
        return retStr.ToString();
    }
    public static string MakeNameBillBoardStr_Firend(string name, string title)
    {
        StringBuilder retStr = new StringBuilder();
        retStr.Append("<a=center><c=9dff86><s=0.7>");
        retStr.Append(name);
        retStr.Append("</s></c></a><br><a=center><c=ffe486><s=0.6>");
        retStr.Append(title);
        retStr.Append("</s></c></a>");
        return retStr.ToString();
    }
    public static string MakeNameBillBoardStr_Myself(string name, string title)
    {
        StringBuilder retStr = new StringBuilder();
        retStr.Append("<a=center><c=86ffec><s=0.7>");
        retStr.Append(name);
        retStr.Append("</s></c></a><br><a=center><c=ffe486><s=0.6>");
        retStr.Append(title);
        retStr.Append("</s></c></a>");
        return retStr.ToString();
    }
    public static string MakeHitStr(string name)
    {
        StringBuilder retStr = new StringBuilder();
        retStr.Append("<a=center>");
        retStr.Append(name);
        retStr.Append("</a>");
        return retStr.ToString();
    }
    public static void MakeFullScreen(Vector2 panelSize, ExUITexture text, bool isBaseWidth)
    {
        if (isBaseWidth)
        {//以宽度进行适配的界面，当界面高度大于图片高度时，图片进行高度的缩放比适配
            Vector2 textSize = text.Size;
            if (panelSize.y > textSize.y)
            {
                float scale = 1.0f * panelSize.y / textSize.y;
                text.Height = (int)panelSize.y;
                text.Width = (int)(panelSize.x * scale);
            }
            else
                text.SetNativeSize();
        }
        else
        {//以高度进行适配的界面，当界面的宽度大于图片宽度时，图片进行宽度适配
            Vector2 textSize = text.Size;
            if (panelSize.x > textSize.x)
            {
                float scale = 1.0f * panelSize.x / textSize.x;
                text.Height = (int)(panelSize.y * scale);
                text.Width = (int)panelSize.x;
            }
            else
                text.SetNativeSize();
        }
    }
}
