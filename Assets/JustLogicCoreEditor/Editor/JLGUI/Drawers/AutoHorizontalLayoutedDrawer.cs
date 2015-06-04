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
    /// <summary>
    /// Если есть label, то рисуется в отдельной строке. Если label отсутствует, рисует в той же
    /// </summary>
    public abstract class AutoHorizontalLayoutedDrawer : ParameterDrawerBase
    {
        public override sealed ParameterDrawerLayout SelfLayout { get { return ParameterDrawerLayout.HorizontalLimited; } protected set { } }

        public override bool Initialize(DrawerInitArgs args, object value, IDrawContext context)
        {
            bool r = base.Initialize(args, value, context);
            if (r)
            {
                if (Label != null && string.IsNullOrEmpty(Label.text))
                    Label = null;
            }
            return r;
        }

        public override sealed void UpdateLayoutType(int parentsFromHorizontalStart, IDrawContext context, out int horizontalChildren, out int maxDepth, out bool isTuple)
        {
            base.UpdateLayoutType(parentsFromHorizontalStart, context, out horizontalChildren, out maxDepth, out isTuple);

            bool isHorizontal = Label == null || parentsFromHorizontalStart < 2;
            Layout = isHorizontal ? ParameterDrawerLayout.HorizontalLimited : ParameterDrawerLayout.VerticalRoot;
        }

        public override sealed GUIContent Label { get { return base.Label; } set { base.Label = value; } }
        public override sealed ParameterDrawerLayout Layout { get { return base.Layout; } protected set { base.Layout = value; } }

        protected override sealed void DrawLabel(GUIContent label, bool isAppendedToHorizontal, ref bool hasVerticalOutline, IDrawContext context)
        {
            //hasVerticalOutline = !_isEmptyLabel;
            base.DrawLabel(label, isAppendedToHorizontal, ref hasVerticalOutline, context);
        }

        protected override sealed bool OnDraw(IDrawContext context, bool isNewAreaStarted)
        {
            if (Layout.IsHorizontal())
                GUILayout.Space(25f);
            return OnDraw(context);
        }

        protected abstract bool OnDraw(IDrawContext context);
    }
}