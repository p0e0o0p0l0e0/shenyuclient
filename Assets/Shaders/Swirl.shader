// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Fate Shading/Swirl"
{
	Properties
	{
		_SwirlTexture ("Texture", 2D) = "white" {}
		_Angle ("Angle", Range(0, 360)) = 90
		_Radius ("Radius", Range(0,1)) = 0.0
		_Center ("Center", Vector) = (0.5,0.5,0,0)
		_Color ("Color", Color) = (1,1,1,1)
		_ColorRange ("ColorRadius", Range(0,1)) = 0.0
		_Dark ("Dark", Float) = 1
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" "Queue"="Transparent"}
		LOD 100
		ZTest Always Cull Off ZWrite Off Lighting Off

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

			sampler2D _SwirlTexture;
			float4 _SwirlTexture_ST;
			float _Angle;
			float _Radius;
			fixed4 _Center;
			fixed4 _Color;
			fixed _ColorRange;
			fixed _Dark;

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _SwirlTexture);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				fixed2 uv = i.uv-_Center.xy;
				half r = length(uv);
				fixed4 rangeColor = fixed4(1,1,1,1);
				if(r <= _Radius)
				{
					float per = (_Radius-r)/_Radius;
					float value = per*per*_Angle * 3.14*8/180;
					float s = sin(value);
					float c = cos(value);
					uv = float2(dot(uv,float2(c,-s)),dot(uv,float2(s,c)));
				}
				if(r < _ColorRange)
				{
					fixed value = saturate(r/_ColorRange);
					rangeColor=fixed4(value,value,value,1)*_Color;
				}
				//
				fixed4 col = tex2D(_SwirlTexture, uv + _Center.xy)*rangeColor * _Dark;
				return col;
			}
			ENDCG
		}
	}
}
