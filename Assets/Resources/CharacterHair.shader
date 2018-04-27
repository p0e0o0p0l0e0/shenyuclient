Shader "Physical Shading/Character/Hair"
{
	Properties
	{
		_MainTex("Base Map", 2D) = "white" {}
		_NrmTex("Normal Map", 2D) = "white" {}
		_MixTex("Mix Map", 2D) = "white" {}

		_PrimaryColor("Primary Color", Color) = (1.0, 1.0, 1.0, 1.0)
		_PrimaryParams("Primary(pow,bias,scale,)", Vector) = (200.0, -1.0, 0.5, 0.0)
		_SecondaryColor("Secondary Color", Color) = (0.3, 0.3, 0.3, 1.0)
		_SecondaryParams("Secondary(pow,bias,scale,)", Vector) = (150.0, -1.5, 0.5, 0.0)

		_FocusColor("Focus Color", Vector) = (0.0, 0.0, 0.0, 0.0)
		_Dissolve("(Density,Threshold,Edge,A2C)", Vector) = (10.0, 0.5, 0.1, 0.1)
		_DissolveColor("Dissolve Color", Vector) = (0.0, 1.0, 0.0, 0.0)
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque" "LightMode" = "ForwardBase" }
		LOD 100

		Pass
		{
			Cull Back
			ZTest Less
			ZWrite On
			AlphaToMask On

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag_hair
			#pragma multi_compile __ POSTFX_ON
			#pragma multi_compile __ HDR_ON
			#pragma multi_compile __ FOG_ON
			#pragma multi_compile __ SUNLIGHT_ON
			#pragma multi_compile __ USE_DISSOLVE
			#define USE_NORMAL_MAP
			#define USE_HAIR
			#define USE_FOCUS
			#define USE_ROLE
			#include "ForwardBasePass.cginc"
			ENDCG
		}
	}
}
