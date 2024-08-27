using UnityEditor;

namespace Editor.ShaderDocument
{
    public class ShaderReferenceColorBlendMode : EditorWindow
    {
        private ShaderReferenceUtil _reference = new ShaderReferenceUtil();

        public void DrawTitleColorBlendModePS()
        {
            _reference.DrawTitle("PS中的混合公式(A、B为图层)");
        }

        public void DrawContentColorBlendModePS()
        {
            _reference.DrawContent("正常", "A*(1-B.a)+B*(B.a)");
            _reference.DrawContent("变暗", "min(A,B)");
            _reference.DrawContent("变亮", "max(A,B)");
            _reference.DrawContent("正片叠底", "A*B");
            _reference.DrawContent("滤色", "1-((1-A)*(1-B))");
            _reference.DrawContent("颜色加深", "A-((1-A)*(1-B))/B");
            _reference.DrawContent("颜色减淡", "A+(A*B)/(1-B)");
            _reference.DrawContent("线性加深", "A+B-1");
            _reference.DrawContent("线性减淡", "A+B");
            _reference.DrawContent("叠加", "half4 a = step(A,0.5);\n" +
                                         "half4 c = a*A*B*2+(1-a)*(1-(1-A)*(1-B)*2);");
            _reference.DrawContent("强光", "half4 a = step(B,0.5);\n" +
                                         "half4 c =a*A*B*2+(1-a)*(1-(1-A)*(1-B)*2);");
            _reference.DrawContent("柔光", "half4 a = step(B,0.5);\n" +
                                         "half4 c =a*(A*B*2+A*A*(1-B*2))+(1-a)*(A*(1-B)*2+sqrt(A)*(2*B-1)");
            _reference.DrawContent("亮光", "half4 a = step(B,0.5);\n" +
                                         "half4 c =a*(A-(1-A)*(1-2*B)/(2*B))+(1-a)*(A+A*(2*B-1)/(2*(1-B)));");
            _reference.DrawContent("点光", "half4 a = step(B,0.5);\n" +
                                         "half4 c =a*(min(A,2*B))+(1-a)*(max(A,( B*2-1)));");
            _reference.DrawContent("线性光", "A+2*B-1");
            // ShaderReferenceUtil.DrawOneContent("实色混合", "half4 a = step(A+B,1);\n" +
            // "half4 c =a*(fixed4(0,0,0,0))+(1-a)*(fixed4(1,1,1,1));");
            _reference.DrawContent("排除", "A+B-A*B*2");
            _reference.DrawContent("差值", "abs(A-B)");
            _reference.DrawContent("深色", "half4 a = step(B.r+B.g+B.b,A.r+A.g+A.b);\n" +
                                         "half4 c =a*(B)+(1-a)*(A);");
            _reference.DrawContent("浅色", "half4 a = step(B.r+B.g+B.b,A.r+A.g+A.b);\n" +
                                         "half4 c =a*(A)+(1-a)*(B);");
            _reference.DrawContent("减去", "A-B");
            _reference.DrawContent("划分", "A/B");
        }
        
    } 
}

