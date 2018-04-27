//
//  Custom Scroll View Spring Effect
//
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(UIPanel))]
[AddComponentMenu("NGUI/Interaction/Scroll View Ex (Spring)")]
public class UIScrollViewEx_Spring : UIScrollView
{
	/// <summary>
	/// Absolute Value 
	/// </summary>
	public float InertiaMaxSpeed = 3f;
	public float InertiaAccerlate = 1.5f;
	public float InertiaScale = 1f;

	public override void DisableSpring()
	{
		SpringPanelEx sp = GetComponent<SpringPanelEx>();
		if (sp != null) sp.enabled = false;
	}

	/// <summary>
	/// Restrict the scroll view's contents to be within the scroll view's bounds.
	/// </summary>
	public override bool RestrictWithinBounds(bool instant, bool horizontal, bool vertical)
	{
		if (mPanel == null) return false;
		//
		Bounds b = bounds;
		Vector3 constraint = mPanel.CalculateConstrainOffset(b.min, b.max);

		if (!horizontal) constraint.x = 0f;
		if (!vertical) constraint.y = 0f;

		if (constraint.sqrMagnitude > 0.1f)
		{
			if (!instant)
			{
				// Spring back into place
				Vector3 pos = mTrans.localPosition + constraint;
				pos.x = Mathf.Round(pos.x);
				pos.y = Mathf.Round(pos.y);
				SpringPanelEx.Begin(mPanel.gameObject, pos);
			}
			else
			{
				// Jump back into place
				MoveRelative(constraint);

				// Clear the momentum in the constrained direction
				if (Mathf.Abs(constraint.x) > 0.01f) mMomentum.x = 0;
				if (Mathf.Abs(constraint.y) > 0.01f) mMomentum.y = 0;
				if (Mathf.Abs(constraint.z) > 0.01f) mMomentum.z = 0;
				mScroll = 0f;
			}
			return true;
		}
		return false;
	}

	protected override void LateUpdate()
	{
		if (!Application.isPlaying) return;
		float deltaTime = RealTime.deltaTime;

		// Fade the scroll bars if needed
		if (showScrollBars != ShowCondition.Always && (verticalScrollBar || horizontalScrollBar))
		{
			bool vertical = false;
			bool horizontal = false;

			if (showScrollBars != ShowCondition.WhenDragging || mDragID != -10 || mMomentum.magnitude > 0.01f)
			{
				vertical = shouldMoveVertically;
				horizontal = shouldMoveHorizontally;
			}

			if (verticalScrollBar)
			{
				float alpha = verticalScrollBar.alpha;
				alpha += vertical ? deltaTime * 6f : -deltaTime * 3f;
				alpha = Mathf.Clamp01(alpha);
				if (verticalScrollBar.alpha != alpha) verticalScrollBar.alpha = alpha;
			}

			if (horizontalScrollBar)
			{
				float alpha = horizontalScrollBar.alpha;
				alpha += horizontal ? deltaTime * 6f : -deltaTime * 3f;
				alpha = Mathf.Clamp01(alpha);
				if (horizontalScrollBar.alpha != alpha) horizontalScrollBar.alpha = alpha;
			}
		}
		//
		//
		if (_scrollingLearp)
		{
			_Move(ref mScroll, deltaTime);
			if (mMomentum.magnitude <= 0.01f && Mathf.Abs(mScroll) <= 0.01f)
			{
				RestrictWithinBounds(false);
				mMomentum = Vector3.zero;
				mScroll = 0f;
				_scrollingLearp = false;
				if (onStoppedMoving != null)
				{
					onStoppedMoving();
				}
			}
			else
			{
				if (onMomentumMove != null)
				{
					onMomentumMove();
				}
			}
		}
		//
		if (_inertialLearp)
		{
			_inertiaVelocity.UpdateAccelerate(deltaTime * InertiaScale, InertiaAccerlate);
			Vector3 move = Vector3.zero;
			if (movement == Movement.Horizontal)
			{
				move.x = _inertiaVelocity.Value * deltaTime;
			}
			else if (movement == Movement.Vertical)
			{
				move.y = _inertiaVelocity.Value * deltaTime;
			}
			//
			MoveAbsolute(move);
			//
			if (onMomentumMove != null)
			{
				onMomentumMove();
			}
			//
			if (_inertiaVelocity.Value == 0f || RestrictWithinBounds(false))
			{
				_inertialLearp = false;
			}
		}

	}

	public override void Scroll(float delta)
	{
		if (shouldMoveVertically || shouldMoveHorizontally)
		{
			base.Scroll(delta);
			_scrollingLearp = true;
		}
	}

	public override void Press(bool pressed)
	{
		base.Press(pressed);
		//
		if (pressed)
		{
			_inertialLearp = false;
			_inertiaVelocity.SetValue(0);
		}
		else if ((movement == Movement.Horizontal && shouldMoveHorizontally)
			|| (movement == Movement.Vertical && shouldMoveVertically))
		{
			_inertialLearp = true;
		}
	}

	public override void Drag()
	{
		base.Drag();
		//
		Vector2 delta = UICamera.currentTouch.delta;
		float deltaTime = UICamera.currentTouch.deltaTime;
		if (deltaTime > 0)
		{
			if (movement == Movement.Horizontal)
			{
				_inertiaVelocity.UpdateVelocity(_dragOffest.x / deltaTime, InertiaMaxSpeed);
			}
			else if (movement == Movement.Vertical)
			{
				_inertiaVelocity.UpdateVelocity(_dragOffest.y / deltaTime, InertiaMaxSpeed);
			}
		}
	}

	void _Move(ref float scroll, float deltaTime)
	{
		if (movement == Movement.Horizontal)
		{
			mMomentum -= mTrans.TransformDirection(new Vector3(scroll * 0.05f, 0f, 0f));
		}
		else if (movement == Movement.Vertical)
		{
			mMomentum -= mTrans.TransformDirection(new Vector3(0f, scroll * 0.05f, 0f));
		}
		else if (movement == Movement.Unrestricted)
		{
			mMomentum -= mTrans.TransformDirection(new Vector3(scroll * 0.05f, scroll * 0.05f, 0f));
		}
		else
		{
			mMomentum -= mTrans.TransformDirection(new Vector3(
				scroll * customMovement.x * 0.05f,
				scroll * customMovement.y * 0.05f, 0f));
		}
		scroll = NGUIMath.Lerp(scroll, 0f, deltaTime * 18f);
		// Move the scroll view
		Vector3 offset = NGUIMath.SpringDampen(ref mMomentum, dampenStrength, deltaTime);
		MoveAbsolute(offset);
	}

	bool _scrollingLearp = false;
	bool _inertialLearp = false;
	UIInertiaVelocity _inertiaVelocity = new UIInertiaVelocity();
}
