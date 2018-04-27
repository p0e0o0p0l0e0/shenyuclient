Shader "Fate Shading/Character/Character_NormalAlphaBlend"
{
	Properties
	{
		_MainTex ("Base Texture", 2D) = "white" {}
		_MatTex ("Material Texture", 2D) = "white" {}
		_DiffuseRampTex ("Diffuse Ramp Texture", 2D) = "white" {}
		_SpecRampTex ("Spec Ramp Texture", 2D) = "white" {}
		_OutlineWidth ("OutlineWidth", Float) = 0.005
		_EdgeColor ("Edge Light Color", Vector) = (1, 1, 1, 1)
		_LightParams("LR(diff_mul,spec_mul,spec_pwr,emi_mul)", Vector) = (1, 0.6, 8.0, 1.0)
		_LightParamsHDR("HDR(diff_mul,spec_mul,spec_pwr,emi_mul)", Vector) = (1, 0.6, 8.0, 1.0)

		_Emission ("Emission", Color) = (0,0,0,0)
		_TintColor ("Tint Color", Color) = (0.5,0.5,0.5,1.0)
	}

	CGINCLUDE
		#define USE_ALPHA
	ENDCG

	SubShader
	{
		Tags { "Queue"="Transparent" "LightMode" = "ForwardBase" "RenderType"="Transparent" }
		Blend SrcAlpha OneMinusSrcAlpha
		LOD 100

		Pass
		{
			ColorMask 0
		}

		Pass
		{
			Cull Back
			ZTest Less
			ZWrite On
			Offset -0.1, 0

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile __ USE_FOG
			#include "Character.cginc"
			ENDCG
		}

		Pass
		{
			Cull Front
			ZTest Less
			ZWrite On

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile __ USE_FOG
			#include "Outline.cginc"
			ENDCG
		}
	}
}
