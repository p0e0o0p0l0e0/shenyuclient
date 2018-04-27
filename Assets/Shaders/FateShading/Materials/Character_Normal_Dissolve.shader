Shader "Fate Shading/Character/Normal_Dissolve"
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
		//
		_Duration ("Duration", Float) = 5
		_DissolveSrc ("DissolveSrc", 2D) = "white" {}
		//
		_StartHeight ("StartHeight", FLOAT) = 0
		_GlowColor ("GlowColor", COLOR) = (1,1,1,1)
		_GlowRange ("GlowRange", FLOAT) = 0.01
		_HeightDelta ("HeightDelta", FLOAT) = 0.01

		_Emission ("Emission", Color) = (0,0,0,0)
	}

	SubShader
	{
		Tags {"Queue" = "Geometry+1" "LightMode" = "ForwardBase" }
		LOD 100
		Blend SrcAlpha OneMinusSrcAlpha

		Pass
		{
			Cull Back
			ZTest Less
			ZWrite On

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			//#pragma exclude_renderers d3d9 d3d11_9x
			//#pragma multi_compile __ HDR_ON
			#pragma multi_compile DISSOLVE_OFF RANDOM_DISSOLVE_ON VERTICAL_DISSOLVE_ON
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
			//#pragma exclude_renderers d3d9 d3d11_9x
			//#pragma multi_compile __ HDR_ON
			#pragma multi_compile DISSOLVE_OFF RANDOM_DISSOLVE_ON VERTICAL_DISSOLVE_ON
			#include "Outline.cginc"
			ENDCG
		}
	}
}
