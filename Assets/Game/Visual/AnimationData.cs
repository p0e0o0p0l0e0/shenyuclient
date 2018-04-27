using System;
using System.Collections.Generic;
using UnityEngine;

public enum AnimationLayerId
{
	DEFAULT,
	MOVE_BREAK,
	STATE,

    ACTION,
    HITED,
    DIE,
	ROTATE_H,
	ROTATE_V,
	TOTAL,
}

public class AnimInfo
{
	public AnimationLayerId layer;
	public WrapMode wrapMode;
	public AnimationBlendMode blendMod = AnimationBlendMode.Blend;
	public int upperWeight;
	public int lowerWeight;
}

public static class AnimationData
{
    /*
    public static readonly string Idle = "Idle";
	public static readonly string Idle02 = "Idle02";
	public static readonly string Idle03 = "Idle03";
	public static readonly string Run = "Run";
	public static readonly string RunForward = "RunF";
	public static readonly string RunBackward = "RunB";
	public static readonly string RunLeft = "RunL";
	public static readonly string RunRight = "RunR";
	public static readonly string Walk = "Walk";
	public static readonly string Die = "Die";
	public static readonly string JumpStart = "JumpStart";
	public static readonly string JumpLoop = "JumpLoop";
	public static readonly string JumpEnd = "JumpEnd";
	public static readonly string Enter = "Enter";
	public static readonly string Enter02 = "Enter02";
	public static readonly string Enter03 = "Enter03";
	public static readonly string Enter04 = "Enter04";
	public static readonly string Enter05 = "Enter05";
	public static readonly string Exit = "Exit";
	public static readonly string Exit02 = "Exit02";
	public static readonly string Exit03 = "Exit03";
	public static readonly string Show = "Show";
	public static readonly string Show02 = "Show02";
	public static readonly string Show03 = "Show03";
	public static readonly string Show04 = "Show04";
	public static readonly string Show05 = "Show05";
	public static readonly string Show06 = "Show06";
	public static readonly string ChargeBullet = "Reload";
	public static readonly string Boom = "Boom";
	public static readonly string Throw = "Throw";
	public static readonly string Lay = "Lay";
	public static readonly string Roar = "Roar";
	public static readonly string Attack = "Attack";
	public static readonly string Attack02 = "Attack02";
	public static readonly string Attack03 = "Attack03";
	public static readonly string Attack04 = "Attack04";
	public static readonly string Attack05 = "Attack05";
	public static readonly string Attack11 = "Attack11";
	public static readonly string Attack12 = "Attack12";
	public static readonly string Attack13 = "Attack13";
	public static readonly string Spell = "Spell";
	public static readonly string Spell02 = "Spell02";
	public static readonly string Spell03 = "Spell03";
	public static readonly string Spell04 = "Spell04";
	public static readonly string Spell05 = "Spell05";
	public static readonly string Spell11 = "Spell11";
	public static readonly string Spell12 = "Spell12";
	public static readonly string Spell13 = "Spell13";
	public static readonly string Spell14 = "Spell14";
	public static readonly string Hited = "Hited";
	public static readonly string Hited02 = "Hited02";
	public static readonly string Hited03 = "Hited03";
	public static readonly string Knocked = "Knocked";
	public static readonly string Stun = "Stun";
	public static readonly string LookL = "LookL";
	public static readonly string LookR = "LookR";
	public static readonly string LookLR = "LookLR";
    */


    public static readonly string Idle = "idle01";
    public static readonly string Idle02 = "idle02";
    public static readonly string Idle03 = "idle03";
    public static readonly string Run = "run03"; // 奔跑
    public static readonly string Run02 = "run02"; // 翻滾
    public static readonly string Run03 = "run01"; //非战斗跑动

    public static readonly string Win = "win01";
    public static readonly string Die = "die01";

    public static readonly string Talk01 = "talk01";
    public static readonly string Fly = "fly01";
    public static readonly string Stun = "stun01";
    public static readonly string Rise = "rise01";
    public static readonly string Hitlie = "hitlie01";// 击倒
    public static readonly string Hit01 = "hit01";
    public static readonly string Hit = "hit02";

