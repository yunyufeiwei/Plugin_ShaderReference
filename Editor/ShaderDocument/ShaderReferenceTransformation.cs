using UnityEditor;

namespace yuxuetian
{
    public class ShaderReferenceTransformation : EditorWindow
    {
        private ShaderReferenceUtil _reference = new ShaderReferenceUtil();
        
        public void DrawTitleTransformationBase()
        {
            _reference.DrawTitle("位置与方向(矢量)");
        }

        public void DrawContentTransformationBase()
        {
            _reference.DrawContent("矢量表示写法", "Unity提供的内置矩阵是4X4的矩阵，与矢量左乘(矩阵放左边)就能得到变换新坐标后的矢量数据.\n" +
                                             "Unity矢量必须写成四维度而不是三维，位置写成(x,y,z,1),方向写成(x,y,z,0)\n" +
                                             "例如：\n" +
                                             "模型空间的顶点位置变换到世界空间的顶点位置:\n" +
                                             "float3 positionWS = mul(UNITY_MATRIX_M , float4(positionOS , 1).xyz;\n" +
                                             "模型空间的法线方向变换到相机空间的法线方向:\n" +
                                             "方法一：float3 normalVS = mul(UNITY_MATRIX_IT_MV , float4(normalOS , 0)).xyz);\n" +
                                             "方法二：float3 normalVS = mul((float3x3)UNITY_MATRIX_IT_MV , normalOS);");
        }

        public void DrawTitleSpaceTransformationMatrix()
        {
            _reference.DrawTitle("空间变换(矩阵)");
        }

        public void DrawContentSpaceTransformationMatrix(bool isFold)
        {
            if (isFold)
            {
                _reference.DrawContent("UNITY_MATRIX_M", "模型变换矩阵(unity_ObjectToWorld):通常用于把矢量从模型空间变换到世界空间");
                _reference.DrawContent("UNITY_MATRIX_I_M", "模型变换逆矩阵(unity_WorldToObject):通常用于把矢量从世界空间变换到模型空间");
                _reference.DrawContent("UNITY_MATRIX_V", "视图变换矩阵(unity_MatrixV):通常用于把矢量从世界空间变换到相机空间");
                _reference.DrawContent("UNITY_MATRIX_I_V", "视图变换逆矩阵(unity_MatrixInvV):通常用于把矢量从相机空间变换到世界空间");
                _reference.DrawContent("UNITY_MATRIX_P", "投影变换矩阵(OptimizeProjectionMatrix(glstate_matrix_projection)):通常用于把矢量从相机空间变换到裁剪空间");
                _reference.DrawContent("UNITY_MATRIX_I_P", "投影变换逆矩阵(ERROR_UNITY_MATRIX_I_P_IS_NOT_DEFINED):通常用于把矢量从裁剪空间变换到相机");
                _reference.DrawContent("UNITY_MATRIX_VP", "视图投影变换矩阵(unity_MatrixVP):通常用于把矢量从世界空间变换到裁剪空间");
                _reference.DrawContent("UNITY_MATRIX_I_VP", "视图投影变换逆矩阵(_InvCameraViewProj):通常用于把矢量从裁剪空间变换到世界空间");
                _reference.DrawContent("UNITY_MATRIX_MV", "模型视图变换矩阵(mul(UNITY_MATRIX_V, UNITY_MATRIX_M)):通常用于把矢量从模型空间变换到相机空间");
                _reference.DrawContent("UNITY_MATRIX_T_MV", "模型视图变换转置矩阵(transpose(UNITY_MATRIX_MV)):模型视图矩阵的转置式");
                _reference.DrawContent("UNITY_MATRIX_IT_MV", "模型视图变换转置逆矩阵(transpose(mul(UNITY_MATRIX_I_M, UNITY_MATRIX_I_V))):把法线从模型空间变换到相机空间");
                _reference.DrawContent("UNITY_MATRIX_MVP", "模型视图投影变换矩阵(mul(UNITY_MATRIX_VP, UNITY_MATRIX_M)):通常用于把矢量从模型空间变换到裁剪空间");
            }
        }

        public void DrawTitleSpaceTransformationFunction()
        {
            _reference.DrawTitle("空间变换(方法)");
        }

