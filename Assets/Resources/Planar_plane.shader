Shader "Physical Shading/Replace/Planar Plane"
{
	Properties
	{
		_Stencil ("Stencil Reference", Int) = 0
	}

	SubShader
	{
		Tags { "RenderType"="Opaque" "LightMode" = "ForwardBase" }
		LOD 100

		Pass
		{
			Cull Back
			ZTest Always
			ZWrite Off
			ColorMask 0

			Stencil
			{
				Ref [_Stencil]
				Comp Greater
				Pass Replace
				Fail Keep
			}

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "Planar.cginc"
			ENDCG
		}
	}
}
