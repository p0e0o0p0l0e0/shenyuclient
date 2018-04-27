using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using System.IO;

public class GameObjectKeyName
{
	public static readonly string Level = "level";
	public static readonly string LevelLiving = "level_living";
	public static readonly string LevelDead = "level_dead";
	//
	public static readonly string FadeOut = "FadeOut";
	//
	public static readonly string LOD = "LOD_";
	public static readonly string LOD_HEIGHT = "LOD_H";
	public static readonly string LOD_LOW = "LOD_L";
	//
	public static readonly string BODY_LOW = "BodyLow";
}

public static class UnityComponentList<T>
		where T : Component
{
	public static int Count { get { return _list.Count; } }
	public static List<T> List { get { return _list; } }
	public static void Begin(GameObject obj)
	{
		Begin(obj, false);
	}
	public static void Begin(GameObject obj, bool includeInactive)
	{
		_list.Clear();
		if (obj != null)
		{
			obj.GetComponentsInChildren<T>(includeInactive, _list);
		}
	}
	public static void End()
	{
		_list.Clear();
	}
	static List<T> _list = new List<T>();
}

public static class UnityAssisstant
{
	public static readonly string GROUP_PRO = "pro";
	public static readonly string GROUP_RES = "res";
	public static readonly string GROUP_VIB = "vib";
    public static readonly string GROUP_FIG = "config";

    public static Quaternion CameraRotation = Quaternion.identity;
	public static float CameraYaw = 0.0f;

	public static GameObject DebugHint;

	public static void SetActive(GameObject obj, bool value)
	{
		if (obj != null)
		{
			obj.SetActive(value);
		}
	}

	public static void Destroy(ref UnityEngine.Object obj)
	{
		if (obj == null)
		{
			return;
		}
		UnityEngine.GameObject gameObj = obj as UnityEngine.GameObject;
		if (gameObj != null)
		{
			gameObj.SetActive(false);
		}
		gameObj.transform.parent = null;
		UnityEngine.Object.Destroy(obj);
		obj = null;
	}

	public static void Destroy(ref UnityEngine.GameObject obj)
	{
		if (obj == null)
		{
			return;
		}
		obj.transform.parent = null;
		obj.SetActive(false);
		UnityEngine.Object.Destroy(obj);
		obj = null;
	}

	public static void Destroy(List<UnityEngine.GameObject> objList)
	{
		if (objList == null)
		{
			return;
		}
		for (int iter = 0; iter < objList.Count; ++iter)
		{
			UnityEngine.GameObject iterObj = objList[iter];
			Destroy(ref iterObj);
		}
		objList.Clear();
	}

	public static UnityDeletor.Node DestroyEx(ref UnityEngine.GameObject obj)
	{
		return DestroyEx(ref obj, 1.0f);
	}

	public static UnityDeletor.Node DestroyEx(ref UnityEngine.GameObject obj, float dropScale)
	{
		float duration = 0.0f;
		if (obj != null)
		{
			UnityComponentList<FadeOutProperty>.Begin(obj, true);
			for (int iter = 0; iter < UnityComponentList<FadeOutProperty>.Count; ++iter)
			{
				FadeOutProperty iterComponent = UnityComponentList<FadeOutProperty>.List[iter];
				iterComponent.enabled = true;
				iterComponent.VerticalSpeed *= dropScale;
				duration = Mathf.Max(iterComponent.Duration, duration);
			}
			UnityComponentList<FadeOutProperty>.End();
		}
		UnityDeletor.Node node = UnityDeletor.Add(obj, duration);
		obj = null;
		return node;
	}

	public static GameObject Instantiate(GameObject gameObj, Vector3 position, Quaternion rotation)
	{
		GameObject newObj = UnityEngine.Object.Instantiate(gameObj, position, rotation) as GameObject;
		newObj.SetActive(true);
		if (Application.isEditor)
		{
			ReplaceMaterialShader(newObj);
		}
		return newObj;
	}

	public static GameObject Instantiate(GameObject gameObj)
	{
		GameObject newObj = UnityEngine.Object.Instantiate(gameObj);
		newObj.SetActive(true);
		if (Application.isEditor)
		{
			ReplaceMaterialShader(newObj);
		}
		return newObj;
	}

	public static GameObject InstantiateAsChild(GameObject gameObj, Transform tran)
	{
		return InstantiateAsChild(gameObj, tran, Vector3.zero, true);
	}
	public static GameObject InstantiateAsChild(GameObject gameObj, Transform tran, Vector3 offset, bool inheritScale)
	{
		GameObject newObj = UnityEngine.Object.Instantiate(gameObj, 
            tran == null ? gameObj.transform.position : tran.position + offset, 
            tran == null ? gameObj.transform.rotation : tran.rotation) as GameObject;
		if (!inheritScale)
		{
			newObj.transform.localScale = Vector3.one;
		}
		newObj.SetActive(true);
		newObj.transform.parent = tran;
		if (inheritScale)
		{
			newObj.transform.localScale = Vector3.one;
		}
        
		if (Application.isEditor)
		{
			ReplaceMaterialShader(newObj);
		}
		return newObj;
	}

