Shader "ViCross/RimHexagon"
{
	Properties
	{
		_HexagonTex ("HexagonTex", 2D) = "white" {}
		_HexagonColor ("HexagonColor", Color) = (1,1,1,1)
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
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			sampler2D _HexagonTex;
			float4 _HexagonTex_ST;

			fixed4 _HexagonColor;

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _HexagonTex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 hexagonColor = tex2D(_HexagonTex, i.uv);
				return fixed4 (_HexagonColor.rgb * hexagonColor.rgb, hexagonColor.r);
			}
			ENDCG
		}
	}
}
