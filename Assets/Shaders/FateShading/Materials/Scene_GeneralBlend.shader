Shader "Fate Shading/Scene/GeneralBlend"
{
	Properties
	{
		_Multiplier("HDR Multiplier", Range(0,10)) = 1
		_MainTex ("Base (RGB)", 2D) = "white" {}

		_RenderQueue ("RenderQueue", Float) = 3000
	}

	SubShader
	{
		Tags { "RenderType" = "Opaque" "Queue" = "Transparent" }
		LOD 100

		Pass
		{
			ZWrite Off
			Blend SrcAlpha OneMinusSrcAlpha

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			//#pragma exclude_renderers d3d9 d3d11_9x
			//#pragma multi_compile HDR_OFF HDR_ON
			#pragma multi_compile __ USE_FOG
			#include "General.cginc"
			ENDCG
		}
	}

	CustomEditor "VFXShaderInspector"
}