	public static void SetStaticRecursively(UnityEngine.GameObject obj, bool value)
	{
		_SetStaticRecursively(obj, value);
	}

	static void _SetStaticRecursively(UnityEngine.GameObject obj, bool value)
	{
		obj.isStatic = value;
		for (int iter = 0; iter < obj.transform.childCount; ++iter)
		{
			Transform iterTran = obj.transform.GetChild(iter);
			_SetStaticRecursively(iterTran.gameObject, value);
		}
	}

	public static void SetLayerRecursively(UnityEngine.GameObject obj, int value)
	{
		_SeLayerRecursively(obj, value);
	}

	static void _SeLayerRecursively(UnityEngine.GameObject obj, int value)
	{
		obj.layer = value;
		for (int iter = 0; iter < obj.transform.childCount; ++iter)
		{
			Transform iterTran = obj.transform.GetChild(iter);
			_SeLayerRecursively(iterTran.gameObject, value);
		}
	}
	public static Transform GetChildRecursively(this Transform root, string name)
	{
		return GetChildRecursively(root, name, null);
	}

	public static Transform GetChildRecursively(this Transform root, string name, Transform defaultTranform)
	{
		Transform tran = _GetChildRecursively(root, name, false);
		if (tran == null)
		{
			tran = _GetChildRecursively(root, name, true);
		}
		if (tran == null)
		{
			tran = defaultTranform;
		}
		return tran;
	}

	static Transform _GetChildRecursively(Transform root, string name, bool ignoreDeactive)
	{
		if (!ignoreDeactive && !root.gameObject.activeSelf)
		{
			return null;
		}
		if (root.gameObject.name == name)
		{
			return root;
		}
		for (int iter = 0; iter < root.childCount; ++iter)
		{
			Transform iterTran = root.GetChild(iter);
			Transform iterTarget = _GetChildRecursively(iterTran, name, ignoreDeactive);
			if (iterTarget != null)
			{
				return iterTarget;
			}
		}
		return null;
	}

	public static string GetTranFullHierarchy(GameObject go)
	{
		if (go == null)
		{
			return string.Empty;
		}
		Transform current = go.transform;
		string path = current.name;
		while (current.parent != null)
		{
			current = current.parent;
			path = current.name + "/" + path;
		}
		return path;
	}

	public static void GetChildren(this GameObject parent, string name, List<GameObject> objList)
	{
		for (int iter = 0; iter < parent.transform.childCount; ++iter)
		{
			GameObject iterObject = parent.transform.GetChild(iter).gameObject;
			if (iterObject.name == name)
			{
				objList.Add(iterObject);
			}
		}
	}
	public static GameObject GetChild(this GameObject parent, string name)
	{
		Transform childTransform = parent.transform.Find(name);
		if (childTransform != null)
		{
			return childTransform.gameObject;
		}
		else
		{
			return null;
		}
	}
	public static void SetChildStateRecursively(Transform root, string name, bool value)
	{
		Transform child = GetChildRecursively(root, name, null);
		if (child != null)
		{
			child.gameObject.SetActive(value);
		}
	}

	public static T GetChildComponent<T>(GameObject parent, string name) where T : Component
	{
		Transform childTransform = parent.transform.Find(name);
		if (childTransform != null)
		{
			return childTransform.gameObject.GetComponent<T>();
		}
		else
		{
			return null;
		}
	}
	public static T GetComponentRecursively<T>(GameObject obj)
		where T : Component
	{
		if (obj == null)
		{
			return null;
		}
		T component = obj.GetComponent<T>();
		if (component != null)
		{
			return component;
		}
		return obj.GetComponentInChildren<T>();
	}


	public static void GetComponentRecursively<T>(GameObject obj, List<T> list)
		where T : Component
	{
		list.Clear();
		if (obj == null)
		{
			return;
		}
		obj.GetComponentsInChildren<T>(list);
		//T component = obj.GetComponent<T>();
		//if (component != null)
		//{
		//    list.Add(component);
		//}
	}

	public static Animation GetAvatarAnimation(GameObject obj)
	{
		if (obj == null)
		{
			return null;
		}
		Animation animation = obj.GetComponentInChildren<Animation>();
		if (animation != null)
		{
			return animation;
		}
		//UnityComponentList<Animation>.Begin()
		//Animation[] animationList = obj.GetComponentsInChildren<Animation>();
		//for (int iter = 0; iter < animationList.Length; ++iter)
		//{
		//    Animation iterAnim = animationList[iter];
		//    if (iterAnim["Idle"] != null)
		//    {
		//        return iterAnim;
		//    }
		//}
		//if (animationList.Length > 0)
		//{
		//    return animationList[0];
		//}
		return null;
	}


	public static void JionTransform(Transform parent, Transform child)
	{
		Quaternion oldQuat = child.transform.localRotation;
		child.parent = parent;
		child.localPosition = Vector3.zero;
		child.localRotation = oldQuat;
	}

	public static void JionTransform(GameObject parent, GameObject child)
	{
		Quaternion oldQuat = child.transform.localRotation;
		child.transform.parent = parent.transform;
		child.transform.localPosition = Vector3.zero;
		child.transform.localRotation = oldQuat;
	}

