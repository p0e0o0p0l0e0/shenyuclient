Shader "Fate Shading/Effect/ParticleClipUV"
{
	Properties
	{
		_TintColor ("Tint Color", Color) = (0.5,0.5,0.5,0.5)
		_MainTex ("Texture", 2D) = "white" {}
		_Angle ("Angle", Range(0 ,3.14)) = 60
		_Center ("Center", Vector) = (0.5,0.5,0,0)
		_MinRange ("MinRange", Float) = 1
	}

	SubShader
	{
		Tags { "Queue"="Transparent+100" "IgnoreProjector"="True" "RenderType"="Transparent" }
		LOD 100
		ZWrite Off
	                 
		Blend SrcAlpha One
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
			half4 _Center;
			half _Angle;
			half _MinRange;

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
				fixed4 col = tex2D(_MainTex, i.uv) * i.vertexColor;
				col = col * 2.0f * _TintColor;
				half rangeLen = length(i.uv.xy - _Center.xy);
				float2 coordinate = i.uv.xy - float2(0.5, 0.5);
				half radian = _Angle * 0.5f;
				half slope = cos(radian) / sin(radian);
				if(slope * coordinate.x + coordinate.y > 0 && slope * coordinate.x - coordinate.y < 0 && rangeLen > _MinRange)
				{

				}
				else
				{
					col.a = 0;
				}
				//
				return col;
			}
			ENDCG
		}
	}
}
