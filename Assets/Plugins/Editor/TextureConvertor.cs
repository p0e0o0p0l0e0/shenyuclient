using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;

public static class TextureConvertor
{
	static Format CurrentFormat;
	static List<TextureFormatInfo> GetAllTex(bool bFilter, CheckPlatformTexFormat checkAndroid, CheckPlatformTexFormat checkIphone, ReplacePlatformTexFormat replaceAction = null)
	{
		List<string> texPathLs = new List<string>();
		GetAssetsTexInSubFolderForAtlas("assets/UIResource", ref texPathLs);
		List<TextureFormatInfo> infoLs = new List<TextureFormatInfo>();
		int totalCount = texPathLs.Count;
		if (texPathLs.Count > 0)
		{
			int iCurCount = 0;
			foreach (var path in texPathLs)
			{
				TextureImporter texImporter = TextureImporter.GetAtPath(path) as TextureImporter;
				if (null != texImporter)
				{
					TextureFormatInfo texFormatInfo = new TextureFormatInfo(texImporter.assetPath);
					texImporter.GetPlatformTextureSettings("Standalone", out texFormatInfo.windowsMaxSize, out texFormatInfo.texFormatWindows);
					texImporter.GetPlatformTextureSettings("iPhone", out texFormatInfo.iphoneMaxSize, out texFormatInfo.texFormatIphone);
					texImporter.GetPlatformTextureSettings("Android", out texFormatInfo.androidMaxSize, out texFormatInfo.texFormatAndroid);
					texFormatInfo.bMipMapEnabled = texImporter.mipmapEnabled;
					bool bAdd = true;
					texFormatInfo.bNeedAndroidFormat = checkAndroid(texFormatInfo.texFormatAndroid);
					texFormatInfo.bNeedIphoneFormat = checkIphone(texFormatInfo.texFormatIphone);
					if (bFilter)
					{
						bAdd = texFormatInfo.bMipMapEnabled || (!texFormatInfo.bNeedAndroidFormat) || (!texFormatInfo.bNeedIphoneFormat);
					}

					if (bAdd)
					{
						//Debug.Log(texFormatInfo.ToString());
						if (null != replaceAction)
						{
							replaceAction(texImporter, texFormatInfo);
						}
						infoLs.Add(texFormatInfo);
					}
				}
				EditorUtility.DisplayCancelableProgressBar("Check TexFormat", "Wait......", (++iCurCount) * 1f / totalCount);
			}
		}
		totalCount = infoLs.Count;
		Debug.Log("PathCount:" + texPathLs.Count);
		Debug.Log("InfoCount:" + infoLs.Count);

		EditorUtility.ClearProgressBar();
		return infoLs;
	}

	static void SaveTextureFormatInfoPath(List<TextureFormatInfo> infoLs)
	{
		string fileSavePath = "../AllTextureFormatInfoPath";
		int totalCount = infoLs.Count;
		using (StreamWriter sw = File.CreateText(fileSavePath + ".html"))
		{
			sw.WriteLine("size = " + totalCount + "</br>");
			foreach (var info in infoLs)
			{
				sw.WriteLine(info.ToHtmlString());
			}
			sw.Close();
		}
	}

	static bool CheckAndroidFormat(TextureImporterFormat format)
	{
		return format == TextureImporterFormat.ETC_RGB4;
	}

	static bool CheckIphoneFormat(TextureImporterFormat format)
	{
		return format.ToString().Contains("PVRTC");
	}

	delegate bool CheckPlatformTexFormat(TextureImporterFormat format);

	delegate void ReplacePlatformTexFormat(TextureImporter textureImporter, TextureFormatInfo texInfo);