	public static void JionTransform(Transform parent, Transform child, Vector3 offset, Quaternion rot)
	{
		child.parent = parent;
		child.localPosition = offset;
		child.localRotation = rot;
	}

	public static void JionTransform(GameObject parent, GameObject child, Vector3 offset, Quaternion rot)
	{
		child.transform.parent = parent.transform;
		child.transform.localPosition = offset;
		child.transform.localRotation = rot;
	}

	public static void SetScale(GameObject obj, float scale)
	{
		if (obj != null)
		{
			obj.transform.localScale = new Vector3(scale, scale, scale);
			//
			UnityComponentList<Projector>.Begin(obj);
			for (int iter = 0; iter < UnityComponentList<Projector>.List.Count; ++iter)
			{
				Projector iterComponent = UnityComponentList<Projector>.List[iter];
				iterComponent.orthographicSize = scale;
			}
			UnityComponentList<Projector>.End();
		}
	}

	public static GameObject CreateChild(Transform root, string name, bool force)
	{
		Transform child = root.Find(name);
		if (child != null && !force)
		{
			return child.gameObject;
		}
		GameObject newObj = new GameObject(name);
		JionTransform(root, newObj.transform);
		return newObj;
	}

	public static T CreateComponent<T>(GameObject obj) where T : Component
	{
		T component = obj.GetComponent<T>();
		if (component == null)
		{
			component = obj.AddComponent<T>();
		}
		return component;
	}

	public static void DelComponent<T>(GameObject obj) where T : Component
	{
		T component = obj.GetComponent<T>();
		if (component != null)
		{
			UnityEngine.Object.Destroy(component);
		}
	}

	public static void SetComponentState<T>(GameObject obj, bool active) where T : Behaviour
	{
		T component = obj.GetComponent<T>();
		if (component != null)
		{
			component.enabled = active;
		}
	}

	#region UI

	public static Vector3 WorldToNGUIPixel(Camera camera, Vector3 pos)
	{
		Vector3 screenPos = camera.WorldToScreenPoint(pos);
		float x = screenPos.x - Screen.width * 0.5f;
		float y = screenPos.y - Screen.height * 0.5f;
		return new Vector3(x, y, 0.0f);
	}

	public static Vector3 WorldToNGUIScale(Camera camera, Vector3 pos)
	{
		Vector3 screenPos = camera.WorldToScreenPoint(pos);
		float horizScale = (float)Screen.width / (float)Screen.height;
		float x = (1.0f + (screenPos.x - Screen.width) / Screen.width * 2) * horizScale;
		float y = 1.0f + (screenPos.y - Screen.height) / Screen.height * 2;
		return new Vector3(x, y, 0.0f);
	}

	public static Vector3 ScreenToNGUIScale(Vector3 screenPos)
	{
		float horizScale = (float)Screen.width / (float)Screen.height;
		float x = (1.0f + (screenPos.x - Screen.width) / Screen.width * 2) * horizScale;
		float y = 1.0f + (screenPos.y - Screen.height) / Screen.height * 2;
		return new Vector3(x, y, 0.0f);
	}

	#endregion
	#region Gree&Angle

	public static float Translate360To2Pi(float value)
	{
		return (180.0f - value) * 3.14f / 180.0f;
	}
	public static float Translate2PiTo360(float value)
	{
		return 180.0f - value / 3.14f * 180.0f;
	}

	#endregion
	//public static void SetColor(Renderer renderer, Color color)
	//{
	//    Material[] materials = renderer.materials;
	//    for (int iter = 0; iter < materials.Length; ++iter)
	//    {
	//        Material material = materials[iter];
	//        material.color = color;
	//    }
	//}

	#region Color
	public static void SetColor(Renderer renderer, Color color, Dictionary<Int32, Color> oldColors)
	{
		Material[] materials = renderer.materials;
		for (int iter = 0; iter < materials.Length; ++iter)
		{
			Material material = materials[iter];
			if (!material.HasProperty("_Color"))
			{
				continue;
			}
			if (oldColors != null)
			{
				oldColors[material.GetInstanceID()] = material.color;
			}
			material.color = color;
		}
	}

	public static void SetColor(List<Renderer> renderers, Color color, Dictionary<Int32, Color> oldColors)
	{
		for (int iter = 0; iter < renderers.Count; ++iter)
		{
			SetColor(renderers[iter], color, oldColors);
		}
	}

	public static void SetColor(Renderer renderer, Dictionary<Int32, Color> colors)
	{
		Material[] materials = renderer.materials;
		for (int iter = 0; iter < materials.Length; ++iter)
		{
			Material material = materials[iter];
			if (!material.HasProperty("_Color"))
			{
				continue;
			}
			Color color;
			if (colors.TryGetValue(material.GetInstanceID(), out color))
			{
				material.color = color;
			}
		}
	}

	public static void SetColor(List<Renderer> renderers, Dictionary<Int32, Color> colors)
	{
		for (int iter = 0; iter < renderers.Count; ++iter)
		{
			SetColor(renderers[iter], colors);
		}
	}

	public static void SetColor(GameObject obj, Color color)
	{
		UnityComponentList<Renderer>.Begin(obj);
		SetColor(UnityComponentList<Renderer>.List, null);
		UnityComponentList<Renderer>.End();
	}

