Shader "ShaderReference/ShaderModule/Base/Noise"
{
    Properties
    {
        _NoiseA("NoiseA",Float) = 12.9898
        _NoiseB("NoiseB",Float) = 78.233
        _MulValue("MulValue",Float) = 43758.5453
    }
    SubShader
    {
        Tags{"RenderPipeline" = "UniversalPipeline" "RenderType" = "Opaque" "Queue" = "Geometry"}
        LOD 100

        pass
        {
            Tags{"LightMode" = "UniversalForward"}
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            
            struct Attributes
            {
                float4 positionOS     : POSITION;
                float2 texcoord     : TEXCOORD;
            };
            struct Varyings
            {
                float4 positionHCS  : SV_POSITION;
                float2 uv           : TEXCOORD;
            };
            
            //CBuffer部分，数据参数定义在该结构内，可以使用srp的batch功能
            CBUFFER_START(UnityPerMaterial)
                float _NoiseA;
                float _NoiseB;
                float _MulValue;
            CBUFFER_END
            
            float RandomNoise(float2 seed,float a ,float b,float mulValue)
            {
                return frac(sin(dot(seed , float2(a,b))) * mulValue);
            }

            Varyings vert(Attributes v)
            {
                Varyings o = (Varyings)0;

                o.positionHCS = TransformObjectToHClip(v.positionOS.xyz);
                o.uv = v.texcoord;

                return o;
            }

            half4 frag(Varyings i):SV_TARGET
            {
                half4 FinalColor;

                FinalColor = RandomNoise(i.uv,_NoiseA,_NoiseB,_MulValue);

                return FinalColor;
            }
            ENDHLSL  
        }
    }
}
