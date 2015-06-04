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
  
using System.Collections.Generic;
using JustLogic.Core;
using UnityEditor;
using UnityEngine;

namespace JustLogic.Editor.JLGUI.Drawers
{
    [ParameterDrawer(typeof(JLAction), Order = int.MaxValue)]
    public class ActionDrawer : UnitDrawerBase
    {
        static GUIStyle _toggleStyle;
        static GUIStyle _toggleStyleOn;
        static bool _isStaticInited;

        public ActionDrawer()
        {
            if (!_isStaticInited)
            {
                _toggleStyle = new GUIStyle(StylesCache.toggle) { fixedWidth = 15f };
                _toggleStyle.margin.top += 1;
                _toggleStyleOn = new GUIStyle(_toggleStyle) { normal = _toggleStyle.onNormal };
                _isStaticInited = true;
            }
        }

        protected override void GetUnits(out IList<TypeInfo> units, out object cacheKey)
        {
            units = DrawersLibrary.GetActions(InitArgs.SupportedType);
            cacheKey = InitArgs.SupportedType;
        }

        bool _changed;

        protected override void DrawLabel(GUIContent label, bool isAppendedToHorizontal, ref bool hasVerticalOutline, IDrawContext context)
        {
            if (GUILayout.Button(" ", (!Unit || Unit.On) ? _toggleStyleOn : _toggleStyle) && Unit)
            {
                Unit.On = !Unit.On;
                _changed = true;
            }
            base.DrawLabel(label, isAppendedToHorizontal, ref hasVerticalOutline, context);
        }

        protected override bool OnDraw(IDrawContext context, bool isNewAreaStarted)
        {
            bool changed = _changed;
            _changed = false;
            return base.OnDraw(context, isNewAreaStarted) || changed;
        }

        public override object Value { get { return base.Value; } protected set { Unit = (JLAction)value; } }

        public new JLAction Unit { get { return (JLAction)base.Value; } protected set { base.Value = value; } }

    }
}