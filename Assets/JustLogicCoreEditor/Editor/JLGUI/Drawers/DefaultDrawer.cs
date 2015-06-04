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
using System.Collections.Generic;
using UnityEngine;
using JustLogic.Core;
using System.Linq;

namespace JustLogic.Editor.JLGUI.Drawers
{
    public class DefaultDrawer : ParameterDrawerBase
    {
        IList<UnitParameter> _parameters = new UnitParameter[0];
        IList<IParameterDrawer> _drawers = new IParameterDrawer[0];

        bool _changed;

        public override bool Initialize(DrawerInitArgs args, object value, IDrawContext context)
        {
            bool r = base.Initialize(args, value, context);
            if (r)
            {
                if (value == null)
                {
                    Value = value = args.SupportedType == typeof(string) ? string.Empty : Activator.CreateInstance(args.SupportedType);
                    _changed = true;
                }

                if (!args.SupportedType.Type.IsPrimitive)
                {
                    _parameters = args.SupportedType.JustLogicParametersList;

                    _drawers = new IParameterDrawer[_parameters.Count];

                    for (int i = 0; i < _parameters.Count; i++)
                    {
                        var unitParameter = _parameters[i];
                        _drawers[i] = args.Factory.CreateDrawer(new DrawerInitArgs(
                            unitParameter.Name, this, unitParameter.Type, args.Factory,
                            args.ParameterInfo.Attributes, unitParameter, containerExpressionType: InitArgs.ExpressionType),
                            unitParameter.Getter(value), context);
                    }
                }
            }
            return r;
        }

        public override void Dispose()
        {
            foreach (var parameterDrawer in _drawers)
                if (parameterDrawer != null)
                    parameterDrawer.Dispose();
            base.Dispose();
        }

        public override void UpdateLayoutType(int parentsFromHorizontalStart, IDrawContext context, out int horizontalChildren, out int maxDepth, out bool isTuple)
        {
            horizontalChildren = 0;
            ParameterDrawerLayout layout = _drawers.Count > 1 || _parameters.Any(p => p.Type.IsArray)
                                               ? ParameterDrawerLayout.VerticalRoot
                                               : ((_drawers.Count == 0) ? ParameterDrawerLayout.Horizontal : ParameterDrawerLayout.HorizontalLimited);


            Layout = layout;

            maxDepth = 0;

            foreach (var parameterDrawer in _drawers)
            {
                if (parameterDrawer != null)
                {
                    int dummy;
                    int depth;
                    bool tuple;
                    parameterDrawer.UpdateLayoutType(layout == ParameterDrawerLayout.VerticalRoot ? 0 : (parentsFromHorizontalStart + 1), context, out dummy, out depth, out tuple);
                    maxDepth = Math.Max(depth, maxDepth);
                    if ((parameterDrawer.Layout == ParameterDrawerLayout.VerticalRoot) || (parameterDrawer.Layout == ParameterDrawerLayout.VerticalNested))
                        Layout = ParameterDrawerLayout.VerticalRoot;
                }
            }

            if (_drawers.Count != 0) maxDepth++;
            isTuple = false;
        }


        static readonly GUIContent TempContent = new GUIContent();

        protected override void DrawLabel(GUIContent label, bool isAppendedToHorizontal, ref bool hasVerticalOutline, IDrawContext context)
        {
            if (_drawers.Count != 1)
            {
                if ((label == null) || string.IsNullOrEmpty(label.text))
                {
                    label = TempContent;
                    label.text = InitArgs.SupportedType.Type.GetSimpleName();
                    label.tooltip = string.Empty;
                }
                else
                {
                    TempContent.text = label.text;
                    TempContent.tooltip = label.tooltip ?? InitArgs.SupportedType.Type.GetSimpleName();
                    label = TempContent;
                }
                hasVerticalOutline = true;
                base.DrawLabel(label, isAppendedToHorizontal, ref hasVerticalOutline, context);
            }
            else base.DrawLabel(null, isAppendedToHorizontal, ref hasVerticalOutline, context);
        }

        protected override bool OnDraw(IDrawContext context, bool isNewAreaStarted)
        {
            bool changed = _changed;
            _changed = false;

            foreach (var parameterDrawer in _drawers)
            {
                if (parameterDrawer != null)
                {
                    if (parameterDrawer.Draw(context))
                        changed = true;
                }
            }

            return changed;
        }
    }
}