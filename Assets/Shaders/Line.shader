Shader "Unlit/Line"
{
	Properties
	{
		_MainTex("Base (RGB), Alpha (A)", 2D) = "black" {}
		//_StencilComp("Stencil Comparison", Float) = 8
		//_Stencil("Stencil ID", Float) = 0
		//_StencilOp("Stencil Write Mask", Float) = 0
		//_StencilWriteMask("Stencil Write Mask", Float) = 255
		//_StencilReadMask("Stencil Read Mask", Float) = 255
		//_ColorMask("Color Mask", Float) = 15
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
	//	Stencil
	//{
	//	Ref[_Stencil]
	//	Comp[_StencilComp]
	//	Pass[_StencilOp]
	//	ReadMask[_StencilReadMask]
	//	WriteMask[_StencilWriteMask]
	//}
		//ColorMask[_ColorMask]
		Pass
	{
		Cull Off
		Lighting Off
		ZWrite Off
		//ZTest Off
		Fog{ Mode Off }
		Offset -1, -1
		Blend SrcAlpha One

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
		half4 color = tex2D(_MainTex, IN.texcoord) * IN.color;
		//if (IN.color.a < 0.01)
		//	color = Luminance(color);
		return color;
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
		//ZTest Off
		Fog{ Mode Off }
		Offset -1, -1
		Blend SrcAlpha OneMinusSrcAlpha
		ColorMaterial AmbientAndDiffuse

		SetTexture[_MainTex]
	{
		Combine Texture * Primary
	}
	}
	}
}
