// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

#include "UnityCG.cginc"

struct appdata
{
	float4 vertex : POSITION;
	half3 normal : NORMAL;
#ifdef SPEC_HAIR
	half4 tangent : TANGENT;
#endif
	float2 uv : TEXCOORD0;
	fixed4 vertexcolor : COLOR;
};

struct v2f
{
	float4 vertex : SV_POSITION;
	half4 normal : NORMAL;
#ifdef SPEC_HAIR
	half3 tangent : TANGENT;
#endif
	float2 uv : TEXCOORD0;
	half3 viewDir : TEXCOORD1;
	half3 lightDir : TEXCOORD2;
	fixed4 vertexcolor : COLOR;
#ifdef VERTICAL_DISSOLVE_ON
	half4 worldPos: TEXCOORD3;
#endif
#ifdef USE_FOG
	float4 projPos : TEXCOORD3;
#endif
};

sampler2D _MainTex;
sampler2D _MatTex;
sampler2D _DiffuseRampTex;
sampler2D _SpecRampTex;
half4 _DiffuseRampTex_TexelSize;
half4 _EdgeColor;
half4 _Emission;

#ifdef USE_GLOW
sampler2D _GlowTex;
#endif

#ifdef SPEC_METAL
sampler2D _AnimeEnvTex;
sampler2D _SceneEnvTex;
half4 _EnvParams;
#endif

#ifdef SPEC_HAIR
half4 _HairParams;
#endif

#ifdef HDR_ON
half4 _LightParamsHDR;
#else
half4 _LightParams;
#endif

#ifdef VERTICAL_DISSOLVE_ON
half _GlowRange;
half _StartHeight;
fixed4 _GlowColor;
half _HeightDelta;
#endif

#ifdef RANDOM_DISSOLVE_ON
sampler2D _DissolveSrc;
half _Duration;
#endif

#ifdef USE_FOG
float _StartDepth;
float _Depth;
half4 _FogColor;
#endif

#ifdef USE_ALPHA
fixed4 _TintColor;
#endif

half3 EnvBRDFApprox(half3 SpecularColor, half NoV)
{
	// [ Lazarov 2013, "Getting More Physical in Call of Duty: Black Ops II" ]
	// Adaptation to fit our G term.
	const half4 c0 = { -1, -0.0275, -0.572, 0.022 };
	const half4 c1 = { 1, 0.0425, 1.04, -0.04 };
	half4 r = 0.1 * c0 + c1;
	half a004 = min(r.x * r.x, exp2(-9.28 * NoV)) * r.x + r.y;
	half2 AB = half2(-1.04, 1.04) * a004 + r.zw;

	return SpecularColor * AB.x + AB.y;
}

half3 ShiftTangent(half3 T, half3 N, half shift)
{
	return normalize(T + shift * N);
}

half StrandSpecular(half3 T, half3 H, half exponent)
{
	half dotTH = dot(T, H);
	half sinTH = sqrt(1 - dotTH * dotTH);
	half dirAtten = smoothstep(-1, 0, dotTH);
	return dirAtten * pow(sinTH, exponent);
}

v2f vert(appdata v)
{
	v2f o;
	o.vertex = UnityObjectToClipPos(v.vertex);
	o.normal.xyz = UnityObjectToWorldNormal(v.normal);
	o.normal.w = o.vertex.w;
#ifdef SPEC_HAIR
	half sign = half(v.tangent.w) * half(unity_WorldTransformParams.w);
	o.tangent.xyz = cross(o.normal.xyz, UnityObjectToWorldDir(v.tangent)) * sign;
#endif
	o.viewDir = WorldSpaceViewDir(v.vertex);
	o.lightDir = WorldSpaceLightDir(v.vertex);
	o.uv = v.uv;
	o.vertexcolor.rgb = v.vertexcolor.rgb * v.vertexcolor.rgb;
	o.vertexcolor.a = v.vertexcolor.a;
	//
#ifdef VERTICAL_DISSOLVE_ON
	o.worldPos = mul(unity_ObjectToWorld, v.vertex);
#endif
#ifdef USE_FOG
	o.projPos = ComputeScreenPos(o.vertex);
#endif
	return o;
}