	public static void SetColor(GameObject obj, Color color, Dictionary<Int32, Color> oldColors)
	{
		UnityComponentList<Renderer>.Begin(obj);
		SetColor(UnityComponentList<Renderer>.List, color, oldColors);
		UnityComponentList<Renderer>.End();
	}

	public static void SetColor(GameObject obj, Dictionary<Int32, Color> colors)
	{
		UnityComponentList<Renderer>.Begin(obj);
		SetColor(UnityComponentList<Renderer>.List, colors);
		UnityComponentList<Renderer>.End();
	}

	#endregion


	public static void Rewind(GameObject obj)
	{
		UnityComponentList<Animation>.Begin(obj);
		for (int iter = 0; iter < UnityComponentList<Animation>.List.Count; ++iter)
		{
			Animation iterComponent = UnityComponentList<Animation>.List[iter];
			iterComponent.Rewind();
		}
		UnityComponentList<Animation>.End();
		//
		UnityComponentList<ParticleSystem>.Begin(obj);
		for (int iter = 0; iter < UnityComponentList<ParticleSystem>.List.Count; ++iter)
		{
			ParticleSystem iterComponent = UnityComponentList<ParticleSystem>.List[iter];
			iterComponent.Stop();
			iterComponent.Play();
		}
		UnityComponentList<ParticleSystem>.End();
	}

	public static void StopParticleLoop(GameObject obj)
	{
		UnityComponentList<ParticleSystem>.Begin(obj);
		for (int iter = 0; iter < UnityComponentList<ParticleSystem>.List.Count; ++iter)
		{
			ParticleSystem iterParticle = UnityComponentList<ParticleSystem>.List[iter];
            ParticleSystem.MainModule particleMain = iterParticle.main;
            particleMain.loop = false;

            //iterParticle.loop = false;
		}
		UnityComponentList<ParticleSystem>.End();
	}

	//public static void SetOutLine(GameObject obj, bool active)
	//{
	//    if (obj == null)
	//    {
	//        return;
	//    }
	//    OutlineDetector outline = obj.GetComponentInChildren<OutlineDetector>();
	//    if (outline == null)
	//    {
	//        return;
	//    }
	//    if (active)
	//    {
	//        outline.TurnOn();
	//    }
	//    else
	//    {
	//        outline.TurnOff();
	//    }
	//}

	public static bool GetBound(GameObject ob, ref ViVector3 center, ref ViVector3 external)
	{
		BoxCollider collider = GetComponentRecursively<BoxCollider>(ob);
		if (collider != null)
		{
			center = collider.center.Convert();
			external = collider.size.Convert();
			return true;
		}
		Renderer render = GetComponentRecursively<Renderer>(ob);
		if (render != null)
		{
			center = render.bounds.center.Convert();
			external = render.bounds.extents.Convert();
			return true;
		}
		return false;
	}

	public static Ray Rotate(Ray ray, Vector3 center, float yaw)
	{
		Quaternion rotate = Quaternion.AngleAxis(ViMathDefine.Rad2Deg * yaw, Vector3.up);
		Vector3 origin = ray.origin - center;
		origin = rotate * origin;
		Vector3 direction = rotate * ray.direction;
		Ray newRay = new Ray(origin + center, direction);
		return newRay;
	}

	public static void UpdateSoundVolume(GameObject obj, float volume)
	{
		if (obj == null)
		{
			return;
		}
		//
		UnityComponentList<AudioSource>.Begin(obj);
		for (int iter = 0; iter < UnityComponentList<AudioSource>.List.Count; ++iter)
		{
			AudioSource iterComponent = UnityComponentList<AudioSource>.List[iter];
			iterComponent.volume = volume;
			iterComponent.spread = 120.0f;
		}
		UnityComponentList<AudioSource>.End();
	}

	public static void UpdateSoundVolume(GameObject obj, float volume, out float duration)
	{
		duration = 0;
		if (obj == null)
		{
			return;
		}
		//
		UnityComponentList<AudioSource>.Begin(obj);
		for (int iter = 0; iter < UnityComponentList<AudioSource>.List.Count; ++iter)
		{
			AudioSource iterComponent = UnityComponentList<AudioSource>.List[iter];
			iterComponent.volume = volume;
			iterComponent.spread = 120.0f;
			if (iterComponent.clip == null)
			{
				duration = 1.0f;
				ViDebuger.Warning("iterComponent.clip is NULL! [" + iterComponent.name + "]");
			}
			else
			{
				duration = ViMathDefine.Max(duration, iterComponent.clip.length);
			}
		}
		UnityComponentList<AudioSource>.End();
	}

	public static void SetSoundLoop(GameObject obj, bool value)
	{
		if (obj == null)
		{
			return;
		}
		//
		UnityComponentList<AudioSource>.Begin(obj);
		for (int iter = 0; iter < UnityComponentList<AudioSource>.List.Count; ++iter)
		{
			AudioSource iterComponent = UnityComponentList<AudioSource>.List[iter];
			iterComponent.loop = value;
		}
		UnityComponentList<AudioSource>.End();
	}

