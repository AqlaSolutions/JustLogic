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
using System.Linq;
using JustLogic.Core;
using UnityEditor;
using UnityEngine;

namespace JustLogic.Editor.JLGUI.Drawers
{
    [ParameterDrawer(typeof(SelectedVariableInfoBase))]
    public class VariableDrawer : ParameterDrawerBase
    {
        public override bool Initialize(DrawerInitArgs args, object value, IDrawContext context)
        {
            Layout = ParameterDrawerLayout.VerticalRoot;
            return base.Initialize(args, value, context);
        }

        protected override void DrawLabel(GUIContent label, bool isAppendedToHorizontal, ref bool hasVerticalOutline, IDrawContext context)
        {
            hasVerticalOutline = true;
            base.DrawLabel(new GUIContent("Variable"), isAppendedToHorizontal, ref hasVerticalOutline, context);
        }

        protected override bool OnDraw(IDrawContext context, bool isNewAreaStarted)
        {
            bool changed = false;
            var value = (SelectedVariableInfoBase)Value ?? Library.Instantiator.CreateSelectedVariableInfoBase();
            changed = DrawVariableSelector(Label != null ? Label.text : string.Empty, value, v => Value = v, context);
            return changed;
        }

        public class VariableSelectorData
        {
            public string AddText;
            public Vector2 ScrollPosition;
        }

        readonly VariableSelectorData _data = new VariableSelectorData();

        public bool DrawVariableSelector(string label, SelectedVariableInfoBase variable, Action<SelectedVariableInfoBase> setter, IDrawContext context)
        {
            bool changed = false;

            bool global = (variable.Scope == SelectedVariableInfoBase.VariableScope.Global);
            var describerNotSet = context.CurrentVariablesDescriber == null;
            if (global || describerNotSet)
            {
                BeginHorizontal();
                PrefixLabel(label);
                context.BeginLook(true);
                context.SetCheckChanged(ref changed, () => variable.Name = EditorGUILayout.TextField(variable.Name));
                context.EndLook();
                EndHorizontal();
                if (DrawVariableGlobalToggle(variable, global))
                    changed = true;
                if (variable.Scope == SelectedVariableInfoBase.VariableScope.Global) return changed;
            }

            if (describerNotSet)
            {
                context.SetCheckChanged(ref changed, () => variable.IsStatic = EditorGUILayout.Toggle("Static", variable.IsStatic));
                return changed;
            }


            BeginHorizontal();

            string name = variable.Name;
            if (string.IsNullOrEmpty(name))
                name = "<select>";
            else if (variable.IsStatic) name = "[" + name + "]";

            PrefixLabel(label ?? "Variable");
            context.BeginLook(true);
            if (GUILayout.Button(name, StylesCache.popup))
            {
                _data.AddText = _data.AddText == null ? string.Empty : null;
                ResetFocus();
            }
            context.EndLook();
            EndHorizontal();
            if (_data.AddText != null)
            {
                BeginVertical(StylesCache.box);
                BeginHorizontal();
                GUILayout.Label("Add: ");
                context.BeginLook(true);
                string addText = _data.AddText = EditorGUILayout.TextField(_data.AddText).Trim();
                context.EndLook();
                if (GUILayout.Button("Local") && (addText.Length != 0) && context.CurrentVariablesDescriber.CtorVariables.All(el => el.VariableName != addText))
                {
                    var vars = context.CurrentVariablesDescriber.CtorVariables;
                    ArrayUtility.Add(ref vars, new EditorVariableInfoBase() { VariableName = addText });
                    context.CurrentVariablesDescriber.CtorVariables = vars;
                    changed = true;
                }
                if (GUILayout.Button("Static") && (addText.Length != 0) && context.CurrentVariablesDescriber.CtorStaticVariables.All(el => el.VariableName != addText))
                {
                    var vars = context.CurrentVariablesDescriber.CtorStaticVariables;
                    ArrayUtility.Add(ref vars, new EditorVariableInfoBase() { VariableName = addText });
                    context.CurrentVariablesDescriber.CtorStaticVariables = vars;
                    changed = true;
                }
                EndHorizontal();
                try
                {
                    _data.ScrollPosition = GUILayout.BeginScrollView(_data.ScrollPosition, GUILayout.Height(200f));
                }
                catch { }
                var btnStyle = new GUIStyle(StylesCache.button) { alignment = TextAnchor.MiddleLeft, normal = { background = null } };
                var btnPressedStyle = new GUIStyle(btnStyle);
                btnPressedStyle.normal = btnPressedStyle.active;
                {
                    var vars = context.CurrentVariablesDescriber.CtorVariables;
                    if (DrawVariablesList(variable, ref vars, false, btnStyle, btnPressedStyle))
                        changed = true;
                    context.CurrentVariablesDescriber.CtorVariables = vars;
                }
                {
                    var vars = context.CurrentVariablesDescriber.CtorStaticVariables;
                    if (DrawVariablesList(variable, ref vars, true, btnStyle, btnPressedStyle))
                        changed = true;
                    context.CurrentVariablesDescriber.CtorStaticVariables = vars;
                }
                try
                {
                    GUILayout.EndScrollView();
                }
                catch { }
                EndVertical();
                if (changed) setter(variable);
                return changed;
            }
            if (DrawVariableGlobalToggle(variable, false))
                changed = true;
            if (changed) setter(variable);
            return changed;
        }

        private bool DrawVariableGlobalToggle(SelectedVariableInfoBase variable, bool global)
        {
            bool newGlobal = EditorGUILayout.Toggle("Is global", global);
            if (newGlobal != global)
            {
                ResetFocus();
                variable.Name = string.Empty;
                variable.Scope = newGlobal ? SelectedVariableInfoBase.VariableScope.Global : SelectedVariableInfoBase.VariableScope.Local;
                return true;
            }
            return false;
        }

        private bool DrawVariablesList(SelectedVariableInfoBase variable, ref EditorVariableInfoBase[] variables, bool isStatic, GUIStyle btnStyle, GUIStyle btnPressedStyle)
        {
            bool changed = false;
            int removeAt = -1;
            for (int i = 0; i < variables.Length; i++)
            {
                var variableInfo = variables[i];
                var style = ((variable.IsStatic == isStatic) && variable.Name == variableInfo.VariableName) ? btnPressedStyle : btnStyle;

                BeginHorizontal();
                if (GUILayout.Button((isStatic ? "[" : string.Empty) + variableInfo.VariableName + (isStatic ? "]" : string.Empty), style))
                {
                    variable.IsStatic = isStatic;
                    variable.Name = variableInfo.VariableName;
                    changed = true;
                }
                if (GUILayout.Button("-", GUILayout.Width(20f)))
                    removeAt = i;
                EndHorizontal();
            }
            if (removeAt != -1)
            {
                changed = true;
                var vars = variables;
                if ((variable.IsStatic == isStatic) && (vars[removeAt].VariableName == variable.Name))
                    variable.Name = string.Empty;
                ArrayUtility.RemoveAt(ref vars, removeAt);
                variables = vars;
            }
            return changed;
        }

        static void ResetFocus()
        {
            GUI.SetNextControlName("FocusMe()*0ri20jr");
            GUI.Label(new Rect(), "");
            GUI.FocusControl("FocusMe()*0ri20jr");
        }
    }
}