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