half4 frag(v2f i) : SV_Target
{
#ifdef RANDOM_DISSOLVE_ON
	half ClipTex = tex2D(_DissolveSrc, i.uv).r;
	clip(_Duration - ClipTex);
#endif
	
	half4 base = tex2D(_MainTex, i.uv);
	half4 mat = tex2D(_MatTex, i.uv);

	half3 N = normalize(i.normal.xyz);
	half3 V = normalize(i.viewDir);
	half3 L = i.lightDir;
	half3 H = normalize(V + L);

#ifdef SPEC_HAIR
	half3 B = i.tangent;
#endif

#ifdef SPEC_METAL
	half3 R = normalize(reflect(-V, N));
#endif

#ifdef HDR_ON
	half4 params = _LightParamsHDR;
#else
	half4 params = _LightParams;
#endif

	half4 tbias;

	tbias.xy = _DiffuseRampTex_TexelSize.xy * 0.5;
	tbias.zw = half2(1.0, 1.0) - tbias.xy;

	half nov = dot(N, V);
	half edge = tex2D(_DiffuseRampTex, lerp(tbias.xy, tbias.zw, half2(mat.g, nov))).a;
	half ndotl = dot(L, N);
	edge = saturate(-ndotl * edge);
	half3 diffuse = tex2D(_DiffuseRampTex, lerp(tbias.xy, tbias.zw, half2(mat.g, 0.5 - ndotl * 0.5))).rgb;
	diffuse = params.x * lerp(diffuse, _EdgeColor, edge);

#ifdef SPEC_HAIR
	half3 T1 = ShiftTangent(B, N, (mat.b + _HairParams.x) * _HairParams.y);
	half hair1 = StrandSpecular(T1, H, params.z);
	half3 spec1 = tex2D(_SpecRampTex, half2(0.25, lerp(tbias.w, tbias.y, hair1))).rgb;
	half3 T2 = ShiftTangent(B, N, (mat.b + _HairParams.z) * _HairParams.w);
	half hair2 = StrandSpecular(T2, H, params.w);
	half3 spec2 = tex2D(_SpecRampTex, half2(0.75, lerp(tbias.w, tbias.y, hair2))).rgb;
	half3 specular = (mat.r * params.y * (1.0 - edge)) * (spec1 + spec2);
#else
	half pow_ndoth = pow(saturate(dot(N, H)), params.z);
	half3 specular = tex2D(_SpecRampTex, lerp(tbias.xy, tbias.zw, float2(mat.g, 1.0 - pow_ndoth))).rgb;
	specular *= mat.r * params.y;
#endif

#ifdef SPEC_METAL
	half metallic = mat.b;
	half filp_metallic = 1.0 - metallic;
	half3 diffuseColor = base.rgb * filp_metallic;
	half3 specularColor = EnvBRDFApprox(base.rgb, nov) * metallic;

	half2 ref_tex = R.xy * half2(0.5, -0.5) + 0.5;
	half3 anime = tex2D(_AnimeEnvTex, ref_tex).rgb;
	half3 scene = tex2D(_SceneEnvTex, ref_tex).rgb;
#	ifdef HDR_ON  			
	half3 env = anime * _EnvParams.z + scene * _EnvParams.w;
#	else
	half3 env = anime * _EnvParams.x + scene * _EnvParams.y;
#	endif
	half3 color = diffuse * diffuseColor + env * specularColor;
#else
	half3 color = diffuse * base.rgb;
#endif

#if defined(USE_GLOW) && defined(HDR_ON) && (!defined(SPEC_HAIR))
	half3 glow = tex2D(_GlowTex, i.uv.xy).rgb;
	color += glow * glow * params.w;
#endif

	color = lerp(i.vertexcolor.rgb, color * color + specular, base.a);

#ifndef HDR_ON
	color = pow(color, 0.5);
#endif

#ifdef VERTICAL_DISSOLVE_ON
	half alpha = _StartHeight - (i.worldPos.y + _HeightDelta);
	if(alpha <= _GlowRange && alpha >= 0)
	{
		half value = alpha/_GlowRange;
		half flag = value > 0.5;
		if(flag ==1 && value > 0.85)
		{
			base.a = 1;
		}
		else
		{
			value = flag == 1 ? (- 2 * (value + 0.15) + 2) : 2 * value ;
			color = lerp(color, _GlowColor, value);
			base.a = flag == 0 ? value : 1;
		}
	}
	else if(alpha < 0)
	{
		base.a = 0;
	}
#endif
	color += _Emission.rgb;
#ifdef USE_FOG
	float scale = min(max(0, i.projPos.w - _StartDepth), _Depth)/_Depth;
	color.rgb =lerp(color.rgb  , _FogColor.rgb , scale * _FogColor.a);
#endif

#ifdef USE_ALPHA
base.a = _TintColor.a;
#endif

#ifdef USE_DEPTH
	return half4(color , i.normal.w);
#else
	return half4(color, base.a);
#endif
}
