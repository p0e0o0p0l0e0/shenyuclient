using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace PhysicalShading
{
    [RequireComponent(typeof(Camera))]
    [DisallowMultipleComponent]
    [AddComponentMenu("Physical Shading/Render Pipeline")]
    [ExecuteInEditMode]
    public class RenderPipeline : MonoBehaviour
    {
		public enum Quality
        {
            Low = 0,
            Mid = 1,
            High = 2
        }

        public enum FrameRate
        {
            FPS_30 = 30,
            FPS_60 = 60
        }

		public enum MSAA
		{
			MSAA_NONE = 1,
			MSAA_2X = 2,
			MSAA_4X = 4,
			MSAA_8X = 8
		}

		public enum SpecialLayer
		{
			LAYER_REF_PLANE = 30
        }

        public FrameRate framerate = FrameRate.FPS_60;

        public bool postFX = true;
        public Quality resolution = Quality.High;
		public MSAA msaa = MSAA.MSAA_8X;
		public bool fxaa = false;
#if UNITY_STANDALONE
		public bool ssaa = true;
#endif
        
        public bool enableHDR = true;
		public bool enableBloom = true;
		public bool highQuality = true;

		public bool enablePlanarFX = true;
		public MSAA msaaPlanarRT = MSAA.MSAA_8X;
		public bool blurPlanarFX = false;

		private enum BloomPass
		{
			BLOOM_SETUP = 0,
			BLOOM_DOWN_0 = 1,
			BLOOM_DOWN_1 = 2,
			BLOOM_DOWN_2 = 3,
			BLOOM_UP_0 = 4,
			BLOOM_UP_1 = 5,
			BLOOM_MERGE = 6,
		}

        static private Shader bloom = null;
        static private Shader finalMerge = null;
        static private Shader planarShadowShader = null;
        static private Shader planarPlaneShader = null;
        static private Shader planarMirrorShader = null;
        static private Shader planarBlurShader = null;

        private Material bloomMat = null;
        private Material finalMergeMat = null;
        private Material planarBlurMat = null;

        private int currentWidth = 0;
        private int currentHeight = 0;

        private RenderTexture sceneRT = null;
        private RenderTexture sceneRT_div2 = null;
        private RenderTexture bloomSetup = null;
		private RenderTexture bloomDown0 = null;
		private RenderTexture bloomDown1 = null;
		private RenderTexture bloomDown2 = null;
		private RenderTexture bloomUp0 = null;
		private RenderTexture bloomUp1 = null;

		private RenderTexture mirrorShadowRT = null;
		private RenderTexture mirrorShadowBlurRT = null;

		private Camera mainCamera = null;
		private Camera displayCamera = null;
		private Camera mirrorShadowCamera = null;

        private CommandBuffer grabPass = null;
        private CommandBuffer mirrorAgents = null;
        private CommandBuffer shadowAgents = null;

		private Vector4 fogParams = new Vector4(0, 0, 0, 0);
		private static RenderPipeline singleton = null;
        private static bool enableFog = false;
		private static float fogHeight = 0;
		private static float fogDensity = 0;
		private static float fogHeightFalloff = 0;
        private static float fogStartDistance = 0;

        public static Shader PlanarShadowShader()
        {
            if (planarShadowShader == null) planarShadowShader = Resources.Load<Shader>("Planar_shadow");
            return planarShadowShader;
        }

        public static Shader PlanarPlaneShader()
        {
            if (planarPlaneShader == null) planarPlaneShader = Resources.Load<Shader>("Planar_plane");
            return planarPlaneShader;
        }

        public static Shader PlanarMirrorShader()
        {
            if (planarMirrorShader == null) planarMirrorShader = Resources.Load<Shader>("Planar_mirror");
            return planarMirrorShader;
        }

        public static void RenderMirror(Mesh mesh, Matrix4x4 trans, Material mat, int submeshIndex)
		{
			if (!singleton) return;
			singleton.mirrorAgents.DrawMesh(mesh, trans, mat, submeshIndex);
		}

        public static void RenderShadow(ref List<Renderer> renderers, Material mat)
        {
            if (singleton == null) return;
            foreach (Renderer render in renderers)
            {
                singleton.shadowAgents.DrawRenderer(render, mat);
            }
        }

        public static void SetFogEnable(bool bEnable)
        {
            enableFog = bEnable;
        }

		public static void SetFogParams(float height, float density, float heightFalloff, float startDistance)
		{
			fogHeight = height;
			fogDensity = density;
			fogHeightFalloff = heightFalloff;
            fogStartDistance = startDistance;
        }

        private static Camera _DefaultParams(Camera cam)
		{
			cam.renderingPath = RenderingPath.Forward;
			cam.targetTexture = null;
			cam.useOcclusionCulling = false;
			cam.allowHDR = false;
			cam.allowMSAA = false;
			return cam;
		}

        private static Camera _CreatTemperalCamera(string name)
        {
            GameObject cameraObj = new GameObject(name);
            cameraObj.hideFlags = HideFlags.HideAndDontSave;
            Camera cam = cameraObj.AddComponent<Camera>();
			return _DefaultParams(cam);
		}

		private static void _UpdateCameraModes(Camera src, Camera dest)
        {
            dest.farClipPlane = src.farClipPlane;
            dest.nearClipPlane = src.nearClipPlane;
            dest.orthographic = src.orthographic;
            dest.fieldOfView = src.fieldOfView;
            dest.aspect = src.aspect;
            dest.orthographicSize = src.orthographicSize;
            dest.renderingPath = src.renderingPath;
        }

		private static void _UpdateRenderTexture(
			ref RenderTexture rt, int w, int h, int d = 0,
			RenderTextureFormat fmt = RenderTextureFormat.ARGB32,
			MSAA msaa = MSAA.MSAA_NONE)
		{
			if(rt)
			{
				if(rt.width == w && rt.height == h
					&& rt.depth == d && rt.format == fmt)
				{
					if (rt.antiAliasing != (int)msaa)
						rt.antiAliasing = (int)msaa;
					return;
				}
				else
				{
					rt.Release();
				}
			}
			rt = new RenderTexture(w, h, d, fmt);
			rt.filterMode = FilterMode.Bilinear;
			rt.wrapMode = TextureWrapMode.Clamp;
			rt.antiAliasing = (int)msaa;
		}

		private static void _ReleaseRenderTexture(
			ref RenderTexture rt)
		{
			if(rt)
			{
				rt.Release();
				rt = null;
			}
		}

		private void Awake()
        {
            if (bloom == null) bloom = Resources.Load<Shader>("Bloom");
            if (finalMerge == null) finalMerge = Resources.Load<Shader>("FinalMerge");
            if (planarShadowShader == null) planarShadowShader = Resources.Load<Shader>("Planar_shadow");
            if (planarPlaneShader == null) planarPlaneShader = Resources.Load<Shader>("Planar_plane");
            if (planarMirrorShader == null) planarMirrorShader = Resources.Load<Shader>("Planar_mirror");
            if (planarBlurShader == null) planarBlurShader = Resources.Load<Shader>("Planar_blur");
            if (bloom == null || finalMerge == null || planarShadowShader == null
                || planarPlaneShader == null || planarMirrorShader == null
                || planarBlurShader == null)
            {
                Debug.LogError("[RenderPipline] is not completed");
                Destroy(this);
            }
			bloomMat = new Material(bloom);
			finalMergeMat = new Material(finalMerge);
			planarBlurMat = new Material(planarBlurShader);
            _Refresh();
			singleton = this;
		}

        private void OnValidate()
        {
            _Refresh();
        }

        public void _Refresh()
        {
			currentWidth = Screen.width;
            currentHeight = Screen.height;
            int width, height;
            {
                float s = 1.0f;
#if UNITY_STANDALONE
				if(ssaa) s *= 2.0f;
#endif
                if (resolution == Quality.Low) s *= 0.5f;
                else if (resolution == Quality.Mid) s *= 0.75f;
                width = (int)((float)currentWidth * s);
                height = (int)((float)currentHeight * s);
				width = width > 64 ? width : 64;
				height = height > 64 ? height : 64;
			}

            Application.targetFrameRate = (int)framerate;

			if (!mainCamera)
			{
                mainCamera = _DefaultParams(GetComponent<Camera>());
            }
            mainCamera.cullingMask = mainCamera.cullingMask & (~(1 << (int)SpecialLayer.LAYER_REF_PLANE));

            if (!displayCamera)
			{
				GameObject obj = GameObject.Find("Display Camera");
				if (obj) displayCamera = obj.GetComponent<Camera>();
			}
			if (!displayCamera)
			{
				displayCamera = _CreatTemperalCamera("Display Camera");
			}
            displayCamera.cullingMask = 0;
            displayCamera.clearFlags = CameraClearFlags.SolidColor;
            displayCamera.depth = mainCamera.depth + 1;
            Display dispComponent = displayCamera.gameObject.GetComponent<Display>();
            if (dispComponent == null)
            {
                displayCamera.gameObject.AddComponent<Display>();
            }

            if (!mirrorShadowCamera)
			{
				GameObject obj = GameObject.Find("Planar Camera");
				if (obj) mirrorShadowCamera = obj.GetComponent<Camera>();
			}
			if (!mirrorShadowCamera)
			{
				mirrorShadowCamera = _CreatTemperalCamera("Planar Camera");
			}
            mirrorShadowCamera.enabled = false;
            mirrorShadowCamera.clearFlags = CameraClearFlags.SolidColor;
            mirrorShadowCamera.backgroundColor = new Color(0, 0, 0, 1);
            _UpdateCameraModes(mainCamera, mirrorShadowCamera);
            mirrorShadowCamera.cullingMask = (1 << (int)SpecialLayer.LAYER_REF_PLANE);

            if (mirrorAgents == null)
			{
                mirrorAgents = new CommandBuffer();
                mirrorAgents.name = "Mirror Agents";
			}

            if (shadowAgents == null)
            {
                shadowAgents = new CommandBuffer();
                shadowAgents.name = "Shadow Agents";
            }

            mirrorAgents.Clear();
            shadowAgents.Clear();

            if (postFX)
            {
                Shader.EnableKeyword("POSTFX_ON");

                RenderTextureFormat mainFormat;
                RenderTextureFormat bloomFormat;
                if (msaa == MSAA.MSAA_NONE)
                {
                    Shader.DisableKeyword("MSAA_ON");
                }
                else
                {
                    Shader.EnableKeyword("MSAA_ON");
                }
                if (enableHDR)
                {
                    Shader.EnableKeyword("HDR_ON");
					mainFormat = RenderTextureFormat.ARGBHalf;
					if(highQuality) bloomFormat = RenderTextureFormat.ARGBHalf;
					else bloomFormat = RenderTextureFormat.ARGB32;
				}
                else
                {
                    Shader.DisableKeyword("HDR_ON");
					mainFormat = RenderTextureFormat.ARGB32;
					bloomFormat = RenderTextureFormat.ARGB32;
				}

				_UpdateRenderTexture(ref sceneRT, width, height, 24, mainFormat, msaa);
                Shader.SetGlobalTexture("sceneRT", sceneRT);
                _UpdateRenderTexture(ref sceneRT_div2, width >> 1, height >> 1, 0, mainFormat);
                Shader.SetGlobalTexture("sceneRT_div2", sceneRT_div2);

                if (enableBloom || enableHDR)
				{
					Shader.EnableKeyword("BLOOM_ON");
					if (highQuality) Shader.EnableKeyword("HQ_BLOOM");
					else Shader.DisableKeyword("HQ_BLOOM");
					_UpdateRenderTexture(ref bloomSetup, width >> 2, height >> 2, 0, bloomFormat);
					Shader.SetGlobalTexture("bloomSetup", bloomSetup);
					_UpdateRenderTexture(ref bloomDown0, width >> 3, height >> 3, 0, bloomFormat);
					Shader.SetGlobalTexture("bloomDown0", bloomDown0);
					if (highQuality)
					{
						_UpdateRenderTexture(ref bloomDown1, width >> 4, height >> 4, 0, bloomFormat);
						Shader.SetGlobalTexture("bloomDown1", bloomDown1);
						_UpdateRenderTexture(ref bloomDown2, width >> 5, height >> 5, 0, bloomFormat);
						Shader.SetGlobalTexture("bloomDown2", bloomDown2);

						_UpdateRenderTexture(ref bloomUp0, width >> 4, height >> 4, 0, bloomFormat);
						Shader.SetGlobalTexture("bloomUp0", bloomUp0);
						_UpdateRenderTexture(ref bloomUp1, width >> 3, height >> 3, 0, bloomFormat);
						Shader.SetGlobalTexture("bloomUp1", bloomUp1);
					}
				}
				else
				{
					Shader.DisableKeyword("BLOOM_ON");
				}

				mainCamera.targetTexture = sceneRT;
                if (grabPass == null)
                {
                    grabPass = new CommandBuffer();
                    grabPass.name = "Grab Screen";
                }
                grabPass.Clear();
                grabPass.Blit(BuiltinRenderTextureType.CurrentActive, sceneRT_div2);
                mainCamera.RemoveAllCommandBuffers();
                mainCamera.AddCommandBuffer(CameraEvent.AfterSkybox, grabPass);

                Display disp = displayCamera.GetComponent<Display>();
                disp.blitMaterial = finalMergeMat;
                displayCamera.enabled = true;
            }
            else
            {
                Shader.DisableKeyword("POSTFX_ON");
                Shader.DisableKeyword("MSAA_ON");
                Shader.DisableKeyword("HDR_ON");
				Shader.DisableKeyword("BLOOM_ON");
				Shader.DisableKeyword("HQ_BLOOM");

				Shader.SetGlobalTexture("sceneRT", null);
				_ReleaseRenderTexture(ref sceneRT);
                Shader.SetGlobalTexture("sceneRT_div2", null);
                _ReleaseRenderTexture(ref sceneRT_div2);
                Shader.SetGlobalTexture("bloomSetup", null);
				_ReleaseRenderTexture(ref bloomSetup);
				Shader.SetGlobalTexture("bloomDown0", null);
				_ReleaseRenderTexture(ref bloomDown0);
				Shader.SetGlobalTexture("bloomDown1", null);
				_ReleaseRenderTexture(ref bloomDown1);
				Shader.SetGlobalTexture("bloomDown2", null);
				_ReleaseRenderTexture(ref bloomDown2);
				Shader.SetGlobalTexture("bloomUp0", null);
				_ReleaseRenderTexture(ref bloomUp0);
				Shader.SetGlobalTexture("bloomUp1", null);
				_ReleaseRenderTexture(ref bloomUp1);

				mainCamera.targetTexture = null;
                mainCamera.RemoveAllCommandBuffers();
                Display disp = displayCamera.GetComponent<Display>();
                disp.blitMaterial = null;
                displayCamera.enabled = false;
			}

			if (enablePlanarFX)
			{
				Shader.EnableKeyword("PLANAR_ON");
				_UpdateRenderTexture(ref mirrorShadowRT, width >> 2, height >> 2, 24, RenderTextureFormat.ARGB32, msaaPlanarRT);
				mirrorShadowCamera.targetTexture = mirrorShadowRT;
				if (blurPlanarFX)
				{
					_UpdateRenderTexture(ref mirrorShadowBlurRT, width >> 2, height >> 2, 0, RenderTextureFormat.ARGB32);
					Shader.SetGlobalTexture("mirrorShadowRT", mirrorShadowBlurRT);
					Shader.SetGlobalTexture("mirrorShadowRES", mirrorShadowRT);
				}
				else
				{
					Shader.SetGlobalTexture("mirrorShadowRT", mirrorShadowRT);
					Shader.SetGlobalTexture("mirrorShadowRES", mirrorShadowRT);
				}
				mirrorShadowCamera.RemoveAllCommandBuffers();
				mirrorShadowCamera.AddCommandBuffer(CameraEvent.AfterEverything, mirrorAgents);
                mirrorShadowCamera.AddCommandBuffer(CameraEvent.AfterEverything, shadowAgents);
            }
			else
			{
				Shader.DisableKeyword("PLANAR_ON");
				mirrorShadowCamera.targetTexture = null;
				Shader.SetGlobalTexture("mirrorShadowRT", null);
				Shader.SetGlobalTexture("mirrorShadowRES", null);
				_ReleaseRenderTexture(ref mirrorShadowBlurRT);
				_ReleaseRenderTexture(ref mirrorShadowRT);
			}
		}

		private void _UpdateFogParams()
		{
            fogParams.x = fogDensity * (float)Math.Pow(2.0, -fogHeightFalloff * (mainCamera.transform.position.y * 100.0f - fogHeight));
            fogParams.y = fogHeightFalloff;
            fogParams.z = 0;
            fogParams.w = fogStartDistance;
            Shader.SetGlobalVector("_FogParams", fogParams);
        }

        private void OnPreRender()
        {
			if (enablePlanarFX && mirrorShadowCamera)
			{
                mirrorShadowCamera.worldToCameraMatrix = mainCamera.worldToCameraMatrix;
				mirrorShadowCamera.projectionMatrix = mainCamera.projectionMatrix;
				mirrorShadowCamera.transform.position = mainCamera.transform.position;
				mirrorShadowCamera.transform.eulerAngles = mainCamera.transform.eulerAngles;
				mirrorShadowCamera.Render();
                mirrorAgents.Clear();
                shadowAgents.Clear();

                if (blurPlanarFX)
				{
					Graphics.SetRenderTarget(mirrorShadowBlurRT);
					GL.Clear(false, true, Color.black);
					Graphics.Blit(null, planarBlurMat);
				}
			}

            if (sceneRT_div2)
            {
                sceneRT_div2.DiscardContents();
            }
        }

        private void OnPostRender()
        {
			if (postFX)
			{
				if (enableHDR || enableBloom)
				{
					Graphics.SetRenderTarget(bloomSetup);
					GL.Clear(false, true, Color.black);
					Graphics.Blit(null, bloomMat, (int)BloomPass.BLOOM_SETUP);

					Graphics.SetRenderTarget(bloomDown0);
					GL.Clear(false, true, Color.black);
					Graphics.Blit(null, bloomMat, (int)BloomPass.BLOOM_DOWN_0);

					if(highQuality)
					{
						Graphics.SetRenderTarget(bloomDown1);
						GL.Clear(false, true, Color.black);
						Graphics.Blit(null, bloomMat, (int)BloomPass.BLOOM_DOWN_1);

						Graphics.SetRenderTarget(bloomDown2);
						GL.Clear(false, true, Color.black);
						Graphics.Blit(null, bloomMat, (int)BloomPass.BLOOM_DOWN_2);

						Graphics.SetRenderTarget(bloomUp0);
						GL.Clear(false, true, Color.black);
						Graphics.Blit(null, bloomMat, (int)BloomPass.BLOOM_UP_0);

						Graphics.SetRenderTarget(bloomUp1);
						GL.Clear(false, true, Color.black);
						Graphics.Blit(null, bloomMat, (int)BloomPass.BLOOM_UP_1);
					}

					Graphics.SetRenderTarget(bloomSetup);
					GL.Clear(false, true, Color.black);
					Graphics.Blit(null, bloomMat, (int)BloomPass.BLOOM_MERGE);
				}
			}
		}

        private void OnGUI()
        {
			string info = "FPS: " + _FPSValue.ToString("00");
			if (!SystemInfo.supports3DTextures)
			{
				info += "\nNo 3D Texture";
			}
			if (SystemInfo.graphicsDeviceType == GraphicsDeviceType.OpenGLES2)
			{
				info += "\nLow API";
			}
			GUI.Box(new Rect(10, 10, 100, 90), info);
        }
        float _FPSValue;
        float _FPSUpdateTime;

		private void Update()
		{
            if (currentWidth != Screen.width || currentHeight != Screen.height)
			{
				_Refresh();
            }
           
            if (enableFog)
            {
                _UpdateFogParams();
            }
			if (Time.time >= _FPSUpdateTime)
			{
				_FPSValue = 1.0f / Time.deltaTime;
				_FPSUpdateTime = Time.time + 0.33f;
			}
		}
	}
}