	static void ReplacePlatformFormat(TextureImporter textureImporter, TextureFormatInfo texInfo)
	{
		textureImporter.mipmapEnabled = false;
		//textureImporter.SetPlatformTextureSettings("Android", texInfo.androidMaxSize, TextureImporterFormat.ETC_RGB4);
		//textureImporter.SetPlatformTextureSettings("Android", texInfo.androidMaxSize, TextureImporterFormat.DXT1);
		//textureImporter.SetPlatformTextureSettings("Iphone", texInfo.iphoneMaxSize, TextureImporterFormat.PVRTC_RGBA4);
		switch (CurrentFormat)
		{
			case Format.Alpha8:
				textureImporter.textureFormat = TextureImporterFormat.Alpha8;
				break;
			case Format.ARGB16:
				textureImporter.textureFormat = TextureImporterFormat.ARGB16;
				break;
			case Format.ARGB32:
				textureImporter.textureFormat = TextureImporterFormat.ARGB32;
				break;
			case Format.ASTC_RGB_10x10:
				textureImporter.textureFormat = TextureImporterFormat.ASTC_RGB_10x10;
				break;
			case Format.ASTC_RGB_12x12:
				textureImporter.textureFormat = TextureImporterFormat.ASTC_RGB_12x12;
				break;
			case Format.ASTC_RGB_4x4:
				textureImporter.textureFormat = TextureImporterFormat.ASTC_RGB_4x4;
				break;
			case Format.ASTC_RGB_5x5:
				textureImporter.textureFormat = TextureImporterFormat.ASTC_RGB_5x5;
				break;
			case Format.ASTC_RGB_6x6:
				textureImporter.textureFormat = TextureImporterFormat.ASTC_RGB_6x6;
				break;
			case Format.ASTC_RGB_8x8:
				textureImporter.textureFormat = TextureImporterFormat.ASTC_RGB_8x8;
				break;
			case Format.ASTC_RGBA_10x10:
				textureImporter.textureFormat = TextureImporterFormat.ASTC_RGBA_10x10;
				break;
			case Format.ASTC_RGBA_12x12:
				textureImporter.textureFormat = TextureImporterFormat.ASTC_RGBA_12x12;
				break;
			case Format.ASTC_RGBA_4x4:
				textureImporter.textureFormat = TextureImporterFormat.ASTC_RGBA_4x4;
				break;
			case Format.ASTC_RGBA_5x5:
				textureImporter.textureFormat = TextureImporterFormat.ASTC_RGBA_5x5;
				break;
			case Format.ASTC_RGBA_6x6:
				textureImporter.textureFormat = TextureImporterFormat.ASTC_RGBA_6x6;
				break;
			case Format.ASTC_RGBA_8x8:
				textureImporter.textureFormat = TextureImporterFormat.ASTC_RGBA_8x8;
				break;
			case Format.ATC_RGB4:
				textureImporter.textureFormat = TextureImporterFormat.ATC_RGB4;
				break;
			case Format.ATC_RGBA8:
				textureImporter.textureFormat = TextureImporterFormat.ATC_RGBA8;
				break;
			case Format.Automatic16bit:
				textureImporter.textureFormat = TextureImporterFormat.Automatic16bit;
				break;
			case Format.AutomaticCompressed:
				textureImporter.textureFormat = TextureImporterFormat.AutomaticCompressed;
				break;
			case Format.AutomaticCrunched:
				textureImporter.textureFormat = TextureImporterFormat.AutomaticCrunched;
				break;
			case Format.AutomaticTruecolor:
				textureImporter.textureFormat = TextureImporterFormat.AutomaticTruecolor;
				break;
			case Format.DXT1:
				textureImporter.textureFormat = TextureImporterFormat.DXT1;
				break;
			case Format.DXT1Crunched:
				textureImporter.textureFormat = TextureImporterFormat.DXT1Crunched;
				break;
			case Format.DXT5:
				textureImporter.textureFormat = TextureImporterFormat.DXT5;
				break;
			case Format.DXT5Crunched:
				textureImporter.textureFormat = TextureImporterFormat.DXT5Crunched;
				break;
			case Format.ETC2_RGB4:
				textureImporter.textureFormat = TextureImporterFormat.ETC2_RGB4;
				break;
			case Format.ETC2_RGB4_PUNCHTHROUGH_ALPHA:
				textureImporter.textureFormat = TextureImporterFormat.ETC2_RGB4_PUNCHTHROUGH_ALPHA;
				break;
			case Format.ETC2_RGBA8:
				textureImporter.textureFormat = TextureImporterFormat.ETC2_RGBA8;
				break;
			case Format.ETC_RGB4:
				textureImporter.textureFormat = TextureImporterFormat.ETC_RGB4;
				break;
			case Format.PVRTC_RGB2:
				textureImporter.textureFormat = TextureImporterFormat.PVRTC_RGB2;
				break;
			case Format.PVRTC_RGB4:
				textureImporter.textureFormat = TextureImporterFormat.PVRTC_RGB4;
				break;
			case Format.PVRTC_RGBA2:
				textureImporter.textureFormat = TextureImporterFormat.PVRTC_RGBA2;
				break;
			case Format.PVRTC_RGBA4:
				textureImporter.textureFormat = TextureImporterFormat.PVRTC_RGBA4;
				break;
			case Format.RGB24:
				textureImporter.textureFormat = TextureImporterFormat.RGB24;
				break;
			case Format.RGBA16:
				textureImporter.textureFormat = TextureImporterFormat.RGBA16;
				break;
			case Format.RGBA32:
				textureImporter.textureFormat = TextureImporterFormat.RGBA32;
				break;
		}
		AssetDatabase.ImportAsset(textureImporter.assetPath);
	}

