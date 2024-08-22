using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using yuxuetian.tools.shaderReference;

namespace yuxuetian.tools.shaderReference
{
    public class ShaderReferenceProperty : EditorWindow
    {
        private ShaderReferenceUtil reference = new ShaderReferenceUtil();
        
        public void DrawTitleProperty()
        {
            reference.DrawTitle("属性（Properties）");
        }
        public void DrawContentProperty(bool ifFold)
        {
            if (ifFold)
            {
                reference.DrawContent("_Int(\"Int\",Integer) = 1","类型：整型\n说明：在URP下，如果要使用整数的表达方式，不能使用Int，必须要使用Integer");
                reference.DrawContent("_Float(\"Float\",Float) = 0.1","类型：浮点型\n说明：根据需要定义不同的浮点精度，任何需要显式精度的函数，使用float或half限定符，当函数可以同时支持两者时，则使用real.\n" +
                                         "half   16位精度，常用于本地坐标位置,方向等\n"+
                                         "float  32位精度，常用于世界坐标位置以及uv坐标");
                reference.DrawContent("_Slider(\"Slider\",Range(0,1)) = 0","类型：数值型滑动条\n说明：本质还是浮点型，只是通过Range(min,max)来控制滑动条的最小值与最大值");
                reference.DrawContent("_Color(\"Color\",Color) = (1,1,1,1)","类型：颜色\n说明：用来表示颜色，通常是四维.");
                reference.DrawContent("_Vector(\"Vector\",Vector) = (1,1,1,1)","类型：向量\n说明：四维向量，在Property中无法定义二维或者三维向量，只能定义四维向量.");
            
                reference.DrawContent("_BaseMap (\"BaseMap\", 2D) = \"white\" {}","类型：2D纹理\n说明：默认值有white、black、gray、bump以及空，空就是white");
                reference.DrawContent("_BaseMapArray(\"BaseMapArray\",2DArray) = \"white\"{}","类型：2D数组纹理\n"+
                                         "说明：默认值有white、black、gray、bump以及空，空就是white，仅支持DX10、OpenGL3.0、Metal及以上版本\n" + "\n"+
                                         "TEXTURE2D_ARRAY(_BaseMapArray);     SAMPLER(sampler_BaseMapArray);\n"+
                                         "half4 baseMapArray = SAMPLE_TEXTURE2D_ARRAY(_BaseMapArray , sampler_BaseMapArray , i.uv , 0);");
                reference.DrawContent("_Cube(\"Cube\",Cube) = \"_skybox\"{}","类型：立方体贴图\n说明：类似天空球一样的纹理，默认使用\"_skybox{}\"\n" + "\n" + 
                                         "TEXTURECUBE(_Cube);    SAMPLER(sampler_Cube);\n"+
                                         "half4 cubeMap = SAMPLE_TEXTURECUBE(_Cube,sampler_Cube,reflexDir);");
                reference.DrawContent("_3DTexture(\"3DTexture\",3D) = \"white\"{}","类型：3D纹理，通常用作着色器的查找表，或用于表示体积数据。\n说明："+"\n" + 
                                         "TEXTURE3D(_3DTexture);    SAMPLER(sampler_3DTexture);");
            }
            
        }

        public void DrawTitleAttribute()
        {
            reference.DrawTitle("属性性质（Attribute）");
        }
        public void DrawContentAttribute(bool isFold)
        {
            if (isFold)
            {
                
            }
        }
    }
}

