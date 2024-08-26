using UnityEngine;
using UnityEditor;

namespace yuxuetian.tools.shaderReference
{
    public class ShaderReferenceMath : EditorWindow
    {
        private ShaderReferenceUtil reference = new ShaderReferenceUtil();

        public void DrawTitleMathFunction()
        {
            reference.DrawTitle("Math(数学函数)" , "https://learn.microsoft.com/zh-cn/windows/win32/direct3dhlsl/dx-graphics-hlsl-intrinsic-functions");
        }

        public void DrawContentMathFunction(bool isFold)
        {
            if (isFold)
            {
                reference.DrawContent("abs (x)", "取绝对值，即正值返回正值，负值返回的还是正值,x值也可以为向量\n" +
                                        "float abs(float a)\n" +
                                        "{\n" +
                                        "    return max(-a, a);\n" +
                                        "}");
                reference.DrawContent("acos (x)", "反余弦函数,输入参数范围为[-1, 1],返回[0, π] 区间的弧度值");
                reference.DrawContent("all (a)", "当a或a的所有分量都为true或者非0时返回1(true),否则返回0(false).\n" +
                                         "bool all(bool4 a)\n" +
                                         "{\n" +
                                         "    return a.x && a.y && a.z && a.w;\n" +
                                         "}");
                reference.DrawContent("any (a)", "如果a=0或者a中的所有分量为0，则返回0(false);否则返回1(true).\n" +
                                         "bool any(bool4 a)\n" +
                                         "{\n" +
                                         "    return a.x || a.y || a.z || a.w;\n" +
                                         "}");
                reference.DrawContent("asin (x)", "返回x的反正弦值,范围为(-π/2,π/2)");
                reference.DrawContent("atan2 (y,x)", "返回y/x的反正切值");
                reference.DrawContent("atan (x)", "返回x的反正切值,范围为(-π/2,π/2),表示弧度");
                reference.DrawContent("ceil (x)", "对x进行向上取整，即x=0.1返回1，x=1.5返回2，x=-0.3返回0\n" +
                                         "float ceil(float x)\n" +
                                         "{\n" +
                                         "    return -floor(-x);\n" +
                                         "}");
                reference.DrawContent("clamp(x,a,b)", "如果x值小于a，则返回a;如果x值大于b,返回b;否则返回x.\n" +
                                         "float clamp(float x, float a, float b)\n" +
                                         "{\n" +
                                         "    return max(a, min(b, x));\n" +
                                         "}");
                reference.DrawContent("clip (x)", "如果x<0则裁剪掉此片断\n" +
                                         "void clip(float4 x)\n" +
                                         "{\n" +
                                         "    if (any(x < 0))\n" +
                                         "    discard;\n" +
                                         "}");
                reference.DrawContent("cos(x)", "返回弧度x的余弦值,范围在[-1,1]之间.\n");
                reference.DrawContent("cosh(x)", "双曲余弦函数\n" +
                                         "float cosh(float x)\n" +
                                         "{\n" +
                                         "    return 0.5 * (exp(x) + exp(-x));\n" +
                                         "}");
                reference.DrawContent("cross(a,b)", "返回两个三维向量a与b的叉积\n" +
                                         "float3 cross(float3 a, float3 b)\n" +
                                         "{\n" +
                                         "    return a.yzx * b.zxy - a.zxy * b.yzx;\n" +
                                         "}");
                reference.DrawContent("ddx(v)", "当前像素右边的v值-当前像素的v值(水平方向的差值),假如v是坐标,那就是求坐标差");
                reference.DrawContent("ddy(v)", "当前像素下边的v值-当前像素的v值(垂直方向的差值)");
                reference.DrawContent("degrees(x)", "将x从弧度转换成角度\n" +
                                         "float degrees(float x)\n" +
                                         "{\n" +
                                         "    return 57.29577951 * x;\n" +
                                         "}\n" +
                                         "角度=180/π*弧度\n" +
                                         "弧度=π/180*角度");
                reference.DrawContent("determinant(M)", "返回方阵M的行列式,注意只有方阵才有行列式");
                reference.DrawContent("dot(a,b)", "点乘，a和b可以为标量也可以为向量,其计算结果是两个向量夹角的余弦值，相当于|a|*|b|*cos(θ)或者a.x*b.x+a.y*b.y+a.z*b.z\na和b的位置无所谓前后，结果都是一样的");
                reference.DrawContent("distance(a,b)", "返回a,b间的距离.\n" +
                                         "float distance(a, b)\n" +
                                         "{\n" +
                                         "    float3 v = b - a;\n" +
                                         "    return sqrt(dot(v, v));\n" +
                                         "}");
                reference.DrawContent("exp(x)", "计算e的x次方，e = 2.71828182845904523536");
                reference.DrawContent("exp2(x)", "计算2的x次方");

                reference.DrawContent("floor(x)", "对x值进行向下取整(去尾求整)\n比如:floor (0.6) = 0.0,floor (-0.6) = -1.0");
                reference.DrawContent("fmod(x,y)", "返回x/y的余数。如果y为0，结果不可预料,注意！如果x为负值，返回的结果也是负值！\n" +
                                         "float fmod(float a, float b)\n" +
                                         "{\n" +
                                         "    float c = frac(abs(a / b)) * abs(b);\n" +
                                         "    return (a < 0) ? -c : c;   /* if ( a < 0 ) c = 0-c */\n" +
                                         "}");
                reference.DrawContent("frac (x)", "返回x的小数部分\n" +
                                         "float frac(float x)\n" +
                                         "{\n" +
                                         "    return x - floor(x);\n" +
                                         "}");
                reference.DrawContent("fwidth(v)", "当前像素与它右边及下边像素的差值,abs( ddx(v) )+ abs(ddy(v))");
                reference.DrawContent("length (v)", "返回一个向量的模，即 sqrt(dot(v,v))");
                reference.DrawContent("lerp (A,B,alpha)", "线性插值.\n如果alpha=0，则返回A;\n如果alpha=1，则返回B;\n否则返回A与B的混合值;内部执行:A + alpha*(B-A)\n" +
                                         "float3 lerp(float3 A, float3 B, float alpha)\n" +
                                         "{\n" +
                                         "    return A + alpha*(B-A);\n" +
                                         "}");
                reference.DrawContent("log(x)", "返回x的自然对数,如果a^x = N（a>0，且a≠1），那么x就叫做以a为底N的对数.");
                reference.DrawContent("log2(x)", "返回以2为底的自然对数");
                reference.DrawContent("log10(x)", "返回以10为底的自然对数");
                reference.DrawContent("max(a,b)", "比较两个标量或等长向量元素，返回最大值");
                reference.DrawContent("min(a,b)", "比较两个标量或等长向量元素，返回最小值");
                reference.DrawContent("mul", "mul(M,v):矩阵M与列向量v相乘，结果就是对向量v进行矩阵M变换后的值,相当于mul(v,transpose(M)).\n" +
                                         "mul(v,M):行向量v与矩阵M相乘，结果就是对向量v进行矩阵M变换后的值,相当于mul(transpose(M),v).");

                reference.DrawContent("normalize(v)", "返回一个向量的归一化版本(方向一样，但是模为1)" +
                                         "\nnormalize(v) = rsqrt(dot(v,v))*v; rsqrt返回的是平方根的倒数");
                reference.DrawContent("pow(x,y)", "返回x的y次方\n" +
                                          "float pow(float x, float y)\n" +
                                          "{\n" +
                                          "   exp(x * log(y));\n" +
                                          "}");
                reference.DrawContent("PositivePow(x,y)", "同pow()，但是避免了报错的警告信息.");
                reference.DrawContent("rcp(x)", "返回x的倒数,相当于 1/x");
                reference.DrawContent("reflect(I, N)", "根据入射光方向向量 I ，和顶点法向量 N ，计算反射光方向向量。其中 I 和 N 必须被归一化，需要非常注意的是，这个 I 是指向顶点的；函数只对三元向量有效。\n\n" +
                                         "float3 reflect( float3 i, float3 n )\n" +
                                         "{\n" +
                                         "   return i - 2.0 * n * dot(n,i);\n" +
                                         "}");
                reference.DrawContent("refract(I,N,eta)", "计算折射向量， I 为入射光线， N 为法向量， eta 为折射系数；其中 I 和 N 必须被归一化，如果 I 和 N 之间的夹角太大，则返回（ 0 ， 0 ， 0 ），也就是没有折射光线； I 是指向顶点的；函数只对三元向量有效。\n\n" +
                                         "float3 refract( float3 i, float3 n, float eta )\n" +
                                         "{\n" +
                                         "   float cosi = dot(-i, n);\n" +
                                         "   float cost2 = 1.0f - eta * eta * (1.0f - cosi*cosi);\n" +
                                         "   float3 t = eta*i + ((eta*cosi - sqrt(abs(cost2))) * n);\n" +
                                         "   return t * (float3)(cost2 > 0);\n" +
                                         "}");
                reference.DrawContent("round(x)", "返回x四舍五入的值");
                reference.DrawContent("rsqrt(x)", "返回x的平方根倒数,注意x不能为0.相当于 pow(x, -0.5)");
                reference.DrawContent("saturate (x)", "如果x<0返回0,如果x>1返回1,否则返回x.");
                reference.DrawContent("sqrt(x)", "返回x的平方根.");
                reference.DrawContent("step(a,b)", "如果a<=b返回1,否则返回0.");
                reference.DrawContent("sign(x)", "如果x=0返回0,如果x>0返回1,如果x<0返回-1.");
                reference.DrawContent("sin(x)", "返回弧度x的正弦值,范围在[-1,1]之间.\n");
                reference.DrawContent("sincos(x,a,b)", "同时返回弧度x的正弦值a与余弦值b.\n");
                reference.DrawContent("smoothstep (min,max,x)", "float smoothstep (float min, float max, float x)\n" +
                                         "{\n" +
                                         "\tfloat t = saturate ((x - min) / (max - min));\n" +
                                         "\treturn t * t * (3.0 - (2.0 * t));\n" +
                                         "}\n" +
                                         "如果 x 比min 小，返回 0\n如果 x 比max 大，返回 1\n如果 x 处于范围 [min，max]中，则返回 0 和 1 之间的值(按值在min和max间的比例).\n如果只想要线性过渡，并不需要平滑的话，可以直接使用saturate((x - min)/(max - min))");
                reference.DrawContent("tan(x)", "返回x的正切值");
                reference.DrawContent("transpose (M)", "求矩阵M的转置.");
            }
        }

