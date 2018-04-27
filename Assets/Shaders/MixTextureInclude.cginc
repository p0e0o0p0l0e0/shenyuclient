// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'


#include "UnityCG.cginc"

		struct appdata
		{
			float4 vertex : POSITION;
			float2 uv : TEXCOORD0;
			float2 uv1 : TEXCOORD1;
		};

		struct v2f
		{
			float2 uv : TEXCOORD0;
			float4 uv01 : TEXCOORD1;
			float4 uv02 : TEXCOORD2;
#ifdef USE_WATER_REFLECTION
			float2 uv03 : TEXCOORD3;
#endif
			float4 vertex : SV_POSITION;
#if defined(USE_SHADOW_MIRROR) || defined(USE_DEPTH)
			float4 projPos : TEXCOORD4;
#endif
			#ifdef CLOUD_SHADOW
			float4 posWorld : TEXCOORD5;
			#endif
		};

		#ifdef BLEND_ON
		half _Weight;
		#endif

		sampler2D _ChannelTexture;
		sampler2D _ChannelR;
		sampler2D _ChannelG;
		sampler2D _ChannelB;

		float4 _ChannelTexture_ST;
		float4 _ChannelR_ST;
		float4 _ChannelG_ST;
		float4 _ChannelB_ST;

		#ifdef USE_SHADOW
		sampler2D _MirrorShadowTex;
		float4 _MirrorShadowTex_TexelSize;
		half4 _MirrorColor;
		half4 _ShadowColor;
		#endif

		#if defined(USE_FOG) && defined(USE_DEPTH)
		sampler2D _AirFlowTex;
		float4 _AirFlowTex_ST;
		float _AirFlowStartDepth;
		float _AirFlowDepth;
		half4 _AirFlowColor;
		half2 _AirFlowOffset;
		
		float _StartDepth;
		float _Depth;
		half4 _FogColor;
		#endif

		#ifdef USE_DEPTH
		float _ColorScale;
		#endif

		#ifdef CLOUD_SHADOW
		sampler2D _CloudShadow;
		fixed4 _CloudShadowColor;
		half4 _Params;
		#endif

		#ifdef USE_WATER_REFLECTION
		fixed4 _WaterColor;
		half4 _WaterParam;
		sampler2D _ChannelA;
		float4 _ChannelA_ST;
		#endif

		#ifdef BLEND_ON
		inline half4 Blend(half depth1 ,half depth2,half depth3 , half4 control) 
		{
			half4 blend ;
			blend.r =depth1 * control.r;
			blend.g =depth2 * control.g;
			blend.b =depth3 * control.b;
			half ma = max(blend.r, max(blend.g, blend.b));
			blend = max(blend - ma +_Weight , 0) * control;
			return blend/(blend.r + blend.g + blend.b);
		}
		#endif

		v2f vert (appdata v)
		{
			v2f o;
			o.vertex = UnityObjectToClipPos(v.vertex);

			#if defined(USE_SHADOW_MIRROR) || defined(USE_DEPTH)
			o.projPos = ComputeScreenPos(o.vertex);
			#endif

			o.uv = v.uv1 * unity_LightmapST.xy + unity_LightmapST.zw;
			o.uv01.xy = TRANSFORM_TEX(v.uv, _ChannelTexture);
			o.uv01.zw = TRANSFORM_TEX(v.uv, _ChannelR);
			o.uv02.xy = TRANSFORM_TEX(v.uv, _ChannelG);
			o.uv02.zw = TRANSFORM_TEX(v.uv, _ChannelB);
			#ifdef USE_WATER_REFLECTION
			o.uv03.xy = v.uv.xy * _WaterParam.xy + _WaterParam.w * _Time.xy;;
			#endif

			#ifdef CLOUD_SHADOW
			o.posWorld = mul(unity_ObjectToWorld, v.vertex);
			#endif

			return o;
		}
			
		fixed4 frag (v2f i) : SV_Target
		{
			fixed4 bakedColorTex = UNITY_SAMPLE_TEX2D(unity_Lightmap, i.uv);
			half3 bakedColor = DecodeLightmap(bakedColorTex);
			fixed4 col=tex2D(_ChannelTexture, i.uv01.xy);
			fixed4 r=tex2D(_ChannelR, i.uv01.zw);
			fixed4 g=tex2D(_ChannelG, i.uv02.xy);
			fixed4 b=tex2D(_ChannelB, i.uv02.zw);

			fixed4 finalcolor;
			#ifdef BLEND_ON
				half4 blend = Blend(r.a, g.a, b.a, col);
				finalcolor.rgb = blend.r * r.rgb + blend.g * g.rgb + blend.b * b.rgb;
			#else
				finalcolor.rgb = col.r*r+col.g*g+col.b*b;
			#endif

			finalcolor.rgb  = finalcolor.rgb * bakedColor.rgb;

		#if defined(USE_SHADOW_MIRROR) &&(defined(ENABLE_SHADOW) || defined(ENABLE_MIRROR))
			#ifdef USE_WATER_REFLECTION
			float2 shadowUV = i.projPos.xy / i.projPos.w;
			fixed4 mirrorShadow = tex2D(_MirrorShadowTex, shadowUV);
			//fixed4 a=tex2D(_ChannelA, i.uv03.xy);
			#ifdef ENABLE_MIRROR
				finalcolor.rgb = lerp(finalcolor.rgb, _WaterColor.rgb * finalcolor.rgb + mirrorShadow.rgb * _MirrorColor.rgb, col.a);
			#endif
			#ifdef ENABLE_SHADOW
				finalcolor.rgb *= lerp(_ShadowColor, half3(1, 1, 1), mirrorShadow.a);
			#endif
		#else 
			float2 shadowUV = i.projPos.xy / i.projPos.w;
			half4 mirrorShadow = tex2D(_MirrorShadowTex, shadowUV);
			#ifdef ENABLE_SHADOW
				finalcolor.rgb *= lerp(_ShadowColor, half3(1, 1, 1), mirrorShadow.a);
			#endif
			#ifdef ENABLE_MIRROR
				finalcolor.rgb += mirrorShadow.rgb * _MirrorColor.rgb;
			#endif
		#endif
	#endif

			#if defined(USE_FOG) && defined(USE_DEPTH)
		    half2 uv = i.projPos.xy /  i.projPos.w;
			uv = TRANSFORM_TEX(uv, _AirFlowTex);
			half4 fogColor = tex2D(_AirFlowTex,  uv + _AirFlowOffset) * _AirFlowColor;
			float scale = min(max(0, i.projPos.w - _AirFlowStartDepth), _AirFlowDepth)/_AirFlowDepth;
			finalcolor.rgb =lerp(finalcolor.rgb  , fogColor.rgb , scale * fogColor.a);

			scale = min(max(0, i.projPos.w - _StartDepth), _Depth)/_Depth;
			finalcolor.rgb =lerp(finalcolor.rgb  , _FogColor.rgb , scale * _FogColor.a);
			#endif

			#ifdef CLOUD_SHADOW
			float2 uv01 = i.posWorld.xz / _Params.xy + _Time.x * _Params.zw;
			fixed4 shadow = tex2D(_CloudShadow, uv01) * _CloudShadowColor.a;
			finalcolor.rgb = finalcolor.rgb * (1- shadow.r)  + _CloudShadowColor.rgb * shadow.r;
			#endif

			#ifdef USE_DEPTH
			return half4(finalcolor.rgb, i.projPos.w);
			#else
			return half4(finalcolor.rgb, finalcolor.a);
			#endif
		}