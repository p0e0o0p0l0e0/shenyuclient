Shader "Unlit/IconShader"
{
	Properties 
	{
		_MainTex("Base", 2D) = "black" {} 
		_MaskTex("MaskTex", 2D) = "white" {}
		_UUnit("U_Unit", Range(0,10)) = 0
		_VUnit("V_Unit", Range(0,10)) = 0
		//_UnitSpan("Span Between Unit", Range(0,10)) = 1
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
		Fog{ Mode Off }
		Offset -1, -1
		Blend SrcAlpha OneMinusSrcAlpha 

		CGPROGRAM
	#pragma vertex vert
	#pragma fragment frag			
	#include "UnityCG.cginc"

	sampler2D _MainTex;
	sampler2D _MaskTex;
	float _UUnit;
	float _VUnit;
	//float _UnitSpan;
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
		o.texcoord = v.texcoord;
		o.color = v.color;
		return o;
	}

	fixed4 frag(v2f IN) : COLOR
	{
		half4 col = tex2D(_MainTex, IN.texcoord) * IN.color;
		float offsetU = 1 / _UUnit;
		float offsetV = 1 / _VUnit;
		float finalU = IN.texcoord.x % (1 / _UUnit) * _UUnit;
		float finalV = IN.texcoord.y % (1 / _VUnit) * _VUnit;
		float2 mapUV = float2(finalU, finalV);
		col.a = tex2D(_MaskTex, mapUV) * col.a;
		return col;
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
