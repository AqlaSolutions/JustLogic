/*
	
	This file is a part of JustLogic product which is distributed under 
	the BSD 3-clause "New" or "Revised" License
	
	Copyright (c) 2015. All rights reserved. 
	Authors: Vladyslav Taranov.
	
	Redistribution and use in source and binary forms, with or without
	modification, are permitted provided that the following conditions are met:
	
	* Redistributions of source code must retain the above copyright notice, this
	  list of conditions and the following disclaimer.
	
	* Redistributions in binary form must reproduce the above copyright notice,
	  this list of conditions and the following disclaimer in the documentation
	  and/or other materials provided with the distribution.
	
	* Neither the name of JustLogic nor the names of its
	  contributors may be used to endorse or promote products derived from
	  this software without specific prior written permission.
	
	THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
	AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
	IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
	DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE
	FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
	DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
	SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
	CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
	OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
	OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

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