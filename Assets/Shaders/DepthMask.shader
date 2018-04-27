Shader "Fate Shading/DepthMask" {
	Properties{
		_Cutoff("Cutoff", Range(0,1)) = 0
		_Mask("Mask", 2D) = "white" {}
		_Factor("Factor", Float) = 0.0
		_Units("Units", Float) = 0.0
	}
	SubShader{
		Tags{ "Queue" = "Geometry-1" }
		ZWrite On
		ColorMask 0
		Offset [_Factor], [_Units]

		Pass{

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"
			
			sampler2D _Mask;
			float _Cutoff;

			struct appdata_t 
			{
				float4 vertex : POSITION;
				float2 texcoord : TEXCOORD0;
			};

			struct v2f 
			{
				float4 vertex : SV_POSITION;
				float2 texcoord : TEXCOORD0;
			};

			float4 _Mask_ST;

			v2f vert(appdata_t v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.texcoord = TRANSFORM_TEX(v.texcoord, _Mask);
				return o;
			}

			half4 frag(v2f i) : SV_Target
			{
				float4 tex = tex2D(_Mask, i.texcoord);
				clip(tex.r - _Cutoff);
				return half4(0,0,0,0);
			}
			ENDCG
		}
	}
}
