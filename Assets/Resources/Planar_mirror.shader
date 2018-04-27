Shader "Physical Shading/Replace/Mirror Agent"
{
	Properties
	{
		_MainTex("Base (RGB)", 2D) = "white" {}
		[HideInInspector]_Stencil("Stencil Reference", Int) = 0
		[HideInInspector]_MirrorPlane("Mirror Plane", Vector) = (0, 1, 0, 0)
		[HideInInspector]_MirrorParams("Mirror Params", Vector) = (0.7, 0.5, 0, 0)
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque" "LightMode" = "ForwardBase" }
		LOD 100

		Pass
		{
			Cull Front
			ZTest Less
			ZWrite On
			ColorMask RGB

			Stencil
			{
				Ref [_Stencil]
				Comp Equal
				Pass Keep
				Fail Keep
			}

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#define MIRROR
			#include "Planar.cginc"
			ENDCG
		}
	}
}
