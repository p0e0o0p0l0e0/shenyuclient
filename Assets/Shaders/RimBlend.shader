Shader "ViCross/RimBlend"
{
	Properties 
	{
		_Color("Main Color",  Color) = (1,1,1,1)
		_RimColor("Rim Color" , Color) = (0.26,0.19,0.16,0.0)
		_RimPower("Rim Power",Range(0.2,8.0)) = 2.5
		_SpecColor ("Specular Color", Color) = (0.5, 0.5, 0.5, 1)
		_SpecPower ("Spec Power", Range (0.01, 1)) = 0.078125
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_Cutoff("Alpha Cut off", Range(0,1)) = 0.5
		_OriginalTex ("Base (RGB)", 2D) = "white" {}
	}
	
	SubShader 
	{
		Tags
		{
			"Queue"="Transparent+100"
			"IgnoreProjector"="False"
			"RenderType"="Transparent"
		}

		Cull Off
		ZTest Less  
		Offset -1,0
		blend SrcAlpha one
		CGPROGRAM
		#pragma surface surf Lambert alphatest:_Cutoff  
		#pragma target 3.0
	

		sampler2D _MainTex;
		sampler2D _OriginalTex;
		half4 _Color;     
		half4 _RimColor;
		half _RimPower;
		fixed _SpecPower;

		struct Input 
		{
			float3 viewDir;
			float2 uv_MainTex;
			float2 uv_Blend_Texture;
			float2 uv_Blend_Texture01;
			float2 uv_OriginalTex; 
			half4 color : COLOR;
		};

		void surf (Input IN, inout SurfaceOutput o) 
		{
			fixed4 originalTex = tex2D (_OriginalTex, IN.uv_OriginalTex);
			o.Alpha = originalTex.a;
			o.Gloss = originalTex.a;
			o.Specular = _SpecPower;
			o.Albedo = _Color.rgb*originalTex.a;

			half rim = 1.0 - saturate(dot (normalize(IN.viewDir), o.Normal));
			o.Emission = _RimColor.rgb * pow (rim, _RimPower);
		}
		ENDCG
	}
}