using UnityEditor;

namespace yuxuetian
{
    public class ShaderReferenceTags : EditorWindow
    {
        private ShaderReferenceUtil _reference = new ShaderReferenceUtil();

        public void DrawTitleTag()
        {
            _reference.DrawTitle("Tags" , "https://docs.unity3d.com/cn/current/Manual/SL-SubShaderTags.html"); 
        }
        public void DrawContentTag()
        {
            _reference.DrawContent("Tags { \"TagName1\" = \"Value1\" \"TagName2\" = \"Value2\" }", "Tag的语法结构，通过Tags{}来表示需要添加的标识,大括号内可以添加多组Tag（所以才叫Tags）,名称（TagName）和值（Value）是成对成对出现的，并且全部用字符串表示。");
        }

        public void DrawTitleRenderPipeline()
        {
            _reference.DrawTitle("RenderPipeline","https://docs.unity3d.com/cn/current/Manual/SL-SubShaderTags.html");
        }
        public void DrawContentRenderPipeline()
        {
            
            _reference.DrawContent("\"RenderPipeline\" = \"UniversalPipeline\"", "渲染管线标记，对应的管线C#代码UniversalRenderPipeline.cs中的Shader.globalRenderPipeline = UniversalPipeline,LightweightPipeline,只有带有UniversalPipeline或LightweightPipeline的Tag的SubShader才会生效." +
                                     "\n主要作用是用于标记当前这个SubShader是属于哪个管线下的.");
        }

        public void DrawTitleQueue()
        {
            _reference.DrawTitle("Queue","https://docs.unity3d.com/cn/current/Manual/SL-SubShaderTags.html");
            
        }
        public void DrawContentQueue(bool isFold)
        {
            if (isFold)
            {
                _reference.DrawContent("Queue", "渲染队列直接影响性能中的重复绘制，合理的队列可极大的提升渲染效率。\n渲染队列数<=2500的对象都被认为是不透明的物体（从前往后渲染），>2500的被认为是半透明物体（从后往前渲染）。\n\"Queue\" = \"Geometry+1\" 可通过在值后加数字的方式来改变队列。");
                _reference.DrawContent("\"Queue\" = \"Background\"", "值为1000，此队列的对象最先进行渲染。");
                _reference.DrawContent("\"Queue\" = \"Geometry\"", "默认值，值为2000，通常用于不透明对象，比如场景中的物件与角色等。");
                _reference.DrawContent("\"Queue\" = \"AlphaTest\"", "值为2450，要么完全透明要么完全不透明，多用于利用贴图来实现边缘透明的效果，也就是美术常说的透贴。");
                _reference.DrawContent("\"Queue\" = \"Transparent\"", "值为3000，常用于半透明对象，渲染时从后往前进行渲染，建议需要混合的对象放入此队列。");
                _reference.DrawContent("\"Queue\" = \"Overlay\"", "值为4000,此渲染队列用于叠加效果。最后渲染的东西应该放在这里（例如镜头光晕等）。");
            }
        }

        public void DrawTitleRenderType()
        {
            _reference.DrawTitle("RenderType","https://docs.unity3d.com/cn/current/Manual/SL-SubShaderTags.html");
        }
        public void DrawContentRenderType(bool isFold)
        {
            if (isFold)
            {
                _reference.DrawContent("RenderType", "用来区别这个Shader要渲染的对象是属于什么类别的，你可以想像成是我们把各种不同的物体按我们需要的类型来进行分类一样。\n当然你也可以根据需要改成自定义的名称，这样并不会影响到Shader的效果。\n此Tag多用于摄像机的替换材质功能(Camera.SetReplacementShader)。");
                _reference.DrawContent("\"RenderType\" = \"Opaque\"", "大多数不透明着色器。");
                _reference.DrawContent("\"RenderType\" = \"Transparent\"", "大多数半透明着色器，比如粒子、特效、字体等。");
                _reference.DrawContent("\"RenderType\" = \"TransparentCutout\"", "透贴着色器，多用于植被等。");
                _reference.DrawContent("\"RenderType\" = \"Background\"", "多用于天空盒着色器。");
                _reference.DrawContent("\"RenderType\" = \"Overlay\"", "GUI、光晕着色器等。");
                _reference.DrawContent("\"RenderType\" = \"TreeOpaque\"", "Terrain地形中的树干。");
                _reference.DrawContent("\"RenderType\" = \"TreeTransparentCutout\"", "Terrain地形中的树叶。");
                _reference.DrawContent("\"RenderType\" = \"TreeBillboard\"", "Terrain地形中的永对面树。");
                _reference.DrawContent("\"RenderType\" = \"Grass\"", "Terrain地形中的草。");
                _reference.DrawContent("\"RenderType\" = \"GrassBillboard\"", "Terrain地形中的永对面草。");
            }
        }

