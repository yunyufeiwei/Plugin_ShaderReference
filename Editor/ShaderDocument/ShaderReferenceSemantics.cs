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
                _reference.DrawContent("float4 color        : COLOR;", "顶点的顶点色信息");
                _reference.DrawContent("float4 texcoord     : TEXCOORD0;", "顶点的UV1信息");
                _reference.DrawContent("float4 texcoord1    : TEXCOORD1;", "顶点的UV2信息");
                _reference.DrawContent("float4 texcoord2    : TEXCOORD2;", "顶点的UV3信息");
                _reference.DrawContent("float4 texcoord3    : TEXCOORD3;", "顶点的UV4信息");
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
    }
}

