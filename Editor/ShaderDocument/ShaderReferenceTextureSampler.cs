using UnityEditor;
using UnityEngine;

namespace yuxuetian
{
    public class ShaderReferenceTextureSampler : EditorWindow
    {
        private ShaderReferenceUtil _reference = new ShaderReferenceUtil();

        public void DrawTitleTextureSampler()
        {
            _reference.DrawTitle("TextureSampler(纹理采样)");
        }
        public void DrawContentTextureSampler(bool isFoldout)
        {
            if (isFoldout)
            {
                _reference.DrawContent("TEXTURE2D (textureName);",
                    "二维纹理的定义(纹理与采样器分离定义),此功能在OpenGL ES2.0上不支持，会使用原来sampler2D的形式.\n" +
                    "textureName:Properties中声明的2D纹理名称.");
                _reference.DrawContent("TEXTURECUBE (textureName);",
                    "立方体纹理的定义(纹理与采样器分离定义),此功能在OpenGL ES2.0上不支持，会使用原来samplerCube的形式.\n" +
                    "textureName:Properties中声明的立方体纹理名称.");
                _reference.DrawContent("SAMPLER(samplerName);",
                    "采样器的定义(纹理与采样器分离定义),采样器是指纹理的过滤模式与重复模式,此功能在OpenGL ES2.0上不支持，相当于没写.\n" +
                    "1.SAMPLER(sampler_textureName):sampler+纹理名称，这种定义形式是表示采用textureName这个纹理Inspector面板中的采样方式.\n" +
                    "2.SAMPLER(_filter_wrap):比如SAMPLER(sampler_linear_repeat),使用自定义的采样器设置，自定义的采样器一定要同时包含过滤模式<filter>与重复模式<wrap>的设置，注意这种自定义写法很多移动平台不支持！.\n" +
                    "3.SAMPLER(_filter_wrapU_wrapV):比如SAMPLER(sampler_linear_clampU_mirrorV),可同时设置重复模式的U与V的不同值.\n" +
                    "4.filter:point/linear/triLinear\n" +
                    "5.wrap:clamp/repeat/mirror/mirrorOnce");
                
                GUILayout.Space(20);
                _reference.DrawContent("float4 [textureName]_ST;", "获取纹理的Tiling(.xy)和Offset(.zw)");
                _reference.DrawContent("float4 [textureName]_TexelSize;", "获取纹理的宽高分之一(.xy)和宽高(.zw)");
                
                GUILayout.Space(20);
                _reference.DrawContent("SAMPLE_TEXTURE2D(textureName, samplerName, coord);", "进行二维纹理采样操作\n" +
                    "textureName:Properties中声明的2D纹理名称\n" +
                    "samplerName:此纹理所使用的采样器设置\n" +
                    "coord:采样用的UV");
                _reference.DrawContent("SAMPLE_TEXTURE2D_LOD(textureName, samplerName, coord,lod);", "进行二维纹理采样操作\n" +
                    "textureName:Properties中声明的2D纹理名称\n" +
                    "samplerName:此纹理所使用的采样器设置\n" +
                    "coord:采样用的UV\n" +
                    "lod:mipmap级别");
                _reference.DrawContent("SAMPLE_TEXTURE2D_BIAS(textureName, samplerName, coord,bias);",
                    "对mipmap进行偏移后再采样纹理\n" +
                    "textureName:Properties中声明的2D纹理名称\n" +
                    "samplerName:此纹理所使用的采样器设置\n" +
                    "coord:采样用的UV\n" +
                    "bias:mipmap偏移量,比如0=默认,-1=比当前级别更清晰一级,1=比当前级别更模糊一级.");
                _reference.DrawContent("SAMPLE_TEXTURECUBE(textureName, samplerName, coord);", "进行立方体纹理采样操作\n" +
                    "textureName:Properties中声明的CUBE纹理名称\n" +
                    "samplerName:此纹理所使用的采样器设置\n" +
                    "coord:采样用的UV");
                _reference.DrawContent("SAMPLE_TEXTURECUBE_LOD(textureName, samplerName, coord,lod);", "进行立方体纹理采样操作\n" +
                    "textureName:Properties中声明的CUBE纹理名称\n" +
                    "samplerName:此纹理所使用的采样器设置\n" +
                    "coord:采样用的UV\n" +
                    "lod:mipmap级别");
                _reference.DrawContent("SAMPLE_TEXTURE3D(textureName, samplerName, coord);", "进行3D纹理采样操作\n" +
                    "textureName:Properties中声明的3D纹理名称\n" +
                    "samplerName:此纹理所使用的采样器设置\n" +
                    "coord:采样用的三给UV");
            }
        }
        
        public void DrawTitleTextureArraySampler()
        {
            _reference.DrawTitle("TextureArray(纹理数组采样)");
        }
        public void DrawContentTextureArraySampler(bool isFold)
        {
            if (isFold)
            {
                _reference.DrawContent("TEXTURE2D_ARRAY(textureName);", "纹理数组的定义,此功能在OpenGL ES2.0上不支持，会fallback到samplerCUBE的形式.");
                _reference.DrawContent("SAMPLER(sampler_samplerName);", "纹理数组的采样器定义.");
                _reference.DrawContent("SAMPLE_TEXTURE2D_ARRAY(textureName, samplerName, coord2, index);", "纹理数组采样.\n" +
                    "textureName:Properties中声明的2D纹理名称\n" +
                    "samplerName:此纹理所使用的采样器设置\n" +
                    "coord:采样用的UV\n" +
                    "index:数组索引");
            }
        }
    }
}
    
