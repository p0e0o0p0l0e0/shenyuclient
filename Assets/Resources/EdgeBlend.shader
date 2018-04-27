Shader "Physical Shading/Effect/EdgeBlend"
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
		Blend SrcAlpha OneMinusSrcAlpha
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
				#include "Effect.cginc"
				ENDCG 
			}
		}	
	}
}
