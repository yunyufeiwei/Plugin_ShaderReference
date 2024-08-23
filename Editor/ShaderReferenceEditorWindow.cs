using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace yuxuetian.tools.shaderReference
{
    public class ShaderReferenceEditorWindow : EditorWindow
    {
        #region 折叠属性布尔值
        private bool isFold_PipelineApplicationStage = true;
        private bool isFold_PipelineGeometryStage = true;
        private bool isFold_PipelineRasterizerStage = true;
        private bool isFold_PipelineShaderLab = true;
        
        private bool isFold_Property = true;
        private bool isFold_PropertyAttribute = true;
        
        private bool isFold_SemanticsAttribute = true;
        private bool isFold_SemanticsVaryings = true;

        private bool isFold_TagQueue = true;
        private bool isFold_TagRenderType = true;
        private bool isFold_TagLightMode = true;
        private bool isFold_TagDisableBatching = true;
        private bool isFold_TagIgnoreProjector = true;
        private bool isFold_TagForceNoShadowCasting = true;
        private bool isFold_TagPreviewType = true;
        private bool isFold_TagCanUseSpriteAtlas = true;
        private bool isFold_TagPerformanceChecks = true;

        private bool isFold_RenderStateCull = true;
        #endregion
        

        private Vector2 scrollpos;
        private string[] tabName = new string[]{"Pipeline(渲染管线)", "Property(属性)" , "_Semantics(语义)","Tags(标签)","Render State(渲染状态)"};
        private int selectedTabID;  
        
        private ShaderReferencePipeline _pipeline;
        private ShaderReferenceProperty _property;
        private ShaderReferenceSemantics _semantics;
        private ShaderReferenceTags _tags;
        private ShaderReferenceRenderState _renderState;
        
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
            
            float _width = 160.0f;
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
            
            _pipeline = ScriptableObject.CreateInstance<ShaderReferencePipeline>();
            _property = ScriptableObject.CreateInstance<ShaderReferenceProperty>();
            _semantics = ScriptableObject.CreateInstance<ShaderReferenceSemantics>();
            _tags = ScriptableObject.CreateInstance<ShaderReferenceTags>();
            _renderState = ScriptableObject.CreateInstance<ShaderReferenceRenderState>();
        }

        void OnDisable()
        {
            EditorPrefs.SetInt("yuxuetian_SelectedTabID", selectedTabID);
        }

        void DrawMainUI(int selectedTabID)
        {
            switch (selectedTabID)
            {
                case 0:
                    //滑动条
                    scrollpos = EditorGUILayout.BeginScrollView(scrollpos);
                    
                    _pipeline.DrawTitleApplicationStage();
                    isFold_PipelineApplicationStage = EditorGUILayout.Foldout(isFold_PipelineApplicationStage, "应用程序阶段");
                    _pipeline.DrawContentApplicationStage(isFold_PipelineApplicationStage);
                    
                    _pipeline.DrawTitleGeometryStage();
                    isFold_PipelineGeometryStage = EditorGUILayout.Foldout(isFold_PipelineGeometryStage, "几何阶段");
                    _pipeline.DrawContentGeometryStage(isFold_PipelineGeometryStage);
                    
                    _pipeline.DrawTitleResterizerStage();
                    isFold_PipelineRasterizerStage = EditorGUILayout.Foldout(isFold_PipelineRasterizerStage, "光栅化阶段");
                    _pipeline.DrawContentResterizerStage(isFold_PipelineRasterizerStage);
                    
                    _pipeline.DrawTitleShaderLab();
                    isFold_PipelineShaderLab = EditorGUILayout.Foldout(isFold_PipelineShaderLab, "Shader Lab");
                    _pipeline.DrawContentShaderLab(isFold_PipelineShaderLab);
                    
                    EditorGUILayout.EndScrollView();
                    break;
                case 1:
                    scrollpos = EditorGUILayout.BeginScrollView(scrollpos);
                    
                    _property.DrawTitleProperty();
                    isFold_Property = EditorGUILayout.Foldout(isFold_Property, "属性");
                    _property.DrawContentProperty(isFold_Property);
                    
                    _property.DrawTitleAttribute();
                    isFold_PropertyAttribute = EditorGUILayout.Foldout(isFold_PropertyAttribute, "属性形式");
                    _property.DrawContentAttribute(isFold_PropertyAttribute);
                    
                    EditorGUILayout.EndScrollView();
                    break;
                case 2:
                    scrollpos = EditorGUILayout.BeginScrollView(scrollpos);
                    _semantics.DrawTitleAttribute();
                    isFold_SemanticsAttribute = EditorGUILayout.Foldout(isFold_SemanticsAttribute, "Attribute");
                    _semantics.DrawContentAttribute(isFold_SemanticsAttribute);
                    
                    _semantics.DrawTitleVaryings();
                    isFold_SemanticsVaryings = EditorGUILayout.Foldout(isFold_SemanticsVaryings, "Varying");
                    _semantics.DrawContentVaryings(isFold_SemanticsVaryings);
                    
                    EditorGUILayout.EndScrollView();
                    break;
                case 3:
                    scrollpos = EditorGUILayout.BeginScrollView(scrollpos);
                    
                    _tags.DrawTitleTag();
                    _tags.DrawContentTag();
                    
                    _tags.DrawTitleRenderPipeline();
                    _tags.DrawContentRenderPipeline();
                    
                    _tags.DrawTitleQueue();
                    isFold_TagQueue = EditorGUILayout.Foldout(isFold_TagQueue, "Queue");
                    _tags.DrawContentQueue(isFold_TagQueue);
                    
                    _tags.DrawTitleRenderType();
                    isFold_TagRenderType = EditorGUILayout.Foldout(isFold_TagRenderType, "RenderType");
                    _tags.DrawContentRenderType(isFold_TagRenderType);
                    
                    _tags.DrawTitleLightMode();
                    isFold_TagLightMode = EditorGUILayout.Foldout(isFold_TagLightMode, "LightMode");
                    _tags.DrawContentLightMode(isFold_TagLightMode);
                    
                    _tags.DrawTitleDisableBatching();
                    isFold_TagDisableBatching = EditorGUILayout.Foldout(isFold_TagDisableBatching, "DisableBatching");
                    _tags.DrawContentDisableBatching(isFold_TagDisableBatching);
                    
                    _tags.DrawTitleIgnoreProjector();
                    isFold_TagIgnoreProjector = EditorGUILayout.Foldout(isFold_TagIgnoreProjector, "IgnoreProjector");
                    _tags.DrawContentIgnoreProjector(isFold_TagIgnoreProjector);
                    
                    _tags.DrawTitleForceNoShadowCasting();
                    isFold_TagForceNoShadowCasting = EditorGUILayout.Foldout(isFold_TagForceNoShadowCasting, "ForceNoShadowCasting");
                    _tags.DrawContentForceNoShadowCasting(isFold_TagForceNoShadowCasting);

                    _tags.DrawTitlePreviewType();
                    isFold_TagPreviewType = EditorGUILayout.Foldout(isFold_TagPreviewType, "PreviewType");
                    _tags.DrawContentPreviewType(isFold_TagPreviewType);

                    _tags.DrawTitleCanUseSpriteAtlas();
                    isFold_TagCanUseSpriteAtlas = EditorGUILayout.Foldout(isFold_TagCanUseSpriteAtlas, "CanUseSpriteAltas");
                    _tags.DrawContentCanUseSpriteAtlas(isFold_TagCanUseSpriteAtlas);
                    
                    _tags.DrawTitlePerformanceChecks();
                    isFold_TagPerformanceChecks = EditorGUILayout.Foldout(isFold_TagPerformanceChecks, "PerformanceChecks");
                    _tags.DrawContentPerformanceChecks(isFold_TagPerformanceChecks);
                    
                    EditorGUILayout.EndScrollView();
                    break;
                case 4:
                    scrollpos = EditorGUILayout.BeginScrollView(scrollpos);

                    _renderState.DrawTitleCull();
                    isFold_RenderStateCull = EditorGUILayout.Foldout(isFold_RenderStateCull, "Cull");
                    _renderState.DrawContentCull(isFold_RenderStateCull);
                    
                    EditorGUILayout.EndScrollView();
                    break;
            }
        }
    }
}


