Shader "Toony Gooch Pro/Outline/OneDirLight/Specular-Fade"
{
	Properties
	{
		_MainTex ("Base (RGB) Gloss (A) ", 2D) = "white" {}
		_Ramp ("Toon Ramp (RGB)", 2D) = "gray" {}

		_SpecColor ("Specular Color", Color) = (0.5, 0.5, 0.5, 1)
		_Shininess ("Shininess", Range (0.01, 1)) = 0.078125

		_Color ("Highlight Color", Color) = (0.8,0.8,0.8,1)
		_SColor ("Shadow Color", Color) = (0.0,0.0,0.0,1)

		_Outline ("Outline Width", Range(0,0.05)) = 0.005
		_OutlineColor ("Outline Color", Color) = (0.2, 0.2, 0.2, 1)

		_Emission ("Emissive Color", Color) = (0,0,0,1)


		_Duration ("Duration", Float) = 5
		_DissolveSrc ("DissolveSrc", 2D) = "white" {}
	}
	
	SubShader
	{
		Tags { "RenderType"="Opaque" "Queue"="Geometry"}
		LOD 200
		Cull Off
		CGPROGRAM
		
		#include "TGP_Include.cginc"

		#pragma surface surf ToonyGoochSpec finalcolor:final nolightmap nodirlightmap noforwardadd approxview halfasview

		sampler2D _MainTex;
		sampler2D _DissolveSrc;
		fixed _Shininess;
		fixed4 _Emission;
		half _Duration;

		struct Input
		{
			half2 uv_MainTex : TEXCOORD0;
			half2 uv_DissolveSrc : TEXCOORD1;
		};
		
		void surf (Input IN, inout SurfaceOutput o)
		{
			half4 c = tex2D(_MainTex, IN.uv_MainTex);
			o.Albedo = c.rgb + _Emission.rgb;
			o.Gloss = c.a;
			o.Alpha = 1;
			o.Specular = _Shininess;
		}

		void final(Input IN, SurfaceOutput o, inout fixed4 color) 
		{   
            half4 ClipTex = tex2D (_DissolveSrc, IN.uv_DissolveSrc).r;
			clip(_Duration - ClipTex.r);
        }

		ENDCG

		UsePass "Hidden/ToonyGooch-Outline-Fade/OUTLINEFADE"
	}
	
	Fallback "Toony Gooch Pro/Outline/OneDirLight/Basic"
}
