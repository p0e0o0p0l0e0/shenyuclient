// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Fate Shading/Effect/Alpha Blended VertexAnimation" 
{
	Properties
	{
		_TintColor ("Tint Color", Color) = (0.5,0.5,0.5,0.5)
		_MainTex ("Particle Texture", 2D) = "white" {}

		_RenderQueue ("RenderQueue", Float) = 3000
	}

	SubShader
	{
		Tags { "Queue"="Transparent"  "RenderType"="Transparent" }
		Blend SrcAlpha OneMinusSrcAlpha
		Lighting Off ZWrite On

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile __ VERTEX_ANIMATION_ON
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
				float4 vertexColor : COLOR;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			fixed4 _TintColor;

			#ifdef VERTEX_ANIMATION_ON
			fixed4 _Offset;
			#endif

			v2f vert (appdata v)
			{
				v2f o;
				#ifdef VERTEX_ANIMATION_ON
				float4 posWorld = mul(unity_ObjectToWorld, v.vertex);
				posWorld.xy += _Offset.xy * v.vertexColor.r;
				o.vertex =mul(UNITY_MATRIX_VP, posWorld);
				#else
				o.vertex = UnityObjectToClipPos(v.vertex);
				#endif
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.uv);
				col = col * 2.0f * _TintColor;
				return col;
			}
			ENDCG
		}
	}
		CustomEditor "VFXShaderInspector"
}
