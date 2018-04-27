using PhysicalShading;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Avatar
{
    public delegate void DeleCallback(Avatar avatar);
    public DeleCallback LoadCallback;

    public Collider Collider { get { return _collider; } } //人物clider
    public string Name { set { _root.name = value; } } //根节点名称
    public bool Loading { get { return (pBodyPart == null || pBodyPart.IsLoading()); } }//是否正在（身体）加载
    public Int32 LODLevel;
    public float PartScale = 1.0f;
    public AnimationController AnimController { get { return _animationController; } } //ac
    public MoveAnimMixer MoveAnimMixer { get { return _moveAnimMixer; } }
    public AvatarFaceAnimator Face { get { return _face; } }
    public Animation Anim { get { return _animation; } } //动画
    public ViPriorityValue<string> IdleAnimName { get { return _idleAnimName; } }
    public Dictionary<string, string> AnimReplacer { get { return _animReplacer; } }
    public GameObject Root { get { return _root; } }
    public Transform RootTran { get { return _rootTran; } }

    public Transform SeeFace { get { return _seeface; } }
    public GameObject Visual { get { return _visual; } }
    public Transform VisualTran { get { return _visualTran; } }
    public AvatarProperty Property { get { return _property; } }
    public ViAvatarDurationVisualControllers<Avatar> DurationVisualControllers { get { return _durationVisualControllers; } }
    public ViAvatarDurationVisualOwnList<Avatar> DurationVisualOwnList { get { return _durationVisualOwnList; } }
    public string Tag { get; set; }

    private List<Transform> allBones;
    public bool Active
    {
        set
        {
            _active = value;
            if (_visual != null)
            {
                _visual.SetActive(_active);
                AnimController.Revert(Anim);
            }
        }
    }
    public bool Visiable{ get;private set;}

    public Avatar()
    {
        _rootTran = _root.transform;
        _idleAnimName.UpdatedExec = this.UpdateIdleAnimName;
        Visiable = true;
    }

    /// <summary>
    /// 加载身体，模型的话就是
    /// </summary>
    public void SetBody(PathFileResStruct path)
    {
        if (path == null || path.ID == 0)
        {
            ViDebuger.Error("传入身体参数pathfile id==0");
            return;
        }
        if (pBodyPart != null)
        {
            return;
        }
        pBodyPart = new AvatarPart();
        pBodyPart.Start(1000070, PlayerEquipSlotType.HAND, path, LODLevel, SetVisual);
    }
    public void SetBody(int id)
    {
        if (pBodyPart != null)
        {
            return;
        }
        pBodyPart = new AvatarPart();
        pBodyPart.Start(id, PlayerEquipSlotType.HAND, ViSealedDB<PathFileResStruct>.Data(id), LODLevel, SetVisual);
    }

    private void SetVisual(PlayerEquipSlotType type)
    {
        _visual = UnityAssisstant.InstantiateAsChild(pBodyPart.Obj, _rootTran);
        _visual.SetActive(_active); //设置状态
        _visualTran = _visual.transform;
        _seeface = _visualTran.Find("body/Seeface");
        _property = UnityAssisstant.CreateComponent<AvatarProperty>(_visual);
        allBones = new List<Transform>();
        allBones.AddRange(_visual.transform.GetComponentsInChildren<Transform>(true));
        UnityAssisstant.SetLayerRecursively(_visual, (int)UnityLayer.ENTITY);
        if (_property.BodyLow != null)
        {
            _property.BodyLow.SetActive(false);
            UnityAssisstant.SetLayerRecursively(_property.BodyLow, (int)UnityLayer.ENTITY_LOW);
        }
        //
        _animation = _visual.GetComponentInChildren<Animation>();
        if (_animation != null)
        {
            AnimationData.Format(_animation, 1.0f);
            _animationController.Start(_animation, false);
            _animationController.MoveLayer.SetDefault(_animation, IdleAnimName.Value);
        }

        if (_property.MoveMix != null)
        {
            _moveAnimMixer.SetMixNode(Anim, _property.MoveMix);
        }
        //
        _collider = _visual.GetComponentInChildren<Collider>();
        if (_collider != null)
            _collider.isTrigger = true;
        Rigidbody rigidbody = UnityAssisstant.CreateComponent<Rigidbody>(_visual);
        rigidbody.useGravity = false;
        _face = _visual.GetComponentInChildren<AvatarFaceAnimator>();
        // _visual.AddComponent<ForcePlanar>();
        if (LoadCallback != null)
            LoadCallback(this);
        LoadCallback = null;
        OnLoad();
    }


    /// <summary>
    /// 获得不同类型list
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
	List<AvatarPart> GetPartList(AvatarPartType type)
    {
        if (type == AvatarPartType.SKIN)
        {
            return _skinPartList;
        }
        else
        {
            return _linkPartList;
        }
    }

    public void SetPart(List<int> res, byte gender)
    {
        if (res != null && res.Count != 0)
        {
            for (int i = 0; i < res.Count; i++)
            {
                SetPart(res[i], gender);
            }
        }
    }

    /// <summary>
    /// 设置身体装备部分
    /// </summary>
    /// <param name="id"></param>
    public void SetPart(int id, byte gender)
    {
        AvatarPartType type = GetTypeByItemId(id, gender);
        if (type != AvatarPartType.None)
        {
            List<AvatarPart> partList = GetPartList(type);
            PlayerEquipSlotType slotType = GetPostionTypeById(false, id);
            int idx = GetIndexByType(partList, slotType);

            if (idx >= 0)
            {
                if (partList[idx].ID != id)
                {
                    AvatarPart newPart = new AvatarPart();
                    if (gender == 0)
                        newPart.Start(id, slotType, ViSealedDB<VisualItemStruct>.Data(id).MalePathFile, LODLevel, OnPartLoaded);
                    else if (gender == 1)
                        newPart.Start(id, slotType, ViSealedDB<VisualItemStruct>.Data(id).FeMalePathFile, LODLevel, OnPartLoaded);
                    partList[idx] = newPart;
                }
            }
            else
            {
                AvatarPart newPart = new AvatarPart();
                if (gender == 0)
                    newPart.Start(id, slotType, ViSealedDB<VisualItemStruct>.Data(id).MalePathFile, LODLevel, OnPartLoaded);
                else if (gender == 1)
                    newPart.Start(id, slotType, ViSealedDB<VisualItemStruct>.Data(id).FeMalePathFile, LODLevel, OnPartLoaded);
                partList.Add(newPart);
            }
        }
    }

    /// <summary>
    /// 设置头发或是脸型
    /// </summary>
    /// <param name="id"></param>
    public void SetFaceOrFair(int id)
    {
        if (id != 0 && ViSealedDB<VisualCornerList>.Data(id).path != 0)
        {
            List<AvatarPart> partList = GetPartList(AvatarPartType.SKIN);
            PlayerEquipSlotType slotType = GetPostionTypeById(true, id);
            int idx = GetIndexByType(partList, slotType);

            if (idx >= 0)
            {
                if (partList[idx].ID != id)
                {
                    AvatarPart newPart = new AvatarPart();
                    newPart.Start(id, slotType, ViSealedDB<VisualCornerList>.Data(id).path, LODLevel, OnPartLoaded);
                    partList[idx] = newPart;
                }
            }
            else
            {
                AvatarPart newPart = new AvatarPart();
                newPart.Start(id, slotType, ViSealedDB<VisualCornerList>.Data(id).path, LODLevel, OnPartLoaded);
                partList.Add(newPart);
            }
        }
    }


    /// <summary>
    /// 根据id获得所在挂点位置
    /// </summary>
    /// <param name="isFaceOrFair"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    private PlayerEquipSlotType GetPostionTypeById(bool isFaceOrFair, int id)
    {
        if (!isFaceOrFair)
            return (PlayerEquipSlotType)ViSealedDB<ItemStruct>.Data(id).EquipSlot.Value;
        else
            return (PlayerEquipSlotType)ViSealedDB<VisualCornerList>.Data(id).type.Value;
    }
    /// <summary>
    /// 根据类型获取list所在位置索引
    /// </summary>
    private int GetIndexByType(List<AvatarPart> list, PlayerEquipSlotType type)
    {
        return list.FindIndex((AvatarPart part) => { if (part.part == type) return true; else return false; });
    }

    public void ClearPart(Int32 idx, AvatarPartType type)
    {
        List<AvatarPart> partList = GetPartList(type);
        AvatarPart oldPart = partList[idx];
        partList[idx] = null;
        //
        if (oldPart != null)
        {
            if (oldPart.Obj != null)
            {
                UnityAssisstant.Destroy(ref oldPart.Obj);
            }
            //
            oldPart.End();
        }
    }

    static void ClearPart(List<AvatarPart> list)
    {
        for (int iter = 0; iter < list.Count; ++iter)
        {
            AvatarPart iterPart = list[iter];
            list[iter] = null;
            if (iterPart != null)
            {
                iterPart.End();
            }
        }
        list.Clear();
    }


    public void Clear()
    {
        LoadCallback = null;
        //
        DurationVisualOwnList.Clear(this, true);
        DurationVisualControllers.Clear(this, true);
        //
        ClearPart(_linkPartList);
        ClearPart(_skinPartList);
        //
        _visualRendererList.Clear();
        //
        if (_face != null)
        {
            _face.Clear();
        }
        //
        _ghostList.Clear();
        //
        UnityAssisstant.Destroy(ref _root);
    }

    public void Clear(float dropScale)
    {
        LoadCallback = null;
        //
        DurationVisualOwnList.Clear(this, true);
        DurationVisualControllers.Clear(this, true);
        //
        ClearPart(_linkPartList);
        ClearPart(_skinPartList);
        //
        _visualRendererList.Clear();
        //
        if (_face != null)
        {
            _face.Clear();
        }
        //
        if (_property != null)
        {
            if (_property.BodyLow != null)
            {
                _property.BodyLow.SetActive(false);
            }
        }
        //
        _ghostList.Clear();
        //
        if (_visual != null)
        {
            UnityAssisstant.CreateComponent<FadeOutProperty>(_visual);
        }
        UnityDeletor.Node deleteNode = UnityAssisstant.DestroyEx(ref _root, dropScale);
    }





    static List<Material> CACHE_Materials = new List<Material>(20);
    static List<Transform> CACHE_Bones = new List<Transform>(50);



    /// <summary>
    /// 身体创建完成的回调
    /// </summary>
    void OnPartLoaded(PlayerEquipSlotType type)
    {
        if (pBodyPart.IsLoading())
        {
            return;
        }
        if (_visual == null)
        {
            Debug.Log("_visual is not com");
            _initTime = ViTimerInstance.Time;
        }



        if (GetTypeBySlotType(type) == AvatarPartType.LINK)
        {
            for (int i = 0; i < _linkPartList.Count; ++i)
            {
                if (_linkPartList[i] != null && _linkPartList[i].IsLoading())
                {
                    return;
                }
            }
            for (int iter = 0; iter < _linkPartList.Count; ++iter)
            {
                AvatarPart iterPart = _linkPartList[iter];
                if (iterPart != null)
                {
                    iterPart.ClearOld();
                    Transform iterTran = _property.GetAttachPos(ViSealedDB<VisualItemStruct>.Data(iterPart.ID).EquipInfo.PData.ModelJoint.Value);
                    iterTran.localScale = Vector3.one * PartScale;
                    iterPart.Obj = UnityAssisstant.InstantiateAsChild(iterPart.Obj, iterTran);
                    UnityAssisstant.SetLayerRecursively(iterPart.Obj, (int)UnityLayer.ENTITY);
                }
            }
        }
        else if (GetTypeBySlotType(type) == AvatarPartType.SKIN)
        {
            for (int i = 0; i < _skinPartList.Count; ++i)
            {
                if (_skinPartList[i] != null && _skinPartList[i].IsLoading())
                {
                    return;
                }
            }
            _skinCombineList.Clear();
            for (int iter = 0; iter < _skinPartList.Count; ++iter)
            {
                AvatarPart iterPart = _skinPartList[iter];
                if (iterPart != null)
                {
                    iterPart.ClearOld();
                    GameObject iterObj = UnityAssisstant.Instantiate(iterPart.Obj);
                    CombineSkin(_visual, iterObj, CACHE_Materials, CACHE_Bones, _skinCombineList);//获得合并的数据
                    UnityEngine.Object.Destroy(iterObj);
                }
            }
            if (_skinCombineList.Count > 0)//合并
            {
                SkinnedMeshRenderer skinMeshRender = UnityAssisstant.CreateComponent<SkinnedMeshRenderer>(_visual);
                skinMeshRender.sharedMesh = new Mesh();
                skinMeshRender.sharedMesh.CombineMeshes(_skinCombineList.ToArray(), false, false);
                skinMeshRender.bones = CACHE_Bones.ToArray();
                skinMeshRender.materials = CACHE_Materials.ToArray();
            }
            CACHE_Materials.Clear();
            CACHE_Bones.Clear();
        }
        OnLoad();
    }

    void OnLoad()
    {
        _visualRendererList.Clear();
        UnityComponentList<Renderer>.Begin(Visual, true);
        _visualRendererList.AddRange(UnityComponentList<Renderer>.List);
        UnityComponentList<Renderer>.End();
        //
        UpdateGhost();
        //
        if (LoadCallback != null)
        {
            LoadCallback(this);
            LoadCallback = null;
        }
        // if use shadow
        if (true)
        {
            _shadowMaterial = new Material(RenderPipeline.PlanarShadowShader());
        }
    }
    /// <summary>
    /// 获得这个物体下面的material ，bone ，CombineInstance
    /// </summary>
    /// <param name="root"></param>
    /// <param name="skinObj"></param>
    /// <param name="materialList"></param>
    /// <param name="boneList"></param>
    /// <param name="combineList"></param>
    void CombineSkin(GameObject root, GameObject skinObj, List<Material> materialList, List<Transform> boneList, List<CombineInstance> combineList)
    {
        SkinnedMeshRenderer skin = skinObj.GetComponentInChildren<SkinnedMeshRenderer>();
        for (int iter = 0; iter < skin.materials.Length; ++iter)
        {
            Material iterMaterial = skin.materials[iter];
            iterMaterial.renderQueue = (int)ShaderQueueLayer.AVATARINTERFACE;
            materialList.Add(iterMaterial);
        }
        for (int iter = 0; iter < skin.sharedMesh.subMeshCount; ++iter)
        {
            CombineInstance ci = new CombineInstance();
            ci.mesh = skin.sharedMesh;
            ci.subMeshIndex = iter;
            combineList.Add(ci);
        }
        for (int j = 0; j < skin.bones.Length; j++)
        {
            for (int tBase = 0; tBase < allBones.Count; tBase++)
            {
                if (skin.bones[j].name.Equals(allBones[tBase].name))
                {
                    boneList.Add(allBones[tBase]);
                    break;
                }
            }
        }

        //BoneNameList iterBoneNames = skinObj.GetComponent<BoneNameList>();
        //for (int iter = 0; iter < iterBoneNames.content.Length; ++iter)
        //{
        //    string iterName = iterBoneNames.content[iter];
        //    Transform iterBone = root.transform.Find(iterName);
        //    if (iterBone != null)
        //    {

        //    }
        //    else
        //    {
        //        ViDebuger.Warning("CharacterAvatar" + root.name + ".AssemblingMesh [" + skin.gameObject.name + "]Not find Bone(" + iterName + ")");
        //    }
        //}
    }

    public void UpdateShadow(float z)
    {
        if (_visual != null && _shadowMaterial != null && Visiable)
        {
            _shadowMaterial.SetVector("_ShadowPlane", new Vector4(0, 1, 0, -z));
            RenderPipeline.RenderShadow(ref _visualRendererList, _shadowMaterial);
        }
        //ForcePlanar com = _visual.GetComponent<ForcePlanar>();
        //if (com)
        //    com.plane.w = -z;
    }

    private AvatarPartType GetTypeByItemId(int id, byte gender)
    {
        ItemStruct type = ViSealedDB<ItemStruct>.Data(id);
        if (gender == 0 && ViSealedDB<VisualItemStruct>.Data(id).MalePathFile == 0)
            return AvatarPartType.None;
        else if (gender == 1 && ViSealedDB<VisualItemStruct>.Data(id).FeMalePathFile == 0)
            return AvatarPartType.None;
        switch ((PlayerEquipSlotType)type.EquipSlot.Value)
        {
            case PlayerEquipSlotType.WEAPON:
                return AvatarPartType.LINK;
            case PlayerEquipSlotType.RIGHTWEAPON:
                return AvatarPartType.LINK;
            case PlayerEquipSlotType.SHOULDER:
                return AvatarPartType.SKIN;
            case PlayerEquipSlotType.BODY:
                return AvatarPartType.SKIN;
            case PlayerEquipSlotType.LEG:
                return AvatarPartType.SKIN;
            default:
                return AvatarPartType.None;
        }
    }

    private AvatarPartType GetTypeBySlotType(PlayerEquipSlotType type)
    {

        switch (type)
        {
            case PlayerEquipSlotType.WEAPON:
                return AvatarPartType.LINK;
            case PlayerEquipSlotType.RIGHTWEAPON:
                return AvatarPartType.LINK;

            case PlayerEquipSlotType.SHOULDER:
                return AvatarPartType.SKIN;
            case PlayerEquipSlotType.BODY:
                return AvatarPartType.SKIN;
            case PlayerEquipSlotType.LEG:
                return AvatarPartType.SKIN;
            case PlayerEquipSlotType.Face:
                return AvatarPartType.SKIN;
            case PlayerEquipSlotType.Fair:
                return AvatarPartType.SKIN;
            default:
                return AvatarPartType.None;
        }
    }

    /// <summary>
    /// UI 摄像机渲染没有后处理，修改shader
    /// </summary>
    public void ChangeUIShander()
    {
        if (_visual != null)
        {
            Transform trans = _visual.transform.Find("Body");
            int count = trans.childCount;
            for (int i = 0; i < count; i++)
            {
                SkinnedMeshRenderer mat = trans.GetChild(i).GetComponent<SkinnedMeshRenderer>();
                if (mat != null)
                {
                    string str = IsShaderContainString(mat.material.shader.name);
                    if (str != "")
                    {
                        mat.material.shader = Shader.Find(str);
                    }
                }
            }
        }
    }

    private string IsShaderContainString(string name)
    {
        if (name.Contains("PBR"))
            return "Physical Shading/Character/UIPBR";
        else if (name.Contains("Hair"))
            return "Physical Shading/Character/UIHair";
        else if (name.Contains("PBRGlow"))
            return "Physical Shading/Character/UIPBRGlow";
        return "";
    }
    public void SetBodyVisiable(bool visiable)
    {
        if (Root == null)
        {
            return;
        }

        Visiable = visiable;
        //隐藏模型,隐藏影子
        Renderer[] renderers = Root.GetComponentsInChildren<Renderer>();

        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].enabled = visiable;
        }
    }


    GameObject _root = new GameObject("Entity");
    bool _active = true;  //是否显示的状态
    AvatarProperty _property;
    GameObject _visual; //avatar创建出来的物体(可以看成骨架)
    List<Renderer> _visualRendererList = new List<Renderer>();
    List<CombineInstance> _skinCombineList = new List<CombineInstance>();
    Collider _collider;
    AvatarFaceAnimator _face;
    Transform _rootTran;
    Transform _seeface;
    Transform _visualTran;
    Int64 _initTime;
    List<AvatarPart> _linkPartList = new List<AvatarPart>();
    List<AvatarPart> _skinPartList = new List<AvatarPart>();

    AvatarPart pBodyPart = null; //身体部分

    ViAvatarDurationVisualControllers<Avatar> _durationVisualControllers = new ViAvatarDurationVisualControllers<Avatar>();
    ViAvatarDurationVisualOwnList<Avatar> _durationVisualOwnList = new ViAvatarDurationVisualOwnList<Avatar>();







    #region Anim

    public string AnimReplace(string name)
    {
        string newName;
        if (AnimReplacer.TryGetValue(name, out newName))
        {
            if (Anim != null)
            {
                if (Anim[newName] == null)
                {
                    newName = name;
                }
            }
            return newName;
        }
        else
        {
            return name;
        }
    }
    public bool IsActionAnimPlaying()
    {
        if (_lastActionAnim == null)
        {
            return false;
        }
        if (Anim == null)
        {
            return false;
        }
        return Anim.IsPlaying(_lastActionAnim);
    }
    public void PlayActionAnim(string name, bool breakCurrent)
    {
        if (Anim == null)
        {
            return;
        }
        name = AnimReplace(name);
        name = AnimationAssisstant.Alias(name, Anim);
        if (!_animationController.MoveLayer.IsDefaultPlaying && IsMoveBreakAnim(name))
        {
            return;
        }
        _lastActionAnim = name;
        _animationController.Play(Anim, name, breakCurrent);
    }
    public void StopActionAnim(string name)
    {
        name = AnimReplace(name);
        name = AnimationAssisstant.Alias(name, Anim);
        if (Anim != null)
        {
            _animationController.Stop(Anim, name);
        }
        if (string.IsNullOrEmpty(_lastActionAnim) && string.Equals(_lastActionAnim, name, StringComparison.CurrentCultureIgnoreCase))
        {
            _lastActionAnim = null;
        }
    }
    public void StopActionAnim()
    {
        if (!string.IsNullOrEmpty(_lastActionAnim))
        {
            StopActionAnim(_lastActionAnim);
            _lastActionAnim = null;
        }
    }
    public void BlendAnim(string name)
    {
        name = AnimReplace(name);
        name = AnimationAssisstant.Alias(name, Anim);
        if (Anim != null)
        {
            _animationController.Blend(Anim, name);
        }
    }
    //
    public void PlayStateAnim(string name)
    {
        bool blend = (ViTimerInstance.Time - _initTime) > 30;
        PlayStateAnim(name, 0, blend);
    }
    public void PlayStateAnim(string name, float startTime, bool blend)
    {
        name = AnimReplace(name);
        name = AnimationAssisstant.Alias(name, Anim);
        _animationController.StateLayer.Play(Anim, name, startTime, blend);
    }
    public void StopStateAnim(string name)
    {
        name = AnimReplace(name);
        name = AnimationAssisstant.Alias(name, Anim);
        _animationController.StateLayer.Stop(Anim, name);
    }
    public void StopStateAnim()
    {
        _animationController.StateLayer.Stop(Anim);
    }
    public void PlayDieAnim(string name)
    {
        name = AnimReplace(name);
        name = AnimationAssisstant.Alias(name, Anim);
        _animationController.DieLayer.Play(Anim, name, false);
    }
    public void PlayDieAnim(string name, float startTime, bool blend)
    {
        name = AnimReplace(name);
        name = AnimationAssisstant.Alias(name, Anim);
        _animationController.DieLayer.Play(Anim, name, startTime, blend);
    }
    public void StopDieAnim(string name)
    {
        name = AnimReplace(name);
        name = AnimationAssisstant.Alias(name, Anim);
        _animationController.DieLayer.Stop(Anim, name);
    }
    public void StopDieAnim()
    {
        _animationController.DieLayer.Stop(Anim);
    }

    public ViActiveValue<float> LookValue;

    public void SetLook(float progress)
    {
        LookValue.Set(progress);
        /* Unity傻叉有bug
		StartPosition(AnimationData.LookLR);
		SetPosition(AnimationData.LookLR, progress);
		*/
        if (progress < 0.5f)
        {
            progress = (0.5f - progress) * 2;
            //StartPosition(AnimationData.LookL);
            //SetPosition(AnimationData.LookL, progress);
        }
        else
        {
            progress = (progress - 0.5f) * 2;
            //StartPosition(AnimationData.LookR);
            //SetPosition(AnimationData.LookR, progress);
        }
    }

    public void ClearLook()
    {
        if (LookValue.Active)
        {
            //_animationController.Stop(_animation, AnimationData.LookL);
            //_animationController.Stop(_animation, AnimationData.LookR);
            //_animationController.Stop(_animation, AnimationData.LookLR);
        }
        LookValue.Clear();
    }

    public void SetPosition(string name, float time)
    {
        _animationController.SetPosition(name, time, _animation);
    }
    public void StartPosition(string name)
    {
        _animationController.StartPosition(name, _animation);
    }
    public void EndPosition(string name)
    {
        _animationController.EndPosition(name, _animation);
    }

    public void SetAnimSpeed(string name, float spd)
    {
        if (Anim != null)
        {
            _animationController.SetSpeed(name, spd, Anim);
        }
    }

    public bool IsMoveBreakAnim(string name)
    {
        return AnimationData.IsMoveBreakAnim(name);
    }
    public bool IsLoopAnim(string name)
    {
        return AnimationData.IsLoopAnim(name);
    }

    public void SetAnimSpeed(float speed)
    {
        if (Anim != null)
        {
            AnimController.SetDefaultSpeed(Anim, speed);
            //
            UnityComponentList<Animation>.Begin(_root);
            for (int iter = 0; iter < UnityComponentList<Animation>.List.Count; ++iter)
            {
                AnimationController.SetSpeed(UnityComponentList<Animation>.List[iter], speed);
            }
            UnityComponentList<Animation>.End();
        }
    }

    void UpdateIdleAnimName(string oldValue, string newValue)
    {
        _animationController.MoveLayer.SetDefault(_animation, IdleAnimName.Value); //重新播放？
    }

    public float GetAnimStateLen(string name)
    {
        if (Anim == null)
        {
            return 0.0f;
        }
        AnimationState animState = Anim[name];
        if (animState != null)
        {
            return animState.length;
        }
        else
        {
            return 0.0f;
        }
    }

    Animation _animation; //动画
    AnimationController _animationController = new AnimationController();
    Dictionary<string, string> _animReplacer = new Dictionary<string, string>();
    ViPriorityValue<string> _idleAnimName = new ViPriorityValue<string>(AnimationData.Idle);//idle动画名字(为了动画更改的时候，有回调)
    string _lastActionAnim = null;
    MoveAnimMixer _moveAnimMixer = new MoveAnimMixer();

    // shadowMaterial
    Material _shadowMaterial = null;

    #endregion

    #region Ghost

    class GhostStruct
    {
        public GameObject Obj;
        public Material Material;
        public UnityAssisstant.GhostMaterialReplace BodyReplace;
        public UnityAssisstant.GhostMaterialReplace PartReplace;
        public bool HideVisual;
    }

    public virtual GameObject _CreateGhost(Material material, string name, bool hideVisual, UnityAssisstant.GhostMaterialReplace bodyMaterialReplace, UnityAssisstant.GhostMaterialReplace partMaterialReplace)
    {
        if (Visual == null)
        {
            return null;
        }
        //
        GameObject ghostObject = UnityAssisstant.CreateChild(RootTran, name, false);
        //
        if (_skinCombineList.Count > 0)
        {
            SkinnedMeshRenderer realMeshRender = Visual.GetComponent<SkinnedMeshRenderer>();
            if (realMeshRender == null)
            {
                SkinnedMeshRenderer skinMeshRender = UnityAssisstant.CreateComponent<SkinnedMeshRenderer>(_visual);
                skinMeshRender.sharedMesh = new Mesh();
                skinMeshRender.sharedMesh.CombineMeshes(_skinCombineList.ToArray(), false, false);
                skinMeshRender.bones = realMeshRender.bones;
                if (bodyMaterialReplace != null)
                {
                    skinMeshRender.material = bodyMaterialReplace(realMeshRender.material, material);
                }
                else
                {
                    skinMeshRender.material = material;
                }
            }
        }
        //
        UnityComponentList<SkinnedMeshRenderer>.Begin(Visual);
        for (int iter = 0; iter < UnityComponentList<SkinnedMeshRenderer>.List.Count; ++iter)
        {
            SkinnedMeshRenderer iterRender = UnityComponentList<SkinnedMeshRenderer>.List[iter];
            if (iterRender.sharedMesh == null)
            {
                continue;
            }
            if (iterRender.gameObject.name == GameObjectKeyName.BODY_LOW)
            {
                continue;
            }
            //
            UnityAssisstant.CreateGhostAvatar(ghostObject, iterRender, material, bodyMaterialReplace);
        }
        UnityComponentList<SkinnedMeshRenderer>.End();
        //
        return ghostObject;
    }

    public GameObject CreateGhost(string name, bool hideVisual, UnityAssisstant.GhostMaterialReplace bodyMaterialReplace, UnityAssisstant.GhostMaterialReplace partMaterialReplace)
    {
        GameObject materialObj = UnityAssisstant.GetChild(GlobalGameObject.Instance.MaterialInstance.RealObject, name);
        if (materialObj == null)
        {
            return null;
        }
        Renderer renderer = materialObj.GetComponent<Renderer>();
        if (renderer == null)
        {
            return null;
        }
        if (renderer.material == null)
        {
            return null;
        }
        if (HasGhost(name))
        {
            return null;
        }
        GameObject ghost = _CreateGhost(renderer.material, name, hideVisual, bodyMaterialReplace, partMaterialReplace);
        AddGhost(name, ghost, renderer.material, bodyMaterialReplace, partMaterialReplace, hideVisual);
        return ghost;
    }

    public void ClearGhost(bool updateRenderer)
    {
        foreach (KeyValuePair<string, GhostStruct> iter in _ghostList)
        {
            GhostStruct iterGhost = iter.Value;
            if (iterGhost.Obj != null)
            {
                UnityAssisstant.Destroy(ref iterGhost.Obj);
            }
        }
        _ghostList.Clear();
        //
        if (updateRenderer)
        {
            UpdateGhostVisual();
        }
    }

    public void ClearGhost(string name)
    {
        GhostStruct ghost;
        if (_ghostList.TryGetValue(name, out ghost))
        {
            _ghostList.Remove(name);
            UnityAssisstant.Destroy(ref ghost.Obj);
        }
        UpdateGhostVisual();
    }

    public void UpdateGhost()
    {
        if (Visual == null)
        {
            return;
        }
        foreach (KeyValuePair<string, GhostStruct> iter in _ghostList)
        {
            GhostStruct iterGhost = iter.Value;
            UnityAssisstant.Destroy(ref iterGhost.Obj);
            iterGhost.Obj = _CreateGhost(iterGhost.Material, iter.Key, iterGhost.HideVisual, iterGhost.BodyReplace, iterGhost.PartReplace);
        }
        UpdateGhostVisual();
    }

    protected bool HasGhost(string name)
    {
        return _ghostList.ContainsKey(name);
    }

    public GameObject GetGhost(string name)
    {
        if (_ghostList.ContainsKey(name))
        {
            return _ghostList[name].Obj;
        }
        //
        return null;
    }

    protected void AddGhost(string name, GameObject obj, Material material, UnityAssisstant.GhostMaterialReplace bodyReplace, UnityAssisstant.GhostMaterialReplace partReplace, bool hideVisual)
    {
        GhostStruct ghost = new GhostStruct();
        ghost.Obj = obj;
        ghost.Material = material;
        ghost.BodyReplace = bodyReplace;
        ghost.PartReplace = partReplace;
        ghost.HideVisual = hideVisual;
        _ghostList.Add(name, ghost);
        UpdateGhostVisual();
    }

    void UpdateGhostVisual()
    {
        if (Visual == null)
        {
            return;
        }
        bool renderShow = true;
        foreach (KeyValuePair<string, GhostStruct> iter in _ghostList)
        {
            if (iter.Value.HideVisual)
            {
                renderShow = false;
                break;
            }
        }
        //
        for (int iter = 0; iter < _visualRendererList.Count; ++iter)
        {
            _visualRendererList[iter].enabled = renderShow;
        }
    }

    Dictionary<string, GhostStruct> _ghostList = new Dictionary<string, GhostStruct>();

    #endregion

}
