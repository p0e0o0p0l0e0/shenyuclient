using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class CharactorRigid
{
	public static ViConstValue<float> VALUE_IKColliderSize = new ViConstValue<float>("IKColliderSize", 0.2f);
	//
	public static void Exec(Transform skeleton, Transform[] jiontArray, Transform[] colliderArray, List<Rigidbody> rigidbodyList, List<Collider> collderList, List<CharacterJoint> jiontList, float angularDrag)
	{
		if (skeleton == null)
		{
			return;
		}
		//
		{
			BoxCollider colider = UnityAssisstant.CreateComponent<BoxCollider>(skeleton.gameObject);
			Vector3 lossyScale = skeleton.lossyScale;
			colider.size = VALUE_IKColliderSize * new Vector3(1.0f / lossyScale.x, 1.0f / lossyScale.y, 1.0f / lossyScale.z);
			collderList.Add(colider);
		}
		//
		Rigidbody RootRigid = UnityAssisstant.CreateComponent<Rigidbody>(skeleton.gameObject);
		RootRigid.angularDrag = angularDrag;
		rigidbodyList.Add(RootRigid);
		//
		for (int iter = 0; iter < jiontArray.Length; ++iter)
		{
			Transform iterTran = jiontArray[iter];
			CreateJoint(iterTran, RootRigid, jiontList, rigidbodyList);
		}
		//
		for (int iter = 0; iter < colliderArray.Length; ++iter)
		{
			Transform iterTran = colliderArray[iter];
			BoxCollider iterCollider = UnityAssisstant.CreateComponent<BoxCollider>(iterTran.gameObject);
			Vector3 lossyScale = iterTran.lossyScale;
			iterCollider.size = VALUE_IKColliderSize * new Vector3(1.0f / lossyScale.x, 1.0f / lossyScale.y, 1.0f / lossyScale.z);
			iterCollider.enabled = true;
			iterCollider.gameObject.layer = (int)UnityLayer.ENTITY_EXPLORE;
			collderList.Add(iterCollider);
		}
	}

	static void CreateJoint(Transform transfrom, Rigidbody parentRigdibody, List<CharacterJoint> jiontList, List<Rigidbody> rigidbodyList)
	{
		CharacterJoint characterJoint = UnityAssisstant.CreateComponent<CharacterJoint>(transfrom.gameObject);
		characterJoint.connectedBody = parentRigdibody;
		jiontList.Add(characterJoint);
		Rigidbody rigibody = transfrom.gameObject.GetComponent<Rigidbody>();
		transfrom.gameObject.layer = (int)UnityLayer.ENTITY_EXPLORE;
		if (rigibody != null)
		{
			rigidbodyList.Add(rigibody);
		}
	}
}
