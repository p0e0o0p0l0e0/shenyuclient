#include "UnityCG.cginc"
#include "Common.cginc"
#include "Noise.cginc"
#include "Fog.cginc"

#if defined(USE_PBR) || defined(USE_DISSOLVE)
#define USE_WORLD_POS
#endif

#if defined(USE_PBR) || defined(USE_FOCUS)
#define USE_NOV
#endif

#if defined(USE_PLANAR) && defined(PLANAR_ON)
#define USE_SCREEN_UV
#endif

struct appdata
{
	float4 vertex			: POSITION;
	half3 normal			: NORMAL;
#if defined(USE_NORMAL_MAP) || defined(USE_HAIR)
	half4 tangent			: TANGENT;
#endif
	float2 uv				: TEXCOORD0;
#ifdef USE_LIGHTMAP
	float2 uv1				: TEXCOORD3;
#endif
};

struct v2f
{
	float4 vertex			: SV_POSITION;
	half4 normal			: NORMAL;
#if defined(USE_NORMAL_MAP) || defined(USE_HAIR)
	half4 tangent			: TANGENT;
#endif
#ifdef USE_LIGHTMAP
	float4 uv				: TEXCOORD0;
#else
	float2 uv				: TEXCOORD0;
#endif
	half3 viewDir			: TEXCOORD1;
#if defined(USE_SCREEN_UV)
	float4 projPos			: TEXCOORD2;
#if defined(USE_WORLD_POS)
	float3 worldPos			: TEXCOORD3;
#endif
#elif defined(USE_WORLD_POS)
	float3 worldPos			: TEXCOORD2;
#endif
#ifdef FOG_ON
	fixed4 fogColor			: COLOR;
#endif
};

#ifdef USE_LIGHTMAP
float4 _LightMapUVParams;
half4 _LightMapScale0;
half4 _LightMapAdd0;
half4 _LightMapScale1;
half4 _LightMapAdd1;
sampler2D _LightMap;

half4 GetLightMapInfo(in float2 uv, in half3 N, out half shadow)
{
	float2 uv1 = uv * float2(1, 0.5);
	float2 uv0 = uv1 + float2(0, 0.5);
	half4 lightMap0 = tex2D(_LightMap, uv0);
	half4 lightMap1 = tex2D(_LightMap, uv1);

	half distanceField = lightMap0.a;
	const float size = 5;
	float distanceFieldBias = -0.5f * size + 0.5f;
	half shadowFactor = saturate(distanceField * size + distanceFieldBias);
	shadow = shadowFactor * shadowFactor;

	half3 logRGB = lightMap0.rgb * _LightMapScale0.xyz + _LightMapAdd0.xyz;
	half logL = dot(logRGB, half3(0.3, 0.59, 0.11));

	half l = exp2(logL * 16 - 8) - 0.00390625;

	half4 sh = lightMap1 * _LightMapScale1 + _LightMapAdd1;	// 1 vmad
	half directionality = max(0.0, dot(sh, half4(N.zy, -N.x, 1)));

	half luma = l * directionality;
	half3 color = logRGB * (luma / logL);				// 1 rcp, 1 smul, 1 vmul

	return half4(color, luma);
}
#endif

v2f vert(appdata v)
{
	v2f o;
	float4 wPos = mul(unity_ObjectToWorld, v.vertex);
	o.vertex = mul(UNITY_MATRIX_VP, wPos);
	o.normal.xyz = UnityObjectToWorldNormal(v.normal);
	o.normal.w = o.vertex.w;
#if defined(USE_NORMAL_MAP) || defined(USE_HAIR)
	o.tangent.xyz = UnityObjectToWorldDir(v.tangent.xyz);
	o.tangent.w = v.tangent.w;
#endif
	o.uv.xy = v.uv;
#ifdef USE_LIGHTMAP
	float2 flip_uv1 = float2(v.uv1.x, 1 - v.uv1.y);
	flip_uv1 = flip_uv1 * _LightMapUVParams.xy + _LightMapUVParams.zw;
	o.uv.zw = float2(flip_uv1.x, 1 - flip_uv1.y);
#endif
	o.viewDir = _WorldSpaceCameraPos - wPos.xyz;
#ifdef USE_SCREEN_UV
	o.projPos = ComputeScreenPos(o.vertex);
#endif
#ifdef USE_WORLD_POS
	o.worldPos = wPos;
#endif
#ifdef FOG_ON
	o.fogColor = GetExponentialHeightFog(wPos.xyz - _WorldSpaceCameraPos);
#endif
	return o;
}

