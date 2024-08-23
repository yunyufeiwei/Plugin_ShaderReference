using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace yuxuetian.tools.shaderReference
{
    public class ShaderReferenceRenderState : EditorWindow
    {
        private ShaderReferenceUtil reference = new ShaderReferenceUtil();

        //标题函数
        public void DrawTitleCull()
        {
            reference.DrawTitle("Cull" , "https://docs.unity3d.com/cn/2023.2/Manual/SL-Cull.html");
        }
        
        //具体内容的函数，布尔值用来在外面控制折叠效果，内容太多时不方便查看，通过折叠更方便查看
        public void DrawContentCull(bool isFold)
        {
            if (isFold)
            {
                reference.DrawContent("Cull Back | Front | Off" , "[Enum(UnityEngine.Rendering.CullMode)]\n" + 
                                         "背面剔除,默认值为Back。\nBack：表示剔除背面，也就是显示正面，这也是最常用的设置。\nFront：表示剔除前面，只显示背面。\nOff:表示关闭剔除，也就是正反面都渲染。");
            }
        }
        
    }
}