    // 四段击飞
    public static readonly string HitFly = "hitfly01";
    public static readonly string HitFly01 = "hitfly02";
    public static readonly string HitFly02 = "hitfly03";
    public static readonly string HitFly03 = "hitfly04";
    //public static readonly string 

    //
    public static readonly string Show01 = "show01";
    public static readonly string Show02 = "show02";
    public static readonly string Show03 = "show03";
    public static readonly string Show04 = "show04";
    public static readonly string Show05 = "show05";
    // 剧情

    public static readonly string Attack01 = "attack01";
    public static readonly string Attack02 = "attack02";
    public static readonly string Attack03 = "attack03";
    public static readonly string Attack04 = "attack04";
    public static readonly string Attack05 = "attack05";
    public static readonly string Attack06 = "attack06";
    public static readonly string Attack07 = "attack07";
//     public static readonly string[] Attacks = new string[] {Attack01, Attack02, Attack03, Attack04, Attack05, Attack06, Attack07};
//    public static readonly string[] Attacks = new string[] { Attack01, Attack01, Attack01, Attack01, Attack01, Attack01, Attack01 };
    
    public static readonly string CdSkill01 = "cdskill01";
    public static readonly string CdSkill02 = "cdskill02";
    public static readonly string CdSkill03 = "cdskill03";
    public static readonly string CdSkill04 = "cdskill04";
    public static readonly string CdSkill05 = "cdskill05";
    public static readonly string CdSkill06 = "cdskill06";
    public static readonly string CdSkill07 = "cdskill07";
    public static readonly string CdSkill08 = "cdskill08";
    public static readonly string CdSkill0901 = "cdskill0901";
    public static readonly string CdSkill0902 = "cdskill0902";
    public static readonly string CdSkill10 = "cdskill10";
    public static readonly string CdSkill11 = "cdskill11";
    public static readonly string CdSkill12 = "cdskill12";
    public static readonly string CdSkill13 = "cdskill13";
    public static readonly string CdSkill14 = "cdskill14";
    public static readonly string CdSkill15 = "cdskill15";
    public static readonly string CdSkill17 = "cdskill17";
    public static readonly string CdSkill1001 = "cdskill1001";

    public static readonly string BqSkill01 = "bqskill01";
    public static readonly string BqSkill02 = "bqskill02";
    public static readonly string BqSkill03 = "bqskill03";
    public static readonly string BqSkill04 = "bqskill04";
    public static readonly string BqSkill05 = "bqskill05";
    public static readonly string BqSkill06 = "bqskill06";
    public static readonly string BqSkill07 = "bqskill07";

    public static readonly string Chusheng = "chusheng";

    public static readonly string Ride = "ride01";