	class TextureFormatInfo
	{
		public string path;
		public bool bMipMapEnabled;
		public bool bNeedAndroidFormat;
		public bool bNeedIphoneFormat;
		public TextureImporterFormat texFormatIphone;
		public TextureImporterFormat texFormatAndroid;
		public TextureImporterFormat texFormatWindows;
		public int androidMaxSize;
		public int iphoneMaxSize;
		public int windowsMaxSize;

		public TextureFormatInfo(string filePath)
		{
			path = filePath;
		}

		public string ToHtmlString()
		{
			//<font color="red"><b> size = 2357 </b></font></br>
			string strFormat = "{0}:   &nbsp &nbsp &nbsp&nbsp &nbsp{1},    &nbsp &nbsp &nbsp &nbsp{2},   &nbsp &nbsp &nbsp &nbsp {3}</br>";

			string bMipStr = string.Format("MipMapEnabled:{0}", bMipMapEnabled);
			string parm1 = bMipMapEnabled ? GetSpecialTip(bMipStr, "red") : bMipStr;
			string androidStr = string.Format("Android:{0}", texFormatAndroid);
			string parm2 = !bNeedAndroidFormat ? GetSpecialTip(androidStr, "blue") : androidStr;
			string iphoneStr = string.Format("Iphone:{0}", texFormatIphone);
			string parm3 = !bNeedIphoneFormat ? GetSpecialTip(iphoneStr, "YellowGreen") : iphoneStr;
			return string.Format(strFormat, path, parm1, parm2, parm3);
		}

