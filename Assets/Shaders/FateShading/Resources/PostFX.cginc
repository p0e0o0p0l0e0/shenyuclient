// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

#include "UnityCG.cginc"

#ifdef IMG_0
sampler2D IMG_0;
#endif
#ifdef IMG_1
sampler2D IMG_1;
#endif
#ifdef IMG_2
sampler2D IMG_2;
#endif
#ifdef IMG_3
sampler2D IMG_3;
#endif

#ifdef PARAM_0
float4 PARAM_0;
#endif

#ifdef PARAM_1
float4 PARAM_1;
#endif

#ifdef PARAM_2
float4 PARAM_2;
#endif

#ifdef PARAM_3
float4 PARAM_3;
#endif

float2 Circle(float Start, float Points, float Point)
{
	float Rad = (3.141592 * 2.0 * (1.0 / Points)) * (Point + Start);
	return float2(sin(Rad), cos(Rad));
}

struct v2f
{
	float4 pos : SV_POSITION;
	float2 uv  : TEXCOORD0;
};

struct v2f_s4
{
	float4 pos : SV_POSITION;
	float4 uv01  : TEXCOORD0;
	float4 uv23  : TEXCOORD1;
};

struct v2f_s7
{
	float4 pos : SV_POSITION;
	float4 uv01 : TEXCOORD1;
	float4 uv23 : TEXCOORD2;
	float4 uv45 : TEXCOORD3;
	float2 uv6 : TEXCOORD4;
};

struct v2f_s14
{
	float4 pos : SV_POSITION;
	half4 uv01 : TEXCOORD0;
	half4 uv23 : TEXCOORD1;
	half4 uv45 : TEXCOORD2;
	half4 uv67 : TEXCOORD3;
	half4 uv89 : TEXCOORD4;
	half4 uv0A : TEXCOORD5;
	half4 uvBC : TEXCOORD6;
	half2 uvD : TEXCOORD7;
};

v2f vert(appdata_img v)
{
	v2f o;
	o.pos = UnityObjectToClipPos(v.vertex);
	o.uv = v.vertex.xy;
	return o;
}

#if defined(PARAM_0)
v2f_s4 vert_s4(appdata_img v)
{
	v2f_s4 o;
	o.pos = UnityObjectToClipPos(v.vertex);
	o.uv01.xy = v.texcoord.xy + float2(PARAM_0.x, PARAM_0.y);
	o.uv01.zw = v.texcoord.xy + float2(-PARAM_0.x, -PARAM_0.y);
	o.uv23.xy = v.texcoord.xy + float2(PARAM_0.x, -PARAM_0.y);
	o.uv23.zw = v.texcoord.xy + float2(-PARAM_0.x, PARAM_0.y);
	return o;
}

v2f_s7 vert_bloomup(appdata_img v)
{
	v2f_s7 o;
	float Start = 2.0/6.0;
	float2 uv_offset = PARAM_0.xy * (0.66 / 2.0);
	o.pos = UnityObjectToClipPos(v.vertex);
	o.uv01.xy = v.texcoord.xy;
	o.uv01.zw = v.texcoord.xy + Circle(Start, 6.0, 0.0) * uv_offset;
	o.uv23.zw = v.texcoord.xy + Circle(Start, 6.0, 1.0) * uv_offset;
	o.uv23.xy = v.texcoord.xy + Circle(Start, 6.0, 2.0) * uv_offset;
	o.uv45.xy = v.texcoord.xy + Circle(Start, 6.0, 3.0) * uv_offset;
	o.uv45.zw = v.texcoord.xy + Circle(Start, 6.0, 4.0) * uv_offset;
	o.uv6.xy = v.texcoord.xy + Circle(Start, 6.0, 5.0) * uv_offset;
	return o;
}

v2f_s14 vert_bloomdown(appdata_img v)
{
	v2f_s14 o;
	float Start = 2.0 / 14.0;
#ifdef HQ_BLOOM
	float2 uv_offset = PARAM_0.xy * (4.0 / 3.0);
#else
	float2 uv_offset = PARAM_0.xy * (8.0 / 3.0);
#endif
	o.pos = UnityObjectToClipPos(v.vertex);
	o.uv01.xy = v.texcoord.xy;
	o.uv01.zw = v.texcoord.xy + Circle(Start, 14.0, 0.0) * uv_offset;
	o.uv23.xy = v.texcoord.xy + Circle(Start, 14.0, 1.0) * uv_offset;
	o.uv23.zw = v.texcoord.xy + Circle(Start, 14.0, 2.0) * uv_offset;
	o.uv45.xy = v.texcoord.xy + Circle(Start, 14.0, 3.0) * uv_offset;
	o.uv45.zw = v.texcoord.xy + Circle(Start, 14.0, 4.0) * uv_offset;
	o.uv67.xy = v.texcoord.xy + Circle(Start, 14.0, 5.0) * uv_offset;
	o.uv67.zw = v.texcoord.xy + Circle(Start, 14.0, 6.0) * uv_offset;
	o.uv89.xy = v.texcoord.xy + Circle(Start, 14.0, 7.0) * uv_offset;
	o.uv89.zw = v.texcoord.xy + Circle(Start, 14.0, 8.0) * uv_offset;
	o.uv0A.xy = v.texcoord.xy + Circle(Start, 14.0, 9.0) * uv_offset;
	o.uv0A.zw = v.texcoord.xy + Circle(Start, 14.0, 10.0) * uv_offset;
	o.uvBC.xy = v.texcoord.xy + Circle(Start, 14.0, 11.0) * uv_offset;
	o.uvBC.zw = v.texcoord.xy + Circle(Start, 14.0, 12.0) * uv_offset;
	o.uvD.xy = v.texcoord.xy + Circle(Start, 14.0, 13.0) * uv_offset;
	return o;
}
#endif



