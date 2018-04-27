using System;

public class OwnSpellStruct : ViSealedData
{
	public ViEnum32<BoolValue> Operate;
	public ViForeignKey<ViSpellStruct> Spell;   //技能(即原表中的技能id)
	public Int32 LevelSup;
	public ViForeignKey<ViValueMappingStruct> LevelValueMapping;
	public string Icon;     //天赋图标
	public string Description;  //天赋的描述
	public string DescriptionEx;

    public ViEnum32<HeroClass> m_eClass;  //使用此技能的职业(转职后此值不变)
    public ViEnum32<BoolValue> IsTalent;   //false转职前可用，true转职后才能使用
    ViEnum32<Gender> m_eGender;      // 性别
    public Int32 Floor;     //技能所在的层（技能面板的顺序）
    public Int32 Position;      //技能所在层的位置
    public Int32 NeedLevel;     //主角解锁等级
    public Int32 EffectType;    //天赋效果类型
    public ViStaticArray<ViMiscInt32> AddProperty = new ViStaticArray<ViMiscInt32>(3);     //提升的属类型(name)/提升的属性值(value)
    public Int32 PassiveTrigger;    //被动效果ID（-1表示没有）
    public string VideoPath;    //技能视频路径
}

//技能位置解锁限制
public class SpellLimitStruct : ViSealedData
{
    public Int32 Level;  //人物等级
}

public class HeroLevelStruct : ViSealedData
{
    public ViEnum32<HeroClass> HeroClass;
    public Int32 Level;
    public Int32 XPToLeave;
    public ViForeignKey<GameUnitPropertyStruct> BasicAttribute;
}

public class HeroStruct : ViSealedData
{
	public struct RequestStruct
	{
		public ItemCountStruct kItem;
		public MoneyStruct kPrice;
	}
	public struct WorkingSwitchStruct
	{
		public Int32 EnterDuration;
		public Int32 ExitDuration;
	}
	public struct RewardStruct
	{
		public ViForeignKey<PlayerPhotoStruct> Photo;
	}
	//
	public ViEnum32<Gender> Gender;
    public ViEnum32<HeroClass> HeroClass;
	public Int32 BodyRadius;
	public Int32 MoveSpeed;
	public Int32 Reserve_0;
	public ViForeignKey<WeaponTypeStruct> WeaponType;
	public Int32 ShotWidthOffset;
	public Int32 ShotHeight;
	public ViForeignKey<HeroNatureStruct> Nature;
    public ViStaticArray<ViForeignKeyStruct<OwnSpellStruct>> Spell = new ViStaticArray<ViForeignKeyStruct<OwnSpellStruct>>(10);
    public ViForeignKey<OwnSpellStruct> NormalAttackSpell;
    public ViForeignKey<OwnSpellStruct> DashSpell;
    public RequestStruct Request;
	public RewardStruct Reward;
}

public class HeroNatureStruct : ViSealedData
{
	public string Icon;
	public string Icon2;
}

public class BulletStruct : ViSealedData
{
	public Int32 Radius;
	public ViForeignKey<PathFileResStruct> Res;
}

public class WeaponTypeStruct : ViSealedData
{
	
}
