using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

/********************************************************************
	created:	2017/10/11
	created:	11:10:2017   10:23
	filename: 	D:\Project\trunk\Program\Program\Client\Assets\Game\UICode\Common\UICommonFuntion.cs
	file path:	D:\Project\trunk\Program\Program\Client\Assets\Game\UICode\Common
	file base:	UICommonFuntion
	file ext:	cs
	author:		zlj
	
	purpose:	
*********************************************************************/
/// <summary>
/// UI公用功能类
/// </summary>
public static class UICommonFuntion
{
    public static void SetTextContent(this Text text, string content)
    {
        if (text != null)
            text.text = content;
    }
    public static void SetTextContent(this ExText text, string content)
    {
        if (text != null)
            text.text = content;
    }
    public static void SetTextContent (this Text text, object content)
    {
        text.SetTextContent(content.ToString());
	}
    public static void SetImageSprite(this Image image, Sprite sprite)
    {
        if (image != null)
            image.sprite = sprite;
    }
    public static void SetExUISprite(this ExUISprite image, string spriteName)
    {
        if (image != null)
            image.SpriteName = spriteName;
    }
    public static void SetExUISpriteAtlas(this ExUISprite image, UIAtlas atlas)
    {
        if (image != null)
            image.Atlas = atlas;
    }
    public static void SetExUISpriteAtlasAndSprite(this ExUISprite image, IconData iconData)
    {
        if(image!=null)
        {
            image.Atlas = iconData.Atlas;
            image.SpriteName = iconData.Sprite;
        }
    }
    public static void SetExUISpriteAtlasAndSprite(this ExCircleSprite image, IconData iconData)
    {
        if (image != null)
        {
            image.Atlas = iconData.Atlas;
            image.SpriteName = iconData.Sprite;
        }
    }
    public static void SetRawImageTexture(this RawImage rawImage, Texture tex)
    {
        if (rawImage != null)
            rawImage.texture = tex; 
    }
    public static void SetImageFillAmount(this Image image,float amount)
    {
        if (image != null)
            image.fillAmount = amount;
    }
    public static void SetRectTransformHigh(this RectTransform rect,float high)
    {
        if (rect != null)
            rect.sizeDelta = new Vector2(rect.sizeDelta.x,high);
    }
    public static void AddButtonListener(this ExUIButton btn, UnityAction callBack)
    {
        if (btn != null)
            btn.onClick.AddListener(callBack);
    }
    public static void RemoveButtonListener(this ExUIButton btn, UnityAction callBack)
    {
        if (btn != null)
            btn.onClick.RemoveListener(callBack);
    }
    public static void RemoveButtonAllListener(this ExUIButton btn)
    {
        if (btn != null)
            btn.onClick.RemoveAllListeners();
    }
    public static T GetComponentPro<T>(this Transform trans, string path) where T : Component
    {
        if (trans != null)
        {
            Transform childTrans = trans.Find(path);
            if (childTrans != null)
                return childTrans.GetComponent<T>();
        }
        return null;
    }
    public static T GetComponentPro<T>(this GameObject obj, string path) where T : Component
    {
        if (obj != null)
        {
            Transform childTrans = obj.transform.Find(path);
            if (childTrans != null)
                return childTrans.GetComponent<T>();
        }
        return null;
    }
    public static GameObject Instantiate(this GameObject obj,Transform parent = null,string name = null)
    {
        if (obj != null)
        {
            GameObject go = GameObject.Instantiate(obj);
            go.name = string.IsNullOrEmpty(name)?  obj.name : name;
            go.transform.SetParent(parent);
            go.transform.localPosition = Vector3.zero;
            go.transform.eulerAngles = Vector3.zero;
            go.transform.localScale = Vector3.one;
            return go;
        }
        return null;
    }
    public static void SetActive<T>(this T t,bool enable) where T : Component
    {
        if (t != null)
            t.gameObject.SetActive(enable);
    }
    public static Button GetButtonListener(this Transform trans,string path, UnityAction call)
    {
        Button btn = trans.GetComponentPro<Button>(path);
        if (btn != null)
            btn.onClick.AddListener(call);
        return btn;
    }
    public static void SetPosition<T>(this T t, Vector3 pos) where T : Component
    {
        if (t != null)
            t.transform.position = pos;
    }
    public static void SetLocalPosition<T>(this T t, Vector3 pos) where T : Component
    {
        if (t != null)
            t.transform.localPosition = pos;
    }
    public static void SetRectPosition<T>(this T t, Vector3 pos) where T : Component
    {
        if (t != null)
            (t.transform as RectTransform).position = pos;
    }
    public static void SetLocalRectPosition<T>(this T t, Vector3 pos) where T : Component
    {
        if (t != null)
            (t.transform as RectTransform).localPosition = pos;
    }
    public static void SetLocalScale<T>(this T t,Vector3 scale) where T : Component
    {
        if (t != null)
            t.transform.localScale = scale;
    }
    public static void Move(this Transform trans, Vector3 point, float duration, TweenCallback callBack = null, bool autoKill = true)
    {
        Tweener _tweenPos = trans.DOMove(point, duration);
        _tweenPos.OnComplete(callBack);
        _tweenPos.SetAutoKill(autoKill);
    }
    public static void LocalMove(this Transform trans, Vector3 point, float duration, TweenCallback callBack = null,bool autoKill = true)
    {
        Tweener _tweenPos = trans.DOLocalMove(point, duration);
        _tweenPos.OnComplete(callBack);
        _tweenPos.SetAutoKill(autoKill);
    }
	public static void TweenScale(this TweenScale tween, Vector3 from, Vector3 to, float duration, TweenCallback callBack = null)
	{
		if (tween != null) 
		{
			tween.transform.localScale = from;
			tween.Reset ();
			tween.duration = duration;
			tween.from = from;
			tween.to = to;
			tween.Play();
		}
	}
    public static GameObject Copy(GameObject go, Transform parent, string name = null)
    {
        if (go == null)
            return null;
        GameObject obj = GameObject.Instantiate(go);
        obj.transform.SetParent(parent);
        obj.transform.localPosition = Vector3.zero;
        obj.transform.localScale = Vector3.one;
        if (name.IsNotNullOrEmpty())
            obj.name = name;
        return obj;
    }
    public static void SetParent<T, Z>(this T t, Z parent) where T : UnityEngine.Component where Z : UnityEngine.Component
    {
        if (t != null && parent != null)
        {
            t.transform.SetParent(parent.transform);
            t.transform.localScale = Vector3.one;
            t.transform.localPosition = Vector3.zero;
        }
    }
    public static T AddCloneComponent<T>(GameObject prefab, Transform parent) where T : UnityEngine.Component
    {
        if (prefab == null)
            return null;
        GameObject go = GameObject.Instantiate(prefab.gameObject);
        go.SetActive(true);
        go.transform.SetParent<Transform, Transform>(parent);
        T info = go.GetComponent<T>();
        if (info == null)
            info = go.AddComponent<T>();
        return info;
    }
   
