Shader "Fate Shading/Replace/MirrorShadow"
{
	Properties
	{
		_MainTex("Base (RGB)", 2D) = "white" {}
		_MirrorParams("(Fade,Intensity,,)", Vector) = (0.7, 0.5, 0, 0)
	}

	SubShader
	{
		Tags{ "CasterShadow" = "CasterShadow"  "CasterMirror" = "CasterMirror" "LightMode" = "ForwardBase" }
		LOD 100

		Pass
		{
			Cull Front
			ZTest Less
			ZWrite On
			ColorMask RGB
			Lighting Off
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			//#pragma exclude_renderers d3d9 d3d11_9x
			#pragma multi_compile __ HDR_ON
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
				float3 uv : TEXCOORD0;
			};

			sampler2D _MainTex;
			half4 _MirrorPlane;
			half4 _MirrorParams;

			v2f vert(appdata v)
			{
				v2f o;
				float4 wPos = mul(unity_ObjectToWorld, v.vertex);

				o.uv.xy = v.uv;
				o.uv.z = dot(wPos, _MirrorPlane.xyz) + _MirrorPlane.w;

				float dist = dot(float3(0, -_MirrorPlane.w, 0) - wPos, _MirrorPlane.xyz) / dot(_MirrorPlane.xyz, _MirrorPlane.xyz);
				wPos.xyz = wPos.xyz + 2 * dist * _MirrorPlane.xyz;
				o.vertex = mul(UNITY_MATRIX_VP, wPos);
				
				return o;
			}
			
			half4 frag (v2f i) : SV_Target
			{
				half4 base = tex2D(_MainTex, i.uv.xy);
#				ifdef HDR_ON
				base.rgb *= base.rgb;
#				endif
				half fade = (1.0 - saturate(i.uv.z * _MirrorParams.x)) * _MirrorParams.y;
				return half4(base.rgb * fade, 1);
			}
			ENDCG
		}

		Pass
		{
			Cull Back
			ZTest Always
			ZWrite Off
			ColorMask A

			Stencil
			{
				Ref 128
				Comp NotEqual
				Pass Replace
				Fail Keep
			}

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			//#pragma exclude_renderers d3d9 d3d11_9x
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
			};

			half4 _MirrorPlane;

			v2f vert(appdata v)
			{
				v2f o;
				float4 wPos = mul(unity_ObjectToWorld, v.vertex);
				float3 direction = normalize(_WorldSpaceLightPos0.xyz);
				float dist = dot(float3(0, -_MirrorPlane.w, 0) - wPos, _MirrorPlane.xyz) / dot(direction, _MirrorPlane.xyz);
				wPos.xyz = wPos.xyz + dist * direction;
				o.vertex = mul(UNITY_MATRIX_VP, wPos);
				return o;
			}
			
			half4 frag (v2f i) : SV_Target
			{
				return half4(0, 0, 0, 0);
			}
			ENDCG
		}
	}
}
