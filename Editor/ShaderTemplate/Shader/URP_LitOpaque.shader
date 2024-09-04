Shader "ShaderReference/Template/LitOpaque"
{
    Properties
    {
        _Color("Color" , Color) = (1,1,1,1)
        _BaseMap ("BaseMap", 2D) = "white" {}
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
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"

            struct Attributes
            {
                float4 positionOS   : POSITION;
                float3 normalOS     : NORMAL;
                float3 tangentOS    : TANGENT;
                float3 color        : COLOR;
                float2 texcoord     : TEXCOORD;
            };
            struct Varyings
            {
                float4 positionHCS  : SV_POSITION;
                float2 uv           : TEXCOORD;
                float3 positionWS   : TEXCOORD1;
                float3 normalWS     : TEXCOORD2;
                float3 tangentWS    : TEXCOORD3;
                float3 bitangentWS  : TEXCOORD4;
                float3 viewWS       : TEXCOORD5;
            };

            TEXTURE2D(_BaseMap);SAMPLER(sampler_BaseMap);
            CBUFFER_START(UnityPerMaterial)
                float4 _Color;
                float4 _BaseMap_ST;
            CBUFFER_END

            Varyings vert (Attributes v)
            {
                Varyings o = (Varyings) 0;
                VertexPositionInputs vertexInput = GetVertexPositionInputs(v.positionOS.xyz);
                VertexNormalInputs normalInput = GetVertexNormalInputs(v.normalOS);

                o.positionHCS = vertexInput.positionCS;
                o.positionWS = vertexInput.positionWS;

                o.tangentWS = normalInput.tangentWS;
                o.bitangentWS = normalInput.bitangentWS;
                o.normalWS = normalInput.normalWS;

                o.viewWS = GetWorldSpaceViewDir(o.positionWS);
                
                o.uv = TRANSFORM_TEX(v.texcoord, _BaseMap);
                return o;
            }

            half4 frag (Varyings i) : SV_Target
            {
                half4 FinalColor;

                Light light = GetMainLight();
                half4 lightColor = half4(light.color * light.distanceAttenuation , 1);
                half3 lightDirWS = light.direction;

                half4 baseMap = SAMPLE_TEXTURE2D(_BaseMap,sampler_BaseMap , i.uv);

                FinalColor = baseMap * _Color;
                
                return FinalColor;
            }
            ENDHLSL
        }
    }
}
