using UnityEngine;
using UnityEditor;

namespace yuxuetian.tools.shaderReference
{
    public class ShaderReferenceLighting : EditorWindow
    {
        private ShaderReferenceUtil reference = new ShaderReferenceUtil();

        public void DrawTitleLightModel()
        {
            reference.DrawTitle("LightModel(光照模型)");
        }
        public void DrawContentLightModel(bool isFold)
        {
            if (isFold)
            {
                reference.DrawContent("Lambertian", "Diffuse = Ambient + Kd * LightColor * max(0,dot(N,L))\n" +
                                        "Diffuse:\t最终物体上的漫反射光强.\n" +
                                        "Ambient:\t环境光强度，为了简化计算，环境光强采用一个常数表示.\n" +
                                        "Kd:\t物体材质对光的反射系数.\n" +
                                        "LightColor:\t光源的强度.\n" +
                                        "N:\t顶点的单位法线向量.\n" +
                                        "L:\t顶点指向光源的单位向量.");
                reference.DrawContent("Phong", "Specular = SpecularColor * Ks * pow(max(0,dot(R,V)), Shininess)\n" +
                                       "Specular:\t最终物体上的反射高光光强.\n" +
                                       "SpecularColor:\t反射光的颜色.\n" +
                                       "Ks:\t反射强度系数.\n" +
                                       "R:\t反射向量，可使用2 * N * dot(N,L) - L或者reflect (-L,N)获得.\n" +
                                       "V:\t观察方向.\n" +
                                       "N:\t顶点的单位法线向量.\n" +
                                       "L:\t顶点指向光源的单位向量.\n" +
                                       "Shininess:\t乘方运算来模拟高光的变化.");
                reference.DrawContent("Blinn-Phong", "Specular = SpecularColor * Ks * pow(max(0,dot(N,H)), Shininess)\n" +
                                         "Specular:\t最终物体上的反射高光光强.\n" +
                                         "SpecularColor:\t反射光的颜色.\n" +
                                         "Ks:\t反射强度系数.\n" +
                                         "N:\t顶点的单位法线向量.\n" +
                                         "H:\t入射光线L与视线V的中间向量，也称为半角向量H = normalize(L+V).\n" +
                                         "Shininess:\t乘方运算来模拟高光的变化.");
                reference.DrawContent("BRDF", "f(l,v) = diffuse + D(h)F(v,h)G(l,v,h)/4cos(n·l)cos(n·v)\n" +
                                          "f(l,v):\t双向反射分布函数的最终值,l表示光的方向,v表示视线的方向.\n" +
                                          "diffuse:\t漫反射.\n" +
                                          "D(h):\t法线分布函数(Normal Distribution Function),描述微面元法线分布的概率,即朝向正确的法线浓度.h为半角向量,表示光的方向与反射方向的半角向量,只有物体的微表面法向m = h时,才会反射到视线中.\nD(h) = roughness^2 / π((n·h)^2(roughness^2-1)+1)^2\n" +
                                          "F(v,h):\t菲涅尔方程(Fresnel Equation),描述不同的表面角下表面所反射的光线所占的比率.\nF(v,h) = F0 + (1-F0)(1-(v·h))^5(F0是0度入射角的菲涅尔反射值)\n" +
                                          "G(l,v,h):\t几何函数(Geometry Function),描述微平面自成阴影的属性,即微表面法向m = h的并未被遮蔽的表面点的百分比.\n" +
                                          "4cos(n·l)cos(n·v):\t校正因子(correctionfactor)作为微观几何的局部空间和整个宏观表面的局部空间之间变换的微平面量的校正.");
            }
        }

