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

namespace JustLogic.Editor.JLGUI.Drawers
{
    [ParameterDrawer(typeof(Quaternion))]
    public class QuaternionDrawer : ParameterDrawerBase
    {
        public override bool Initialize(DrawerInitArgs args, object value, IDrawContext context)
        {
            Layout = ParameterDrawerLayout.VerticalRoot;
            return base.Initialize(args, value, context);
        }

        protected override void DrawLabel(GUIContent label, bool isAppendedToHorizontal, ref bool hasVerticalOutline, IDrawContext context)
        {
            label = null;
            base.DrawLabel(label, isAppendedToHorizontal, ref hasVerticalOutline, context);
        }

        protected override bool OnDraw(IDrawContext context, bool isNewAreaStarted)
        {
            var value = (Quaternion)Value;
            context.BeginLook(true);
            try
            {
                const string autoLabel = "Euler Angles";
                string label = InitArgs.Label != null ? InitArgs.Label.text : autoLabel;
                if (string.IsNullOrEmpty(label))
                    label = autoLabel;
                object newValue = Quaternion.Euler(EditorGUILayout.Vector3Field(label, value.eulerAngles));
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