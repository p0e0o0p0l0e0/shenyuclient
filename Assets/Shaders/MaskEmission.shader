Shader "ViCross/MaskEmission" {
Properties {
	_MainTex ("Diffuse Texture", 2D) = "white" {}
	_DiffuseColor ("Diffuse Color", Color) = (1,1,1,1)
	_EmissionTex ("Emission", 2D) = "white" {}
	_EmissionColor ("Emission", Color) = (1,1,1,1)
}

SubShader { 
	Tags { "RenderType"="Opaque" }
	LOD 100
	
	CGPROGRAM
	#pragma surface surf Lambert

	sampler2D _MainTex;
	sampler2D _EmissionTex;
	sampler2D _OccluisonTex;
	half4 _EmissionColor;
	half4 _DiffuseColor;

	struct Input {
		float2 uv_MainTex;
		float2 uv_EmissionTex;
		float2 uv_OccluisonTex;
		half4 _EmissionColor;
	};

	void surf (Input IN, inout SurfaceOutput o) {
		fixed4 tex = tex2D(_MainTex, IN.uv_MainTex) * _DiffuseColor;
		fixed4 emissionColor = tex2D(_EmissionTex, IN.uv_EmissionTex).r * _EmissionColor;
		o.Albedo = tex.rgb;
		o.Emission = emissionColor;
		o.Alpha = tex.a;
	}
ENDCG
}
}
