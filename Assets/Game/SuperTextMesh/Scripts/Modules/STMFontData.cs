//Copyright (c) 2016 Kai Clavier [kaiclavier.com] Do Not Distribute
using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName = "New Font Data", menuName = "Super Text Mesh/Font Data", order = 1)]
public class STMFontData : ScriptableObject{
	//public string name;
	public Font font;
	[Tooltip("Only effects dynamic fonts.")]
	[Range(1,512)] public int quality = 64; 
	public FilterMode filterMode = FilterMode.Bilinear; //default

}