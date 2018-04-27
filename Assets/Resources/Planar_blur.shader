Shader "Hidden/Planar Blur"
{
	SubShader
	{
		ZTest Off
		ZWrite Off
		Cull Off

		Pass
		{
	    	CGPROGRAM
	    	#pragma vertex vert_blur
	    	#pragma fragment frag_blur
			#include "Planar.cginc"		
	    	ENDCG
	  	}
	}
}
