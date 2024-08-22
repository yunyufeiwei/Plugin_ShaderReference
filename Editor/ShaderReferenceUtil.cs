using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace yuxuetian.tools.shaderReference
{
    public class ShaderReferenceUtil
    {
        public void DrawTitle(string str)
        {
            EditorGUILayout.LabelField(str, EditorStyles.miniButton);
        }

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
                    style02.wordWrap = true;
                    style02.richText = true;
                    style02.fontSize = 14;
                }
                return style02;
            }
        }

        //用来显示垂直内容的背景样式
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

