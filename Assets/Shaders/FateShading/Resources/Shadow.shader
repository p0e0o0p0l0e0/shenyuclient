Shader "Fate Shading/Replace/Shadow"
{
	SubShader
	{
		Tags{"CasterShadow" = "CasterShadow" "LightMode" = "ForwardBase" }
		LOD 100

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
