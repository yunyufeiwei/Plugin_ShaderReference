using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace yuxuetian.tools.shaderReference
{
    
    public class ShaderReferenceEditorWindow : EditorWindow
    {
        public bool isFold_ApplicationStage = true;
        public bool isFold_GeometryStage = true;
        public bool isFold_RasterizerStage = true;
        public bool isFold_Property = true;
        public bool isFold_Attribute = true;

        private Vector2 scrollpos;
        private string[] tabName = new string[]{"Pipeline", "Property"};
        private int selectedTabID;  
        
        private ShaderReferencePipeline pipline;
        private ShaderReferenceProperty property;
        
        //快捷键组合方式 #-shift %-Ctrl &-Alt
        [MenuItem("ArtTools/ShaderReference #R")]
        public static void ShowWindow()
        {
            EditorWindow window = GetWindow<ShaderReferenceEditorWindow>();
            window.titleContent = new GUIContent("Shader参考手册");
        }

        private void OnGUI()
        {
            //绘制两块区域，左边用来描述分类，右边则显示不同分类下的具体内容
            EditorGUILayout.BeginHorizontal();
            
            float _width = 150.0f;
            float _height = position.height - 30;
            
            //左侧区域绘制
            EditorGUILayout.BeginVertical(EditorStyles.helpBox , GUILayout.MaxWidth(_width) , GUILayout.MaxHeight(_height));
            selectedTabID = GUILayout.SelectionGrid(selectedTabID, tabName, 1);            
            EditorGUILayout.EndVertical();

            //右侧区域绘制
            EditorGUILayout.BeginVertical(EditorStyles.helpBox , GUILayout.MinWidth(position.width - _width), GUILayout.MinHeight(_height));
            DrawMainUI(selectedTabID);
            EditorGUILayout.EndVertical();
            
            EditorGUILayout.EndHorizontal();
        }

        void OnEnable()
        {
            selectedTabID = EditorPrefs.HasKey("yuxuetian_SelectedTabID") ? EditorPrefs.GetInt("yuxuetian_SelectedTabID") : 0;
            
            pipline = ScriptableObject.CreateInstance<ShaderReferencePipeline>();
            property = ScriptableObject.CreateInstance<ShaderReferenceProperty>();
        }

        void OnDisable()
        {
            EditorPrefs.SetInt("yuxuetian_SelectedTabID", selectedTabID);
        }

        void DrawMainUI(int selectedTabID)
        {
            switch (selectedTabID)
            {
                case 0 :
                    //滑动条
                    scrollpos = EditorGUILayout.BeginScrollView(scrollpos);
                    
                    pipline.DrawTitleApplicationStage();
                    isFold_ApplicationStage = EditorGUILayout.Foldout(isFold_ApplicationStage, "应用程序阶段");
                    pipline.DrawContentApplicationStage(isFold_ApplicationStage);
                    
                    pipline.DrawTitleGeometryStage();
                    isFold_GeometryStage = EditorGUILayout.Foldout(isFold_GeometryStage, "几何阶段");
                    pipline.DrawContentGeometryStage(isFold_GeometryStage);
                    
                    pipline.DrawTitleResterizerStage();
                    isFold_RasterizerStage = EditorGUILayout.Foldout(isFold_RasterizerStage, "光栅化阶段");
                    pipline.DrawContentResterizerStage(isFold_RasterizerStage);
                    
                    EditorGUILayout.EndScrollView();
                    break;
                case 1:
                    scrollpos = EditorGUILayout.BeginScrollView(scrollpos);
                    property.DrawTitleProperty();
                    isFold_Property = EditorGUILayout.Foldout(isFold_Property, "属性");
                    property.DrawContentProperty(isFold_Property);
                    property.DrawTitleAttribute();
                    isFold_Attribute = EditorGUILayout.Foldout(isFold_Attribute, "属性性质");
                    property.DrawContentAttribute(isFold_Attribute);
                    EditorGUILayout.EndScrollView();
                    break;
            }
        }
    }
}


