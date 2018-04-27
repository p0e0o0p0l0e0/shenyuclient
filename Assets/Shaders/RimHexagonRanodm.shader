Shader "ViCross/RimHexagonRanodm"
{
	Properties
	{
		_HexagonTex ("HexagonTex", 2D) = "white" {}
		_HexagonColor ("HexagonColor", Color) = (1,1,1,1)
		_HexagonFadeOutInTex("HexagonFadeOutInTex", 2D) = "white" {}
	}

	SubShader
	{
		Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" }
		LOD 100
		Blend SrcAlpha OneMinusSrcAlpha
		Cull Off Lighting Off ZWrite Off Fog { Color (0,0,0,0) }
		Offset -0.1, 0

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
				float4 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			sampler2D _HexagonTex;
			float4 _HexagonTex_ST;

			sampler2D _HexagonFadeOutInTex;

			fixed4 _HexagonColor;

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv.xy = TRANSFORM_TEX(v.uv, _HexagonTex);
				o.uv.zw = TRANSFORM_TEX(v.uv, _HexagonTex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 hexagonColor = tex2D(_HexagonTex, i.uv.zw);
				fixed4 _HexagonFadeOutInColor = tex2D(_HexagonFadeOutInTex, i.uv.zw);
				fixed r = (_HexagonFadeOutInColor.r + _Time.y) % 1;
				fixed3 finalColor = lerp(fixed3(1,1,1), (hexagonColor.rgb + fixed3(r,r,r)) * _HexagonColor.rgb, r);
				return fixed4 (finalColor, _HexagonFadeOutInColor.r);
			}
			ENDCG
		}
	}
}
