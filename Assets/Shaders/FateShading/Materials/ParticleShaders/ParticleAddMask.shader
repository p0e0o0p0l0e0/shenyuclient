// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Fate Shading/Effect/Add Mask" 
{
	Properties 
	{
		_TintColor ("Tint Color", Color) = (0.5,0.5,0.5,0.5)
		_MainTex ("Particle Texture", 2D) = "white" {}
		_Mask ("Mask ( R Channel )", 2D) = "white" {}

		_RenderQueue ("RenderQueue", Float) = 3100
	}

	Category 
	{
		Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" }
		Blend SrcAlpha One
		Cull Off Lighting Off ZWrite Off Fog { Color (0,0,0,0) } ColorMask RGB
	
		SubShader 
		{
			Pass 
			{
				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#pragma fragmentoption ARB_precision_hint_fastest
				#pragma multi_compile CLIPOFF CLIPON
				#include "UnityCG.cginc"

				sampler2D _MainTex;
				sampler2D _Mask;
				fixed4 _TintColor;

				struct appdata_t 
				{
					float4 vertex : POSITION;
					fixed4 color : COLOR;
					float2 texcoord : TEXCOORD0;
				};

				struct v2f 
				{
					float4 vertex : SV_POSITION;
					fixed4 color : COLOR;
					float2 texcoord : TEXCOORD0;
					float2 texcoordMask : TEXCOORD1;
					#ifdef CLIPON
					float2 worldPos : TEXCOORD2;
					#endif
				};
			
				float4 _MainTex_ST;
				float4 _Mask_ST;
				uniform float4x4 _Camera2World;

				#ifdef CLIPON
				float4 _ClipRange0 = float4(0.0, 0.0, 1.0, 1.0);
				float2 _ClipArgs0 = float2(1000.0, 1000.0);
				#endif

				v2f vert (appdata_t v)
				{
					v2f o;
					o.vertex = UnityObjectToClipPos(v.vertex);
					o.color = v.color;
					o.texcoord = TRANSFORM_TEX(v.texcoord,_MainTex);
					o.texcoordMask = TRANSFORM_TEX(v.texcoord,_Mask);
					//
					#ifdef CLIPON
					o.worldPos = v.vertex.xy * 50.0f *  _ClipRange0.zw + _ClipRange0.xy;
					#endif
					return o;
				}
			
				fixed4 frag (v2f i) : SV_Target
				{
				    fixed4 c = tex2D(_MainTex, i.texcoord);
					c.a *= tex2D(_Mask, i.texcoordMask).r;
					half4 finalColor =  i.color * c;
					finalColor = finalColor * _TintColor * 2.0f;
					//
					#ifdef CLIPON
					float2 factor = (float2(1.0, 1.0) - abs(i.worldPos)) * _ClipArgs0;
					finalColor.a *= clamp(min(factor.x, factor.y), 0.0, 1.0) * 2.0f;
					#endif
					return finalColor;
				}
				ENDCG 
			}

		}
	}

	CustomEditor "VFXShaderInspector"
}
