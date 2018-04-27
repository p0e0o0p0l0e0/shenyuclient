Shader "Hidden/Rescale"
{
	SubShader
	{
  		ZTest Off
        ZWrite Off
        Cull Off
		
		Pass
		{
	    	CGPROGRAM
	    	#pragma vertex vert_s4
	    	#pragma fragment frag_scale_s4
			#define IMG_0 sceneRT
			#define PARAM_0 sceneRT_TexelSize
			#include "PostFX.cginc"		
	    	ENDCG
	  	}
	}
	FallBack off
}
