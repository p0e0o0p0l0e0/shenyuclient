// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Unlit/Transparent Colored"
{
	Properties
	{
		_MainTex ("Base (RGB), Alpha (A)", 2D) = "black" {}
		_StencilComp("Stencil Comparison", Float) = 8
		_Stencil("Stencil ID", Float) = 0
		_StencilOp("Stencil Write Mask", Float) = 0
		_StencilWriteMask("Stencil Write Mask", Float) = 255
		_StencilReadMask("Stencil Read Mask", Float) = 255
		_ColorMask("Color Mask", Float) = 15
	}
	
	SubShader
	{
		LOD 200

		Tags
		{
			"Queue" = "Transparent"
			"IgnoreProjector" = "True"
			"RenderType" = "Transparent"
		}
		Stencil
		{
			Ref [_Stencil]
			Comp [_StencilComp]
			Pass [_StencilOp]
			ReadMask [_StencilReadMask]
			WriteMask [_StencilWriteMask]
		}
			ColorMask[_ColorMask]
		Pass
		{
			Cull Off
			Lighting Off
			ZWrite Off
			Fog { Mode Off }
			Offset -1, -1
			Blend SrcAlpha OneMinusSrcAlpha

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag			
			#include "UnityCG.cginc"

			sampler2D _MainTex;
			float4 _MainTex_ST;
	
			struct appdata_t
			{
				float4 vertex : POSITION;
				float2 texcoord : TEXCOORD0;
				//float3 normal : NORMAL;
				half4 color : COLOR;
			};
	
			struct v2f
			{
				float4 vertex : SV_POSITION;
				float2 texcoord : TEXCOORD0;
				//float3 uvinfo : TEXCOORD1;
				half4 color : COLOR;
			};
	
			v2f o;

			v2f vert (appdata_t v)
			{
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);//use TRANSFORM_TEX to set tiling and offset avaliable
				//o.uvinfo = v.normal;
				o.color = v.color;
				return o;
			}
				
			fixed4 frag (v2f IN) : SV_TARGET
			{
				half4 color = tex2D(_MainTex, IN.texcoord);
				//luminance
				fixed flag = step(IN.color.a, 0.01);
				color = (1 - flag) * color * IN.color + flag * Luminance(color) * color.a;
			//if (IN.color.a <= 0.01)
			//	color = Luminance(color) * color.a;
			//color.a = color.a * IN.color.a;
				//color = Luminance(color);
				//gradinet
				//flag = step(1, IN.uvinfo.x);
				//fixed changeFactor = IN.uvinfo.x - 2;
				//fixed factor = IN.uvinfo.y;
				//fixed leftDistance = IN.uvinfo.z - factor;
				//fixed finalAlpha = saturate(1- (changeFactor * saturate(IN.texcoord.x - factor)) / leftDistance);
				//fixed alpha = color.a * finalAlpha;
				//color.a = flag * alpha + (1 - flag) * color.a;
				return color;
			}
			ENDCG
		}
	}

}
