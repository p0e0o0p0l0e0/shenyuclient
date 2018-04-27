using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

using UInt8 = System.Byte;
using Int8 = System.SByte;

public static class EntityMessageController
{
    public static bool ServerMouseHint = false;
    public static bool ServerKeyboardHint = false;
    public static bool ClientMouseHint = false;
    public static bool ClientKeyboardHint = false;

    static EntityMessageController()
    {
        for (int iter = 0; iter < 4; ++iter)
        {
            _logParamsStrList.Add(new ViStringBuilder());
        }
        for (int iter = 0; iter < 4; ++iter)
        {
            _logParamsObjList.Add(null);
        }
    }

    public static void OnServerMessage(UInt16 msgID, UInt64 types, ViIStream IS)
    {
        OnMessage(msgID, types, IS, ServerMouseHint, ServerKeyboardHint);
    }

    public static void OnClientMessage(UInt16 msgID, UInt64 types, ViIStream IS)
    {
        OnMessage(msgID, types, IS, ClientMouseHint, ClientKeyboardHint);
    }

    public static void OnDebugMessage(string title, string content)
    {
        string log = title + "\n" + content;
        //ViewControllerManager.CenterMessageView.ShowMessage(log);
        if (Application.isEditor)
        {
            ViDebuger.CritOK(log);
        }
    }

    static ViStringBuilder _logStrBuilder = new ViStringBuilder();
    static List<ViStringBuilder> _logParamsStrList = new List<ViStringBuilder>();
    static List<object> _logParamsObjList = new List<object>();
    public static void OnMessage(UInt16 msgID, UInt64 types, ViIStream IS, bool mouseHint, bool keyboardHint)
    {
        EntityMessageLogStruct messageInfo = ViSealedDB<EntityMessageLogStruct>.Data((int)msgID);
        ViMask32<EntityMessagePositionMask> posMask = messageInfo.Position;
        //
        _logStrBuilder.Clear();
        Int32 paramCount = EntityMessageReader.Read(types, IS, _logParamsStrList, _logParamsObjList);
        string sendEntityName;
        IS.Read(out sendEntityName);
        OnMessage(msgID, _logParamsObjList, ref _logStrBuilder);
        if (posMask.HasAny((int)EntityMessagePositionMask.CENTER + (int)EntityMessagePositionMask.CONFIRM + (int)EntityMessagePositionMask.VOUCHER) || Application.isEditor)
        {
            if (_logStrBuilder.Empty)
            {
                if (!string.IsNullOrEmpty(sendEntityName))
                {
                    _logStrBuilder.Add("[@").Add(sendEntityName).Add("].");
                }
                int idx = 0;
                _logStrBuilder.Add(messageInfo.NameSegmentList.List[0]);
                int count = ViMathDefine.Min(messageInfo.NameSegmentList.List.Count - 1, paramCount);
                while (idx < count)
                {
                    _logStrBuilder.Add(_logParamsStrList[idx]);
                    ++idx;
                    _logStrBuilder.Add(messageInfo.NameSegmentList.List[idx]);
                }
            }
            if (messageInfo.NameSegmentList.List.Count - 1 != paramCount)
            {
                ViDebuger.Warning("消息<" + msgID + ">参数不匹配");
            }
            if (_logStrBuilder.NotEmpty)
            {
                if (posMask.HasAny((int)EntityMessagePositionMask.CENTER))
                {
                    string player = paramCount > 0 ? _logParamsObjList[0] as string : string.Empty;
                    //ViewControllerManager.CenterMessageView.ShowMessage(_logStrBuilder.Value);
                }
                if (posMask.HasAny((int)EntityMessagePositionMask.CONFIRM))
                {
                    //ViewControllerManager.ConfirmView.ShowConfirm1(_logStrBuilder.Value);
                }
                if (posMask.HasAny((int)EntityMessagePositionMask.VOUCHER))
                {
                    //ViewControllerManager.ShowVoucherConfirm(_logStrBuilder.Value);
                }
                if (Application.isEditor)
                {
                    ViDebuger.CritOK(_logStrBuilder.Value);
                }
            }
        }
    }


