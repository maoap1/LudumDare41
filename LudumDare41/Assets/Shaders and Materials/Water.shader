Shader "Unlit/Water"
{
	Properties
	{
		_NoiseTex0("NoiseTexture0", 2D) = "white" {}
		_NoiseTex1("NoiseTexture1", 2D) = "black" {}

		_Color0("Color0", Color) = (0.0, 0.0, 0.0, 1.0)
		_Color1("Color1", Color) = (1.0, 1.0, 1.0, 1.0)
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
			};

			sampler2D _NoiseTex0;
			float4 _NoiseTex0_SD;
			sampler2D _NoiseTex1;
			float4 _NoiseTex1_SD;
			fixed4 _Color0;
			fixed4_Color1;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _NoiseTex1);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col = tex2D(_NoiseTex1, i.uv);
				return col;
			}
			ENDCG
		}
	}
}
