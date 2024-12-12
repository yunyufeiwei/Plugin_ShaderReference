using UnityEditor;

namespace yuxuetian
{
    public class ShaderReferenceMath : EditorWindow
    {
        private ShaderReferenceUtil _reference = new ShaderReferenceUtil();

        public void DrawTitleMathFunction()
        {
            _reference.DrawTitle("Math(数学函数)" , "https://learn.microsoft.com/zh-cn/windows/win32/direct3dhlsl/dx-graphics-hlsl-intrinsic-functions");
        }

        public void DrawContentMathFunction(bool isFold)
        {
            if (isFold)
            {
                _reference.DrawContent("abs (x)", "取绝对值，即正值返回正值，负值返回的还是正值,x值也可以为向量\n" +
                                        "float abs(float a)\n" +
                                        "{\n" +
                                        "    return max(-a, a);\n" +
                                        "}");
                _reference.DrawContent("acos (x)", "反余弦函数,输入参数范围为[-1, 1],返回[0, π] 区间的弧度值");
                _reference.DrawContent("all (a)", "当a或a的所有分量都为true或者非0时返回1(true),否则返回0(false).\n" +
                                         "bool all(bool4 a)\n" +
                                         "{\n" +
                                         "    return a.x && a.y && a.z && a.w;\n" +
                                         "}");
                _reference.DrawContent("any (a)", "如果a=0或者a中的所有分量为0，则返回0(false);否则返回1(true).\n" +
                                         "bool any(bool4 a)\n" +
                                         "{\n" +
                                         "    return a.x || a.y || a.z || a.w;\n" +
                                         "}");
                _reference.DrawContent("asin (x)", "返回x的反正弦值,范围为(-π/2,π/2)");
                _reference.DrawContent("atan2 (y,x)", "返回y/x的反正切值");
                _reference.DrawContent("atan (x)", "返回x的反正切值,范围为(-π/2,π/2),表示弧度");
                _reference.DrawContent("ceil (x)", "对x进行向上取整，即x=0.1返回1，x=1.5返回2，x=-0.3返回0\n" +
                                         "float ceil(float x)\n" +
                                         "{\n" +
                                         "    return -floor(-x);\n" +
                                         "}");
                _reference.DrawContent("clamp(x,a,b)", "如果x值小于a，则返回a;如果x值大于b,返回b;否则返回x.\n" +
                                         "float clamp(float x, float a, float b)\n" +
                                         "{\n" +
                                         "    return max(a, min(b, x));\n" +
                                         "}");
                _reference.DrawContent("clip (x)", "如果x<0则裁剪掉此片断\n" +
                                         "void clip(float4 x)\n" +
                                         "{\n" +
                                         "    if (any(x < 0))\n" +
                                         "    discard;\n" +
                                         "}");
                _reference.DrawContent("cos(x)", "返回弧度x的余弦值,范围在[-1,1]之间.\n");
                _reference.DrawContent("cosh(x)", "双曲余弦函数\n" +
                                         "float cosh(float x)\n" +
                                         "{\n" +
                                         "    return 0.5 * (exp(x) + exp(-x));\n" +
                                         "}");
                _reference.DrawContent("cross(a,b)", "返回两个三维向量a与b的叉积\n" +
                                         "float3 cross(float3 a, float3 b)\n" +
                                         "{\n" +
                                         "    return a.yzx * b.zxy - a.zxy * b.yzx;\n" +
                                         "}");
                _reference.DrawContent("ddx(v)", "当前像素右边的v值-当前像素的v值(水平方向的差值),假如v是坐标,那就是求坐标差");
                _reference.DrawContent("ddy(v)", "当前像素下边的v值-当前像素的v值(垂直方向的差值)");
                _reference.DrawContent("degrees(x)", "将x从弧度转换成角度\n" +
                                         "float degrees(float x)\n" +
                                         "{\n" +
                                         "    return 57.29577951 * x;\n" +
                                         "}\n" +
                                         "角度=180/π*弧度\n" +
                                         "弧度=π/180*角度");
                _reference.DrawContent("determinant(M)", "返回方阵M的行列式,注意只有方阵才有行列式");
                _reference.DrawContent("dot(a,b)", "点乘，a和b可以为标量也可以为向量,其计算结果是两个向量夹角的余弦值，相当于|a|*|b|*cos(θ)或者a.x*b.x+a.y*b.y+a.z*b.z\na和b的位置无所谓前后，结果都是一样的");
                _reference.DrawContent("distance(a,b)", "返回a,b间的距离.\n" +
                                         "float distance(a, b)\n" +
                                         "{\n" +
                                         "    float3 v = b - a;\n" +
                                         "    return sqrt(dot(v, v));\n" +
                                         "}");
                _reference.DrawContent("exp(x)", "计算e的x次方，e = 2.71828182845904523536");
                _reference.DrawContent("exp2(x)", "计算2的x次方");

                _reference.DrawContent("floor(x)", "对x值进行向下取整(去尾求整)\n比如:floor (0.6) = 0.0,floor (-0.6) = -1.0");
                _reference.DrawContent("fmod(x,y)", "返回x/y的余数。如果y为0，结果不可预料,注意！如果x为负值，返回的结果也是负值！\n" +
                                         "float fmod(float a, float b)\n" +
                                         "{\n" +
                                         "    float c = frac(abs(a / b)) * abs(b);\n" +
                                         "    return (a < 0) ? -c : c;   /* if ( a < 0 ) c = 0-c */\n" +
                                         "}");
                _reference.DrawContent("frac (x)", "返回x的小数部分\n" +
                                         "float frac(float x)\n" +
                                         "{\n" +
                                         "    return x - floor(x);\n" +
                                         "}");
                _reference.DrawContent("fwidth(v)", "当前像素与它右边及下边像素的差值,abs( ddx(v) )+ abs(ddy(v))");
                _reference.DrawContent("length (v)", "返回一个向量的模，即 sqrt(dot(v,v))");
                _reference.DrawContent("lerp (A,B,alpha)", "线性插值.\n如果alpha=0，则返回A;\n如果alpha=1，则返回B;\n否则返回A与B的混合值;内部执行:A + alpha*(B-A)\n" +
                                         "float3 lerp(float3 A, float3 B, float alpha)\n" +
                                         "{\n" +
                                         "    return A + alpha*(B-A);\n" +
                                         "}");
                _reference.DrawContent("log(x)", "返回x的自然对数,如果a^x = N（a>0，且a≠1），那么x就叫做以a为底N的对数.");
                _reference.DrawContent("log2(x)", "返回以2为底的自然对数");
                _reference.DrawContent("log10(x)", "返回以10为底的自然对数");
                _reference.DrawContent("max(a,b)", "比较两个标量或等长向量元素，返回最大值");
                _reference.DrawContent("min(a,b)", "比较两个标量或等长向量元素，返回最小值");
                _reference.DrawContent("mul", "mul(M,v):矩阵M与列向量v相乘，结果就是对向量v进行矩阵M变换后的值,相当于mul(v,transpose(M)).\n" +
                                         "mul(v,M):行向量v与矩阵M相乘，结果就是对向量v进行矩阵M变换后的值,相当于mul(transpose(M),v).");

                _reference.DrawContent("normalize(v)", "返回一个向量的归一化版本(方向一样，但是模为1)" +
                                         "\nnormalize(v) = rsqrt(dot(v,v))*v; rsqrt返回的是平方根的倒数");
                _reference.DrawContent("pow(x,y)", "返回x的y次方\n" +
                                          "float pow(float x, float y)\n" +
                                          "{\n" +
                                          "   exp(x * log(y));\n" +
                                          "}");
                _reference.DrawContent("PositivePow(x,y)", "同pow()，但是避免了报错的警告信息.");
                _reference.DrawContent("rcp(x)", "返回x的倒数,相当于 1/x");
                _reference.DrawContent("reflect(I, N)", "根据入射光方向向量 I ，和顶点法向量 N ，计算反射光方向向量。其中 I 和 N 必须被归一化，需要非常注意的是，这个 I 是指向顶点的；函数只对三元向量有效。\n\n" +
                                         "float3 reflect( float3 i, float3 n )\n" +
                                         "{\n" +
                                         "   return i - 2.0 * n * dot(n,i);\n" +
                                         "}");
                _reference.DrawContent("refract(I,N,eta)", "计算折射向量， I 为入射光线， N 为法向量， eta 为折射系数；其中 I 和 N 必须被归一化，如果 I 和 N 之间的夹角太大，则返回（ 0 ， 0 ， 0 ），也就是没有折射光线； I 是指向顶点的；函数只对三元向量有效。\n\n" +
                                         "float3 refract( float3 i, float3 n, float eta )\n" +
                                         "{\n" +
                                         "   float cosi = dot(-i, n);\n" +
                                         "   float cost2 = 1.0f - eta * eta * (1.0f - cosi*cosi);\n" +
                                         "   float3 t = eta*i + ((eta*cosi - sqrt(abs(cost2))) * n);\n" +
                                         "   return t * (float3)(cost2 > 0);\n" +
                                         "}");
                _reference.DrawContent("round(x)", "返回x四舍五入的值");
                _reference.DrawContent("rsqrt(x)", "返回x的平方根倒数,注意x不能为0.相当于 pow(x, -0.5)");
                _reference.DrawContent("saturate (x)", "如果x<0返回0,如果x>1返回1,否则返回x.");
                _reference.DrawContent("sqrt(x)", "返回x的平方根.");
                _reference.DrawContent("step(a,b)", "如果a<=b返回1,否则返回0.");
                _reference.DrawContent("sign(x)", "如果x=0返回0,如果x>0返回1,如果x<0返回-1.");
                _reference.DrawContent("sin(x)", "返回弧度x的正弦值,范围在[-1,1]之间.\n");
                _reference.DrawContent("sincos(x,a,b)", "同时返回弧度x的正弦值a与余弦值b.\n");
                _reference.DrawContent("smoothstep (min,max,x)", "float smoothstep (float min, float max, float x)\n" +
                                         "{\n" +
                                         "\tfloat t = saturate ((x - min) / (max - min));\n" +
                                         "\treturn t * t * (3.0 - (2.0 * t));\n" +
                                         "}\n" +
                                         "如果 x 比min 小，返回 0\n如果 x 比max 大，返回 1\n如果 x 处于范围 [min，max]中，则返回 0 和 1 之间的值(按值在min和max间的比例).\n如果只想要线性过渡，并不需要平滑的话，可以直接使用saturate((x - min)/(max - min))");
                _reference.DrawContent("tan(x)", "返回x的正切值");
                _reference.DrawContent("transpose (M)", "求矩阵M的转置.");
            }
        }

        
        
    }
}
