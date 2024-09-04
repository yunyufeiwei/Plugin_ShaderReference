Shader "ShaderReference/ShaderModule/Base/Transparent"
{
    Properties
    {
        _Color("Color",Color) = (1,1,1,1)
        _Alpha("Alpha",Range(0,1)) = 1
    }
    SubShader
    {
        //设置标签的渲染类型为半透明，以及标签的排序为半透明排序(确保渲染顺序正确)
        Tags{"RenderPipeline" = "UniversalPipeline" "Queue" = "Transparent" "RenderType" = "Transparent"}
        LOD 100

        pass
        {
            Tags{"LightMode" = "UniversalForward"}
            ZWrite Off
            Blend SrcAlpha OneMinusSrcAlpha

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"
            
            struct Attributes
            {
                float4 positionOS     : POSITION;
            };
            struct Varyings
            {
                float4 positionHCS  : SV_POSITION;
            };
            
            //CBuffer部分，数据参数定义在该结构内，可以使用srp的batch功能
            CBUFFER_START(UnityPerMaterial)
                float4 _Color;
                float  _Alpha;
            CBUFFER_END

            Varyings vert(Attributes v)
            {
                Varyings o = (Varyings)0;

                o.positionHCS = TransformObjectToHClip(v.positionOS.xyz);

                return o;
            }

            half4 frag(Varyings i):SV_TARGET
            {
                half4 FinalColor;

                //使用颜色的A通道和_Alpha属性来共同控制最终输出的半透明强度
                FinalColor = half4(_Color.rgb , _Color.a * _Alpha);

                return FinalColor;
            }
            ENDHLSL  
        }
    }
}
