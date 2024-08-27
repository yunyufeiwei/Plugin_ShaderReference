using UnityEditor;

namespace Editor.ShaderDocument
{
    public class ShaderReferenceTransformation : EditorWindow
    {
        private ShaderReferenceUtil _reference = new ShaderReferenceUtil();

        public void DrawTitleSpaceTransformationMatrix()
        {
            _reference.DrawTitle("空间变换(矩阵)");
        }

        public void DrawContentSpaceTransformationMatrix(bool isFold)
        {
            if (isFold)
            {
                _reference.DrawContent("UNITY_MATRIX_M", "模型变换矩阵:unity_ObjectToWorld");
                _reference.DrawContent("UNITY_MATRIX_I_M", "模型变换逆矩阵:unity_WorldToObject");
                _reference.DrawContent("UNITY_MATRIX_V", "视图变换矩阵:unity_MatrixV");
                _reference.DrawContent("UNITY_MATRIX_I_V", "视图变换逆矩阵:unity_MatrixInvV");
                _reference.DrawContent("UNITY_MATRIX_P", "投影变换矩阵:OptimizeProjectionMatrix(glstate_matrix_projection)");
                _reference.DrawContent("UNITY_MATRIX_I_P", "投影变换逆矩阵:ERROR_UNITY_MATRIX_I_P_IS_NOT_DEFINED");
                _reference.DrawContent("UNITY_MATRIX_VP", "视图投影变换矩阵:unity_MatrixVP");
                _reference.DrawContent("UNITY_MATRIX_I_VP", "视图投影变换逆矩阵:_InvCameraViewProj");
                _reference.DrawContent("UNITY_MATRIX_MV", "模型视图变换矩阵:mul(UNITY_MATRIX_V, UNITY_MATRIX_M)");
                _reference.DrawContent("UNITY_MATRIX_T_MV", "模型视图变换转置矩阵:transpose(UNITY_MATRIX_MV)");
                _reference.DrawContent("UNITY_MATRIX_IT_MV", "模型视图变换转置逆矩阵:transpose(mul(UNITY_MATRIX_I_M, UNITY_MATRIX_I_V))");
                _reference.DrawContent("UNITY_MATRIX_MVP", "模型视图投影变换矩阵:mul(UNITY_MATRIX_VP, UNITY_MATRIX_M)");
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

