using System;
using System.Collections;
using System.Collections.Generic;
using Int8 = System.SByte;
using UInt8 = System.Byte;
using ViEntityID = System.UInt64;
using ViString = System.String;
using ViArrayIdx = System.Int32;
public class GameUnitProperty : ViGameUnitProperty
{
	public static readonly new int TYPE_SIZE = ViGameUnitProperty.TYPE_SIZE + 160;
	public static readonly new int INDEX_PROPERTY_COUNT = ViGameUnitProperty.INDEX_PROPERTY_COUNT + 148;
	//
	public Int16 Level;//ALL_CLIENT
	public UInt32 FocusEntity;//OWN_CLIENT
	public UInt8 Faction;//ALL_CLIENT+CENTER
	public UInt64PtrProperty Team;//ALL_CLIENT
	public UInt32 Owner;//ALL_CLIENT
	public Dictionary<UInt32, TimeProperty> SpellCDList;//OWN_CLIENT
	public HashSet<ViString> ScriptList;//ALL_CLIENT
	public Dictionary<ViString, Int64Property> ScriptValueList;//ALL_CLIENT
	public Int32 DefenceCoefficient;//ALL_CLIENT
	public Int32 CriticalHitCoefficient;//ALL_CLIENT
	public Int32 CriticalDamageCoefficient;//ALL_CLIENT
	public Int32 ElementCoefficient;//ALL_CLIENT
	public Int32 None0;//
	public Int32 None1;//
	public Int32 None2;//
	public Int32 None3;//
	public Int32 None4;//
	public Int32 None5;//
	public Int32 ViewRange0;//
	public Int32 ViewRange1;//
	public Int32 ViewRange2;//
	public Int32 ViewRange3;//
	public Int32 ViewRange4;//
	public Int32 ViewRange5;//
	public Int32 VisibilityRange0;//
	public Int32 VisibilityRange1;//
	public Int32 VisibilityRange2;//
	public Int32 VisibilityRange3;//
	public Int32 VisibilityRange4;//
	public Int32 VisibilityRange5;//
	public Int32 AntiStealthRange0;//
	public Int32 AntiStealthRange1;//
	public Int32 AntiStealthRange2;//
	public Int32 AntiStealthRange3;//
	public Int32 AntiStealthRange4;//
	public Int32 AntiStealthRange5;//
	public Int32 HPPercent;//
	public Int32 HP;//ALL_CLIENT+CENTER
	public Int32 MP;//ALL_CLIENT
	public Int32 SP;//ALL_CLIENT
	public Int32 HPMax0;//ALL_CLIENT+CENTER
	public Int32 HPMax1;//
	public Int32 HPMax2;//
	public Int32 HPMax3;//
	public Int32 HPMax4;//
	public Int32 HPMax5;//
	public Int32 MPMax0;//ALL_CLIENT+CENTER
	public Int32 MPMax1;//
	public Int32 MPMax2;//
	public Int32 MPMax3;//
	public Int32 MPMax4;//
	public Int32 MPMax5;//
	public Int32 SPMax0;//ALL_CLIENT+CENTER
	public Int32 SPMax1;//
	public Int32 SPMax2;//
	public Int32 SPMax3;//
	public Int32 SPMax4;//
	public Int32 SPMax5;//
	public Int32 HPRegenerate0;//OWN_CLIENT
	public Int32 HPRegenerate1;//
	public Int32 HPRegenerate2;//
	public Int32 HPRegenerate3;//
	public Int32 HPRegenerate4;//
	public Int32 HPRegenerate5;//
	public Int32 MPRegenerate0;//OWN_CLIENT
	public Int32 MPRegenerate1;//
	public Int32 MPRegenerate2;//
	public Int32 MPRegenerate3;//
	public Int32 MPRegenerate4;//
	public Int32 MPRegenerate5;//
	public Int32 SPRegenerate0;//OWN_CLIENT
	public Int32 SPRegenerate1;//
	public Int32 SPRegenerate2;//
	public Int32 SPRegenerate3;//
	public Int32 SPRegenerate4;//
	public Int32 SPRegenerate5;//
	public Int32 PhysicsAttack0;//OWN_CLIENT
	public Int32 PhysicsAttack1;//
	public Int32 PhysicsAttack2;//
	public Int32 PhysicsAttack3;//
	public Int32 PhysicsAttack4;//
	public Int32 PhysicsAttack5;//
	public Int32 PhysicsDefence0;//OWN_CLIENT
	public Int32 PhysicsDefence1;//
	public Int32 PhysicsDefence2;//
	public Int32 PhysicsDefence3;//
	public Int32 PhysicsDefence4;//
	public Int32 PhysicsDefence5;//
	public Int32 MagicAttack0;//OWN_CLIENT
	public Int32 MagicAttack1;//
	public Int32 MagicAttack2;//
	public Int32 MagicAttack3;//
	public Int32 MagicAttack4;//
	public Int32 MagicAttack5;//
	public Int32 MagicDefence0;//OWN_CLIENT
	public Int32 MagicDefence1;//
	public Int32 MagicDefence2;//
	public Int32 MagicDefence3;//
	public Int32 MagicDefence4;//
	public Int32 MagicDefence5;//
	public Int32 MoveSpeed0;//ALL_CLIENT
	public Int32 MoveSpeed1;//
	public Int32 MoveSpeed2;//
	public Int32 MoveSpeed3;//
	public Int32 MoveSpeed4;//
	public Int32 MoveSpeed5;//
	public Int32 CriticalHit0;//OWN_CLIENT
	public Int32 CriticalHit1;//
	public Int32 CriticalHit2;//
	public Int32 CriticalHit3;//
	public Int32 CriticalHit4;//
	public Int32 CriticalHit5;//
	public Int32 CriticalMiss0;//OWN_CLIENT
	public Int32 CriticalMiss1;//
	public Int32 CriticalMiss2;//
	public Int32 CriticalMiss3;//
	public Int32 CriticalMiss4;//
	public Int32 CriticalMiss5;//
	public Int32 CriticalHitRate0;//OWN_CLIENT
	public Int32 CriticalHitRate1;//
	public Int32 CriticalHitRate2;//
	public Int32 CriticalHitRate3;//
	public Int32 CriticalHitRate4;//
	public Int32 CriticalHitRate5;//
	public Int32 CriticalMissRate0;//OWN_CLIENT
	public Int32 CriticalMissRate1;//
	public Int32 CriticalMissRate2;//
	public Int32 CriticalMissRate3;//
	public Int32 CriticalMissRate4;//
	public Int32 CriticalMissRate5;//
	public Int32 CriticalDamageAttack0;//OWN_CLIENT
	public Int32 CriticalDamageAttack1;//
	public Int32 CriticalDamageAttack2;//
	public Int32 CriticalDamageAttack3;//
	public Int32 CriticalDamageAttack4;//
	public Int32 CriticalDamageAttack5;//
	public Int32 CriticalDamageDefence0;//OWN_CLIENT
	public Int32 CriticalDamageDefence1;//
	public Int32 CriticalDamageDefence2;//
	public Int32 CriticalDamageDefence3;//
	public Int32 CriticalDamageDefence4;//
	public Int32 CriticalDamageDefence5;//
	public Int32 Penetrate0;//OWN_CLIENT
	public Int32 Penetrate1;//
	public Int32 Penetrate2;//
	public Int32 Penetrate3;//
	public Int32 Penetrate4;//
	public Int32 Penetrate5;//
	public Int32 AttackVampire0;//OWN_CLIENT
	public Int32 AttackVampire1;//
	public Int32 AttackVampire2;//
	public Int32 AttackVampire3;//
	public Int32 AttackVampire4;//
	public Int32 AttackVampire5;//
	public Int32 AttackSpeedMultiply0;//OWN_CLIENT
	public Int32 AttackSpeedMultiply1;//
	public Int32 AttackSpeedMultiply2;//
	public Int32 AttackSpeedMultiply3;//
	public Int32 AttackSpeedMultiply4;//
	public Int32 AttackSpeedMultiply5;//
	public new void Read(ViIStream IS)
	{
		base.Read(IS);
		ViGameSerializer<Int16>.Read(IS, out Level);
		ViGameSerializer<UInt32>.Read(IS, out FocusEntity);
		ViGameSerializer<UInt8>.Read(IS, out Faction);
		ViGameSerializer<UInt64PtrProperty>.Read(IS, out Team);
		ViGameSerializer<UInt32>.Read(IS, out Owner);
		ViGameSerializer<TimeProperty>.Read(IS, out SpellCDList);
		ViGameSerializer<ViString>.Read(IS, out ScriptList);
		ViGameSerializer<Int64Property>.Read(IS, out ScriptValueList);
		ViGameSerializer<Int32>.Read(IS, out DefenceCoefficient);
		ViGameSerializer<Int32>.Read(IS, out CriticalHitCoefficient);
		ViGameSerializer<Int32>.Read(IS, out CriticalDamageCoefficient);
		ViGameSerializer<Int32>.Read(IS, out ElementCoefficient);
		ViGameSerializer<Int32>.Read(IS, out None0);
		ViGameSerializer<Int32>.Read(IS, out None1);
		ViGameSerializer<Int32>.Read(IS, out None2);
		ViGameSerializer<Int32>.Read(IS, out None3);
		ViGameSerializer<Int32>.Read(IS, out None4);
		ViGameSerializer<Int32>.Read(IS, out None5);
		ViGameSerializer<Int32>.Read(IS, out ViewRange0);
		ViGameSerializer<Int32>.Read(IS, out ViewRange1);
		ViGameSerializer<Int32>.Read(IS, out ViewRange2);
		ViGameSerializer<Int32>.Read(IS, out ViewRange3);
		ViGameSerializer<Int32>.Read(IS, out ViewRange4);
		ViGameSerializer<Int32>.Read(IS, out ViewRange5);
		ViGameSerializer<Int32>.Read(IS, out VisibilityRange0);
		ViGameSerializer<Int32>.Read(IS, out VisibilityRange1);
		ViGameSerializer<Int32>.Read(IS, out VisibilityRange2);
		ViGameSerializer<Int32>.Read(IS, out VisibilityRange3);
		ViGameSerializer<Int32>.Read(IS, out VisibilityRange4);
		ViGameSerializer<Int32>.Read(IS, out VisibilityRange5);
		ViGameSerializer<Int32>.Read(IS, out AntiStealthRange0);
		ViGameSerializer<Int32>.Read(IS, out AntiStealthRange1);
		ViGameSerializer<Int32>.Read(IS, out AntiStealthRange2);
		ViGameSerializer<Int32>.Read(IS, out AntiStealthRange3);
		ViGameSerializer<Int32>.Read(IS, out AntiStealthRange4);
		ViGameSerializer<Int32>.Read(IS, out AntiStealthRange5);
		ViGameSerializer<Int32>.Read(IS, out HPPercent);
		ViGameSerializer<Int32>.Read(IS, out HP);
		ViGameSerializer<Int32>.Read(IS, out MP);
		ViGameSerializer<Int32>.Read(IS, out SP);
		ViGameSerializer<Int32>.Read(IS, out HPMax0);
		ViGameSerializer<Int32>.Read(IS, out HPMax1);
		ViGameSerializer<Int32>.Read(IS, out HPMax2);
		ViGameSerializer<Int32>.Read(IS, out HPMax3);
		ViGameSerializer<Int32>.Read(IS, out HPMax4);
		ViGameSerializer<Int32>.Read(IS, out HPMax5);
		ViGameSerializer<Int32>.Read(IS, out MPMax0);
		ViGameSerializer<Int32>.Read(IS, out MPMax1);
		ViGameSerializer<Int32>.Read(IS, out MPMax2);
		ViGameSerializer<Int32>.Read(IS, out MPMax3);
		ViGameSerializer<Int32>.Read(IS, out MPMax4);
		ViGameSerializer<Int32>.Read(IS, out MPMax5);
		ViGameSerializer<Int32>.Read(IS, out SPMax0);
		ViGameSerializer<Int32>.Read(IS, out SPMax1);
		ViGameSerializer<Int32>.Read(IS, out SPMax2);
		ViGameSerializer<Int32>.Read(IS, out SPMax3);
		ViGameSerializer<Int32>.Read(IS, out SPMax4);
		ViGameSerializer<Int32>.Read(IS, out SPMax5);
		ViGameSerializer<Int32>.Read(IS, out HPRegenerate0);
		ViGameSerializer<Int32>.Read(IS, out HPRegenerate1);
		ViGameSerializer<Int32>.Read(IS, out HPRegenerate2);
		ViGameSerializer<Int32>.Read(IS, out HPRegenerate3);
		ViGameSerializer<Int32>.Read(IS, out HPRegenerate4);
		ViGameSerializer<Int32>.Read(IS, out HPRegenerate5);
		ViGameSerializer<Int32>.Read(IS, out MPRegenerate0);
		ViGameSerializer<Int32>.Read(IS, out MPRegenerate1);
		ViGameSerializer<Int32>.Read(IS, out MPRegenerate2);
		ViGameSerializer<Int32>.Read(IS, out MPRegenerate3);
		ViGameSerializer<Int32>.Read(IS, out MPRegenerate4);
		ViGameSerializer<Int32>.Read(IS, out MPRegenerate5);
		ViGameSerializer<Int32>.Read(IS, out SPRegenerate0);
		ViGameSerializer<Int32>.Read(IS, out SPRegenerate1);
		ViGameSerializer<Int32>.Read(IS, out SPRegenerate2);
		ViGameSerializer<Int32>.Read(IS, out SPRegenerate3);
		ViGameSerializer<Int32>.Read(IS, out SPRegenerate4);
		ViGameSerializer<Int32>.Read(IS, out SPRegenerate5);
		ViGameSerializer<Int32>.Read(IS, out PhysicsAttack0);
		ViGameSerializer<Int32>.Read(IS, out PhysicsAttack1);
		ViGameSerializer<Int32>.Read(IS, out PhysicsAttack2);
		ViGameSerializer<Int32>.Read(IS, out PhysicsAttack3);
		ViGameSerializer<Int32>.Read(IS, out PhysicsAttack4);
		ViGameSerializer<Int32>.Read(IS, out PhysicsAttack5);
		ViGameSerializer<Int32>.Read(IS, out PhysicsDefence0);
		ViGameSerializer<Int32>.Read(IS, out PhysicsDefence1);
		ViGameSerializer<Int32>.Read(IS, out PhysicsDefence2);
		ViGameSerializer<Int32>.Read(IS, out PhysicsDefence3);
		ViGameSerializer<Int32>.Read(IS, out PhysicsDefence4);
		ViGameSerializer<Int32>.Read(IS, out PhysicsDefence5);
		ViGameSerializer<Int32>.Read(IS, out MagicAttack0);
		ViGameSerializer<Int32>.Read(IS, out MagicAttack1);
		ViGameSerializer<Int32>.Read(IS, out MagicAttack2);
		ViGameSerializer<Int32>.Read(IS, out MagicAttack3);
		ViGameSerializer<Int32>.Read(IS, out MagicAttack4);
		ViGameSerializer<Int32>.Read(IS, out MagicAttack5);
		ViGameSerializer<Int32>.Read(IS, out MagicDefence0);
		ViGameSerializer<Int32>.Read(IS, out MagicDefence1);
		ViGameSerializer<Int32>.Read(IS, out MagicDefence2);
		ViGameSerializer<Int32>.Read(IS, out MagicDefence3);
		ViGameSerializer<Int32>.Read(IS, out MagicDefence4);
		ViGameSerializer<Int32>.Read(IS, out MagicDefence5);
		ViGameSerializer<Int32>.Read(IS, out MoveSpeed0);
		ViGameSerializer<Int32>.Read(IS, out MoveSpeed1);
		ViGameSerializer<Int32>.Read(IS, out MoveSpeed2);
		ViGameSerializer<Int32>.Read(IS, out MoveSpeed3);
		ViGameSerializer<Int32>.Read(IS, out MoveSpeed4);
		ViGameSerializer<Int32>.Read(IS, out MoveSpeed5);
		ViGameSerializer<Int32>.Read(IS, out CriticalHit0);
		ViGameSerializer<Int32>.Read(IS, out CriticalHit1);
		ViGameSerializer<Int32>.Read(IS, out CriticalHit2);
		ViGameSerializer<Int32>.Read(IS, out CriticalHit3);
		ViGameSerializer<Int32>.Read(IS, out CriticalHit4);
		ViGameSerializer<Int32>.Read(IS, out CriticalHit5);
		ViGameSerializer<Int32>.Read(IS, out CriticalMiss0);
		ViGameSerializer<Int32>.Read(IS, out CriticalMiss1);
		ViGameSerializer<Int32>.Read(IS, out CriticalMiss2);
		ViGameSerializer<Int32>.Read(IS, out CriticalMiss3);
		ViGameSerializer<Int32>.Read(IS, out CriticalMiss4);
		ViGameSerializer<Int32>.Read(IS, out CriticalMiss5);
		ViGameSerializer<Int32>.Read(IS, out CriticalHitRate0);
		ViGameSerializer<Int32>.Read(IS, out CriticalHitRate1);
		ViGameSerializer<Int32>.Read(IS, out CriticalHitRate2);
		ViGameSerializer<Int32>.Read(IS, out CriticalHitRate3);
		ViGameSerializer<Int32>.Read(IS, out CriticalHitRate4);
		ViGameSerializer<Int32>.Read(IS, out CriticalHitRate5);
		ViGameSerializer<Int32>.Read(IS, out CriticalMissRate0);
		ViGameSerializer<Int32>.Read(IS, out CriticalMissRate1);
		ViGameSerializer<Int32>.Read(IS, out CriticalMissRate2);
		ViGameSerializer<Int32>.Read(IS, out CriticalMissRate3);
		ViGameSerializer<Int32>.Read(IS, out CriticalMissRate4);
		ViGameSerializer<Int32>.Read(IS, out CriticalMissRate5);
		ViGameSerializer<Int32>.Read(IS, out CriticalDamageAttack0);
		ViGameSerializer<Int32>.Read(IS, out CriticalDamageAttack1);
		ViGameSerializer<Int32>.Read(IS, out CriticalDamageAttack2);
		ViGameSerializer<Int32>.Read(IS, out CriticalDamageAttack3);
		ViGameSerializer<Int32>.Read(IS, out CriticalDamageAttack4);
		ViGameSerializer<Int32>.Read(IS, out CriticalDamageAttack5);
		ViGameSerializer<Int32>.Read(IS, out CriticalDamageDefence0);
		ViGameSerializer<Int32>.Read(IS, out CriticalDamageDefence1);
		ViGameSerializer<Int32>.Read(IS, out CriticalDamageDefence2);
		ViGameSerializer<Int32>.Read(IS, out CriticalDamageDefence3);
		ViGameSerializer<Int32>.Read(IS, out CriticalDamageDefence4);
		ViGameSerializer<Int32>.Read(IS, out CriticalDamageDefence5);
		ViGameSerializer<Int32>.Read(IS, out Penetrate0);
		ViGameSerializer<Int32>.Read(IS, out Penetrate1);
		ViGameSerializer<Int32>.Read(IS, out Penetrate2);
		ViGameSerializer<Int32>.Read(IS, out Penetrate3);
		ViGameSerializer<Int32>.Read(IS, out Penetrate4);
		ViGameSerializer<Int32>.Read(IS, out Penetrate5);
		ViGameSerializer<Int32>.Read(IS, out AttackVampire0);
		ViGameSerializer<Int32>.Read(IS, out AttackVampire1);
		ViGameSerializer<Int32>.Read(IS, out AttackVampire2);
		ViGameSerializer<Int32>.Read(IS, out AttackVampire3);
		ViGameSerializer<Int32>.Read(IS, out AttackVampire4);
		ViGameSerializer<Int32>.Read(IS, out AttackVampire5);
		ViGameSerializer<Int32>.Read(IS, out AttackSpeedMultiply0);
		ViGameSerializer<Int32>.Read(IS, out AttackSpeedMultiply1);
		ViGameSerializer<Int32>.Read(IS, out AttackSpeedMultiply2);
		ViGameSerializer<Int32>.Read(IS, out AttackSpeedMultiply3);
		ViGameSerializer<Int32>.Read(IS, out AttackSpeedMultiply4);
		ViGameSerializer<Int32>.Read(IS, out AttackSpeedMultiply5);
	}
	public new void Print(string head, ViStringDictionaryStream OS)
	{
		base.Print(head, OS);
		ViGameSerializer<Int16>.Append(OS, head + "Level", Level);
		ViGameSerializer<UInt32>.Append(OS, head + "FocusEntity", FocusEntity);
		ViGameSerializer<UInt8>.Append(OS, head + "Faction", Faction);
		ViGameSerializer<UInt64PtrProperty>.Append(OS, head + "Team", Team);
		ViGameSerializer<UInt32>.Append(OS, head + "Owner", Owner);
		ViGameSerializer<TimeProperty>.Append(OS, head + "SpellCDList", SpellCDList);
		ViGameSerializer<ViString>.Append(OS, head + "ScriptList", ScriptList);
		ViGameSerializer<Int64Property>.Append(OS, head + "ScriptValueList", ScriptValueList);
		ViGameSerializer<Int32>.Append(OS, head + "DefenceCoefficient", DefenceCoefficient);
		ViGameSerializer<Int32>.Append(OS, head + "CriticalHitCoefficient", CriticalHitCoefficient);
		ViGameSerializer<Int32>.Append(OS, head + "CriticalDamageCoefficient", CriticalDamageCoefficient);
		ViGameSerializer<Int32>.Append(OS, head + "ElementCoefficient", ElementCoefficient);
		ViGameSerializer<Int32>.Append(OS, head + "None0", None0);
		ViGameSerializer<Int32>.Append(OS, head + "None1", None1);
		ViGameSerializer<Int32>.Append(OS, head + "None2", None2);
		ViGameSerializer<Int32>.Append(OS, head + "None3", None3);
		ViGameSerializer<Int32>.Append(OS, head + "None4", None4);
		ViGameSerializer<Int32>.Append(OS, head + "None5", None5);
		ViGameSerializer<Int32>.Append(OS, head + "ViewRange0", ViewRange0);
		ViGameSerializer<Int32>.Append(OS, head + "ViewRange1", ViewRange1);
		ViGameSerializer<Int32>.Append(OS, head + "ViewRange2", ViewRange2);
		ViGameSerializer<Int32>.Append(OS, head + "ViewRange3", ViewRange3);
		ViGameSerializer<Int32>.Append(OS, head + "ViewRange4", ViewRange4);
		ViGameSerializer<Int32>.Append(OS, head + "ViewRange5", ViewRange5);
		ViGameSerializer<Int32>.Append(OS, head + "VisibilityRange0", VisibilityRange0);
		ViGameSerializer<Int32>.Append(OS, head + "VisibilityRange1", VisibilityRange1);
		ViGameSerializer<Int32>.Append(OS, head + "VisibilityRange2", VisibilityRange2);
		ViGameSerializer<Int32>.Append(OS, head + "VisibilityRange3", VisibilityRange3);
		ViGameSerializer<Int32>.Append(OS, head + "VisibilityRange4", VisibilityRange4);
		ViGameSerializer<Int32>.Append(OS, head + "VisibilityRange5", VisibilityRange5);
		ViGameSerializer<Int32>.Append(OS, head + "AntiStealthRange0", AntiStealthRange0);
		ViGameSerializer<Int32>.Append(OS, head + "AntiStealthRange1", AntiStealthRange1);
		ViGameSerializer<Int32>.Append(OS, head + "AntiStealthRange2", AntiStealthRange2);
		ViGameSerializer<Int32>.Append(OS, head + "AntiStealthRange3", AntiStealthRange3);
		ViGameSerializer<Int32>.Append(OS, head + "AntiStealthRange4", AntiStealthRange4);
		ViGameSerializer<Int32>.Append(OS, head + "AntiStealthRange5", AntiStealthRange5);
		ViGameSerializer<Int32>.Append(OS, head + "HPPercent", HPPercent);
		ViGameSerializer<Int32>.Append(OS, head + "HP", HP);
		ViGameSerializer<Int32>.Append(OS, head + "MP", MP);
		ViGameSerializer<Int32>.Append(OS, head + "SP", SP);
		ViGameSerializer<Int32>.Append(OS, head + "HPMax0", HPMax0);
		ViGameSerializer<Int32>.Append(OS, head + "HPMax1", HPMax1);
		ViGameSerializer<Int32>.Append(OS, head + "HPMax2", HPMax2);
		ViGameSerializer<Int32>.Append(OS, head + "HPMax3", HPMax3);
		ViGameSerializer<Int32>.Append(OS, head + "HPMax4", HPMax4);
		ViGameSerializer<Int32>.Append(OS, head + "HPMax5", HPMax5);
		ViGameSerializer<Int32>.Append(OS, head + "MPMax0", MPMax0);
		ViGameSerializer<Int32>.Append(OS, head + "MPMax1", MPMax1);
		ViGameSerializer<Int32>.Append(OS, head + "MPMax2", MPMax2);
		ViGameSerializer<Int32>.Append(OS, head + "MPMax3", MPMax3);
		ViGameSerializer<Int32>.Append(OS, head + "MPMax4", MPMax4);
		ViGameSerializer<Int32>.Append(OS, head + "MPMax5", MPMax5);
		ViGameSerializer<Int32>.Append(OS, head + "SPMax0", SPMax0);
		ViGameSerializer<Int32>.Append(OS, head + "SPMax1", SPMax1);
		ViGameSerializer<Int32>.Append(OS, head + "SPMax2", SPMax2);
		ViGameSerializer<Int32>.Append(OS, head + "SPMax3", SPMax3);
		ViGameSerializer<Int32>.Append(OS, head + "SPMax4", SPMax4);
		ViGameSerializer<Int32>.Append(OS, head + "SPMax5", SPMax5);
		ViGameSerializer<Int32>.Append(OS, head + "HPRegenerate0", HPRegenerate0);
		ViGameSerializer<Int32>.Append(OS, head + "HPRegenerate1", HPRegenerate1);
		ViGameSerializer<Int32>.Append(OS, head + "HPRegenerate2", HPRegenerate2);
		ViGameSerializer<Int32>.Append(OS, head + "HPRegenerate3", HPRegenerate3);
		ViGameSerializer<Int32>.Append(OS, head + "HPRegenerate4", HPRegenerate4);
		ViGameSerializer<Int32>.Append(OS, head + "HPRegenerate5", HPRegenerate5);
		ViGameSerializer<Int32>.Append(OS, head + "MPRegenerate0", MPRegenerate0);
		ViGameSerializer<Int32>.Append(OS, head + "MPRegenerate1", MPRegenerate1);
		ViGameSerializer<Int32>.Append(OS, head + "MPRegenerate2", MPRegenerate2);
		ViGameSerializer<Int32>.Append(OS, head + "MPRegenerate3", MPRegenerate3);
		ViGameSerializer<Int32>.Append(OS, head + "MPRegenerate4", MPRegenerate4);
		ViGameSerializer<Int32>.Append(OS, head + "MPRegenerate5", MPRegenerate5);
		ViGameSerializer<Int32>.Append(OS, head + "SPRegenerate0", SPRegenerate0);
		ViGameSerializer<Int32>.Append(OS, head + "SPRegenerate1", SPRegenerate1);
		ViGameSerializer<Int32>.Append(OS, head + "SPRegenerate2", SPRegenerate2);
		ViGameSerializer<Int32>.Append(OS, head + "SPRegenerate3", SPRegenerate3);
		ViGameSerializer<Int32>.Append(OS, head + "SPRegenerate4", SPRegenerate4);
		ViGameSerializer<Int32>.Append(OS, head + "SPRegenerate5", SPRegenerate5);
		ViGameSerializer<Int32>.Append(OS, head + "PhysicsAttack0", PhysicsAttack0);
		ViGameSerializer<Int32>.Append(OS, head + "PhysicsAttack1", PhysicsAttack1);
		ViGameSerializer<Int32>.Append(OS, head + "PhysicsAttack2", PhysicsAttack2);
		ViGameSerializer<Int32>.Append(OS, head + "PhysicsAttack3", PhysicsAttack3);
		ViGameSerializer<Int32>.Append(OS, head + "PhysicsAttack4", PhysicsAttack4);
		ViGameSerializer<Int32>.Append(OS, head + "PhysicsAttack5", PhysicsAttack5);
		ViGameSerializer<Int32>.Append(OS, head + "PhysicsDefence0", PhysicsDefence0);
		ViGameSerializer<Int32>.Append(OS, head + "PhysicsDefence1", PhysicsDefence1);
		ViGameSerializer<Int32>.Append(OS, head + "PhysicsDefence2", PhysicsDefence2);
		ViGameSerializer<Int32>.Append(OS, head + "PhysicsDefence3", PhysicsDefence3);
		ViGameSerializer<Int32>.Append(OS, head + "PhysicsDefence4", PhysicsDefence4);
		ViGameSerializer<Int32>.Append(OS, head + "PhysicsDefence5", PhysicsDefence5);
		ViGameSerializer<Int32>.Append(OS, head + "MagicAttack0", MagicAttack0);
		ViGameSerializer<Int32>.Append(OS, head + "MagicAttack1", MagicAttack1);
		ViGameSerializer<Int32>.Append(OS, head + "MagicAttack2", MagicAttack2);
		ViGameSerializer<Int32>.Append(OS, head + "MagicAttack3", MagicAttack3);
		ViGameSerializer<Int32>.Append(OS, head + "MagicAttack4", MagicAttack4);
		ViGameSerializer<Int32>.Append(OS, head + "MagicAttack5", MagicAttack5);
		ViGameSerializer<Int32>.Append(OS, head + "MagicDefence0", MagicDefence0);
		ViGameSerializer<Int32>.Append(OS, head + "MagicDefence1", MagicDefence1);
		ViGameSerializer<Int32>.Append(OS, head + "MagicDefence2", MagicDefence2);
		ViGameSerializer<Int32>.Append(OS, head + "MagicDefence3", MagicDefence3);
		ViGameSerializer<Int32>.Append(OS, head + "MagicDefence4", MagicDefence4);
		ViGameSerializer<Int32>.Append(OS, head + "MagicDefence5", MagicDefence5);
		ViGameSerializer<Int32>.Append(OS, head + "MoveSpeed0", MoveSpeed0);
		ViGameSerializer<Int32>.Append(OS, head + "MoveSpeed1", MoveSpeed1);
		ViGameSerializer<Int32>.Append(OS, head + "MoveSpeed2", MoveSpeed2);
		ViGameSerializer<Int32>.Append(OS, head + "MoveSpeed3", MoveSpeed3);
		ViGameSerializer<Int32>.Append(OS, head + "MoveSpeed4", MoveSpeed4);
		ViGameSerializer<Int32>.Append(OS, head + "MoveSpeed5", MoveSpeed5);
		ViGameSerializer<Int32>.Append(OS, head + "CriticalHit0", CriticalHit0);
		ViGameSerializer<Int32>.Append(OS, head + "CriticalHit1", CriticalHit1);
		ViGameSerializer<Int32>.Append(OS, head + "CriticalHit2", CriticalHit2);
		ViGameSerializer<Int32>.Append(OS, head + "CriticalHit3", CriticalHit3);
		ViGameSerializer<Int32>.Append(OS, head + "CriticalHit4", CriticalHit4);
		ViGameSerializer<Int32>.Append(OS, head + "CriticalHit5", CriticalHit5);
		ViGameSerializer<Int32>.Append(OS, head + "CriticalMiss0", CriticalMiss0);
		ViGameSerializer<Int32>.Append(OS, head + "CriticalMiss1", CriticalMiss1);
		ViGameSerializer<Int32>.Append(OS, head + "CriticalMiss2", CriticalMiss2);
		ViGameSerializer<Int32>.Append(OS, head + "CriticalMiss3", CriticalMiss3);
		ViGameSerializer<Int32>.Append(OS, head + "CriticalMiss4", CriticalMiss4);
		ViGameSerializer<Int32>.Append(OS, head + "CriticalMiss5", CriticalMiss5);
		ViGameSerializer<Int32>.Append(OS, head + "CriticalHitRate0", CriticalHitRate0);
		ViGameSerializer<Int32>.Append(OS, head + "CriticalHitRate1", CriticalHitRate1);
		ViGameSerializer<Int32>.Append(OS, head + "CriticalHitRate2", CriticalHitRate2);
		ViGameSerializer<Int32>.Append(OS, head + "CriticalHitRate3", CriticalHitRate3);
		ViGameSerializer<Int32>.Append(OS, head + "CriticalHitRate4", CriticalHitRate4);
		ViGameSerializer<Int32>.Append(OS, head + "CriticalHitRate5", CriticalHitRate5);
		ViGameSerializer<Int32>.Append(OS, head + "CriticalMissRate0", CriticalMissRate0);
		ViGameSerializer<Int32>.Append(OS, head + "CriticalMissRate1", CriticalMissRate1);
		ViGameSerializer<Int32>.Append(OS, head + "CriticalMissRate2", CriticalMissRate2);
		ViGameSerializer<Int32>.Append(OS, head + "CriticalMissRate3", CriticalMissRate3);
		ViGameSerializer<Int32>.Append(OS, head + "CriticalMissRate4", CriticalMissRate4);
		ViGameSerializer<Int32>.Append(OS, head + "CriticalMissRate5", CriticalMissRate5);
		ViGameSerializer<Int32>.Append(OS, head + "CriticalDamageAttack0", CriticalDamageAttack0);
		ViGameSerializer<Int32>.Append(OS, head + "CriticalDamageAttack1", CriticalDamageAttack1);
		ViGameSerializer<Int32>.Append(OS, head + "CriticalDamageAttack2", CriticalDamageAttack2);
		ViGameSerializer<Int32>.Append(OS, head + "CriticalDamageAttack3", CriticalDamageAttack3);
		ViGameSerializer<Int32>.Append(OS, head + "CriticalDamageAttack4", CriticalDamageAttack4);
		ViGameSerializer<Int32>.Append(OS, head + "CriticalDamageAttack5", CriticalDamageAttack5);
		ViGameSerializer<Int32>.Append(OS, head + "CriticalDamageDefence0", CriticalDamageDefence0);
		ViGameSerializer<Int32>.Append(OS, head + "CriticalDamageDefence1", CriticalDamageDefence1);
		ViGameSerializer<Int32>.Append(OS, head + "CriticalDamageDefence2", CriticalDamageDefence2);
		ViGameSerializer<Int32>.Append(OS, head + "CriticalDamageDefence3", CriticalDamageDefence3);
		ViGameSerializer<Int32>.Append(OS, head + "CriticalDamageDefence4", CriticalDamageDefence4);
		ViGameSerializer<Int32>.Append(OS, head + "CriticalDamageDefence5", CriticalDamageDefence5);
		ViGameSerializer<Int32>.Append(OS, head + "Penetrate0", Penetrate0);
		ViGameSerializer<Int32>.Append(OS, head + "Penetrate1", Penetrate1);
		ViGameSerializer<Int32>.Append(OS, head + "Penetrate2", Penetrate2);
		ViGameSerializer<Int32>.Append(OS, head + "Penetrate3", Penetrate3);
		ViGameSerializer<Int32>.Append(OS, head + "Penetrate4", Penetrate4);
		ViGameSerializer<Int32>.Append(OS, head + "Penetrate5", Penetrate5);
		ViGameSerializer<Int32>.Append(OS, head + "AttackVampire0", AttackVampire0);
		ViGameSerializer<Int32>.Append(OS, head + "AttackVampire1", AttackVampire1);
		ViGameSerializer<Int32>.Append(OS, head + "AttackVampire2", AttackVampire2);
		ViGameSerializer<Int32>.Append(OS, head + "AttackVampire3", AttackVampire3);
		ViGameSerializer<Int32>.Append(OS, head + "AttackVampire4", AttackVampire4);
		ViGameSerializer<Int32>.Append(OS, head + "AttackVampire5", AttackVampire5);
		ViGameSerializer<Int32>.Append(OS, head + "AttackSpeedMultiply0", AttackSpeedMultiply0);
		ViGameSerializer<Int32>.Append(OS, head + "AttackSpeedMultiply1", AttackSpeedMultiply1);
		ViGameSerializer<Int32>.Append(OS, head + "AttackSpeedMultiply2", AttackSpeedMultiply2);
		ViGameSerializer<Int32>.Append(OS, head + "AttackSpeedMultiply3", AttackSpeedMultiply3);
		ViGameSerializer<Int32>.Append(OS, head + "AttackSpeedMultiply4", AttackSpeedMultiply4);
		ViGameSerializer<Int32>.Append(OS, head + "AttackSpeedMultiply5", AttackSpeedMultiply5);
	}
}

