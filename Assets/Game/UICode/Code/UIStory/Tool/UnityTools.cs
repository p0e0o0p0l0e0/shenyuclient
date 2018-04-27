using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System;
using System.Reflection;
using System.ComponentModel;
using System.Globalization;
using UnityEngine.EventSystems;

/// <summary>
/// GameObject工具类
/// </summary>
public static class UnityTools
{
    /// <summary>
    /// 只给GameObject添加一次Component（避免重复添加）
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static T AddComponentOnce<T>(this GameObject obj) where T : UnityEngine.Component
    {
        bool isUnable = false;
        if (!obj.activeSelf)
        { // 如果不是激活的，先激活，挂上以后再反激活
            isUnable = true;
            obj.SetActive(true);
        }

        T comp = obj.GetComponent<T>();
        if (null == comp)
        { // 挂上
            comp = obj.AddComponent<T>();
        }

        // 还原
        if (isUnable)
        {
            obj.SetActive(false);
        }
        return comp;
    }
    public static GameObject LoadGameObject(string path, Transform parent)
    {
        GameObject obj = Resources.Load<GameObject>(path);

        if (obj == null)
        {
            UConsole.Log("load " + path + " faild.");
            return null;
        }
        else
        {
            return Instantiate(obj, parent);
        }
    }

    /// <summary>
    /// UI相关克隆
    /// </summary>
    public static GameObject Instantiate(GameObject original, Transform parent)
    {
        GameObject obj = UnityEngine.Object.Instantiate(original) as GameObject;
        obj.transform.parent = parent;
        obj.transform.localPosition = original.transform.localPosition;
        obj.transform.localScale = original.transform.localScale;
        return obj;
    }
    /// <summary>
    /// UI相关清除节点下非隐藏的Transform
    /// </summary>
    /// <param name="parent"></param>
    public static void ClearItems(Transform parent)
    {
        int count = parent.childCount;
        for (int i = 0; i < count; i++)
        {
            Transform item = parent.transform.GetChild(i);
            if (item.gameObject.activeSelf)
            {
                item.gameObject.SetActive(false);
                GameObject.Destroy(item.gameObject, 0.2f);
            }
        }
    }

    /// <summary>
    /// 判断泛型对象是否是：空的or默认的
    /// </summary>
    /// <param name="v"></param>
    /// <returns></returns>
    public static bool IsValueNullOrDefault<V>(V v)
    {
        if (null == v)
        {
            return true;
        }

        return EqualityComparer<V>.Default.Equals(v, default(V));
    }
    public static bool ConverEmeji(char textValue)
    {
        return (textValue == 0x0) ||
            (textValue == 0x9) ||
            (textValue == 0xA) ||
            (textValue == 0xD) ||
            (textValue == 0x20) && (textValue == 0xD7FF) ||
            (textValue == 0xE000) && (textValue == 0xFFFD) ||
            (textValue == 0x10000) && (textValue == 0x10FFFF);

    }
    /// <summary>
    /// 固定长度下截取字符串（字母和数字占1个长度其它2个长度）
    /// </summary>
    /// <param name="textValue"></param>
    /// <param name="length"></param>
    /// <returns></returns>
    public static string GetLength2TextValue(string textValue, int length)
    {
        int curLength = 0;
        string text = string.Empty;
        if (!string.IsNullOrEmpty(textValue))
        {
            char[] strs = textValue.ToCharArray();
            int sLength = strs.Length;
            for (int i = 0; i < sLength; i++)
            {
                if (curLength < length)
                {
                    //if (Regex.IsMatch(strs[i].ToString(), @"[\u4e00-\u9fbb]+{1}quot"))
                    //if (strs[i]>= 0x4e00 && strs[i] <= 0x9fbb)
                    //if (ConverEmeji(strs[i]))
                    if (strs[i] == ' ')
                        continue;
                    var inCharType = char.GetUnicodeCategory(strs[i]);
                    if (inCharType != UnicodeCategory.OtherLetter)
                        if (inCharType != UnicodeCategory.LowercaseLetter)
                            if (inCharType != UnicodeCategory.DecimalDigitNumber)
                                continue;
                    //if (Regex.IsMatch(strs[i].ToString(), @"^\:[a-z0-9_]+\:$"))
                    if (IsTextLengthEqualOne(strs[i].ToString()))
                    {
                        curLength += 1;
                        text += strs[i];
                    }
                    else
                    {
                        curLength += 2;
                        text += strs[i];
                    }
                }
            }
        }
        return text;
    }

