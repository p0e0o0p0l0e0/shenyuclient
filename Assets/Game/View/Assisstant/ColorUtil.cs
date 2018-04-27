using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class ColorUtil
{
	public static string Format(string text, string color)
	{
		return ColorUtil.FLAG_L + color + FLAG_R + text + FLAG_END;
	}

	#region Color Flags
	/// <summary>
	/// Color Flag: [
	/// </summary>
	public static readonly string FLAG_L = "[";
	/// <summary>
	/// Color Flag: ]
	/// </summary>
	public static readonly string FLAG_R = "]";
	/// <summary>
	/// Color Flag: [-]
	/// </summary>
	public static readonly string FLAG_END = "[-]";
	#endregion

	/// <summary>
	/// WITHE
	/// </summary>
	public static readonly string WITHE = "FFFFFF";
	public static readonly string WITHE_FLAG = FLAG_L + WITHE + FLAG_R;


	/// <summary>
	/// 红色: ff7f7f
	/// </summary>
	public static readonly string RED = "ff7f7f";
	public static readonly string RED_FLAG = FLAG_L + RED + FLAG_R;
	/// <summary>
	/// 红色: ff6e6e
	/// </summary>
	public static readonly string RED2 = "ff6e6e";
	public static readonly string RED2_FLAG = FLAG_L + RED2 + FLAG_R;
	/// <summary>
	/// 绿色: 49de46
	/// </summary>
	public static readonly string GREEN = "49de46";
	public static readonly string GREEN_FLAG = FLAG_L + GREEN + FLAG_R;
	/// <summary>
	/// 黄色 : FFFF00
	/// </summary>
	public static readonly string YELLOW = "FFFF00";
	public static readonly string YELLOW_FLAG = FLAG_L + YELLOW + FLAG_R;
	/// <summary>
	/// 灰色 : 808080
	/// </summary>
	public static readonly string GREY = "808080";
	public static readonly string GREY_FLAG = FLAG_L + GREY + FLAG_R;

	/// <summary>
	/// 橙: F0B140
	/// </summary>
	public static readonly string ORANGE = "F0B140";
	public static readonly string ORANGE_FLAG = FLAG_L + ORANGE + FLAG_R;

	/// <summary>
	/// 蓝色: 91FBFF
	/// </summary>
	public static readonly string BLUE = "91FBFF";
	public static readonly string BLUE_FLAG = FLAG_L + BLUE + FLAG_R;
	/// <summary>
	/// 蓝色: 72d2ff
	/// </summary>
	public static readonly string BLUE2 = "72d2ff";
	public static readonly string BLUE2_FLAG = FLAG_L + BLUE2 + FLAG_R;

	//++++++++++++++++++++++++++++++++++++++++
	public static readonly string MASTER = "[FF8080]";
	public static readonly string SERVANT = "[60EDFB]";

	public static readonly Color BlueHP = new Color(152f / 255f, 242f / 255f, 1f);
}
