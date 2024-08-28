using UnityEngine;
using UnityEditor;

namespace Editor.ShaderDocument
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

        public void DrawContentSite(string buttonName, string WebsiteName)
        {
            GUIStyle labelStyle = new GUIStyle("label");
            labelStyle.fontStyle = FontStyle.Normal;
            labelStyle.fontSize = 16;
            labelStyle.alignment = TextAnchor.MiddleLeft;
            
            EditorGUILayout.BeginVertical();
            
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button(buttonName, GUILayout.MaxWidth(180.0f), GUILayout.MaxHeight(20.0f)))
            {
                Application.OpenURL(WebsiteName);
            }
            EditorGUILayout.TextArea(WebsiteName,labelStyle);
            EditorGUILayout.EndHorizontal();
            
            EditorGUILayout.EndVertical();
        }

        //主按钮的显示样式
        private GUIStyle _style01;
        private GUIStyle Style01
        {
            get
            {
                if (_style01 == null)
                {
                    _style01 = new GUIStyle("label");
                    _style01.alignment = TextAnchor.MiddleLeft;
                    _style01.wordWrap = false;
                    _style01.fontSize = 16;
                    _style01.fontStyle = FontStyle.Normal;
                }
                return _style01;
            }
        }

        private GUIStyle _style02;

        private GUIStyle Style02
        {
            get
            {
                if (_style02 == null)
                {
                    _style02 = new GUIStyle("label");
                    _style02.alignment = TextAnchor.MiddleLeft;
                    _style02.wordWrap = true;
                    _style02.richText = true;
                    _style02.fontSize = 14;
                }
                return _style02;
            }
        }

        //用来显示垂直内容的背景样式，就是将Content里面的内容用一个box的背景框内。
        private GUIStyle _style03;

        private GUIStyle Style03
        {
            get
            {
                if (_style03 == null)
                {
                    _style03 = new GUIStyle("box");
                }
                return _style03;
            }
        }
    } 
}

