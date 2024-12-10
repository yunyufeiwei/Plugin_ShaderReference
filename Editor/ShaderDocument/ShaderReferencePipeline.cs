using UnityEditor;

namespace yuxuetian
{
    public class ShaderReferencePipeline : EditorWindow
    {
        private ShaderReferenceUtil _reference = new ShaderReferenceUtil();

        public void DrawTitleApplicationStage()
        {
            _reference.DrawTitle("应用程序阶段（Application Stage）");
        }
        public void DrawContentApplicationStage(bool isFold)
        {
            if (isFold)
            {
                _reference.DrawContent("1.Application Stage", "此阶段一般由CPU将需要在屏幕上绘制的几何体、摄像机位置、光照纹理等输出到管线的几何阶段。该阶段主要有3个任务：\n" +
                                       "●准备场景数据：摄像机的位置、视椎体、场景模型数据、光源数据等等。\n" +
                                       "●粗粒度剔除：为了提高渲染性能，需要执行该项，把那些不可见的物体剔除出去。\n" +
                                       "●设置渲染状态：包括但不限于使用的材质（漫反射颜色、高光反射颜色）、使用的纹理、shader等等。");
            }
        }

        public void DrawTitleGeometryStage()
        {
            _reference.DrawTitle("几何阶段（Geometry Stage）");
        }
        public void DrawContentGeometryStage(bool isFold)
        {
            if (isFold)
            {
                _reference.DrawContent("1.模型和视图变换（Model and View Transform）", "模型和视图变换阶段分为模型变换和视图变换。\n●模型变换的目的是将模型从本地空间变换到世界空间当中\n●视图变换的目的是将摄像机放置于坐标原点（以使裁剪和投影操作更简单高效）,将模型从世界空间变换到相机空间,以便后续步骤的操作。");
                _reference.DrawContent("2.顶点着色（Vertex Shading）", "顶点着色阶段的目的在于确定模型上顶点处的光照效果,其输出结果（颜色、向量、纹理坐标等）会被发送到光栅化阶段以进行插值操作。");
                _reference.DrawContent("3.几何、曲面细分着色器", "【可选项】分为几何着色器(Geometry Shader)和曲面细分着色器(Tessellation Shader)，主要是对顶点进行增加与删除修改等操作.");
                _reference.DrawContent("4.投影（Projection）", "投影阶段分为正交投影与透视投影。\n投影变换其实就是矩阵变换，最终会使坐标位于归一化的设备坐标NDC中，之所以叫投影就是因为最终Z轴坐标将被舍弃，也就是说此阶段主要的目的是将模型从三维空间投射到了二维的空间中的过程（但是坐标仍然是三维的，只是显示上看是二维的）。\n" + 
                                       "\n"+
                                       "重点说明：观察空间（摄像机空间）和屏幕空间是不同的，观察空间（裁剪空间或齐次裁剪空间）设计一个三维空间，而屏幕空间是一个二维空间，而从观察空间到屏幕空间的转换需要经过一个操作，那就是投影（Projection Matrix）。");
                _reference.DrawContent("5.裁剪（Clipping）", "裁剪根据图元在视体的位置分为三种情况：\n1.当图元完全位于视体内部，那么它可以直接进行下一个阶段。\n2.当图元完全位于视体外部，则不会进入下一个阶段，直接丢弃。\n3.当图元部分位于视体内部，则需要对位于视体内的图元进行裁剪处理。\n最终的目的就是对部分位于视体内部的图元进行裁剪操作，以使处于视体外部不需要渲染的图元进行裁剪丢弃。\n" + 
                                       "\n"+ 
                                       "重点说明：在裁剪空间完成之后，其实还有一步NDC空间坐标，其实是在裁剪空间的基础上进行透视除法或称为齐次除法，得到的坐标空间。\n" +
                                       "透视除法：将齐次坐标空间的positionHCS的xyz分量都除以w分量。经透视除法之后的点（x,y,z,1），其xyz的取值范围则在【-1,1】区间内。");
                _reference.DrawContent("6.屏幕映射（Screen Mapping）", "屏幕映射阶段的主要目的，是将之前步骤得到的坐标映射到对应的屏幕坐标系上。");
            }
        }

        public void DrawTitleResterizerStage()
        {
            _reference.DrawTitle("光栅化阶段（Rasterizer Stage）");
        }
        public void DrawContentResterizerStage(bool isFold)
        {
            if (isFold)
            {
                _reference.DrawContent("1.三角形设定（Triangle Setup）", "此阶段主要是将从几何阶段得到的一个个顶点通过计算来得到一个个三角形网格。");
                _reference.DrawContent("2.三角形遍历（Triangle Traversal）", "此阶段将进行逐像素遍历检查操作，以检查出该像素是否被上一步得到的三角形所覆盖，这个查找过程被称为三角形遍历。\n" +
                                       "该阶段输出就是得到一个片元序列。一个片元并不是真正意义上的像素，而是包含了很多状态的集合，这些状态用于计算每个像素的最终颜色，包括但不限于屏幕坐标、深度信息，以及其它从几何阶段输出的顶点信息，例如法线、纹理坐标等。");
                _reference.DrawContent("3.像素着色(Pixel Shading)", "对应于ShaderLab中的frag函数,主要目的是定义像素的最终输出颜色.");
                _reference.DrawContent("4.混合（Merging）", "主要任务是合成当前储存于缓冲器中的由之前的像素着色阶段产生的片段颜色。\n" +
                                       "此阶段还负责可见性问题（Alpha测试、模版测试、深度测试、混合等）处理.");
            }
        }

        public void DrawTitleShaderLab()
        {
            _reference.DrawTitle("Shader Lab");
        }

        public void DrawContentShaderLab(bool isFold)
        {
            if (isFold)
            {
                _reference.DrawContent("Shader Lab","是Unity3D游戏引擎中用于编写Shader的语言，它不是一个独立的编程语言，而是一种结构化的语法，用于组织和配置Shader代码的各个部分.");
                _reference.DrawContent("Property\n"+"{\n"+"}","该部分用来创建用于显示在面版上的属性.");
                _reference.DrawContent("SubShader\n"+"{\n"+"}","每个Shader至少包含一个SubShader，它定义了一系列的通道（Pass），这些通道告诉Unity如何渲染物体，如果一个设备不支持第一个SubShader，Unity会尝试下一个SubShader，直到找到一个合适的.");
                _reference.DrawContent("Pass\n" + "{\n" + "}" , "pass定义了实际的渲染步骤。每个Pass可以包含一段HLSL代码，这部分是实际的Shader程序，包括顶点和片元Shader.");
                _reference.DrawContent("1.Attribute" , "将应用程序阶段的内容传递到顶点着色器中.");
                _reference.DrawContent("2.Varyings(顶点着色器)","本地空间->(本地到世界空间矩阵)->世界空间->(世界到观察空间矩阵)->观察空间->(投影矩阵)->齐次裁剪空间.");
                _reference.DrawContent("3.透视除法","齐次裁剪空间做透视除法(clip.xyzw/clip.w),变换到归一化设备坐标NDC.");
                _reference.DrawContent("4.视口变换","从NDC坐标变换到屏幕坐标.");
                _reference.DrawContent("5.frag(片段着色器)","用从顶点着色器的输出当做输入进行逐片段的颜色计算并输出.");
                
            }
        }
    }
}

