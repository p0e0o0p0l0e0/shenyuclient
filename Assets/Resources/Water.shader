Shader "Physical Shading/Effect/Water"
{
	Properties
	{
		_SmallWaveMap("Small Wave Texture", 2D) = "bump" {}
		_SmallWaveTiling("Small Wave Tiling", Vector) = (0.05 ,0.05, 0.07, 0.08)
		_SmallWaveDirection("Small Wave Direction", Vector) = (10, 10, -10, 10)
		_LargeWaveMap("Large Wave Texture", 2D) = "bump" {}
		_LargeWaveTiling("Large Wave Tiling", Vector) = (0.12, 0.12, -0.08, 0.04)
		_LargeWaveDirection("Large Wave Direction", Vector) = (5.0, 5.0, -3.0, 4.0)
		_WaveBumpScale("Wave Bump Scale", Vector) = (0.25, 0.25, 0.2, 0.2)
		_PackedParams("(Refraction, Reflection, Fresnel power, Fresnel bias)", Vector) = (0.6, 0.3, 4.0, 0.2)

		_Fade("Fade(edge, shelf, deep,)", Vector) = (1, 0.1, 0.15, 1)
		_FadePow("FadePow(edge, shelf, deep,)", Vector) = (1, 2, 0.4, 1)
		
		_MainColor("Main Color", Color) = (0.4, 1, 0.945, 1)
		_MainColorLDR("Main Color LDR", Color) = (0.4, 1, 0.945, 0.5)
		_DeepWaterColor("Deep Water Color", Color) = (0,0.3411765,0.6235294,1)
	}

	SubShader
	{
		Tags
		{
			"RenderType" = "Transparent"
			"LightMode" = "ForwardBase"
			"Queue" = "Transparent-499"
			"IgnoreProjector" = "True"
			"PreviewType" = "Plane"
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
			#include "Water.cginc"
			ENDCG
		}
	}
}