    public static void UpdateInfo<T1, T2>(ref List<T1> t1List, List<T2> t2List, Transform prefabTrans, Transform parent, Action<T2> callBack = null) where T1 : CloneItem<T2>, new()
    {
        t1List = AddTList<T1, T2>(t1List, t2List.Count, prefabTrans, parent, callBack);

        for (int i = 0; i < t2List.Count; i++)
        {
            t1List[i].UpdateInfo(t2List[i]);
        }
    }
    public static List<T1> AddTList<T1, T2>(List<T1> list, int count, Transform prefabTrans, Transform parent, Action<T2> callBack = null) where T1 : CloneItem<T2>, new()
    {
        int flag = count - list.Count;
        if (flag > 0)
        {
            for (int i = 0; i < flag; i++)
            {
                T1 t1 = AddCloneT<T1>(prefabTrans.gameObject, parent);
                t1.Init(callBack);
                list.Add(t1);
            }
        }
        for (int i = 0; i < list.Count; i++)
            list[i].Trans.SetActive(i < count);
        return list;
    }
    public static T AddCloneT<T>(GameObject prefab, Transform parent) where T : CloneItem, new()
    {
        if (prefab == null)
            return null;
        GameObject go = Copy(prefab, parent);
        go.SetActive(true);
        T t = new T();
        t.New(go.transform);
        return t;
    }
}
public class CloneItem
{
    public Transform Trans { get; protected set; }

    public CloneItem()
    {

    }

    public void New(Transform trans)
    {
        Trans = trans;
    }
    public virtual void Clear()
    {
        Trans = null;
    }
}
public class CloneItem<T> : CloneItem
{
    public T t { get; private set; }

    public virtual void Init(Action<T> callBack)
    {

    }
    public virtual void UpdateInfo(T tt)
    {
        t = tt;
    }
    public override void Clear()
    {
        base.Clear();
        t = default(T);
    }
}
