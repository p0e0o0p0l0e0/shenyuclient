using System;
using System.Collections.Generic;
using UnityEngine;
using UInt8 = System.Byte;

public class LocalSummonEntity
{
    public UInt64 ID { get; set; }
    public Avatar VisualBody { get { return _visualBody; } }
    public ViPriorityValue<float> Scale { get { return _scale; } }
    public  float BodyRadius { get { return 0.5f; } }
    public virtual float BodyHeight { get { return 8.0f; } }

    public Action LoadedCallBack;


    public void Start(Transform parent)
    {
        Scale.UpdatedExec = this.OnScaleUpdated;
        _parent = parent;
    }

    public void End()
    {
        for (int i = 0; i < _timeNode1List.Count; i++)
        {
            _timeNode1List[i].Detach();
            _timeNode1List[i] = null;
        }
        _timeNode1List.Clear();
        _timeNode1List = null;
        _ownExpressList.End();
        _expressList.End();
        _visualBody.Clear();
        Scale.UpdatedExec = null;
    }

    public void OnScaleUpdated(float oldValue, float newValue)
    {
        _visualBody.RootTran.localScale = Vector3.one * Scale.Value;
    }

    public void SetScale(float value)
    {
        _scale = new ViPriorityValue<float>(value);
    }

    public void SetVisual(PathFileResStruct body, ViStaticArray<ViForeignKeyStruct<PathFileResStruct>> partList)
    {
        AvatarCreator.Create(_visualBody, body, 1.0f, partList);
        _visualBody.LoadCallback = this.OnVisualLoad;
    }

    void OnVisualLoad(Avatar avatar)
    {
        avatar.RootTran.SetParent(_parent);
        avatar.RootTran.localPosition = Vector3.zero;
        avatar.RootTran.localRotation = Quaternion.identity;
        avatar.RootTran.localScale = Vector3.one * Scale.Value;

        if (LoadedCallBack != null)
        {
            LoadedCallBack();
        }
    }
    public Transform GetTransform(int pos)
    {
        if (VisualBody.Property != null)
        {
            return VisualBody.Property.GetAttachPos(pos);
        }
        else
        {
            return VisualBody.RootTran;
        }
    }
    public bool PlaySound(int id)
    {
        PathFileResStruct resourceData = ViSealedDB<PathFileResStruct>.Data(id);
        if (resourceData.IsNotNull())
        {
            AttachedSpaceExpress express = new AttachedSpaceExpress();
            express.CameraAnim = false;
            express.IsLocal = false;
            express.Start(resourceData, VisualBody.RootTran);
            express.SoundDuration = true;
            _ownExpressList.Add(express);
            return true;
        }
        return false;
    }
    public void PlayActionAnim(string name)
    {
        VisualBody.PlayActionAnim(name, true);
    }
    public void PlayStateAnim(string name)
    {
        VisualBody.PlayStateAnim(name);
    }
    public void StopStateAnim(string name)
    {
        VisualBody.StopStateAnim(name);
    }
    public void PlayEffectVisual(ViVisualAuraStruct.EffectStruct effectStruct,uint randomIndex = 0)
    {
        if (effectStruct == null)
        {
            return;
        }
        switch ((ViEffectPlayType)effectStruct.effectPlayType.Value)
        {
            case ViEffectPlayType.PUSHALL:
                {
                    int flag = 0;
                    foreach (ViAttachExpressStruct expressInfo in effectStruct.express.Array)
                    {
                        _timeNode1List[flag].Value1 = expressInfo;
                        if((ViAuraEffectAnimType)effectStruct.effectAnimType.Value == ViAuraEffectAnimType.CONDITION)
                            _timeNode1List[flag].Value2 = effectStruct.effectAnim[flag];
                        ViTimerInstance.SetTime<ViAttachExpressStruct,ViAnimStruct>(_timeNode1List[flag], effectStruct.effectAnimDelayTime[flag], _OnWaitDelayCallBack);
                        flag++;
                    }
                }
                break;
            case ViEffectPlayType.ONEBYONE:
                {
                    int flag = 0;
                    int delayTime = 0;
                    foreach (ViAttachExpressStruct expressInfo in effectStruct.express.Array)
                    {
                        if (flag == 0)
                            delayTime = effectStruct.effectAnimDelayTime[flag];
                        _timeNode1List[flag].Value1 = expressInfo;
                        if ((ViAuraEffectAnimType)effectStruct.effectAnimType.Value == ViAuraEffectAnimType.CONDITION)
                            _timeNode1List[flag].Value2 = effectStruct.effectAnim[flag];
                        ViTimerInstance.SetTime<ViAttachExpressStruct, ViAnimStruct>(_timeNode1List[flag], delayTime, _OnWaitDelayCallBack);
                        flag++;
                        delayTime += effectStruct.effectAnimDelayTime[flag];
                    }
                }
                break;
            case ViEffectPlayType.RANDOM:
                {
                    if (randomIndex < effectStruct.express.Array.Length)
                    {
                        int flag = (int)randomIndex;
                        _timeNode1List[flag].Value1 = effectStruct.express.Array[flag];
                        if ((ViAuraEffectAnimType)effectStruct.effectAnimType.Value == ViAuraEffectAnimType.CONDITION)
                            _timeNode1List[flag].Value2 = effectStruct.effectAnim[flag];
                        ViTimerInstance.SetTime<ViAttachExpressStruct, ViAnimStruct>(_timeNode1List[flag], effectStruct.effectAnimDelayTime[flag], _OnWaitDelayCallBack);
                    }
                }
                break;
        }
    }