    /// <summary>
    /// 获取当前字符串长度针对角色名字
    /// </summary>
    /// <param name="textValue"></param>
    /// <returns></returns>
    public static int GetTextLength(string textValue)
    {
        int length = 0;
        if (!string.IsNullOrEmpty(textValue))
        {
            char[] strs = textValue.ToCharArray();
            int sLength = strs.Length;
            for (int i = 0; i < sLength; i++)
            {
                if (IsTextLengthEqualOne(strs[i].ToString()))
                {
                    length += 1;
                }
                else
                {
                    length += 2;
                }
            }
        }
        return length;
    }

    /// <summary>
    /// 判断当前字符串中是否存在规定的特殊字符（字母和数字占1个长度其它2个长度）
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public static bool IsNullityText(string text)
    {
        string regx = "[`~!@#$^&*()=|{}':;',\\[\\].<>/?~！@#￥……&*（）&;—|{}【】‘；：”“'。，、？]";
        Regex regExp = new Regex(regx);
        return regExp.IsMatch(text);
    }

    /// <summary>
    /// 判断是否是中英文或数字（字母和数字占1个长度其它2个长度）
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public static bool IsTextLengthEqualOne(string text)
    {
        Regex regex = new Regex(@"^[A-Za-z0-9]+$");
        return regex.IsMatch(text);
    }

    /// <summary>
    /// 拆分字符串
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public static List<string> GetText2ListStr(string text)
    {
        List<string> list = new List<string>();
        string str = text;
        int length = text.Length;
        while (length > 0)
        {
            char[] strs = str.ToCharArray();
            string value = string.Empty;
            for (int i = 0; i < length; i++)
            {
                value += strs[i].ToString();
                list.Add(value);
            }
            length--;
            str = str.Substring(1, length);
        }
        return list;
    }

    /// <summary>
    /// 打乱排序规则
    /// </summary>
    public static List<T> RandomSort<T>(List<T> list)
    {
        if (list == null)
            return new List<T>();

        List<T> newList = new List<T>();
        int flag = 0;
        T t;

        while (list.Count > 0)
        {
            flag = UnityEngine.Random.Range(0, list.Count);
            t = list[flag];
            newList.Add(t);
            list.Remove(t);
        }
        return newList;
    }

