using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class ScreenEntityHintInterface
{
	public static ViDoubleLink2<ScreenEntityHintInterface> HintList { get { return _list; } }
	static ViDoubleLink2<ScreenEntityHintInterface> _list = new ViDoubleLink2<ScreenEntityHintInterface>();

	//
	public ViVector3 Position { get { return _posProvider.Value; } }
	public IconData Icon { get { return IconDataManager.GetIcon(_hint.Icon); } }

	public GameObject EntityObj;

	public void SetPosProvider(ViProvider<ViVector3> posProvider)
	{
		_posProvider = posProvider;
	}
	public void SetHintInfo(EntityHintStruct hint) 
	{
		_hint = hint;
	}

	public void Start()
	{
		ViDebuger.AssertError(_posProvider);
		_attachNode.Data = this;
		_list.PushBack(_attachNode);
	}

	public void End()
	{
		_attachNode.Detach();
		_attachNode.Data = null;
		UnityAssisstant.Destroy(ref EntityObj);
	}

	EntityHintStruct _hint;
	ViProvider<ViVector3> _posProvider;
	ViDoubleLinkNode2<ScreenEntityHintInterface> _attachNode = new ViDoubleLinkNode2<ScreenEntityHintInterface>();
}
