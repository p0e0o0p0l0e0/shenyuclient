using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class CharactorExplosion
{
	public static void Start(Transform root, AvatarProperty property, List<Rigidbody> rigidbodyList, List<Collider> collderList, List<CharacterJoint> jiontList, ViVector3 attackPos, float forceH, float forceV, float weight, float exploreProbability)
	{
		HideBody(property.gameObject);
		//
		Transform boom = property.Boom;
		if (boom != null)
		{
			StartMesh(boom, rigidbodyList, collderList);
		}
		else
		{
			boom = new GameObject("Boom").transform;
			UnityAssisstant.JionTransform(root, boom);
		}
		//
		Transform skin;
		Transform skeleton;
		Transform[] jiontArray;
		Transform[] colliderArray;
		if (ViRandom.Value(exploreProbability))
		{
			skin = property.BoomSkin;
			skeleton = property.BoomSkinSkeleton;
			jiontArray = property.BoomSkinPhysicxJiont;
			colliderArray = property.BoomSkinPhysicxCollider;
		}
		else
		{
			exploreProbability = 0.0f;
			skin = property.IKSkin;
			skeleton = property.IKSkinSkeleton;
			jiontArray = property.IKSkinPhysicxJiont;
			colliderArray = property.IKSkinPhysicxCollider;
		}
		//
		if (skin != null)
		{
			CopyTransform(property.SkinPhysicxJiont, jiontArray);
			CopyTransform(property.SkinPhysicxCollider, colliderArray);
			StartSkin(skin, boom, rigidbodyList, collderList, exploreProbability);
			//
			CharactorRigid.Exec(skeleton, jiontArray, colliderArray, rigidbodyList, collderList, jiontList, 1.0f);
			Animation boomSkinAnim = skin.GetComponent<Animation>();
			if (boomSkinAnim != null)
			{
				boomSkinAnim.Stop();
				boomSkinAnim.enabled = false;
			}
		}
		//
		ViVector3 force = property.transform.position.Convert() - attackPos;
		force.z = 0;
		force.Normalize();
		force.x *= forceH;
		force.y *= forceH;
		force.z = forceV;
		AddForce(rigidbodyList, attackPos, force, weight);
	}

	public static void StartMesh(Transform boom, List<Rigidbody> rigidbodyList, List<Collider> collderList)
	{
		boom.gameObject.SetActive(true);
		for (int iter = 0; iter < boom.childCount; ++iter)
		{
			Transform iterTransform = boom.GetChild(iter);
			MeshRenderer meshrenderer = iterTransform.gameObject.GetComponent<MeshRenderer>();
			if (meshrenderer == null)
			{
				continue;
			}
			//
			UpdateMesh(meshrenderer);
			iterTransform.gameObject.layer = (int)UnityLayer.ENTITY_EXPLORE;
			collderList.Add(AddCollider(iterTransform.gameObject));
			rigidbodyList.Add(AddRigidbody(iterTransform.gameObject));
		}
	}

	public static void StartSkin(Transform boomSkin, Transform boom, List<Rigidbody> rigidbodyList, List<Collider> collderList, float probability)
	{
		boomSkin.gameObject.SetActive(true);
		UnityComponentList<SkinnedMeshRenderer>.Begin(boomSkin.gameObject);
		for (int iter = 0; iter < UnityComponentList<SkinnedMeshRenderer>.List.Count; ++iter)
		{
			SkinnedMeshRenderer iterSkinrenderer = UnityComponentList<SkinnedMeshRenderer>.List[iter];
			if (!ViRandom.Value(probability))
			{
				Collider iterCollider = iterSkinrenderer.GetComponent<Collider>();
				if (iterCollider != null)
				{
					iterCollider.enabled = false;
				}
				continue;
			}
			//
			iterSkinrenderer.gameObject.SetActive(false);
			//
			Mesh mesh = new Mesh();
			iterSkinrenderer.BakeMesh(mesh);
			//
			GameObject iterChildrenobj = UnityAssisstant.CreatMeshGameObject(mesh, iterSkinrenderer, null);
			iterChildrenobj.name = iterSkinrenderer.gameObject.name;
			iterChildrenobj.layer = (int)UnityLayer.ENTITY_EXPLORE;
			//
			iterChildrenobj.transform.position = iterSkinrenderer.transform.position;
			iterChildrenobj.transform.rotation = iterSkinrenderer.transform.rotation;
			iterChildrenobj.transform.parent = boom.transform;
			//
			collderList.Add(AddCollider(iterChildrenobj));
			rigidbodyList.Add(AddRigidbody(iterChildrenobj));
		}
		UnityComponentList<SkinnedMeshRenderer>.End();
	}

	static void HideBody(GameObject gameObj)
	{
		UnityComponentList<SkinnedMeshRenderer>.Begin(gameObj);
		for (int iter = 0; iter < UnityComponentList<SkinnedMeshRenderer>.List.Count; ++iter)
		{
			SkinnedMeshRenderer iterRender = UnityComponentList<SkinnedMeshRenderer>.List[iter];
			iterRender.gameObject.SetActive(false);
		}
		UnityComponentList<SkinnedMeshRenderer>.End();
		//
		UnityComponentList<MeshFilter>.Begin(gameObj);
		for (int iter = 0; iter < UnityComponentList<MeshFilter>.List.Count; ++iter)
		{
			MeshFilter iterRender = UnityComponentList<MeshFilter>.List[iter];
			iterRender.gameObject.SetActive(false);
		}
		UnityComponentList<MeshFilter>.End();
	}

	public static GameObject UpdateMesh(MeshRenderer meshrenderer)
	{
		meshrenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
		meshrenderer.receiveShadows = false;
		return meshrenderer.gameObject;
	}

	public static void End(GameObject gameobj, List<Rigidbody> rigidbodyList, List<Collider> collderList, List<CharacterJoint> jiontList)
	{
		for (int iter = 0; iter < jiontList.Count; ++iter)
		{
			CharacterJoint iterJoint = jiontList[iter];
			UnityEngine.Object.Destroy(iterJoint);
		}
		jiontList.Clear();
		//
		for (int iter = 0; iter < rigidbodyList.Count; ++iter)
		{
			Rigidbody iterRigidbody = rigidbodyList[iter];
			UnityEngine.Object.Destroy(iterRigidbody);
		}
		rigidbodyList.Clear();
		//
		for (int iter = 0; iter < collderList.Count; ++iter)
		{
			Collider iterColider = collderList[iter];
			UnityEngine.Object.Destroy(iterColider);
		}
		collderList.Clear();
	}

	public static Collider AddCollider(GameObject gameobj)
	{
		BoxCollider collider = UnityAssisstant.CreateComponent<BoxCollider>(gameobj);
		collider.material.dynamicFriction = 0.5f;
		collider.material.bounciness = 0.5f;
		collider.material.staticFriction = 0.5f;
		collider.material.frictionCombine = PhysicMaterialCombine.Minimum;
		return collider;
	}

	public static Rigidbody AddRigidbody(GameObject gameobj)
	{
		Rigidbody rigidbody = UnityAssisstant.CreateComponent<Rigidbody>(gameobj);
		rigidbody.angularDrag = 0;
		rigidbody.angularVelocity = Vector3.one * 100;
		rigidbody.drag = 0;
		return rigidbody;
	}

	public static void AddForce(List<Rigidbody> rigidbodyList, ViVector3 rootPos, ViVector3 force, float mass)
	{
		for (int iter = 0; iter < rigidbodyList.Count; ++iter)
		{
			AddForce(rigidbodyList[iter], rootPos, force, mass);
		}
	}

	public static void AddForce(Rigidbody rigidbody, ViVector3 rootPos, ViVector3 force, float mass)
	{
		rigidbody.gameObject.SetActive(true);
		rigidbody.mass = mass;
		ViVector3 direction = rootPos - rigidbody.gameObject.transform.position.Convert();
		direction.Normalize();
		ViVector3 localForce = ViVector3.Dot(direction, force) * direction;
		localForce.x *= 0.15f;
		localForce.y *= 0.15f;
		localForce.z *= Random.Range(0.15f, 0.2f);
		rigidbody.AddForce(localForce.Convert());
	}

	public static void AddForce(Rigidbody rigidbody, ViVector3 rootPos, float force, float mass)
	{
		rigidbody.gameObject.SetActive(true);
		rigidbody.mass = mass;
		ViVector3 direction = rootPos - rigidbody.gameObject.transform.position.Convert();
		direction.Normalize();
		ViVector3 localForce = force * direction;
		localForce.x *= 0.15f;
		localForce.y *= 0.15f;
		localForce.z *= Random.Range(0.15f, 0.2f);
		rigidbody.AddForce(localForce.Convert());
	}

	public static void AddForce(Rigidbody rigidbody, ViVector3 force, float mass)
	{
		rigidbody.gameObject.SetActive(true);
		rigidbody.mass = mass;
		ViVector3 localForce = force;
		localForce.x *= 0.15f;
		localForce.y *= 0.15f;
		localForce.z *= Random.Range(0.15f, 0.2f);
		rigidbody.AddForce(localForce.Convert());
	}

	public static void CopyTransform(Transform[] from, Transform[] to)
	{
		if (from == null || to == null)
		{
			return;
		}
		int size = ViMathDefine.Min(from.Length, to.Length);
		for (int iter = 0; iter < size; ++iter)
		{
			to[iter].position = from[iter].position;
			to[iter].rotation = from[iter].rotation;
		}
	}
}
