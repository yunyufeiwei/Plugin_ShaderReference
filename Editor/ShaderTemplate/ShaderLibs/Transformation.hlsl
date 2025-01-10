#ifndef TRANSFORMATION_INCLUDE   
#define TRANSFORMATION_INCLUDE

float4 Unity_TranslateAboutAxis_float4(float4 In , float4 Axis)
{
    float4x4 rot_mat =float4x4
    {
        1,0,0,Axis.x,
        0,1,0,Axis.y,
        0,0,1,Axis.z,
        0,0,0,1
    };
    return mul(rot_mat , In);
}

float3 Unity_RotateAboutAxis_Radians_float(float3 In, float3 Axis, float Rotation)
{
    float s = sin(Rotation);
    float c = cos(Rotation);
    float one_minus_c = 1.0 - c;
            
    Axis = normalize(Axis);
    float3x3 rot_mat =
    {   one_minus_c * Axis.x * Axis.x + c, one_minus_c * Axis.x * Axis.y - Axis.z * s, one_minus_c * Axis.z * Axis.x + Axis.y * s,
        one_minus_c * Axis.x * Axis.y + Axis.z * s, one_minus_c * Axis.y * Axis.y + c, one_minus_c * Axis.y * Axis.z - Axis.x * s,
        one_minus_c * Axis.z * Axis.x - Axis.y * s, one_minus_c * Axis.y * Axis.z + Axis.x * s, one_minus_c * Axis.z * Axis.z + c
    };
    return  mul(rot_mat,  In);
}
float3 Unity_RotateAboutAxis_Degrees_float(float3 In, float3 Axis, float Rotation)
{
    Rotation = radians(Rotation);
    float s = sin(Rotation);
    float c = cos(Rotation);
    float one_minus_c = 1.0 - c;

    Axis = normalize(Axis);
    float3x3 rot_mat =
    {   one_minus_c * Axis.x * Axis.x + c, one_minus_c * Axis.x * Axis.y - Axis.z * s, one_minus_c * Axis.z * Axis.x + Axis.y * s,
        one_minus_c * Axis.x * Axis.y + Axis.z * s, one_minus_c * Axis.y * Axis.y + c, one_minus_c * Axis.y * Axis.z - Axis.x * s,
        one_minus_c * Axis.z * Axis.x - Axis.y * s, one_minus_c * Axis.y * Axis.z + Axis.x * s, one_minus_c * Axis.z * Axis.z + c
    };
    return mul(rot_mat,  In);
}

float4 Unity_ScaleAboutAxis_float4(float4 In, float4 ScaleValue)
{
    float4x4 mat_Scale=float4x4
        (
             ScaleValue.x , 0 , 0 ,0,
             0 , ScaleValue.y , 0 ,0,
             0 , 0 , ScaleValue.z , 0,
             0 , 0 , 0 , 1
         );
    return mul(mat_Scale,In);  
}

#endif  