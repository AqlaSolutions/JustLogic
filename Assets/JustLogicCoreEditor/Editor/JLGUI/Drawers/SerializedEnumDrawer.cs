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

namespace JustLogic.Editor.JLGUI.Drawers
{
    [ParameterDrawer(typeof(SerializedEnumBase))]
    public class SerializedEnumDrawer : ParameterDrawerBase
    {
        public enum EmptyEnum
        {
            None = 0
        }
        readonly LongListSelector _typeSelector = new LongListSelector(DrawersLibrary.EnumListShort, DrawersLibrary.EnumList, label: "Enum: ", filter: "UnityEngine.");

        public override bool Initialize(DrawerInitArgs args, object value, IDrawContext context)
        {
            Layout = ParameterDrawerLayout.VerticalRoot;
            return base.Initialize(args, value, context);
        }

        protected override void DrawLabel(GUIContent label, bool isAppendedToHorizontal, ref bool hasVerticalOutline, IDrawContext context)
        {
            hasVerticalOutline = !isAppendedToHorizontal && label != null;
            base.DrawLabel(label, isAppendedToHorizontal, ref hasVerticalOutline, context);
        }

        protected override bool OnDraw(IDrawContext context, bool isNewAreaStarted)
        {
            bool changed = false;
            var value = (SerializedEnumBase)Value ?? Library.Instantiator.CreateSerializedEnumBase();

            context.BeginLook(true);
            try
            {
                if (string.IsNullOrEmpty(value.TypeFullName))
                    value.TypeFullName = typeof(EmptyEnum).FullName;
                _typeSelector.CurrentValueIndex = DrawersLibrary.EnumList.IndexOf(value.TypeFullName);
                if (_typeSelector.Draw(context))
                {
                    value.TypeFullName = _typeSelector.FullValue;
                    changed = true;
                }

                var enumType = Library.FindType(value.TypeFullName);

                object newValue = Enum.ToObject(enumType, value.Value);
                if (ConcreteEnumDrawer.DrawEnum(ref newValue, enumType))
                {
                    changed = true;
                    value.Value = (int)Convert.ChangeType(Convert.ChangeType(newValue, Enum.GetUnderlyingType(enumType)), typeof(int));
                }
            }
            finally { context.EndLook(); }
            if (changed)
                Value = value;
            return changed;
        }

    }
}