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
using JustLogic.Core;
using UnityEditor;
using UnityEngine;
using System.Linq;

namespace JustLogic.Editor.JLGUI.Drawers
{
    [ParameterDrawer(typeof(String))]
    public class StringDrawer : ParameterDrawerBase
    {
        public override void UpdateLayoutType(int parentsFromHorizontalStart, IDrawContext context, out int horizontalChildren, out int maxDepth, out bool isTuple)
        {
            base.UpdateLayoutType(parentsFromHorizontalStart, context, out horizontalChildren, out maxDepth, out isTuple);
            var value = (string)Value ?? string.Empty;
            bool hasLineEnds = value.Contains("\n");
            bool expanded = _expanded || hasLineEnds;
            Layout = expanded ? ParameterDrawerLayout.VerticalRoot : ParameterDrawerLayout.HorizontalLimited;
        }

        public override ParameterDrawerLayout SelfLayout { get { return ParameterDrawerLayout.HorizontalLimited; } protected set { } }

        protected override void DrawLabel(GUIContent label, bool isAppendedToHorizontal, ref bool hasVerticalOutline, IDrawContext context)
        {
            base.DrawLabel(label, isAppendedToHorizontal, ref hasVerticalOutline, context);
            var value = (string)Value ?? string.Empty;
            bool hasLineEnds = value.Contains("\n");
            bool expanded = _expanded || hasLineEnds;
            if (expanded)
            {
                GUILayout.FlexibleSpace();

                context.BeginEnabled(!hasLineEnds);
                if (GUILayout.Button("↑", GUILayout.Width(20f)) && !hasLineEnds)
                    _expanded = false;
                context.EndEnabled();
            }
        }

        bool _expanded;

        protected override bool OnDraw(IDrawContext context, bool isNewAreaStarted)
        {
            var value = (string)Value ?? string.Empty;
            bool hasLineEnds = value.Contains("\n");
            bool expanded = _expanded || hasLineEnds;

            context.BeginLook(true);
            object newValue;
            try
            {
                if (expanded)
                    newValue = EditorGUILayout.TextArea(value, GUILayout.MinHeight(50f));
                else
                {
                    newValue = EditorGUILayout.TextField(value);

                    if (GUILayout.Button("↓", GUILayout.Width(20f)))
                        _expanded = true;

                }

            }
            finally
            {
                context.EndLook();
            }
            if (!newValue.Equals(value))
            {
                Value = newValue;
                return true;
            }
            return false;
        }
    }
}