#if defined(IMG_0)
half4 frag_scale_s1(v2f i) : SV_Target
{
	return tex2D(IMG_0, i.uv);
}
#endif

#if defined(IMG_0)
half4 frag_scale_s4(v2f_s4 i) : SV_Target
{
	half4 s = tex2D(IMG_0, i.uv01.xy);
	s += tex2D(IMG_0, i.uv01.zw);
	s += tex2D(IMG_0, i.uv23.xy);
	s += tex2D(IMG_0, i.uv23.zw);
	return s * 0.25;
}
#endif

#if defined(IMG_0) && defined(PARAM_0) && defined(PARAM_1)
half4 frag_bloomstart(v2f i) : SV_Target
{
	half4 c = tex2D(IMG_0, i.uv);
#ifdef HDR_ON
	half threshold = PARAM_1.z;
#else
	half threshold = PARAM_1.x;
#endif
	half bloom = saturate(dot(c.rgb, half3(0.299, 0.587, 0.114)) - threshold);
	return c * bloom;
}
#endif

#if defined(IMG_0) && defined(PARAM_0)
half4 frag_bloomdown(v2f_s14 i) : SV_Target
{
	half4 s = tex2D(IMG_0, i.uv01.xy);
	s += tex2D(IMG_0, i.uv01.zw);
	s += tex2D(IMG_0, i.uv23.xy);
	s += tex2D(IMG_0, i.uv23.zw);
	s += tex2D(IMG_0, i.uv45.xy);
	s += tex2D(IMG_0, i.uv45.zw);
	s += tex2D(IMG_0, i.uv67.xy);
	s += tex2D(IMG_0, i.uv67.zw);
	s += tex2D(IMG_0, i.uv89.xy);
	s += tex2D(IMG_0, i.uv89.zw);
	s += tex2D(IMG_0, i.uv0A.xy);
	s += tex2D(IMG_0, i.uv0A.zw);
	s += tex2D(IMG_0, i.uvBC.xy);
	s += tex2D(IMG_0, i.uvBC.zw);
	s += tex2D(IMG_0, i.uvD.xy);
	s = (s * (1.0 / 15.0));
#ifdef HQ_BLOOM
	return s;
#else
	return s * 1.8;
#endif
}
#endif

#if defined(IMG_0) && defined(PARAM_0)
half4 frag_bloomup(v2f_s7 i) : SV_Target
{
	half s0 = 1.0;
	half s1 = 0.5;
	half a = 1.0 / (s0 + s1 * 6.0);
	s0 *= a;
	s1 *= a;
	half4 s = tex2D(IMG_0, i.uv01.xy) * s0;
	s += tex2D(IMG_0, i.uv01.zw) * s1;
	s += tex2D(IMG_0, i.uv23.xy) * s1;
	s += tex2D(IMG_0, i.uv23.zw) * s1;
	s += tex2D(IMG_0, i.uv45.xy) * s1;
	s += tex2D(IMG_0, i.uv45.zw) * s1;
	s += tex2D(IMG_0, i.uv6.xy) * s1;
	return s;
}
#endif

#if defined(IMG_0) && defined(IMG_1) 
half4 frag_bloom_merge(v2f i) : SV_Target
{
	half4 extraBloom = tex2D(IMG_0, i.uv) * 0.575;
	extraBloom += tex2D(IMG_1, i.uv) * 0.225;
	return extraBloom;
}
#endif

#if defined(IMG_0) && defined(IMG_1) && defined(PARAM_0)
half4 frag_final_merge(v2f i) : SV_Target
{
	half3 origin = tex2D(IMG_0, i.uv).rgb;
	half3 bloom = tex2D(IMG_1, i.uv).rgb * PARAM_0.y;
	return half4(pow(origin + bloom, 0.5), 1);
}
#endif

#if defined(IMG_0) && defined(IMG_1) && defined(IMG_2) && defined(PARAM_0)
half4 frag_final_merge_tonemap(v2f i) : SV_Target
{
	half3 origin = tex2D(IMG_0, i.uv).rgb;
	half3 bloom = tex2D(IMG_1, i.uv).rgb * PARAM_0.y;
	half3 tonemapped = 1 - exp(half3(-PARAM_0.z * (origin + bloom)));
	half3 color = pow(tonemapped, 0.5);
	color.r = tex2D(IMG_2, half2(color.r, 0.5)).r;
	color.g = tex2D(IMG_2, half2(color.g, 0.5)).g;
	color.b = tex2D(IMG_2, half2(color.b, 0.5)).b;
	return half4(color, 1);
}
#endif
