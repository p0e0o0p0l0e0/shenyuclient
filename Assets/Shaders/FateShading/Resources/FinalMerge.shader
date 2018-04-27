Shader "Hidden/FinalMerge"
{
	SubShader
	{
  		ZTest Off
        ZWrite Off
        Cull Off
		
		Pass
		{
	    	CGPROGRAM
	    	#pragma vertex vert
	    	#pragma fragment frag_final_merge
			#define IMG_0 sceneRT
			#define IMG_1 bloomRT
			#define PARAM_0 _BloomParams
	    	#include "PostFX.cginc"
	    	ENDCG
	  	}

		Pass
		{
	    	CGPROGRAM
	    	#pragma vertex vert
	    	#pragma fragment frag_final_merge_tonemap
			#define IMG_0 sceneRT
			#define IMG_1 bloomRT
			#define IMG_2 colorLUT
			#define PARAM_0 _HDRParams
	    	#include "PostFX.cginc"
	    	ENDCG
	  	}
	} 
	FallBack off
}
