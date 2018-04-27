// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "ViCross/Standard" {
Properties {
	_Color ("Main Color", Color) = (0,0,0,1)
	_Emission ("Emissive Color", Color) = (0,0,0,1)
	_MainTex ("Base (RGB)", 2D) = "white" {}
	_CutOff ("CutOff", Range(0,1)) = 0.0
}

SubShader {
	Tags { "RenderType"="Opaque" "Queue" = "Transparent"}
	LOD 100
	Cull Off
	Blend SrcAlpha OneMinusSrcAlpha

	Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			fixed4 _Emission;
			half _CutOff;

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.uv);
				clip(col.a - _CutOff);
				col = col + _Emission - fixed4(0,0,0,1);
				return col;
			}
			ENDCG
		}
	}

}
