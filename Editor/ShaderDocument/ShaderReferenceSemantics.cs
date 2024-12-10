using UnityEditor;

namespace yuxuetian
{
    public class ShaderReferenceSemantics : EditorWindow
    {
        private ShaderReferenceUtil _reference = new ShaderReferenceUtil();

        public void DrawTitleAttribute()
        {
            _reference.DrawTitle("应用程序到顶点着色器的数据（Attribute）");
        }
        public void DrawContentAttribute(bool isFold)
        {
            if (isFold)
            {
                _reference.DrawContent("float4 positionOS   : POSITION;" , "顶点的本地坐标");
                _reference.DrawContent("float3 normalOS     : NORMAL;" , "顶点的法线信息");
                _reference.DrawContent("float4 tangentOS    : TANGENT;","顶点的切线信息");
                _reference.DrawContent("float4 color             : COLOR;", "顶点的顶点色信息");
                _reference.DrawContent("float4 texcoord      : TEXCOORD0;", "顶点的UV1信息");
                _reference.DrawContent("float4 texcoord1     : TEXCOORD1;", "顶点的UV2信息");
                _reference.DrawContent("float4 texcoord2     : TEXCOORD2;", "顶点的UV3信息");
                _reference.DrawContent("float4 texcoord3     : TEXCOORD3;", "顶点的UV4信息");
            }
        }

        public void DrawTitleVaryings()
        {
            _reference.DrawTitle("顶点着色器到片段着色器的数据（Varying）");   
        }
        public void DrawContentVaryings(bool isFold)
        {
            if (isFold)
            {
                _reference.DrawContent("float4 positionHCS  : SV_POSITION;","顶点的齐次裁剪空间下的坐标,默认情况下用POSITION也可以(PS4下不支持)，但是为了支持所有平台，所以最好使用SV_POSITION.");
                _reference.DrawContent("float2 uv           : TEXCOORD0;" , "用来采样uv纹理的坐标，通常是float2，但也可以使用float4来定义,");
                _reference.DrawContent("注意事项", "1.OpenGL ES2.0支持最多8个\n2.OpenGL ES3.0支持最多16个");
            }
        }

        public void DrawTitlePixelShading()
        {
            _reference.DrawTitle("像素着色器语义（half4 frag）");
        }
        public void DrawContentPixelShading(bool isFold)
        {
            if (isFold)
            {
                _reference.DrawContent("half4 frag (Varyings i) : SV_Target","常用的像素着色器语义，这里的sv_Target语义等价于COLOR");
                _reference.DrawContent("struct FragmentOutput\n" +
                                       "{\n" +
                                       "    half4 color : SV_Target;\n" +
                                       "    half4 depth : SV_Depth;\n" +
                                       "    half4 vFace : SV_IsFrontFace;\n" +
                                       "}","定义像素着色器输出结构体,然后在FragmentOutput frag(Varyings i)像素着色器输出中实现。");
                
            }
        }

        public void DrawTitleSemanticsWebsite()
        {
            _reference.DrawTitle("语义相关网址");
        }
        public void DrawContentSemanticsWebsite()
        {
            _reference.DrawContentSite("语义网址：","https://learn.microsoft.com/zh-cn/windows/win32/direct3dhlsl/dx-graphics-hlsl-semantics?redirectedfrom=MSDN#vertex-shader-semantics");
        }
    }
}

