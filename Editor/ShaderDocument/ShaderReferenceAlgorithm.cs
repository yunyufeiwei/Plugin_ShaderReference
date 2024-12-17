using UnityEditor;

namespace yuxuetian
{
    public class ShaderReferenceAlgorithm : EditorWindow
    {
        private ShaderReferenceUtil _reference = new ShaderReferenceUtil();

        public void DrawTitleAlgorithmVertex()
        {
            _reference.DrawTitle("Vertex(顶点)");
        }

        public void DrawContentAlgorithmVertex(bool isFold)
        {
            if (isFold)
            {
                _reference.DrawContent("模型中心点坐标", "方法1: float3 objCenterPos = mul( unity_ObjectToWorld, float4( 0, 0, 0, 1 ) ).xyz;\n" +
                                                              "方法2: float3 objCenterPos = float3(UNITY_MATRIX_M[0][3], UNITY_MATRIX_M[1][3], UNITY_MATRIX_M[2][3]);\n" +
                                                              "方法3: float3 center = float3(unity_ObjectToWorld[0].w, unity_ObjectToWorld[1].w, unity_ObjectToWorld[2].w);\n" +
                                                              "方法4: float3 center = float3(unity_ObjectToWorld._m03, unity_ObjectToWorld._m13, unity_ObjectToWorld._m23);\n" +
                                                              "方法5: float3 center = unity_ObjectToWorld._14_24_34;\n" +
                                                              "在Shader中获取当前模型中心点在世界空间下的坐标位置,整体缩放时uv会整体缩放，如果需要做某一个平面缩放，则需要重组UV坐标。");
                _reference.DrawContent("获取模型的旋转角度(Y轴)", "float cosA = unity_ObjectToWorld._11;\n" +
                                                                      "float sinA = unity_ObjectToWorld._13;\n" +
                                                                      "float angle = atan2(sinA, cosA);\n" +
                                                                      "angle *= 180 / 3.1415926;\n" +
                                                                      "if (angle < 0) angle += 360;");
                _reference.DrawContent("BillBoard", "在Properties中添加:\n" +
                                                            "[Enum(BillBoard,1,VerticalBillboard,0)]BillBoardType(\"BillBoard Type\",float) = 1\n\n" +
                                                            "在顶点着色器中添加:\n" +
                                                            "//将相机从世界空间转换到模型的本地空间中,而这个转换后的相机坐标即是点也是模型中心点(0,0,0)到相机的方向向量，如果按照相机空间来定义的话，可以把这个向量定义为相机空间下的Z值\n" +
                                                            "float3  cameraOS_Z = mul(unity_WorldToObject, float4(_WorldSpaceCameraPos, 1));\n" +
                                                            "//BillBoardType=0时,圆柱形BillBoard;BillBoard=1时,圆形BillBoard;\n" +
                                                            "cameraOS_Z.y = cameraOS_Z.y * BillBoardType;\n" +
                                                            "//归一化，使其为长度不变模为1的向量\n" +
                                                            "cameraOS_Z = normalize(cameraOS_Z);\n" +
                                                            "//假设相机空间下的Y轴向量为(0,1,0)\n" +
                                                            "cameraOS_Y = float3(0,1,0);\n" +
                                                            "//利用叉积求出相机空间下的X轴向量\n" +
                                                            "float3 cameraOS_X = normalize(cross(cameraOS_Z,cameraOS_Y));\n" +
                                                            "//再次利用叉积求出相机空间下的Y轴向量\n" +
                                                            "cameraOS_Y = cross(cameraOS_X,cameraOS_Z);\n" +
                                                            "//通过向量与常数相乘来把顶点的X轴与Y对应到cameraOS的X与Y轴向上\n" +
                                                            "float3 billboardPositionOS = cameraOS_X * v.vertex.x + cameraOS_Y * v.vertex.y;\n" +
                                                            "o.pos = UnityObjectToClipPos(billboardPositionOS);");
                _reference.DrawContent("网格阴影", "half4 worldPos = mul(unity_ObjectToWorld, v.vertex);\n" +
                                                          "worldPos.y = 2.47;\n" +
                                                          "worldPos.xz += fixed2(阴影X方向,阴影Z方向)*v.vertex.y;\n" +
                                                          "o.pos = mul(UNITY_MATRIX_VP,worldPos);");
            }
        }
        
        public void DrawTitleuvTransform()
        {
            _reference.DrawTitle("UV变换");
        }

        public void DrawContentuvTransform(bool isFold)
        {
            if (isFold)
            {
                _reference.DrawContent("UV重映射到中心位置", "float2 centerUV = uv * 2 - 1\n将UV值重映射为(-1,-1)~(1,1)，也就是将UV的中心点从左下角移动到中间位置。");
                _reference.DrawContent("从中心缩放纹理", "half2 offset = (0.5-i.uv.xy)*_Offset;\nhalf4 baseMap = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.uv.xy + offset);");
                _reference.DrawContent("旋转", "float t=_Time.y;\nfloat2 rot= cos(t)*i.uv+sin(t)*float2(i.uv.y,-i.uv.x);");
                _reference.DrawContent("极坐标", "float2 centerUV = (i.uv * 2 - 1);\n" +
                                              "float atan2UV = 1 - abs(atan2(centerUV.g, centerUV.r) / 3.14);\n" +
                                              "利用UV来实现极坐标.");
            }
        }
        
