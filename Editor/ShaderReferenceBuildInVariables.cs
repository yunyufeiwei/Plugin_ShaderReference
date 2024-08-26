using UnityEngine;
using UnityEditor;

namespace yuxuetian.tools.shaderReference
{
    public class ShaderReferenceBuildInVariables : EditorWindow
    {
        private ShaderReferenceUtil reference = new ShaderReferenceUtil();

        public void DrawTitleVert()
        {
            reference.DrawTitle("Vert");
        }

        public void DrawContentVert()
        {
            reference.DrawContent("UNITY_INITIALIZE_OUTPUT(type,name)", "由于HLSL编缉器不接受没有初始化的数据，所以为了支持所有平台，从而需要使用此方法进行初始化.\n" +
                                                                        "Varying o = (Varying)0");
            reference.DrawContent("o.uv = TRANSFORM_TEX(i.uv,_MainTex)","对UV进行Tiling与Offset变换,也可以将其拆开。\n"+
                                     "o.uv = v.texcoord.xy * _BaseMap_ST.xy + _BaseMap_ST.zw");
            reference.DrawContent("float3 UnityWorldSpaceLightDir( float3 worldPos )", "返回顶点到灯光的向量");
        }

        public void DrawTitleBuildInVariabledCameraAndScreen()
        {
            reference.DrawTitle("CameraAndScreen");
        }

        public void DrawContentBuildInVariabledCameraAndScreen(bool isFold)
        {
            if (isFold)
            {
                reference.DrawContent("Camera相关参数", "相机在世界空间下的位置坐标(xyz):_WorldSpaceCameraPos\n" +
                                         "相机指向前方的方向:-1 * mul(UNITY_MATRIX_M, transpose(mul(UNITY_MATRIX_I_M, UNITY_MATRIX_I_V)) [2].xyz);\n" +
                                         "是否是正交相机(1为正交,0为透视):unity_OrthoParams.w\n" +
                                         "近裁剪面:_ProjectionParams.y\n" +
                                         "远裁剪面:_ProjectionParams.z\n" +
                                         "Z Buffer方向(-1为反向,1为正向):_ProjectionParams.x\n" +
                                         "正交相机的宽度:unity_OrthoParams.x\n" +
                                         "正交相机的高度:unity_OrthoParams.y");
                reference.DrawContent("_ZBufferParams", "传统Z方向:\n" +
                                         "x=1-far/near\n" +
                                         "y=far/near\n" +
                                         "z=x/far\n" +
                                         "w=y/far\n\n" +
                                         "反向Z:\n" +
                                         "x=-1+far/near\n" +
                                         "y=1\n" +
                                         "z=x/far\n" +
                                         "w=1/far");
                reference.DrawContent("深度:_CameraDepthTexture", "在PipelineAsset中勾选DepthTexture.\n" +
                                         "#define REQUIRE_DEPTH_TEXTURE\t//直接这样定义可以省去声明纹理的步骤(直接使用内部hlsl中的定义)\n" +
                                         "TEXTURE2D (_CameraDepthTexture);SAMPLER(sampler_CameraDepthTexture);\n" +
                                         "float2 screenUV = i.positionCS/_ScreenParams.xy;\n" +
                                         "half4 depthMap = SAMPLE_TEXTURE2D(_CameraDepthTexture, sampler_CameraDepthTexture, screenUV);\n" +
                                         "half depth = Linear01Depth(depthMap, _ZBufferParams);");
                reference.DrawContent("线性深度转换","从深度图中得到顶点的线性深度值(相机位置=0，相机远裁剪面=1)\n" +
                                         "Linear01Depth(depthMap, _ZBufferParams);\n" +
                                         "从深度图中得到顶点的线性深度值(不是0-1的范围)\n" +
                                         "LinearEyeDepth(depthMap, _ZBufferParams);");
                reference.DrawContent("抓屏:_CameraOpaqueTexture", "在PipelineAsset中勾选OpaqueTexture,同时这个抓屏只能在半透明序列下正确执行.\n" +
                                         "#define REQUIRE_OPAQUE_TEXTURE\t//直接这样定义可以省去声明纹理的步骤(直接使用内部hlsl中的定义)\n" +
                                         "TEXTURE2D (_CameraOpaqueTexture);SAMPLER(sampler_CameraOpaqueTexture);\n" +
                                         "float2 screenUV = i.positionCS.xy / _ScreenParams.xy;\n" +
                                         "half4 screenColor = SAMPLE_TEXTURE2D(_CameraOpaqueTexture, sampler_CameraOpaqueTexture, screenUV);");
                reference.DrawContent("_ScreenParams", "屏幕的相关参数，单位为像素。\nx表示屏幕的宽度\ny表示屏幕的高度\nz表示1+1/屏幕宽度\nw表示1+1/屏幕高度");
                reference.DrawContent("_ScaledScreenParams", "同上，但是有考虑到RenderScale的影响.");
            }
                    
        }

