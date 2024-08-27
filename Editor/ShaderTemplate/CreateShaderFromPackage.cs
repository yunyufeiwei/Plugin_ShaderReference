using System.IO;
using UnityEngine;
using UnityEditor;

public class CreateShaderFromPackage : EditorWindow
{
    private const string RootPath = "Packages/com.yuxuetian.shaderreference/Editor/ShaderTemplate/Shader/";
    [MenuItem("Assets/Create/Shader/UniversalPipeline/UnlitOpaque")]
    static void CreateUnlitOpaqueShader()
    {
        string fileName = "URP_UnlitOpaque.shader";
        string shaderPath = RootPath + fileName;
        CreatShaderByPath(shaderPath, fileName);
    }
    
    [MenuItem("Assets/Create/Shader/UniversalPipeline/UnlitTransparent")]
    static void CreateUnlitTransparentShader()
    {
        string fileName = "URP_UnlitTransparent.shader";
        string shaderPath = RootPath + fileName;
        CreatShaderByPath(shaderPath, fileName);
    }
    

    [MenuItem("Assets/Create/Shader/UniversalPipeline/LitOpaque")]
    static void CreateLitOpaqueShader()
    {
        string fileName = "URP_LitOpaque.shader";
        string shaderPath = RootPath + fileName;
        CreatShaderByPath(shaderPath, fileName);
    }

    //创建Shader
    private static void CreatShaderByPath(string shaderPath , string fileName)
    {
        string selectPath = AssetDatabase.GetAssetPath(Selection.activeObject);
        if (selectPath == null)
        {
            selectPath = "Assets/";
        }
        else if (Path.GetExtension(selectPath) != "")
        {
            selectPath = selectPath.Replace(Path.GetFileName(AssetDatabase.GetAssetPath(Selection.activeObject)), "");
        }

        string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath(selectPath + "/" + fileName);
        AssetDatabase.CopyAsset(shaderPath, assetPathAndName);
        AssetDatabase.Refresh();
    }
}
