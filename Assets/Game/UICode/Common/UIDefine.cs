using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDefine
{
    public static Vector2 DESIGN_RESOLUTION = new Vector2(1334, 750);
    public const string UI_SHADER_NORMAL = "Unlit/Transparent Colored";
    public const string UI_SHADER_ITEM = "Unlit/ItemShader";
    public const int UI_BASE_RENDER_QUEUE = 3000;
    public const int UI_INVISIBLE_LAYER = (int)UnityLayer.UI_Invisible;
    public const int UI_VISIBLE_LAYER = (int)UnityLayer.UI;
}
public class UIGoalDefine
{
    public static string[] COLORARRAY = { COLOR_CANRECIVER , COLOR_UNDERWAY , COLOR_LEVELBG };
    private const string COLOR_CANRECIVER = "#DCFFB6FF";
    private const string COLOR_UNDERWAY = "#FFD6BFFF";
    private const string COLOR_LEVELBG = "#FFF79BFF";
    public static string[] BTNARRAY = { BTN_CANRECIVER, BTN_UNDERWAY, BTN_LEVELBG };
    private const string BTN_CANRECIVER = "btn_canreceive";
    private const string BTN_UNDERWAY = "btn_underway";
    private const string BTN_LEVELBG = "btn_levelbg";

    public static string[] ICONARRAY = { ICON_THREAD, ICON_ADVENTURE, ICON_ADVENTURE02 };
    private const string ICON_THREAD = "icon_thread";
    private const string ICON_ADVENTURE = "icon_adventure";
    private const string ICON_ADVENTURE02 = "icon_adventure02";

    public static string[] BGARRAY = { BG_THREAD, BG_ADVENTURE, BG_ADVENTURE02 };
    private const string BG_THREAD = "bg_thread";
    private const string BG_ADVENTURE = "bg_adventure";
    private const string BG_ADVENTURE02 = "bg_adventure02";

    public const string EFFECT_COMPLETESMALLGOAL = "UI_effect_renwuwancheng";
    public const string EFFECT_COMPLETEBIGGOAL = "UI_effect_renwuwanc_flash";
}
public enum UIRES_ACTION
{
    UNLOAD  = 0X01,//未加载
    WILLLOADING = 0X02,//将要被加载
    LOADING = 0X04,//加载中
    LOADED = 0X08,//已加载
    WILLSHOW = 0X10,//将要显示
    WILLHIDE = 0X20,//将要隐藏
    SHOW = 0X40,
    HIDE = 0X80,
    WILLDESTROY = 0X100,//将来被删除
}
public enum HP_Type
{
    Unhostile,
    Hostile,
}