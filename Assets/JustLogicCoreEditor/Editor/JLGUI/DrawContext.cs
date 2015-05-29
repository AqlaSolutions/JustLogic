//#define LOG

using System;
using System.Collections.Generic;
using JustLogic.Core;
using UnityEditor;
using UnityEngine;

namespace JustLogic.Editor.JLGUI
{
    public class DrawContext : IDrawContext
    {
        readonly Stack<bool> _changedStack = new Stack<bool>();
        public UnityEditor.Editor Inspector { get; set; }

        public void BeginChangedCheck()
        {
            _changedStack.Push(GUI.changed);
            GUI.changed = false;
        }

        public bool EndChangedCheck()
        {
            bool r = GUI.changed;
            if (!r)
                GUI.changed = _changedStack.Pop();
            return r;
        }

        public IScriptVariablesDescriber CurrentVariablesDescriber { get; set; }
        public IEventDescription CurrentEditingEvent { get; set; }

        enum AreaType
        {
            Horizontal,
            Vertical,
            VerticalOutlined
        }

        struct Area
        {
            public readonly AreaType Type;
            public readonly bool Created;

            public static bool operator ==(Area area, AreaType type)
            {
                return area.Type == type;
            }
            public static bool operator !=(Area area, AreaType type)
            {
                return area.Type != type;
            }

            public override bool Equals(object obj)
            {
                return base.Equals(obj);
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            public Area(AreaType type, bool created)
            {
                Type = type;
                Created = created;
            }
        }

        readonly Stack<Area> _areas = new Stack<Area>();
        readonly Stack<bool> _likeInspector = new Stack<bool>();
        bool _likeInspectorMode;
        public bool IsLooksLikeControls { get { return !_likeInspectorMode; } }

        public void Reset()
        {
#if LOG
            Debug.Log("Clear");
#endif
            _areas.Clear();
            _isEnabled = true;
            _likeInspector.Clear();
            NeedsRepaint = false;
            OutlinedIndent = 0;
            _likeInspectorMode = false;
            CurrentEditingEvent = null;
            CurrentVariablesDescriber = null;
            Inspector = null;
        }

        public bool NeedsRepaint { get; private set; }

        public void ScheduleRepaint()
        {
            NeedsRepaint = true;
        }

        readonly Stack<bool> _enabled = new Stack<bool>();
        bool _isEnabled = true;
        public bool IsEnabled { get { return _isEnabled; } }

        public void BeginEnabled(bool enabled)
        {
            _enabled.Push(_isEnabled);
            GUI.enabled = _isEnabled = enabled;
        }

        public void EndEnabled()
        {
            GUI.enabled = _isEnabled = _enabled.Pop();
        }

        public bool IsHorizontal { get { return _areas.Count != 0 && _areas.Peek() == AreaType.Horizontal; } }
        public int OutlinedIndent { get; private set; }

        public void BeginVerticalArea(bool outline, params GUILayoutOption[] options)
        {
            try
            {
#if LOG
            Debug.Log("Begin vertical area, was count " + _areas.Count);
#endif
                if (outline)
                {
                    OutlinedIndent++;
                    GUILayout.BeginVertical(StylesCache.box, options);
                    _areas.Push(new Area(AreaType.VerticalOutlined, true));
                }
                else
                {
                    GUILayout.BeginVertical(options);
                    _areas.Push(new Area(AreaType.Vertical, true));
                }

#if LOG
                Debug.Log(" -- begin vertical area, now count " + _areas.Count);
#endif
            }
            catch (ArgumentException e)
            {
                _areas.Push(new Area(outline ? AreaType.VerticalOutlined : AreaType.Vertical, false));
                ScheduleRepaint();
#if LOG
                Debug.Log("Layout exception " + e);
#endif
            }
        }

        
        public void EndAllAreas()
        {
            while (_areas.Count != 0)
                EndArea();
        }

        public void EndArea()
        {
            try
            {
#if LOG
            Debug.Log("Ending area, was count " + _areas.Count);
#endif
                Area area = _areas.Pop();
                switch (area.Type)
                {
                    case AreaType.Horizontal:
                        if (area.Created)
                            GUILayout.EndHorizontal();
                        break;
                    case AreaType.Vertical:
                        if (area.Created)
                            GUILayout.EndVertical();
                        break;
                    case AreaType.VerticalOutlined:
                        if (area.Created)
                            GUILayout.EndVertical();
                        OutlinedIndent--;
                        break;
                }
            }
            catch (ArgumentException e) { ScheduleRepaint(); Debug.LogError("Layout exception " + e); }
        }

        public void BeginHorizontalArea(params GUILayoutOption[] options)
        {
            try
            {
#if LOG
            Debug.Log("Begin horizontal area, was count " + _areas.Count);
#endif
                GUILayout.BeginHorizontal(options);
                _areas.Push(new Area(AreaType.Horizontal, true));
            }
            catch (ArgumentException e)
            {
                _areas.Push(new Area(AreaType.Horizontal, false));
                ScheduleRepaint();
#if LOG
                Debug.Log("Layout exception " + e);
#endif
            }
        }

        public void BeginLook(bool likeControlsMode)
        {
            _likeInspector.Push(_likeInspectorMode);
            _likeInspectorMode = !likeControlsMode;
            if (_likeInspectorMode)
                StylesCache.LookLikeInspector();
            else
                StylesCache.LookLikeControls();
        }

        public void EndLook()
        {
            _likeInspectorMode = _likeInspector.Pop();
            if (_likeInspectorMode)
                StylesCache.LookLikeInspector();
            else
                StylesCache.LookLikeControls();
        }
    }
}