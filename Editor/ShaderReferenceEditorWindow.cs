using UnityEngine;
using UnityEditor;

namespace yuxuetian.tools.shaderReference
{
    public class ShaderReferenceEditorWindow : EditorWindow
    {
        #region 折叠属性布尔值
        private bool _isFoldPipelineApplicationStage = true;
        private bool _isFoldPipelineGeometryStage = true;
        private bool _isFoldPipelineRasterizerStage = true;
        private bool _isFoldPipelineShaderLab = true;
        
        private bool _isFoldProperty = true;
        private bool _isFoldPropertyAttribute = true;
        
        private bool _isFoldSemanticsAttribute = true;
        private bool _isFoldSemanticsVaryings = true;

        private bool _isFoldTagQueue = true;
        private bool _isFoldTagRenderType = true;
        private bool _isFoldTagLightMode = true;
        private bool _isFoldTagDisableBatching = true;
        private bool _isFoldTagIgnoreProjector = true;
        private bool _isFoldTagForceNoShadowCasting = true;
        private bool _isFoldTagPreviewType = true;
        private bool _isFoldTagCanUseSpriteAtlas = true;
        private bool _isFoldTagPerformanceChecks = true;

        private bool _isFoldRenderStateCull = true;
        private bool _isFoldRenderStateStencilTest = true;
        private bool _isFoldRenderStateDepthTest = true;
        private bool _isFoldRenderStateColorMask = true;
        private bool _isFoldRenderStateBlend = true;

        private bool _isFoldPragma = true;
        #endregion
        
        private Vector2 _scrollPos;
        private int _selectedTabID;  
        private string[] _tabName = new string[]{"Pipeline(渲染管线)", 
                                                "Property(属性)" , 
                                                "Semantics(语义)",
                                                "Tags(标签)",
                                                "Render State(渲染状态)",
                                                "Pragma(编译指令)",
                                                "Transformation(变换)"};
       
        private ShaderReferencePipeline _pipeline;
        private ShaderReferenceProperty _property;
        private ShaderReferenceSemantics _semantics;
        private ShaderReferenceTags _tags;
        private ShaderReferenceRenderState _renderState;
        private ShaderReferencePragma _pragma;
        private ShaderReferenceTransformation _transformation;
        
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
            
            float width = 170.0f;
            float height = position.height - 20;
            
            //左侧区域绘制
            EditorGUILayout.BeginVertical(EditorStyles.helpBox , GUILayout.MaxWidth(width) , GUILayout.MaxHeight(height));
            _selectedTabID = GUILayout.SelectionGrid(_selectedTabID, _tabName, 1);            
            EditorGUILayout.EndVertical();

            //右侧区域绘制
            EditorGUILayout.BeginVertical(EditorStyles.helpBox , GUILayout.MinWidth(position.width - width), GUILayout.MinHeight(height));
            DrawMainUI(_selectedTabID);
            EditorGUILayout.EndVertical();
            
            EditorGUILayout.EndHorizontal();
        }

        void OnEnable()
        {
            _selectedTabID = EditorPrefs.HasKey("yuxuetian_SelectedTabID") ? EditorPrefs.GetInt("yuxuetian_SelectedTabID") : 0;
            
            _pipeline = ScriptableObject.CreateInstance<ShaderReferencePipeline>();
            _property = ScriptableObject.CreateInstance<ShaderReferenceProperty>();
            _semantics = ScriptableObject.CreateInstance<ShaderReferenceSemantics>();
            _tags = ScriptableObject.CreateInstance<ShaderReferenceTags>();
            _renderState = ScriptableObject.CreateInstance<ShaderReferenceRenderState>();
            _pragma = ScriptableObject.CreateInstance<ShaderReferencePragma>();
            _transformation = ScriptableObject.CreateInstance<ShaderReferenceTransformation>();
        }

        void OnDisable()
        {
            EditorPrefs.SetInt("yuxuetian_SelectedTabID", _selectedTabID);
        }