        public void DrawTitleNormal()
        {
            reference.DrawTitle("Normal(NormalMap)");
        }
        public void DrawContentNormal(bool isFold)
        {
            if (isFold)
            {
                reference.DrawContent("切线空间法线变换到世界空间：\n" +
                                       "1.Attributes中定义NORMAL与TANGENT语义.\n" +
                                       "   float3 normalOS     : NORMAL;\n" +
                                       "   float4 tangentOS    : TANGENT;\n" +
                                       "2.Varyings中声明三个变量用于组成成切线空间下的旋转矩阵.\n" +
                                       "   half4 normalWS      :TEXCOORD3;\n" +
                                       "   half4 tangentWS     :TEXCOORD4;\n" +
                                       "   half4 bitangentWS   :TEXCOORD5;\n" +
                                       "3.在顶点着色器中执行:\n" +
                                       "   方法一：\n" + 
                                       "   o.normalWS.xyz = TransformObjectToWorldNormal(v.normalOS);\n" +
                                       "   o.tangentWS.xyz = TransformObjectToWorldDir(v.tangentOS.xyz);\n" +
                                       "   half sign = v.tangentOS.w * GetOddNegativeScale();\n" +
                                       "   o.bitangentWS.xyz = cross(o.normalWS, o.tangentWS) * sign;\n" +
                                       "   方法二\n" +
                                       "   VertexNormalInputs normalInput = GetVertexNormalInputs(v.normalOS,v.tangentOS);\n" +
                                       "   o.tangentWS = normalInput.tangentWS;\n" +
                                       "   o.bitangentWS = normalInput.bitangentWS;\n" +
                                       "   o.normalWS = normalInput.normalWS;\n" + 
                                       "4.在片断着色器中计算出世界空间下的法线,然后再拿去进行需要的计算:\n" +
                                       "   方法一：\n" + 
                                       "   half3 normalMapTS = UnpackNormalScale(SAMPLE_TEXTURE2D(_NormalMap, sampler_NormalMap, i.uv),scale);\n" +
                                       "   half3 normalWS = mul(normalMap,half3x3(i.tangentWS.xyz, i.bitangentWS.xyz, i.normalWS.xyz));\n" + 
                                       "   方法二：\n"+
                                       "   float3x3 TBN = float3x3(i.tangentWS,i.bitangentWS,i.normalWS);\n" +
                                       "   half3 normalMapTS = UnpackNormalScale(SAMPLE_TEXTURE2D(_NormalMap, sampler_NormalMap, i.uv),scale);\n" +
                                       "   float3 normalWS = TransformTangentToWorld(normalTS , TBN);");
            }
            
            reference.DrawContent("法线混合", "方法一：\n" +
                                          "return normalize(float3(A.rg + B.rg, A.b * B.b));\n" +
                                          "方法二：\n" +
                                          "float3 t = A.xyz + float3(0.0, 0.0, 1.0);\n" +
                                          "float3 u = B.xyz * float3(-1.0, -1.0, 1.0);\n" +
                                          "float3 r = (t / t.z) * dot(t, u) - u;\n" +
                                          "return r;");
        }

        public void DrawTitleMainLight()
        {
            reference.DrawTitle("获取主方向光");
        }
        public void DrawContentMainLight(bool isFold)
        {
            if (isFold)
            {
                reference.DrawContent("Light light = GetMainLight(shadowCoord);", "获取主平行灯相关参数:\n" +
                                        "light.direction : 主平行灯的方向(_MainLightPosition.xyz),已归一化.\n" +
                                        "light.color : 主平行灯的颜色(_MainLightColor.rgb).\n" +
                                        //"light.distanceAttenuation : 主平行灯的CullingMask,当主灯的CullingMask包含当对象所在的层时返回1，否则返回0(unity_LightData.z).\n" +
                                        "light.shadowAttenuation : 在此函数下为1(half).");
            }
        }

        public void DrawTitleAdditionalLight()
        {
            reference.DrawTitle("获取额外光源");
        }
        public void DrawContentAdditioinalLight(bool isFold)
        {
            if (isFold)
            {
                reference.DrawContent("是否额外的灯启用.","#ifdef _ADDITIONAL_LIGHTS\n"+ 
                                      "uint AdditionalLightCount = GetAdditionalLightsCount();\n" +
                                      "for (uint lightIndex = 0; lightIndex < AdditionalLightCount; ++lightIndex)\n" + 
                                      "{\n" +
                                      "   Light light = GetAdditionalLight(lightIndex, i.posWorld.xyz);\n"+
                                      "   half3 attenuatedLightColor = light.color * (light.distanceAttenuation * light.shadowAttenuation);\n"+
                                      "   lightColor += LightingLambert(attenuatedLightColor, light.direction, normalDirection);\n" +
                                      "}\n" +
                                      "#endif");
                reference.DrawContent("_ADDITIONAL_LIGHTS_VERTEX", "额外的灯是否采用逐顶点照明."); 
            }
        }

        public void DrawTitleCastShadow()
        {
            reference.DrawTitle("投射阴影");
        }
        public void DrawContentCastShadow()
        {
            reference.DrawContent("ShadowCaster", "添加LightMode = ShadowCaster的pass即可渲染进lightmap产生投影.\n"+
                                    "UsePass \"Universal Render Pipeline/Lit/SHADOWCASTER\"");
        }
    }
}