        public void DrawContentSpaceTransformationFunction(bool isFold)
        {
            if (isFold)
            {
                _reference.DrawContent("float3 TransformObjectToWorld(float3 positionOS)", "模型空间>>世界空间");
                _reference.DrawContent("float3 TransformWorldToObject(float3 positionWS)", "世界空间>>模型空间");
                _reference.DrawContent("float3 TransformWorldToView(float3 positionWS)", "世界空间>>视图空间");
                _reference.DrawContent("float4 TransformObjectToHClip(float3 positionOS)", "模型空间>>齐次裁剪空间 (比MVP高效)");
                _reference.DrawContent("float4 TransformWorldToHClip(float3 positionWS)", "世界空间>>齐次裁剪空间");
                _reference.DrawContent("float4 TransformWViewToHClip(float3 positionVS)", "视图空间>>齐次裁剪空间");
                _reference.DrawContent("real3 TransformObjectToWorldDir(real3 dirOS)", "(向量)模型空间>>世界空间");
                _reference.DrawContent("real3 TransformWorldToObjectDir(real3 dirWS)", "(向量)世界空间>>模型空间");
                _reference.DrawContent("real3 TransformWorldToViewDir(real3 dirWS)", "(向量)世界空间>>视图空间");
                _reference.DrawContent("real3 TransformWorldToHClipDir(real3 directionWS)", "(向量)世界空间>齐次裁剪空间");
                _reference.DrawContent("float3 TransformObjectToWorldNormal(float3 normalOS)", "(法线)模型空间>>世界空间(已归一化)");
                _reference.DrawContent("float3 TransformWorldToObjectNormal(float3 normalWS)", "(法线)世界空间>>模型空间(已归一化)");
            }
        }

        public void DrawTitleBaseTransformationMatrix()
        {
            _reference.DrawTitle("基础变换矩阵");
        }

        public void DrawContentBaseTransformationMatrix(bool isFold)
        {
            if (isFold)
            {
                _reference.DrawContent("平移矩阵", "float4x4 M_translate = float4x4(\n" +
                                              "\t1, 0, 0, T.x,\n" +
                                              "\t0, 1, 0, T.y,\n" +
                                              "\t0, 0, 1, T.z,\n" +
                                              "\t0, 0, 0, 1);");

                _reference.DrawContent("缩放矩阵", "float4x4 M_scale = float4x4(\n" +
                                              "\tS.x, 0, 0, 0,\n" +
                                              "\t0, S.y, 0, 0,\n" +
                                              "\t0, 0, S.z, 0,\n" +
                                              "\t0, 0, 0, 1);");

                _reference.DrawContent("旋转矩阵(X轴)", "float4x4 M_rotationX = float4x4(\n" +
                                                  "\t1, 0, 0, 0,\n" +
                                                  "\t0, cos(θ), -sin(θ), 0,\n" +
                                                  "\t0, sin(θ), cos(θ), 0,\n" +
                                                  "\t0, 0, 0, 1);");

                _reference.DrawContent("旋转矩阵(Y轴)", "float4x4 M_rotationY = float4x4(\n" +
                                                  "\tcos(θ), 0, sin(θ), 0,\n" +
                                                  "\t0, 1, 0, 0,\n" +
                                                  "\t-sin(θ), 0, cos(θ), 0,\n" +
                                                  "\t0, 0, 0, 1);");

                _reference.DrawContent("旋转矩阵(Z轴)", "float4x4 M_rotationZ = float4x4(\n" +
                                                  "\tcos(θ), -sin(θ), 0, 0,\n" +
                                                  "\tsin(θ), cos(θ), 0, 0,\n" +
                                                  "\t0, 0, 1, 0,\n" +
                                                  "\t0, 0, 0, 1);");
                _reference.DrawContent("旋转矩阵(任意轴)","float3 Unity_RotateAboutAxis_Radians_float(float3 In, float3 Axis, float Rotation)\n" +
                                                   "{\n    " +
                                                   "\tfloat s = sin(Rotation);\n    " +
                                                   "\tfloat c = cos(Rotation);\n    " +
                                                   "\tfloat one_minus_c = 1.0 - c;\n    " +
                                                   "\tAxis = normalize(Axis);\n    " +
                                                   "\tfloat3x3 rot_mat =\n" +
                                                   "\t{\n            " +
                                                   "one_minus_c * Axis.x * Axis.x + c, one_minus_c * Axis.x * Axis.y - Axis.z * s, one_minus_c * Axis.z * Axis.x + Axis.y * s,\n            " +
                                                   "one_minus_c * Axis.x * Axis.y + Axis.z * s, one_minus_c * Axis.y * Axis.y + c, one_minus_c * Axis.y * Axis.z - Axis.x * s,\n            " +
                                                   "one_minus_c * Axis.z * Axis.x - Axis.y * s, one_minus_c * Axis.y * Axis.z + Axis.x * s, one_minus_c * Axis.z * Axis.z + c \n" +
                                                   "\t};\n    " +
                                                   "return  mul(rot_mat,  In);\n" +
                                                   "}");
            }
        }

        public void DrawTitleTransformationRules()
        {
            _reference.DrawTitle("变换规则");
        }

        public void DrawContentTransformationRules()
        {
            _reference.DrawContent("将P点从A空间变换到B空间", 
                "P_B = M_AB * P_A\n" +
                "       = (M_BA)^-1 * P_A\n" +
                "       = (M_BA)^T * P_A)");
        }

        
    }
}

