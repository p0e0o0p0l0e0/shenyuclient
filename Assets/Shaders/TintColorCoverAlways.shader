// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Fate Shading/TintColor Cover Always" {
Properties {
	_Color ("Main Color", Color) = (0,0,0,1)
}

SubShader {
	Tags { "RenderType"="Transparent" "Queue" = "Transparent+1000"}
	LOD 100
	Cull Off
	ZTest Always
	ZWrite  Off
	Lighting Off
	Blend SrcAlpha OneMinusSrcAlpha

	Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma fragmentoption ARB_precision_hint_fastest

			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
			};

			fixed4 _Color;

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				return _Color;
			}
			ENDCG
		}
	}

}
