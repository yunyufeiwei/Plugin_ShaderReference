using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace yuxuetian.tools.shaderReference
{
    public class ShaderReferenceUtil
    {
        //绘制标题的按钮，
        public void DrawTitle(string str , string address = null)
        {
            //str是显示在按钮上面的内容，address是打开的一个相关的链接(可以不填)，如果第二个参数没有输入，则点击没有网页跳转功能
            if (GUILayout.Button(str))
            {
                //如果第二个参数为空(也就是没有填)，则点击按钮没有链接跳转，直接返回。
                if (address == null)
                {
                    return;
                }
                Application.OpenURL(address);
            }
        }
        
        //绘制具体的内容
        public void DrawContent(string str , string massage = null)
        {
            EditorGUILayout.BeginVertical(Style03);
            EditorGUILayout.TextArea(str , Style01);
            EditorGUILayout.TextArea(massage , Style02);
            EditorGUILayout.EndVertical();
        }

        //主按钮的显示样式
        private GUIStyle style01;
        private GUIStyle Style01
        {
            get
            {
                if (style01 == null)
                {
                    style01 = new GUIStyle("label");
                    style01.alignment = TextAnchor.MiddleLeft;
                    style01.wordWrap = false;
                    style01.fontSize = 16;
                    style01.fontStyle = FontStyle.Normal;
                }
                return style01;
            }
        }

        private GUIStyle style02;

        private GUIStyle Style02
        {
            get
            {
                if (style02 == null)
                {
                    style02 = new GUIStyle("label");
                    style02.alignment = TextAnchor.MiddleLeft;
                    style02.wordWrap = true;
                    style02.richText = true;
                    style02.fontSize = 14;
                }
                return style02;
            }
        }

        //用来显示垂直内容的背景样式，就是将Content里面的内容用一个box的背景框内。
        private GUIStyle style03;

        private GUIStyle Style03
        {
            get
            {
                if (style03 == null)
                {
                    style03 = new GUIStyle("box");
                }
                return style03;
            }
        }
    } 
}

