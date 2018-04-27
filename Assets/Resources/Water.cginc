#include "UnityCG.cginc"
#include "Common.cginc"
#include "Fog.cginc"

struct appdata_t {
	float4 vertex			: POSITION;
};

struct v2f {
	float4 vertex			: SV_POSITION;
	float4 viewDir			: TEXCOORD0;
	float4 projPos			: TEXCOORD1;
	float4 wave0			: TEXCOORD2;
	float4 wave1			: TEXCOORD3;
};

float4 _SmallWaveTiling;
float4 _SmallWaveDirection;
float4 _LargeWaveTiling;
float4 _LargeWaveDirection;

v2f vert(appdata_t v)
{
	v2f o;
	float4 wPos = mul(unity_ObjectToWorld, v.vertex);
	o.vertex = mul(UNITY_MATRIX_VP, wPos);
	o.viewDir.xyz = _WorldSpaceCameraPos - wPos.xyz;
	o.viewDir.w = o.vertex.w;
	o.projPos = ComputeScreenPos(o.vertex);

	//float2 tileableUV = wPos.xz;
	o.wave0 = (wPos.xzxz + _Time.xxxx * _SmallWaveDirection) * _SmallWaveTiling;
	o.wave1 = (wPos.xzxz + _Time.xxxx * _LargeWaveDirection) * _LargeWaveTiling;
	
	return o;
}

sampler2D _SmallWaveMap;
sampler2D _LargeWaveMap;
half4 _WaveBumpScale;
sampler2D sceneRT_div2;
half4 _PackedParams;

half4 _MainColor;
half4 _MainColorLDR;
half4 _DeepWaterColor;
half _Density;
half4 _Fade;
half4 _FadePow;

half4 frag(v2f i) : SV_Target
{
	half3 N = half3(0,1,0);
	N.xz += (tex2D(_SmallWaveMap, i.wave0.xy).xy * 2 - 1) * _WaveBumpScale.x;
	N.xz += (tex2D(_SmallWaveMap, i.wave0.zw).xy * 2 - 1) * _WaveBumpScale.y;
	N.xz += (tex2D(_LargeWaveMap, i.wave1.xy).xy * 2 - 1) * _WaveBumpScale.z;
	N.xz += (tex2D(_LargeWaveMap, i.wave1.zw).xy * 2 - 1) * _WaveBumpScale.w;
	N = normalize(N);
	half3 V = normalize(i.viewDir.xyz);
	half3 R = normalize(reflect(-V, N));
	half3 reflection = RGBMDecode(UNITY_SAMPLE_TEXCUBE_LOD(unity_SpecCube0, half3(-R.x, R.yz), 1)) * unity_SpecCube0_HDR.x;

#ifdef HDR_ON
	half4 grabScreen = tex2Dproj(sceneRT_div2, UNITY_PROJ_COORD(i.projPos));
	half3 originalRefraction = grabScreen.xyz;
	half4 distortOffset = half4(N.xz * _PackedParams.x, 0, 0);
	half3 distortedRefraction = tex2Dproj(sceneRT_div2, UNITY_PROJ_COORD(i.projPos + distortOffset));
	float underWaterDepth = grabScreen.w - i.viewDir.w;
	half3 depthFade = pow(saturate(underWaterDepth * _Fade.xyz), _FadePow.xyz);
	half3 refraction = lerp(lerp(1, _MainColor.rgb, depthFade.g) * distortedRefraction, _DeepWaterColor, depthFade.b);  // lerp(distortedRefraction * _MainColor.rgb, _DeepWaterColor, depthFade.x);
#else
	half3 refraction = _DeepWaterColor.rgb;
	half4 distortOffset = half4(N.xz * _PackedParams.x, 0, 0);
	half3 distortedRefraction = tex2Dproj(sceneRT_div2, UNITY_PROJ_COORD(i.projPos + distortOffset));
	refraction = distortedRefraction * _MainColorLDR.xyz * _MainColorLDR.w + (1 - _MainColorLDR.w) * _DeepWaterColor;
#endif



	half fresnel = _PackedParams.w + (1 - _PackedParams.w) * pow(1.0 - abs(dot(N, V)), _PackedParams.z);
	half3 color = fresnel * reflection + (1 - fresnel) * refraction;

#ifdef FOG_ON
	half4 fogColor = GetExponentialHeightFog(-i.viewDir.xyz);
	color = color * fogColor.a + fogColor.rgb;
#endif

#ifdef HDR_ON
	color = lerp(originalRefraction, color, depthFade.r);
#endif

#ifndef POSTFX_ON
	color = sqrt(color);
#endif
	return half4(color, 1);
}
