using UnityEngine;
using System.Collections;

public class ObjectMove : MonoBehaviour {

	//public int Distance = 5;
	public int Speed = 5;
	public float TimeLength = 3;
	public float AnimationScale = 1;
	public Direction_Enum Direction = Direction_Enum.NULL;
	private Vector3 startPoint;
	private Quaternion startRotation;
	private float surplusTime;
	public enum Direction_Enum
	{
		NULL,
		X,
		Y,
		Z,
		ROTATE	,
	}


	// Use this for initialization
	void Start () 
	{
		startPoint = transform.position;
		startRotation = transform.rotation;
		
		RestMove();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Direction != Direction_Enum.NULL)
		{
			MoveUpdata();
		}
	}

	void MoveUpdata()
	{
		surplusTime -= Time.deltaTime;
		if (surplusTime > 0)
		{
			float translation = Time.deltaTime * Speed;
			move(translation);
		}
		else
		{
			RestMove();
		}
	}

	void OnEnable()
	{
		ChangeAnimationScale();
	}


	void ChangeAnimationScale()
	{
		if (GetComponent<Animation>() == null)
		{
			return;
		}

		foreach (AnimationState state in GetComponent<Animation>())
		{
			state.speed = AnimationScale;
		}
	}

	void move(float translation)
	{
		switch (Direction)
		{
			case Direction_Enum.X:
				transform.Translate(translation, 0, 0);
				break;
			case Direction_Enum.Y:
				transform.Translate(0, translation, 0);
				break;
			case Direction_Enum.Z:
				transform.Translate( 0, 0, translation);
				break;
			case Direction_Enum.ROTATE:
				transform.Rotate(Vector3.up * translation);
				break;
			default:
				break;
		}
	}

	void RestMove()
	{
		surplusTime = TimeLength;
		transform.position = startPoint;
		transform.rotation = startRotation;
	
		//transform.transform = startPoint;
	}
}
