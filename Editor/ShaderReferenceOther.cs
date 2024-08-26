using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace yuxuetian.tools.shaderReference
{
    public class ShaderReferenceOther : EditorWindow
    {
        private ShaderReferenceUtil reference = new ShaderReferenceUtil();

        public void DrawTitleOther()
        {
            reference.DrawTitle("Other");
        }

        public void DrawContentOther(bool isFold)
        {
            if (isFold)
            {
                reference.DrawContent("#include \"Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl\n" +
                                      "#include \"Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl\"\n" +
                                      "#include \"Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl\"\n" +
                                      "#include \"Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl\n" + 
                                      "#include \"Packages/com.unity.render-pipelines.core/ShaderLibrary/UnityInstancing.hlsl");
                reference.DrawContent("CBUFFER_START(UnityPerMaterial)/CBUFFER_END","将材质属性面板中的变量定义在这个常量缓冲区中，用于支持SRP Batcher.");
                reference.DrawContent("HLSLPROGRAM/ENDHLSL", "HLSL代码的开始与结束.");
                reference.DrawContent("HLSLINCLUDE/ENDHLSL", "通常用于定义多段vert/frag函数，然后这段CG代码会插入到所有Pass的CG中，根据当前Pass的设置来选择加载.");
                reference.DrawContent("LOD", "Shader LOD，可利用脚本来控制LOD级别，通常用于不同配置显示不同的SubShader。注意SubShader要从高往低写，要不然会无法生效.");
                reference.DrawContent("Category{}", "定义一组所有SubShader共享的命令，位于SubShader外面。");
                reference.DrawContent("Name \"MyPassName\"", "给当前Pass指定名称，以便利用UsePass进行调用。");
                reference.DrawContent("UsePass \"Shader/NAME\"", "调用其它Shader中的Pass，注意Pass的名称要全部大写！Shader的路径也要写全，以便能找到具体是哪个Shader的哪个Pass。另外加了UsePass后，也要注意相应的Properties要自行添加。");
                reference.DrawContent("CustomEditor \"name\"", "自定义材质面板，name为自定义的脚本名称。可利用此功能对材质面板进行个性化自定义。");
                reference.DrawContent("Fallback \"name\"", "备胎，当Shader中没有任何SubShader可执行时，则执行FallBack。默认值为Off,表示没有备胎。\n比如URP下默认的紫色报错Shader:Fallback \"Hidden/Universal Render Pipeline/FallbackError\"");
            }
        }
    }
}

