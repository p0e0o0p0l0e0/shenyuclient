// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Fate Shading/Gem"
{
	Properties {
		_MainTex ("DiffuseTexture", 2D) = "white" {}
		_Color ("Color", Color) = (1,1,1,1)
		_ReflectionStrength ("Reflection Strength", Range(0.0,10.0)) = 1.0
		_EnvironmentLight ("Environment Light", Range(0.0,10.0)) = 1.0
		_Emission ("Emission", Range(0.0,10.0)) = 0.0
		[NoScaleOffset] _RefractTex ("Refraction Texture", Cube) = "" {}
		_Reflection("_Reflection", 2D) = "black" {}
		_ReflectPower("_ReflectPower", Range(0,1) ) = 0
	}
	SubShader {
		Tags { "Queue" = "Transparent" }

		Pass {

			Cull Front
			ZWrite Off

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma fragmentoption ARB_precision_hint_fastest
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
				float3 normal : NORMAL;
			};

			struct v2f {
				float4 pos : SV_POSITION;
				float2 uv : TEXCOORD0;
				float3 uvRef : TEXCOORD1;
			};

			v2f vert (appdata v)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				float3 viewDir = normalize(ObjSpaceViewDir(v.vertex));
				o.uv = v.uv;
				o.uvRef = -reflect(viewDir, v.normal);
				o.uvRef = mul(unity_ObjectToWorld, float4(o.uvRef,0));
				return o;
			}

			sampler2D _MainTex;
			fixed4 _Color;
			samplerCUBE _RefractTex;
			half _EnvironmentLight;
			half _Emission;
			half4 frag (v2f i) : SV_Target
			{
				fixed4 col =  tex2D(_MainTex, i.uv);
				half3 refraction = texCUBE(_RefractTex, i.uvRef).rgb * _Color.rgb * col.rgb;
				half3 multiplier = _EnvironmentLight + _Emission;
				return half4(refraction.rgb * multiplier.rgb, 1.0f);
			}
			ENDCG 
		}
		
		Pass {
			ZWrite On
			Blend One One
			
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma fragmentoption ARB_precision_hint_fastest
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
				float3 normal : NORMAL;
			};

			struct v2f {
				float4 pos : SV_POSITION;
				float2 uv : TEXCOORD0;
				half fresnel : TEXCOORD1;
				float3 uvRef : TEXCOORD2;
				float2 reflexUV: TEXCOORD3;
			};

			v2f vert (appdata v)
			{
				v2f o;
				o.uv = v.uv;
				o.pos = UnityObjectToClipPos(v.vertex);
				float3 viewDir = normalize(ObjSpaceViewDir(v.vertex));
				o.uvRef = -reflect(viewDir, v.normal);
				o.uvRef = mul(unity_ObjectToWorld, float4(o.uvRef,0));
				o.fresnel = 1.0 - saturate(dot(v.normal,viewDir));
				o.reflexUV = float2((viewDir.x + 1) * 0.5, (viewDir.y + 1) * 0.5);
				return o;
			}

			sampler2D _MainTex;
			fixed4 _Color;
			samplerCUBE _RefractTex;
			half _ReflectionStrength;
			half _EnvironmentLight;
			half _Emission;
			sampler2D _Reflection;
			float _ReflectPower;

			half4 frag (v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.uv);
				float4 reflectCol=tex2D(_Reflection,i.reflexUV);
				half3 refraction = texCUBE(_RefractTex, i.uvRef).rgb * _Color.rgb * col.rgb;
				half3 reflection2 = _ReflectionStrength * i.fresnel * reflectCol * _ReflectPower;
				half3 multiplier =  _EnvironmentLight + _Emission;
				return fixed4(reflection2 + refraction.rgb * multiplier, 1.0f);
			}
			ENDCG
		}

		UsePass "VertexLit/SHADOWCASTER"
	}
}