#ifdef USE_SHOW
samplerCUBE _EnvTex;
#endif

sampler2D _MainTex;

#ifdef USE_NORMAL_MAP
sampler2D _NrmTex;
#endif

#if defined(USE_PBR) || defined(USE_HAIR)
sampler2D _MixTex;
#endif

#if defined(USE_PLANAR) && defined(PLANAR_ON)
sampler2D mirrorShadowRT;
#endif

#if (!defined(USE_SPEC_MAP)) || defined(USE_SKIN_SCATTER)
half _Specular;
#endif

#ifdef USE_SKIN_SCATTER
half4 _SkinParams;
half3 _SkinScatter;
#endif

#ifdef USE_GLOW
sampler2D _GlowTex;
half _GlowIntensity;
#endif

#ifdef USE_FOCUS
half4 _FocusColor;
#endif

#ifdef USE_DISSOLVE
half3 _Dissolve;
half3 _DissolveColor;
#endif

#ifdef USE_TERRAIN
sampler2D _BaseLayer0;
sampler2D _BaseLayer1;
sampler2D _Blend;
float3 _Tiling;
#endif

half3 _mainLightDirection;
half4 _mainLightColor;

#ifdef USE_ROLE
half3 _roleLighting;
#endif

half4 frag(v2f i) : SV_Target
{
	half4 baseColor = 0;
#ifdef USE_TERRAIN
	half4 blend = tex2D(_Blend, i.uv.xy);
	baseColor.rgb += blend.r * tex2D(_MainTex, i.uv.xy * _Tiling.x);
	baseColor.rgb += blend.g * tex2D(_BaseLayer0, i.uv.xy * _Tiling.y);
	baseColor.rgb += blend.b * tex2D(_BaseLayer1, i.uv.xy * _Tiling.z);
	baseColor.a = 1;
#else
	baseColor = tex2D(_MainTex, i.uv.xy);
#endif
	baseColor.rgb *= baseColor.rgb;

#if defined(USE_DISSOLVE)
	half disNoise = min((cnoise(i.worldPos * _Dissolve.x) + 1.) * 0.5, 0.999) - _Dissolve.y;
	baseColor.a *= disNoise + 0.5;
	clip(baseColor.a - 0.5);
	if (_Dissolve.z > 0)
	{
		disNoise = smoothstep(0, _Dissolve.z, disNoise);
	}
	else
	{
		disNoise = 1;
	}
#elif defined(USA_ALPHA_MASK)
	clip(baseColor.a - 0.5);
#endif

	half3 N = normalize(i.normal.xyz);
#ifdef USE_NORMAL_MAP
	half3 T = normalize(i.tangent.xyz);
	half3 B = cross(N, T) * i.tangent.w;
#ifdef USE_TERRAIN
	half3 normalMapColor = lerp(half3(0.5, 0.5, 1.0), tex2D(_NrmTex, i.uv.xy * _Tiling.x).rgb, blend.r);
#else
	half3 normalMapColor = tex2D(_NrmTex, i.uv.xy).rgb;
#endif
	N = GetNormalMappedNormal(normalMapColor, half3x3(T, B, N));
#endif

#ifdef USE_NOV
	half3 V = normalize(i.viewDir);
	half NoV = max(dot(N, V), 0);
#endif
	
#ifdef USE_PBR
	half3 R = normalize(reflect(-V, N));
	half extra;
	half roughness;
	half metallic;
#ifdef USE_TERRAIN
	half3 mixColor = lerp(half3(0, 1, 0), tex2D(_MixTex, i.uv.xy * _Tiling.x).rgb, blend.r);
#else
	half3 mixColor = tex2D(_MixTex, i.uv.xy).rgb;
#endif
	extra = mixColor.r;
	roughness = lerp(0.2, 1, mixColor.g);
	metallic = mixColor.b;
#if defined(USE_SPEC_MAP) && (!defined(USE_SKIN_SCATTER))
	half specLevel = extra;
#else
	half specLevel = _Specular;
#endif
	half dielectricSpecular = 0.08 * specLevel;
	half3 diffuseColor = baseColor - baseColor * metallic;	// 1 mad
	half3 specularColor = (dielectricSpecular - dielectricSpecular * metallic) + baseColor * metallic;	// 2 mad
	specularColor = EnvBRDFApprox(specularColor, roughness, NoV);
#else
	half3 diffuseColor = baseColor;
#endif

	half3 color = 0;
	half irradiance = 0;
	half shadow = 1;

#if defined(USE_LIGHTMAP)
	half4 lightInfo = GetLightMapInfo(i.uv.zw, N, shadow);
	color += lightInfo.rgb * diffuseColor;
	irradiance += lightInfo.a;
#elif defined(USE_SH_VOLUME)

#elif defined(USE_SHOW)
	half3 diffuseGI = RGBMDecode(texCUBElod(_EnvTex, half4(N, ENV_MIP_NUM)));
	color += diffuseColor * diffuseGI;
	irradiance += GetLuminance(diffuseGI);
#else
	half3 diffuseGI = lerp(0.5, 1, (N.y * 0.5 + 0.5));
#ifdef USE_ROLE
	diffuseGI *= _roleLighting.x;
#endif
	color += diffuseColor * diffuseGI;
	irradiance += GetLuminance(diffuseGI);
#endif

#if defined(USE_PLANAR) && defined(PLANAR_ON)
	half4 mirrorShadow = tex2Dproj(mirrorShadowRT, UNITY_PROJ_COORD(i.projPos));
	shadow *= mirrorShadow.a;
	color *= lerp(0.7, 1, mirrorShadow.a);
#endif

	half3 L = _mainLightDirection;
	half3 LC = _mainLightColor.rgb;
#ifndef HDR_ON
	LC *= _mainLightColor.a;
#endif
#ifdef USE_ROLE
	LC *= _roleLighting.z;
#endif
#ifdef USE_SHOW
	L = normalize(_WorldSpaceLightPos0.xyz);
#endif

	half NoL = max(0, dot(N, L)) * shadow;

#ifdef USE_PBR
	half RoL = max(0, dot(R, L));

#ifdef USE_SKIN_SCATTER
	color += NoL * LC * (diffuseColor * (1 - extra) + specularColor * PhongApprox(roughness, RoL));
	half NoL_wrap = (NoL + _SkinParams.r) / (1 + _SkinParams.r);
	half scatter = smoothstep(0.0, _SkinParams.g, NoL_wrap) * smoothstep(_SkinParams.g * 2.0, _SkinParams.g, NoL_wrap);
	color += (NoL_wrap + scatter * _SkinScatter) * extra * LC * diffuseColor;
#else
	color += NoL * LC * (diffuseColor + specularColor * PhongApprox(roughness, RoL));
#endif

	half absoluteSpecularMip = ComputeReflectionCaptureMipFromRoughness(roughness);
#ifdef USE_SHOW
	half3 specularIBL = RGBMDecode(texCUBElod(_EnvTex, half4(R, absoluteSpecularMip)));
#else
	half3 projectedCaptureVector = GetSphereCaptureVector(half3(-R.x, R.yz), i.worldPos,
		half4(unity_SpecCube0_ProbePosition.xyz, 0.5 * (unity_SpecCube0_BoxMax.x - unity_SpecCube0_BoxMin.x)));
	half3 specularIBL = RGBMDecode(UNITY_SAMPLE_TEXCUBE_LOD(unity_SpecCube0, projectedCaptureVector, absoluteSpecularMip)) * unity_SpecCube0_HDR.x;
#endif
	specularIBL = specularIBL * irradiance;
#ifdef USE_ROLE
	specularIBL *= _roleLighting.y;
#endif
	color += specularIBL * specularColor;
#else
	color += NoL * LC * diffuseColor;
#endif

#ifdef USE_GLOW
	half3 glowColor = tex2D(_GlowTex, i.uv.xy).rgb;
	color += glowColor * glowColor * _GlowIntensity;
#endif

#ifdef USE_FOCUS
	color += pow((1 - NoV), 2) * _FocusColor.rgb;
#endif

#ifdef USE_DISSOLVE
	color = lerp(_DissolveColor, color, disNoise);
#endif

#ifdef FOG_ON
	color = color * i.fogColor.a + i.fogColor.rgb;
#endif

#if defined(UI_DISPLAY) || (!defined(POSTFX_ON))
	color = sqrt(color);
#endif

	return half4(color, i.normal.w);
}

