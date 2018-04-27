// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

#include "UnityCG.cginc"

struct appdata
{
	float4 vertex : POSITION;
	float2 uv0 : TEXCOORD0;
#ifdef USE_LIGHTMAP
	float2 uv1 : TEXCOORD1;
#endif
};

struct v2f
{
	float4 vertex : SV_POSITION;
#ifdef USE_LIGHTMAP
	float4 uv : TEXCOORD0;
#else
	float2 uv : TEXCOORD0;
#endif
#if defined(USE_SHADOW_MIRROR) || defined(USE_DEPTH)
	float4 projPos : TEXCOORD1;
#endif

#ifdef USE_WATER_REFLECTION
	float4 waterUV : TEXCOORD2;
#endif

#ifdef CLOUD_SHADOW
	float4 posWorld : TEXCOORD3;
#endif

};

sampler2D _MainTex;
float4 _MainTex_ST;
half3 _Color;
half _Multiplier;

#ifdef USE_GLOW
sampler2D _GlowTex;
half _GlowMultiplier;
#endif

#ifdef USE_ALPHATEST
half _AlphaCutOff;
#endif

#ifdef USE_SHADOW_MIRROR
sampler2D _MirrorShadowTex;
float4 _MirrorShadowTex_TexelSize;
half4 _MirrorColor;
half4 _ShadowColor;
#endif

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

#ifdef USE_WATER_REFLECTION
sampler2D _WaterMaskTex;
fixed4 _WaterColor;
half4 _WaterParam;
#endif

#ifdef CLOUD_SHADOW
sampler2D _CloudShadow;
fixed4 _CloudShadowColor;
half4 _Params;
#endif

v2f vert(appdata v)
{
	v2f o;
	o.vertex = UnityObjectToClipPos(v.vertex);
	o.uv.xy = v.uv0 * _MainTex_ST.xy + _MainTex_ST.zw;
#ifdef USE_LIGHTMAP
	o.uv.zw = v.uv1 * unity_LightmapST.xy + unity_LightmapST.zw;
#endif

#if defined(USE_SHADOW_MIRROR) || defined(USE_DEPTH)
	o.projPos = ComputeScreenPos(o.vertex);
#endif

#ifdef USE_WATER_REFLECTION
	o.waterUV.xy = v.uv0.xy * _WaterParam.xy + _WaterParam.w * _Time.xy;
	o.waterUV.zw = v.uv0.xy;
#endif

#ifdef CLOUD_SHADOW
	o.posWorld = mul(unity_ObjectToWorld, v.vertex);
#endif

	return o;
}

half4 frag(v2f i) : SV_Target
{
	half4 base = tex2D(_MainTex, i.uv.xy);

#ifdef USE_LIGHTMAP
	fixed4 bakedColorTex = UNITY_SAMPLE_TEX2D(unity_Lightmap, i.uv.zw);
	half3 bakedColor = DecodeLightmap(bakedColorTex);
#	ifdef HDR_ON
	half3 color = base.rgb * bakedColor * _Color.rgb * _Multiplier;
#	else
	half3 color = base.rgb * bakedColor * _Color.rgb;
#	endif
#else
#	ifdef HDR_ON
	half3 color = base.rgb * _Color.rgb * _Multiplier;
#	else
	half3 color = base.rgb * _Color.rgb;
#	endif
#endif

#ifdef USE_ALPHATEST
	clip(base.a - _AlphaCutOff);
#endif

#if defined(USE_SHADOW_MIRROR) &&(defined(ENABLE_SHADOW) || defined(ENABLE_MIRROR))
	#ifdef USE_WATER_REFLECTION
		half4 maskCol = tex2D(_WaterMaskTex, i.waterUV.zw);
		half4 screenPosproj = half4(i.projPos.xy + maskCol.bb * _WaterParam.z * maskCol.r, 0, i.projPos.w);
		fixed4 mirrorShadow = tex2Dproj(_MirrorShadowTex, screenPosproj);
		#ifdef ENABLE_SHADOW
			color *= lerp(_ShadowColor, half3(1, 1, 1), mirrorShadow.a);
		#endif
		#ifdef ENABLE_MIRROR
			color.rgb = lerp(color.rgb, _WaterColor.rgb * color.rgb + mirrorShadow.rgb * _MirrorColor.rgb, maskCol.r);
		#endif
	#else 
		float2 shadowUV = i.projPos.xy / i.projPos.w;
		half4 mirrorShadow = tex2D(_MirrorShadowTex, shadowUV);
		#ifdef ENABLE_SHADOW
			color *= lerp(_ShadowColor, half3(1, 1, 1), mirrorShadow.a);
		#endif
		#ifdef ENABLE_MIRROR
			color += mirrorShadow.rgb * _MirrorColor.rgb *base.a;
		#endif
	#endif
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

#ifdef CLOUD_SHADOW
	float2 uv01 = i.posWorld.xz / _Params.xy + _Time.x * _Params.zw;
	fixed4 shadow = tex2D(_CloudShadow, uv01) * _CloudShadowColor.a;
	color.rgb = color.rgb * (1- shadow.r)  + _CloudShadowColor.rgb * shadow.r;
#endif

#if defined(USE_GLOW)
	half3 glow = tex2D(_GlowTex, i.uv.xy).rgb;
	color += glow * glow * _GlowMultiplier;
#endif

#ifdef USE_DEPTH
	return half4(color, i.projPos.w);
#elif defined(USE_SHADOW_MIRROR) &&(defined(ENABLE_SHADOW) || defined(ENABLE_MIRROR))
	return half4(color, maskCol.r);
#else
	return half4(color, base.a);
#endif
}
