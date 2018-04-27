Shader "Fate Shading/Post Effect/GrayEffect"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_Trend ("trend(趋势(0:原来的颜色, 1:完全灰化)", Range(0.0, 1.0)) = 0.0
	}

	SubShader
	{
		Lighting Off
		Zwrite Off
		ZTest Always

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
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			half _Trend;

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.uv);
				col.rgb = lerp(col, Luminance(col.rgb), _Trend);
				return col;
			}
			ENDCG
		}
	}
}
