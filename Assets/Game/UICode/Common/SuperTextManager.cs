using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public enum HintType
{
    NONE,
    ATTACK_PLAYER,//玩家操控的主角攻击其他人的伤害是用“白色”字体
    DAMAGE,//玩家受击和其他角色受击用“红色”字体
    REAL_DAMAGE,//主角打出真实伤害用“紫色”字体
    HEALTH,//主角或其他角色回复生命值用“绿色”字体
    CRITICAL, //所有角色暴击用“金色"字体
    NAME_BILL_BOARD,//人物头顶名牌
    GOAL_FLAG,//任务标识
    MAX
}
public class SuperTextManagerWrapper: DataManagerBase<SuperTextManagerWrapper>, IRelease
{
    public void Release()
    {
        SuperTextManager.Instance.Dispose();
    }
}
[ExecuteInEditMode]
public class SuperTextManager : MonoBehaviour, IDisposable
{
    public Shader ShareShader = null;//blend shader
    public Transform CriticalTran = null;
    public Transform HealthTran = null;
    public Transform AttackTran = null;
    public Transform BuffTran = null;
    public Transform RealAttackTran = null;
    public Transform BillBoardTran = null;
    public Transform GoalFlagTran = null;
    public const int NAME_BILL_BOARD_QUEUE = 3000;
    public const int HINT_QUEUE = 3001;

    public class TweenElement
    {
        public TweenScale ScaleCtrl { get; set; }
        public TweenAnim_alpha AlphaCtrl { get; set; }
        public TweenAnim_position PositionCtrl { get; set; }
        public void Restart(EventDelegate.Callback callback)
        {
            ScaleCtrl.ResetToBeginning();
            AlphaCtrl.ResetToBeginning();
            PositionCtrl.ResetToBeginning();
            ScaleCtrl.PlayForward();
            AlphaCtrl.PlayForward();
            PositionCtrl.PlayForward();
            AlphaCtrl.SetOnFinished(callback);
        }
        public void SetScalePara(Vector3 from, Vector3 to)
        {
            ScaleCtrl.from = from;
            ScaleCtrl.to = to;
        }
        public void SetAlphaPara(float from, float to)
        {
            AlphaCtrl.from = from;
            AlphaCtrl.to = to;
        }
        public void SetPositionPara(Vector3 from, Vector3 dir)
        {
            PositionCtrl.worldSpace = true;
            PositionCtrl.from = from;
            PositionCtrl.Dir = dir;
        }
        public void SetRandomDir(bool forward)
        {
            PositionCtrl.OffsetFlag = forward;
        }
    }
    public class SuperTextElement : PoolElement<HintType>
    {
        public SuperTextMesh TextMesh { get; set; }
        public Transform Tran { get; set; }
        public TweenElement Tween = new TweenElement();
        public UICallback.VOO_CB Callback { get; set; }
        public ViProvider<ViVector3> TargetPos { get; set; }
        public float TimeStamp { get; set; }//出生的时间戳

        public void Fire()
        {
            Tween.Restart(_onTweenOver);
        }
        private void _onTweenOver()
        {
            if (Callback != null)
                Callback(this, this.KeyType);
        }
        public override void Close()
        {
            base.Close();
        }
        public override void Open()
        {
            base.Open();
        }
        public void Update()
        {
            Camera cam = GlobalGameObject.Instance.SceneCamera;
            if (cam != null)
            {
                if (TargetPos != null)
                {
                    Vector3 pos = TargetPos.Value.Convert();
                    //this.Tran.position = pos;
                    pos = Vector3.Lerp(this.Tran.position, pos, Time.deltaTime * 50);
                    this.Tran.position = pos;
                }
                this.Tran.forward = cam.transform.forward;

            }
        }
        public void SetVisible(bool isVisible)
        {
            if (Tran != null)
                Tran.SetActive(isVisible);
        }
        public void Rebuild()
        {
            if (TextMesh != null)
            {
                TextMesh.Rebuild(0);
                if (this.KeyType == HintType.NAME_BILL_BOARD)
                    TextMesh.r.material.renderQueue = NAME_BILL_BOARD_QUEUE;
                else
                    TextMesh.r.material.renderQueue = HINT_QUEUE;
            }
                
        }
        public override void Dispose()
        {
            if (Tran != null)
                GameObject.DestroyImmediate(Tran.gameObject);
            Tran = null;
            TextMesh = null;
            TargetPos = null;
            base.Dispose();
        }
        public void SetText(string text)
        {
            if (TextMesh != null)
                TextMesh.text = text;
        }
        public void SetRenderQueueOffset(int offset)
        {
            if (this.KeyType == HintType.NAME_BILL_BOARD)
                TextMesh.r.material.renderQueue = NAME_BILL_BOARD_QUEUE + offset;
            else
                TextMesh.r.material.renderQueue = HINT_QUEUE + offset;
        }
        public void RestoreRenderQueue()
        {
            if (TextMesh == null)
            {
                return;
            }            
            if (this.KeyType == HintType.NAME_BILL_BOARD)
                TextMesh.r.material.renderQueue = NAME_BILL_BOARD_QUEUE;
            else
                TextMesh.r.material.renderQueue = HINT_QUEUE;
        }
    }
    private PoolManager<HintType, SuperTextElement> _targetPool = new PoolManager<HintType, SuperTextElement>();
    private Dictionary<string, STMQuadData> _quadData = new Dictionary<string, STMQuadData>();
    private static SuperTextManager _handler = null;
    private Dictionary<string, Material> _shareMat = new Dictionary<string, Material>();
    private int _showCount = 0;
    private int _maxQueue = 0;