        public void DrawTitleBuildInVariablesTime()
        {
            reference.DrawTitle("Time");
        }

        public void DrawContentBuildInVariablesTime(bool isFold)
        {
            if (isFold)
            {
                reference.DrawContent("_Time", "时间，主要用于在Shader做动画,类型：float4\nx = t/20\ny = t\nz = t*2\nw = t*3");
                reference.DrawContent("_SinTime", "t是时间的正弦值，返回值(-1~1): \nx = t/8\ny = t/4\nz = t/2\nw = t");
                reference.DrawContent("_CosTime", "t是时间的余弦值，返回值(-1~1):\nx = t/8\ny = t/4\nz = t/2\nw = t");
                reference.DrawContent("unity_DeltaTime", "dt是时间增量,smoothDt是平滑时间\nx = dt\ny = 1/dt\nz = smoothDt\nz = 1/smoothDt");
 
            }
        }

        public void DrawTitleBuidInVariablesGPUInstancing()
        {
            reference.DrawTitle("GPU Instancing");
        }

        public void DrawContentBuildInVariablesGPUInstancing(bool isFold)
        {
            if (isFold)
            {
                reference.DrawContent("实现步骤", "用于对多个对象(网格一样，材质一样，但是材质属性不一样)合批,单个合批最大上限为511个对象.\n" +
                                              "1.#pragma multi_compile_instancing 添加此指令后会使材质面板上曝露Instaning开关,同时会生成相应的Instancing变体(INSTANCING_ON).\n" +
                                              "2.UNITY_VERTEX_INPUT_INSTANCE_ID 在顶点着色器的输入(appdata)和输出(v2f可选)中添加(uint instanceID : SV_InstanceID).\n" +
                                              "3.构建需要实例化的额外数据:\n" +
                                              "\t#ifdef UNITY_INSTANCING_ENABLED\n" +
                                              "\tUNITY_INSTANCING_BUFFER_START(prop自定义名字)\n" +
                                              "\tUNITY_DEFINE_INSTANCED_PROP(vector, _BaseColor)\n" +
                                              "\tUNITY_INSTANCING_BUFFER_END(prop自定义名字)\n" +
                                              "\t#endif\n" +
                                              "4.UNITY_SETUP_INSTANCE_ID(v); 放在顶点着色器/片断着色器(可选)中最开始的地方,这样才能访问到全局变量unity_InstanceID.\n" +
                                              "5.UNITY_TRANSFER_INSTANCE_ID(v, o); 当需要将实例化ID传到片断着色器时,在顶点着色器中添加.\n" +
                                              "6.UNITY_ACCESS_INSTANCED_PROP(arrayName, propName) 在片断着色器中访问具体的实例化变量.\n");
                reference.DrawContent("Instancing选项", "对GPU Instancing进行一些设置.\n" +
                                              "• #pragma instancing_options forcemaxcount:batchSize 强制设置单个批次内Instancing的最大数量,最大值和默认值是511.\n" +
                                              "• #pragma instancing_options maxcount:batchSize 设置单个批次内Instancing的最大数量,仅Vulkan, Xbox One和Switch有效.");

            }
        }
    }
}

