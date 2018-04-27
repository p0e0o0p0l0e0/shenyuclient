Shader "Fate Shading/Character/NormalGlow"
{
	Properties
	{
		_MainTex ("Base Texture", 2D) = "white" {}
		_MatTex ("Material Texture", 2D) = "white" {}
		_GlowTex("Glow Texture", 2D) = "black" {}
		_DiffuseRampTex ("Diffuse Ramp Texture", 2D) = "white" {}
		_SpecRampTex ("Spec Ramp Texture", 2D) = "white" {}
		_OutlineWidth ("OutlineWidth", Float) = 0.005
		_EdgeColor ("Edge Light Color", Vector) = (1, 1, 1, 1)
		_LightParams("LR(diff_mul,spec_mul,spec_pwr,emi_mul)", Vector) = (1, 0.6, 8.0, 1.0)
		_LightParamsHDR("HDR(diff_mul,spec_mul,spec_pwr,emi_mul)", Vector) = (1, 0.6, 8.0, 1.0)

		_Emission ("Emission", Color) = (0,0,0,0)
	}

	CGINCLUDE
		#define USE_DEPTH
		#define USE_GLOW
	ENDCG

	SubShader
	{
		Tags {"Queue" = "Geometry+1" "RenderType"="Opaque" "LightMode" = "ForwardBase" }
		LOD 100

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
			#include "Outline.cginc"
			ENDCG
		}
	}
}
