Shader "Fate Shading/Scene/Floor_WaterRelfection"
{
	Properties
	{
		_Color("Main Color", Color) = (1,1,1,1)
		_MirrorColor("Mirror Color", Color) = (1,1,1,1)
		_ShadowColor("Shadow Color", Color) = (1,1,1,1)
		_Multiplier("HDR Multiplier", Range(0,10)) = 1
		_MainTex ("Base (RGBA)", 2D) = "white" {}

		_WaterMaskTex ("WaterMaskTex", 2D) = "white" {}
		_WaterColor("WaterColor", Color) = (1,1,1,1)
		_WaterParam("WaterParam", Vector) = (1,1,0.5,0.2)

		_RenderQueue ("RenderQueue", Float) = 3000
	}

	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100
		//Blend SrcAlpha OneMinusSrcAlpha
		Pass
		{
			Tags{ "LightMode" = "Vertex" }

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile __ ENABLE_SHADOW
			#pragma multi_compile __ ENABLE_MIRROR
			#pragma multi_compile __ USE_FOG
			#pragma multi_compile __ CLOUD_SHADOW
			#define USE_SHADOW_MIRROR
			#define USE_WATER_REFLECTION
			#define USE_LIGHTMAP
			#include "LightMapped.cginc"
			ENDCG
		}

		Pass
		{
			Tags{ "LightMode" = "VertexLM" }

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile __ ENABLE_SHADOW
			#pragma multi_compile __ ENABLE_MIRROR
			#pragma multi_compile __ USE_FOG
			#pragma multi_compile __ CLOUD_SHADOW
			#define USE_SHADOW_MIRROR
			#define USE_WATER_REFLECTION
			#define USE_LIGHTMAP
			#include "LightMapped.cginc"
			ENDCG
		}

		Pass
		{
			Tags{ "LightMode" = "VertexLMRGBM" }

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile __ ENABLE_SHADOW
			#pragma multi_compile __ ENABLE_MIRROR
			#pragma multi_compile __ USE_FOG
			#pragma multi_compile __ CLOUD_SHADOW
			#define USE_SHADOW_MIRROR
			#define USE_WATER_REFLECTION
			#define USE_LIGHTMAP
			#include "LightMapped.cginc"
			ENDCG
		}
	}

	CustomEditor "VFXShaderInspector"
}