    static AnimationData()
	{
        Set(Idle, AnimationLayerId.DEFAULT, WrapMode.Loop);
        Set(Idle02, AnimationLayerId.DEFAULT, WrapMode.Loop);
        Set(Idle03, AnimationLayerId.DEFAULT, WrapMode.Loop);
        Set(Run, AnimationLayerId.DEFAULT, WrapMode.Loop);
        Set(Run03, AnimationLayerId.DEFAULT, WrapMode.Loop);

        Set(Show01, AnimationLayerId.DEFAULT, WrapMode.Once);
        Set(Show02, AnimationLayerId.DEFAULT, WrapMode.Once);
        Set(Show03, AnimationLayerId.DEFAULT, WrapMode.Once);
        Set(Show04, AnimationLayerId.DEFAULT, WrapMode.Once);
        Set(Show05, AnimationLayerId.DEFAULT, WrapMode.Once);

        Set(Talk01, AnimationLayerId.ACTION, WrapMode.Once);
        
        Set(Run02, AnimationLayerId.ACTION, WrapMode.Once);
        Set(Fly, AnimationLayerId.ACTION, WrapMode.Once);
        Set(Stun, AnimationLayerId.ACTION, WrapMode.Loop);
        Set(Hitlie, AnimationLayerId.ACTION, WrapMode.Once);
        Set(Rise, AnimationLayerId.ACTION, WrapMode.Once);
        Set(Hit01, AnimationLayerId.ACTION, WrapMode.ClampForever);
        Set(Hit, AnimationLayerId.HITED, WrapMode.Once, AnimationBlendMode.Additive);
        

        Set(HitFly, AnimationLayerId.ACTION, WrapMode.ClampForever);
        Set(HitFly01, AnimationLayerId.ACTION, WrapMode.ClampForever);
        Set(HitFly02, AnimationLayerId.ACTION, WrapMode.ClampForever);
        Set(HitFly03, AnimationLayerId.ACTION, WrapMode.ClampForever);

        Set(Attack01, AnimationLayerId.ACTION, WrapMode.Once);
        Set(Attack02, AnimationLayerId.ACTION, WrapMode.Once);
        Set(Attack03, AnimationLayerId.ACTION, WrapMode.Once);
        Set(Attack04, AnimationLayerId.ACTION, WrapMode.Once);
        Set(Attack05, AnimationLayerId.ACTION, WrapMode.Once);
        Set(Attack06, AnimationLayerId.ACTION, WrapMode.Once);
        Set(Attack07, AnimationLayerId.ACTION, WrapMode.Once);

        Set(CdSkill01, AnimationLayerId.ACTION, WrapMode.Once);
        Set(CdSkill02, AnimationLayerId.ACTION, WrapMode.Once);
        Set(CdSkill03, AnimationLayerId.ACTION, WrapMode.Once);
        Set(CdSkill04, AnimationLayerId.ACTION, WrapMode.Once);
        Set(CdSkill05, AnimationLayerId.ACTION, WrapMode.Once);
        Set(CdSkill06, AnimationLayerId.ACTION, WrapMode.Once);
        Set(CdSkill07, AnimationLayerId.ACTION, WrapMode.Once);
        Set(CdSkill08, AnimationLayerId.ACTION, WrapMode.Once);
        Set(CdSkill0901, AnimationLayerId.ACTION, WrapMode.ClampForever);
        Set(CdSkill0902, AnimationLayerId.ACTION, WrapMode.Once);
        Set(CdSkill10, AnimationLayerId.ACTION, WrapMode.Once);
        Set(CdSkill11, AnimationLayerId.ACTION, WrapMode.Once);
        Set(CdSkill12, AnimationLayerId.ACTION, WrapMode.Once);
        Set(CdSkill13, AnimationLayerId.ACTION, WrapMode.Once);
        Set(CdSkill14, AnimationLayerId.ACTION, WrapMode.Once);
        Set(CdSkill15, AnimationLayerId.ACTION, WrapMode.Once);
        Set(CdSkill17, AnimationLayerId.ACTION, WrapMode.Once);
        Set(CdSkill1001, AnimationLayerId.ACTION, WrapMode.Once);

        Set(BqSkill01, AnimationLayerId.ACTION, WrapMode.Once);
        Set(BqSkill02, AnimationLayerId.ACTION, WrapMode.Once);
        Set(BqSkill03, AnimationLayerId.ACTION, WrapMode.Once);
        Set(BqSkill04, AnimationLayerId.ACTION, WrapMode.Once);
        Set(BqSkill05, AnimationLayerId.ACTION, WrapMode.Once);
        Set(BqSkill06, AnimationLayerId.ACTION, WrapMode.Once);
        Set(BqSkill07, AnimationLayerId.ACTION, WrapMode.Once);
        Set(Chusheng, AnimationLayerId.ACTION, WrapMode.Once);

        Set(Win, AnimationLayerId.DIE, WrapMode.ClampForever);
        Set(Die, AnimationLayerId.DIE, WrapMode.ClampForever);


        AddMoveMixAnim(Attack01);
        AddMoveMixAnim(Attack02);
        AddMoveMixAnim(Attack03);
        AddMoveMixAnim(Attack04);
        AddMoveMixAnim(Attack05);
        AddMoveMixAnim(Attack06);
        AddMoveMixAnim(Attack07);
        AddMoveMixAnim(CdSkill01);
        AddMoveMixAnim(CdSkill02);
        AddMoveMixAnim(CdSkill03);
        AddMoveMixAnim(CdSkill04);
        AddMoveMixAnim(CdSkill05);
        AddMoveMixAnim(CdSkill06);
        AddMoveMixAnim(CdSkill07);

        /*
		Set(Idle, AnimationLayerId.DEFAULT, WrapMode.Loop);
		Set(Idle02, AnimationLayerId.DEFAULT, WrapMode.Loop);
		Set(Idle03, AnimationLayerId.DEFAULT, WrapMode.Loop);
		Set(Run, AnimationLayerId.DEFAULT, WrapMode.Loop);
		Set(RunForward, AnimationLayerId.DEFAULT, WrapMode.Loop);
		Set(RunBackward, AnimationLayerId.DEFAULT, WrapMode.Loop);
		Set(RunLeft, AnimationLayerId.DEFAULT, WrapMode.Loop);
		Set(RunRight, AnimationLayerId.DEFAULT, WrapMode.Loop);
		Set(Walk, AnimationLayerId.DEFAULT, WrapMode.Loop);
		//
		Set(JumpStart, AnimationLayerId.ACTION, WrapMode.Once);
		Set(JumpLoop, AnimationLayerId.ACTION, WrapMode.Loop);
		Set(JumpEnd, AnimationLayerId.ACTION, WrapMode.Once);
		Set(Enter, AnimationLayerId.ACTION, WrapMode.Once);
		Set(Enter02, AnimationLayerId.ACTION, WrapMode.Once);
		Set(Enter03, AnimationLayerId.ACTION, WrapMode.Once);
		Set(Enter04, AnimationLayerId.ACTION, WrapMode.Once);
		Set(Enter05, AnimationLayerId.ACTION, WrapMode.Once);
		Set(Exit, AnimationLayerId.ACTION, WrapMode.ClampForever);
		Set(Exit02, AnimationLayerId.ACTION, WrapMode.ClampForever);
		Set(Exit03, AnimationLayerId.ACTION, WrapMode.ClampForever);
		//
		Set(Show, AnimationLayerId.ACTION, WrapMode.Once);
		Set(Show02, AnimationLayerId.ACTION, WrapMode.Once);
		Set(Show03, AnimationLayerId.ACTION, WrapMode.Once);
		Set(Show04, AnimationLayerId.ACTION, WrapMode.Once);
		Set(Show05, AnimationLayerId.ACTION, WrapMode.Once);
		Set(Show06, AnimationLayerId.ACTION, WrapMode.Once);
		//
		Set(ChargeBullet, AnimationLayerId.ACTION, WrapMode.Once);
		Set(Boom, AnimationLayerId.ACTION, WrapMode.Once);
		Set(Throw, AnimationLayerId.ACTION, WrapMode.Once);
		Set(Lay, AnimationLayerId.ACTION, WrapMode.Once);
		Set(Roar, AnimationLayerId.ACTION, WrapMode.Once);
		Set(Attack, AnimationLayerId.ACTION, WrapMode.Once);
		Set(Attack02, AnimationLayerId.ACTION, WrapMode.Once);
		Set(Attack03, AnimationLayerId.ACTION, WrapMode.Once);
		Set(Attack04, AnimationLayerId.ACTION, WrapMode.Once);
		Set(Attack05, AnimationLayerId.ACTION, WrapMode.Once);
		Set(Spell, AnimationLayerId.ACTION, WrapMode.Once);
		Set(Spell02, AnimationLayerId.ACTION, WrapMode.Once);
		Set(Spell03, AnimationLayerId.ACTION, WrapMode.Once);
		Set(Spell04, AnimationLayerId.ACTION, WrapMode.Once);
		Set(Spell05, AnimationLayerId.ACTION, WrapMode.Once);
		//
		Set(Hited, AnimationLayerId.HITED, WrapMode.Once, AnimationBlendMode.Additive);
		Set(Hited02, AnimationLayerId.ACTION, WrapMode.Once);
		Set(Hited03, AnimationLayerId.ACTION, WrapMode.Once);
		Set(Knocked, AnimationLayerId.ACTION, WrapMode.Once);
		//
		Set(Stun, AnimationLayerId.STATE, WrapMode.Loop);
		//
		Set(LookL, AnimationLayerId.ROTATE_H, WrapMode.ClampForever, AnimationBlendMode.Additive);
		Set(LookR, AnimationLayerId.ROTATE_H, WrapMode.ClampForever, AnimationBlendMode.Additive);
		Set(LookLR, AnimationLayerId.ROTATE_H, WrapMode.ClampForever, AnimationBlendMode.Additive);
		//
		
		//
		AddMoveMixAnim(ChargeBullet);
		AddMoveMixAnim(Boom);
		AddMoveMixAnim(Throw);
		AddMoveMixAnim(Lay);
		AddMoveMixAnim(Roar);
		AddMoveMixAnim(Attack);
		AddMoveMixAnim(Spell);
		AddMoveMixAnim(Spell02);
		AddMoveMixAnim(Spell03);
		AddMoveMixAnim(Spell04);
		AddMoveMixAnim(Spell05);
        */

    }

