using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class UIClipBoard
{
	public static UIClipBoard Instance
	{
		get
		{
			if (_Clipboard == null)
			{
				_Clipboard = new UIClipBoard();
			}
			return _Clipboard;
		}
	}

	static UIClipBoard _Clipboard = null;

	public void CopyText(string text)
	{
		TextEditor editor = new TextEditor();
		editor.text = text;
		editor.OnFocus();
		editor.Copy();
	}
}