        void DrawMainUI(int _selectedTabID)
        {
            switch (_selectedTabID)
            {
                case 0:
                    //滑动条
                    _scrollPos = EditorGUILayout.BeginScrollView(_scrollPos);
                    
                    _pipeline.DrawTitleApplicationStage();
                    _isFoldPipelineApplicationStage = EditorGUILayout.Foldout(_isFoldPipelineApplicationStage, "应用程序阶段");
                    _pipeline.DrawContentApplicationStage(_isFoldPipelineApplicationStage);
                    
                    _pipeline.DrawTitleGeometryStage();
                    _isFoldPipelineGeometryStage = EditorGUILayout.Foldout(_isFoldPipelineGeometryStage, "几何阶段");
                    _pipeline.DrawContentGeometryStage(_isFoldPipelineGeometryStage);
                    
                    _pipeline.DrawTitleResterizerStage();
                    _isFoldPipelineRasterizerStage = EditorGUILayout.Foldout(_isFoldPipelineRasterizerStage, "光栅化阶段");
                    _pipeline.DrawContentResterizerStage(_isFoldPipelineRasterizerStage);
                    
                    _pipeline.DrawTitleShaderLab();
                    _isFoldPipelineShaderLab = EditorGUILayout.Foldout(_isFoldPipelineShaderLab, "Shader Lab");
                    _pipeline.DrawContentShaderLab(_isFoldPipelineShaderLab);
                    
                    EditorGUILayout.EndScrollView();
                    break;
                case 1:
                    _scrollPos = EditorGUILayout.BeginScrollView(_scrollPos);
                    
                    _property.DrawTitleProperty();
                    _isFoldProperty = EditorGUILayout.Foldout(_isFoldProperty, "属性");
                    _property.DrawContentProperty(_isFoldProperty);
                    
                    _property.DrawTitleAttribute();
                    _isFoldPropertyAttribute = EditorGUILayout.Foldout(_isFoldPropertyAttribute, "属性形式");
                    _property.DrawContentAttribute(_isFoldPropertyAttribute);
                    
                    EditorGUILayout.EndScrollView();
                    break;
                case 2:
                    _scrollPos = EditorGUILayout.BeginScrollView(_scrollPos);
                    _semantics.DrawTitleAttribute();
                    _isFoldSemanticsAttribute = EditorGUILayout.Foldout(_isFoldSemanticsAttribute, "Attribute");
                    _semantics.DrawContentAttribute(_isFoldSemanticsAttribute);
                    
                    _semantics.DrawTitleVaryings();
                    _isFoldSemanticsVaryings = EditorGUILayout.Foldout(_isFoldSemanticsVaryings, "Varying");
                    _semantics.DrawContentVaryings(_isFoldSemanticsVaryings);
                    
                    EditorGUILayout.EndScrollView();
                    break;
                case 3:
                    _scrollPos = EditorGUILayout.BeginScrollView(_scrollPos);
                    
                    _tags.DrawTitleTag();
                    _tags.DrawContentTag();
                    
                    _tags.DrawTitleRenderPipeline();
                    _tags.DrawContentRenderPipeline();
                    
                    _tags.DrawTitleQueue();
                    _isFoldTagQueue = EditorGUILayout.Foldout(_isFoldTagQueue, "Queue");
                    _tags.DrawContentQueue(_isFoldTagQueue);
                    
                    _tags.DrawTitleRenderType();
                    _isFoldTagRenderType = EditorGUILayout.Foldout(_isFoldTagRenderType, "RenderType");
                    _tags.DrawContentRenderType(_isFoldTagRenderType);
                    
                    _tags.DrawTitleLightMode();
                    _isFoldTagLightMode = EditorGUILayout.Foldout(_isFoldTagLightMode, "LightMode");
                    _tags.DrawContentLightMode(_isFoldTagLightMode);
                    
                    _tags.DrawTitleDisableBatching();
                    _isFoldTagDisableBatching = EditorGUILayout.Foldout(_isFoldTagDisableBatching, "DisableBatching");
                    _tags.DrawContentDisableBatching(_isFoldTagDisableBatching);
                    
                    _tags.DrawTitleIgnoreProjector();
                    _isFoldTagIgnoreProjector = EditorGUILayout.Foldout(_isFoldTagIgnoreProjector, "IgnoreProjector");
                    _tags.DrawContentIgnoreProjector(_isFoldTagIgnoreProjector);
                    
                    _tags.DrawTitleForceNoShadowCasting();
                    _isFoldTagForceNoShadowCasting = EditorGUILayout.Foldout(_isFoldTagForceNoShadowCasting, "ForceNoShadowCasting");
                    _tags.DrawContentForceNoShadowCasting(_isFoldTagForceNoShadowCasting);

                    _tags.DrawTitlePreviewType();
                    _isFoldTagPreviewType = EditorGUILayout.Foldout(_isFoldTagPreviewType, "PreviewType");
                    _tags.DrawContentPreviewType(_isFoldTagPreviewType);

                    _tags.DrawTitleCanUseSpriteAtlas();
                    _isFoldTagCanUseSpriteAtlas = EditorGUILayout.Foldout(_isFoldTagCanUseSpriteAtlas, "CanUseSpriteAltas");
                    _tags.DrawContentCanUseSpriteAtlas(_isFoldTagCanUseSpriteAtlas);
                    
                    _tags.DrawTitlePerformanceChecks();
                    _isFoldTagPerformanceChecks = EditorGUILayout.Foldout(_isFoldTagPerformanceChecks, "PerformanceChecks");
                    _tags.DrawContentPerformanceChecks(_isFoldTagPerformanceChecks);
                    
                    EditorGUILayout.EndScrollView();
                    break;
                case 4:
                    _scrollPos = EditorGUILayout.BeginScrollView(_scrollPos);

                    _renderState.DrawTitleCull();
                    _isFoldRenderStateCull = EditorGUILayout.Foldout(_isFoldRenderStateCull, "Cull");
                    _renderState.DrawContentCull(_isFoldRenderStateCull);
                    
                    _renderState.DrawTitleStencilTest();
                    _isFoldRenderStateStencilTest = EditorGUILayout.Foldout(_isFoldRenderStateStencilTest, "Stencil Test");
                    _renderState.DrawContentStencilTest(_isFoldRenderStateStencilTest);
                    
                    _renderState.DrawTitleDepthTest();
                    _isFoldRenderStateDepthTest = EditorGUILayout.Foldout(_isFoldRenderStateDepthTest, "Depth Test");
                    _renderState.DrawContentDepthTest(_isFoldRenderStateDepthTest);
                    
                    _renderState.DrawTitleColorMask();
                    _isFoldRenderStateColorMask = EditorGUILayout.Foldout(_isFoldRenderStateColorMask, "ColorMask");
                    _renderState.DrawContentColorMask(_isFoldRenderStateColorMask);
                    
                    _renderState.DrawTitleBlend();
                    _isFoldRenderStateBlend = EditorGUILayout.Foldout(_isFoldRenderStateBlend, "Blend");
                    _renderState.DrawContentBlend(_isFoldRenderStateBlend);
                    
                    _renderState.DrawTitleOther();
                    _renderState.DrawContentOther();
                    
                    EditorGUILayout.EndScrollView();
                    break;
                case 5:
                    _pragma.DrawTitlePragma();
                    _isFoldPragma = EditorGUILayout.Foldout(_isFoldPragma, "Pragma");
                    _pragma.DrawContentPragma(_isFoldPragma);
                    break;
                case 6:
                    break;
            }
        }
    }
}


