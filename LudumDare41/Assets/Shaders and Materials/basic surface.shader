Shader "Custom/basic surface" {
	/*
	SLouzi predevsim k tomu, aby fungovaly stiny atd. (proste osvetleni)
	
	*/
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows addshadow
			//addshadow je k tomu, aby se prepocitali i stiny

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex; // tzn chceme uv koordinaty main textury
			float3 worldPos; //obsahuje svetove koordinaty
			float3 worldNormal; //vrati svetovou normalu
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// zde budeme resit, jak se chova povrch

			// uplne se zahodi pixel, ktery chceme vykreslit -> fce clip();
			
			clip(IN.worldPos.z); // docela vtipne, kdyz zabijeme z souradnici -> ale nesedi stiny

			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			//o.Albedo = c.rgb;
			//o.Albedo = IN.worldNormal; // take dost vtipne, nicmene se pouzije pro snich
			
			o.Albedo = lerp(c.rgb, fixed3(1.0, 1.0, 1.0), IN.worldNormal.y); // vytvori "snih"

			//mnohem lepsi je to na zaklade dot produktu, viz jiny skript -> v nem je dost dobry snow shader


			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness; // jakym zpusobem se chova svetlo
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
