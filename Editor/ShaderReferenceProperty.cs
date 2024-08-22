using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using yuxuetian.tools.shaderReference;

namespace yuxuetian.tools.shaderReference
{
    public class ShaderReferenceProperty : EditorWindow
    {
        private ShaderReferenceUtil pfff = new ShaderReferenceUtil();
        public void DrawMainGUI()
        {
            pfff.DrawTitle("Properties");
        }
    }
}