    static void OnMessage(UInt16 msgID, List<object> paramsObjList, ref ViStringBuilder logStr)
    {
        UConsole.Log("Server OnMessage: " + ((EntityMessage)msgID) + "," + ((ViGameMessageIdx)msgID));

#if PARTY
		Debug.Log("-->" + ((EntityMessage)msgID));
#endif
        switch (msgID)
        {
            case (UInt16)ViGameMessageIdx.ACTION_REQ_STATE_NOT_MATCH:
                StateReqMatchFail(ActionStateDescription.ReqFailDesc, (UInt32)paramsObjList[0], (UInt32)paramsObjList[1], ref logStr);
                break;
            case (UInt16)ViGameMessageIdx.ACTION_NOT_STATE_NOT_MATCH:
                StateNotMatchFail(ActionStateDescription.NotFailDesc, (UInt32)paramsObjList[0], (UInt32)paramsObjList[1], ref logStr);
                break;
            case (UInt16)EntityMessage.PLAYER_REQ_STATE_MATCH_FAIL:
                StateReqMatchFail(PlayerStateMaskDescription.ReqFailDesc, (UInt32)paramsObjList[0], (UInt32)paramsObjList[1], ref logStr);
                break;
            case (UInt16)EntityMessage.PLAYER_NOT_STATE_MATCH_FAIL:
                StateNotMatchFail(PlayerStateMaskDescription.NotFailDesc, (UInt32)paramsObjList[0], (UInt32)paramsObjList[1], ref logStr);
                break;
            case (UInt16)EntityMessage.BATTLE_MISS_ATTCKER:
                MissAsAttacker(paramsObjList[0] as GameUnit, AttackResult.MISS);
                break;
            case (UInt16)EntityMessage.BATTLE_MISS_VICTIM:
                MissAsVictim(paramsObjList[0] as GameUnit, AttackResult.MISS);
                break;
            case (UInt16)EntityMessage.BATTLE_DAMAGE_ATTCKER:
                DamageAsAttacker(paramsObjList[0] as GameUnit, (AttackResult)((UInt8)paramsObjList[1]), (Int32)paramsObjList[2], (Int32)paramsObjList[3]);
                break;
            case (UInt16)EntityMessage.BATTLE_DAMAGE_VICTIM:
                DamageAsVictim(paramsObjList[0] as GameUnit, (AttackResult)((UInt8)paramsObjList[1]), (Int32)paramsObjList[2], (Int32)paramsObjList[3]);
                break;
            case (UInt16)EntityMessage.ITEM_ADD_CNT:
                ItemCountProperty property = new ItemCountProperty();
                property.Info.Set(((ItemStruct)paramsObjList[1]).ID);
                property.Count = (Int32)paramsObjList[0];
                //ViewControllerManager.CommonPopView.ShowItemPop(property);
                break;
            case (UInt16)EntityMessage.YINPIAO_RECEIVE:
                ItemCountProperty yinPiaoProperty = new ItemCountProperty();
                yinPiaoProperty.Info.Set(GameVisualItemInstance.YinPiao);
                yinPiaoProperty.Count = (Int32)(Int64)paramsObjList[0];
                //ViewControllerManager.CommonPopView.ShowItemPop(yinPiaoProperty);
                //
                break;
            case (UInt16)EntityMessage.JINPIAO_RECEIVE:
                ItemCountProperty jinPiaoProperty = new ItemCountProperty();
                jinPiaoProperty.Info.Set(GameVisualItemInstance.JinPiao);
                jinPiaoProperty.Count = (Int32)(Int64)paramsObjList[0];
                //ViewControllerManager.CommonPopView.ShowItemPop(jinPiaoProperty);
                //
                break;
            case (UInt16)EntityMessage.XP_UP:
                ItemCountProperty xpProperty = new ItemCountProperty();
                xpProperty.Info.Set(GameVisualItemInstance.XP);
                xpProperty.Count = (Int32)(Int64)paramsObjList[0];
                //ViewControllerManager.CommonPopView.ShowItemPop(xpProperty);
                //
                break;
            case (UInt16)EntityMessage.POWER_ADD:

                //
                break;
            case (UInt16)EntityMessage.HERO_ADD:
                HeroStruct heroInfo = (HeroStruct)paramsObjList[0];
                ////ViewControllerManager.DisplayHero(heroInfo);
                //
                break;
            case (UInt16)EntityMessage.HP_UP:

                break;
            case (UInt16)EntityMessage.ITEM_USE:  //使用成功
                UIBagDataMgr.GetInstance.ReceiveItemUseSuccess((UInt32)paramsObjList[0]);
                break;
            case (UInt16)EntityMessage.ITEM_RECOVER://冷却中

                break;

            case (UInt16)EntityMessage.ITEM_UNABLE_USE://无法使用

                break;

            case (UInt16)EntityMessage.ITEM_HP_MAX:

                break;
            case (UInt16)EntityMessage.BATTLE_HOT_CASTER:
                HP_UP(paramsObjList[0] as GameUnit, (Int32)paramsObjList[2]);
                break;


            case (UInt16)EntityMessage.PARTY_INVITED:
                UIManagerUtility.ShowHint(I18NManager.Instance.GetWord("tips_224"));
                break;

            case (UInt16)EntityMessage.PARTY_MEMBER_FULL:
                UIManagerUtility.ShowHint(I18NManager.Instance.GetWord("tips_225"));
                break;

            case (UInt16)EntityMessage.PARTY_NOT_EXIST:
                UIManagerUtility.ShowHint(I18NManager.Instance.GetWord("tips_226"));
                break;

            case (UInt16)EntityMessage.PARTY_EXIST:
                UIManagerUtility.ShowHint(I18NManager.Instance.GetWord("tips_227"));
                break;


            case (UInt16)EntityMessage.PARTY_MATCH_TEAM_START:
                PartyInstance.ChangeMatchingStage(true);
                break;
            case (UInt16)EntityMessage.PARTY_MATCH_TEAM_END:
                PartyInstance.ChangeMatchingStage(false);
                break;
            default:
                break;
        }
    }

