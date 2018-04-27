using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


class tData
{
    public int mType = 0;// 0是类型 1是表
    public int mID = 0;

    public tData(int vType, int vID)
    {
        mType = vType;
        mID = vID;
    }
}

public class DebugControl : MonoBehaviour
{
    Camera mMainCamera = null;
    Transform mCameraTrans;
    GameObject mSceneObj = null;

    bool mFingerDown = false;
    Vector2 mStartAngle = Vector2.zero;
    float mDistance = 12.0f;

    public float mMinDistance = 5.0f;
    public float mMaxDistance = 25.0f;
    
    CellHero pHero = null;

    // Panel
    LoopVerticalScrollRect mBetterGrid = null;
    GameObject mListParent = null;
    GameObject mStyleItem = null;

    List<tData> mDataList = new List<tData>();
    string[] mTitleList = { "Spell", "Hit", "Travel", "Aura" };
    int mCurShowTab = 0;
    int mSelectIndex = -1;

    // Use this for initialization
    void Start ()
    {
        Init();
    }

    GameObject GetChild(Transform pTrans, string sName)
    {
        for (int i = 0; i < pTrans.childCount; ++i)
        {
            if (pTrans.GetChild(i).name == sName)
            {
                return pTrans.GetChild(i).gameObject;
            }
            GetChild(pTrans.GetChild(i), sName);
        }
        return null;
    }

    void Init()
    {
        GameObject pResList = GameObject.Find("ResList");
        mStyleItem = GameObject.Find("Item");
        mBetterGrid = pResList.GetComponent<LoopVerticalScrollRect>();

        GameApplication.Instance.OnDataCompleted = ()=>
        {
            int nMaxCount = ViSealedDB<VisualSpellStruct>.Array.Count;
            nMaxCount = Mathf.Max(ViSealedDB<ViVisualHitEffectStruct>.Array.Count, nMaxCount);
            nMaxCount = Mathf.Max(ViSealedDB<ViTravelExpressStruct>.Array.Count, nMaxCount);
            nMaxCount = Mathf.Max(ViSealedDB<ViVisualAuraStruct>.Array.Count, nMaxCount);

            int nNum = FormatData();

            GameObject contentobj = GetChild(pResList.transform, "Content");
            int nChildNum = contentobj.transform.childCount;
            for (int i = 0; i < nChildNum; i++)
            {
                ExUIButton btn = contentobj.transform.GetChild(i).GetComponent<ExUIButton>();
                btn.onClickEx = OnEventSelectItem;
            }

            mSelectIndex = -1;
            mBetterGrid.Init(TTTT, nNum);
            mBetterGrid.RefillCells();

            CreateShowGirl();
        };

        FingerManager.OnDrag += OnDrag;
        FingerManager.OnPinch += OnPinch;
        FingerManager.OnFingerDown += OnFingerDown;
        FingerManager.OnFingerUp += OnFingerUp;
    }

    int FormatData()
    {
        mDataList.Clear();
        mDataList.Add(new tData(0, 0));

        int nNum = 0;
        if (mCurShowTab == 0)
        {
            nNum = ViSealedDB<VisualSpellStruct>.Array.Count;
        }
        else if (mCurShowTab == 1)
        {
            nNum = ViSealedDB<ViVisualHitEffectStruct>.Array.Count;
            mDataList.Add(new tData(0, 1));
        }
        else if (mCurShowTab == 2)
        {
            nNum = ViSealedDB<ViTravelExpressStruct>.Array.Count;
            mDataList.Add(new tData(0, 1));
            mDataList.Add(new tData(0, 2));
        }
        else if (mCurShowTab == 3)
        {
            nNum = ViSealedDB<ViVisualAuraStruct>.Array.Count;
            mDataList.Add(new tData(0, 1));
            mDataList.Add(new tData(0, 2));
            mDataList.Add(new tData(0, 3));
        }

        for (int i = 0; i < nNum; ++i)
        {
            switch (mCurShowTab)
            {
                case 0:
                    mDataList.Add(new tData(1, ViSealedDB<VisualSpellStruct>.Array[i].ID));
                    break;
                case 1:
                    mDataList.Add(new tData(1, ViSealedDB<ViVisualHitEffectStruct>.Array[i].ID));
                    break;
                case 2:
                    mDataList.Add(new tData(1, ViSealedDB<ViTravelExpressStruct>.Array[i].ID));
                    break;
                case 3:
                    mDataList.Add(new tData(1, ViSealedDB<ViVisualAuraStruct>.Array[i].ID));
                    break;
            }
        }

        if (mCurShowTab == 0 || mCurShowTab == -1)
        {
            mDataList.Add(new tData(0, 1));
            mDataList.Add(new tData(0, 2));
            mDataList.Add(new tData(0, 3));
        }
        else if (mCurShowTab == 1)
        {
            mDataList.Add(new tData(0, 2));
            mDataList.Add(new tData(0, 3));
        }
        else if (mCurShowTab == 2)
        {
            mDataList.Add(new tData(0, 3));
        }

        return mDataList.Count;
    }

