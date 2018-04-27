// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

#include "UnityCG.cginc"

struct appdata
{
	float4 vertex : POSITION;
	float2 uv : TEXCOORD0;
};

struct v2f
{
	float4 vertex : SV_POSITION;
#ifdef USE_DEPTH
	float3 uv : TEXCOORD0;
#else
	float2 uv : TEXCOORD0;
#endif

#if defined(USE_FOG) || defined(USE_DEPTH)
	float4 projPos : TEXCOORD1;
#endif
};

sampler2D _MainTex;
float4 _MainTex_ST;
half _Multiplier;

#if defined(USE_FOG) && defined(USE_DEPTH)
sampler2D _AirFlowTex;
float4 _AirFlowTex_ST;
float _AirFlowStartDepth;
float _AirFlowDepth;
half4 _AirFlowColor;
half2 _AirFlowOffset;
		
float _StartDepth;
float _Depth;
half4 _FogColor;
#endif

#ifdef USE_DEPTH
float _ColorScale;
#endif

v2f vert(appdata v)
{
	v2f o;
	o.vertex = UnityObjectToClipPos(v.vertex);
	o.uv.xy = v.uv * _MainTex_ST.xy + _MainTex_ST.zw;
#ifdef USE_DEPTH
	o.uv.z = o.vertex.w;
#endif
#if defined(USE_FOG) || defined(USE_DEPTH)
	o.projPos = ComputeScreenPos(o.vertex);
#endif
	return o;
}

half4 frag(v2f i) : SV_Target
{
	half4 base = tex2D(_MainTex, i.uv.xy);
#ifdef HDR_ON
	half3 color = base.rgb * base.rgb * _Multiplier;
#else
	half3 color = base.rgb;
#endif

#if defined(USE_FOG) && defined(USE_DEPTH)
    half2 uv = i.projPos.xy /  i.projPos.w;
	uv = TRANSFORM_TEX(uv, _AirFlowTex);
	half4 fogColor = tex2D(_AirFlowTex,  uv + _AirFlowOffset) * _AirFlowColor;
	float scale = min(max(0, i.projPos.w - _AirFlowStartDepth), _AirFlowDepth)/_AirFlowDepth;
	color.rgb =lerp(color.rgb  , fogColor.rgb , scale * fogColor.a);
	//
	scale = min(max(0, i.projPos.w - _StartDepth), _Depth)/_Depth;
	color.rgb =lerp(color.rgb  , _FogColor.rgb , scale * _FogColor.a);
#endif

#ifdef USE_DEPTH
color.rgb = color.rgb * _ColorScale;
#endif

#ifdef USE_DEPTH
	return half4(color, i.uv.z);
#else
	return half4(color, base.a);
#endif
}
