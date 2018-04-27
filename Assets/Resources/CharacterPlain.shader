Shader "Physical Shading/Character/Plain"
{
	Properties
	{
		_MainTex("Base Map", 2D) = "white" {}

		_FocusColor("Focus Color", Vector) = (0.0, 0.0, 0.0, 0.0)
		_Dissolve("Dissolve(Density,Threshold,Edge,)", Vector) = (10.0, 0.5, 0.1, 0.0)
		_DissolveColor("Dissolve Color", Vector) = (0.0, 1.0, 0.0, 0.0)
	}

	SubShader
	{
		Tags
		{
			"RenderType" = "Opaque"
			"LightMode" = "ForwardBase"
			"Queue" = "Geometry"
		}
		LOD 100

		Pass
		{
			Cull Back
			ZTest Less
			ZWrite On

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile __ POSTFX_ON
			#pragma multi_compile __ HDR_ON
			#pragma multi_compile __ FOG_ON
			#pragma multi_compile __ SUNLIGHT_ON
			#pragma multi_compile __ USE_DISSOLVE
			#define USE_FOCUS
			#define USE_ROLE
			#include "ForwardBasePass.cginc"
			ENDCG
		}
	}
}