        public void DrawTitleMathTextureSampler()
        {
            reference.DrawTitle("Texture Sampler(普通纹理采样)");
        }

        public void DrawContentMathTextureSampler(bool isFold)
        {
            if (isFold)
            {
                reference.DrawContent("TEXTURE2D (textureName);", "二维纹理的定义(纹理与采样器分离定义),此功能在OpenGL ES2.0上不支持，会使用原来sampler2D的形式.\n" +
                                         "textureName:Properties中声明的2D纹理.");
                reference.DrawContent("TEXTURECUBE (textureName);", "立方体纹理的定义(纹理与采样器分离定义),此功能在OpenGL ES2.0上不支持，会使用原来samplerCube的形式.\n" +
                                         "textureName:Properties中声明的立方体纹理.");
                reference.DrawContent("SAMPLER(samplerName);", "采样器的定义(纹理与采样器分离定义),采样器是指纹理的过滤模式与重复模式,此功能在OpenGL ES2.0上不支持，相当于没写.\n" +
                                         "1.SAMPLER(sampler_textureName):sampler+纹理名称，这种定义形式是表示采用textureName这个纹理Inspector面板中的采样方式.\n" +
                                         "2.SAMPLER(_filter_wrap):比如SAMPLER(sampler_linear_repeat),使用自定义的采样器设置，自定义的采样器一定要同时包含过滤模式<filter>与重复模式<wrap>的设置，注意这种自定义写法很多移动平台不支持！.\n" +
                                         "3.SAMPLER(_filter_wrapU_wrapV):比如SAMPLER(sampler_linear_clampU_mirrorV),可同时设置重复模式的U与V的不同值.\n" +
                                         "4.filter:point/linear/triLinear\n" +
                                         "5.wrap:clamp/repeat/mirror/mirrorOnce");
                reference.DrawContent("float4 [textureName]_ST;", "获取纹理的Tiling(.xy)和Offset(.zw)");
                reference.DrawContent("float4 [textureName]_TexelSize;", "获取纹理的宽高分之一(.xy)和宽高(.zw)");
                reference.DrawContent("SAMPLE_TEXTURE2D(textureName, samplerName, coord);", "进行二维纹理采样操作\n" +
                                         "textureName:Properties中声明的2D纹理名称\n" +
                                         "samplerName:此纹理所使用的采样器设置\n" +
                                         "coord:采样用的UV");
                reference.DrawContent("SAMPLE_TEXTURE2D_LOD(textureName, samplerName, coord,lod);", "进行二维纹理采样操作\n" +
                                         "textureName:Properties中声明的2D纹理名称\n" +
                                         "samplerName:此纹理所使用的采样器设置\n" +
                                         "coord:采样用的UV\n" +
                                         "lod:mipmap级别");
                reference.DrawContent("SAMPLE_TEXTURE2D_BIAS(textureName, samplerName, coord,bias);", "对mipmap进行偏移后再采样纹理\n" +
                                         "textureName:Properties中声明的2D纹理名称\n" +
                                         "samplerName:此纹理所使用的采样器设置\n" +
                                         "coord:采样用的UV\n" +
                                         "bias:mipmap偏移量,比如0=默认,-1=比当前级别更清晰一级,1=比当前级别更模糊一级.");
                reference.DrawContent("SAMPLE_TEXTURECUBE(textureName, samplerName, coord);", "进行立方体纹理采样操作\n" +
                                         "textureName:Properties中声明的CUBE纹理名称\n" +
                                         "samplerName:此纹理所使用的采样器设置\n" +
                                         "coord:采样用的UV");
                reference.DrawContent("SAMPLE_TEXTURECUBE_LOD(textureName, samplerName, coord,lod);", "进行立方体纹理采样操作\n" +
                                         "textureName:Properties中声明的CUBE纹理名称\n" +
                                         "samplerName:此纹理所使用的采样器设置\n" +
                                         "coord:采样用的UV\n" +
                                         "lod:mipmap级别");
                reference.DrawContent("SAMPLE_TEXTURE3D(textureName, samplerName, coord);", "进行3D纹理采样操作\n" +
                                         "textureName:Properties中声明的3D纹理名称\n" +
                                         "samplerName:此纹理所使用的采样器设置\n" +
                                         "coord:采样用的三给UV");
            }
        }

        public void DrawTitleMathTextureArraySampler()
        {
            reference.DrawTitle("TextureArray(纹理数组采样)");
        }

        public void DrawContentMahTextureArraySampler(bool isFold)
        {
            if (isFold)
            {
                reference.DrawContent("TEXTURE2D_ARRAY(textureName);", "纹理数组的定义,此功能在OpenGL ES2.0上不支持，会fallback到samplerCUBE的形式.");
                reference.DrawContent("SAMPLER(sampler_samplerName);", "纹理数组的采样器定义.");
                reference.DrawContent("SAMPLE_TEXTURE2D_ARRAY(textureName, samplerName, coord2, index);", "纹理数组采样.\n" +
                                         "textureName:Properties中声明的2D纹理名称\n" +
                                         "samplerName:此纹理所使用的采样器设置\n" +
                                         "coord:采样用的UV\n" +
                                         "index:数组索引");
            }
        }
    }
}
