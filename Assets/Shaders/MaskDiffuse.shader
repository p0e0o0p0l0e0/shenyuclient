// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Fate Shading/MaskDiffuse"
{
	Properties
	{
		_MainTex ("MainTex ", 2D) = "white" {}
		_ColorTex ("ColorTex", 2D) = "white" {}
		_MaskTex ("MaskTex", 2D) = "white" {}
		_Color ("MaskTex", Color) = (0,0,0,0)
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100

		Pass
		{
			Tags { "RenderType"="Opaque" "LightMode"="Always"}
			Cull off
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			#pragma multi_compile_fog
			
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

			float4 _MainTex_ST;
			sampler2D _MainTex;
			sampler2D _MaskTex;
			sampler2D _ColorTex;
			fixed4 _Color;
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col1 = tex2D(_MainTex, i.uv);
				fixed4 col2 = tex2D(_ColorTex, i.uv)*_Color;
				fixed4 colMask = tex2D(_MaskTex, i.uv);
				fixed4 col = col1*(1-colMask.a) + col2 * colMask.a;
				return col;
			}
			ENDCG
		}
		
	}
}
