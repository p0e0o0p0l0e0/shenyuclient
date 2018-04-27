using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
//
using UInt8 = System.Byte;

public class ApplicationSetting
{
	public static ViConstValue<List<Int32>> VALUE_FPSSettingList = new ViConstValue<List<Int32>>("FPSSettingList", new List<Int32>());
	
	public static ApplicationSetting Instance { get { return _instance; } }
	static ApplicationSetting _instance = new ApplicationSetting();

	public float MusicVolumeScale { get { return MainVolume * MusicVolume; } }
	public float SoundVolumeScale { get { return MainVolume * SoundVolume; } }
	public float CharactorVolumeScale { get { return MainVolume * CharacterVolume; } }
	public string LOD_Name { get { return string.Empty; } }

	public ClientSettingForPlayerProperty PlayerProperty { get { return _playerSetting; } }
	public ClientSettingForAccountProperty AccountProperty { get { return _accountSetting; } }

	public UInt8 AutoAct
	{
		get { return _playerSetting.AutoAct; }
		set
		{
			_playerSetting.AutoAct = value;
		}
	}

	public UInt8 MouseControllerType
	{
		get { return _playerSetting.MouseControllerType; }
		set
		{
			_playerSetting.MouseControllerType = value;
		}
	}

	public float MainVolume
	{
		get { return _accountSetting.MainVolume; }
		set
		{
			_accountSetting.MainVolume = value;
			//
			GameApplication.Instance.MusicManager.SetVolume(MusicVolumeScale);
		}
	}

	public float MusicVolume
	{
		get { return _accountSetting.MusicVolume; }
		set
		{
			_accountSetting.MusicVolume = value;
			//
			GameApplication.Instance.MusicManager.SetVolume(MusicVolumeScale);
		}
	}

	public float SoundVolume
	{
		get { return _accountSetting.SoundVolume; }
		set
		{
			_accountSetting.SoundVolume = value;
		}
	}

	public float CharacterVolume
	{
		get { return _accountSetting.CharacterVolume; }
		set
		{
			_accountSetting.CharacterVolume = value;
		}
	}

	public float CameraShakeScale
	{
		get { return _accountSetting.CameraShakeScale; }
		set
		{
			_accountSetting.CameraShakeScale = value;
		}
	}

	public UInt8 FPSLevel
	{
		get { return _accountSetting.FPSLevel; }
		set
		{
			_accountSetting.FPSLevel = value;
			//
			Application.targetFrameRate = VALUE_FPSSettingList.Value[value];
		}
	}

	public UInt8 EnergySave
	{
		get { return _accountSetting.EnergySave; }
		set
		{
			_accountSetting.EnergySave = value;
		}
	}

	public UInt8 SpellLODLevelSUP { get { return 2; } }
	public UInt8 SpellLODLevel
	{
		get { return _accountSetting.SpellLODLevel; }
		set
		{
			_accountSetting.SpellLODLevel = value;
		}
	}
	public bool UILODLow { get { return ApplicationSetting.Instance.GraphicsMainLevel <= 0; } }

	public UInt8 GraphicsMainLevelSup { get { return 3; } }
	public UInt8 GraphicsMainLevel
	{
		get { return _accountSetting.GraphicsMainLevel; }
		set
		{
			_accountSetting.GraphicsMainLevel = value;
			Update();
		}
	}

	public UInt8 GraphicsMirrorCharacter
	{
		get { return _accountSetting.GraphicsMirrorCharacter; }
		set
		{
			_accountSetting.GraphicsMirrorCharacter = value;
		}
	}

	public UInt8 GraphicsMirrorScene
	{
		get { return _accountSetting.GraphicsMirrorScene; }
		set
		{
			_accountSetting.GraphicsMirrorScene = value;
		}
	}

	public bool GraphicsMirror
	{
		get { return _accountSetting.GraphicsMirrorCharacter != 0 || _accountSetting.GraphicsMirrorScene != 0; }
	}

	public UInt8 GraphicsShadow
	{
		get { return _accountSetting.GraphicsShadow; }
		set
		{
			_accountSetting.GraphicsShadow = value;
			Update();
		}
	}

	public UInt8 GraphicsColorEnhance
	{
		get { return _accountSetting.GraphicsColorEnhance; }
		set
		{
			_accountSetting.GraphicsColorEnhance = value;
			Update();
		}
	}

	public UInt8 GraphicsBloom
	{
		get { return _accountSetting.GraphicsBloom; }
		set
		{
			_accountSetting.GraphicsBloom = value;
		}
	}

	public UInt8 GraphicsDistort
	{
		get { return _accountSetting.GraphicsDistort; }
		set
		{
			_accountSetting.GraphicsDistort = value;
		}
	}

	public float AutoLockFocus
	{
		get { return _accountSetting.AutoLockFocusScale; }
		set
		{
			_accountSetting.AutoLockFocusScale = value;
		}
	}

	public int ResolutionScaleIndex
	{
		get { return _resoltionScaleIdx; }
		set { _resoltionScaleIdx = value; }
	}
	int _resoltionScaleIdx;

	public Resolution StartResolution { get { return _startResoltion; } }
	Resolution _startResoltion = new Resolution();

	public void Start(Player entity)
	{
		_accountSetting = Account.Instance.Property.ClientSetting;
		_playerSetting = entity.Property.ClientSetting;
		//
		_resoltionScaleIdx = 2;
		_startResoltion.width = Screen.width;
		_startResoltion.height = Screen.height;
		//
		Update();
	}

	public void Save()
	{
		Update();
		//
		AccountServerInvoker.UpdateClientSetting(Account.Instance, _accountSetting);
		PlayerServerInvoker.UpdateClientSetting(Player.Instance, _playerSetting);
	}

	public void Update()
	{
		GraphicsLevelStruct graphicsLevelInfo = ViSealedDB<GraphicsLevelStruct>.Data(GraphicsMainLevel);
		QualitySettings.SetQualityLevel(graphicsLevelInfo.QualityLevel);
		Application.targetFrameRate = VALUE_FPSSettingList.Value[FPSLevel];
		GameApplication.Instance.MusicManager.SetVolume(MusicVolumeScale);
		PlayerPrefs.SetFloat("MusicVolumeScale", ApplicationSetting.Instance.MusicVolumeScale);
		PlayerPrefs.Save();
	}

	ClientSettingForAccountProperty _accountSetting = new ClientSettingForAccountProperty();
	ClientSettingForPlayerProperty _playerSetting = new ClientSettingForPlayerProperty();
	ViPriorityValue<Int32> _renderLevel = new ViPriorityValue<Int32>();
}