    private void _OnWaitDelayCallBack(ViTimeNodeInterface node, ViAttachExpressStruct expressInfo, ViAnimStruct animInfo)
    {
        if (!expressInfo.IsEmpty())
        {
            AttachedSpaceExpress express = new AttachedSpaceExpress();
            express.CameraAnim = false;
            express.AttachMask = (UInt32)expressInfo.attachMask;
            ViVector3 offset = new ViVector3(0, 0, BodyHeight * 0.01f);
            express.Start(expressInfo.res.Data, 0.0f, VisualBody.Property.GetAttachPos(expressInfo.attachPos), offset);
            _expressList.Add(express);
        }
        if (!animInfo.IsEmpty())
        {
            PlayActionAnim(animInfo.res);
        }
    }
    /// <summary>
    /// 播放受击特效
    /// </summary>
    /// <param name="hitEffectID"></param>
    /// <param name="position"></param>
    /// <param name="yaw"></param>
    /// <returns></returns>
    public int PlayHitEffect(int hitEffectID, ViVector3 position, float yaw)
    {
        GroundHeight.GetGroundHeight(ref position);
        position.z += 0.05f;
        ViSimpleProvider<ViVector3> posProvider = new ViSimpleProvider<ViVector3>(position);
        ViVisualHitEffectStruct effectVisualInfo = ViSealedDB<ViVisualHitEffectStruct>.Data(hitEffectID);
        int totalTime = 0;
        for (int iter = 0; iter < effectVisualInfo.express.Length; ++iter)
        {
            ViAttachExpressStruct iterInfo = effectVisualInfo.express[iter];
            if (!iterInfo.IsEmpty())
            {
                FreeSpaceExpressEx express = new FreeSpaceExpressEx();
                express.CameraAnim = false;
                express.IsLocal = false;
                express.Scale = iterInfo.Scale;
                express.AttachMask = (UInt32)(iterInfo.attachMask);
                express.Start(iterInfo.res.Data, posProvider, yaw, iterInfo.delayTime * 0.01f, iterInfo.duration * 0.01f);
            }
        }
        return 0;
    }
    //
    SimpleAvatarStruct _info;
    Avatar _visualBody = new Avatar();
    ViPriorityValue<float> _scale = new ViPriorityValue<float>(2.0f);
    LocalSpellVisualProccess _spellProc = new LocalSpellVisualProccess();
    ViExpressOwnList<ViExpressInterface> _ownExpressList = new ViExpressOwnList<ViExpressInterface>();
    ViExpressOwnList<ViExpressInterface> _expressList = new ViExpressOwnList<ViExpressInterface>();
    List<ViTimeNodeEx2<ViAttachExpressStruct, ViAnimStruct>> _timeNode1List = new List<ViTimeNodeEx2<ViAttachExpressStruct, ViAnimStruct>>(5)
    {
        new ViTimeNodeEx2<ViAttachExpressStruct, ViAnimStruct>(),
        new ViTimeNodeEx2<ViAttachExpressStruct, ViAnimStruct>(),
        new ViTimeNodeEx2<ViAttachExpressStruct, ViAnimStruct>(),
        new ViTimeNodeEx2<ViAttachExpressStruct, ViAnimStruct>(),
        new ViTimeNodeEx2<ViAttachExpressStruct, ViAnimStruct>()
    };
    Transform _parent;
}