        public void DrawTitleAlgorithmUVShape()
        {
            _reference.DrawTitle("UV图形");
        }

        public void DrawContentAlgorithmUVShape(bool isFold)
        {
            if (isFold)
            {
                _reference.DrawContent("画圆", "float circle = smoothstep(_Radius, (_Radius + _CircleFade), length(uv * 2 - 1));\n利用UV来画圆，通过_Radius来调节大小，_CircleFade来调节边缘虚化程序。");
                _reference.DrawContent("画矩形", "float2 centerUV = abs(i.uv.xy * 2 - 1);\n" +
                                          "float rectangleX = smoothstep(_Width, (_Width + _RectangleFade), centerUV.x);\n" +
                                          "float rectangleY = smoothstep(_Heigth, (_Heigth + _RectangleFade), centerUV.y);\n" +
                                          "float rectangleClamp = clamp((rectangleX + rectangleY), 0.0, 1.0);\n" +
                                          "利用UV来画矩形，_Width调节宽度，_Height调节高度，_RectangleFade调节边缘虚化度。");
                _reference.DrawContent("黑白棋盘格", "float2 uv = i.uv * 格子密度;\n" +
                                            "uv = floor(uv) * 0.5;\n" +
                                            "float c = frac(uv.x + uv.y) * 2;\n" +
                                            "return c;");
                _reference.DrawContent("蜂窝格", "float2 uv = i.uv * 格子密度;\n" +
                                          "uv.y += floor(uv.x) * 0.5;\n" +
                                          "uv = fmod(uv,1);\n" +
                                          "uv = uv*2-1;\n" +
                                          "uv = abs(uv);\n" +
                                          "float d = max((uv.x*0.9+uv.y*0.5),uv.y);\n" +
                                          "d = step(d,_Size);\n" +
                                          "return d;");
                
                _reference.DrawContent("将0-1的值控制在某个自定义的区间内", "frac(x*n+n);\n比如frac(i.uv*3.33+3.33);就是将0-1的uv值重新定义为0.33-0.66");
                _reference.DrawContent("随机", "1.float2 uv = floor(i.uv.xy*24);\n2.frac(sin(dot(uv, float2(12.9898, 78.233))) * 43758.5453);\n或者:frac(sin(x)*n);");
                _reference.DrawContent("序列图", "splitUV是把原有的UV重新定位到左上角的第一格UV上，_Sequence.xy表示的是纹理是由几x几的格子组成的,_Sequence.z表示的是走序列的快慢." +
                                          "\nfloat2 splitUV = uv * (1/_Sequence.xy) + float2(0,_Sequence.y - 1/_Sequence.y);" +
                                          "\nfloat time = _Time.y * _Sequence.z;" +
                                          "\nuv = splitUV + float2(floor(time *_Sequence.x)/_Sequence.x,1-floor(time)/_Sequence.y);");
            }
        }

        public void DrawTitleAlgorithmColor()
        {
            _reference.DrawTitle("Color(颜色)");
        }

        public void DrawContentAlgorithmColor(bool isFold)
        {
            if (isFold)
            {
                _reference.DrawContent("去色", "方法1：Luminance(float rgb)\n" +
                                          "方法2：dot(rgb,fixed3(0.22,0.707,0.071))\n" +
                                          "方法3：dot(rgb,half3(0.299,0.587,0.114))\n" +
                                          "方法4：(r+g+b)/3");
                _reference.DrawContent("RGB2HSV方法", "half3 RGB2HSV(half3 c)\n" +
                                          "{\n" +
                                          "\thalf4 K = half4(0.0, -1.0 / 3.0, 2.0 / 3.0, -1.0);\n" +
                                          "\thalf4 p = lerp(half4(c.bg, K.wz), half4(c.gb, K.xy), step(c.b, c.g));\n" +
                                          "\thalf4 q = lerp(half4(p.xyw, c.r), half4(c.r, p.yzx), step(p.x, c.r));\n" +
                                          "\thalf d = q.x - min(q.w, q.y);\n" +
                                          "\thalf e = 1.0e-10;\n" +
                                          "\treturn half3(abs(q.z + (q.w - q.y) / (6.0 * d + e)), d / (q.x + e), q.x);\n" +
                                          "}");
                _reference.DrawContent("HSV2RGB方法", "half3 HSV2RGB (half3 c)\n" +
                                          "{\n" +
                                          "\tfloat4 K = float4 (1.0, 2.0 / 3.0, 1.0 / 3.0, 3.0);\n" +
                                          "\tfloat3 p = abs (frac (c.xxx + K.xyz) * 6.0 - K.www);\n" +
                                          "\treturn c.z * lerp (K.xxx, saturate (p - K.xxx), c.y);\n" +
                                          "}");
                _reference.DrawContent("利用HSV对颜色进行调整", "half3 hsv = RGB2HSV(baseMap.rgb);\nbaseMap.rgb = HSV2RGB(float3((hsv.x + _HSVValue.x), (hsv.y * _HSVValue.y), (hsv.z * _HSVValue.z)));");

            }
        }

