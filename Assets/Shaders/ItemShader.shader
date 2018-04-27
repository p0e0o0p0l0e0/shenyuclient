Shader "Unlit/ItemShader"
{
	Properties
	{
		_MainTex("Base", 2D) = "black" {}
		_SencondTex("SecondTex", 2D) = "white" {}
		_SecondScale("SecondScale", Range(0,1)) = 1
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
			Ref[_Stencil]
			Comp[_StencilComp]
			Pass[_StencilOp]
			ReadMask[_StencilReadMask]
			WriteMask[_StencilWriteMask]
		}
			ColorMask[_ColorMask]
		Pass
		{
			Cull Off
			Lighting Off
			ZWrite Off
			Fog{ Mode Off }
			Offset -1, -1
			Blend SrcAlpha OneMinusSrcAlpha

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag			
			#include "UnityCG.cginc"

			sampler2D _MainTex;
			sampler2D _SencondTex;
			float4 _MainTex_ST;
			float _SecondScale;

			struct appdata_t
			{
				float4 vertex : POSITION;
				float2 texcoord : TEXCOORD0;
				fixed4 color : COLOR;
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
				half2 texcoord : TEXCOORD0;
				fixed4 color : COLOR;
			};

			v2f o;

			v2f vert(appdata_t v)
			{
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);//use TRANSFORM_TEX to set tiling and offset avaliable
				o.color = v.color;
				return o;
			}

			fixed4 frag(v2f IN) : COLOR
			{
				half offset = 0.5 - 0.5 * _SecondScale;// (1 - _SecondScale) / 2;
				half offset_a = 0.5 + 0.5 * _SecondScale;
				half reciprocalScale = 1 / _SecondScale;
				float2 finalUV = float2((IN.texcoord.x * reciprocalScale - 0.5 * reciprocalScale + 0.5), (IN.texcoord.y * reciprocalScale - 0.5 * reciprocalScale + 0.5));

				half4 col_back = tex2D(_MainTex, IN.texcoord) * IN.color;		
				half4 col_second = tex2D(_SencondTex, finalUV) * IN.color;

				float flag = (step(offset, IN.texcoord.x) * step(IN.texcoord.x, offset_a) * step(offset, IN.texcoord.y) * step(IN.texcoord.y, offset_a));
				return (col_second.a * col_second + (1 - col_second.a) * col_back) * flag + col_back * (1 - flag);

			}
		ENDCG
		}
	}

	SubShader
	{
		LOD 100

		Tags
		{
			"Queue" = "Transparent"
			"IgnoreProjector" = "True"
			"RenderType" = "Transparent"
		}

		Pass
		{
			Cull Off
			Lighting Off
			ZWrite Off
			Fog{ Mode Off }
			Offset -1, -1
			ColorMask RGB
			Blend SrcAlpha OneMinusSrcAlpha
			ColorMaterial AmbientAndDiffuse

			SetTexture[_MainTex]
			{
				Combine Texture * Primary
			}
		}
	}
}
