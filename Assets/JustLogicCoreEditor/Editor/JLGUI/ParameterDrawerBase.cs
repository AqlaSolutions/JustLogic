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

namespace JustLogic.Editor.JLGUI
{
    public abstract class ParameterDrawerBase : IParameterDrawer
    {
        public virtual GUIContent Label { get; set; }
        public virtual object Value { get; protected set; }

        ParameterDrawerLayout _layout = ParameterDrawerLayout.VerticalRoot;
        public virtual ParameterDrawerLayout Layout { get { return _layout; } protected set { _layout = value; } }

        public virtual ParameterDrawerLayout SelfLayout { get { return Layout; } protected set { Layout = value; } }

        private bool _expanded = true;
        protected virtual bool Expanded { get { return _expanded; } set { _expanded = value; } }


        static GUIStyle _foldoutStyle;
        static GUIStyle _foldoutStyleOn;

        static bool _isStaticInited;

        protected ParameterDrawerBase()
        {
            if (!_isStaticInited)
            {
                _foldoutStyle = new GUIStyle(StylesCache.foldout) { fixedWidth = 15f };
                _foldoutStyleOn = new GUIStyle(_foldoutStyle) { normal = _foldoutStyle.onNormal, active = _foldoutStyle.onActive };
                _isStaticInited = true;
            }
        }

        public virtual void UpdateLayoutType(int parentsFromHorizontalStart, IDrawContext context, out int horizontalChildren, out int maxDepth, out bool isTuple)
        {
            horizontalChildren = 0;
            maxDepth = 0;
            isTuple = false;
        }

        static readonly GUIContent EmptyContent = new GUIContent();


        /// <summary>
        /// Override to draw before, after or replace with custom implementation
        /// </summary>
        protected virtual void DrawLabel(GUIContent label, bool isAppendedToHorizontal, ref bool hasVerticalOutline, IDrawContext context)
        {
            bool expanded = Expanded;
            bool canBeHidden = hasVerticalOutline;
            if (!isAppendedToHorizontal && (canBeHidden || (label != null && (!string.IsNullOrEmpty(label.text) || label.image))))
            {
                context.BeginEnabled(canBeHidden);
                try
                {
                    GUIStyle style = (expanded && canBeHidden) ? _foldoutStyleOn : _foldoutStyle;
                    float prevWidth = style.fixedWidth;
                    int prevPadding = style.padding.left;
                    GUIContent content = EmptyContent;
                    if ((label != null) && canBeHidden)
                    {
                        content = label;
                        style.fixedWidth += StylesCache.label.CalcSize(content).x + 7;
                        style.padding.left += 7;
                    }
                    try
                    {
                        if (GUILayout.Button(content, style))
                            Expanded = !expanded;
                    }
                    finally
                    {
                        style.fixedWidth = prevWidth;
                        style.padding.left = prevPadding;
                    }
                }
                finally { context.EndEnabled(); }
            }
            else if (!isAppendedToHorizontal) GUILayout.Space(8f);

            if ((label != null) && !canBeHidden)
                GUILayout.Label(label, GUILayout.ExpandWidth(false));

            if (!canBeHidden && !expanded)
                Expanded = true;
        }

        IDrawContext _currentContext;

        public const float PrefixLabelWidth = 150f;

