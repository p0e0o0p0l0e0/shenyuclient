Shader "ViCross/EnergyFlow"
{
	Properties 
	{
		_MainTex("Main_Texture", 2D) = "white" {}
		_Color01("Main_Texture_Color", Color) = (1,1,1,1)
		_Blend_Texture("Blend_Texture", 2D) = "white" {}
		_Color02("Blend_Texture_Color", Color) = (1,1,1,1)
		_Blend_Texture01("Blend_Texture01", 2D) = "black" {}
		_Speed("Main_Texutre_Speed", Float) = 1
		_Speed01("Blend_Texture_Speed", Float) = 1
		_Speed02("Blend_Texture01_Speed", Float) = 1
		_Fresnel_Value("Fresnel_Value", Range(0,3) ) = 0.5
		_Lighten("Lighten", Float) = 1
		_OriginalTex ("Original (RGB)", 2D) = "white" {}
		_Cutoff("Alpha Cut off", Range(0,1)) = 0.1
	}
	
	SubShader 
	{
		Tags
		{
			"Queue"="Transparent+100"
			"IgnoreProjector"="False"
			"RenderType"="Transparent"

		}


		Cull Off
		//ZWrite On
		ZTest Less  
		//ColorMask RGBA
		//Fog { Mode off }
		Offset -1,0
		AlphaTest Greater [_Cutoff]
		CGPROGRAM
		#pragma surface surf BlinnPhongEditor decal:add 
		#pragma target 3.0
	

		sampler2D _MainTex;
		half4 _Color01;
		sampler2D _Blend_Texture;
		half4 _Color02;
		sampler2D _Blend_Texture01;
		float _Speed;
		float _Speed01;
		float _Speed02;
		float _Fresnel_Value;
		float _Lighten;
		sampler2D _GrabTexture;
		sampler2D _OriginalTex;
		
		struct EditorSurfaceOutput {
				half3 Albedo;
				half3 Normal;
				half3 Emission;
				half3 Gloss;
				half Specular;
				half Alpha;
				half4 Custom;
			};
			
			inline half4 LightingBlinnPhongEditor_PrePass (EditorSurfaceOutput s, half4 light)
			{
				half3 spec = light.a * s.Gloss;
				half4 c;
				c.rgb = (s.Albedo * light.rgb + light.rgb * spec);
				c.a = s.Alpha;
				return c;
			}

			inline half4 LightingBlinnPhongEditor (EditorSurfaceOutput s, half3 lightDir, half3 viewDir, half atten)
			{
				half3 h = normalize (lightDir + viewDir);
				
				half diff = max (0, dot ( lightDir, s.Normal ));
				
				half nh = max (0, dot (s.Normal, h));
				half spec = pow (nh, s.Specular*128.0);
				
				half4 res;
				res.rgb = _LightColor0.rgb * diff;
				res.w = spec * Luminance (_LightColor0.rgb);
				res *= atten * 2.0;

				return LightingBlinnPhongEditor_PrePass( s, res );
			}
			
			struct Input 
			{
				float3 viewDir;
				float2 uv_MainTex;
				float2 uv_Blend_Texture;
				float2 uv_Blend_Texture01;
				float2 uv_OriginalTex; 
				half4 color : COLOR;
			};

			void surf (Input IN, inout EditorSurfaceOutput o) 
			{
			
				o.Normal = float3(0.0,0.0,1.0);
				o.Alpha = 1.0;
				o.Albedo = 0.0;
				o.Emission = 0.0;
				o.Gloss = 0.0;
				o.Specular = 0.0;
				o.Custom = 0.0;
				
				fixed4 originalTex = tex2D (_OriginalTex, IN.uv_OriginalTex);
				
				half4 Fresnel0_1_NoInput = half4(0,0,1,1);
				half4 Fresnel0=(1.0 - dot( normalize( half4( IN.viewDir.x, IN.viewDir.y,IN.viewDir.z,1.0 ).xyz), normalize( Fresnel0_1_NoInput.xyz ) )).x;
				half4 Pow0=pow(Fresnel0,_Fresnel_Value.x);
				half4 Multiply2=_Time * _Speed.x;
				half4 UV_Pan1=half4((IN.uv_MainTex.xyxy).x,(IN.uv_MainTex.xyxy).y + Multiply2.x,(IN.uv_MainTex.xyxy).z,(IN.uv_MainTex.xyxy).w);
				half4 Tex2D0=tex2D(_MainTex,UV_Pan1.xy);
				
				half4 Multiply1=_Time * _Speed01.x;
				half4 UV_Pan0=half4((IN.uv_Blend_Texture.xyxy).x,(IN.uv_Blend_Texture.xyxy).y + Multiply1.x,(IN.uv_Blend_Texture.xyxy).z,(IN.uv_Blend_Texture.xyxy).w);
				half4 Tex2D1=tex2D(_Blend_Texture,UV_Pan0.xy);
				half4 Multiply3=Pow0 * (_Color01 * Tex2D0 + _Color02 * Tex2D1) * Tex2D0 * Tex2D1;
				
				half4 Multiply10=_Time * _Speed02.x;
				half4 UV_Pan2=half4((IN.uv_Blend_Texture01.xyxy).x,(IN.uv_Blend_Texture01.xyxy).y + Multiply10.x,(IN.uv_Blend_Texture01.xyxy).z,(IN.uv_Blend_Texture01.xyxy).w);
				half4 Tex2D2=tex2D(_Blend_Texture01,UV_Pan2.xy);
				Tex2D2*= originalTex.a;
				half4 Multiply4=Multiply3 * Tex2D2 * _Lighten.x * IN.color;
				o.Emission = Multiply4;
				o.Normal = normalize(o.Normal);
			}
		ENDCG
	}
}