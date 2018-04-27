Shader "Hidden/Bloom"
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
	    	#pragma fragment frag_bloomstart
			#pragma multi_compile __ HDR_ON
			#define IMG_0 sceneRT_div_4
			#define PARAM_0 sceneRT_div_4_TexelSize
			#define PARAM_1 _BloomParams
			#include "PostFX.cginc"		
	    	ENDCG
	  	}

		Pass
		{
	    	CGPROGRAM
	    	#pragma vertex vert_bloomup
	    	#pragma fragment frag_bloomup
			#define IMG_0 bloomRT_div_2
			#define PARAM_0 bloomRT_div_2_TexelSize
			#include "PostFX.cginc"		
	    	ENDCG
	  	}

		Pass
		{
	    	CGPROGRAM
	    	#pragma vertex vert_bloomdown
	    	#pragma fragment frag_bloomdown
			#define IMG_0 bloomRT
			#define PARAM_0 bloomRT_TexelSize
			#include "PostFX.cginc"
	    	ENDCG
	  	}

		Pass
		{
	    	CGPROGRAM
	    	#pragma vertex vert_bloomdown
	    	#pragma fragment frag_bloomdown
			#define HQ_BLOOM
			#define IMG_0 bloomRT
			#define PARAM_0 bloomRT_TexelSize
			#include "PostFX.cginc"
	    	ENDCG
	  	}

		Pass
		{
	    	CGPROGRAM
	    	#pragma vertex vert_bloomdown
	    	#pragma fragment frag_bloomdown
			#define HQ_BLOOM
			#define IMG_0 bloomRT_div_2
			#define PARAM_0 bloomRT_div_2_TexelSize
			#include "PostFX.cginc"
	    	ENDCG
	  	}

		Pass
		{
	    	CGPROGRAM
	    	#pragma vertex vert_bloomdown
	    	#pragma fragment frag_bloomdown
			#define HQ_BLOOM
			#define IMG_0 bloomRT_div_4
			#define PARAM_0 bloomRT_div_4_TexelSize
			#include "PostFX.cginc"
	    	ENDCG
	  	}

		Pass
		{
			Blend One One
			ColorMask RGB
	    	CGPROGRAM
	    	#pragma vertex vert
	    	#pragma fragment frag_bloom_merge
			#define IMG_0 bloomRT_div_4
			#define IMG_1 bloomRT_div_8
			#include "PostFX.cginc"
	    	ENDCG
	  	}
	}
	FallBack off
}
