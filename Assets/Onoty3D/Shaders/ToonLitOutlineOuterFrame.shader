Shader "Onoty3D/Toon/Lit Outline OuterFrame" {
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
		_OutlineColor("Outline Color", Color) = (0,0,0,1)
		_OutlineWidth("Outline Width", Range(.001, 0.03)) = .005

	}

	SubShader {
		Tags { "RenderType"="Opaque" }

		UsePass "Onoty3D/Toon/Lit/FORWARD"
		UsePass "Onoty3D/Toon/Lit Outline/OUTLINE"
		UsePass "Onoty3D/Toon/Lit OuterFrame/OUTER FRAME"
		UsePass "Onoty3D/Toon/Lit OuterFrame/OUTER SHADOW"
	} 
	
	Fallback "Onoty3D/Toon/Lit"
}
