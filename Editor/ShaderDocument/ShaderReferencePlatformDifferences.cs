using UnityEditor;

namespace yuxuetian
{
    public class ShaderReferencePlatformDifferences : EditorWindow
    {
        private ShaderReferenceUtil _reference = new ShaderReferenceUtil();

        public void DrawTitlePlatformDifferenceHcsSpace()
        {
            _reference.DrawTitle("裁剪空间(规范化立方体)");
        }

        public void DrawContentPlatformDifferenceHcsSpace()
        {
            _reference.DrawContent("OpenGL", "裁剪空间下坐标范围(-1,1)");
            _reference.DrawContent("DirectX", "裁剪空间下坐标范围(1,0)");
            _reference.DrawContent("UNITY_NEAR_CLIP_VALUE", "裁剪空间下的近剪裁值,(DX为1,OpenGL为-1).");
        }

        public void DrawTitlePlatformDifferenceReversedZ()
        {
            _reference.DrawTitle("ReversedZ");
        }

        public void DrawContentPlatformDifferenceReversedZ()
        {
            _reference.DrawContent("Reversed direction(反向方向)", "DirectX 11、DirectX 12、PS4、Xbox One、Metal这些平台都属于反向方向.\n" +
                                      "深度值从近裁剪面到远裁剪面的值为[1 ~ 0]\n" +
                                      "裁剪空间下的Z轴范围为[near,0]");
            _reference.DrawContent("Traditional direction(传统方向)", "除以上反向方向的平台以外都属于传统方向.\n" +
                                     "深度值从近裁剪面到远裁剪面的值为[0 ~ 1]\n" +
                                     "裁剪空间下的Z轴范围为:\n" +
                                     "DX平台=[0,far]\n" +
                                     "OpenGL平台=[-near,far]");
            _reference.DrawContent("UNITY_REVERSED_Z", "判断当前平台是否开启ReversedZ");
            _reference.DrawContent("SystemInfo.usesReversedZBuffer", "利用C#判断当前平台是否支持ReversedZ");
        }
    }
}