    /// <summary>
    /// 获取枚举描述特性值
    /// </summary>
    /// <typeparam name="TEnum"></typeparam>
    /// <param name="enumerationValue">枚举值</param>
    /// <returns>枚举值的描述/returns>
    public static string GetDescription<TEnum>(this TEnum enumerationValue)
       where TEnum : struct, IComparable, IFormattable, IConvertible
    {
        Type type = enumerationValue.GetType();
        if (!type.IsEnum)
        {
            throw new ArgumentException("EnumerationValue必须是一个枚举值", "enumerationValue");
        }

        //使用反射获取该枚举的成员信息
        MemberInfo[] memberInfo = type.GetMember(enumerationValue.ToString());
        if (memberInfo != null && memberInfo.Length > 0)
        {
            object[] attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attrs != null && attrs.Length > 0)
            {
                //返回枚举值得描述信息
                return ((DescriptionAttribute)attrs[0]).Description;
            }
        }
        //如果没有描述特性的值，返回该枚举值得字符串形式
        return enumerationValue.ToString();
    }

    static Keyframe[] m_keys = new Keyframe[]
    {
            new Keyframe(0f, 0, 0f, 1f),
            new Keyframe(0.6398076f, 0.7669951f, 1.468463f, 1.468463f),
            new Keyframe(0.8078576f, 0.9514414f, 0.3176422f, 0.3176422f),
            new Keyframe(1, 1, 1, 0),
            //new Keyframe(0.9625f, 0.89375f, -0.6545443f, -0.6545443f),
    };
    /// <summary>
    /// 返回一个AnimationCurve
    /// </summary>
    /// <returns></returns>
    public static AnimationCurve GetPopCurve()
    {
        return new AnimationCurve(m_keys);
    }

    public struct RendererParams
    {
        public float HideAlpha;
        public Color LineColor;
    }

    public readonly static Color DefaultLineColor = new Color(11f / 255f, 11f / 255f, 11f / 255f, 255f);
    public readonly static Color DefaultTransparentLineColor = new Color(11f / 255f, 11f / 255f, 11f / 255f, 11f / 255f);
    readonly static int SHADER_HIDEALPHA_PROPERTY = Shader.PropertyToID("_HideAlpha");
    readonly static int SHADER_OUTLINE_PROPERTY = Shader.PropertyToID("_LineColor");

    /// <summary>
    /// 由于不确定所有模型的初始配置是否一致,最稳妥方式使用如下代码
    /// 隐身时调用var cache = SetModelTransparent(target, 0, DefaultTransparentLineColor);
    /// 保存返回的对象,取消隐身时
    /// SetModelTransparent(target, cache.HideAlpha, cache.LineColor);
    /// 如果所有模型的初始值都是alpha=1,linecolor=DefaultLineColor
    /// 则可隐身时调用SetModelTransparent(target, 0, DefaultTransparentLineColor);
    /// 取消隐身时调用SetModelTransparent(target, 1, DefaultLineColor);
    /// 不需要保存还原参数
    /// </summary>
    /// <param name="renderer">模型的SkinnedMeshRenderer对象</param>
    /// <param name="hideAlpha"></param>
    /// <param name="lineColor">此参数可以调整隐身对象的显示效果,可以不同角色配置不同隐身参数</param>
    /// <returns></returns>
    public static RendererParams SetModelTransparent(Renderer renderer, float hideAlpha, Color lineColor, out bool isOk)
    {
        isOk = false;
        RendererParams ret = new RendererParams();

        //lxg 对翅膀特殊处理  翅膀会隐藏后显示
        if (renderer == null)
        {
            isOk = true;
            return ret;
        }

        if (renderer.material.HasProperty(SHADER_OUTLINE_PROPERTY))
        {
            ret.LineColor = renderer.material.GetColor(SHADER_OUTLINE_PROPERTY);
            renderer.material.SetColor(SHADER_OUTLINE_PROPERTY, lineColor);
        }
        if (renderer.material.HasProperty(SHADER_HIDEALPHA_PROPERTY))
        {
            isOk = true;
            ret.HideAlpha = renderer.material.GetFloat(SHADER_HIDEALPHA_PROPERTY);
            renderer.material.SetFloat(SHADER_HIDEALPHA_PROPERTY, hideAlpha);
        }
        return ret;
    }
    public static bool IsClickUI()
    {
        Vector3 screenPosition;
        RaycastHit hit;
        Ray ray;
        bool cast = false;
#if ((UNITY_ANDROID || UNITY_IOS || UNITY_WINRT || UNITY_BLACKBERRY) && !UNITY_EDITOR)
        int count = Input.touchCount;
        for (int i = 0; i < count; i++)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Ended)
            {
                screenPosition = Input.GetTouch(i).position;
                ray = UICamera.currentCamera.ScreenPointToRay(screenPosition);
                cast |= Physics.Raycast(ray, out hit);
                cast |=  EventSystem.current == null ? false : EventSystem.current.IsPointerOverGameObject(Input.GetTouch(i).fingerId);
            }
        }