        public void DrawTitleLightMode()
        {
            _reference.DrawTitle("LightMode","https://docs.unity3d.com/Packages/com.unity.render-pipelines.universal@17.0/manual/urp-shaders/urp-shaderlab-pass-tags.html?q=lightmode");
        }
        public void DrawContentLightMode(bool isFold)
        {
            if (isFold)
            {
                _reference.DrawContent("\"LightMode\" = \"UniversalForward\"", "用于前向渲染路径，所有的灯光都在这一个pass中执行，包括GI、自发光、雾效.(在不需要光照的pass中，可以不写LightMode)");
                _reference.DrawContent("\"LightMode\" = \"SRPDefaultUnlit\"", "用于在额外需要一个pass时使用.");
                _reference.DrawContent("\"LightMode\" = \"ShadowCaster\"", "用于生成阴影贴图ShadowMap(灯光视角下的深度信息)");
                _reference.DrawContent("\"LightMode\" = \"UniversalGBuffer\"", "用于延迟渲染");
                _reference.DrawContent("\"LightMode\" = \"DepthOnly\"", "用于生成相机下的深度信息,当管线资源上开启MSAA时会调用此pass.");
                _reference.DrawContent("\"LightMode\" = \"DepthNormalsOnly\"", "用于生成相机下的深度法线信息.");
                _reference.DrawContent("\"LightMode\" = \"Meta\"", "仅在光照烘焙时才会使用此Pass,用于间接光的反弹.");
                _reference.DrawContent("\"LightMode\" = \"Universal2D\"", "用于URP使用2D渲染器时绘制物体的Pass，不受光照影响.");
            }
        }

        public void DrawTitleDisableBatching()
        {
            _reference.DrawTitle("DisableBatching","https://docs.unity3d.com/cn/current/Manual/SL-SubShaderTags.html");
        }
        public void DrawContentDisableBatching(bool isFold)
        {
            if (isFold)
            {
                _reference.DrawContent("DisableBatching", "在利用Shader在模型的顶点本地坐标下做一些位移动画，而当此模型有批处理时会出现效果不正确的情况，这是因为批处理会将所有模型转换为世界坐标空间，因此“本地坐标空间”将丢失。");
                _reference.DrawContent("\"DisableBatching\" = \"True\"", "禁用批处理。");
                _reference.DrawContent("\"DisableBatching\" = \"False\"", "不禁用批处理。");
                _reference.DrawContent("\"DisableBatching\" = \"LODFading\"", "仅当LOD激活时禁用批处理。");
            }
        }

        public void DrawTitleIgnoreProjector()
        {
            _reference.DrawTitle("IgnoreProjector","https://docs.unity3d.com/cn/current/Manual/SL-SubShaderTags.html");
        }
        public void DrawContentIgnoreProjector(bool isFold)
        {
            if (isFold)
            {
                _reference.DrawContent("IgnoreProjector", "是否忽略Projector投影器的影响。");
                _reference.DrawContent("\"IgnoreProjector\" = \"True\"", "不受投影器影响。");
                _reference.DrawContent("\"IgnoreProjector\" = \"False\"", "受投影器影响。");
            }
        }

        public void DrawTitlePreviewType()
        {
            _reference.DrawTitle("PreviewType","https://docs.unity3d.com/cn/current/Manual/SL-SubShaderTags.html");
        }
        public void DrawContentPreviewType(bool isFold)
        {
            if (isFold)
            {
                _reference.DrawContent("PreviewType", "定义材质面板中的预览的模型显示,默认不写或者不为Plane与Skybox时则为圆球。");
                _reference.DrawContent("\"PreviewType\" = \"Plane\"", "平面。");
                _reference.DrawContent("\"PreviewType\" = \"Skybox\"", "天空盒。"); 
            }
        }

        public void DrawTitleForceNoShadowCasting()
        {
            _reference.DrawTitle("ForceNoShadowCasting","https://docs.unity3d.com/cn/current/Manual/SL-SubShaderTags.html");
        }
        public void DrawContentForceNoShadowCasting(bool isFold)
        {
            if (isFold)
            {
                _reference.DrawContent("ForceNoShadowCasting", "是否强制关闭投射阴影。");
                _reference.DrawContent("\"ForceNoShadowCasting\" = \"True\"", "强制关闭阴影投射。");
                _reference.DrawContent("\"ForceNoShadowCasting\" = \"False\"", "不关闭阴影投射。");
            }
        }

        public void DrawTitleCanUseSpriteAtlas()
        {
            _reference.DrawTitle("CanUseSpriteAtlas","https://docs.unity3d.com/cn/current/Manual/SL-SubShaderTags.html");
        }
        public void DrawContentCanUseSpriteAtlas(bool isFold)
        {
            if (isFold)
            {
                _reference.DrawContent("CanUseSpriteAtlas", "是否可用于打包图集的精灵。");
                _reference.DrawContent("\"CanUseSpriteAtlas\" = \"True\"", "支持精灵打包图集。");
                _reference.DrawContent("\"CanUseSpriteAtlas\" = \"False\"", "不支持精灵打包图集。");
            }
        }

        public void DrawTitlePerformanceChecks()
        {
            _reference.DrawTitle("PerformanceChecks");
        }
        public void DrawContentPerformanceChecks(bool isFold)
        {
            if (isFold)
            {
                _reference.DrawContent("PerformanceChecks", "是否对shader在当前平台进行性能检测，并在材质面板进行警告提示");
                _reference.DrawContent("\"PerformanceChecks\" = \"True\"", "开启性能检测提示");
                _reference.DrawContent("\"PerformanceChecks\" = \"False\"", "关闭性能检测提示"); 
            }
        }
    }
}

