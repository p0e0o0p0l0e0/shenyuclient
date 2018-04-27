// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "ViCross/AirflowAdd" {
Properties {
	_TintColor ("Tint Color", Color) = (0.5,0.5,0.5,0.5)
	_MainTex ("Particle Texture", 2D) = "white" {}
	_InvFade ("Soft Particles Factor", Range(0.01,3.0)) = 1.0
	[HideInInspector]_Depth("Depth", float) = 50
	[HideInInspector]_farClip("_farClip", float) = 1000
}

Category {
	Tags { "Queue"="Transparent+100" "IgnoreProjector"="True" "RenderType"="Transparent" }
	ZWrite Off
	ZTest Always
	                 
	Blend SrcAlpha One
	ColorMask RGB
	Lighting Off 
	
	SubShader {
		Pass {
		
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile_particles
			#pragma multi_compile_fog

			#include "UnityCG.cginc"

			sampler2D _MainTex;
			fixed4 _TintColor;
			struct appdata_t {
				float4 vertex : POSITION;
				fixed4 color : COLOR;
				float2 texcoord : TEXCOORD0;
			};

			struct v2f {
				float4 vertex : SV_POSITION;
				fixed4 color : COLOR;
				float2 texcoord : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 projPos : TEXCOORD2;
			};
			
			float4 _MainTex_ST;
			float _farClip;

			v2f vert (appdata_t v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.projPos = ComputeScreenPos (o.vertex);
				o.color = v.color;
				o.texcoord = TRANSFORM_TEX(v.texcoord,_MainTex);
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}

			sampler2D_float _CameraDepthTexture;
			float _Depth;

			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col = 2.0f * i.color * _TintColor * tex2D(_MainTex, i.texcoord);
				float depth = tex2Dproj(_CameraDepthTexture,UNITY_PROJ_COORD(i.projPos)).r;
				depth = Linear01Depth (depth);	
				//
				float vertexDepth = i.projPos.z/i.projPos.w;
				vertexDepth = Linear01Depth (vertexDepth);	
				//
				_Depth = _Depth/_farClip;
				float scale=0;
				if(depth!=1)
					scale = min(max(depth - vertexDepth, 0), _Depth)/_Depth;
				col*= scale;
				return col;
			}
			ENDCG 
		}
	}	
}
}