    delegate string DeleDesc(UInt32 state);
    static void StateReqMatchFail(DeleDesc dele, UInt32 reqState, UInt32 curState, ref ViStringBuilder logStr)
    {
        for (Int32 idx = 0; idx < 32; ++idx)
        {
            UInt32 iterState = (UInt32)(1 << idx);
            if (!ViMask32.HasAny(reqState, iterState) || ViMask32.HasAny(curState, iterState))
            {
                continue;
            }
            string log = dele(iterState);
            if (string.IsNullOrEmpty(log))
            {
                continue;
            }
            logStr.Set(log);
            break;
        }
    }
    static void StateNotMatchFail(DeleDesc dele, UInt32 notState, UInt32 curState, ref ViStringBuilder logStr)
    {
        for (Int32 idx = 0; idx < 32; ++idx)
        {
            UInt32 iterState = (UInt32)(1 << idx);
            if (!ViMask32.HasAny(notState, iterState) || !ViMask32.HasAny(curState, iterState))
            {
                continue;
            }
            string log = dele(iterState);
            if (string.IsNullOrEmpty(log))
            {
                continue;
            }
            logStr.Set(log);
            break;
        }
    }


    public static void MissAsAttacker(GameUnit victime, AttackResult result)
    {
        if (victime == null)
        {
            return;
        }
        //FightDamageTextController.Instance.AddDamageText(0, victime.CenterPosProvider, victime.IsLeftDir, result);
        if (SuperTextManager.Instance != null)
            SuperTextManager.Instance.SpwanFlyHint("Miss ", HintType.DAMAGE, victime.HeadPosProvider.Value.Convert());
    }
    public static void MissAsVictim(GameUnit attacker, AttackResult result)
    {
        if (attacker == null)
        {
            return;
        }
        //FightDamageTextController.Instance.AddDamageText(0, CellHero.LocalHero.CenterPosProvider, CellHero.LocalHero.IsLeftDir, result);
        if (SuperTextManager.Instance != null)
            SuperTextManager.Instance.SpwanFlyHint("Miss ", HintType.DAMAGE, CellHero.LocalHero.HeadPosProvider.Value.Convert());
    }

