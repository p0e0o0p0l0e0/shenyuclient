Shader "Physical Shading/Scene/NoLight"
{
	Properties
	{
		_MainTex("Base Texture", 2D) = "white" {}
		_TintColor("Tint Color", Color) = (1.0,1.0,1.0,1.0)
		_Intensity("Intensity(HDR,LDR,,)", Vector) = (1,1,0,0)
	}

	SubShader
	{
		Tags
		{
			"RenderType" = "Opaque"
			"LightMode" = "ForwardBase"
			"Queue" = "Geometry+1"
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


			#include "ForwardNoLight.cginc"
			ENDCG
		}
	}
}
