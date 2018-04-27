//----------------------------------------------
//  Custom Script
//----------------------------------------------
using UnityEngine;

[RequireComponent(typeof(UIPanel))]
[AddComponentMenu("NGUI/Internal/SpringPanelEx")]
public class SpringPanelEx : MonoBehaviour
{
	static public SpringPanelEx current;

	/// <summary>
	/// Target position to spring the panel to.
	/// </summary>

	public Vector3 Target = Vector3.zero;

	public float SpringRate = 10f;
	public float SpeedFriction = 3f;
	public float TimeScale = 7f;

	public delegate void OnFinished();

	/// <summary>
	/// Delegate function to call when the operation finishes.
	/// </summary>

	public OnFinished onFinished;

	UIPanel mPanel;
	Transform mTrans;
	UIScrollView mDrag;

	/// <summary>
	/// Cache the transform.
	/// </summary>

	void Start()
	{
		mPanel = GetComponent<UIPanel>();
		mDrag = GetComponent<UIScrollView>();
		mTrans = transform;
	}

	/// <summary>
	/// Advance toward the target position.
	/// </summary>

	void Update()
	{
		AdvanceTowardsPosition();
	}

	/// <summary>
	/// Advance toward the target position.
	/// </summary>

	protected virtual void AdvanceTowardsPosition()
	{
		float delta = RealTime.deltaTime;
		//
		Vector3 before = mTrans.localPosition;
		bool update = _tweenerSpring.Update(Target, delta);
		Vector3 after = _tweenerSpring.Value;
		//Debug.Log("after:" + after);
		mTrans.localPosition = after;
		//
		Vector3 offset = after - before;
		Vector2 cr = mPanel.clipOffset;
		cr.x -= offset.x;
		cr.y -= offset.y;
		mPanel.clipOffset = cr;

		if (mDrag != null) mDrag.UpdateScrollbars(false);

		if (!update)
		{
			enabled = false;
			if (onFinished != null)
			{
				current = this;
				onFinished();
				current = null;
			}
		}
	}

	public void Init()
	{
		if (mTrans == null)
		{
			mTrans = transform;
		}
		Vector3 from = mTrans.localPosition;
		_tweenerSpring.StopAt(from);
		_tweenerSpring.Init(SpringRate, SpeedFriction, TimeScale);
	}

	/// <summary>
	/// Start the tweening process.
	/// </summary>

	static public SpringPanelEx Begin(GameObject go, Vector3 pos)
	{
		SpringPanelEx sp = go.GetComponent<SpringPanelEx>();
		if (sp == null)
		{
			sp = go.AddComponent<SpringPanelEx>();
			sp.SpringRate = 21f;
			sp.SpeedFriction = 4f;
			sp.TimeScale = 7.5f;
			sp.onFinished = null;
		}
		sp.Target = pos;
		sp.Init();
		sp.enabled = true;
		return sp;
	}

	Vector3Interpolation_Spring _tweenerSpring = new Vector3Interpolation_Spring();
}
