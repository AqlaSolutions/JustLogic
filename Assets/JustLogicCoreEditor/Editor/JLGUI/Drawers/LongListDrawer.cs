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
using UnityEngine;

namespace JustLogic.Editor.JLGUI.Drawers
{
    public class LongListDrawer : IParameterDrawer
    {
        protected LongListSelector Selector { get; private set; }

        public LongListDrawer(LongListSelector selector)
        {
            if (selector == null) throw new ArgumentNullException("selector");
            Selector = selector;
        }

        public virtual object Value { get; protected set; }
        public ParameterDrawerLayout Layout { get { return ParameterDrawerLayout.VerticalRoot; } }
        public ParameterDrawerLayout SelfLayout { get { return ParameterDrawerLayout.VerticalRoot; } }
        public virtual string Label { get { return "Type: "; } }

        public bool Initialize(DrawerInitArgs args, object value, IDrawContext context)
        {
            if (value == null)
                value = string.Empty;
            else if (value is Type)
                value = ((Type)value).FullName;
            else if (!(value is string))
                return false;
            Value = value;
            GUIContent label = args.Label;
            if (label != null)
                Selector.PrefixLabel = !string.IsNullOrEmpty(label.text) ? label.text : Label;
            else
                Selector.PrefixLabel = Label;
            Selector.FullValue = (string)value;
            return true;
        }

        protected virtual bool DrawSelector(IDrawContext context)
        {
            return Selector.Draw(context);
        }

        public virtual bool Draw(IDrawContext context)
        {
            bool changed = DrawSelector(context);
            if (changed)
            {
                Value = Selector.FullValue;
                return true;
            }
            return false;
        }

        public void UpdateLayoutType(int parentsFromHorizontalStart, IDrawContext context, out int horizontalChildren, out int maxDepth, out bool isTuple)
        {
            horizontalChildren = 0;
            maxDepth = 0;
            isTuple = false;
        }

        public virtual void Dispose()
        {

        }
    }
}