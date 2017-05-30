// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'
<<<<<<< HEAD

Shader "Onoty3D/Toon/Lit Outline" {
	Properties {
		_Color ("Main Color", Color) = (0.5,0.5,0.5,1)
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_Ramp ("Toon Ramp (RGB)", 2D) = "gray" {}
		[Enum(OFF,0,FRONT,1,BACK,2)] _CullMode("Cull Mode", int) = 2 //OFF/FRONT/BACK
		_StencilRefMain("Stcl Ref Main", Range(0, 255)) = 128
		_OutlineColor("Outline Color", Color) = (0,0,0,1)
		_OutlineWidth("Outline Width", Range(.001, 0.03)) = .005

	}

	CGINCLUDE
		#include "UnityCG.cginc"

		struct appdata {
			float4 vertex : POSITION;
			float3 normal : NORMAL;
		};

		struct v2f {
			float4 pos : SV_POSITION;
			UNITY_FOG_COORDS(0)
			fixed4 color : COLOR;
		};

		uniform float _OutlineWidth;
		uniform float4 _OutlineColor;

		v2f vert(appdata v) {
			v2f o;
			o.pos = UnityObjectToClipPos(v.vertex);

			float3 norm = normalize(mul((float3x3)UNITY_MATRIX_IT_MV, v.normal));
			float2 offset = TransformViewToProjection(norm.xy);

			o.pos.xy += offset * o.pos.z * _OutlineWidth;
			o.color = _OutlineColor;
			UNITY_TRANSFER_FOG(o, o.pos);
			return o;
		}
	ENDCG

	SubShader {
		Tags { "RenderType"="Opaque" }

		UsePass "Onoty3D/Toon/Lit/FORWARD"

		Pass{
			Name "OUTLINE"
			Tags{ "LightMode" = "Always" }

			Stencil{
				Ref[_StencilRefMain]
				Comp always
				Pass replace
			}

			Cull Front
			ZWrite On
			ColorMask RGB
			Blend SrcAlpha OneMinusSrcAlpha

			CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#pragma multi_compile_fog
				fixed4 frag(v2f i) : SV_Target
				{
					UNITY_APPLY_FOG(i.fogCoord, i.color);
					return i.color;
				}
			ENDCG
		}
	} 
	
	Fallback "Onoty3D/Toon/Lit"
}
=======

Shader "Onoty3D/Toon/Lit Outline" {
	Properties {
		_Color ("Main Color", Color) = (0.5,0.5,0.5,1)
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_Ramp ("Toon Ramp (RGB)", 2D) = "gray" {}
		[Enum(OFF,0,FRONT,1,BACK,2)] _CullMode("Cull Mode", int) = 2 //OFF/FRONT/BACK
		_StencilRefMain("Stcl Ref Main", Range(0, 255)) = 128
		_OutlineColor("Outline Color", Color) = (0,0,0,1)
		_OutlineWidth("Outline Width", Range(.001, 0.03)) = .005

	}

	CGINCLUDE
		#include "UnityCG.cginc"

		struct appdata {
			float4 vertex : POSITION;
			float3 normal : NORMAL;
		};

		struct v2f {
			float4 pos : SV_POSITION;
			UNITY_FOG_COORDS(0)
			fixed4 color : COLOR;
		};

		uniform float _OutlineWidth;
		uniform float4 _OutlineColor;

		v2f vert(appdata v) {
			v2f o;
			o.pos = UnityObjectToClipPos(v.vertex);

			float3 norm = normalize(mul((float3x3)UNITY_MATRIX_IT_MV, v.normal));
			float2 offset = TransformViewToProjection(norm.xy);

			o.pos.xy += offset * o.pos.z * _OutlineWidth;
			o.color = _OutlineColor;
			UNITY_TRANSFER_FOG(o, o.pos);
			return o;
		}
	ENDCG

	SubShader {
		Tags { "RenderType"="Opaque" }

		UsePass "Onoty3D/Toon/Lit/FORWARD"

		Pass{
			Name "OUTLINE"
			Tags{ "LightMode" = "Always" }

			Stencil{
				Ref[_StencilRefMain]
				Comp always
				Pass replace
			}

			Cull Front
			ZWrite On
			ColorMask RGB
			Blend SrcAlpha OneMinusSrcAlpha

			CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#pragma multi_compile_fog
				fixed4 frag(v2f i) : SV_Target
				{
					UNITY_APPLY_FOG(i.fogCoord, i.color);
					return i.color;
				}
			ENDCG
		}
	} 
	
	Fallback "Onoty3D/Toon/Lit"
}
>>>>>>> 3492851a250a340db1ec231ee25615632125268f