#ifdef USE_HAIR
half3 _PrimaryColor;
half3 _PrimaryParams;
half3 _SecondaryColor;
half3 _SecondaryParams;

half4 frag_hair(v2f i) : SV_Target
{
	half4 baseColor = tex2D(_MainTex, i.uv.xy);
#if defined(USE_DISSOLVE)
	half disNoise = min((cnoise(i.worldPos * _Dissolve.x) + 1.) * 0.5, 0.999) - _Dissolve.y;
	baseColor.a *= disNoise + 0.5;
	clip(baseColor.a - 0.5);
	if (_Dissolve.z > 0)
	{
		disNoise = smoothstep(0, _Dissolve.z, disNoise);
	}
	else
	{
		disNoise = 1;
	}
#elif defined(USA_ALPHA_MASK)
	clip(baseColor.a - 0.5);
#endif

	half3 N = normalize(i.normal.xyz);
#ifdef USE_NORMAL_MAP
	half3 T = normalize(i.tangent.xyz);
	half3 B = cross(N, T) * i.tangent.w;
#ifdef USE_TERRAIN
	half3 normalMapColor = lerp(half3(0.5, 0.5, 1.0), tex2D(_NrmTex, i.uv.xy * _Tiling.x).rgb, blend.r);
#else
	half3 normalMapColor = tex2D(_NrmTex, i.uv.xy).rgb;
#endif
	N = GetNormalMappedNormal(normalMapColor, half3x3(T, B, N));
#endif

	half specular;
	half shift;
	half noise1;
	half3 mixColor = tex2D(_MixTex, i.uv.xy).rgb;
	specular = mixColor.r;
	shift = mixColor.g;
	noise1 = mixColor.b;

	half3 L = _mainLightDirection;
	half3 LC = _mainLightColor.rgb;
#ifndef HDR_ON
	LC *= _mainLightColor.a;
#endif
#ifdef USE_ROLE
	LC *= _roleLighting.z;
#endif
	half3 V = normalize(i.viewDir);
	half3 H = normalize(V + L);

	half3 diffuseGI = (N.y * 0.5 + 0.5);
#ifdef USE_ROLE
	diffuseGI *= _roleLighting.x;
#endif
	half3 color = diffuseGI * baseColor;

	half NoL = max(0, dot(L, N));
	half NoL_wrap = (NoL + 0.2) / (1 + 0.2);
	color += NoL_wrap * LC * baseColor;
	half3 T1 = ShiftTangent(B, N, (shift + _PrimaryParams.g) * _PrimaryParams.b);
	half3 hair1 = HairSpecular(T1, H, _PrimaryParams.r) * _PrimaryColor;
	half3 T2 = ShiftTangent(B, N, (shift + _SecondaryParams.g) * _SecondaryParams.b);
	half3 hair2 = HairSpecular(T2, H, _SecondaryParams.r) * _SecondaryColor * noise1;
	//color += specular * LC * (hair1 + hair2);

#if defined(UI_DISPLAY) || (!defined(POSTFX_ON))
	color = sqrt(color);
#endif

	return half4(color, i.normal.w);
}
#endif
