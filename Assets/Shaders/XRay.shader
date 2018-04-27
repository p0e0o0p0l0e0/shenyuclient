Shader "ViCross/XRay"
{
	Properties 
	{
		_Color("Main Color",  Color) = (1,1,1,1)
		_RimColor("Rim Color" , Color) = (0.31,0.3,0.28,0.0)
		_RimPower("Rim Power",Range(0.2,8.0)) = 2.5
		_Cutoff("Alpha Cut off", Range(0,1)) = 0.1
		_OriginalTex ("Original (RGB)", 2D) = "white" {}
		_LihgtColor("Light Color",  Color) = (1,1,1,1)
		
	}

	SubShader
	{
		Tags {"Queue" = "Geometry" "RenderType" = "Transparent" }
		Name "BASE"
		LOD 100

		Cull Off
		ZTest Greater
		Lighting Off
		ZWrite Off
		Blend one one
		Offset -50,50
		
		CGPROGRAM
		#pragma surface surf StandardNoLight alphatest:_Cutoff nolightmap noshadow noforwardadd nodirlightmap nofog 
		#include "UnityPBSLighting.cginc"

		struct Input 
		{
			float2 uv_OriginalTex;     
			float3 viewDir;
			float4 _color;
		};

		sampler2D _OriginalTex;
		fixed4 _Color;     
		fixed4 _RimColor;
		fixed4 _LihgtColor;
		fixed _RimPower;
			
	
		inline half4 LightingStandardNoLight (SurfaceOutputStandard s, half3 viewDir, UnityGI gi)
		{
			return 0;
		}

		inline half4 LightingStandardNoLight_Deferred (SurfaceOutputStandard s, half3 viewDir, UnityGI gi, out half4 outDiffuseOcclusion, out half4 outSpecSmoothness, out half4 outNormal)
		{
			outDiffuseOcclusion = 0;
			outSpecSmoothness = 0;
			outNormal = 0;
			
			half rim = saturate( 1- dot (normalize(viewDir), s.Normal));
			half4 col = 1;
			col.rgb = _RimColor.rgb * pow (rim, _RimPower) * s.Albedo * 3;
			col.a = s.Occlusion;
			return  col;
		}
		
		inline void LightingStandardNoLight_GI (
			SurfaceOutputStandard s,
			UnityGIInput data,
			inout UnityGI gi)
		{
		}
		
		void surf (Input IN, inout SurfaceOutputStandard o) 
		{
			fixed4 originalTex = tex2D (_OriginalTex, IN.uv_OriginalTex);
			o.Albedo =  _Color.rgb;       
			o.Alpha = originalTex.a;
			half rim = saturate( 1- dot (normalize(IN.viewDir), o.Normal));
			o.Emission = _RimColor.rgb * pow (rim, _RimPower);
		}
		ENDCG
    } 
}
