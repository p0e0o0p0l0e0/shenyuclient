using System;
using UnityEngine;

public enum IconGetResult
{
	NO_ERROR,
	NO_ATLAS,
	NO_ICON,
}

/// <summary>
///  icon数据封装，非控制器类！！！！
/// </summary>
public class IconData
{
	public static IconData Empty
	{
		get
		{
			if (_empty == null)
			{
				_empty = new IconData();
			}
			return _empty;
		}
	}
	static IconData _empty = null;


	public ViDelegateAssisstant.Dele<IconData> OnLoadedCallback;
	//
	public object Tag { get { return _tag; } }
	public IconGetResult Result { get { return _result; } }
	public UIAtlas Atlas { get { return _atlas; } }
	public string AtlasName { get { return _atlasName; } }
	public string Sprite { get { return _sprite; } }

	public UISpriteData SpriteData { get { return _spriteData; } }

	IconData()
	{
	}

	public IconData(string atlas, string iconName)
	{	
		_tag = "IconInfo [" + atlas + " -- " + iconName + "]";
		//
		_atlasName = atlas;
		_sprite = iconName;
		Init();
	}

	void Init()
	{
		//_atlas = UIResourceController.Instance.GetAtlas(_atlasName);
        _atlas = UIAtlasManager.Instance.GetAtlas(_atlasName);

        if (_atlas == null)
		{
			_result = IconGetResult.NO_ATLAS;
		}
		else
		{
			_spriteData = _atlas.GetSprite(_sprite);
			if (_spriteData == null)
			{
				_result = IconGetResult.NO_ICON;
			}
		}
	}

	UIAtlas _atlas = null;
	string _atlasName = string.Empty;
	string _sprite = string.Empty;
	IconGetResult _result = IconGetResult.NO_ERROR;
	UISpriteData _spriteData=null;
	object _tag = null;
}

