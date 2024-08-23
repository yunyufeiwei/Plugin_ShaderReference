Shader "ShaderReference/PropertyShowCase"
{
    Properties
    {
        [Header(PropertyValue)]
        _Int("Int",Integer) = 1
        [HideInInspector]_Float("Float",Float) = 0.1
        [PowerSlider(3)]_Slider1("Slider1",Range(0,10)) = 0
        [IntRange]_Slider2("Slider2",Range(0,10)) = 0
        _Float2("Float2",Float) = 0.5
        
        [Space(20)]
        [Toggle]_Toggle("Toggle1",Float) = 0
        [ToggleOff]_Toggle2("Toggle2",Float) = 0
        
        [Space(20)]
        [Enmu(Off,0,On,1)]_Enum1("Enmu1" , Integer) = 0
        [KeywordEnum (Enum0, Enum1, Enum2, Enum3, Enum4, Enum5, Enum6, Enum7, Enum8)]_Enum2("Enmu2" , Integer) = 0
        [Enum (UnityEngine.Rendering.CullMode)]_Enum3("Enmu3" , Integer) = 0
        
        [Enum(UnityEngine.Rendering.CullMode)]_Cull("Cull",Float) = 0
        [Space(20)]
        [HDR]_Color("Color",Color) = (1,1,1,1)
        _Vector("Vector",Vector) = (1,1,1,1)
        _BaseMap ("BaseMap", 2D) = "white" {}
        _BaseMapArray("BaseMapArray",2DArray) = "white"{}
        _ArrayIndex("ArrayIndex",Integer) = 0
        _Cube("Cube",Cube) = "_skybox"{}
        _3DTexture("3DTexture",3D) = "white"{}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" "Queue" = "Geometry" "PreviewType" = "Sphere"}
        LOD 100

        Pass
        {
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"

            struct Attribute
            {
                float4 positionOS   : POSITION;
                float3 normalOS     : NORMAL;
                float2 texcoord     : TEXCOORD0;
            };

            struct Varyings
            {
                float4 positionHCS  : SV_POSITION;
                float2 uv           : TEXCOORD0;
                float3 positionWS   : TEXCOORD1;
                float3 normalWS     : TEXCOORD2;
                float3 viewWS       : TEXCOORD3;
                float3 uvw          : TEXCOORD4;
                
            };

            TEXTURE2D(_BaseMap);            SAMPLER(sampler_BaseMap);
            TEXTURE2D_ARRAY(_BaseMapArray); SAMPLER(sampler_BaseMapArray);
            TEXTURECUBE(_Cube);             SAMPLER(sampler_Cube);
            TEXTURE3D(_3DTexture);          SAMPLER(sampler_3DTexture);

            CBUFFER_START(UnityPerMateiral)
                float4 _BaseMap_ST;
                float4 _BaseMapArraty_ST;
                float  _ArrayIndex;
                float  _Float2;
            CBUFFER_END
            

            Varyings vert (Attribute v)
            {
                Varyings o = (Varyings)0;
                VertexPositionInputs vertexInput = GetVertexPositionInputs(v.positionOS.xyz);
                VertexNormalInputs normalInput = GetVertexNormalInputs(v.normalOS);

                o.positionWS = vertexInput.positionWS;
                o.positionHCS = vertexInput.positionCS;
                o.normalWS = normalInput.normalWS;
                o.viewWS = GetWorldSpaceViewDir(o.positionWS);
                o.uv = TRANSFORM_TEX(v.texcoord, _BaseMap);
                o.uvw = v.positionOS.xyz * 0.5 + 0.5;
                return o;
            }

            half4 frag (Varyings i) : SV_Target
            {
                half4 FinalColor;

                Light light = GetMainLight();
                half3 worldLightDir = light.direction;

                half3 worldNormalDir = normalize(i.normalWS);
                half3 worldViewDir = normalize(i.viewWS);

                half3 reflexDir = reflect(-worldLightDir, worldNormalDir);

                half4 baseMap = SAMPLE_TEXTURE2D(_BaseMap , sampler_BaseMap , i.uv);
                half4 baseMapArray = SAMPLE_TEXTURE2D_ARRAY(_BaseMapArray , sampler_BaseMapArray , i.uv , 0);
                half4 cubeMap = SAMPLE_TEXTURECUBE(_Cube,sampler_Cube,reflexDir);
                half4 dTexture = SAMPLE_TEXTURE3D(_3DTexture , sampler_3DTexture , i.uvw);

                FinalColor = baseMap;
                return _Float2;
            }
            ENDHLSL
        }
    }
}
