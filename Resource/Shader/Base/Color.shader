Shader "ShaderTemplate/Base/Color"
{
    Properties
    {
        _Color("Color" , Color) = (1,1,1,1)
    }
    SubShader
    {
        Tags{"RenderPipeline" = "UniversalPipeline" "Queue" = "Geometry" "RenderType" = "Opaque" }
        LOD 100

        Pass
        {
            Tags{"LightMode" = "UniversalForward"}
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct Attributes
            {
                float4 positionOS   : POSITION;
                float2 texcoord     : TEXCOORD;
            };
            struct Varyings
            {
                float4 positionHCS  : SV_POSITION;
                float2 uv           : TEXCOORD;
            };

            CBUFFER_START(UnityPerMaterial)
                float4 _Color;
            CBUFFER_END

            Varyings vert (Attributes v)
            {
                Varyings o = (Varyings) 0;
                VertexPositionInputs vertexInput = GetVertexPositionInputs(v.positionOS.xyz);

                o.positionHCS = vertexInput.positionCS;
                return o;
            }

            half4 frag (Varyings i) : SV_Target
            {
                half4 FinalColor;


                FinalColor = _Color;
                
                return FinalColor;
            }
            ENDHLSL
        }
    }
}
