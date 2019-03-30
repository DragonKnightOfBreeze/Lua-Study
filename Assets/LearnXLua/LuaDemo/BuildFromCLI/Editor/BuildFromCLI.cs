using CSObjectWrapEditor;
using UnityEditor;
using UnityEngine;
using XLua;

/* Reformatted and refactored by @DragonKnightOfBreeze. */

namespace LearnXLua.LuaDemo.BuildFromCLI.Editor
{
    public static class BuildFromCLI
    {
        /// <summary>
        /// 此方法通过Unity菜单调用。
        /// </summary>
        [MenuItem("XLua/Examples/13_BuildFromCLI")]
        public static void BuildFromUnityMenu()
        {
            var outputDir = Application.dataPath.Substring(0, Application.dataPath.Length - "/Assets".Length) + "/output";
            const string packageName = "xLuaGame.exe";
            build(outputDir, packageName);
        }

        /// <summary>
        /// 此方法通过命令行调用。
        /// </summary>
        public static void BuildFromCmd()
        {
            var outputDir = Application.dataPath.Substring(0, Application.dataPath.Length - "/Assets".Length) + "/output";
            const string packageName = "xLuaGame.exe";
            build(outputDir, packageName);
        }

        private static void build(string outputDir, string packageName)
        {
            Debug.Log("构建开始：输出目录 " + outputDir);
            DelegateBridge.Gen_Flag = true;
            Generator.ClearAll();
            Generator.GenAll();

            var levels = new string[0];
            var locationPathName = $"{outputDir}/{packageName}";
            const BuildTarget target = BuildTarget.StandaloneWindows64;
            const BuildOptions options = BuildOptions.None;
            BuildPipeline.BuildPlayer(levels, locationPathName, target, options);
            Debug.Log("构建完成");
        }
    }
}