        public bool Draw(IDrawContext context)
        {
            int endedHorizontalAreas = 0;
            int startedAreas = 0;
            _currentContext = context;
            bool prevGuiChanged = GUI.changed;
            GUI.changed = false;
            try
            {
                var hzLimited = (Layout == ParameterDrawerLayout.HorizontalLimited);
                if ((Layout == ParameterDrawerLayout.Horizontal) || hzLimited)
                {
                    bool outline = false;
                    if (!context.IsHorizontal)
                    {
                        // начинаем рисовать горизонтально
                        // если не продолжаем
                        context.BeginHorizontalArea();
                        startedAreas++;

                        if (!InitArgs.NoHeader)
                        {
                            if (hzLimited)
                            {
                                context.BeginHorizontalArea(GUILayout.Width(PrefixLabelWidth), GUILayout.MinWidth(PrefixLabelWidth), GUILayout.MaxWidth(PrefixLabelWidth), GUILayout.ExpandWidth(false));
                            }
                            try
                            {
                                DrawLabel(Label, startedAreas == 0, ref outline, context);
                            }
                            finally { if (hzLimited) context.EndArea(); }
                        }
                    }
                    else if (!InitArgs.NoHeader) DrawLabel(Label, startedAreas == 0, ref outline, context);
                }
                else
                {
                    bool needsOutline = false;

                    bool wasHorizontal = context.IsHorizontal;
                    if (!InitArgs.NoHeader)
                    {
                        if (!wasHorizontal)
                            context.BeginHorizontalArea();
                        try
                        {
                            DrawLabel(Label, wasHorizontal, ref needsOutline, context);
                        }
                        finally
                        {
                            if (!wasHorizontal)
                                context.EndArea();
                        }
                    }

                    if (Layout == ParameterDrawerLayout.VerticalRoot)
                    {
                        // закрываем горизонтальные
                        // если есть
                        // пока не дойдем до контейнера
                        if (wasHorizontal)
                            endedHorizontalAreas = context.EndAreasHorizontal();

                        if (needsOutline && Expanded)
                        {
                            context.BeginVerticalArea(true);
                            startedAreas++;
                        }
                    }
                    else if (Layout == ParameterDrawerLayout.VerticalNested)
                    {
                        if (wasHorizontal)
                        {
                            context.BeginVerticalArea(false);
                            startedAreas++;
                        }
                        if (needsOutline && Expanded)
                        {
                            context.BeginVerticalArea(true);
                            startedAreas++;
                        }
                    }
                }
                //return (Expanded && OnDraw(context, startedAreas != 0)) || GUI.changed;
                bool drawChanged = false;
                if ((Expanded && (drawChanged = OnDraw(context, startedAreas != 0))))
                {
#if DEBUG
                    Debug.Log("changed " + this + ", draw changed " + drawChanged);
#endif
                    return true;
                }
                return false;
            }
            catch (ArgumentException e)
            {
                if (!e.Message.StartsWith("Getting control ") && !e.Message.StartsWith("GUILayout: Mismatched LayoutGroup.Repaint"))
                    throw;

                context.ScheduleRepaint();

                return true;
            }
            finally
            {
                while (--startedAreas >= 0)
                    try
                    {
                        context.EndArea();
                    }
                    catch { }

                if (endedHorizontalAreas != 0)
                    try
                    {
                        context.BeginHorizontalAreas(endedHorizontalAreas);
                    }
                    catch { }
                _currentContext = null;
                if (!GUI.changed)
                    GUI.changed = prevGuiChanged;
            }
        }

        protected void BeginHorizontal(params GUILayoutOption[] options)
        {
            _currentContext.BeginHorizontalArea(options);
        }

        protected void EndHorizontal()
        {
            _currentContext.EndArea();
        }

        protected void BeginVertical(params GUILayoutOption[] options)
        {
            _currentContext.BeginVerticalArea(options);
        }

        protected void BeginVertical(GUIStyle boxStyle, params GUILayoutOption[] options)
        {
            if (boxStyle != StylesCache.box)
                throw new ArgumentException("Need to be equal tp StylesCache.box", "boxStyle");
            _currentContext.BeginVerticalArea(true, options);
        }

        protected void EndVertical()
        {
            _currentContext.EndArea();
        }

        protected void EndArea()
        {
            _currentContext.EndArea();
        }

        protected void PrefixLabel(string label)
        {
            GUILayout.Label(label);
        }

        protected void PrefixLabel(string label, bool bold)
        {
            if (bold)
                GUILayout.Label(label, StylesCache.boldLabel);
            else
                PrefixLabel(label);
        }

        public DrawerInitArgs InitArgs { get; private set; }

        public virtual bool Initialize(DrawerInitArgs args, object value, IDrawContext context)
        {
            Label = args.Label;
            Value = value;
            InitArgs = args;
            return true;
        }

        protected abstract bool OnDraw(IDrawContext context, bool isNewAreaStarted);

        bool _disposed;

        public virtual void Dispose()
        {
            if (_disposed) throw new ObjectDisposedException(GetType().Name);
            _disposed = true;
        }
    }
}