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
using UnityEditor;
using UnityEngine;

namespace JustLogic.Editor.JLGUI.Drawers
{
    public class EventArgumentDrawer : ParameterDrawerBase
    {
        bool _isEmptyLabel;

        public override ParameterDrawerLayout SelfLayout { get { return ParameterDrawerLayout.HorizontalLimited; } protected set { } }

        public override bool Initialize(DrawerInitArgs args, object value, IDrawContext context)
        {
            if (!(value is int)) return false;
            var r = base.Initialize(args, value, context);
            if (r)
            {
                _isEmptyLabel = string.IsNullOrEmpty(InitArgs.Label != null ? InitArgs.Label.text : string.Empty);
                Layout = _isEmptyLabel ? ParameterDrawerLayout.HorizontalLimited : ParameterDrawerLayout.VerticalRoot;
                if (_isEmptyLabel)
                    Label = null;
            }
            return r;
        }

        protected override void DrawLabel(GUIContent label, bool isAppendedToHorizontal, ref bool hasVerticalOutline, IDrawContext context)
        {
            hasVerticalOutline = !_isEmptyLabel;
            base.DrawLabel(label, isAppendedToHorizontal, ref hasVerticalOutline, context);
        }

        protected override bool OnDraw(IDrawContext context, bool isNewAreaStarted)
        {
            int value = (int)Value;
            context.BeginLook(true);
            try
            {
                int newValue;
                if (context.CurrentEditingEvent == null)
                {
                    newValue = _isEmptyLabel
                                  ? EditorGUILayout.IntField(value)
                                  : EditorGUILayout.IntField(Label, value);
                }
                else
                    newValue = EditorGUILayout.Popup(value, 
                        context.CurrentEditingEvent.Arguments
                        .Select(a => a.Key + " (" + a.Value.Name + ")")
                        .ToArray());

                if (!newValue.Equals(value))
                {
                    Value = newValue;
                    return true;
                }
                return false;
            }
            finally { context.EndLook(); }

        }
    }
}