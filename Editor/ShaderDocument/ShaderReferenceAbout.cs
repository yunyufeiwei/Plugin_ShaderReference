using UnityEngine;
using UnityEditor;

namespace yuxuetian
{
    public class ShaderReferenceAbout : EditorWindow
    {
        private ShaderReferenceUtil _reference = new ShaderReferenceUtil();
        
        private Texture2D _texUnity;
        private Texture texUnity
        {
            get
            {
                if (_texUnity == null)
                {
                    string textureString = "Packages/com.yuxuetian.shaderreference/Resource/Texture/Icon/kingame.png";
                    
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
            _reference.DrawContentSite("Git主页：","https://github.com/yunyufeiwei/CustomShaderReference");
            _reference.DrawContentSite("知乎主页：", "https://www.zhihu.com/people/XiaoYu");
            _reference.DrawContentSite("B站主页：", "https://space.bilibili.com/382898888");
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