	/// <summary>
	/// 如果模型采用了standard shader， 就把它重新设置一遍。为了应对Unity5.2f1的bug。
	/// 现在每个模型载入的时候都要做这个检查。等unity修了这个bug后， 应该把这个步骤取消.
	/// </summary>
	//public static void ResetStandardShader(GameObject obj)
	//{
	//    if (obj == null)
	//    {
	//        return;
	//    }
	//    Renderer rend = obj.GetComponent<Renderer>();
	//    if (rend == null)
	//    {
	//        return;
	//    }
	//    //
	//    Material[] materials = rend.sharedMaterials;
	//    for (int iter = 0; iter < materials.Length; ++iter)
	//    {
	//        Material material = materials[iter];
	//        if (material == null) continue;
	//        string shaderName = material.shader.name;
	//        if (shaderName.Contains("Standard"))
	//        {
	//            Shader shader = Shader.Find(shaderName);
	//            if (shader != null)
	//            {
	//                material.shader = shader;
	//            }
	//        }
	//    }
	//}

	public static void ReplaceMaterialShader(Material material)
	{
		if (material == null)
		{
			return;
		}
		//
		Int32 renderQueue = material.renderQueue;
		Shader shader = Shader.Find(material.shader.name);
		if (shader != null)
		{
			material.shader = shader;
			material.renderQueue = renderQueue;
		}
	}

	public static void ReplaceMaterialShader(Renderer renderer)
	{
		for (int iter = 0; iter < renderer.sharedMaterials.Length; ++iter)
		{
			Material iterMaterial = renderer.sharedMaterials[iter];
			if (iterMaterial != null)
			{
				ReplaceMaterialShader(iterMaterial);
			}
		}
	}

	public static void ReplaceMaterialShader(GameObject gameobject)
	{
		UnityComponentList<Renderer>.Begin(gameobject, true);
		for (int iter = 0; iter < UnityComponentList<Renderer>.List.Count; ++iter)
		{
			ReplaceMaterialShader(UnityComponentList<Renderer>.List[iter]);
		}
		UnityComponentList<Renderer>.End();
	}

	public static SkinnedMeshRenderer GetMainSkin(GameObject obj)
	{
		SkinnedMeshRenderer skin = obj.GetComponent<SkinnedMeshRenderer>();
		if (skin != null)
		{
			return skin;
		}
		//
		float maxBody = 0.0f;
		UnityComponentList<SkinnedMeshRenderer>.Begin(obj);
		for (int iter = 0; iter < UnityComponentList<SkinnedMeshRenderer>.List.Count; ++iter)
		{
			SkinnedMeshRenderer iterComponent = UnityComponentList<SkinnedMeshRenderer>.List[iter];
			Vector3 iterSize = iterComponent.bounds.size;
			float iterBody = iterSize.x * iterSize.y * iterSize.z;
			if (iterBody >= maxBody)
			{
				maxBody = iterBody;
				skin = iterComponent;
			}
		}
		UnityComponentList<SkinnedMeshRenderer>.End();
		return skin;
	}

	public static void SetParticleLightEnable(GameObject obj, bool paritcalLight)
	{
		if (!paritcalLight)
		{
			return;
		}
		//
		UnityComponentList<Light>.Begin(obj);
		for (int iter = 0; iter < UnityComponentList<Light>.List.Count; ++iter)
		{
			Light iterComponent = UnityComponentList<Light>.List[iter];
			iterComponent.enabled = true;
		}
		UnityComponentList<Light>.End();
	}

	public delegate Material GhostMaterialReplace(Material old, Material newTemplate);
	public static GameObject CreateGhostAvatar(GameObject root, SkinnedMeshRenderer renderer, Material material, GhostMaterialReplace materialReplace)
	{
		if (renderer.sharedMesh == null)
		{
			return null;
		}
		GameObject newObj = UnityAssisstant.CreateChild(root.transform, renderer.gameObject.name, false);
		SkinnedMeshRenderer mesh = UnityAssisstant.CreateComponent<SkinnedMeshRenderer>(newObj);
		mesh.sharedMesh = (UnityEngine.Mesh)UnityEngine.Object.Instantiate(renderer.sharedMesh);
		mesh.bones = renderer.bones;
		Material newMaterial = material;
		int materialSize = renderer.materials.Length;
		UnityEngine.Material[] materials = new UnityEngine.Material[materialSize];
		for (int iter = 0; iter < materialSize; ++iter)
		{
			if (materialReplace != null)
			{
				newMaterial = materialReplace(renderer.materials[iter], material);
			}
			//
			materials[iter] = newMaterial;
		}
		mesh.material = newMaterial;
		mesh.materials = materials;
		mesh.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
		mesh.receiveShadows = false;
		return newObj;
	}

