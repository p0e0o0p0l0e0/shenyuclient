Shader "Unlit/SuperTextUV2"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_SecondTex ("Texture", 2D) = "white" {}
		_IsUseOutLine("_IsUseOutLine", Range(0, 1)) = 0
		_OutlineColor("Outline Color", Color) = (1,1,1,1)
		_OutlineWidth("Outline Width", Range(0, 2)) = 1
		_Threshold("Threshold", Range(0, 1)) = 0.5
		_Color("Color", Color) = (1,1,1,1)
			_StencilComp("Stencil Comparison", Float) = 8
			_Stencil("Stencil ID", Float) = 0
			_StencilOp("Stencil Write Mask", Float) = 0
			_StencilWriteMask("Stencil Write Mask", Float) = 255
			_StencilReadMask("Stencil Read Mask", Float) = 255
			_ColorMask("Color Mask", Float) = 15
	}
	SubShader
	{
		Tags
		{
			"Queue" = "Transparent"
			"IgnoreProjector" = "True"
			"RenderType" = "Transparent"
		}
			Stencil
		{
			Ref[_Stencil]
			Comp[_StencilComp]
			Pass[_StencilOp]
			ReadMask[_StencilReadMask]
			WriteMask[_StencilWriteMask]
		}
			ColorMask[_ColorMask]
		LOD 200

		Pass
		{
			Cull Off
			Lighting Off
			ZTest Off
			ZWrite Off
			Fog{ Mode Off }
			Blend SrcAlpha OneMinusSrcAlpha
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv1 : TEXCOORD0;
				float4 uv2 : TEXCOORD1;
				float4 uv3 : TEXCOORD2;
				fixed4 color : COLOR;
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
				float2 uv1 : TEXCOORD0;//main tex uv
				float2 uv2 : TEXCOORD1;//second tex uv
				float2 uv3 : TEXCOORD2;//third tex uv
				fixed4 color : COLOR;
			};

			sampler2D _MainTex;
			sampler2D _SecondTex;
			float4 _MainTex_ST;
			float4 _SecondTex_ST;

			float4 _OutlineColor;
			float4 _Color;
			float _OutlineWidth;
			float _Threshold;
			fixed _IsUseOutLine;
			float4 _MainTex_TexelSize;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv1 = TRANSFORM_TEX(v.uv1, _MainTex);// output uv1
				o.uv2 = TRANSFORM_TEX(v.uv2, _SecondTex);// output uv2
				o.uv3 = v.uv3;// output uv3
				o.color = v.color;
				return o;
			}
			
			fixed4 frag (v2f IN) : SV_TARGET
			{
				//if (_IsUseOutLine == 1)
				//{
				//	////以下是应用shader实现的描边,当前点周围的8个方向进行扫描
				//	//half4 col = tex2D(_MainTex, IN.uv1);
				//	//float width = _MainTex_TexelSize.z, height = _MainTex_TexelSize.w;

				//	//if (col.a <= _Threshold)
				//	//{
				//	//	half2 dir[8] = { { 0,1 },{ 1,1 },{ 1,0 },{ 1,-1 },{ 0,-1 },{ -1,-1 },{ -1,0 },{ -1,1 } };//8方向
				//	//	for (int i = 0; i < 8; i++)
				//	//	{
				//	//		float2 offset = float2(dir[i].x / width, dir[i].y / height);
				//	//		offset *= _OutlineWidth;

				//	//		half4 nearby = tex2D(_MainTex, IN.uv1 + offset) * IN.color;
				//	//		if (nearby.a > _Threshold)
				//	//		{
				//	//			col = _OutlineColor;
				//	//			break;
				//	//		}
				//	//	}
				//	//}
				//	//col = (1 - IN.uv3.x) * col + IN.uv3.x * tex2D(_SecondTex, IN.uv2);
				//	//return col;
				//}
				//else
				{
					half4 col = (1 - IN.uv3.x) * tex2D(_MainTex, IN.uv1).a * IN.color * _Color + IN.uv3.x * tex2D(_SecondTex, IN.uv2);
					return col;
				}
			}
			ENDCG
		}
	}
}
