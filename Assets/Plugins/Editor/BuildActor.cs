using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

public class BuildActor
{
    static string mSrcPath = "Assets/Arts/";

    [UnityEditor.MenuItem("Assets/BuildAnimation")]
    public static void BuildAnimation()
    {
        List<string> mRefreshList = new List<string>();

        string sSrcPath = "Assets/Arts/";
        for (int i = 0; i < Selection.objects.Length; i++)
        {
            string objPath = AssetDatabase.GetAssetPath(Selection.objects[i]);

            string sFileName = Path.GetFileNameWithoutExtension(objPath);
            string[] sName = sFileName.Split('@');

            string sType = objPath.Replace(sSrcPath, "");
            sType = sType.Substring(0, sType.IndexOf('/'));
            string sNewPath = "Assets/ResEx/Character/" + sType + "/" + sName[0] + "/Anims";

            string mRefreshPath = "Assets/ResEx/Character/" + sType + "/" + sName[0] + "/" + sName[0] + ".prefab";
            if (!mRefreshList.Contains(mRefreshPath))
            {
                mRefreshList.Add(mRefreshPath);
            }

            if (!Directory.Exists(sNewPath))
            {
                Debug.LogError("命名不规范或者没有先导出 skeleton");
                continue;
            }

            ModelImporter tImporter = AssetImporter.GetAtPath(objPath) as ModelImporter;
            if (tImporter != null)
            {
                tImporter.animationType = ModelImporterAnimationType.Legacy;
                tImporter.SaveAndReimport();
            }

            if (Selection.objects[i] is GameObject)
            {
                GameObject select = Selection.objects[i] as GameObject;
                Animation anim = select.GetComponent<Animation>();
                if (anim != null)
                {
                    foreach (AnimationState state in anim)
                    {
                        AnimationClip clip = UnityEngine.Object.Instantiate(anim.GetClip(state.name));
                        FixFloatAtClip(clip);
                        AssetDatabase.CreateAsset(clip, sNewPath + "/" + state.name + ".anim");
                    }
                }
            }
        }
        AssetDatabase.Refresh();

        RefreshActor(mRefreshList);
    }

    private static void RefreshActor(List<string> vRefreshList)
    {
        for (int i = 0; i < vRefreshList.Count; ++i)
        {
            GameObject pActor = AssetDatabase.LoadAssetAtPath<GameObject>(vRefreshList[i]);
            if (pActor != null)
            {
                Animation pNewAnim = pActor.GetChild("Body").GetComponent<Animation>();
                GameObject.DestroyImmediate(pNewAnim, true);

                pNewAnim = pActor.GetChild("Body").AddComponent<Animation>();

                string sPath = vRefreshList[i].Substring(0, vRefreshList[i].LastIndexOf('/') + 1) + "Anims";
                string[] files = Directory.GetFiles(sPath, "*.anim", SearchOption.TopDirectoryOnly);

                foreach (string s in files)
                {
                    AnimationClip clip = AssetDatabase.LoadAssetAtPath<AnimationClip>(s);
                    string sName = Path.GetFileNameWithoutExtension(s);
                    pNewAnim.AddClip(clip, sName);
                }

                AssetDatabase.SaveAssets();
            }
        }
        Debug.Log("动画更新完成!");
    }

