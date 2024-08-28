using UnityEngine;
using UnityEditor;

namespace Editor.ShaderDocument
{
    public class ShaderReferenceStudyWebsite : EditorWindow
    {
        private ShaderReferenceUtil _reference = new ShaderReferenceUtil();

        public void DrawTitleStudyWebsiteProgram()
        {
            _reference.DrawTitle("编程网站");
        }

        public void DrawContentStydyWebsityProgram()
        {
            
            
        }

        public void DrawTitleStydyWebsityGraphics()
        {
            _reference.DrawTitle("计算机图形");
        }

        public void DrawContentStydyWebsityGraphics()
        {
            GUIStyle labelStyle = new GUIStyle("label");
            labelStyle.fontStyle = FontStyle.Normal;
            labelStyle.fontSize = 16;
            labelStyle.alignment = TextAnchor.MiddleLeft;
            
            EditorGUILayout.BeginVertical();
            
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("OpenGL网址：", GUILayout.MaxWidth(120.0f), GUILayout.MaxHeight(20.0f)))
            {
                Application.OpenURL("https://learnopengl-cn.github.io/");
            }
            EditorGUILayout.LabelField("        https://learnopengl-cn.github.io/",labelStyle);
            EditorGUILayout.EndHorizontal();
            
            EditorGUILayout.EndVertical();
        }
    }
}