    void OnEventSelectItem(int vID, object obj)
    {
        ExUIButton pBtn = obj as ExUIButton;
        int vIndex = mBetterGrid.GetIndexByTransform(pBtn.gameObject.transform);
        tData pData = mDataList[vIndex];
        if (pData.mType == 0)
        {
            if (pData.mID != mCurShowTab)
            {
                mCurShowTab = pData.mID;

                mBetterGrid.ChangeTotalCount(FormatData());
                mBetterGrid.RefillCells();
            }
            else
            {
                mCurShowTab = -1;
                mBetterGrid.ChangeTotalCount(FormatData());
                mBetterGrid.RefillCells();
            }

            mSelectIndex = -1;
        }
        else
        {
            if (mSelectIndex != -1)
            {
                SetObjTextColor(mBetterGrid.GetTransformByIndex(mSelectIndex), "Text", Color.white);
            }

            mSelectIndex = vIndex;
            SetObjTextColor(mBetterGrid.GetTransformByIndex(mSelectIndex), "Text", Color.red);

            Play(pData.mID);
        }
    }

    void TTTT(string path, int vIndex)
    {
        tData pData = mDataList[vIndex];
        Transform obj = mBetterGrid.GetTransformByIndex(vIndex);
        ExText pText = GetChild(obj, "Text").GetComponent<ExText>();
        if (pData.mType == 0)
        {
            pText.text = mTitleList[pData.mID];
        }
        else
        {
            pText.text = pData.mID.ToString();
        }

        pText.color = (vIndex == mSelectIndex) ? Color.red : Color.white;
        obj.GetComponent<ExUISprite>().SpriteName = (pData.mType == 0) ? "pic_setup_bar2" : "choosesever_bg";
    }

    void SetObjTextColor(Transform pTrans, string sName, Color col)
    {
        if (pTrans == null)
        {
            return;
        }
        GameObject pObj = GetChild(pTrans, "Text");
        if (pObj != null)
        {
            ExText pText = pObj.GetComponent<ExText>();
            if (pText != null)
            {
                pText.color = col;
            }
        }
    }

    void InitCamera()
    {
        mMainCamera = GlobalGameObject.Instance.SceneCamera;
        mCameraTrans = mMainCamera.transform;

        mSceneObj = GameObject.Find("EasySecne");

        mCameraTrans.position = new Vector3(0.0f, 8.0f, -10.0f);
        mCameraTrans.LookAt(mSceneObj.transform);
    }

    void CreateShowGirl()
    {
        pHero = new CellHero();
        pHero.Enable(0, 0, true);
        pHero.SetProperty(new CellHeroReceiveProperty());
        pHero.UpdateInfoForEditor(1, 0);
        pHero.VisualBody.Root.name = "Entity_Hero";
    }

    void Play(int vID)
    {
        uint nDataID = (uint)vID;
        if (mCurShowTab == 0)
        {
            pHero.OnSpellCast(nDataID, null);
        }
        else if (mCurShowTab == 1)
        {
            pHero.OnHitVisual(nDataID);
        }
        else if (mCurShowTab == 2)
        {
            ViVector3 vTargetPos = new ViVector3(0.0f, 10.0f, 15.0f);
            float fDistance = ViVector3.Distance(vTargetPos, pHero.GetPosProvider(0).Value);
            float fTravelDuration = fDistance / (1500 * 0.01f);

            pHero.TravelForEditor(ViSealedDB<ViTravelExpressStruct>.Data(nDataID), vTargetPos, fTravelDuration);

        }
        else if (mCurShowTab == 3)
        {
            ViVisualAuraStruct pEditData = ViSealedDB<ViVisualAuraStruct>.Data(nDataID);
            if (pEditData != null)
            {
                pHero.ShowAuraForEditor(pEditData, 1500 * 0.01f);
            }
        }
    }

    void LateUpdate()
    {
        if (mMainCamera == null)
        {
            InitCamera();
        }
    }

    void OnDrag(DragGesture gesture)
    {
        if (!mFingerDown || mCameraTrans == null)
        {
            return;
        }

        Vector2 vAngle = mStartAngle;
        vAngle.x -= (gesture.DeltaMove.y * 0.3f);
        vAngle.y += (gesture.DeltaMove.x * 0.3f);

        mCameraTrans.rotation = Quaternion.Euler(Mathf.Clamp(vAngle.x, 10.0f, 70.0f), vAngle.y, 0.0f);
        mCameraTrans.position = -mCameraTrans.forward * mDistance;
        mCameraTrans.LookAt(Vector3.zero);

        mStartAngle = vAngle;
    }

    void OnPinch(PinchGesture gesture)
    {
        mFingerDown = false;
        mDistance = Mathf.Clamp(mDistance -= (gesture.Delta * 0.5f), mMinDistance, mMaxDistance);
        mCameraTrans.position = Vector3.zero + -mCameraTrans.forward * mDistance;
    }

    void OnFingerDown(FingerDownEvent e)
    {
        mFingerDown = true;
        mStartAngle = mCameraTrans.transform.rotation.eulerAngles;
    }

    void OnFingerUp(FingerUpEvent e)
    {
        mFingerDown = false;
    }
}
