#include "UnityCG.cginc"

struct appdata
{
	float4 vertex			: POSITION;
#	ifdef MIRROR
	float2 uv				: TEXCOORD0;
#	endif
};

struct v2f
{
	float4 vertex			: SV_POSITION;
#	ifdef MIRROR
	float3 uv				: TEXCOORD0;
#	endif
};

#ifdef MIRROR
sampler2D _MainTex;
half4 _MirrorPlane;
half4 _MirrorParams;
#endif

#ifdef SHADOW
float4 _ShadowPlane;
float3 _mainLightDirection;
#endif

v2f vert(appdata v)
{
	v2f o;
#	if defined(MIRROR)
	float4 wPos = mul(unity_ObjectToWorld, v.vertex);
	o.uv.xy = v.uv;
	o.uv.z = dot(wPos, _MirrorPlane.xyz) + _MirrorPlane.w;
	float dist = dot(float3(0, -_MirrorPlane.w, 0) - wPos, _MirrorPlane.xyz) / dot(_MirrorPlane.xyz, _MirrorPlane.xyz);
	wPos.xyz = wPos.xyz + 2 * dist * _MirrorPlane.xyz;
	o.vertex = mul(UNITY_MATRIX_VP, wPos);
#	elif defined(SHADOW)
	float4 wPos = mul(unity_ObjectToWorld, v.vertex);
	float3 direction = -normalize(_mainLightDirection);
	float dist = dot(float3(0, -_ShadowPlane.w, 0) - wPos, _ShadowPlane.xyz) / dot(direction, _ShadowPlane.xyz);
	wPos.xyz = wPos.xyz + dist * direction;
	o.vertex = mul(UNITY_MATRIX_VP, wPos);
#	else
	o.vertex = UnityObjectToClipPos(v.vertex);
#	endif
	return o;
}

half4 frag(v2f i) : SV_Target
{
#	if defined(MIRROR)
	half3 base = tex2D(_MainTex, i.uv.xy).rgb;
	base *= base;
	half fade = pow((1.0 - saturate(i.uv.z * _MirrorParams.x)), _MirrorParams.y);
	return half4(base * fade, 1);
#	else
	return half4(1, 1, 1, 0);
#	endif
}

float4 mirrorShadowRES_TexelSize;
sampler2D mirrorShadowRES;

struct v2f_s5
{
	float4 pos		: SV_POSITION;
	float4 uv01		: TEXCOORD0;
	float4 uv23		: TEXCOORD1;
	float2 uv4		: TEXCOORD2;
};

v2f_s5 vert_blur(appdata_img v)
{
	v2f_s5 o;
	o.pos = UnityObjectToClipPos(v.vertex);
	o.uv01.xy = v.texcoord.xy + mirrorShadowRES_TexelSize.xy * float2(-1.5, -1.5);
	o.uv01.zw = v.texcoord.xy + mirrorShadowRES_TexelSize.xy * float2(1.5, -1.5);
	o.uv23.xy = v.texcoord.xy + mirrorShadowRES_TexelSize.xy * float2(-1.5, 1.5);
	o.uv23.zw = v.texcoord.xy + mirrorShadowRES_TexelSize.xy * float2(1.5, 1.5);
	o.uv4 = v.texcoord.xy;
	return o;
}

half4 frag_blur(v2f_s5 i) : SV_Target
{
	half4 C0 = tex2D(mirrorShadowRES, i.uv01.xy);
	half4 C1 = tex2D(mirrorShadowRES, i.uv01.zw);
	half4 C2 = tex2D(mirrorShadowRES, i.uv23.xy);
	half4 C3 = tex2D(mirrorShadowRES, i.uv23.zw);
	half4 C4 = tex2D(mirrorShadowRES, i.uv4);

	return (C0 * 0.2) + (C1 * 0.2) + (C2 * 0.2) + (C3 * 0.2) + (C4 * 0.2);
}