		private string GetSpecialTip(string name, string fontColor)
		{
			return string.Format("<font color=\"{0}\"><b>{1}</b></font>", fontColor, name);
		}
	}
	static void GetAssetsTexInSubFolderForAtlas(string srcFolder, ref List<string> atlas)
	{
		string searchPattern0 = "*.png";
		string searchPattern1 = "*.tga";
		string searchPattern2 = "*.psd";
		string searchFolder = srcFolder.Replace(@"\", @"/");
		string searchDir0 = searchFolder;
		if (Directory.Exists(searchDir0))
		{
			//string[] files = Directory.GetFiles(searchDir0, searchPattern);
			AddFilePathToList(Directory.GetFiles(searchDir0, searchPattern0), ref atlas);
			AddFilePathToList(Directory.GetFiles(searchDir0, searchPattern1), ref atlas);
			AddFilePathToList(Directory.GetFiles(searchDir0, searchPattern2), ref atlas);
		}

		string[] dirs = Directory.GetDirectories(searchFolder);
		foreach (string oneDir in dirs)
		{
			GetAssetsTexInSubFolderForAtlas(oneDir, ref atlas);
		}
	}

	static void AddFilePathToList(string[] files, ref List<string> ls)
	{
		foreach (string oneFile in files)
		{
			string srcFile = oneFile.Replace(@"\", @"/");
			string lowerFile = srcFile.ToLower();
			ls.Add(lowerFile);
		}
	}

	[UnityEditor.MenuItem("TextureConvertor/Check Texture Format")]

	public static void CheckTextureFormat()
	{
		List<TextureFormatInfo> infoLs = GetAllTex(true, CheckAndroidFormat, CheckIphoneFormat);
		SaveTextureFormatInfoPath(infoLs);
	}

	[UnityEditor.MenuItem("TextureConvertor/Replace Texture Format/Alpha8")]
	public static void ToAlpha8()
	{
		CurrentFormat = Format.Alpha8;
		GetAllTex(true, CheckAndroidFormat, CheckIphoneFormat, ReplacePlatformFormat);
	}

	[UnityEditor.MenuItem("TextureConvertor/Replace Texture Format/ARGB16")]
	public static void ToARGB16()
	{
		CurrentFormat = Format.ARGB16;
		GetAllTex(true, CheckAndroidFormat, CheckIphoneFormat, ReplacePlatformFormat);
	}

	[UnityEditor.MenuItem("TextureConvertor/Replace Texture Format/ARGB32")]
	public static void ToARGB32()
	{
		CurrentFormat = Format.ARGB32;
		GetAllTex(true, CheckAndroidFormat, CheckIphoneFormat, ReplacePlatformFormat);
	}

	[UnityEditor.MenuItem("TextureConvertor/Replace Texture Format/ASTC_RGB_10x10")]
	public static void ToASTC_RGB_10x10()
	{
		CurrentFormat = Format.ASTC_RGB_10x10;
		GetAllTex(true, CheckAndroidFormat, CheckIphoneFormat, ReplacePlatformFormat);
	}

	[UnityEditor.MenuItem("TextureConvertor/Replace Texture Format/ASTC_RGB_12x12")]
	public static void ToASTC_RGB_12x12()
	{
		CurrentFormat = Format.ASTC_RGB_12x12;
		GetAllTex(true, CheckAndroidFormat, CheckIphoneFormat, ReplacePlatformFormat);
	}

	[UnityEditor.MenuItem("TextureConvertor/Replace Texture Format/ASTC_RGB_4x4")]
	public static void ToASTC_RGB_4x4()
	{
		CurrentFormat = Format.ASTC_RGB_4x4;
		GetAllTex(true, CheckAndroidFormat, CheckIphoneFormat, ReplacePlatformFormat);
	}

	[UnityEditor.MenuItem("TextureConvertor/Replace Texture Format/ASTC_RGB_5x5")]
	public static void ToASTC_RGB_5x5()
	{
		CurrentFormat = Format.ASTC_RGB_5x5;
		GetAllTex(true, CheckAndroidFormat, CheckIphoneFormat, ReplacePlatformFormat);
	}

	[UnityEditor.MenuItem("TextureConvertor/Replace Texture Format/ASTC_RGB_6x6")]
	public static void ToASTC_RGB_6x6()
	{
		CurrentFormat = Format.ASTC_RGB_6x6;
		GetAllTex(true, CheckAndroidFormat, CheckIphoneFormat, ReplacePlatformFormat);
	}

	[UnityEditor.MenuItem("TextureConvertor/Replace Texture Format/ASTC_RGB_8x8")]
	public static void ToASTC_RGB_8x8()
	{
		CurrentFormat = Format.ASTC_RGB_8x8;
		GetAllTex(true, CheckAndroidFormat, CheckIphoneFormat, ReplacePlatformFormat);
	}

	[UnityEditor.MenuItem("TextureConvertor/Replace Texture Format/ASTC_RGBA_10x10")]
	public static void ToASTC_RGBA_10x10()
	{
		CurrentFormat = Format.ASTC_RGBA_10x10;
		GetAllTex(true, CheckAndroidFormat, CheckIphoneFormat, ReplacePlatformFormat);
	}

	[UnityEditor.MenuItem("TextureConvertor/Replace Texture Format/ASTC_RGBA_12x12")]
	public static void ToASTC_RGBA_12x12()
	{
		CurrentFormat = Format.ASTC_RGBA_12x12;
		GetAllTex(true, CheckAndroidFormat, CheckIphoneFormat, ReplacePlatformFormat);
	}

	[UnityEditor.MenuItem("TextureConvertor/Replace Texture Format/ASTC_RGBA_4x4")]
	public static void ToASTC_RGBA_4x4()
	{
		CurrentFormat = Format.ASTC_RGBA_4x4;
		GetAllTex(true, CheckAndroidFormat, CheckIphoneFormat, ReplacePlatformFormat);
	}

	[UnityEditor.MenuItem("TextureConvertor/Replace Texture Format/ASTC_RGBA_5x5")]
	public static void ToASTC_RGBA_5x5()
	{
		CurrentFormat = Format.ASTC_RGBA_5x5;
		GetAllTex(true, CheckAndroidFormat, CheckIphoneFormat, ReplacePlatformFormat);
	}

	[UnityEditor.MenuItem("TextureConvertor/Replace Texture Format/ASTC_RGBA_6x6")]
	public static void ToASTC_RGBA_6x6()
	{
		CurrentFormat = Format.ASTC_RGBA_6x6;
		GetAllTex(true, CheckAndroidFormat, CheckIphoneFormat, ReplacePlatformFormat);
	}

	[UnityEditor.MenuItem("TextureConvertor/Replace Texture Format/ASTC_RGBA_8x8")]
	public static void ToASTC_RGBA_8x8()
	{
		CurrentFormat = Format.ASTC_RGBA_8x8;
		GetAllTex(true, CheckAndroidFormat, CheckIphoneFormat, ReplacePlatformFormat);
	}

	[UnityEditor.MenuItem("TextureConvertor/Replace Texture Format/ATC_RGB4")]
	public static void ToATC_RGB4()
	{
		CurrentFormat = Format.ATC_RGB4;
		GetAllTex(true, CheckAndroidFormat, CheckIphoneFormat, ReplacePlatformFormat);
	}

	[UnityEditor.MenuItem("TextureConvertor/Replace Texture Format/ATC_RGBA8")]
	public static void ToATC_RGBA8()
	{
		CurrentFormat = Format.ATC_RGBA8;
		GetAllTex(true, CheckAndroidFormat, CheckIphoneFormat, ReplacePlatformFormat);
	}

	[UnityEditor.MenuItem("TextureConvertor/Replace Texture Format/Automatic16bit")]
	public static void ToAutomatic16bit()
	{
		CurrentFormat = Format.Automatic16bit;
		GetAllTex(true, CheckAndroidFormat, CheckIphoneFormat, ReplacePlatformFormat);
	}

	[UnityEditor.MenuItem("TextureConvertor/Replace Texture Format/AutomaticCompressed")]
	public static void ToAutomaticCompressed()
	{
		CurrentFormat = Format.AutomaticCompressed;
		GetAllTex(true, CheckAndroidFormat, CheckIphoneFormat, ReplacePlatformFormat);
	}

	[UnityEditor.MenuItem("TextureConvertor/Replace Texture Format/AutomaticCrunched")]
	public static void ToAutomaticCrunched()
	{
		CurrentFormat = Format.AutomaticCrunched;
		GetAllTex(true, CheckAndroidFormat, CheckIphoneFormat, ReplacePlatformFormat);
	}

	[UnityEditor.MenuItem("TextureConvertor/Replace Texture Format/AutomaticTruecolor")]
	public static void ToAutomaticTruecolor()
	{
		CurrentFormat = Format.AutomaticTruecolor;
		GetAllTex(true, CheckAndroidFormat, CheckIphoneFormat, ReplacePlatformFormat);
	}

	[UnityEditor.MenuItem("TextureConvertor/Replace Texture Format/DXT1")]
	public static void ToDXT1()
	{
		CurrentFormat = Format.DXT1;
		GetAllTex(true, CheckAndroidFormat, CheckIphoneFormat, ReplacePlatformFormat);
	}

	[UnityEditor.MenuItem("TextureConvertor/Replace Texture Format/DXT1Crunched")]
	public static void ToDXT1Crunched()
	{
		CurrentFormat = Format.DXT1Crunched;
		GetAllTex(true, CheckAndroidFormat, CheckIphoneFormat, ReplacePlatformFormat);
	}

	[UnityEditor.MenuItem("TextureConvertor/Replace Texture Format/DXT5")]
	public static void ToDXT5()
	{
		CurrentFormat = Format.DXT5;
		GetAllTex(true, CheckAndroidFormat, CheckIphoneFormat, ReplacePlatformFormat);
	}

	[UnityEditor.MenuItem("TextureConvertor/Replace Texture Format/DXT5Crunched")]
	public static void ToDXT5Crunched()
	{
		CurrentFormat = Format.DXT5Crunched;
		GetAllTex(true, CheckAndroidFormat, CheckIphoneFormat, ReplacePlatformFormat);
	}

	[UnityEditor.MenuItem("TextureConvertor/Replace Texture Format/ETC2_RGB4")]
	public static void ToETC2_RGB4()
	{
		CurrentFormat = Format.ETC2_RGB4;
		GetAllTex(true, CheckAndroidFormat, CheckIphoneFormat, ReplacePlatformFormat);
	}

	[UnityEditor.MenuItem("TextureConvertor/Replace Texture Format/ETC2_RGB4_PUNCHTHROUGH_ALPHA")]
	public static void ToETC2_RGB4_PUNCHTHROUGH_ALPHA()
	{
		CurrentFormat = Format.ETC2_RGB4_PUNCHTHROUGH_ALPHA;
		GetAllTex(true, CheckAndroidFormat, CheckIphoneFormat, ReplacePlatformFormat);
	}

	[UnityEditor.MenuItem("TextureConvertor/Replace Texture Format/ETC2_RGBA8")]
	public static void ToETC2_RGBA8()
	{
		CurrentFormat = Format.ETC2_RGBA8;
		GetAllTex(true, CheckAndroidFormat, CheckIphoneFormat, ReplacePlatformFormat);
	}

	[UnityEditor.MenuItem("TextureConvertor/Replace Texture Format/ETC_RGB4")]
	public static void ToETC_RGB4()
	{
		CurrentFormat = Format.ETC_RGB4;
		GetAllTex(true, CheckAndroidFormat, CheckIphoneFormat, ReplacePlatformFormat);
	}

	[UnityEditor.MenuItem("TextureConvertor/Replace Texture Format/PVRTC_RGB2")]
	public static void ToPVRTC_RGB2()
	{
		CurrentFormat = Format.PVRTC_RGB2;
		GetAllTex(true, CheckAndroidFormat, CheckIphoneFormat, ReplacePlatformFormat);
	}

	[UnityEditor.MenuItem("TextureConvertor/Replace Texture Format/PVRTC_RGB4")]
	public static void ToPVRTC_RGB4()
	{
		CurrentFormat = Format.PVRTC_RGB4;
		GetAllTex(true, CheckAndroidFormat, CheckIphoneFormat, ReplacePlatformFormat);
	}

	[UnityEditor.MenuItem("TextureConvertor/Replace Texture Format/PVRTC_RGBA2")]
	public static void ToPVRTC_RGBA2()
	{
		CurrentFormat = Format.PVRTC_RGBA2;
		GetAllTex(true, CheckAndroidFormat, CheckIphoneFormat, ReplacePlatformFormat);
	}

	[UnityEditor.MenuItem("TextureConvertor/Replace Texture Format/PVRTC_RGBA4")]
	public static void ToPVRTC_RGBA4()
	{
		CurrentFormat = Format.PVRTC_RGBA4;
		GetAllTex(true, CheckAndroidFormat, CheckIphoneFormat, ReplacePlatformFormat);
	}

	[UnityEditor.MenuItem("TextureConvertor/Replace Texture Format/RGB16")]
	public static void ToRGB16()
	{
		CurrentFormat = Format.RGB16;
		GetAllTex(true, CheckAndroidFormat, CheckIphoneFormat, ReplacePlatformFormat);
	}

	[UnityEditor.MenuItem("TextureConvertor/Replace Texture Format/RGB24")]
	public static void ToRGB24()
	{
		CurrentFormat = Format.RGB24;
		GetAllTex(true, CheckAndroidFormat, CheckIphoneFormat, ReplacePlatformFormat);
	}

	[UnityEditor.MenuItem("TextureConvertor/Replace Texture Format/RGBA16")]
	public static void ToRGBA16()
	{
		CurrentFormat = Format.RGBA16;
		GetAllTex(true, CheckAndroidFormat, CheckIphoneFormat, ReplacePlatformFormat);
	}

	[UnityEditor.MenuItem("TextureConvertor/Replace Texture Format/RGBA32")]
	public static void ToRGBA32()
	{
		CurrentFormat = Format.RGBA32;
		GetAllTex(true, CheckAndroidFormat, CheckIphoneFormat, ReplacePlatformFormat);
	}


	public enum Format
	{
		Alpha8,
		ARGB16,
		ARGB32,
		ASTC_RGB_10x10,
		ASTC_RGB_12x12,
		ASTC_RGB_4x4,
		ASTC_RGB_5x5,
		ASTC_RGB_6x6,
		ASTC_RGB_8x8,
		ASTC_RGBA_10x10,
		ASTC_RGBA_12x12,
		ASTC_RGBA_4x4,
		ASTC_RGBA_5x5,
		ASTC_RGBA_6x6,
		ASTC_RGBA_8x8,
		ATC_RGB4,
		ATC_RGBA8,
		Automatic16bit,
		AutomaticCompressed,
		AutomaticCrunched,
		AutomaticTruecolor,
		DXT1,
		DXT1Crunched,
		DXT5,
		DXT5Crunched,
		ETC2_RGB4,
		ETC2_RGB4_PUNCHTHROUGH_ALPHA,
		ETC2_RGBA8,
		ETC_RGB4,
		PVRTC_RGB2,
		PVRTC_RGB4,
		PVRTC_RGBA2,
		PVRTC_RGBA4,
		RGB16,
		RGB24,
		RGBA16,
		RGBA32
	}
}