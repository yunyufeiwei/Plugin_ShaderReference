using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace yuxuetian.tools.shaderReference
{
    public class ShaderReferencePragma : EditorWindow
    {
        private ShaderReferenceUtil reference = new ShaderReferenceUtil();

        public void DrawTitlePragma()
        {
            reference.DrawTitle("Pragma(编译指令)");
        }

        public void DrawContentPragma(bool isFold)
        {
            reference.DrawContent("#pragma target 2.0", "Shader编绎目标级别，默认值为2.5\n" +
                                     "#pragma target 2.5,在Unity所有支持的平台上都能够工作。DX9着色器 model2.0\n" + 
                                     "#pragma target 3.0");
        }
    }
}

