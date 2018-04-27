#include "UnityCG.cginc"

fixed4 _TintColor;

struct appdata_edge
{
	float4 vertex			: POSITION;
	fixed4 color			: COLOR;
	half3 normal			: NORMAL;
};

struct v2f_edge
{
	float4 vertex			: SV_POSITION;
	fixed4 color			: COLOR;
	half3 normal			: NORMAL;
	half3 viewDir			: TEXCOORD0;
};


v2f_edge vert_edge(appdata_edge v)
{
	v2f_edge o;
	float4 wPos = mul(unity_ObjectToWorld, v.vertex);
	o.vertex = mul(UNITY_MATRIX_VP, wPos);
	o.color = v.color * _TintColor;
	o.normal = UnityObjectToWorldNormal(v.normal);
	o.viewDir = _WorldSpaceCameraPos - wPos.xyz;
	return o;
}

half4 _Params;

half4 frag_edge(v2f_edge i) : SV_Target
{
	half4 col = i.color;
	col.rgb *= col.rgb;
#	ifdef HDR_ON
	col.rgb *= _Params.x;
#	else
	col.rgb *= _Params.y;
#	endif
	half3 N = normalize(i.normal);
	half3 V = normalize(i.viewDir);
	half NoV = max(dot(N, V), 0);
	half edge = pow(1 - NoV, _Params.z);
	col.a *= edge;
#	ifdef MIX_ADD
	col.rgb *= col.a;
#	endif
#	ifndef POSTFX_ON
	col.rgb = sqrt(col.rgb);
#	endif
	return col;
}

struct appdata_dissolve
{
	float4 vertex			: POSITION;
	fixed4 color			: COLOR;
	half3 normal			: NORMAL;
};

struct v2f_dissolve
{
	float4 vertex			: SV_POSITION;
	fixed4 color			: COLOR;
	half3 normal			: NORMAL;
	half3 viewDir			: TEXCOORD0;
};