	public static GameObject CreateGhostAvatar(GameObject root, MeshRenderer renderer, Material material, GhostMaterialReplace materialReplace)
	{
		GameObject newObj = UnityAssisstant.CreateChild(root.transform, renderer.gameObject.name, false);
		SkinnedMeshRenderer mesh = UnityAssisstant.CreateComponent<SkinnedMeshRenderer>(newObj);
		mesh.sharedMesh = (UnityEngine.Mesh)UnityEngine.Object.Instantiate(renderer.additionalVertexStreams);
		Material newMaterial = material;
		if (materialReplace != null)
		{
			newMaterial = materialReplace(mesh.material, material);
		}
		int materialSize = renderer.materials.Length;
		UnityEngine.Material[] materials = new UnityEngine.Material[materialSize];
		for (int iter = 0; iter < materialSize; ++iter)
		{
			materials[iter] = newMaterial;
		}
		mesh.material = newMaterial;
		mesh.materials = materials;
		mesh.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
		mesh.receiveShadows = false;
		return newObj;
	}

	public static GameObject BakeMesh(GameObject gameobject, Material replaceMaterial)
	{
		if (gameobject == null)
		{
			return null;
		}
		//
		GameObject shadowRoot = new GameObject();
		shadowRoot.name = gameobject.name + "_shadowRoot";
		//
		UnityComponentList<SkinnedMeshRenderer>.Begin(gameobject);
		for (int iter = 0; iter < UnityComponentList<SkinnedMeshRenderer>.List.Count; ++iter)
		{
			SkinnedMeshRenderer iterSkinrenderer = UnityComponentList<SkinnedMeshRenderer>.List[iter];
			if (iterSkinrenderer == null)
			{
				continue;
			}
			//
			Mesh mesh = new Mesh();
			iterSkinrenderer.BakeMesh(mesh);
			//
			GameObject iterChildrenobj = CreatMeshGameObject(mesh, iterSkinrenderer, replaceMaterial);
			//
			iterChildrenobj.transform.position = iterSkinrenderer.gameObject.transform.position - gameobject.transform.position;
			iterChildrenobj.transform.rotation = iterSkinrenderer.gameObject.transform.rotation;
			iterChildrenobj.transform.parent = shadowRoot.transform;
		}
		UnityComponentList<SkinnedMeshRenderer>.End();
		//
		UnityComponentList<MeshFilter>.Begin(gameobject);
		for (int iter = 0; iter < UnityComponentList<MeshFilter>.List.Count; ++iter)
		{
			MeshFilter iterMeshFilter = UnityComponentList<MeshFilter>.List[iter];

			if (!iterMeshFilter.gameObject.name.StartsWith("Wp"))
			{
				continue;
			}

			MeshRenderer iterMeshrenderer = iterMeshFilter.gameObject.GetComponent<MeshRenderer>();
			if (iterMeshFilter == null || iterMeshrenderer == null) continue;
			//
			Mesh mesh = UnityEngine.Object.Instantiate(iterMeshFilter.mesh);
			//
			GameObject childrenobj = CreatMeshGameObject(mesh, iterMeshrenderer, replaceMaterial);
			//
			childrenobj.transform.position = iterMeshrenderer.gameObject.transform.position - gameobject.transform.position;
			childrenobj.transform.rotation = iterMeshrenderer.gameObject.transform.rotation;
			childrenobj.transform.localScale = iterMeshrenderer.gameObject.transform.lossyScale;
			childrenobj.transform.parent = shadowRoot.transform;
		}
		UnityComponentList<MeshFilter>.End();
		//
		shadowRoot.transform.position = gameobject.transform.position;
		StaticBatchingUtility.Combine(shadowRoot);
		return shadowRoot;
	}

	public static GameObject CreatMeshGameObject(Mesh mesh, Renderer render, Material replaceMaterial)
	{
		GameObject childrenobj = new GameObject();
		MeshFilter meshfilter = childrenobj.AddComponent<MeshFilter>();
		MeshRenderer meshrender = childrenobj.AddComponent<MeshRenderer>();
		meshfilter.mesh = mesh;
		//
		if (replaceMaterial)
		{
			Material[] materials = new Material[render.materials.Length];
			for (int iter = 0; iter < materials.Length; ++iter)
			{
				materials[iter] = replaceMaterial;
			}
			meshrender.materials = materials;
		}
		else
		{
			meshrender.materials = render.materials;
		}
		//
		meshrender.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
		meshrender.receiveShadows = false;
		//meshrender.useLightProbes = false;
		//
		return childrenobj;
	}

	public static Material MaterialTextureAlphaReplace(Material oldMaterial, Material newMaterialTemplate)
	{
		if (newMaterialTemplate.HasProperty("_OriginalTex"))
		{
			Material newMaterial = new Material(newMaterialTemplate.shader);
			newMaterial.CopyPropertiesFromMaterial(newMaterialTemplate);
			Texture meshMainTexture = null;
			if (oldMaterial.HasProperty("_MainTex"))
			{
				meshMainTexture = oldMaterial.GetTexture("_MainTex");
			}
			if (meshMainTexture != null)
			{
				newMaterial.SetTexture("_OriginalTex", meshMainTexture);
			}
			else
			{
				Texture2D texture = new Texture2D(1, 1, TextureFormat.ARGB32, false);
				texture.SetPixel(0, 0, Color.black);
				newMaterial.SetTexture("_OriginalTex", texture);
				newMaterial.SetColor("_RimColor", Color.black);
			}
			return newMaterial;
		}
		else
		{
			return newMaterialTemplate;
		}
	}

