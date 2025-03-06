using UnityEditor;

namespace yuxuetian
{
    public class ShaderReferenceProperty : EditorWindow
    {
        private ShaderReferenceUtil _reference = new ShaderReferenceUtil();
        
        public void DrawTitleProperty()
        {
            _reference.DrawTitle("属性（Properties）");
        }
        public void DrawContentProperty(bool ifFold)
        {
            if (ifFold)
            {
                _reference.DrawContent("_Int(\"Int\",Integer) = 1","类型：整型\n说明：在URP下，如果要使用整数的表达方式，不能使用Int，必须要使用Integer");
                _reference.DrawContent("_Float(\"Float\",Float) = 0.1","类型：浮点型\n说明：根据需要定义不同的浮点精度，任何需要显式精度的函数，使用float或half限定符，当函数可以同时支持两者时，则使用real.\n" +
                                         "half   16位精度，常用于本地坐标位置,方向等\n"+
                                         "float  32位精度，常用于世界坐标位置以及uv坐标");
                _reference.DrawContent("_Slider(\"Slider\",Range(0,1)) = 0","类型：数值型滑动条\n说明：本质还是浮点型，只是通过Range(min,max)来控制滑动条的最小值与最大值");
                _reference.DrawContent("_Color(\"Color\",Color) = (1,1,1,1)","类型：颜色\n说明：用来表示颜色，通常是四维.");
                _reference.DrawContent("_Vector(\"Vector\",Vector) = (1,1,1,1)","类型：向量\n说明：四维向量，在Property中无法定义二维或者三维向量，只能定义四维向量.");
            
                _reference.DrawContent("_BaseMap (\"BaseMap\", 2D) = \"white\" {}","类型：2D纹理\n说明：默认值有white、black、gray、bump以及空，空就是white\n" +"\n"+
                                       "TEXTURE2D(_BaseMap);        SAMPLER(sampler_BaseMap);\n" +
                                       "half4 baseMap = SAMPLE_TEXTURE2D(_BaseMap,sampler_BaseMap , i.uv);");
                _reference.DrawContent("_BaseMapArray(\"BaseMapArray\",2DArray) = \"white\"{}","类型：2D数组纹理\n"+
                                         "说明：默认值有white、black、gray、bump以及空，空就是white，仅支持DX10、OpenGL3.0、Metal及以上版本\n" + "\n"+
                                         "TEXTURE2D_ARRAY(_BaseMapArray);     SAMPLER(sampler_BaseMapArray);\n"+
                                         "half4 baseMapArray = SAMPLE_TEXTURE2D_ARRAY(_BaseMapArray , sampler_BaseMapArray , i.uv , 0);");
                _reference.DrawContent("_3DTexture(\"3DTexture\",3D) = \"white\"{}","类型：3D纹理，通常用作着色器的查找表，或用于表示体积数据。\n说明："+"\n" + 
                                       "TEXTURE3D(_3DTexture);    SAMPLER(sampler_3DTexture);");
                _reference.DrawContent("_Cube(\"Cube\",Cube) = \"_skybox\"{}","类型：立方体贴图\n说明：类似天空球一样的纹理，默认使用\"_skybox{}\"\n" + "\n" + 
                                         "TEXTURECUBE(_Cube);       SAMPLER(sampler_Cube);\n"+
                                         "half4 cubeMap = SAMPLE_TEXTURECUBE(_Cube,sampler_Cube,reflexDir);");
            }
        }

        public void DrawTitleAttribute()
        {
            _reference.DrawTitle("属性形式（Attribute）");
        }
        public void DrawContentAttribute(bool isFold)
        {
            if (isFold)
            {
                _reference.DrawContent("[Header(xxx)]","用于在材质面板中当前属性的上方显示标题xxx，只支持英文、数字、空格以及下划线.");
                _reference.DrawContent("[HideInInspector]","用于在材质面板隐藏此条属性，在不希望暴露某条属性时，可以快速将其隐藏.");
                _reference.DrawContent("[Space(n)]", "用于材质面板之间的属性，是属性之间具有间隔，n为间隔的数值大小.");
                _reference.DrawContent("[HDR]","标记颜色属性为高动态范围.");
                _reference.DrawContent("[PowerSlider(3)]","滑条曲率,必须加在range属性前面，用于控制滑动的数值比例,数值前面的部分会在滑动条上占更多的比例.");
                _reference.DrawContent("[IntRange]","必须使用在Range属性之上，使材质面板中滑动条的数值只能生成整数.");
                _reference.DrawContent("[Toggle]" , "开关属性，加在数值类型前面，可以使材质面板中的数值变成开关，0是关，1是开.");
                _reference.DrawContent("[ToggleOff]","与Toggle相当，0是开，1是关.");
                _reference.DrawContent("[Enum(Off, 0, On, 1)]", "数值枚举,可直接在cg中使用此关键字来替代数字,最多可定义7个，超出后无法以下拉列表框的形式展现.");
                _reference.DrawContent("[KeywordEnum (Enum0, Enum1, Enum2, Enum3, Enum4, Enum5, Enum6, Enum7, Enum8)]", "关键字枚举,需要#pragma multi_compile _XXX_ENUM0 _XXX_ENUM1 ...来依次声明变体关键字,XXX为这条属性中声明的变量名,在cg/hlsl中可以通过#if #elif #endif分别做判断.");
                _reference.DrawContent("[Enum (UnityEngine.Rendering.CullMode)]", "内置枚举,可在Enum()内直接调用Unity内部的枚举.");
                _reference.DrawContent("[NoScaleOffset]", "只能加在纹理属性前，使其隐藏材质面板中的Tiling和Offset");
                _reference.DrawContent("[Normal]", "只能加在纹理属性前，标记此纹理是用来接收法线贴图的，当用户指定了非法线的纹理时会在材质面板上进行警告提示");
                _reference.DrawContent("[Gamma]", "Float和Vector属性默认情况下不会进行颜色空间转换，可以通过添加[Gamma]来指明此属性为sRGB值");
                _reference.DrawContent("[PerRendererData]", "标记当前属性将以材质属性块的形式来自于每个渲染器数据");
                _reference.DrawContent("[MainTexture]", "标记当前纹理为主纹理，便于C#通过Material.mainTexture调用");
                _reference.DrawContent("[MainColor]", "标记当前颜色为主颜色，便于C#通过Material.color调用");
            }
        }
    }
}