        public void DrawTitleAlgorithmLight()
        {
            _reference.DrawTitle("Light(光照)");
        }

        public void DrawContentAlgorithmLight(bool isFold)
        {
            if (isFold)
            {
                _reference.DrawContent("MatCap","顶点着色器阶段:将模型法线从本地空间转换到世界空间\n" + 
                                                        "half3 normalWS = TransformObjectToWorldNormal(v.normalOS);\n" + 
                                                        "将模型的法线从世界空间转换到试图空间，并进行区域限制。\n" +
                                                        "viewSpace空间下的法线区域是[-1,1]，而uv的区域是[0，1],因此需要进行一个x *0.5+0.5的操作。\n"+
                                                        "●方法一:使用内置的函数进行空间变换\n" + 
                                                        "o.normalVS = TransformWorldToViewDir(normalWS) * 0.5 + 0.5;\n" +
                                                        "●方法二:使用内置矩阵手动进行空间变换\n" +
                                                        "o.normalVS = mul(UNITY_MATRIX_V, float4(o.normalWS, 0.0)).xy * 0.5 + 0.5;\n\n" +
                                                        "片段着色器阶段:采样MatCapTexture\n" +
                                                        "half4 matCapTexture = SAMPLE_TEXTURE2D(_MatCapTexture,sampler_MatCapTexture , i.normalVS.xy);");
            }
        }

        public void DrawTitleAlgorithmOther()
        {
            _reference.DrawTitle("Other(其它)");
        }

        public void DrawContentAlgorithmFresnel(bool isFold)
        {
            if (isFold)
            {
                _reference.DrawContent("Fresnel(菲涅尔)", " half3 rimColor = half4 (0, 0.4, 1, 1);\n " +
                                                       "half3 worldViewDir = normalize (UnityWorldSpaceViewDir (i.worldPos));\n " +
                                                       "float  ndotv = dot (i.normal, worldViewDir);\n " +
                                                       "float  fresnel = (0.2 + 2.0 * pow (1.0 - ndotv, 2.0));\n " +
                                                       "half4 FinalColor = rimColor * fresnel;");
            }
        }

        public void DrawContnetAlgorithmXRar(bool isFold)
        {
            if (isFold)
            {
                _reference.DrawContent("X-Ray(射线)",
                    "1. 新建一个Pass\n2.设置自己想要的Blend\n3.Zwrite Off关闭深度写入\n4.Ztest greater深度测试设置为大于 ");
            }
        }

        public void DrawContentAlgorithmDither(bool isFold)
        {
            if (isFold)
            {
                _reference.DrawContent("Dither(抖动)","//先求出整数型的屏幕像素UV(求余后)\n" +
                                          "float2 uv = (uint2)i.positionCS.xy%行数;\n" +
                                          "//然后调用相应的方法\n" +
                                          "float Dither2x2(float2 uv)\n" +
                                          "{\n" +
                                          "   float D[4] =\n" +
                                          "   {\n" +
                                          "       0,2,\n" +
                                          "       3,1\n" +
                                          "   };\n" +
                                          "   uint index = uv.x * 2 + uv.y;\n" +
                                          "   return D[index] / 5;\n" +
                                          "}\n\n" +
                                          "float Dither4x4(float2 uv)\n" +
                                          "{\n" +
                                          "   float D[16] =\n" +
                                          "   {\n" +
                                          "       0,8,2,10,\n" +
                                          "       12,4,14,6,\n" +
                                          "       3,11,1,9,\n" +
                                          "       15,7,13,5\n" +
                                          "   };\n" +
                                          "   uint index = uv.x * 4 + uv.y;\n" +
                                          "   return D[index] / 17;\n" +
                                          "}\n\n" +
                                          "float Dither8x8(float2 uv)\n" +
                                          "{\n" +
                                          "   float D[64] =\n" +
                                          "   {\n" +
                                          "       0,32,8,40,2,34,10,42,\n" +
                                          "       48,16,56,24,50,18,58,26,\n" +
                                          "       12,44,4,36,14,46,6,38,\n" +
                                          "       60,28,52,20,62,30,54,22,\n" +
                                          "       3,35,11,43,1,33,9,41,\n" +
                                          "       51,19,59,27,49,17,57,25,\n" +
                                          "       15,47,7,39,13,45,5,37,\n" +
                                          "       63,31,55,23,61,29,53,21\n" +
                                          "   };\n" +
                                          "   uint index = uv.x * 8 + uv.y;\n" +
                                          "   return D[index] / 65;\n" +
                                          "}\n");
            }
        }
    }
}