#else
        screenPosition = Input.mousePosition;
        //NGUI
        ray = UICamera.currentCamera.ScreenPointToRay(screenPosition);
        int layer = LayerMask.GetMask("UI");
        cast = Physics.Raycast(ray, out hit, 100, layer);
        //UGUI
        cast |= EventSystem.current == null ? false : EventSystem.current.IsPointerOverGameObject();
#endif
        return cast;
    }
    public static ViVector3 ToViV3(this Vector3 v3)
    {
        return new ViVector3(v3.x, v3.z, v3.y);
    }
    public static Vector3 ToV3(this ViVector3 viv3)
    {
        return new Vector3(viv3.x, viv3.z, viv3.y);
    }
    public static Vector3 ToV3(this ViVector3Struct viv3s)
    {
        return new Vector3(viv3s.X * 0.01f, viv3s.Z * 0.01f, viv3s.Y * 0.01f);
    }
    public static bool IsNull<T>(this T t)
    {
        return t == null;
    }
    public static bool IsNotNull<T>(this T t)
    {
        return !IsNull<T>(t);
    }
    public static bool IsTrue(this ViEnum32<BoolValue> bv)
    {
        return bv == 1;
    }
    public static bool IsFalse(this ViEnum32<BoolValue> bv)
    {
        return !IsTrue(bv);
    }
    public static bool IsNullOrEmpty(this string str)
    {
        return string.IsNullOrEmpty(str);
    }
    public static bool IsNotNullOrEmpty(this string str)
    {
        return !IsNullOrEmpty(str);
    }
    public static string StringColorFormat(string data, string color16)
    {
        return string.Format("<color=#{0}>{1}</color>", color16, data);
    }
    public static Color ToColor(this string colorRGBA)
    {
        if (colorRGBA.StartsWith("#"))
            colorRGBA = colorRGBA.Replace("#", string.Empty);
        var v = int.Parse(colorRGBA, System.Globalization.NumberStyles.HexNumber);
        return new Color(((v >> 24) & 255) / 255f, ((v >> 16) & 255) / 255f, ((v >> 8) & 255) / 255f, ((v >> 0) & 255) / 255f);
    }

    public static float ParabolaLerp(ViVector3 startPos, ViVector3 destPos, int count, float high, float duration, ref List<ViVector3> posList)
    {
        if (count <= 1 || duration == 0)
        {
            posList.Add(destPos);
            return float.MaxValue;
        }
        float g = 2 * high / (duration * duration);

        if (startPos.z > destPos.z)
        {
            for (int i = 0; i < count; i++)
            {
                ViVector3 v3 = startPos + (destPos - startPos) * (i + 1) / count;
                float t = duration * (i + 1) / count;
                v3.z = startPos.z - 0.5f * g * t * t;
                posList.Add(v3);
                UConsole.Log("down:" + i + "," + v3.z + "," + 0.5f * g * t * t);
            }
        }
        else if (startPos.z < destPos.z)
        {
            for (int i = 0; i < count; i++)
            {
                ViVector3 v3 = startPos + (destPos - startPos) * (i + 1) / count;
                float t = duration * (count - i - 1) / count;
                v3.z = destPos.z - 0.5f * g * t * t;
                posList.Add(v3);
                UConsole.Log("up:" + i + "," + v3.z + "," + 0.5f * g * t * t);
            }
        }
        else
        {
            LineLerp(startPos, destPos, count, ref posList);
        }
        return g;
    }

    public static void LineLerp(ViVector3 startPos, ViVector3 destPos, int count, ref List<ViVector3> posList)
    {
        if (count <= 1)
        {
            posList.Add(destPos);
            return;
        }
        for (int i = 0; i < count; i++)
        {
            ViVector3 v3 = startPos + (destPos - startPos) * (i + 1) / count;
            posList.Add(v3);
        }
    }
}
