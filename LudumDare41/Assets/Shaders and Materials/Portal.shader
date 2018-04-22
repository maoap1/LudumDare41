Shader "Unlit/Portal"
{
	Properties
	{
		_NoiseTex ("NoiseTexture", 2D) = "white" {}
		_DistortionTex("DistortionTexture", 2D) = "black" {}
		_Color0 ("Color0", Color) = (0.0, 0.0, 0.0, 1.0)
        _Color1 ("Color0", Color) = (1.0, 1.0, 1.0, 1.0)


        _DistortionSpeed ("Distotion Speed", Float) = 1.0
        _DistortionStrength ("Distortion Strength", Range(0.0, 20.0)) = 1.0
        _Speed ("Speed", Float) = 1.0

		_Radius("Radius", Range(0.0, 1.0)) = 0.5
	}
	SubShader
	{
		Tags { "Queue"="Transparent" "RenderType"="Transparent" }
		Pass
		{
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

			sampler2D _DistortionTex;
    		half4 _DistortionTex_ST;
			sampler2D _NoiseTex;
			half4 _NoiseTex_ST;
			fixed4 _Color0;    
    		fixed4 _Color1; 
    		half _DistortionStrength;
    		float _Speed;
    		float _DistortionSpeed;
			float _Radius;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				o.uv0 = TRANSFORM_TEX(v.uv, _NoiseTex);
       			o.uv1 = TRANSFORM_TEX(v.uv, _DistortionTex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				float distStrength = _DistortionStrength + _DistortionSpeed*_SinTime.y*_SinTime.y;
        		float2 dist = (tex2D(_DistortionTex, i.uv1).xy - float2(0.5, 0.5))*distStrength;

        		float m = tex2D(_NoiseTex, i.uv0 + dist - float2(0.0, _Time.x * _Speed)).r;
				float t = m + (1.0 - i.uv.y);
				fixed4 c = lerp(_Color1, _Color0, i.uv.y) * t;
       			c.a = t;

				float radDist = distance(i.uv, float2(0.5, 0.5));
				if (abs(radDist) > _Radius)
				{
					discard;
				}
        		return c;
			}
			ENDCG
		}
	}
}
