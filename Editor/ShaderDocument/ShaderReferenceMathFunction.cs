using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace yuxuetian
{
    public class ShaderReferenceMathGraphical : EditorWindow
    {
        private ShaderReferenceUtil _reference = new ShaderReferenceUtil();
        
        private Texture2D _MathGraphical;
        
        private Texture texUnity
        {
            get
            {
                if (_MathGraphical == null)
                {
                    string textureString = "Packages/com.yuxuetian.shaderreference/Resource/Texture/MathGraphical/MathFunction.png";
                    
                    _MathGraphical = LoadTextureFromPath(textureString);
                }
                
                return _MathGraphical;
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
        
        public void DrawTitle()
        {
            _reference.DrawTitle("数学函数图形");
        }
        
        public void DrawContent()
        {
            
            GUI.DrawTexture(new Rect(0,50.0f,1700.0f,913.0f),texUnity,ScaleMode.StretchToFill);
            
        }

    }
}
