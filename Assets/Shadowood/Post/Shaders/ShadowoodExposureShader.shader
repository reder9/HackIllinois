Shader "Hidden/ShadowoodExposureShader" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "" {}		
	}
	
	CGINCLUDE
	
	#include "UnityCG.cginc"
	
	struct v2f {
		float4 pos : SV_POSITION;
		float2 uv : TEXCOORD0;
	};
	
	sampler2D _MainTex;
	

	float4 _MainTex_TexelSize;
	float _Exposure;
		

	v2f vert( appdata_img v ) {
		v2f o;
		o.pos = mul(UNITY_MATRIX_MVP, v.vertex);	
		
		o.uv = v.texcoord.xy;
		return o;
	} 
	
	half4 frag(v2f i) : SV_Target {
		half2 coords = i.uv;
		half2 uv = i.uv;
		
		coords = (coords - 0.5) * 2.0;		
		half coordDot = dot (coords,coords);
		half4 color = tex2D (_MainTex, uv);	 
			
		return color * _Exposure;
	}


	ENDCG 
	
Subshader {
 Pass {
	  ZTest Always Cull Off ZWrite Off

	  CGPROGRAM
	  
	  #pragma vertex vert
	  #pragma fragment frag

	  ENDCG
  }
}
	
Fallback off

} // shader
