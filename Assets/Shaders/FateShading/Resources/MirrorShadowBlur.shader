Shader "Hidden/MirrorShadowBlur"
{
	SubShader
	{
		Tags{ "RenderType" = "Opaque" }
		LOD 100
		Cull Off

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma exclude_renderers d3d9 d3d11_9x

			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
				float4 projPos : TEXCOORD0;
			};

			sampler2D _MirrorShadow;
			float4 _MirrorShadow_TexelSize;

			v2f vert(appdata v)
			{
				v2f o;
				float4 wPos = mul(unity_ObjectToWorld, v.vertex);
				o.vertex = mul(UNITY_MATRIX_VP, wPos);
				o.projPos = ComputeScreenPos(o.vertex);
				return o;
			}
			
			half4 frag (v2f i) : SV_Target
			{
				float2 tex = i.projPos.xy / i.projPos.w;
				float2 offset = _MirrorShadow_TexelSize.xy * 0.5;
				half4 res = tex2D(_MirrorShadow, tex + float2(offset.x, offset.y));
				res += tex2D(_MirrorShadow, tex + float2(-offset.x, offset.y));
				res += tex2D(_MirrorShadow, tex + float2(offset.x, -offset.y));
				res += tex2D(_MirrorShadow, tex + float2(-offset.x, -offset.y));
				return res * 0.25;
			}
			ENDCG
		}
	}
}
