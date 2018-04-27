using UnityEngine;
using System.Collections;

public class AvatarProperty : MonoBehaviour
{
	public GameObject BodyLow;
	public Transform MoveMix;
	public Transform[] AttachPos = new Transform[12];
	public Transform[] LinkPos;
	public Transform RealSkin;
	public Transform RealSkinSkeleton;
	public Transform[] SkinPhysicxJiont;
	public Transform[] SkinPhysicxCollider;
	public Transform Boom;
	public Transform BoomSkin;
	public Transform BoomSkinSkeleton;
	public Transform[] BoomSkinPhysicxJiont;
	public Transform[] BoomSkinPhysicxCollider;
	public Transform IKSkin;
	public Transform IKSkinSkeleton;
	public Transform[] IKSkinPhysicxJiont;
	public Transform[] IKSkinPhysicxCollider;

	public void Awake()
	{
		if (AttachPos == null)
		{
			AttachPos = new Transform[0];
		}
		if (SkinPhysicxJiont == null)
		{
			SkinPhysicxJiont = new Transform[0];
		}
		if (SkinPhysicxCollider == null)
		{
			SkinPhysicxCollider = new Transform[0];
		}
		if (BoomSkinPhysicxJiont == null)
		{
			BoomSkinPhysicxJiont = new Transform[0];
		}
		if (BoomSkinPhysicxCollider == null)
		{
			BoomSkinPhysicxCollider = new Transform[0];
		}
		if (IKSkinPhysicxJiont == null)
		{
			IKSkinPhysicxJiont = new Transform[0];
		}
		if (IKSkinPhysicxCollider == null)
		{
			IKSkinPhysicxCollider = new Transform[0];
		}
		//
		for (int iter = 0; iter < AttachPos.Length; ++iter)
		{
			if (AttachPos[iter] == null)
			{
				AttachPos[iter] = transform;
			}
		}
	}

	public Transform GetAttachPos(int pos)
	{
		if (AttachPos == null)
		{
			return transform;
		}
		if (pos >= AttachPos.Length)
		{
			return transform;
		}
		//
		return AttachPos[pos];
	}

	public Transform GetLinkPos(int pos)
	{
		if (LinkPos == null)
		{
			return transform;
		}
		if (pos >= LinkPos.Length)
		{
			return transform;
		}
		//
		return LinkPos[pos];
	}

}
