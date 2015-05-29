/* TODO changes
 screenshots with text!
сниппеты
method searching
JL Marker. регистрировать объекты по названию в глобальных переменных
удалены отладочные сообщения и всплывающие подсказки
*/
using System;
using System.IO;
using JustLogic.Core;
using JustLogic.Editor.JLGUI;
using JustLogic.Editor.JLGUI.Drawers;
using UnityEditor;
using UnityEngine;
using System.Linq;

namespace JustLogic.Editor
{
    public class UnitsGeneratorWindow : EditorWindow
    {
        [MenuItem("Window/Just Logic Units Generator")]
        public static void Open()
        {
            var w = GetWindow<UnitsGeneratorWindow>();
            w.Show();
            w.Focus();
            w.minSize = new Vector2(400, 600);
        }

        public string Prefix = "JL";
        public bool HideExpressions = true;
        public string MenuRoot = string.Empty;
        public string Path = string.Empty;
        public string MenuSuffix = string.Empty;
        public string FriendlyNamePrefix = string.Empty;
        public string TypeName;
        public bool IncludeBaseTypes;
        public string[] IgnoreParameterTypes;
        public bool CleanDirectory;

        IParameterDrawer _typeDrawer;
        IParameterDrawer _ignoreTypesDrawer;
        DrawContext _drawContext;

        static void ResetFocus()
        {
            GUI.SetNextControlName("FocusMe()*0ri20jr");
            GUI.Label(new Rect(), "");
            GUI.FocusControl("FocusMe()*0ri20jr");
        }

        protected void OnGUI()
        {
            if (_drawContext == null)
            {
                if (string.IsNullOrEmpty(Path))
                    Path = Application.dataPath;
                if (TypeName == null)
                    TypeName = string.Empty;
                _drawContext = new DrawContext();
                _typeDrawer = ParameterDrawersFactory.Default.CreateDrawer(new DrawerInitArgs(typeof(string), drawerType: typeof(TypeDrawer)), TypeName, _drawContext);
                _ignoreTypesDrawer = ParameterDrawersFactory.Default.CreateDrawer(new DrawerInitArgs(typeof(string[]), drawerType: typeof(TypeDrawer)), _ignoreTypesDrawer, _drawContext);
            }
            _drawContext.Reset();
            _drawContext.BeginLook(false);
            Prefix = EditorGUILayout.TextField("Prefix", Prefix);
            HideExpressions = EditorGUILayout.Toggle("Hide Expressions", HideExpressions);
            MenuRoot = EditorGUILayout.TextField("Menu Root", MenuRoot);
            MenuSuffix = EditorGUILayout.TextField("Menu Suffix", MenuSuffix);
            FriendlyNamePrefix = EditorGUILayout.TextField("Friendly Name Prefix", FriendlyNamePrefix);
            GUILayout.BeginHorizontal();
            Path = EditorGUILayout.TextField("Path", Path);
            if (GUILayout.Button("...", GUILayout.Width(50f)))
            {
                Path = EditorUtility.OpenFilePanel("Select any file in directory", Path, "");
                Path = new FileInfo(Path).DirectoryName;
                ResetFocus();
            }
            GUILayout.EndHorizontal();
            CleanDirectory = EditorGUILayout.Toggle("Clean Directory", CleanDirectory);
            if (_typeDrawer.SimpleDraw(_drawContext))
                TypeName = (string)_typeDrawer.Value;
            GUILayout.Space(10f);
            IncludeBaseTypes = EditorGUILayout.Toggle("Include base types", IncludeBaseTypes);

            GUILayout.BeginVertical(StylesCache.box);
            GUILayout.Label("Ignore with parameter types:");
            if (_ignoreTypesDrawer.SimpleDraw(_drawContext))
                IgnoreParameterTypes = (string[])_ignoreTypesDrawer.Value;
            GUILayout.EndVertical();

            if (GUILayout.Button("Generate"))
            {
                if (CleanDirectory)
                {
                    foreach (var file in Directory.GetFiles(Path))
                    {
                        if (file.EndsWith(".cs", StringComparison.OrdinalIgnoreCase))
                            File.Delete(file);
                    }
                    AssetDatabase.Refresh();
                }
                new UnitsGenerator(Prefix, HideExpressions, MenuRoot, Path, MenuSuffix, FriendlyNamePrefix,
                    IgnoreParameterTypes.Select(t => Library.FindType(t).Type).ToArray(), IncludeBaseTypes)
                        .Generate(Library.FindType(TypeName));
                AssetDatabase.Refresh();
            }
        }
    }
}