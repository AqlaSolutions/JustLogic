﻿/*
	
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
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace JustLogic.Editor.JLGUI
{
    public class LongListSelector
    {
        public LongListSelector(IList<string> values, IList<string> fullValues = null, IList<string> searchValues = null, string label = "", string filter = "", bool displayCurrentFullValue = true)
        {
            if (values == null) throw new ArgumentNullException("values");
            if (label == null) throw new ArgumentNullException("label");
            if (filter == null) throw new ArgumentNullException("filter");
            if (fullValues == null) fullValues = values;
            if (searchValues == null) searchValues = values;
            PrefixLabel = label;
            _filter = filter;
            _displayCurrentFullValue = displayCurrentFullValue;
            _searchValues = searchValues;
            _fullValues = fullValues;
            _values = values;
            CurrentValueIndex = -1;
            Initialize();
            DoFilter();
        }

        void DoFilter()
        {
            if (_filter == _prevFilter) return;
            _filteredValues.Clear();
            if (_fullValues.Count != 0)
                _filteredValues.AddRange(Enumerable.Range(0, _fullValues.Count)
                                                  .Where(i1 =>
                                                         string.IsNullOrEmpty(_filter)
                                                         || _searchValues[i1].StartsWith(_filter, StringComparison.OrdinalIgnoreCase)
                                                         || _fullValues[i1].StartsWith(_filter, StringComparison.OrdinalIgnoreCase)));
            _prevFilter = _filter;
        }

        public bool Draw(IDrawContext context, string currentDisplayValue = null)
        {
            if (string.IsNullOrEmpty(currentDisplayValue))
                currentDisplayValue = _displayCurrentFullValue ? FullValue : ShortValue;
            float prefixLabelWidth = 100f;
            if (Expanded)
            {
                bool changed = false;

                DoFilter();

                if (!string.IsNullOrEmpty(PrefixLabel))
                {
                    context.BeginHorizontalArea();
                    GUILayout.Label(PrefixLabel, GUILayout.Width(prefixLabelWidth));
                }
                context.BeginLook(true);
                if (GUILayout.Button(currentDisplayValue ?? GetElementOrEmpty(CurrentValueIndex, _fullValues), StylesCache.popup))
                {
                    Expanded = !Expanded;
                    ResetFocus();
                }
                context.EndLook();
                if (!string.IsNullOrEmpty(PrefixLabel))
                    context.EndArea();

                const int lines = 10;
                float height = StylesCache.label.CalcHeight(new GUIContent("agw()bc\r\n"), 100f) * lines;
                context.BeginHorizontalArea();
                GUILayout.Label("Search: ", GUILayout.Width(50f));
                context.BeginLook(true);
                _filter = EditorGUILayout.TextField(_filter);
                context.EndLook();
                context.EndArea();

                context.BeginHorizontalArea();
                context.BeginVerticalArea(true);
                var rect = GUILayoutUtility.GetRect(new GUIContent(), StylesCache.box, GUILayout.Height(height), GUILayout.ExpandWidth(true));

                int j = 0;
                float btnHeight = StylesCache.button.CalcHeight(new GUIContent(), 100f);//GUILayoutUtility.GetRect(new GUIContent(), , GUILayout.ExpandWidth(true)).height;
                for (int filteredIndex = (int)_scrollPosition; filteredIndex < _filteredValues.Count; filteredIndex++)
                {
                    var btnRect = rect;
                    btnRect.height = btnHeight;
                    btnRect.y += j * btnHeight;
                    j++;
                    if (j * btnHeight > rect.height) break;

                    var valueIndex = _filteredValues[filteredIndex];
                    if (GUI.Button(btnRect, _values[valueIndex], valueIndex == CurrentValueIndex ? _btnSelectedStyle : _btnStyle) && CurrentValueIndex != valueIndex)
                    {
                        changed = true;
                        CurrentValueIndex = valueIndex;
                    }
                }

                context.EndArea();

                var maxScrollPos = Mathf.Max(_filteredValues.Count - lines + 1, 1);
                _scrollPosition = GUILayout.VerticalScrollbar(Mathf.Min(_scrollPosition, maxScrollPos), 0.5f, 0f, maxScrollPos, GUILayout.Height(height));
                context.EndArea();

                return changed;
            }
            context.BeginHorizontalArea();
            GUILayout.Label(PrefixLabel, GUILayout.Width(prefixLabelWidth));
            context.BeginLook(true);
            if (GUILayout.Button(currentDisplayValue, StylesCache.popup))
                Expanded = true;
            context.EndLook();
            context.EndArea();
            return false;
        }
        public string FullValue { get { return GetElementOrEmpty(CurrentValueIndex, _fullValues); } set { CurrentValueIndex = _fullValues.IndexOf(value); } }
        public string ShortValue { get { return GetElementOrEmpty(CurrentValueIndex, _values); } set { CurrentValueIndex = _values.IndexOf(value); } }
        public string Filter { get { return _filter; } set { if (value == null) throw new ArgumentNullException(); _filter = value; } }

        float _scrollPosition;
        public int CurrentValueIndex { get; set; }
        public bool Expanded { get; set; }
        string _filter;
        private readonly bool _displayCurrentFullValue;
        public string PrefixLabel { get; set; }
        readonly IList<string> _values, _fullValues, _searchValues;
        readonly List<int> _filteredValues = new List<int>();
        string _prevFilter;

        static GUIStyle _btnStyle, _btnSelectedStyle;

        static bool _isStaticInited;

        static void Initialize()
        {
            if (_isStaticInited) return;
            _btnStyle = new GUIStyle(StylesCache.button) { alignment = TextAnchor.MiddleLeft, normal = { background = null } };
            _btnSelectedStyle = new GUIStyle(_btnStyle);
            _btnSelectedStyle.normal = _btnSelectedStyle.active;
            _isStaticInited = true;
        }

        static string GetElementOrEmpty(int index, IList<string> values)
        {
            if ((index < 0) || (values.Count <= index)) return string.Empty;
            return values[index];
        }

        static void ResetFocus()
        {
            GUI.SetNextControlName("FocusMe()*0ri20jr");
            GUI.Label(new Rect(), "");
            GUI.FocusControl("FocusMe()*0ri20jr");
        }
    }
}