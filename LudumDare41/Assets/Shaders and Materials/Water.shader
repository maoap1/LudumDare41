Shader "Unlit/Water"
{
	Properties
	{
		_NoiseTex0 ("NoiseTexture", 2D) = "white" {}
		_NoiseTex1("DistortionTexture", 2D) = "black" {}
		_Color0 ("Color0", Color) = (0.0, 0.0, 0.0, 1.0)
        _Color1 ("Color1", Color) = (1.0, 1.0, 1.0, 1.0)

        _DistortionStrength ("Distortion Strength", Range(0.0, 2.0)) = 1.0
        _Speed ("Speed", Float) = 1.0
	}
	SubShader
	{
		Tags { "Queue"="Transparent" "RenderType"="Transparent" }
		Pass
		{

		
            ZWrite Off
            Cull Off

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
       		 	float2 uv0 : TEXCOORD1;
        		float2 uv1 : TEXCOORD2;
			};

			sampler2D _NoiseTex1;
    		half4 _NoiseTex1_ST;
			sampler2D _NoiseTex0;
			half4 _NoiseTex0_ST;
			fixed4 _Color0;    
    		fixed4 _Color1; 
    		half _DistortionStrength;
    		float _Speed;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				o.uv0 = TRANSFORM_TEX(v.uv, _NoiseTex0);
       			o.uv1 = TRANSFORM_TEX(v.uv, _NoiseTex1);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
        		float2 dist = (tex2D(_NoiseTex1, i.uv1).xy - float2(0.5, 0.5))*_DistortionStrength;
        		float m = tex2D(_NoiseTex0, i.uv0 + dist - float2(_Time.x * _Speed*2, _Time.x * _Speed)).r;
				float t = m + (1.0 - i.uv.y);
				fixed4 c = lerp(_Color1, _Color0, i.uv.y) * t;
       			c.a = t;
        		return c;
			}
			ENDCG
		}
	}
}
