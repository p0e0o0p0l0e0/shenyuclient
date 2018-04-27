Shader "Fate Shading/Scene/GeneralFog"
{
	Properties
	{
		_Multiplier("HDR Multiplier", Range(0,10)) = 1
		_MainTex ("Base (RGB)", 2D) = "white" {}
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
			#include "General.cginc"
			ENDCG
		}
	}
}