    // 优化动画文件
    private static void FixFloatAtClip(AnimationClip clip, bool excludeScale = true)
    {
        try
        {
            if (excludeScale)
            {
                foreach (var theCurveBinding in AnimationUtility.GetCurveBindings(clip))
                {
                    var name = theCurveBinding.propertyName.ToLower();
                    if (name.Contains("scale"))
                    {
                        AnimationUtility.SetEditorCurve(clip, theCurveBinding, null);
                    }
                }
            }

            var curves = AnimationUtility.GetCurveBindings(clip);
            foreach (var curveDate in curves)
            {
                var curve = AnimationUtility.GetEditorCurve(clip, curveDate);
                if (curve == null || curve.keys == null)
                {
                    continue;
                }
                var keyFrames = curve.keys;
                for (var i = 0; i < keyFrames.Length; i++)
                {
                    var key = keyFrames[i];
                    key.value = float.Parse(key.value.ToString("f3"));
                    key.inTangent = float.Parse(key.inTangent.ToString("f3"));
                    key.outTangent = float.Parse(key.outTangent.ToString("f3"));
                    keyFrames[i] = key;
                }
                curve.keys = keyFrames;
                clip.SetCurve(curveDate.path, curveDate.type, curveDate.propertyName, curve);
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError(string.Format("CompressAnimationClip Failed !!! animationPath : {0} error: {1}", clip.name, e));
        }
    }

    // 备份材质数据 创建、删除文件夹
    static void ActorDataBackups(string sPath)
    {
        if (Directory.Exists(sPath))
        {
            if (!Directory.Exists(sPath + "_Temp"))
            {
                Directory.Move(sPath, sPath + "_Temp");
            }
        }
        // 创建新的目录
        Directory.CreateDirectory(sPath);
        Directory.CreateDirectory(sPath + "/Anims");
        Directory.CreateDirectory(sPath + "/Meshs");
        Directory.CreateDirectory(sPath + "/Materials");
        Directory.CreateDirectory(sPath + "/Textures");

        AssetDatabase.Refresh();
    }

    static Texture CopyTexture(List<string> sTexPathList, string sDesPath, string sName)
    {
        string sDesTexName = sName;
        for (int i = 0; i < sTexPathList.Count; ++i)
        {
            if (string.Equals(sDesTexName, Path.GetFileNameWithoutExtension(sTexPathList[i]), StringComparison.OrdinalIgnoreCase))
            {
                File.Copy(sTexPathList[i], sDesPath + "/Textures/" + Path.GetFileName(sTexPathList[i]), true);
                AssetDatabase.Refresh();

                Texture pTex = AssetDatabase.LoadAssetAtPath<Texture>(sDesPath + "/Textures/" + Path.GetFileName(sTexPathList[i]));
                if (pTex == null)
                {
                    throw new ArgumentNullException("Textue 加载失败 找  张子豪  查原因!");
                }
                return pTex;
            }
        }
        throw new ArgumentNullException("没有找到贴图 " + sDesTexName + " 检查贴图名字是否符合命名规范!");
    }

    // 创建材质
    static Material CreateMaterials(string sSrcPath, string sDesPath, Material pSrcMat)
    {
        Regex rSearchPattern = new Regex(@"$(?<=\.(png|tga))", RegexOptions.IgnoreCase);
        List<string> pTexList = Directory.GetFiles(sSrcPath, "*.*", SearchOption.AllDirectories).Where(f => rSearchPattern.IsMatch(f)).ToList();

        string sMatName = pSrcMat.name.ToLower();
        Material pNewMat = null;
        if (sMatName.EndsWith("_pbr"))
        {
            string sMainName = sMatName.Replace("_pbr", "");

            pNewMat = new Material(Shader.Find("Physical Shading/Character/PBR"));
            
            Texture pBaseMap = CopyTexture(pTexList, sDesPath, sMainName + "_b");
            Texture pNormalMap = CopyTexture(pTexList, sDesPath, sMainName + "_n");
            Texture pMixMap = CopyTexture(pTexList, sDesPath, sMainName + "_m");

            pNewMat.SetTexture("_MainTex", pBaseMap);
            pNewMat.SetTexture("_NrmTex", pNormalMap);
            pNewMat.SetTexture("_MixTex", pMixMap);

            Material pOldMat = AssetDatabase.LoadAssetAtPath<Material>(sDesPath + "_Temp/Materials/" + sMatName + ".mat");
            if (pOldMat != null)
            {
                pNewMat.SetColor("_SkinParams", pOldMat.GetColor("_SkinParams"));
                pNewMat.SetColor("_SkinScatter", pOldMat.GetColor("_SkinScatter"));
                pNewMat.SetFloat("_Specular", pOldMat.GetFloat("_Specular"));

                pNewMat.SetColor("_FocusColor", pOldMat.GetColor("_FocusColor"));
                pNewMat.SetColor("_Dissolve", pOldMat.GetColor("_Dissolve"));
                pNewMat.SetColor("_DissolveColor", pOldMat.GetColor("_DissolveColor"));
            }
        }
        else if (sMatName.EndsWith("_pbrglow"))
        {
            string sMainName = sMatName.Replace("_pbrglow", "");

            pNewMat = new Material(Shader.Find("Physical Shading/Character/PBRGlow"));

            Texture pBaseMap = CopyTexture(pTexList, sDesPath, sMainName + "_b");
            Texture pNormalMap = CopyTexture(pTexList, sDesPath, sMainName + "_n");
            Texture pMixMap = CopyTexture(pTexList, sDesPath, sMainName + "_m");
            Texture pGlowMap = CopyTexture(pTexList, sDesPath, sMainName + "_g");

            pNewMat.SetTexture("_MainTex", pBaseMap);
            pNewMat.SetTexture("_NrmTex", pNormalMap);
            pNewMat.SetTexture("_MixTex", pMixMap);
            pNewMat.SetTexture("_GlowTex", pGlowMap);

            Material pOldMat = AssetDatabase.LoadAssetAtPath<Material>(sDesPath + "_Temp/Materials/" + sMatName + ".mat");
            if (pOldMat != null)
            {
                pNewMat.SetColor("_SkinParams", pOldMat.GetColor("_SkinParams"));
                pNewMat.SetColor("_SkinScatter", pOldMat.GetColor("_SkinScatter"));
                pNewMat.SetFloat("_GlowIntensity", pOldMat.GetFloat("_GlowIntensity"));

                pNewMat.SetColor("_FocusColor", pOldMat.GetColor("_FocusColor"));
                pNewMat.SetColor("_Dissolve", pOldMat.GetColor("_Dissolve"));
                pNewMat.SetColor("_DissolveColor", pOldMat.GetColor("_DissolveColor"));
            }
        }
        else if (sMatName.EndsWith("_plain"))
        {
            string sMainName = sMatName.Replace("_plain", "");

            pNewMat = new Material(Shader.Find("Physical Shading/Character/Plain"));
            
            Texture pBaseMap = CopyTexture(pTexList, sDesPath, sMainName + "_b");
            pNewMat.SetTexture("_MainTex", pBaseMap);

            Material pOldMat = AssetDatabase.LoadAssetAtPath<Material>(sDesPath + "_Temp/Materials/" + sMatName + ".mat");
            if (pOldMat != null)
            {
                pNewMat.SetColor("_FocusColor", pOldMat.GetColor("_FocusColor"));
                pNewMat.SetColor("_Dissolve", pOldMat.GetColor("_Dissolve"));
                pNewMat.SetColor("_DissolveColor", pOldMat.GetColor("_DissolveColor"));
            }
        }
        else
        {
            throw new ArgumentNullException(sMatName + " <-- 无效材质名字!");
        }
        
        return pNewMat;
    }

    [UnityEditor.MenuItem("Assets/BuildActor")]
    public static void Build_Actor()
    {
        try
        {
            for (int i = 0; i < Selection.objects.Length; i++)
            {
                string objPath = AssetDatabase.GetAssetPath(Selection.objects[i]);
                if (Path.GetExtension(objPath).ToLower() != ".fbx")
                {
                    continue;
                }
                // FBX文件原始路径
                string sSsourcePath = objPath.Substring(0, objPath.LastIndexOf('/'));

                // 文件名
                string sFileName = Path.GetFileNameWithoutExtension(objPath);
                if (Selection.objects[i] is GameObject)
                {
                    GameObject select = Selection.objects[i] as GameObject;

                    // 类型 Hero/Monster/NPC
                    string sType = objPath.Replace(mSrcPath, "");
                    sType = sType.Substring(0, sType.IndexOf('/'));
                    string sNewPath = "Assets/ResEx/Character/" + sType + "/" + sFileName;

                    ActorDataBackups(sNewPath);

                    GameObject pParentObj = null;
                    if (File.Exists(sNewPath + "_Temp/" + sFileName + ".prefab"))
                    {
                        pParentObj = GameObject.Instantiate(AssetDatabase.LoadAssetAtPath<GameObject>(sNewPath + "_Temp/" + sFileName + ".prefab"));
                        for (int n = 0; n < pParentObj.transform.childCount; ++n)
                        {
                            GameObject.DestroyImmediate(pParentObj.transform.GetChild(n).gameObject);
                        }
                    }
                    else
                    {
                        pParentObj = new GameObject(sFileName);
                        pParentObj.AddComponent<AvatarProperty>();
                        pParentObj.AddComponent<BoxCollider>();
                    }

                    GameObject pBody = GameObject.Instantiate(select);
                    pBody.transform.parent = pParentObj.transform;
                    pBody.name = select.name;

                    // 设置FBX AnimationType
                    ModelImporter tImporter = AssetImporter.GetAtPath(objPath) as ModelImporter;
                    if (tImporter != null)
                    {
                        tImporter.animationType = ModelImporterAnimationType.Legacy;
                        tImporter.SaveAndReimport();
                    }

                    Dictionary<string, Mesh> pMeshMap = new Dictionary<string, Mesh>();
                    Dictionary<string, Material[]> pMaterialMap = new Dictionary<string, Material[]>();
                    Dictionary<string, Material> pMatMap = new Dictionary<string, Material>();

                    // 导出模型 材质
                    SkinnedMeshRenderer[] pSrcSkinMeshList = select.GetComponentsInChildren<SkinnedMeshRenderer>();
                    foreach (SkinnedMeshRenderer pMesh in pSrcSkinMeshList)
                    {
                        Mesh pNewMesh = GameObject.Instantiate(pMesh.sharedMesh);
                        AssetDatabase.CreateAsset(pNewMesh, sNewPath + "/Meshs/" + pMesh.name + ".asset");

                        pMeshMap.Add(pMesh.gameObject.name, pNewMesh);
                        Material[] mats = new Material[pMesh.sharedMaterials.Length];
                        for (int k = 0; k < pMesh.sharedMaterials.Length; ++k)
                        {
                            mats[k] = null;
                            if (!pMatMap.TryGetValue(pMesh.sharedMaterials[k].name, out mats[k]))
                            {
                                mats[k] = CreateMaterials(sSsourcePath, sNewPath, pMesh.sharedMaterials[k]);
                                AssetDatabase.CreateAsset(mats[k], sNewPath + "/Materials/" + pMesh.sharedMaterials[k].name + ".mat");
                                pMatMap.Add(pMesh.sharedMaterials[k].name, mats[k]);
                            }
                        }
                        pMaterialMap.Add(pMesh.gameObject.name, mats);
                    }

                    MeshFilter[] pSrcMeshList = select.GetComponentsInChildren<MeshFilter>();
                    foreach (MeshFilter pMesh in pSrcMeshList)
                    {
                        Mesh pNewMesh = GameObject.Instantiate(pMesh.sharedMesh);
                        AssetDatabase.CreateAsset(pNewMesh, sNewPath + "/Meshs/" + pMesh.name + ".asset");

                        pMeshMap.Add(pMesh.gameObject.name, pNewMesh);

                        Material[] pSrcMat = pMesh.GetComponent<MeshRenderer>().sharedMaterials;
                        Material[] mats = new Material[pSrcMat.Length];
                        for (int k = 0; k < pSrcMat.Length; ++k)
                        {
                            mats[k] = null;
                            if (!pMatMap.TryGetValue(pSrcMat[k].name, out mats[k]))
                            {
                                mats[k] = CreateMaterials(sSsourcePath, sNewPath, pSrcMat[k]);
                                AssetDatabase.CreateAsset(mats[k], sNewPath + "/Materials/" + pSrcMat[k].name + ".mat");
                                pMatMap.Add(pSrcMat[k].name, mats[k]);
                            }
                        }
                        pMaterialMap.Add(pMesh.gameObject.name, mats);
                    }

                    Dictionary<string, AnimationClip> pClipMap = new Dictionary<string, AnimationClip>();
                    // 导出动作
                    //Animation pAnim = select.GetComponent<Animation>();
                    //if (pAnim != null)
                    //{
                    //    foreach (AnimationState state in pAnim)
                    //    {
                    //        AnimationClip clip = UnityEngine.Object.Instantiate(pAnim.GetClip(state.name));
                    //        FixFloatAtClip(clip);

                    //        pClipMap.Add(state.name, clip);
                    //        clip.legacy = true;
                    //        AssetDatabase.CreateAsset(clip, sNewPath + "/Anims/" + state.name + ".anim");
                    //    }
                    //}

                    string[] pAnimFBX = Directory.GetFiles(sSsourcePath, sFileName + "@*.fbx", SearchOption.AllDirectories);
                    for (int n = 0; n < pAnimFBX.Length; ++n)
                    {
                        ModelImporter tSetting = AssetImporter.GetAtPath(pAnimFBX[n]) as ModelImporter;
                        if (tSetting != null)
                        {
                            tSetting.animationType = ModelImporterAnimationType.Legacy;
                            tSetting.SaveAndReimport();
                        }

                        GameObject pAnimObj = AssetDatabase.LoadAssetAtPath<GameObject>(pAnimFBX[n]);
                        if (pAnimObj)
                        {
                            Animation pAnim = pAnimObj.GetComponent<Animation>();
                            if (pAnim != null)
                            {
                                foreach (AnimationState state in pAnim)
                                {
                                    AnimationClip clip = UnityEngine.Object.Instantiate(pAnim.GetClip(state.name));
                                    FixFloatAtClip(clip);

                                    pClipMap.Add(state.name, clip);
                                    clip.legacy = true;
                                    AssetDatabase.CreateAsset(clip, sNewPath + "/Anims/" + state.name + ".anim");
                                }
                            }
                        }
                    }

                    AssetDatabase.Refresh();

                    // 设置新的
                    SkinnedMeshRenderer[] pSkinnedMeshList = pParentObj.GetComponentsInChildren<SkinnedMeshRenderer>();
                    foreach (SkinnedMeshRenderer pMesh in pSkinnedMeshList)
                    {
                        pMesh.sharedMesh = pMeshMap[pMesh.gameObject.name];
                        pMesh.sharedMaterials = pMaterialMap[pMesh.gameObject.name];
                    }

                    MeshFilter[] pMeshList = pParentObj.GetComponentsInChildren<MeshFilter>();
                    foreach (MeshFilter pMesh in pMeshList)
                    {
                        pMesh.sharedMesh = pMeshMap[pMesh.gameObject.name];
                        pMesh.GetComponent<MeshRenderer>().sharedMaterials = pMaterialMap[pMesh.gameObject.name];
                    }

                    Animation pNewAnim = pBody.GetComponent<Animation>();
                    GameObject.DestroyImmediate(pNewAnim, true);

                    pNewAnim = pBody.AddComponent<Animation>();
                    foreach (var clip in pClipMap)
                    {
                        pNewAnim.AddClip(clip.Value, clip.Key);
                    }

                    PrefabUtility.CreatePrefab(sNewPath + "/" + sFileName + ".prefab", pParentObj, ReplacePrefabOptions.ConnectToPrefab);
                    if (Directory.Exists(sNewPath + "_Temp"))
                    {
                        Directory.Delete(sNewPath + "_Temp", true);
                    }
                    GameObject.DestroyImmediate(pParentObj);
                    Debug.Log("Actor " + sFileName + " 完成!!!");
                }
            }
        }
        catch (Exception ex)
        {
            Debug.LogError(ex.Message);
        }
        
        AssetDatabase.Refresh();
    }
}