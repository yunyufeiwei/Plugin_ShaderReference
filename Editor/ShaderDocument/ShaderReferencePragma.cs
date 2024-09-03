using UnityEditor;

namespace yuxuetian
{
    public class ShaderReferencePragma : EditorWindow
    {
        private ShaderReferenceUtil _reference = new ShaderReferenceUtil();

        public void DrawTitlePragma()
        {
            _reference.DrawTitle("Pragma(编译指令)","https://docs.unity3d.com/2023.2/Documentation/Manual/SL-PragmaDirectives.html");
        }

        public void DrawContentPragma(bool isFold)
        {
            if (isFold)
            {
                _reference.DrawContent("#Pragma是一个预处理指令，一般用来为Shader编译器提供额外的编译信息。为了便于管理，一般写在着色器头部。\n"+
                                         "#pragma target XXX,Shader编绎目标级别，默认值为2.5。可以通过#if(SHADER_TARGET<30)来做分支判断。");
            }
        }

        public void DrawTitletPragmaTarget()
        {
            _reference.DrawTitle("Target","https://docs.unity3d.com/cn/2023.2/Manual/SL-ShaderCompileTargets.html");
        }

        public void DrawContentPragmaTarget(bool isFold)
        {
            if (isFold)
            {
                _reference.DrawContent("● #pragma target 2.0：\n"+
                                         "● #pragma target 2.5: derivatives(衍生品)\n" +
                                         "● #pragma target 3.0: 2.5 + interpolators 10(内插器) + samplelod + fragcoord\n" + 
                                         "● #pragma target 3.5: (相当于OpenGL ES3.0): 3.0 + interpolators15 + mrt4 + integers + 2darray + instancing\n" +
                                         "● #pragma target 4.0: 3.5 + geometry\n" +
                                         "● #pragma target 4.5: (相当于OpenGL ES3.1): 3.5 + compute + randomwrite\n" +
                                         "● #pragma target 4.6: 4.0 + cubearray + tesshw + tessellation\n" +
                                         "● #pragma target 5.0: 4.0 + compute + randomwrite + tesshw + tessellation");
            }
        }

        public void DrawContentPragmaRequire(bool isFold)
        {
            if (isFold)
            {
                _reference.DrawContent("#pragma require xxx", "表明shader需要的特性功能\n" +
                                         "● interpolators10: 至少支持10个插值器(从顶点到片断)\n" +
                                         "● interpolators15: 至少支持15个插值器(从顶点到片断)\n" +
                                         "● interpolators32: 至少支持32个插值器(从顶点到片断)\n" +
                                         "● mrt4: 至少支持4个Multiple Render Targets\n" +
                                         "● mrt8: 至少支持8个Multiple Render Targets\n" +
                                         "● derivatives: 片断着色器支持偏导函数(ddx/ddy)\n" +
                                         "● samplelod: 纹理LOD采样\n" +
                                         "● fragcoord: 将像素的位置(XY为屏幕上的坐标,ZW为齐次裁剪空间下的深度)传入到片断着色器中\n" +
                                         "● integers: 支持真正的整数类型,包括位/移位操作\n" +
                                         "● 2darray: 2D纹理数组\n" +
                                         "● cubearray: Cubemap纹理数组\n" +
                                         "● instancing: GPU实例化\n" +
                                         "● geometry: 几何着色器\n" +
                                         "● compute: Compute Shader\n" +
                                         "● randomwrite: 可以编写任意位置的一些纹理和缓冲区 (UAV,unordered access views)\n" +
                                         "● tesshw: GPU支持硬件的tessellation\n" +
                                         "● tessellation: Tessellation hull/domain Shader\n" +
                                         "● msaatex: 能够访问多采样纹理\n" +
                                         "● framebufferfetch: 主要用于在延迟渲染中减少采样的带宽消耗");
            }
        }

        public void DrawTitlePragmaShaderVariant()
        {
            _reference.DrawTitle("ShaderVariant(Shader变体)");
        }

