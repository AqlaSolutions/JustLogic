using JustLogic.Core;
using UnityEditor;
using UnityEngine;

namespace JustLogic.Editor
{
    public class EditorCommands
    {
#if !JUSTLOGIC_FREE

        [MenuItem("Assets/Create/Just Logic Script")]
        public static void CreateJustLogicScriptAsset(MenuCommand cmd)
        {
            var asset = JLScriptableHelper.CreateNew<JLCustomScriptAssetBase>();
            AssetDatabase.CreateAsset(asset, GetUniqueAssetPathNameOrFallback("JLScript.asset"));
            Selection.activeObject = asset;
        }

        [MenuItem("Assets/Create/Just Logic Expression")]
        public static void CreateJustLogicExpressionAsset(MenuCommand cmd)
        {
            var asset = JLScriptableHelper.CreateNew<JLCustomExpressionAssetBase>();
            AssetDatabase.CreateAsset(asset, GetUniqueAssetPathNameOrFallback("JLExpression.asset"));
            Selection.activeObject = asset;
        }

        public static string GetUniqueAssetPathNameOrFallback(string filename)
        {
            string path;
            try
            {
                // Private implementation of a filenaming function which puts the file at the selected path.
                System.Type assetdatabase = typeof(AssetDatabase);
                path = (string)assetdatabase.GetMethod("GetUniquePathNameAtSelectedPath", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static).Invoke(assetdatabase, new object[] { filename });
            }
            catch
            {
                // Protection against implementation changes.
                path = AssetDatabase.GenerateUniqueAssetPath("Assets/" + filename);
            }
            return path;
        }
#endif

    }
}