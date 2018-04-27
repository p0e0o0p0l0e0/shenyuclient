using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public enum tCameraState
{
    eEditor,
    eGame,
}

public class EditorGameSupport : MonoBehaviour
{
    public static EditorGameSupport Instance = null;

    private Camera mMainCamera = null;
    private Transform mCameraTrans;
    private Vector2 mStartAngle;

    private float mCameraMoveSpeed = 50.0f;
    private float mCameraScaleSpeed = 2000.0f;
    
    tCameraState mCamState = tCameraState.eEditor;
    bool mFingerDown = false;
    float mDistance = 12.0f;
    float mMinDistance = 5.0f;
    float mMaxDistance = 25.0f;
    Vector2 mAngle = Vector2.zero;
    Vector3 mLastDir = Vector3.zero;
    Transform mHeroTrans = null;
    CellHero mHero = null;
    // Use this for initialization
    void Awake()
    {
        Instance = this;
    }

    public void Destroy()
    {

    }

    // Update is called once per frame
    void LateUpdate ()
    {
        switch(mCamState)
        {
            case tCameraState.eEditor:
                UpdateCamera_Editor();
                break;
            case tCameraState.eGame:
                UpdateCamera_Game();
                break;
        }
    }

    public void SwitchState(tCameraState vState)
    {
        if (vState == mCamState)
        {
            return;
        }

        mCamState = vState;

        RegisterFinger();
    }

    public void SetGameHero(CellHero pHero)
    {
        mHero = pHero;
        mHeroTrans = pHero.VisualBody.Root.transform;
        InitCameraPos();
    }

    void InitCameraPos()
    {
        if (mCameraTrans != null && mHero != null)
        {
            Vector3 vPos = new Vector3(0.0f, 8.0f, -10.0f);
            mCameraTrans.position = mHeroTrans.position + vPos;
            mCameraTrans.LookAt(mHeroTrans.position + Vector3.up * 1.5f);

            mAngle = mCameraTrans.rotation.eulerAngles;
        }
    }

    void RegisterFinger()
    {
        if (mCamState == tCameraState.eGame)
        {
            FingerManager.OnDrag += OnDrag;
            FingerManager.OnPinch += OnPinch;
            FingerManager.OnFingerDown += OnFingerDown;
            FingerManager.OnFingerUp += OnFingerUp;
        }
        else
        {
            FingerManager.OnDrag -= OnDrag;
            FingerManager.OnPinch -= OnPinch;
            FingerManager.OnFingerDown -= OnFingerDown;
            FingerManager.OnFingerUp -= OnFingerUp;
        }
    }

    void Move(Vector3 vDir)
    {
        if (mHero == null)
        {
            return;
        }
        
        vDir = PickAssisstant.OffsetCamera2World(mHeroTrans.position, vDir).normalized;
        mHero.SetYaw(ViGeographicObject.GetDirection(vDir.x, vDir.z));

        ViVector3 vPos = mHero.Position + new ViVector3(vDir.x, vDir.z, 0.0f) * 6.0f * Time.deltaTime;
        GroundHeight.GetGroundHeight(ref vPos);
        mHero.OnMoveTo(vPos);
    }

    void UpdateCamera_Game()
    {
        if (mCameraTrans == null)
        {
            mMainCamera = GameObject.Find("GameMainCamera").GetComponent<Camera>();
            mCameraTrans = mMainCamera.transform;

            InitCameraPos();
            return;
        }
        if (mHeroTrans == null)
        {
            return;
        }

        CameraController.Instance.SpringShaker.Update(GameTimeScale.LogicDeltaTime);
        CameraController.Instance.RandomShaker.Update(GameTimeScale.LogicDeltaTime);

        Vector3 vDir = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            vDir += new Vector3(0.0f, 1.0f, 0.0f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            vDir += new Vector3(0.0f, -1.0f, 0.0f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            vDir += new Vector3(-1.0f, 0.0f, 0.0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            vDir += new Vector3(1.0f, 0.0f, 0.0f);
        }
        
        if (vDir != Vector3.zero)
        {
            Move(vDir);
        }
        mLastDir = vDir;

        float x = Mathf.Clamp(mAngle.x, 10.0f, 70.0f);

        Vector3 vShake = CameraController.Instance.SpringShaker.Offset.Convert() + CameraController.Instance.RandomShaker.Offset.Convert();

        Vector3 vPos = mHeroTrans.position + Vector3.up * 1.5f;
        mCameraTrans.rotation = Quaternion.Euler(-x, mAngle.y, 0.0f);
        mCameraTrans.position = vPos + mCameraTrans.forward * mDistance + vShake;
        mCameraTrans.LookAt(vPos);
    }

    void UpdateCamera_Editor()
    {
        if (mCameraTrans == null)
        {
            mMainCamera = GameObject.Find("GameMainCamera").GetComponent<Camera>();
            mCameraTrans = mMainCamera.transform;
            return;
        }

        //移动摄像机
        Vector3 right = mCameraTrans.right;
        Vector3 forward = mCameraTrans.forward;
        forward.Normalize();
        right.Normalize();

        if (Input.GetKey(KeyCode.W))
        {
            mCameraTrans.position = mCameraTrans.position + forward * mCameraMoveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            mCameraTrans.position = mCameraTrans.position - forward * mCameraMoveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            mCameraTrans.position = mCameraTrans.position + right * mCameraMoveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            mCameraTrans.position = mCameraTrans.position - right * mCameraMoveSpeed * Time.deltaTime;
        }
        //摄像机前进后退
        mCameraTrans.position += Input.GetAxis("Mouse ScrollWheel") * mCameraTrans.forward * mCameraScaleSpeed * Time.deltaTime;

        //摄像机转动
        if (Input.GetMouseButtonDown(1))
        {
            mStartAngle = mCameraTrans.transform.rotation.eulerAngles;
        }
        if (Input.GetMouseButton(1))
        {
            Vector2 vPos = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
            vPos.Normalize();

            Vector2 vAngle = Vector2.zero;
            vAngle.y = mStartAngle.y + vPos.x * 1.5f;
            vAngle.x = mStartAngle.x - vPos.y * 1.5f;
            mCameraTrans.rotation = Quaternion.Euler(vAngle.x, vAngle.y, 0.0f);

            mStartAngle = vAngle;
        }
    }

    void OnDrag(DragGesture gesture)
    {
        if (!mFingerDown || mCameraTrans == null || mHeroTrans == null)
        {
            return;
        }

        mAngle = mStartAngle;
        mAngle.x -= (gesture.DeltaMove.y * 0.3f);
        mAngle.y += (gesture.DeltaMove.x * 0.3f);

        mStartAngle = mAngle;
    }

    void OnPinch(PinchGesture gesture)
    {
        if (mCameraTrans == null || mHeroTrans == null)
        {
            return;
        }
        mFingerDown = false;
        mDistance = Mathf.Clamp(mDistance -= (gesture.Delta * 0.5f), mMinDistance, mMaxDistance);

        Vector3 vPos = mHeroTrans.position + Vector3.up * 1.5f;
        mCameraTrans.position = vPos + -mCameraTrans.forward * mDistance;
    }

    void OnFingerDown(FingerDownEvent e)
    {
        mFingerDown = true;
        mStartAngle = mCameraTrans.transform.rotation.eulerAngles;
        mStartAngle.y -= 180.0f;
    }

    void OnFingerUp(FingerUpEvent e)
    {
        mFingerDown = false;
    }
}
