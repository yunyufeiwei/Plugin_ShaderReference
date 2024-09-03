using UnityEngine;
using UnityEditor;

namespace yuxuetian
{
    public class ShaderReferenceStudyWebsite : EditorWindow
    {
        private ShaderReferenceUtil _reference = new ShaderReferenceUtil();

        public void DrawTitleStudyWebsiteForUnity()
        {
            _reference.DrawTitle("学习网站");
        }

        public void DrawContentStudyWebsiteForUnity()
        {
            _reference.DrawContentSite("日本Unity网站","https://learning.unity3d.jp/tag/shader/");
        }

        public void DrawTitleStudyWebsiteProgram()
        {
            _reference.DrawTitle("编程网站");
        }

        public void DrawContentStudyWebsityProgram()
        {
            
            _reference.DrawContentSite("HLSL着色器语言","https://learn.microsoft.com/zh-cn/windows/win32/direct3dhlsl/dx-graphics-hlsl");
        }

        public void DrawTitleStudyWebsityGraphics()
        {
            _reference.DrawTitle("计算机图形");
        }

        public void DrawContentStudyWebsityGraphics()
        {
            _reference.DrawContentSite("图形学相关书籍","https://www.realtimerendering.com/#intro");
            _reference.DrawContentSite("GDC文章","https://gdcvault.com/play/1034419/");
            _reference.DrawContentSite("OpenGL网址" , "https://learnopengl-cn.github.io/");
            _reference.DrawContentSite("ShaderToy","https://www.shadertoy.com/");
            _reference.DrawContentSite("片元图形算法","https://glslsandbox.com/");
            _reference.DrawContentSite("图形公式算法" , "https://iquilezles.org/articles/");
            _reference.DrawContentSite("图形与编程","https://xbdev.net/maths_of_3d/index.php");
            _reference.DrawContentSite("Catlike Coding", "https://catlikecoding.com/");
            _reference.DrawContentSite("Physically Based Rendering", "https://www.pbr-book.org/3ed-2018/contents");
            _reference.DrawContentSite("有向距离场","https://jamie-wong.com/2016/07/15/ray-marching-signed-distance-functions/#signed-distance-functions");
            _reference.DrawContentSite("延迟渲染与前向渲染","https://www.3dgep.com/forward-plus/");
            _reference.DrawContentSite("光照与阴影","https://ciechanow.ski/lights-and-shadows/");
        }

        public void DrawTitleStudyWebsityCalculatorTools()
        {
            _reference.DrawTitle("Graphing Calculator(图形工具)");
        }

        public void DrawContentStudyWebsityCalculatorTools()
        {
            _reference.DrawContentSite("公式文本编辑器","https://www.latexlive.com/home##");
            _reference.DrawContentSite("GeoGebra计算器","https://www.geogebra.org/");
            _reference.DrawContentSite("图形波形计算器","https://graphtoy.com/");
            _reference.DrawContentSite("数学计算器","https://www.desmos.com/calculator?lang=zh-CN");
            _reference.DrawContentSite("Symbolab计算器", "https://www.symbolab.com/graphing-calculator/linear-graph");
            _reference.DrawContentSite("BRDF3D可视化","https://patapom.com/topics/WebGL/BRDF/");
        }
    }
}

