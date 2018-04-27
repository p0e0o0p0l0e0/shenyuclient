Shader "Fate Shading/Scene/LightMapped"
{
	Properties
	{
		_Color("Main Color", Color) = (1,1,1,1)
		_Multiplier("HDR Multiplier", Range(0,10)) = 1
		_MainTex ("Base (RGB)", 2D) = "white" {}

		_RenderQueue ("RenderQueue", Float) = 2000
	}

	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100

		Pass
		{
			Tags{ "LightMode" = "Vertex" }

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			//#pragma exclude_renderers d3d9 d3d11_9x
			//#pragma multi_compile HDR_OFF HDR_ON
			#pragma multi_compile __ USE_FOG
			#pragma multi_compile __ CLOUD_SHADOW
			#define USE_DEPTH
			#include "LightMapped.cginc"
			ENDCG
		}

		Pass
		{
			Tags{ "LightMode" = "VertexLM" }

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			//#pragma exclude_renderers d3d9 d3d11_9x
			//#pragma multi_compile HDR_OFF HDR_ON
			#pragma multi_compile __ USE_FOG
			#pragma multi_compile __ CLOUD_SHADOW
			#define USE_LIGHTMAP
			#define USE_DEPTH
			#include "LightMapped.cginc"
			ENDCG
		}

		Pass
		{
			Tags{ "LightMode" = "VertexLMRGBM" }

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			//#pragma exclude_renderers d3d9 d3d11_9x
			//#pragma multi_compile HDR_OFF HDR_ON
			#pragma multi_compile __ USE_FOG
			#pragma multi_compile __ CLOUD_SHADOW
			#define USE_LIGHTMAP
			#define USE_DEPTH
			#include "LightMapped.cginc"
			ENDCG
		}
	}

	CustomEditor "VFXShaderInspector"
}
