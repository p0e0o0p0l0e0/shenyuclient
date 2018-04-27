Shader "Physical Shading/Replace/Shadow Agent"
{
	Properties
	{
		[HideInInspector]_ShadowPlane("Shadow Plane", Vector) = (0, 1, 0, -0.5)
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque" "LightMode" = "ForwardBase" }
		LOD 100

		Pass
		{
			Cull Back
			ZTest Always
			ZWrite Off
			ColorMask RGBA

			Stencil
			{
				Ref 128
				Comp NotEqual
				Pass Replace
				Fail Keep
			}

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#define SHADOW
			#include "Planar.cginc"
			ENDCG
		}
	}
}
