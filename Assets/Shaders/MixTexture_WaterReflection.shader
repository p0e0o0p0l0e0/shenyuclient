Shader "Fate Shading/MixTexture_WaterReflection"
{
	Properties
	{
		_ChannelTexture ("ChannelTexture", 2D) = "black" {}
		_ChannelR ("ChannelR", 2D) = "black" {}
		_ChannelG ("ChannelG", 2D) = "black" {}
		_ChannelB ("ChannelB", 2D) = "black" {}
		_ChannelA ("ChannelA", 2D) = "black" {}
		_Weight ("Blend Weight", Range(0.001,1)) = 0.2

		_MirrorColor("Mirror Color", Color) = (1,1,1,1)
		_ShadowColor("Shadow Color", Color) = (1,1,1,1)

		_WaterColor("WaterColor", Color) = (1,1,1,1)
		_WaterParam("WaterParam", Vector) = (1,1,0.5,0.2)

		_RenderQueue ("RenderQueue", Float) = 2000
	}

	CGINCLUDE
		#define USE_SHADOW
		#define USE_DEPTH
	ENDCG

	SubShader
		{
			Tags { "RenderType"="Opaque" }
			LOD 100

			Pass
			{
				Tags{ "LightMode" = "Vertex" }

				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#pragma multi_compile __ BLEND_ON
				#pragma multi_compile __ USE_FOG
				#pragma multi_compile __ ENABLE_SHADOW
				#pragma multi_compile __ ENABLE_MIRROR
				#pragma multi_compile __ CLOUD_SHADOW
				#define USE_SHADOW_MIRROR
				#define USE_WATER_REFLECTION
				#include "MixTextureInclude.cginc"
				ENDCG
			}

			Pass
			{
				Tags{ "LightMode" = "VertexLM" }

				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#pragma multi_compile __ BLEND_ON
				#pragma multi_compile __ USE_FOG
				#pragma multi_compile __ ENABLE_SHADOW
				#pragma multi_compile __ ENABLE_MIRROR
				#pragma multi_compile __ CLOUD_SHADOW
				#define USE_SHADOW_MIRROR
				#define USE_WATER_REFLECTION
				#include "MixTextureInclude.cginc"
				ENDCG
			}

			Pass
			{
				Tags{ "LightMode" = "VertexLMRGBM" }

				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#pragma multi_compile __ BLEND_ON
				#pragma multi_compile __ USE_FOG
				#pragma multi_compile __ ENABLE_SHADOW
				#pragma multi_compile __ ENABLE_MIRROR
				#pragma multi_compile __ CLOUD_SHADOW
				#define USE_SHADOW_MIRROR
				#define USE_WATER_REFLECTION
				#include "MixTextureInclude.cginc"
				ENDCG
			}
	}

	CustomEditor "VFXShaderInspector"
}