    public static void DamageAsAttacker(GameUnit victime, AttackResult result, Int32 damage, Int32 disDamage)
    {
        if (victime == null)
        {
            return;
        }
        string damageStr = ConvertResultToString(damage, result);
        HintType curType = (result == AttackResult.CRITICAL ? HintType.CRITICAL : HintType.REAL_DAMAGE);
        //if (victime is CellNPC)
        {
            CellNPC npc = victime as CellNPC;
            Vector3 heroWorldPos = CellHero.LocalHero.Position.Convert();
            Vector3 npcWorldPos = victime.Position.Convert();
            //Vector2 heroScreenPos = GlobalGameObject.Instance.SceneCamera.WorldToScreenPoint(heroWorldPos);
            //Vector2 bossScreenPos = GlobalGameObject.Instance.SceneCamera.WorldToScreenPoint(npcWorldPos);
            Vector3 dir = Vector3.up;
            //镜像处理
            //if (heroScreenPos.y < bossScreenPos.y)
            //{
            //    dir = bosssWorldPos - heroWorldPos;
            //}
            //else
            //{
            //    dir = bosssWorldPos - heroWorldPos;
            //    dir.Normalize();
            //    dir = new Vector3(dir.x, dir.y, -dir.z);

            //}
            dir = npcWorldPos - heroWorldPos;
            if (SuperTextManager.Instance != null)
                SuperTextManager.Instance.SpwanFlyHint(damageStr, curType, victime.HeadPosProvider.Value.Convert(), dir);
            return;
        }
        //if (SuperTextManager.Instance != null)
        //    SuperTextManager.Instance.SpwanFlyHint(damageStr, curType, victime.HeadPosProvider.Value.Convert());
    }

    public static void DamageAsVictim(GameUnit attacker, AttackResult result, Int32 damage, Int32 disDamage)
    {
        if (attacker == null)
        {
            return;
        }
        string damageStr = ConvertResultToString(damage, result);
        if (SuperTextManager.Instance != null)
        {
            Vector3 heroWorldPos = CellHero.LocalHero.Position.Convert();
            Vector3 npcWorldPos = attacker.Position.Convert();
            Vector3 dir = heroWorldPos - npcWorldPos;
            SuperTextManager.Instance.SpwanFlyHint(damageStr, HintType.DAMAGE, CellHero.LocalHero.HeadPosProvider.Value.Convert(), dir);
        }

    }
    public static void HP_UP(GameUnit attacker, Int32 addHp)
    {
        if (SuperTextManager.Instance != null && attacker != null)
            SuperTextManager.Instance.SpwanFlyHint("+" + addHp.ToString(), HintType.HEALTH, attacker.HeadPosProvider.Value.Convert());
    }
    public static string ConvertResultToString(int damage, AttackResult result)
    {
        string str = "";
        switch (result)
        {
            case AttackResult.CRITICAL:
                //str = "Critical " + damage;
                str = damage.ToString();
                break;
            case AttackResult.MISS:
            case AttackResult.DODGE:
                str = "Miss " + damage;
                break;
            default:
                str = damage.ToString();
                break;
        }
        return str;
    }
}

