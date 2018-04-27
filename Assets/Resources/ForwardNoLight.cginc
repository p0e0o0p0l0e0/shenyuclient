#include "UnityCG.cginc"
#include "Common.cginc"
#include "Noise.cginc"
#include "Fog.cginc"

struct appdata
{
	float4 vertex			: POSITION;
	float2 uv				: TEXCOORD0;
};

struct v2f
{
	float4 vertex			: SV_POSITION;
	float3 uv				: TEXCOORD0;
};

v2f vert(appdata v)
{
	v2f o;
	float4 wPos = mul(unity_ObjectToWorld, v.vertex);
	o.vertex = mul(UNITY_MATRIX_VP, wPos);
	o.uv.xy = v.uv;
	o.uv.z = o.vertex.w;
	return o;
}

sampler2D _MainTex;
half4 _TintColor;
half4 _Intensity;

half4 frag(v2f i) : SV_Target
{
	half4 baseColor = tex2D(_MainTex, i.uv.xy);
	half3 color = baseColor.rgb * baseColor.rgb * _TintColor;
#ifdef HDR_ON
	color *= _Intensity.x;
#else
	color *= _Intensity.y;
#endif
#if defined(UI_DISPLAY) || (!defined(POSTFX_ON))
	color = sqrt(color);
#endif
	return half4(color, i.uv.z);
}
