Shader "Unlit/NewUnlitShader"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			#pragma multi_compile_fog
			
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

			v2f vert (appdata v) // vertex shader
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex); // zde je ta cast, kde se tranformuje na plochu
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target // fragment shader
			{
				return fixed4(1.0,0.0,0.0,1.0); // red
			}
			ENDCG
		}
	}
}