	public static Material MaterialToonShaderTextureReplace(Material oldMaterial, Material newMaterialTemplate)
	{
		if (newMaterialTemplate.HasProperty("_MainTex"))
		{
			Material newMaterial = new Material(newMaterialTemplate.shader);
			newMaterial.CopyPropertiesFromMaterial(newMaterialTemplate);
			Texture meshMainTexture = null;
			if (oldMaterial.HasProperty("_MainTex"))
			{
				meshMainTexture = oldMaterial.GetTexture("_MainTex");
				newMaterial.SetTexture("_MainTex", meshMainTexture);
			}
			if (oldMaterial.HasProperty("_Ramp"))
			{
				newMaterial.SetTexture("_Ramp", oldMaterial.GetTexture("_Ramp"));
			}
			if (oldMaterial.HasProperty("_SpecColor"))
			{
				newMaterial.SetColor("_SpecColor", oldMaterial.GetColor("_SpecColor"));
			}
			if (oldMaterial.HasProperty("_Shininess"))
			{
				newMaterial.SetFloat("_Shininess", oldMaterial.GetFloat("_Shininess"));
			}
			if (oldMaterial.HasProperty("_Color"))
			{
				newMaterial.SetColor("_Color", oldMaterial.GetColor("_Color"));
			}
			if (oldMaterial.HasProperty("_SColor"))
			{
				newMaterial.SetColor("_SColor", oldMaterial.GetColor("_SColor"));
			}
			if (oldMaterial.HasProperty("_Outline"))
			{
				newMaterial.SetFloat("_Outline", oldMaterial.GetFloat("_Outline"));
			}
			if (oldMaterial.HasProperty("_OutlineColor"))
			{
				newMaterial.SetColor("_OutlineColor", oldMaterial.GetColor("_OutlineColor"));
			}
			if (oldMaterial.HasProperty("_Emission"))
			{
				newMaterial.SetColor("_Emission", oldMaterial.GetColor("_Emission"));
			}
			//
			return newMaterial;
		}
		else
		{
			return newMaterialTemplate;
		}
	}

	public static Material MaterialMatCapTextureAddReplace(Material oldMaterial, Material newMaterialTemplate)
	{
		if (newMaterialTemplate.HasProperty("_MainTex"))
		{
			Material newMaterial = new Material(newMaterialTemplate.shader);
			newMaterial.CopyPropertiesFromMaterial(newMaterialTemplate);
			Texture meshMainTexture = null;
			if (oldMaterial.HasProperty("_MainTex"))
			{
				meshMainTexture = oldMaterial.GetTexture("_MainTex");
				newMaterial.SetTexture("_MainTex", meshMainTexture);
			}
			if (oldMaterial.HasProperty("_MatCap"))
			{
				newMaterial.SetTexture("_MatCap", oldMaterial.GetTexture("_MatCap"));
			}
			//
			return newMaterial;
		}
		else
		{
			return newMaterialTemplate;
		}
	}

	public static Material CharacterShaderReplace(Material oldMaterial, Material newMaterialTemplate)
	{
		if (newMaterialTemplate.HasProperty("_MainTex"))
		{
			Material newMaterial = new Material(newMaterialTemplate.shader);
			newMaterial.CopyPropertiesFromMaterial(newMaterialTemplate);
			Texture meshMainTexture = null;
			if (oldMaterial.HasProperty("_MainTex"))
			{
				meshMainTexture = oldMaterial.GetTexture("_MainTex");
				newMaterial.SetTexture("_MainTex", meshMainTexture);
			}
			if (oldMaterial.HasProperty("_MatTex"))
			{
				newMaterial.SetTexture("_MatTex", oldMaterial.GetTexture("_MatTex"));
			}
			if (oldMaterial.HasProperty("_DiffuseRampTex"))
			{
				newMaterial.SetTexture("_DiffuseRampTex", oldMaterial.GetTexture("_DiffuseRampTex"));
			}
			if (oldMaterial.HasProperty("_SpecRampTex"))
			{
				newMaterial.SetTexture("_SpecRampTex", oldMaterial.GetTexture("_SpecRampTex"));
			}
			if (oldMaterial.HasProperty("_OutlineWidth"))
			{
				newMaterial.SetFloat("_OutlineWidth", oldMaterial.GetFloat("_OutlineWidth"));
			}
			if (oldMaterial.HasProperty("_EdgeColor"))
			{
				newMaterial.SetColor("_EdgeColor", oldMaterial.GetColor("_EdgeColor"));
			}
			if (oldMaterial.HasProperty("_LightParams"))
			{
				newMaterial.SetVector("_LightParams", oldMaterial.GetVector("_LightParams"));
			}
			if (oldMaterial.HasProperty("_LightParamsHDR"))
			{
				newMaterial.SetVector("_LightParamsHDR", oldMaterial.GetVector("_LightParamsHDR"));
			}
			if (oldMaterial.HasProperty("_HairParams"))
			{
				newMaterial.SetVector("_HairParams", oldMaterial.GetVector("_HairParams"));
			}
			if (oldMaterial.HasProperty("_AnimeEnvTex"))
			{
				newMaterial.SetTexture("_AnimeEnvTex", oldMaterial.GetTexture("_AnimeEnvTex"));
			}
			if (oldMaterial.HasProperty("_EnvParams"))
			{
				newMaterial.SetVector("_EnvParams", oldMaterial.GetVector("_EnvParams"));
			}
			if (oldMaterial.HasProperty("_SceneEnvTex"))
			{
				newMaterial.SetTexture("_SceneEnvTex", oldMaterial.GetTexture("_SceneEnvTex"));
			}
			//
			return newMaterial;
		}
		else
		{
			return newMaterialTemplate;
		}
	}

