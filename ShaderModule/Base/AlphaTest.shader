Shader "ShaderReference/ShaderModule/Base/AlphaTest"
{
    Properties
    {
        _ClipTexture("ClipTexture" , 2D) = "white"{}
        _ClipThreshold("AlphaTestThreshold" , Range(0,1)) = 0.5
    }
    SubShader
    {
        //设置标签为AlphaTest，该类型的渲染在是半透明之前的
        Tags{"RenderPipeline" = "UniversalPipeline" "RenderType" = "Opaque" "Queue" = "AlphaTest" }
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
                float4 positionOS    : POSITION;
                float2 texcoord     : TEXCOORD;
            };
            struct Varyings
            {
                float4 positionHCS  : SV_POSITION;
                float2 uv           : TEXCOORD;
            };
            
            TEXTURE2D(_ClipTexture);SAMPLER(sampler_ClipTexture);

            //CBuffer部分，数据参数定义在该结构内，可以使用srp的batch功能
            CBUFFER_START(UnityPerMaterial)
                float4 _ClipTexture_ST;
                float  _ClipThreshold;
            CBUFFER_END

            Varyings vert(Attributes v)
            {
                Varyings o = (Varyings)0;

                o.positionHCS = TransformObjectToHClip(v.positionOS.xyz);
                o.uv = TRANSFORM_TEX(v.texcoord , _ClipTexture);

                return o;
            }

            half4 frag(Varyings i):SV_TARGET
            {
                half4 FinalColor;

                half ClipTexture = SAMPLE_TEXTURE2D(_ClipTexture,sampler_ClipTexture , i.uv).r;

                //可以使用AlphaDiscard方法，但需要在头部定义_ALPHATEST_ON
                //例如：#pragma shader_feature_local fragment __ALPHATEST_ON
                //具体实现Library\PackageCache\com.unity.render-pipelines.universal@12.1.8\ShaderLibrary\ShaderVariablesFunctions.hlsl
                clip(ClipTexture - _ClipThreshold);
                
                FinalColor = ClipTexture;

                return FinalColor;
            }
            ENDHLSL  
        }
    }
}
