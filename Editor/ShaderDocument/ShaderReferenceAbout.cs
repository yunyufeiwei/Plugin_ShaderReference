using UnityEngine;
using UnityEditor;

namespace Editor.ShaderDocument
{
    public class ShaderReferenceAbout : EditorWindow
    {
        private Texture2D _texUnity;
        private Texture texUnity
        {
            get
            {
                if (_texUnity == null)
                {
                    string textureString = "Packages/com.yuxuetian.shaderreference/Editor/Resource/kingame.png";
                    _texUnity = LoadTextureFromPath(textureString);
                }
                
                return _texUnity;
            }
        }

        private Texture2D LoadTextureFromPath(string path)
        {
            Texture2D texture = AssetDatabase.LoadAssetAtPath<Texture2D>(path);
            if (texture == null)
            {
                Debug.LogError($"Failed to load texture at path:{path}");
            }

            return texture;
        }
        
        public void DrawTitleURL()
        {
            GUIStyle labelStyle = new GUIStyle("label");
            labelStyle.fontStyle = FontStyle.Normal;
            labelStyle.fontSize = 18;
            labelStyle.alignment = TextAnchor.MiddleLeft;

            GUIStyle buttonStyle = new GUIStyle("button");

            EditorGUILayout.BeginVertical();
            GUILayout.Button("URL(网址链接)");
            
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Git主页：",GUILayout.MaxWidth(120.0f)))
            {
                Application.OpenURL("https://github.com/yunyufeiwei/CustomShaderReference");
            }
            EditorGUILayout.LabelField("Git地址：https://github.com/yunyufeiwei/CustomShaderReference",labelStyle);
            EditorGUILayout.EndHorizontal();
            
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("知乎主页：",GUILayout.MaxWidth(120.0f)))
            {
                Application.OpenURL("https://www.zhihu.com/people/XiaoYu");
            }
            EditorGUILayout.LabelField("知乎主页：https://www.zhihu.com/people/XiaoYu",labelStyle);
            EditorGUILayout.EndHorizontal();
            
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("B站主页：",GUILayout.MaxWidth(120.0f)))
            {
                Application.OpenURL("https://space.bilibili.com/382898888");
            }
            EditorGUILayout.LabelField("B站主页：https://space.bilibili.com/382898888",labelStyle);
            EditorGUILayout.EndHorizontal();
            
            EditorGUILayout.EndVertical();
        }
        
        public void DrawContentUnityTexture()
        {
            GUIContent content = new GUIContent();
            content.image = _texUnity;

            GUIStyle style = new GUIStyle();
            //修改box的尺寸
            style.fixedWidth = 120.0f;
            style.fixedHeight = 120.0f;
            // style.alignment = TextAnchor.MiddleCenter;

            GUILayout.Box(texUnity,style);
        }
    }
}