    public static Dictionary<string, AnimInfo> Datas { get { return _datas; } }
	public static List<string> MoveMixAnims { get { return _moveMixAnims; } }

	public static bool Get(string name, out AnimInfo info)
	{
		return _datas.TryGetValue(name, out info);
	}

	public static void Set(string name, AnimInfo info)
	{
		ViDebuger.AssertWarning(!_datas.ContainsKey(name));
		if (!_datas.ContainsKey(name))
		{
			_datas[name] = info;
		}
	}

	public static void Set(string name, AnimationLayerId layer, WrapMode wrap, AnimationBlendMode blend)
	{
		AnimInfo info = new AnimInfo();
		info.layer = layer;
		info.wrapMode = wrap;
		info.blendMod = blend;
		Set(name, info);
	}

	public static void Set(string name, AnimationLayerId layer, WrapMode wrap)
	{
		Set(name, layer, wrap, AnimationBlendMode.Blend);
	}

	public static void AddMoveMixAnim(string animNam)
	{
		_moveMixAnims.Add(animNam);
	}

	public static void Format(Animation anim, float speed)
	{
		anim.playAutomatically = false;
		anim.Stop();
		anim.cullingType = AnimationCullingType.AlwaysAnimate;
		foreach (KeyValuePair<string, AnimInfo> pair in AnimationData.Datas)
		{
			SetAnimInfo(anim, pair.Key, pair.Value, speed);
		}
	}

	public static void SetAnimInfo(Animation animation, string name, AnimInfo info, float speed)
	{
		AnimationState animState = animation[name];
		if (animState == null)
		{
			return;
		}
		animState.layer = (int)info.layer;
		animState.wrapMode = info.wrapMode;
		animState.blendMode = info.blendMod;
		animState.speed = speed;
	}

	public static bool IsMoveBreakAnim(string name)
	{
		AnimInfo info;
		if (_datas.TryGetValue(name, out info))
		{
			return info.layer == AnimationLayerId.MOVE_BREAK;
		}
		else
		{
			return false;
		}
	}

	public static bool IsLoopAnim(string name)
	{
		AnimInfo info;
		if (_datas.TryGetValue(name, out info))
		{
			return info.wrapMode == WrapMode.Loop;
		}
		else
		{
			return false;
		}
	}


	static List<string> _moveMixAnims = new List<string>();
	static Dictionary<string, AnimInfo> _datas = new Dictionary<string, AnimInfo>();
}

