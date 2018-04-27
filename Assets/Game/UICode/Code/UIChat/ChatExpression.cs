using System.Collections.Generic;
using System.Text.RegularExpressions;

/// <summary>
/// 表情相关的设置
/// </summary>
public static class ChatExpression
{
    /// <summary>
    /// 表情key从 10开始，在点击表情时需要用到
    /// </summary>
    public const int AnimKeyStart = 10;

    /// <summary>
    /// 表情前缀，输入表情时会用到
    /// </summary>
    public const string ExpressionPrefix = "#";

    // 对应表情的key  从STMQuadAnimManager获取 
    private static string[] _quadAnimKey =
    {
        "10", "11", "12",
        "13", "14", "15",
        "16", "17", "18",
        "19", "20", "21",
        "22", "23", "24",
        "25", "26", "27",
    };

    // 对应的图片
    static string[] _quadAnimName =
    {
        "pic_face_1", "pic_face_2", "pic_face_3",
        "pic_face_4", "pic_face_5", "pic_face_6",
        "pic_face_7", "pic_face_8", "pic_face_9",
        "pic_face_10", "pic_face_11", "pic_face_12",
        "pic_face_13", "pic_face_14", "pic_face_15",
        "pic_face_16", "pic_face_17", "pic_face_18",
    };

    /// 显示的符号
    private static string[] _mapKey = new string[_quadAnimKey.Length];

    /// <summary>
    /// 加载
    /// </summary>
    public static void Load()
    {
        for (int i = 0; i < _quadAnimKey.Length; i++)
        {
            _mapKey[i] = ExpressionPrefix + _quadAnimKey[i];
        }

        UIAtlasManager.Instance.Load("ExpressionAtlas", LoadAtlasCB);
    }

    /// <summary>
    /// 获取字符中表情的数量
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static int GetExpressionNumber(string str)
    {
        MatchCollection mc = GetMatching(str);
        return mc.Count;
    }

    /// <summary>
    /// 解析最后的显示的内容
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string Parsing(string str)
    {
        if (str == string.Empty) return string.Empty;

        MatchCollection mc = GetMatching(str);
        foreach (var item in mc)
        {
            if (item.ToString().Length > 2) // 匹配出的字符应该是 #xx 最少三位数
                str = str.Replace(item.ToString(),
                    string.Format("<quadAnim={0}>", item.ToString().Substring(1))); //"<quadAnim=1>"
        }

        return str;
    }

    /// <summary>
    /// 获取匹配对象
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    private static MatchCollection GetMatching(string str)
    {
        MatchCollection mc = null;
        string matching = "#(1[0-9]|2[0-7])";
        mc = Regex.Matches(str, matching);
        return mc;
    }

    /// <summary>
    /// 加载后回调
    /// </summary>
    /// <param name="name"></param>
    /// <param name="go"></param>
    private static void LoadAtlasCB(string name, object go)
    {
        if (go == null) return;

        UIAtlas atls = go as UIAtlas;

        if (atls != null)
        {
            for (int i = 0; i < _quadAnimKey.Length; ++i)
            {
                //Debug.Log("key-->" + quadAnimKey[i] + "    value-->" + quadAnimName[i]);
                STMQuadAnimManager.CreateSTMQuadAnim(_quadAnimKey[i], atls, new string[] {_quadAnimName[i]});
            }
        }
    }
}