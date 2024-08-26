using UnityEngine;
using UnityEditor;

namespace yuxuetian.tools.shaderReference
{
    public class ShaderReferencePredefinedMacros : EditorWindow
    {
        private ShaderReferenceUtil reference = new ShaderReferenceUtil();

        public void DrawTitleTargetPlatform()
        {
            reference.DrawTitle("TargetPlatform");
        }

        public void DrawContentGargetPlatform(bool isFold)
        {
            if (isFold)
            {
                reference.DrawContent("SHADER_API_D3D11", "Direct3D 11");
                reference.DrawContent("SHADER_API_GLCORE", "桌面OpenGL核心(GL3/4)");
                reference.DrawContent("SHADER_API_GLES", "OpenGl ES 2.0");
                reference.DrawContent("SHADER_API_GLES3", "OpenGl ES 3.0/3.1");
                reference.DrawContent("SHADER_API_METAL", "IOS/Mac Metal");
                reference.DrawContent("SHADER_API_VULKAN", "Vulkan");
                reference.DrawContent("SHADER_API_D3D11_9X", "IOS/Mac Metal");
                reference.DrawContent("SHADER_API_PS4", "PS4平台,SHADER_API_PSSL同时也会被定义");
                reference.DrawContent("SHADER_API_XBOXONE", "Xbox One");
                reference.DrawContent("SHADER_API_MOBILE", "所有移动平台(GLES/GLES3/METAL)");
            }
        }

        public void DrawTitleBranch()
        {
            reference.DrawTitle("Branch(流程控制)");
        }

        public void DrawContentBranch(bool isFold)
        {
            if (isFold)
            {
                reference.DrawContent("#define UNITY_BRANCH        [branch]", "添加在if语句上面,表示此语句会根据判断只执行符合条件的代码，有跳转指令.");
                reference.DrawContent("#define UNITY_FLATTEN       [flatten]", "添加在if语句上面,表示此语句会执行全部代码,然后根据条件来选择某个具体的结果,没有跳转指令.");
                reference.DrawContent("#define UNITY_UNROLL        [unroll]", "添加在for语句上面,表示此循环在编绎时会展开所有循环代码，以必竟for循环中的跳转指令,会产生较多的编绎代码.");
                reference.DrawContent("#define UNITY_UNROLLX(_x)   [unroll(_x)]", "添加在for语句上面,功能同上，同时可以指定具体的展开次数.");
                reference.DrawContent("#define UNITY_LOOP          [loop]", "添加在for语句上面,表示此循环不可展开，正常执行跳转."); 
            }
        }

        public void DrawTitleShaderTargetModel()
        {
            reference.DrawTitle("Shader Target Model");
        }

        public void DrawContentShaderTargetModel()
        {
            reference.DrawContent("#if SHADER_TARGET < 30", "对应于#pragma target的值，2.0就是20，3.0就是30。");
        }

        public void DrawTitleUnityVersion()
        {
            reference.DrawTitle("Unity version");
        }

        public void DrawContentUnityVersion()
        {
            reference.DrawContent("#if UNITY_VERSION >= 500", "Unity版本号判断，500表示5.0.0");
        }

        public void DrawTitlePlatformDifferenceHelpers()
        {
            reference.DrawTitle("Platform Difference Helpers");
        }

        public void DrawContentPlatformDifferenceHelpers()
        {
            reference.DrawContent("UNITY_UV_STARTS_AT_TOP", "一般此判断当前平台是DX(UV原点在左上角)还是OpenGL(UV原点在左下角)");
            reference.DrawContent("UNITY_NO_SCREENSPACE_SHADOWS", "定义移动平台不进行Cascaded ScreenSpace Shadow.");
        }

        public void DrawTitleUI()
        {
            reference.DrawTitle("UI");
        }

        public void DrawContentUI()
        {
            reference.DrawContent("UNITY_UI_CLIP_RECT", "当父级物体有Rect Mask 2D组件时激活.\n" +
                                    "需要先手动定义此变体#pragma multi_compile _ UNITY_UI_CLIP_RECT\n" +
                                    "同时需要声明：_ClipRect(一个四维向量，四个分量分别表示RectMask2D的左下角点的xy坐标与右上角点的xy坐标.)\n" +
                                    "UnityGet2DClipping (float2 position, float4 clipRect)即可实现遮罩.");
        }

        public void DrawTitleLighting()
        {
            reference.DrawTitle("Lighting");
        }

        public void DrawContentLighting(bool isFold)
        {
            if (isFold)
            {
                reference.DrawContent("UNITY_SHOULD_SAMPLE_SH", "是否进行计算SH（光照探针与顶点着色）\n" +
                                        "-当静态与动态Lightmap启用时，此项不激活.\n" +
                                        "-当静态与动态Lightmap没有启用时，此项激活.\n" +
                                        "-除ForwardBase其它Pass都不激活，每个Pass需要指定UNITY_PASS_FORWARDADD、UNITY_PASS_SHADOWCASTER等.");
                reference.DrawContent("UNITY_SAMPLE_FULL_SH_PER_PIXEL", "光照贴图uv和来自SHL2的环境颜色在顶点和像素内插器中共享,在启用静态lightmap和LIGHTPROBE_SH时，在像素着色器中执行完整的SH计算。");
                reference.DrawContent("HANDLE_SHADOWS_BLENDING_IN_GI", "当同时定义了SHADOWS_SCREEN与LIGHTMAP_ON时开启.");
                reference.DrawContent("UNITY_SHADOW_COORDS(N)", "定义一个float4类型的变量_ShadowCoord,语义为第N个TEXCOORD.");
                reference.DrawContent("V2F_SHADOW_CASTER;", "用于\"LightMode\" = \"ShadowCaster\"中,相当于定义了float4 pos:SV_POSITION.");
            }
        }

        public void DrawTitleOther()
        {
            reference.DrawTitle("Other");
        }

        public void DrawContentOther(bool isFold)
        {
            if (isFold)
            {
                reference.DrawContent("UNITY_SHADER_NO_UPGRADE", "令Shader不自动更新API,只需把语句用注释的形式写在shader中任意位置即可.");
                reference.DrawContent("UNITY_NO_DXT5nm", "法线纹理是否不采用DXT5压缩,移动平台(在编缉器下切换到Android/IOS平台也可以)是，非移动平台否.");
                reference.DrawContent("UNITY_ASTC_NORMALMAP_ENCODING", "当在移动平台(Android/IOS/TVOS)中,法线纹理采用类DXT5nm的压缩时启用，可通过PlayerSetting中设置NormalMapEncoding的方式.");
                reference.DrawContent("SHADERGRAPH_PREVIEW", "在ShaderGraph中的Custom Function自义定节点上使用，用于判断是否处于SG面板预览中.");
            }
        }
    }
}