        public void DrawContentPragmaShaderVariant(bool isFold)
        {
            if (isFold)
            {
                _reference.DrawContent("#pragma shader_feature", "变体声明，常用于不需要程序控制开关的关键字，在编缉器的材质上设置，打包时会自动过滤");
                _reference.DrawContent("#pragma shader_feature_local", "声明本地变体(shader_feature)，unity2019才支持的功能，每个Shader最多可以有64个本地变体，不占用全局变体的数量.");
                _reference.DrawContent("#pragma multi_compile", "变体声明，在打包时会把所有变体都打包进去，这是它与feature的区别.\n" +
                                                               "定义关键字时如果加两个下划线，则表示定义一个空的变体，主要目的是为了节省关键字.\n" +
                                                               "当使用shader变体时，记住在unity中全局关键字最多只有256个,而且在内部已经用了60个了,所以记得不要超标了.");
                _reference.DrawContent("#pragma multi_compile_local", "声明本地变体(multi_compile)，unity2019才支持的功能，每个Shader最多可以有64个本地变体，不占用全局变体的数量.");
                _reference.DrawContent("#pragma skip_variants XXX01 XXX02...", "剔除指定的变体，可同时剔除多个");
                _reference.DrawContent("#pragma shader_feature EDITOR_VISUALIZATION", "开启Material Validation,Scene视图中的模式，用于查看超出范围的像素颜色");
            }
        }

        public void DrawTitlePragmaOther()
        {
            _reference.DrawTitle("Other");
        }
        public void DrawContentPragmaOther(bool isFold)
        {
            if (isFold)
            {
                _reference.DrawContent("#pragma prefer_hlslcc gles", "在OpenGL ES2.0中使用HLSLcc编译器,目前除了OpenGL ES2.0全都默认使用HLSLcc编译器.");
                _reference.DrawContent("#include \"XXX.hlsl\"", "引入hlsl文件");
                _reference.DrawContent("#include_with_pragmas \"XXX.hlsl\"", "引入hlsl文件,同时也会使用hlsl文件中的#pragma指令");
                _reference.DrawContent("#pragma editor_sync_compilation", "强制某个Shader以同步的方式进行编绎(当此Shader的某个变体被第一次渲染时，在还没有编绎完成前不会渲染出来;如果不加此指令则会先用一个青色的临时占位进行渲染显示。)");
                _reference.DrawContent("#pragma multi_compile_fog", "雾类型定义\nFOG_EXP FOG_EXP2 FOG_LINEAR");
                _reference.DrawContent("#pragma fragmentoption ARB_precision_hint_fastest", "最快的,意思就是会用低精度(一般是指fp16),以提升片段着色器的运行速度,减少时间.");
                _reference.DrawContent("#pragma fragmentoption ARB_precision_hint_nicest", "最佳的,会用高精度(一般是指fp32),可能会降低运行速度,增加时间.");
                _reference.DrawContent("#pragma enable_d3d11_debug_symbols", "开启d3d11调试，加此命令后相关的名称与代码不会被剔除，便于在调试工具中进行查看分析");
                _reference.DrawContent("#pragma only_renderers", "仅编译指定平台的Shader\n" +
                                         "1. d3d11 - Direct3D 11/12\n" +
                                         "2. glcore - OpenGL 3.x/4.x\n" +
                                         "3. gles - OpenGL ES 2.0\n" +
                                         "4. gles3 - OpenGL ES 3.x\n" +
                                         "5. metal - iOS/Mac Metal\n" +
                                         "6. vulkan - Vulkan\n" +
                                         "7. d3d11_9x - Direct3D 11 9.x功能级别，通常在WSA平台上使用\n" +
                                         "8. xboxone - Xbox One\n" +
                                         "9. ps4 - PlayStation 4\n" +
                                         "10.psp2 - PlayStation Vita\n" +
                                         "11.n3ds - Nintendo 3DS\n" +
                                         "12.wiiu - Nintendo Wii U");
                _reference.DrawContent("#pragma exclude_renderers", "剔除掉指定平台的相关代码,列表参考上面");
                _reference.DrawContent("#define NAME", "定义一个叫NAME的字段，在CG代码中可以通过#if defined(NAME)来判断走不同的分支。");
                _reference.DrawContent("#define NAME 1", "定义一个叫NAME的字段并且它的值为1.\n" +
                                         "1.可以通过#if defined(NAME)来判断走不同的分支。\n" +
                                         "2.可以通过#if NAME来判断走不同的分支。（此时值为非0时才有效，为0时不走此分支）\n" +
                                         "3.还可以直接通过NAME来得到它的值，比如上面的1。");
                _reference.DrawContent("#error xxx", "多用于分支的判断中，利用此语句可直接输出一条报错信息，内容为xxx");
            }
        }
    }
}

