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
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace JustLogic.Editor.JLGUI.Drawers
{
    [ParameterDrawer(typeof(Object))]
    public class ObjectDrawer : AutoHorizontalLayoutedDrawer
    {
        bool _changed;

        protected override bool OnDraw(IDrawContext context)
        {
            Type objType = InitArgs.ExpressionType ?? InitArgs.SupportedType;
            bool changed = _changed;
            _changed = false;
            var obj = (Object)Value;
            var bg = GUI.backgroundColor;
            if (!obj)
                GUI.color = Color.red;
            Object newV = EditorGUILayout.ObjectField(obj, objType, true);
            GUI.color = bg;
            if (!ReferenceEquals(newV, obj))
            {
                Value = newV;
                changed = true;
            }
            if (newV && (typeof(Component).IsAssignableFrom(objType) || (newV is Component) || (newV is GameObject)))
            {
                GenericMenu.MenuFunction2 selectFunc =
                            v =>
                            {
                                if (!ReferenceEquals(v, obj))
                                {
                                    Value = v;
                                    _changed = true;
                                }
                            };
                var go = newV as GameObject;
                if (go == null)
                {
                    var c = newV as Component;
                    if (c) go = c.gameObject;
                }
                if (go)
                {
                    if (GUILayout.Button(new GUIContent("[*]", Value.GetType().Name), StylesCache.label, GUILayout.Width(25f)))
                    {
                        var menu = new GenericMenu();
                        if (objType.IsAssignableFrom(typeof(GameObject)))
                            menu.AddItem(new GUIContent("GameObject"), go == newV, selectFunc, go);
                        foreach (var component in go.GetComponents(objType))
                            menu.AddItem(new GUIContent(component.GetType().Name), component == obj, selectFunc, component);

                        menu.ShowAsContext();
                    }
                }
            }
            return changed;
        }
    }
}