    public static SuperTextManager Instance
    {
        get
        {
            SuperTextManagerWrapper instance = SuperTextManagerWrapper.GetInstance;
            return _handler;
        }
    }

    void Awake()
    {
        _handler = this;
    }

    public void SpwanFlyHint(string content, HintType ty, Vector3 pos)
    {
        SpwanFlyHint(content, ty, pos, Vector3.up);
    }
    public SuperTextElement SpwanNameBillBoard(string content, ViProvider<ViVector3> pos)
    {
        return _SpwanBillBoard(content, pos);
    }
    public void SpwanFlyHint(string content, HintType ty, Vector3 pos, Vector3 dir)
    {
        SuperTextElement element = _SpwanTarget(ty);
        element.TextMesh.text = UIUtility.MakeHitStr(content);
        element.SetVisible(true);
        element.Rebuild();
        element.Tween.SetPositionPara(pos, dir);
        if (_targetPool.GetPoolCount(ty) >= 2)
            element.Tween.SetRandomDir(!_targetPool.GetElement(ty, 1).Tween.PositionCtrl.OffsetFlag);
        _showCount++;
        _maxQueue = Mathf.Max(_maxQueue, _showCount);
        element.SetRenderQueueOffset(_maxQueue);
        element.Fire();
    }
    private SuperTextElement _SpwanBillBoard(string content, ViProvider<ViVector3> pos)
    {
        SuperTextElement element = _SpwanTarget(HintType.NAME_BILL_BOARD);
        element.TextMesh.text = content;
        element.TargetPos = pos;
        element.SetVisible(true);
        element.Rebuild();
        return element;
    }
    public SuperTextElement SpwanGoalFlag(ViProvider<ViVector3> pos)
    {
        SuperTextElement element = null;
        bool isNeedCreate = _targetPool.Spwan(HintType.GOAL_FLAG, out element);
        if (isNeedCreate)
        {
            Transform cpTran = _getCPTran(HintType.GOAL_FLAG);
            Transform tran = UnityAssisstant.Instantiate(cpTran.gameObject, Vector3.zero, Quaternion.identity).transform;
            tran.SetParent(cpTran.parent);
            element.Tran = tran;
            tran.localScale = Vector3.one;
        }
        element.TargetPos = pos;
        element.SetVisible(true);
        return element;
    }
    private SuperTextElement _SpwanTarget(HintType ty)
    {
        SuperTextElement element = null;
        bool isNeedCreate = _targetPool.Spwan(ty, out element);
        if (isNeedCreate)
            _CreateTarget(ty, ref element);
        return element;
    }
    public void CloseTarget(HintType type, SuperTextElement element)
    {
        if (element == null || _targetPool.GetPoolCount(type) == 0) return;
        _targetPool.Close(type, element);
        element.RestoreRenderQueue();
        element.SetVisible(false);
        _showCount--;
        _maxQueue = (_showCount == 0 ? 0 : _maxQueue);
    }
    public void CloseGoalFlag(SuperTextElement element)
    {
        if (element == null || 
            _targetPool.GetPoolCount(HintType.GOAL_FLAG) == 0)
            return;

        _targetPool.Close(HintType.GOAL_FLAG, element);
        element.SetVisible(false);
    }
    private void _CreateTarget(HintType type, ref SuperTextElement element)
    {
        Transform cpTran = _getCPTran(type);
        Transform tran = UnityAssisstant.Instantiate(cpTran.gameObject, Vector3.zero, Quaternion.identity).transform;
        tran.SetParent(this.transform);
        element.Tran = tran;
        element.TextMesh = tran.gameObject.GetComponent<SuperTextMesh>();
        if (type != HintType.NAME_BILL_BOARD)
        {
            element.Tween.AlphaCtrl = element.Tran.GetComponent<TweenAnim_alpha>();
            element.Tween.ScaleCtrl = element.Tran.GetComponent<TweenScale>();
            element.Tween.PositionCtrl = element.Tran.GetComponent<TweenAnim_position>();
            element.Callback = _onTweenOver;
            tran.localScale = Vector3.one;
        }
        else
        {
            tran.localScale = new Vector3(0.5f, 0.5f, 1f);
        }
        element.TextMesh.debugMode = true;

    }
    private Transform _getCPTran(HintType type)
    {
        switch (type)
        {
            case HintType.ATTACK_PLAYER: return AttackTran;
            case HintType.CRITICAL: return CriticalTran;
            case HintType.DAMAGE: return AttackTran;
            case HintType.HEALTH: return HealthTran;
            case HintType.REAL_DAMAGE: return RealAttackTran;
            case HintType.NAME_BILL_BOARD: return BillBoardTran;
            case HintType.GOAL_FLAG: return GoalFlagTran;
        }
        return null;
    }
    private void _onTweenOver(object element, object hintType)
    {
        HintType hType = (HintType)hintType;
        this.CloseTarget(hType, (SuperTextElement)element);
        //Debug.Log("-->Close hint id " + index);
    }
    public void Dispose()
    {
        _targetPool.Dispose();
        _shareMat.Clear();
    }
    public Material GetShareMat(UIAtlas atlas, Font font)
    {
        Material shareMat = null;
        string key = (atlas == null ? font.name : atlas.name + font.name);
        bool isNeedCreateMat = !_shareMat.TryGetValue(key, out shareMat);
        if (isNeedCreateMat)
        {
            shareMat = new Material(ShareShader);
            shareMat.SetTexture("_MainTex", font.material.mainTexture);
            if (atlas != null)
                shareMat.SetTexture("_SecondTex", atlas.texture);
            _shareMat.Add(key, shareMat);
            //ViDebuger.Record("--->GetShareMat need to recreate material altas[" + (atlas == null ? "null" : atlas.name) + "]" + ", font[" + font.name + "]");
        }
        return shareMat;
    }
    private void _RebuildAllText()
    {
        for (HintType i = HintType.NONE; i < HintType.MAX; ++i)
        {
            int textCount = this._targetPool.GetPoolCount(i);
            for (int j = 0; j < textCount; ++j)
            {
                SuperTextElement element = this._targetPool.GetElement(i, j);
                if (!element.IsClose())
                    element.Rebuild();
            }
        }
    }
    void OnApplicationFocus(bool focused)
    {
        if (focused && _handler != null)
            this._RebuildAllText();
    }
#if UNITY_EDITOR
    /// <summary>
    /// 检查所有材质，发现存在即进行替换，为了达到动态批处理的目的
    /// </summary>
    [ContextMenu("EditorRebuild")]
    void EditorRebuild()
    {
        SuperTextMesh[] superTexts = this.GetComponentsInChildren<SuperTextMesh>();
        for (int i = 0; i < superTexts.Length; ++i)
        {
            superTexts[i].Rebuild();
        }
    }
#endif
    void Update()
    {
        if (_targetPool == null) return;
        for (HintType i = HintType.NONE; i < HintType.MAX; ++i)
        {
            int textCount = this._targetPool.GetPoolCount(i);
            for (int j = 0; j < textCount; ++j)
            {
                SuperTextElement element = this._targetPool.GetElement(i, j);
                if(!element.IsClose())
                    element.Update();
            }
        }
    }
    ////for test.s
    //private List<Transform> trans = new List<Transform>();
    //private System.Random random = null;
    //[ContextMenu("Test")]
    //void Test()
    //{
    //    {
    //        for (int i = 0; i < 2000; ++i)
    //        {
    //            //this.SpwanTarget();
    //        }
    //        SuperTextMesh[] superTexts = this.GetComponentsInChildren<SuperTextMesh>();
    //        for (int i = 0; i < superTexts.Length; ++i)
    //        {
    //            superTexts[i].text = "<q=clap><c=green>hello world";
    //        }
    //    }
    //    //Check();
    //    random = new System.Random();
    //}
//    void Update()
//    {
        //if (Input.GetKeyDown(KeyCode.K))
        //{
        //    //for (int i = 0; i < trans.Count; ++i)
        //    //{
        //    //    trans[i].Translate(trans[i].forward * (random.Next(1, 10) * 1.0f / 500));
        //    //    trans[i].Translate(trans[i].up * (random.Next(1, 10) * 1.0f / 500));
        //    //}
        //    Test();
        //}

//    }
    ////for test.e
}
