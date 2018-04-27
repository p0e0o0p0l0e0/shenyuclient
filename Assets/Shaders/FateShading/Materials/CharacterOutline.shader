// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Fate Shading/Character/CharacterOutline"
{
	Properties
	{
		_OutlineWidth ("OutlineWidth", Float) = 0.005
		_VertexColor ("VertexColor", Color) = (1,1,1,1)

		_RenderQueue ("RenderQueue", Float) = 2000
	}

	SubShader
	{
		Tags {"Queue" = "Geometry" "RenderType"="Opaque" "LightMode" = "ForwardBase" }
		LOD 100
		Cull Front
		ZTest Less
		ZWrite On

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"
			#include "Lighting.cginc"
			#include "AutoLight.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				half3 normal : NORMAL;
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
			};

			half _OutlineWidth;

			half4 _VertexColor;

			v2f vert (appdata v)
			{
				v2f o;
				float4 outlineVertex = float4(v.vertex.xyz + v.normal.xyz * _OutlineWidth, 1);
				o.vertex = UnityObjectToClipPos(outlineVertex);
				return o;
			}
			
			half4 frag (v2f i) : SV_Target
			{
				return _VertexColor;
			}

			ENDCG
		}
	}
	CustomEditor "VFXShaderInspector"
}
