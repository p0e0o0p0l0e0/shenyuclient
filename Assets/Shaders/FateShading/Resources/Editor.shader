Shader "Hidden/Editor" {
	SubShader {
  		ZTest Off
        ZWrite Off
        Cull Off
		
		Pass {
	    	CGPROGRAM
	    	#pragma vertex vert
	    	#pragma fragment frag
			//#pragma exclude_renderers d3d9 d3d11_9x

			#include "UnityCG.cginc"
			sampler2D _MainTex;
			
			struct v2f {
				float4 pos : SV_POSITION;
				float2 uv  : TEXCOORD0;
			};

			v2f vert( appdata_img v ) {
				v2f o;
				o.pos.xy = (v.vertex.xy - float2(0.5, 0.5)) * 2;
				o.pos.zw = float2(0, 1);
				o.uv = v.vertex.xy;
				return o;
			}

			half4 frag(v2f i) : SV_Target{
				half4 origin = tex2D(_MainTex, i.uv);
				return half4(pow(origin.rgb, 0.5), origin.a);
			}
			
	    	ENDCG
	  	}
	}
	FallBack off
}
