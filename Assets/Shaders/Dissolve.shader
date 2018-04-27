// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "ViCross/Dissolve" {
Properties {
	_Color ("Main Color", Color) = (1,1,1,1)
	_CutOff("Alpha Cut off", Range(0,1)) = 0.5
	_Amount ("Amount", Range (0, 1)) = 0
	_StartProgress ("_StartProgress", float) = 0.2
	_Duration1 ("_Duration1", float) = 0.2
	_Duration2 ("_Duration2", float) = 0.8
	_StartAmount("StartAmount", float) = 0.5
	_Amount2 ("Amount", float) = 5
	_Illuminate ("Illuminate", Range (0, 1)) = 0.5
	_DissColor ("DissColor", Color) = (1,1,1,1)
	_ColorAnimate ("ColorAnimate", vector) = (1,1,1,1)
	_MainTex ("Base (RGB) Gloss (A)", 2D) = "white" {}
	_DissolveSrc ("DissolveSrc", 2D) = "white" {}

}

SubShader { 
	Tags {"Queue" = "Geometry+100"}
	LOD 350
	cull off

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
			sampler2D _DissolveSrc;
			fixed4 _Color;
			half4 _DissColor;
			half4 _ColorAnimate;
			half _Illuminate;
			half _StartAmount;
			float startTime;
			fixed _Duration1;
			fixed _Duration2;
			fixed _Speed;
			fixed _StartProgress;
			fixed _Amount;
			fixed _Amount2;
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
				fixed4 tex = tex2D(_MainTex, i.uv) * _Color;
				fixed val = max(_Time.y - startTime - _Duration1,0);
				_Speed = (1-_StartProgress)/_Duration2;
				_Amount = val*_Speed + _StartProgress;
				fixed ClipTex = tex2D (_DissolveSrc, i.uv).r ;
				fixed ClipAmount = ClipTex - _Amount;
				fixed Clip = 0;
				half4 _color;
				if (ClipAmount <0 || tex.a < _CutOff)
				{
					clip(-0.1);
				}
				else
				{	
					if (ClipAmount < 0.1)
					{
						_color = (_DissColor*_ColorAnimate + ClipAmount*10 * (1-_ColorAnimate))*_Amount2;
						tex  = (tex * _color )/(1 - _Illuminate);
					}
				}
				return tex;
			}
			ENDCG
		}
	}
}