	public static void SelectShareMaterial(GameObject obj, Dictionary<Int32, Material[]> materialList)
	{
		UnityComponentList<Renderer>.Begin(obj);
		SelectShareMaterial(UnityComponentList<Renderer>.List, materialList);
		UnityComponentList<Renderer>.End();
	}
	public static void SelectShareMaterial(List<Renderer> rendererList, Dictionary<Int32, Material[]> materialList)
	{
		for (int iter = 0; iter < rendererList.Count; ++iter)
		{
			SelectShareMaterial(rendererList[iter], materialList);
		}
	}
	public static void SelectShareMaterial(Renderer renderer, Dictionary<Int32, Material[]> materialList)
	{
		materialList[renderer.GetInstanceID()] = renderer.sharedMaterials;
	}
	public static void RevertShareMaterial(GameObject obj, Dictionary<Int32, Material[]> materialList)
	{
		UnityComponentList<Renderer>.Begin(obj);
		RevertShareMaterial(UnityComponentList<Renderer>.List, materialList);
		UnityComponentList<Renderer>.End();
	}
	public static void RevertShareMaterial(List<Renderer> rendererList, Dictionary<Int32, Material[]> materialList)
	{
		for (int iter = 0; iter < rendererList.Count; ++iter)
		{
			RevertShareMaterial(rendererList[iter], materialList);
		}
	}
	public static void RevertShareMaterial(Renderer renderer, Dictionary<Int32, Material[]> materialList)
	{
		Material[] materials;
		if (materialList.TryGetValue(renderer.GetInstanceID(), out materials))
		{
			renderer.materials = materials;
		}
	}

	public static void UpdateSwitchComponent(GameObject obj, string layer)
	{
		if (string.IsNullOrEmpty(layer))
		{
			return;
		}
		//
		UnityComponentList<SwitchComponent>.Begin(obj, false);
		for (int iter = 0; iter < UnityComponentList<SwitchComponent>.Count; ++iter)
		{
			SwitchComponent iterComponent = UnityComponentList<SwitchComponent>.List[iter];
			iterComponent.Set(layer, false);
		}
		UnityComponentList<SwitchComponent>.End();
	}

	public static Vector3 Pick(Vector3 pos, float radius, Vector3 direction, float distance, int layerMask)
	{
		pos -= direction * radius;
		distance += radius;
		return Pick(pos, radius, direction, distance, layerMask, 2);
	}
	static Vector3 Pick(Vector3 pos, float radius, Vector3 direction, float distance, int layerMask, int reserveCount)
	{
		RaycastHit hitResult;
		if (Physics.SphereCast(pos, radius, direction, out hitResult, distance, layerMask))
		{
			float newDistance = Math.Max(hitResult.distance - 0.01f, 0.0f);
			Vector3 newPos = pos + direction * newDistance;
			//
			if (reserveCount > 1)
			{
				float cutedDistance = distance - newDistance;
				Vector3 cutedValue = direction * cutedDistance;
				Vector3 normal = -hitResult.normal;
				Vector3 normalValue = Vector3.Dot(cutedValue, normal) * normal;
				Vector3 slideValue = cutedValue - normalValue;
				Vector3 slideDir = slideValue.normalized;
				float slideDistance = slideValue.magnitude;
				return Pick(newPos, radius, slideDir, slideDistance, layerMask, reserveCount - 1);
			}
			else
			{
				return newPos;
			}
		}
		else
		{
			return pos + direction * distance;
		}
	}

	public static Vector3 ViewportCenterPos = new Vector3(0.5f, 0.5f, 0.0f);
	public static Vector3 WorldToViewportPoint(Camera camera, Vector3 worldPos, float frontDistance)
	{
		Ray ray = camera.ViewportPointToRay(ViewportCenterPos);
		Vector3 diff = worldPos - ray.origin;
		diff -= Vector3.Dot(diff, ray.direction) * ray.direction;
		worldPos = ray.origin + diff + frontDistance * ray.direction;
		return camera.WorldToViewportPoint(worldPos);
	}

	public static Vector3 ViewportRoundPoint(Vector3 viewPortPos)
	{
		Vector3 viewPortDiff = viewPortPos - ViewportCenterPos;
		viewPortDiff /= (2.0f * ViMathDefine.Max(ViMathDefine.Abs(viewPortDiff.x), ViMathDefine.Abs(viewPortDiff.y)));
		return ViewportCenterPos + viewPortDiff;
	}

	public static bool WorldPointInViewport(Camera camera, Vector3 worldPos)
	{
		Vector3 viewPos = camera.WorldToViewportPoint(worldPos);
		if (0.0f < viewPos.x && viewPos.x < 1.0f && 0.0f < viewPos.y && viewPos.y < 1.0f)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
}