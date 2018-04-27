// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Fate Shading/Effect/BlendAdd" 
{
	Properties 
	{
		_TintColor ("Tint Color", Color) = (0.5,0.5,0.5,0.5)
		_MainTex ("Particle Texture", 2D) = "white" {}
		_ColorMul ("ColorMul(颜色倍数)", Float) = 2
		_MaskTex ("Mask Texture (r : 0-0.5 Alpha blend, 0.5-1 Blend Add, 1:Add)", 2D) = "white" {}
	}

	SubShader
	{
		Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" }
		LOD 100
		Blend One OneMinusSrcAlpha
		Cull Off Lighting Off ZWrite Off Fog { Color (0,0,0,0) }
		ColorMask RGB

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
				float4 vertexColor : COLOR;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
				float4 vertexColor : COLOR;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			fixed4 _TintColor;
			half _ColorMul;

			sampler2D _MaskTex;

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				o.vertexColor = v.vertexColor;
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.uv) *  i.vertexColor;
				fixed4 maskCol = tex2D(_MaskTex, i.uv);
				half alphaBlendFactor = saturate(maskCol.r * 2.0f - 1.0f);
				alphaBlendFactor = 1 - alphaBlendFactor;
				col.rgb = col.rgb * lerp(_ColorMul, 2.0f, alphaBlendFactor) * _TintColor.rgb * col.a;
				col.a = col.a * alphaBlendFactor;
				return col;
			}
			ENDCG
		}
	}
}