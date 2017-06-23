// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Onoty3D/Toon/Lit OuterFrame" {
	Properties {
		_Color ("Main Color", Color) = (0.5,0.5,0.5,1)
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_Ramp ("Toon Ramp (RGB)", 2D) = "gray" {}
		[Enum(OFF,0,FRONT,1,BACK,2)] _CullMode("Cull Mode", int) = 2 //OFF/FRONT/BACK
		_StencilRefMain("Stcl Ref Main", Range(0, 255)) = 128
		_StencilRefOuterFrame("Stcl Ref Outer Frame", Range(0, 255)) = 112
		_StencilRefShadow("Stcl Ref Outer Shadow", Range(0, 255)) = 96
		_OuterFrameColor("Outer Frame Color", Color) = (1,1,1,1)
		_OuterFrameWidth("Outer Frame Width", Range(0.0, 1.0)) = 0.02
		_OuterShadowColor("Outer Shadow Color", Color) = (0.5,0.5,0.5,0.5)
		_OuterShadowOffset("Outer Shadow Offset", Vector) = (-0.5,-0.5,0,0)

	}

	SubShader {
		Tags { "RenderType"="Opaque" }
		
		UsePass "Onoty3D/Toon/Lit/FORWARD"
		
		//STENCIL OUTER FRAME"
		Pass{
			Name "OUTER FRAME"
			Stencil{
				Ref [_StencilRefOuterFrame]
				Comp Greater
				Pass Replace
			}

			Cull Front
			ZWrite On
			ColorMask RGB
			Blend SrcAlpha OneMinusSrcAlpha

			CGPROGRAM
				#include "UnityCG.cginc"
				#pragma vertex vert
				#pragma fragment frag

				float _OuterFrameWidth;
				float4 _OuterFrameColor;
				struct appdata {
					float4 vertex : POSITION;
					float3 normal : NORMAL;
				};

				struct v2f {
					float4 pos : SV_POSITION;
				};

				v2f vert(appdata v) {
					v2f o;
					o.pos = UnityObjectToClipPos(v.vertex);

					float3 norm = normalize(mul((float3x3)UNITY_MATRIX_IT_MV, v.normal));
					float2 offset = TransformViewToProjection(norm.xy);

					o.pos.xy += offset * o.pos.z * _OuterFrameWidth;
					UNITY_TRANSFER_FOG(o, o.pos);
					return o;
				}

				half4 frag(v2f i) : COLOR{
					return _OuterFrameColor;
				}
			ENDCG
		}

		//STENCIL SHADOW
		Pass{
			Name "OUTER SHADOW"
			Stencil{
				Ref[_StencilRefShadow]
				Comp Greater
				Pass replace
			}

			Cull Off
			ZWrite Off

			Blend SrcAlpha OneMinusSrcAlpha

			CGPROGRAM
				#include "UnityCG.cginc"
				#pragma vertex vert
				#pragma fragment frag

				float _OuterFrameWidth;
				float4 _OuterShadowColor;
				float _StencilScale;
				float2 _OuterShadowOffset;

				struct appdata {
					float4 vertex : POSITION;
					float3 normal : NORMAL;
				};

				struct v2f {
					float4 pos : SV_POSITION;
				};

				v2f vert(appdata v) {
					v2f o;
					o.pos = UnityObjectToClipPos(v.vertex);

					float3 norm = normalize(mul((float3x3)UNITY_MATRIX_IT_MV, v.normal));
					float2 offset = TransformViewToProjection(norm.xy);

					o.pos.xy += offset * o.pos.z * _OuterFrameWidth;
					o.pos.x += _OuterShadowOffset.x;
					o.pos.y += _OuterShadowOffset.y;
					UNITY_TRANSFER_FOG(o, o.pos);
					return o;
				}

				half4 frag(v2f i) : COLOR{
					return _OuterShadowColor;
				}
			ENDCG
		}
	} 

	Fallback "Onoty3D/Toon/Lit"
}
