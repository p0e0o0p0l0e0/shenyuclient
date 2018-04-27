// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

#include "UnityCG.cginc"

struct appdata
{
	float4 vertex : POSITION;
	float3 normal : NORMAL;
	fixed4 vertexcolor : COLOR;

#ifdef RANDOM_DISSOLVE_ON
	float2 uv : TEXCOORD0;
#endif
};

struct v2f
{
	float4 vertex : SV_POSITION;
	fixed4 vertexcolor : COLOR;
#ifdef USE_DEPTH
	float depth : TEXCOORD0;
#endif
#ifdef VERTICAL_DISSOLVE_ON
	half4 worldPos: TEXCOORD1;
#endif

#ifdef RANDOM_DISSOLVE_ON
	float2 uv : TEXCOORD2;
#endif
#ifdef USE_FOG
	float4 projPos : TEXCOORD3;
#endif
};

half _OutlineWidth;

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

v2f vert(appdata v)
{
	v2f o;
	float4 outlineVertex = float4(v.vertex.xyz + v.normal.xyz * _OutlineWidth * v.vertexcolor.a, 1);
	o.vertex = UnityObjectToClipPos(outlineVertex);

#ifdef HDR_ON
	o.vertexcolor.rgb = v.vertexcolor.rgb * v.vertexcolor.rgb;
	o.vertexcolor.a = v.vertexcolor.a;
#else
	o.vertexcolor = v.vertexcolor;
#endif

#ifdef USE_DEPTH
	o.depth = o.vertex.w;
#endif

#ifdef RANDOM_DISSOLVE_ON
	o.uv = v.uv;
#endif

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

#ifdef VERTICAL_DISSOLVE_ON
	half alpha = _StartHeight - (i.worldPos.y + _HeightDelta);
	if(alpha <= _GlowRange && alpha >= 0)
	{
		half value = alpha/_GlowRange;
		half flag = value > 0.5;
		if(flag ==1 && value > 0.85)
		{
			i.vertexcolor.a = 1;
		}
		else
		{
			value = flag == 1 ? (- 2 * (value + 0.15) + 2) : 2 * value ;
			i.vertexcolor = lerp(i.vertexcolor, _GlowColor, value);
			i.vertexcolor.a = flag == 0 ? value : 1;
		}
	}
	else if(alpha < 0)
	{
		i.vertexcolor.a = 0;
	}
#endif

#ifdef USE_FOG
	float scale = min(max(0, i.projPos.w - _StartDepth), _Depth)/_Depth;
	i.vertexcolor.rgb =lerp(i.vertexcolor.rgb  , _FogColor.rgb , scale * _FogColor.a);
#endif

#ifdef USE_ALPHA
 i.vertexcolor.a = _TintColor.a;
#endif

#ifdef USE_DEPTH
	return half4(i.vertexcolor.rgb, i.depth);
#else
	return half4(i.vertexcolor.rgb, i.vertexcolor.a);
#endif
}
