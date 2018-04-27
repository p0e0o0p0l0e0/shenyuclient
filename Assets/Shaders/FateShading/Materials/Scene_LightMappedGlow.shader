Shader "Fate Shading/Scene/LightMappedGlow"
{
	Properties
	{
		_Color("Main Color", Color) = (1,1,1,1)
		_Multiplier("HDR Multiplier", Range(0,10)) = 1
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_GlowTex("Glow (RGB)", 2D) = "black" {}
		_GlowMultiplier("Glow Multiplier", Range(0,10)) = 1

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
			#define USE_DEPTH
			#define USE_GLOW
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
			#define USE_LIGHTMAP
			#define USE_DEPTH
			#define USE_GLOW
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
			#define USE_LIGHTMAP
			#define USE_DEPTH
			#define USE_GLOW
			#include "LightMapped.cginc"
			ENDCG
		}
	}

	CustomEditor "VFXShaderInspector"
}
