Shader "Physical Shading/Effect/EdgeAdd"
{
	Properties
	{
		_TintColor("Tint Color", Color) = (1.0,1.0,1.0,1.0)
		_Params("(HDR,LDR,Edge,)", Vector) = (1.0,1.0,1.0,0.0)
	}

	Category
	{
		Tags
		{
			"Queue" = "Transparent"
			"IgnoreProjector" = "True"
			"RenderType" = "Transparent"
		}
		Blend SrcAlpha One
		ColorMask RGB
		Cull Back Lighting Off ZWrite On
	
		SubShader
		{
			Pass
			{
				ZTest Less
		
				CGPROGRAM
				#pragma vertex vert_edge
				#pragma fragment frag_edge
				#pragma multi_compile __ HDR_ON
				#pragma multi_compile __ POSTFX_ON
				#define MIX_ADD
				#include "Effect.cginc"
				ENDCG 
			}
		}	
	}
}
