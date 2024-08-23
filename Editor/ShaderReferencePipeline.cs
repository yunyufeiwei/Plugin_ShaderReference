using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace yuxuetian.tools.shaderReference
{
    public class ShaderReferencePipeline : EditorWindow
    {
        private ShaderReferenceUtil referencr = new ShaderReferenceUtil();

        public void DrawTitleApplicationStage()
        {
            referencr.DrawTitle("应用程序阶段（Application Stage）");
        }
        public void DrawContentApplicationStage(bool isFold)
        {
            if (isFold)
            {
                referencr.DrawContent("1.Application Stage", "  此阶段一般由CPU将需要在屏幕上绘制的几何体、摄像机位置、光照纹理等输出到管线的几何阶段.");
            }
        }

        public void DrawTitleGeometryStage()
        {
            referencr.DrawTitle("几何阶段（Geometry Stage）");
        }
        public void DrawContentGeometryStage(bool isFold)
        {
            if (isFold)
            {
                referencr.DrawContent("1.模型和视图变换（Model and View Transform）", "模型和视图变换阶段分为模型变换和视图变换.\n模型变换的目的是将模型从本地空间变换到世界空间当中\n视图变换的目的是将摄像机放置于坐标原点（以使裁剪和投影操作更简单高效），将模型从世界空间变换到相机空间，以便后续步骤的操作。");
                referencr.DrawContent("2.顶点着色（Vertex Shading）", "顶点着色阶段的目的在于确定模型上顶点处的光照效果,其输出结果（颜色、向量、纹理坐标等）会被发送到光栅化阶段以进行插值操作。");
                referencr.DrawContent("3.几何、曲面细分着色器", "【可选项】分为几何着色器(Geometry Shader)和曲面细分着色器(Tessellation Shader)，主要是对顶点进行增加与删除修改等操作.");
                referencr.DrawContent("4.投影（Projection）", "投影阶段分为正交投影与透视投影.\n投影其实就是矩阵变换，最终会使坐标位于归一化的设备坐标NDC中，之所以叫投影就是因为最终Z轴坐标将被舍弃，也就是说此阶段主要的目的是将模型从三维空间投射到了二维的空间中的过程（但是坐标仍然是三维的，只是显示上看是二维的）。");
                referencr.DrawContent("5.裁剪（Clipping）", "裁剪根据图元在视体的位置分为三种情况：\n1.当图元完全位于视体内部，那么它可以直接进行下一个阶段。\n2.当图元完全位于视体外部，则不会进入下一个阶段，直接丢弃。\n3.当图元部分位于视体内部，则需要对位于视体内的图元进行裁剪处理。\n最终的目的就是对部分位于视体内部的图元进行裁剪操作，以使处于视体外部不需要渲染的图元进行裁剪丢弃。");
                referencr.DrawContent("6.屏幕映射（Screen Mapping）", "屏幕映射阶段的主要目的，是将之前步骤得到的坐标映射到对应的屏幕坐标系上。");
            }
        }

        public void DrawTitleResterizerStage()
        {
            referencr.DrawTitle("光栅化阶段（Rasterizer Stage）");
        }
        public void DrawContentResterizerStage(bool isFold)
        {
            if (isFold)
            {
                referencr.DrawContent("1.三角形设定（Triangle Setup）", "此阶段主要是将从几何阶段得到的一个个顶点通过计算来得到一个个三角形网格。");
                referencr.DrawContent("2.三角形遍历（Triangle Traversal）", "此阶段将进行逐像素遍历检查操作，以检查出该像素是否被上一步得到的三角形所覆盖，这个查找过程被称为三角形遍历.");
                referencr.DrawContent("3.像素着色(Pixel Shading)", "对应于ShaderLab中的frag函数,主要目的是定义像素的最终输出颜色.");
                referencr.DrawContent("4.混合（Merging）", "主要任务是合成当前储存于缓冲器中的由之前的像素着色阶段产生的片段颜色。此阶段还负责可见性问题（深度测试、模版测试等）的处理.");

            }
        }

        public void DrawTitleShaderLab()
        {
            referencr.DrawTitle("Shader Lab");
        }

        public void DrawContentShaderLab(bool isFold)
        {
            if (isFold)
            {
                referencr.DrawContent("Shader Lab","是Unity3D游戏引擎中用于编写Shader的语言，它不是一个独立的编程语言，而是一种结构化的语法，用于组织和配置Shader代码的各个部分.");
                referencr.DrawContent("Property\n"+"{\n"+"}","该部分用来创建用于显示在面版上的属性.");
                referencr.DrawContent("SubShader\n"+"{\n"+"}","每个Shader至少包含一个SubShader，它定义了一系列的通道（Pass），这些通道告诉Unity如何渲染物体，如果一个设备不支持第一个SubShader，Unity会尝试下一个SubShader，直到找到一个合适的.");
                referencr.DrawContent("Pass\n" + "{\n" + "}" , "pass定义了实际的渲染步骤。每个Pass可以包含一段HLSL代码，这部分是实际的Shader程序，包括顶点和片元Shader.");
                referencr.DrawContent("1.Attribute" , "将应用程序阶段的内容传递到顶点着色器中.");
                referencr.DrawContent("2.Varyings(顶点着色器)","本地空间->(本地到世界空间矩阵)->世界空间->(世界到观察空间矩阵)->观察空间->(投影矩阵)->齐次裁剪空间.");
                referencr.DrawContent("3.透视除法","齐次裁剪空间做透视除法(clip.xyzw/clip.w),变换到归一化设备坐标NDC.");
                referencr.DrawContent("4.视口变换","从NDC坐标变换到屏幕坐标.");
                referencr.DrawContent("5.frag(片段着色器)","用从顶点着色器的输出当做输入进行逐片段的颜色计算并输出.");
                
            }
        }
    }
}