public class GameUnitReceiveProperty : ViGameUnitReceiveProperty
{
	public static readonly new int TYPE_SIZE = ViGameUnitReceiveProperty.TYPE_SIZE + 160;
	public static readonly new int INDEX_PROPERTY_COUNT = ViGameUnitReceiveProperty.INDEX_PROPERTY_COUNT + 148;
	//
	public ViReceiveDataInt16 Level = new ViReceiveDataInt16();//ALL_CLIENT
	public ViReceiveDataUInt32 FocusEntity = new ViReceiveDataUInt32();//OWN_CLIENT
	public ViReceiveDataUInt8 Faction = new ViReceiveDataUInt8();//ALL_CLIENT+CENTER
	public ReceiveDataUInt64PtrProperty Team = new ReceiveDataUInt64PtrProperty();//ALL_CLIENT
	public ViReceiveDataUInt32 Owner = new ViReceiveDataUInt32();//ALL_CLIENT
	public ViReceiveDataDictionary<UInt32, ReceiveDataTimeProperty, TimeProperty> SpellCDList = new ViReceiveDataDictionary<UInt32, ReceiveDataTimeProperty, TimeProperty>();//OWN_CLIENT
	public ViReceiveDataSet<ViString> ScriptList = new ViReceiveDataSet<ViString>();//ALL_CLIENT
	public ViReceiveDataDictionary<ViString, ReceiveDataInt64Property, Int64Property> ScriptValueList = new ViReceiveDataDictionary<ViString, ReceiveDataInt64Property, Int64Property>();//ALL_CLIENT
	public ViReceiveDataInt32 DefenceCoefficient = new ViReceiveDataInt32();//ALL_CLIENT
	public ViReceiveDataInt32 CriticalHitCoefficient = new ViReceiveDataInt32();//ALL_CLIENT
	public ViReceiveDataInt32 CriticalDamageCoefficient = new ViReceiveDataInt32();//ALL_CLIENT
	public ViReceiveDataInt32 ElementCoefficient = new ViReceiveDataInt32();//ALL_CLIENT
	private ViReceiveDataInt32 None0 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 None1 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 None2 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 None3 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 None4 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 None5 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 ViewRange0 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 ViewRange1 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 ViewRange2 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 ViewRange3 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 ViewRange4 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 ViewRange5 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 VisibilityRange0 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 VisibilityRange1 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 VisibilityRange2 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 VisibilityRange3 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 VisibilityRange4 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 VisibilityRange5 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 AntiStealthRange0 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 AntiStealthRange1 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 AntiStealthRange2 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 AntiStealthRange3 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 AntiStealthRange4 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 AntiStealthRange5 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 HPPercent = new ViReceiveDataInt32();//
	public ViReceiveDataInt32 HP = new ViReceiveDataInt32();//ALL_CLIENT+CENTER
	public ViReceiveDataInt32 MP = new ViReceiveDataInt32();//ALL_CLIENT
	public ViReceiveDataInt32 SP = new ViReceiveDataInt32();//ALL_CLIENT
	public ViReceiveDataInt32 HPMax0 = new ViReceiveDataInt32();//ALL_CLIENT+CENTER
	private ViReceiveDataInt32 HPMax1 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 HPMax2 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 HPMax3 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 HPMax4 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 HPMax5 = new ViReceiveDataInt32();//
	public ViReceiveDataInt32 MPMax0 = new ViReceiveDataInt32();//ALL_CLIENT+CENTER
	private ViReceiveDataInt32 MPMax1 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 MPMax2 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 MPMax3 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 MPMax4 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 MPMax5 = new ViReceiveDataInt32();//
	public ViReceiveDataInt32 SPMax0 = new ViReceiveDataInt32();//ALL_CLIENT+CENTER
	private ViReceiveDataInt32 SPMax1 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 SPMax2 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 SPMax3 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 SPMax4 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 SPMax5 = new ViReceiveDataInt32();//
	public ViReceiveDataInt32 HPRegenerate0 = new ViReceiveDataInt32();//OWN_CLIENT
	private ViReceiveDataInt32 HPRegenerate1 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 HPRegenerate2 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 HPRegenerate3 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 HPRegenerate4 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 HPRegenerate5 = new ViReceiveDataInt32();//
	public ViReceiveDataInt32 MPRegenerate0 = new ViReceiveDataInt32();//OWN_CLIENT
	private ViReceiveDataInt32 MPRegenerate1 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 MPRegenerate2 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 MPRegenerate3 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 MPRegenerate4 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 MPRegenerate5 = new ViReceiveDataInt32();//
	public ViReceiveDataInt32 SPRegenerate0 = new ViReceiveDataInt32();//OWN_CLIENT
	private ViReceiveDataInt32 SPRegenerate1 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 SPRegenerate2 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 SPRegenerate3 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 SPRegenerate4 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 SPRegenerate5 = new ViReceiveDataInt32();//
	public ViReceiveDataInt32 PhysicsAttack0 = new ViReceiveDataInt32();//OWN_CLIENT
	private ViReceiveDataInt32 PhysicsAttack1 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 PhysicsAttack2 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 PhysicsAttack3 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 PhysicsAttack4 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 PhysicsAttack5 = new ViReceiveDataInt32();//
	public ViReceiveDataInt32 PhysicsDefence0 = new ViReceiveDataInt32();//OWN_CLIENT
	private ViReceiveDataInt32 PhysicsDefence1 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 PhysicsDefence2 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 PhysicsDefence3 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 PhysicsDefence4 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 PhysicsDefence5 = new ViReceiveDataInt32();//
	public ViReceiveDataInt32 MagicAttack0 = new ViReceiveDataInt32();//OWN_CLIENT
	private ViReceiveDataInt32 MagicAttack1 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 MagicAttack2 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 MagicAttack3 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 MagicAttack4 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 MagicAttack5 = new ViReceiveDataInt32();//
	public ViReceiveDataInt32 MagicDefence0 = new ViReceiveDataInt32();//OWN_CLIENT
	private ViReceiveDataInt32 MagicDefence1 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 MagicDefence2 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 MagicDefence3 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 MagicDefence4 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 MagicDefence5 = new ViReceiveDataInt32();//
	public ViReceiveDataInt32 MoveSpeed0 = new ViReceiveDataInt32();//ALL_CLIENT
	private ViReceiveDataInt32 MoveSpeed1 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 MoveSpeed2 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 MoveSpeed3 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 MoveSpeed4 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 MoveSpeed5 = new ViReceiveDataInt32();//
	public ViReceiveDataInt32 CriticalHit0 = new ViReceiveDataInt32();//OWN_CLIENT
	private ViReceiveDataInt32 CriticalHit1 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 CriticalHit2 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 CriticalHit3 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 CriticalHit4 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 CriticalHit5 = new ViReceiveDataInt32();//
	public ViReceiveDataInt32 CriticalMiss0 = new ViReceiveDataInt32();//OWN_CLIENT
	private ViReceiveDataInt32 CriticalMiss1 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 CriticalMiss2 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 CriticalMiss3 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 CriticalMiss4 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 CriticalMiss5 = new ViReceiveDataInt32();//
	public ViReceiveDataInt32 CriticalHitRate0 = new ViReceiveDataInt32();//OWN_CLIENT
	private ViReceiveDataInt32 CriticalHitRate1 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 CriticalHitRate2 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 CriticalHitRate3 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 CriticalHitRate4 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 CriticalHitRate5 = new ViReceiveDataInt32();//
	public ViReceiveDataInt32 CriticalMissRate0 = new ViReceiveDataInt32();//OWN_CLIENT
	private ViReceiveDataInt32 CriticalMissRate1 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 CriticalMissRate2 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 CriticalMissRate3 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 CriticalMissRate4 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 CriticalMissRate5 = new ViReceiveDataInt32();//
	public ViReceiveDataInt32 CriticalDamageAttack0 = new ViReceiveDataInt32();//OWN_CLIENT
	private ViReceiveDataInt32 CriticalDamageAttack1 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 CriticalDamageAttack2 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 CriticalDamageAttack3 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 CriticalDamageAttack4 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 CriticalDamageAttack5 = new ViReceiveDataInt32();//
	public ViReceiveDataInt32 CriticalDamageDefence0 = new ViReceiveDataInt32();//OWN_CLIENT
	private ViReceiveDataInt32 CriticalDamageDefence1 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 CriticalDamageDefence2 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 CriticalDamageDefence3 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 CriticalDamageDefence4 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 CriticalDamageDefence5 = new ViReceiveDataInt32();//
	public ViReceiveDataInt32 Penetrate0 = new ViReceiveDataInt32();//OWN_CLIENT
	private ViReceiveDataInt32 Penetrate1 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 Penetrate2 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 Penetrate3 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 Penetrate4 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 Penetrate5 = new ViReceiveDataInt32();//
	public ViReceiveDataInt32 AttackVampire0 = new ViReceiveDataInt32();//OWN_CLIENT
	private ViReceiveDataInt32 AttackVampire1 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 AttackVampire2 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 AttackVampire3 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 AttackVampire4 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 AttackVampire5 = new ViReceiveDataInt32();//
	public ViReceiveDataInt32 AttackSpeedMultiply0 = new ViReceiveDataInt32();//OWN_CLIENT
	private ViReceiveDataInt32 AttackSpeedMultiply1 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 AttackSpeedMultiply2 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 AttackSpeedMultiply3 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 AttackSpeedMultiply4 = new ViReceiveDataInt32();//
	private ViReceiveDataInt32 AttackSpeedMultiply5 = new ViReceiveDataInt32();//
	//
	public GameUnitReceiveProperty()
	{
		ReservePropertySize(TYPE_SIZE);
		Level.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		FocusEntity.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT)), this, ChildList);
		Faction.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT) | (1 << (int)ProjectAChannel.CENTER)), this, ChildList);
		Team.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		Owner.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		SpellCDList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT)), this, ChildList);
		ScriptList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		ScriptValueList.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		DefenceCoefficient.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		CriticalHitCoefficient.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		CriticalDamageCoefficient.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		ElementCoefficient.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		None0.RegisterAsChild((UInt16)(0), this, ChildList);
		None1.RegisterAsChild((UInt16)(0), this, ChildList);
		None2.RegisterAsChild((UInt16)(0), this, ChildList);
		None3.RegisterAsChild((UInt16)(0), this, ChildList);
		None4.RegisterAsChild((UInt16)(0), this, ChildList);
		None5.RegisterAsChild((UInt16)(0), this, ChildList);
		ViewRange0.RegisterAsChild((UInt16)(0), this, ChildList);
		ViewRange1.RegisterAsChild((UInt16)(0), this, ChildList);
		ViewRange2.RegisterAsChild((UInt16)(0), this, ChildList);
		ViewRange3.RegisterAsChild((UInt16)(0), this, ChildList);
		ViewRange4.RegisterAsChild((UInt16)(0), this, ChildList);
		ViewRange5.RegisterAsChild((UInt16)(0), this, ChildList);
		VisibilityRange0.RegisterAsChild((UInt16)(0), this, ChildList);
		VisibilityRange1.RegisterAsChild((UInt16)(0), this, ChildList);
		VisibilityRange2.RegisterAsChild((UInt16)(0), this, ChildList);
		VisibilityRange3.RegisterAsChild((UInt16)(0), this, ChildList);
		VisibilityRange4.RegisterAsChild((UInt16)(0), this, ChildList);
		VisibilityRange5.RegisterAsChild((UInt16)(0), this, ChildList);
		AntiStealthRange0.RegisterAsChild((UInt16)(0), this, ChildList);
		AntiStealthRange1.RegisterAsChild((UInt16)(0), this, ChildList);
		AntiStealthRange2.RegisterAsChild((UInt16)(0), this, ChildList);
		AntiStealthRange3.RegisterAsChild((UInt16)(0), this, ChildList);
		AntiStealthRange4.RegisterAsChild((UInt16)(0), this, ChildList);
		AntiStealthRange5.RegisterAsChild((UInt16)(0), this, ChildList);
		HPPercent.RegisterAsChild((UInt16)(0), this, ChildList);
		HP.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT) | (1 << (int)ProjectAChannel.CENTER)), this, ChildList);
		MP.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		SP.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		HPMax0.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT) | (1 << (int)ProjectAChannel.CENTER)), this, ChildList);
		HPMax1.RegisterAsChild((UInt16)(0), this, ChildList);
		HPMax2.RegisterAsChild((UInt16)(0), this, ChildList);
		HPMax3.RegisterAsChild((UInt16)(0), this, ChildList);
		HPMax4.RegisterAsChild((UInt16)(0), this, ChildList);
		HPMax5.RegisterAsChild((UInt16)(0), this, ChildList);
		MPMax0.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT) | (1 << (int)ProjectAChannel.CENTER)), this, ChildList);
		MPMax1.RegisterAsChild((UInt16)(0), this, ChildList);
		MPMax2.RegisterAsChild((UInt16)(0), this, ChildList);
		MPMax3.RegisterAsChild((UInt16)(0), this, ChildList);
		MPMax4.RegisterAsChild((UInt16)(0), this, ChildList);
		MPMax5.RegisterAsChild((UInt16)(0), this, ChildList);
		SPMax0.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT) | (1 << (int)ProjectAChannel.CENTER)), this, ChildList);
		SPMax1.RegisterAsChild((UInt16)(0), this, ChildList);
		SPMax2.RegisterAsChild((UInt16)(0), this, ChildList);
		SPMax3.RegisterAsChild((UInt16)(0), this, ChildList);
		SPMax4.RegisterAsChild((UInt16)(0), this, ChildList);
		SPMax5.RegisterAsChild((UInt16)(0), this, ChildList);
		HPRegenerate0.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT)), this, ChildList);
		HPRegenerate1.RegisterAsChild((UInt16)(0), this, ChildList);
		HPRegenerate2.RegisterAsChild((UInt16)(0), this, ChildList);
		HPRegenerate3.RegisterAsChild((UInt16)(0), this, ChildList);
		HPRegenerate4.RegisterAsChild((UInt16)(0), this, ChildList);
		HPRegenerate5.RegisterAsChild((UInt16)(0), this, ChildList);
		MPRegenerate0.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT)), this, ChildList);
		MPRegenerate1.RegisterAsChild((UInt16)(0), this, ChildList);
		MPRegenerate2.RegisterAsChild((UInt16)(0), this, ChildList);
		MPRegenerate3.RegisterAsChild((UInt16)(0), this, ChildList);
		MPRegenerate4.RegisterAsChild((UInt16)(0), this, ChildList);
		MPRegenerate5.RegisterAsChild((UInt16)(0), this, ChildList);
		SPRegenerate0.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT)), this, ChildList);
		SPRegenerate1.RegisterAsChild((UInt16)(0), this, ChildList);
		SPRegenerate2.RegisterAsChild((UInt16)(0), this, ChildList);
		SPRegenerate3.RegisterAsChild((UInt16)(0), this, ChildList);
		SPRegenerate4.RegisterAsChild((UInt16)(0), this, ChildList);
		SPRegenerate5.RegisterAsChild((UInt16)(0), this, ChildList);
		PhysicsAttack0.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT)), this, ChildList);
		PhysicsAttack1.RegisterAsChild((UInt16)(0), this, ChildList);
		PhysicsAttack2.RegisterAsChild((UInt16)(0), this, ChildList);
		PhysicsAttack3.RegisterAsChild((UInt16)(0), this, ChildList);
		PhysicsAttack4.RegisterAsChild((UInt16)(0), this, ChildList);
		PhysicsAttack5.RegisterAsChild((UInt16)(0), this, ChildList);
		PhysicsDefence0.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT)), this, ChildList);
		PhysicsDefence1.RegisterAsChild((UInt16)(0), this, ChildList);
		PhysicsDefence2.RegisterAsChild((UInt16)(0), this, ChildList);
		PhysicsDefence3.RegisterAsChild((UInt16)(0), this, ChildList);
		PhysicsDefence4.RegisterAsChild((UInt16)(0), this, ChildList);
		PhysicsDefence5.RegisterAsChild((UInt16)(0), this, ChildList);
		MagicAttack0.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT)), this, ChildList);
		MagicAttack1.RegisterAsChild((UInt16)(0), this, ChildList);
		MagicAttack2.RegisterAsChild((UInt16)(0), this, ChildList);
		MagicAttack3.RegisterAsChild((UInt16)(0), this, ChildList);
		MagicAttack4.RegisterAsChild((UInt16)(0), this, ChildList);
		MagicAttack5.RegisterAsChild((UInt16)(0), this, ChildList);
		MagicDefence0.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT)), this, ChildList);
		MagicDefence1.RegisterAsChild((UInt16)(0), this, ChildList);
		MagicDefence2.RegisterAsChild((UInt16)(0), this, ChildList);
		MagicDefence3.RegisterAsChild((UInt16)(0), this, ChildList);
		MagicDefence4.RegisterAsChild((UInt16)(0), this, ChildList);
		MagicDefence5.RegisterAsChild((UInt16)(0), this, ChildList);
		MoveSpeed0.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.ALL_CLIENT)), this, ChildList);
		MoveSpeed1.RegisterAsChild((UInt16)(0), this, ChildList);
		MoveSpeed2.RegisterAsChild((UInt16)(0), this, ChildList);
		MoveSpeed3.RegisterAsChild((UInt16)(0), this, ChildList);
		MoveSpeed4.RegisterAsChild((UInt16)(0), this, ChildList);
		MoveSpeed5.RegisterAsChild((UInt16)(0), this, ChildList);
		CriticalHit0.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT)), this, ChildList);
		CriticalHit1.RegisterAsChild((UInt16)(0), this, ChildList);
		CriticalHit2.RegisterAsChild((UInt16)(0), this, ChildList);
		CriticalHit3.RegisterAsChild((UInt16)(0), this, ChildList);
		CriticalHit4.RegisterAsChild((UInt16)(0), this, ChildList);
		CriticalHit5.RegisterAsChild((UInt16)(0), this, ChildList);
		CriticalMiss0.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT)), this, ChildList);
		CriticalMiss1.RegisterAsChild((UInt16)(0), this, ChildList);
		CriticalMiss2.RegisterAsChild((UInt16)(0), this, ChildList);
		CriticalMiss3.RegisterAsChild((UInt16)(0), this, ChildList);
		CriticalMiss4.RegisterAsChild((UInt16)(0), this, ChildList);
		CriticalMiss5.RegisterAsChild((UInt16)(0), this, ChildList);
		CriticalHitRate0.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT)), this, ChildList);
		CriticalHitRate1.RegisterAsChild((UInt16)(0), this, ChildList);
		CriticalHitRate2.RegisterAsChild((UInt16)(0), this, ChildList);
		CriticalHitRate3.RegisterAsChild((UInt16)(0), this, ChildList);
		CriticalHitRate4.RegisterAsChild((UInt16)(0), this, ChildList);
		CriticalHitRate5.RegisterAsChild((UInt16)(0), this, ChildList);
		CriticalMissRate0.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT)), this, ChildList);
		CriticalMissRate1.RegisterAsChild((UInt16)(0), this, ChildList);
		CriticalMissRate2.RegisterAsChild((UInt16)(0), this, ChildList);
		CriticalMissRate3.RegisterAsChild((UInt16)(0), this, ChildList);
		CriticalMissRate4.RegisterAsChild((UInt16)(0), this, ChildList);
		CriticalMissRate5.RegisterAsChild((UInt16)(0), this, ChildList);
		CriticalDamageAttack0.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT)), this, ChildList);
		CriticalDamageAttack1.RegisterAsChild((UInt16)(0), this, ChildList);
		CriticalDamageAttack2.RegisterAsChild((UInt16)(0), this, ChildList);
		CriticalDamageAttack3.RegisterAsChild((UInt16)(0), this, ChildList);
		CriticalDamageAttack4.RegisterAsChild((UInt16)(0), this, ChildList);
		CriticalDamageAttack5.RegisterAsChild((UInt16)(0), this, ChildList);
		CriticalDamageDefence0.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT)), this, ChildList);
		CriticalDamageDefence1.RegisterAsChild((UInt16)(0), this, ChildList);
		CriticalDamageDefence2.RegisterAsChild((UInt16)(0), this, ChildList);
		CriticalDamageDefence3.RegisterAsChild((UInt16)(0), this, ChildList);
		CriticalDamageDefence4.RegisterAsChild((UInt16)(0), this, ChildList);
		CriticalDamageDefence5.RegisterAsChild((UInt16)(0), this, ChildList);
		Penetrate0.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT)), this, ChildList);
		Penetrate1.RegisterAsChild((UInt16)(0), this, ChildList);
		Penetrate2.RegisterAsChild((UInt16)(0), this, ChildList);
		Penetrate3.RegisterAsChild((UInt16)(0), this, ChildList);
		Penetrate4.RegisterAsChild((UInt16)(0), this, ChildList);
		Penetrate5.RegisterAsChild((UInt16)(0), this, ChildList);
		AttackVampire0.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT)), this, ChildList);
		AttackVampire1.RegisterAsChild((UInt16)(0), this, ChildList);
		AttackVampire2.RegisterAsChild((UInt16)(0), this, ChildList);
		AttackVampire3.RegisterAsChild((UInt16)(0), this, ChildList);
		AttackVampire4.RegisterAsChild((UInt16)(0), this, ChildList);
		AttackVampire5.RegisterAsChild((UInt16)(0), this, ChildList);
		AttackSpeedMultiply0.RegisterAsChild((UInt16)((1 << (int)ProjectAChannel.OWN_CLIENT)), this, ChildList);
		AttackSpeedMultiply1.RegisterAsChild((UInt16)(0), this, ChildList);
		AttackSpeedMultiply2.RegisterAsChild((UInt16)(0), this, ChildList);
		AttackSpeedMultiply3.RegisterAsChild((UInt16)(0), this, ChildList);
		AttackSpeedMultiply4.RegisterAsChild((UInt16)(0), this, ChildList);
		AttackSpeedMultiply5.RegisterAsChild((UInt16)(0), this, ChildList);
		//
		ReserveIdxPropertySize(INDEX_PROPERTY_COUNT);
		AddIdxProperty(None0);
		AddIdxProperty(None1);
		AddIdxProperty(None2);
		AddIdxProperty(None3);
		AddIdxProperty(None4);
		AddIdxProperty(None5);
		AddIdxProperty(ViewRange0);
		AddIdxProperty(ViewRange1);
		AddIdxProperty(ViewRange2);
		AddIdxProperty(ViewRange3);
		AddIdxProperty(ViewRange4);
		AddIdxProperty(ViewRange5);
		AddIdxProperty(VisibilityRange0);
		AddIdxProperty(VisibilityRange1);
		AddIdxProperty(VisibilityRange2);
		AddIdxProperty(VisibilityRange3);
		AddIdxProperty(VisibilityRange4);
		AddIdxProperty(VisibilityRange5);
		AddIdxProperty(AntiStealthRange0);
		AddIdxProperty(AntiStealthRange1);
		AddIdxProperty(AntiStealthRange2);
		AddIdxProperty(AntiStealthRange3);
		AddIdxProperty(AntiStealthRange4);
		AddIdxProperty(AntiStealthRange5);
		AddIdxProperty(HPPercent);
		AddIdxProperty(HP);
		AddIdxProperty(MP);
		AddIdxProperty(SP);
		AddIdxProperty(HPMax0);
		AddIdxProperty(HPMax1);
		AddIdxProperty(HPMax2);
		AddIdxProperty(HPMax3);
		AddIdxProperty(HPMax4);
		AddIdxProperty(HPMax5);
		AddIdxProperty(MPMax0);
		AddIdxProperty(MPMax1);
		AddIdxProperty(MPMax2);
		AddIdxProperty(MPMax3);
		AddIdxProperty(MPMax4);
		AddIdxProperty(MPMax5);
		AddIdxProperty(SPMax0);
		AddIdxProperty(SPMax1);
		AddIdxProperty(SPMax2);
		AddIdxProperty(SPMax3);
		AddIdxProperty(SPMax4);
		AddIdxProperty(SPMax5);
		AddIdxProperty(HPRegenerate0);
		AddIdxProperty(HPRegenerate1);
		AddIdxProperty(HPRegenerate2);
		AddIdxProperty(HPRegenerate3);
		AddIdxProperty(HPRegenerate4);
		AddIdxProperty(HPRegenerate5);
		AddIdxProperty(MPRegenerate0);
		AddIdxProperty(MPRegenerate1);
		AddIdxProperty(MPRegenerate2);
		AddIdxProperty(MPRegenerate3);
		AddIdxProperty(MPRegenerate4);
		AddIdxProperty(MPRegenerate5);
		AddIdxProperty(SPRegenerate0);
		AddIdxProperty(SPRegenerate1);
		AddIdxProperty(SPRegenerate2);
		AddIdxProperty(SPRegenerate3);
		AddIdxProperty(SPRegenerate4);
		AddIdxProperty(SPRegenerate5);
		AddIdxProperty(PhysicsAttack0);
		AddIdxProperty(PhysicsAttack1);
		AddIdxProperty(PhysicsAttack2);
		AddIdxProperty(PhysicsAttack3);
		AddIdxProperty(PhysicsAttack4);
		AddIdxProperty(PhysicsAttack5);
		AddIdxProperty(PhysicsDefence0);
		AddIdxProperty(PhysicsDefence1);
		AddIdxProperty(PhysicsDefence2);
		AddIdxProperty(PhysicsDefence3);
		AddIdxProperty(PhysicsDefence4);
		AddIdxProperty(PhysicsDefence5);
		AddIdxProperty(MagicAttack0);
		AddIdxProperty(MagicAttack1);
		AddIdxProperty(MagicAttack2);
		AddIdxProperty(MagicAttack3);
		AddIdxProperty(MagicAttack4);
		AddIdxProperty(MagicAttack5);
		AddIdxProperty(MagicDefence0);
		AddIdxProperty(MagicDefence1);
		AddIdxProperty(MagicDefence2);
		AddIdxProperty(MagicDefence3);
		AddIdxProperty(MagicDefence4);
		AddIdxProperty(MagicDefence5);
		AddIdxProperty(MoveSpeed0);
		AddIdxProperty(MoveSpeed1);
		AddIdxProperty(MoveSpeed2);
		AddIdxProperty(MoveSpeed3);
		AddIdxProperty(MoveSpeed4);
		AddIdxProperty(MoveSpeed5);
		AddIdxProperty(CriticalHit0);
		AddIdxProperty(CriticalHit1);
		AddIdxProperty(CriticalHit2);
		AddIdxProperty(CriticalHit3);
		AddIdxProperty(CriticalHit4);
		AddIdxProperty(CriticalHit5);
		AddIdxProperty(CriticalMiss0);
		AddIdxProperty(CriticalMiss1);
		AddIdxProperty(CriticalMiss2);
		AddIdxProperty(CriticalMiss3);
		AddIdxProperty(CriticalMiss4);
		AddIdxProperty(CriticalMiss5);
		AddIdxProperty(CriticalHitRate0);
		AddIdxProperty(CriticalHitRate1);
		AddIdxProperty(CriticalHitRate2);
		AddIdxProperty(CriticalHitRate3);
		AddIdxProperty(CriticalHitRate4);
		AddIdxProperty(CriticalHitRate5);
		AddIdxProperty(CriticalMissRate0);
		AddIdxProperty(CriticalMissRate1);
		AddIdxProperty(CriticalMissRate2);
		AddIdxProperty(CriticalMissRate3);
		AddIdxProperty(CriticalMissRate4);
		AddIdxProperty(CriticalMissRate5);
		AddIdxProperty(CriticalDamageAttack0);
		AddIdxProperty(CriticalDamageAttack1);
		AddIdxProperty(CriticalDamageAttack2);
		AddIdxProperty(CriticalDamageAttack3);
		AddIdxProperty(CriticalDamageAttack4);
		AddIdxProperty(CriticalDamageAttack5);
		AddIdxProperty(CriticalDamageDefence0);
		AddIdxProperty(CriticalDamageDefence1);
		AddIdxProperty(CriticalDamageDefence2);
		AddIdxProperty(CriticalDamageDefence3);
		AddIdxProperty(CriticalDamageDefence4);
		AddIdxProperty(CriticalDamageDefence5);
		AddIdxProperty(Penetrate0);
		AddIdxProperty(Penetrate1);
		AddIdxProperty(Penetrate2);
		AddIdxProperty(Penetrate3);
		AddIdxProperty(Penetrate4);
		AddIdxProperty(Penetrate5);
		AddIdxProperty(AttackVampire0);
		AddIdxProperty(AttackVampire1);
		AddIdxProperty(AttackVampire2);
		AddIdxProperty(AttackVampire3);
		AddIdxProperty(AttackVampire4);
		AddIdxProperty(AttackVampire5);
		AddIdxProperty(AttackSpeedMultiply0);
		AddIdxProperty(AttackSpeedMultiply1);
		AddIdxProperty(AttackSpeedMultiply2);
		AddIdxProperty(AttackSpeedMultiply3);
		AddIdxProperty(AttackSpeedMultiply4);
		AddIdxProperty(AttackSpeedMultiply5);
	}
	public override void OnPropertyUpdate(UInt8 channel, ViIStream IS, ViEntity entity)
	{
		UInt16 slot;
		IS.Read(out slot);
		OnUpdateAsContainer(slot, channel, IS, entity);
	}
	public override void StartProperty(UInt16 channelMask, ViIStream IS, ViEntity entity)
	{
		base.StartProperty(channelMask, IS, entity);
		Level.Start(channelMask, IS, entity);
		FocusEntity.Start(channelMask, IS, entity);
		Faction.Start(channelMask, IS, entity);
		Team.Start(channelMask, IS, entity);
		Owner.Start(channelMask, IS, entity);
		SpellCDList.Start(channelMask, IS, entity);
		ScriptList.Start(channelMask, IS, entity);
		ScriptValueList.Start(channelMask, IS, entity);
		DefenceCoefficient.Start(channelMask, IS, entity);
		CriticalHitCoefficient.Start(channelMask, IS, entity);
		CriticalDamageCoefficient.Start(channelMask, IS, entity);
		ElementCoefficient.Start(channelMask, IS, entity);
		None0.Start(channelMask, IS, entity);
		None1.Start(channelMask, IS, entity);
		None2.Start(channelMask, IS, entity);
		None3.Start(channelMask, IS, entity);
		None4.Start(channelMask, IS, entity);
		None5.Start(channelMask, IS, entity);
		ViewRange0.Start(channelMask, IS, entity);
		ViewRange1.Start(channelMask, IS, entity);
		ViewRange2.Start(channelMask, IS, entity);
		ViewRange3.Start(channelMask, IS, entity);
		ViewRange4.Start(channelMask, IS, entity);
		ViewRange5.Start(channelMask, IS, entity);
		VisibilityRange0.Start(channelMask, IS, entity);
		VisibilityRange1.Start(channelMask, IS, entity);
		VisibilityRange2.Start(channelMask, IS, entity);
		VisibilityRange3.Start(channelMask, IS, entity);
		VisibilityRange4.Start(channelMask, IS, entity);
		VisibilityRange5.Start(channelMask, IS, entity);
		AntiStealthRange0.Start(channelMask, IS, entity);
		AntiStealthRange1.Start(channelMask, IS, entity);
		AntiStealthRange2.Start(channelMask, IS, entity);
		AntiStealthRange3.Start(channelMask, IS, entity);
		AntiStealthRange4.Start(channelMask, IS, entity);
		AntiStealthRange5.Start(channelMask, IS, entity);
		HPPercent.Start(channelMask, IS, entity);
		HP.Start(channelMask, IS, entity);
		MP.Start(channelMask, IS, entity);
		SP.Start(channelMask, IS, entity);
		HPMax0.Start(channelMask, IS, entity);
		HPMax1.Start(channelMask, IS, entity);
		HPMax2.Start(channelMask, IS, entity);
		HPMax3.Start(channelMask, IS, entity);
		HPMax4.Start(channelMask, IS, entity);
		HPMax5.Start(channelMask, IS, entity);
		MPMax0.Start(channelMask, IS, entity);
		MPMax1.Start(channelMask, IS, entity);
		MPMax2.Start(channelMask, IS, entity);
		MPMax3.Start(channelMask, IS, entity);
		MPMax4.Start(channelMask, IS, entity);
		MPMax5.Start(channelMask, IS, entity);
		SPMax0.Start(channelMask, IS, entity);
		SPMax1.Start(channelMask, IS, entity);
		SPMax2.Start(channelMask, IS, entity);
		SPMax3.Start(channelMask, IS, entity);
		SPMax4.Start(channelMask, IS, entity);
		SPMax5.Start(channelMask, IS, entity);
		HPRegenerate0.Start(channelMask, IS, entity);
		HPRegenerate1.Start(channelMask, IS, entity);
		HPRegenerate2.Start(channelMask, IS, entity);
		HPRegenerate3.Start(channelMask, IS, entity);
		HPRegenerate4.Start(channelMask, IS, entity);
		HPRegenerate5.Start(channelMask, IS, entity);
		MPRegenerate0.Start(channelMask, IS, entity);
		MPRegenerate1.Start(channelMask, IS, entity);
		MPRegenerate2.Start(channelMask, IS, entity);
		MPRegenerate3.Start(channelMask, IS, entity);
		MPRegenerate4.Start(channelMask, IS, entity);
		MPRegenerate5.Start(channelMask, IS, entity);
		SPRegenerate0.Start(channelMask, IS, entity);
		SPRegenerate1.Start(channelMask, IS, entity);
		SPRegenerate2.Start(channelMask, IS, entity);
		SPRegenerate3.Start(channelMask, IS, entity);
		SPRegenerate4.Start(channelMask, IS, entity);
		SPRegenerate5.Start(channelMask, IS, entity);
		PhysicsAttack0.Start(channelMask, IS, entity);
		PhysicsAttack1.Start(channelMask, IS, entity);
		PhysicsAttack2.Start(channelMask, IS, entity);
		PhysicsAttack3.Start(channelMask, IS, entity);
		PhysicsAttack4.Start(channelMask, IS, entity);
		PhysicsAttack5.Start(channelMask, IS, entity);
		PhysicsDefence0.Start(channelMask, IS, entity);
		PhysicsDefence1.Start(channelMask, IS, entity);
		PhysicsDefence2.Start(channelMask, IS, entity);
		PhysicsDefence3.Start(channelMask, IS, entity);
		PhysicsDefence4.Start(channelMask, IS, entity);
		PhysicsDefence5.Start(channelMask, IS, entity);
		MagicAttack0.Start(channelMask, IS, entity);
		MagicAttack1.Start(channelMask, IS, entity);
		MagicAttack2.Start(channelMask, IS, entity);
		MagicAttack3.Start(channelMask, IS, entity);
		MagicAttack4.Start(channelMask, IS, entity);
		MagicAttack5.Start(channelMask, IS, entity);
		MagicDefence0.Start(channelMask, IS, entity);
		MagicDefence1.Start(channelMask, IS, entity);
		MagicDefence2.Start(channelMask, IS, entity);
		MagicDefence3.Start(channelMask, IS, entity);
		MagicDefence4.Start(channelMask, IS, entity);
		MagicDefence5.Start(channelMask, IS, entity);
		MoveSpeed0.Start(channelMask, IS, entity);
		MoveSpeed1.Start(channelMask, IS, entity);
		MoveSpeed2.Start(channelMask, IS, entity);
		MoveSpeed3.Start(channelMask, IS, entity);
		MoveSpeed4.Start(channelMask, IS, entity);
		MoveSpeed5.Start(channelMask, IS, entity);
		CriticalHit0.Start(channelMask, IS, entity);
		CriticalHit1.Start(channelMask, IS, entity);
		CriticalHit2.Start(channelMask, IS, entity);
		CriticalHit3.Start(channelMask, IS, entity);
		CriticalHit4.Start(channelMask, IS, entity);
		CriticalHit5.Start(channelMask, IS, entity);
		CriticalMiss0.Start(channelMask, IS, entity);
		CriticalMiss1.Start(channelMask, IS, entity);
		CriticalMiss2.Start(channelMask, IS, entity);
		CriticalMiss3.Start(channelMask, IS, entity);
		CriticalMiss4.Start(channelMask, IS, entity);
		CriticalMiss5.Start(channelMask, IS, entity);
		CriticalHitRate0.Start(channelMask, IS, entity);
		CriticalHitRate1.Start(channelMask, IS, entity);
		CriticalHitRate2.Start(channelMask, IS, entity);
		CriticalHitRate3.Start(channelMask, IS, entity);
		CriticalHitRate4.Start(channelMask, IS, entity);
		CriticalHitRate5.Start(channelMask, IS, entity);
		CriticalMissRate0.Start(channelMask, IS, entity);
		CriticalMissRate1.Start(channelMask, IS, entity);
		CriticalMissRate2.Start(channelMask, IS, entity);
		CriticalMissRate3.Start(channelMask, IS, entity);
		CriticalMissRate4.Start(channelMask, IS, entity);
		CriticalMissRate5.Start(channelMask, IS, entity);
		CriticalDamageAttack0.Start(channelMask, IS, entity);
		CriticalDamageAttack1.Start(channelMask, IS, entity);
		CriticalDamageAttack2.Start(channelMask, IS, entity);
		CriticalDamageAttack3.Start(channelMask, IS, entity);
		CriticalDamageAttack4.Start(channelMask, IS, entity);
		CriticalDamageAttack5.Start(channelMask, IS, entity);
		CriticalDamageDefence0.Start(channelMask, IS, entity);
		CriticalDamageDefence1.Start(channelMask, IS, entity);
		CriticalDamageDefence2.Start(channelMask, IS, entity);
		CriticalDamageDefence3.Start(channelMask, IS, entity);
		CriticalDamageDefence4.Start(channelMask, IS, entity);
		CriticalDamageDefence5.Start(channelMask, IS, entity);
		Penetrate0.Start(channelMask, IS, entity);
		Penetrate1.Start(channelMask, IS, entity);
		Penetrate2.Start(channelMask, IS, entity);
		Penetrate3.Start(channelMask, IS, entity);
		Penetrate4.Start(channelMask, IS, entity);
		Penetrate5.Start(channelMask, IS, entity);
		AttackVampire0.Start(channelMask, IS, entity);
		AttackVampire1.Start(channelMask, IS, entity);
		AttackVampire2.Start(channelMask, IS, entity);
		AttackVampire3.Start(channelMask, IS, entity);
		AttackVampire4.Start(channelMask, IS, entity);
		AttackVampire5.Start(channelMask, IS, entity);
		AttackSpeedMultiply0.Start(channelMask, IS, entity);
		AttackSpeedMultiply1.Start(channelMask, IS, entity);
		AttackSpeedMultiply2.Start(channelMask, IS, entity);
		AttackSpeedMultiply3.Start(channelMask, IS, entity);
		AttackSpeedMultiply4.Start(channelMask, IS, entity);
		AttackSpeedMultiply5.Start(channelMask, IS, entity);
	}
	public override void EndProperty(ViEntity entity)
	{
		base.EndProperty(entity);
		Level.End(entity);
		FocusEntity.End(entity);
		Faction.End(entity);
		Team.End(entity);
		Owner.End(entity);
		SpellCDList.End(entity);
		ScriptList.End(entity);
		ScriptValueList.End(entity);
		DefenceCoefficient.End(entity);
		CriticalHitCoefficient.End(entity);
		CriticalDamageCoefficient.End(entity);
		ElementCoefficient.End(entity);
		None0.End(entity);
		None1.End(entity);
		None2.End(entity);
		None3.End(entity);
		None4.End(entity);
		None5.End(entity);
		ViewRange0.End(entity);
		ViewRange1.End(entity);
		ViewRange2.End(entity);
		ViewRange3.End(entity);
		ViewRange4.End(entity);
		ViewRange5.End(entity);
		VisibilityRange0.End(entity);
		VisibilityRange1.End(entity);
		VisibilityRange2.End(entity);
		VisibilityRange3.End(entity);
		VisibilityRange4.End(entity);
		VisibilityRange5.End(entity);
		AntiStealthRange0.End(entity);
		AntiStealthRange1.End(entity);
		AntiStealthRange2.End(entity);
		AntiStealthRange3.End(entity);
		AntiStealthRange4.End(entity);
		AntiStealthRange5.End(entity);
		HPPercent.End(entity);
		HP.End(entity);
		MP.End(entity);
		SP.End(entity);
		HPMax0.End(entity);
		HPMax1.End(entity);
		HPMax2.End(entity);
		HPMax3.End(entity);
		HPMax4.End(entity);
		HPMax5.End(entity);
		MPMax0.End(entity);
		MPMax1.End(entity);
		MPMax2.End(entity);
		MPMax3.End(entity);
		MPMax4.End(entity);
		MPMax5.End(entity);
		SPMax0.End(entity);
		SPMax1.End(entity);
		SPMax2.End(entity);
		SPMax3.End(entity);
		SPMax4.End(entity);
		SPMax5.End(entity);
		HPRegenerate0.End(entity);
		HPRegenerate1.End(entity);
		HPRegenerate2.End(entity);
		HPRegenerate3.End(entity);
		HPRegenerate4.End(entity);
		HPRegenerate5.End(entity);
		MPRegenerate0.End(entity);
		MPRegenerate1.End(entity);
		MPRegenerate2.End(entity);
		MPRegenerate3.End(entity);
		MPRegenerate4.End(entity);
		MPRegenerate5.End(entity);
		SPRegenerate0.End(entity);
		SPRegenerate1.End(entity);
		SPRegenerate2.End(entity);
		SPRegenerate3.End(entity);
		SPRegenerate4.End(entity);
		SPRegenerate5.End(entity);
		PhysicsAttack0.End(entity);
		PhysicsAttack1.End(entity);
		PhysicsAttack2.End(entity);
		PhysicsAttack3.End(entity);
		PhysicsAttack4.End(entity);
		PhysicsAttack5.End(entity);
		PhysicsDefence0.End(entity);
		PhysicsDefence1.End(entity);
		PhysicsDefence2.End(entity);
		PhysicsDefence3.End(entity);
		PhysicsDefence4.End(entity);
		PhysicsDefence5.End(entity);
		MagicAttack0.End(entity);
		MagicAttack1.End(entity);
		MagicAttack2.End(entity);
		MagicAttack3.End(entity);
		MagicAttack4.End(entity);
		MagicAttack5.End(entity);
		MagicDefence0.End(entity);
		MagicDefence1.End(entity);
		MagicDefence2.End(entity);
		MagicDefence3.End(entity);
		MagicDefence4.End(entity);
		MagicDefence5.End(entity);
		MoveSpeed0.End(entity);
		MoveSpeed1.End(entity);
		MoveSpeed2.End(entity);
		MoveSpeed3.End(entity);
		MoveSpeed4.End(entity);
		MoveSpeed5.End(entity);
		CriticalHit0.End(entity);
		CriticalHit1.End(entity);
		CriticalHit2.End(entity);
		CriticalHit3.End(entity);
		CriticalHit4.End(entity);
		CriticalHit5.End(entity);
		CriticalMiss0.End(entity);
		CriticalMiss1.End(entity);
		CriticalMiss2.End(entity);
		CriticalMiss3.End(entity);
		CriticalMiss4.End(entity);
		CriticalMiss5.End(entity);
		CriticalHitRate0.End(entity);
		CriticalHitRate1.End(entity);
		CriticalHitRate2.End(entity);
		CriticalHitRate3.End(entity);
		CriticalHitRate4.End(entity);
		CriticalHitRate5.End(entity);
		CriticalMissRate0.End(entity);
		CriticalMissRate1.End(entity);
		CriticalMissRate2.End(entity);
		CriticalMissRate3.End(entity);
		CriticalMissRate4.End(entity);
		CriticalMissRate5.End(entity);
		CriticalDamageAttack0.End(entity);
		CriticalDamageAttack1.End(entity);
		CriticalDamageAttack2.End(entity);
		CriticalDamageAttack3.End(entity);
		CriticalDamageAttack4.End(entity);
		CriticalDamageAttack5.End(entity);
		CriticalDamageDefence0.End(entity);
		CriticalDamageDefence1.End(entity);
		CriticalDamageDefence2.End(entity);
		CriticalDamageDefence3.End(entity);
		CriticalDamageDefence4.End(entity);
		CriticalDamageDefence5.End(entity);
		Penetrate0.End(entity);
		Penetrate1.End(entity);
		Penetrate2.End(entity);
		Penetrate3.End(entity);
		Penetrate4.End(entity);
		Penetrate5.End(entity);
		AttackVampire0.End(entity);
		AttackVampire1.End(entity);
		AttackVampire2.End(entity);
		AttackVampire3.End(entity);
		AttackVampire4.End(entity);
		AttackVampire5.End(entity);
		AttackSpeedMultiply0.End(entity);
		AttackSpeedMultiply1.End(entity);
		AttackSpeedMultiply2.End(entity);
		AttackSpeedMultiply3.End(entity);
		AttackSpeedMultiply4.End(entity);
		AttackSpeedMultiply5.End(entity);
	}
	public override void Clear()
	{
		base.Clear();
		Level.Clear();
		FocusEntity.Clear();
		Faction.Clear();
		Team.Clear();
		Owner.Clear();
		SpellCDList.Clear();
		ScriptList.Clear();
		ScriptValueList.Clear();
		DefenceCoefficient.Clear();
		CriticalHitCoefficient.Clear();
		CriticalDamageCoefficient.Clear();
		ElementCoefficient.Clear();
		None0.Clear();
		None1.Clear();
		None2.Clear();
		None3.Clear();
		None4.Clear();
		None5.Clear();
		ViewRange0.Clear();
		ViewRange1.Clear();
		ViewRange2.Clear();
		ViewRange3.Clear();
		ViewRange4.Clear();
		ViewRange5.Clear();
		VisibilityRange0.Clear();
		VisibilityRange1.Clear();
		VisibilityRange2.Clear();
		VisibilityRange3.Clear();
		VisibilityRange4.Clear();
		VisibilityRange5.Clear();
		AntiStealthRange0.Clear();
		AntiStealthRange1.Clear();
		AntiStealthRange2.Clear();
		AntiStealthRange3.Clear();
		AntiStealthRange4.Clear();
		AntiStealthRange5.Clear();
		HPPercent.Clear();
		HP.Clear();
		MP.Clear();
		SP.Clear();
		HPMax0.Clear();
		HPMax1.Clear();
		HPMax2.Clear();
		HPMax3.Clear();
		HPMax4.Clear();
		HPMax5.Clear();
		MPMax0.Clear();
		MPMax1.Clear();
		MPMax2.Clear();
		MPMax3.Clear();
		MPMax4.Clear();
		MPMax5.Clear();
		SPMax0.Clear();
		SPMax1.Clear();
		SPMax2.Clear();
		SPMax3.Clear();
		SPMax4.Clear();
		SPMax5.Clear();
		HPRegenerate0.Clear();
		HPRegenerate1.Clear();
		HPRegenerate2.Clear();
		HPRegenerate3.Clear();
		HPRegenerate4.Clear();
		HPRegenerate5.Clear();
		MPRegenerate0.Clear();
		MPRegenerate1.Clear();
		MPRegenerate2.Clear();
		MPRegenerate3.Clear();
		MPRegenerate4.Clear();
		MPRegenerate5.Clear();
		SPRegenerate0.Clear();
		SPRegenerate1.Clear();
		SPRegenerate2.Clear();
		SPRegenerate3.Clear();
		SPRegenerate4.Clear();
		SPRegenerate5.Clear();
		PhysicsAttack0.Clear();
		PhysicsAttack1.Clear();
		PhysicsAttack2.Clear();
		PhysicsAttack3.Clear();
		PhysicsAttack4.Clear();
		PhysicsAttack5.Clear();
		PhysicsDefence0.Clear();
		PhysicsDefence1.Clear();
		PhysicsDefence2.Clear();
		PhysicsDefence3.Clear();
		PhysicsDefence4.Clear();
		PhysicsDefence5.Clear();
		MagicAttack0.Clear();
		MagicAttack1.Clear();
		MagicAttack2.Clear();
		MagicAttack3.Clear();
		MagicAttack4.Clear();
		MagicAttack5.Clear();
		MagicDefence0.Clear();
		MagicDefence1.Clear();
		MagicDefence2.Clear();
		MagicDefence3.Clear();
		MagicDefence4.Clear();
		MagicDefence5.Clear();
		MoveSpeed0.Clear();
		MoveSpeed1.Clear();
		MoveSpeed2.Clear();
		MoveSpeed3.Clear();
		MoveSpeed4.Clear();
		MoveSpeed5.Clear();
		CriticalHit0.Clear();
		CriticalHit1.Clear();
		CriticalHit2.Clear();
		CriticalHit3.Clear();
		CriticalHit4.Clear();
		CriticalHit5.Clear();
		CriticalMiss0.Clear();
		CriticalMiss1.Clear();
		CriticalMiss2.Clear();
		CriticalMiss3.Clear();
		CriticalMiss4.Clear();
		CriticalMiss5.Clear();
		CriticalHitRate0.Clear();
		CriticalHitRate1.Clear();
		CriticalHitRate2.Clear();
		CriticalHitRate3.Clear();
		CriticalHitRate4.Clear();
		CriticalHitRate5.Clear();
		CriticalMissRate0.Clear();
		CriticalMissRate1.Clear();
		CriticalMissRate2.Clear();
		CriticalMissRate3.Clear();
		CriticalMissRate4.Clear();
		CriticalMissRate5.Clear();
		CriticalDamageAttack0.Clear();
		CriticalDamageAttack1.Clear();
		CriticalDamageAttack2.Clear();
		CriticalDamageAttack3.Clear();
		CriticalDamageAttack4.Clear();
		CriticalDamageAttack5.Clear();
		CriticalDamageDefence0.Clear();
		CriticalDamageDefence1.Clear();
		CriticalDamageDefence2.Clear();
		CriticalDamageDefence3.Clear();
		CriticalDamageDefence4.Clear();
		CriticalDamageDefence5.Clear();
		Penetrate0.Clear();
		Penetrate1.Clear();
		Penetrate2.Clear();
		Penetrate3.Clear();
		Penetrate4.Clear();
		Penetrate5.Clear();
		AttackVampire0.Clear();
		AttackVampire1.Clear();
		AttackVampire2.Clear();
		AttackVampire3.Clear();
		AttackVampire4.Clear();
		AttackVampire5.Clear();
		AttackSpeedMultiply0.Clear();
		AttackSpeedMultiply1.Clear();
		AttackSpeedMultiply2.Clear();
		AttackSpeedMultiply3.Clear();
		AttackSpeedMultiply4.Clear();
		AttackSpeedMultiply5.Clear();
	}
}
