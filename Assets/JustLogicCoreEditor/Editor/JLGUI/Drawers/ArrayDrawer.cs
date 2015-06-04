using System;
using System.Collections;
using System.Collections.Generic;
using JustLogic.Core;
using UnityEditor;
using UnityEngine;

namespace JustLogic.Editor.JLGUI.Drawers
{
    [ParameterDrawer(typeof(Array), Order = int.MaxValue)]
    public class ArrayDrawer : ParameterDrawerBase
    {
        public override bool Initialize(DrawerInitArgs args, object value, IDrawContext context)
        {
            bool r = base.Initialize(args, value, context);
            if (r)
            {
                Layout = ParameterDrawerLayout.VerticalRoot;

                UnitParameter parameter = InitArgs.ParameterInfo;
                Type parameterType = InitArgs.SupportedType;
                Type elementType = parameterType.GetElementType();
                if (Value != null)
                {
                    var list = (IList)Value;
                    foreach (var v in list)
                        _drawers.Add(CreateArrayElementDrawer(v, elementType, parameter, context));
                }
            }
            return r;
        }

        public override void Dispose()
        {
            foreach (var parameterDrawer in _drawers)
                parameterDrawer.Dispose();
            _drawers.Clear();
            base.Dispose();
        }

        readonly List<IParameterDrawer> _drawers = new List<IParameterDrawer>();

        readonly static GUIContent TempContent = new GUIContent();

        protected override void DrawLabel(GUIContent label, bool isAppendedToHorizontal, ref bool hasVerticalOutline, IDrawContext context)
        {
            hasVerticalOutline = true;
            if (Value != null)
            {
                if ((label != null) && !string.IsNullOrEmpty(label.text))
                {
                    TempContent.image = label.image;
                    TempContent.text = label.text + " [" + ((IList)Value).Count + "]";
                    TempContent.tooltip = InitArgs.ParameterInfo.Type.GetElementType().GetSimpleName();
                }
                else
                {
                    TempContent.image = null;
                    TempContent.text = InitArgs.ParameterInfo.Type.GetElementType().GetSimpleName() + " [" + ((IList)Value).Count + "]";
                    TempContent.tooltip = string.Empty;
                }
                label = TempContent;
            }
            base.DrawLabel(label, isAppendedToHorizontal, ref hasVerticalOutline, context);
        }
        Rect? _dragSeperatorRect;
        int _dragInsertIndex = -1;

        protected override bool OnDraw(IDrawContext context, bool isNewAreaStarted)
        {
            int dragCurrentIndex = -1;
            {
                IParameterDrawer dragDrawer = null;

                if ((dragDrawer = (IParameterDrawer)DragAndDrop.GetGenericData(typeof(UnitDrawerBase).FullName)) != null)
                {
                    dragCurrentIndex = _drawers.IndexOf(dragDrawer);
                }
            }
            if (dragCurrentIndex != -1)
            {
                context.ScheduleRepaint();
                if (DragAndDrop.paths == null || DragAndDrop.paths.Length != 1 || DragAndDrop.paths[0] != "///" + typeof(UnitDrawerBase).FullName)
                {
                    _dragSeperatorRect = null;
                    _dragInsertIndex = -1;
                    dragCurrentIndex = -1;
                    DragAndDrop.SetGenericData(typeof(UnitDrawerBase).FullName, null);
                    DragAndDrop.PrepareStartDrag();
                }
            }

            if (Event.current.type != EventType.Layout) _dragInsertIndex = -1;

            UnitParameter parameter = InitArgs.ParameterInfo;
            Type parameterType = InitArgs.SupportedType;
            Type elementType = parameterType.GetElementType();
            bool elementIsValueType = elementType.IsValueType;

            int insertIndex = -1;
            int cloneIndex = -1;
            bool cloneAfter = false;
            int removeIndex = -1;
            int upIndex = -1;
            int downIndex = -1;

            var list = (IList)Value;
            bool arrayChanged = false;

            if (list == null)
            {
                Value = list = Array.CreateInstance(elementType, 0);
                arrayChanged = true;
            }

            if (list.Count == 0)
            {
                context.BeginHorizontalArea();
                GUILayout.FlexibleSpace();

                if (GUILayout.Button("+", GUILayout.Width(20f)))
                {
                    var newItem = elementIsValueType ? Activator.CreateInstance(elementType) : null;
                    ChangeList(ref list, elementType, lst => lst.Add(newItem));
                    var newDrawer = CreateArrayElementDrawer(newItem, elementType, parameter, context);
                    _drawers.Add(newDrawer);
                    arrayChanged = true;
                }
                context.EndArea();
            }
            var prevRectOfItem = new Rect();
            for (int i = 0; i < list.Count; i++)
            {
                context.BeginVerticalArea();
                IParameterDrawer drawer = _drawers[i];
                if (drawer.SimpleDraw(context))
                {
                    arrayChanged = true;
                    list[i] = drawer.Value;
                }
                context.BeginHorizontalArea();
                GUILayout.FlexibleSpace();
                if (GUILayout.Button("+", GUILayout.Width(20f)))
                {
                    cloneIndex = i;
                    cloneAfter = true;
#if JUSTLOGIC_FREE
                    if (list.Count >= 5)
                    {
                        cloneIndex = -1;
                        cloneAfter = false;
                        EditorUtility.DisplayDialog("JustLogic", "The free version of JustLogic allows maximum 5 array items", "OK");
                    }
#endif
                }
                {
                    if (GUILayout.Button("↑", GUILayout.Width(20f)))
                        upIndex = i;
                    if (GUILayout.Button("↓", GUILayout.Width(20f)))
                        downIndex = i;
                }
                if (GUILayout.Button("-", GUILayout.Width(20f)))
                    removeIndex = i;
                context.EndArea();
                GUILayout.Space(10f);

                context.EndArea();
                if (dragCurrentIndex != -1 && Event.current.type != EventType.Layout)
                {
                    Rect rectOfItem = GUILayoutUtility.GetLastRect();
                    Vector2 mp = Event.current.mousePosition;

                    if (_dragInsertIndex == -1)
                    {
                        if (i == 0 && mp.y < rectOfItem.y)
                        {
                            _dragInsertIndex = 0;
                            SetDragSeperator(rectOfItem.x, rectOfItem.yMin, rectOfItem.width);
                        }
                        else if (i == _drawers.Count - 1 && mp.y > rectOfItem.y + rectOfItem.height)
                        {
                            _dragInsertIndex = _drawers.Count;
                            SetDragSeperator(rectOfItem.x, rectOfItem.yMax, rectOfItem.width);
                        }
                        else if (rectOfItem.yMin <= mp.y && rectOfItem.yMax >= mp.y)
                        {
                            if (mp.y > rectOfItem.y + rectOfItem.height / 2f)
                            {
                                _dragInsertIndex = i + 1;
                                SetDragSeperator(rectOfItem.x, rectOfItem.yMax, rectOfItem.width);
                            }
                            else
                            {
                                _dragInsertIndex = i;
                                SetDragSeperator(rectOfItem.x, rectOfItem.yMin, rectOfItem.width);
                            }

                        }
                        else if (i > 0 && mp.y > prevRectOfItem.yMax && mp.y < rectOfItem.yMin)
                        {
                            _dragInsertIndex = i;
                            SetDragSeperator(rectOfItem.x, rectOfItem.yMin, rectOfItem.width);
                        }
                    }
                    prevRectOfItem = rectOfItem;
                }
            }

            if (upIndex > 0)
            {
                ChangeList(ref list, elementType, lst => MoveElementUp(lst, upIndex));
                MoveElementUp(_drawers, upIndex);
                arrayChanged = true;
            }

            if ((downIndex != -1) && (downIndex < list.Count - 1))
            {
                ChangeList(ref list, elementType, lst => MoveElementDown(lst, downIndex));
                MoveElementDown(_drawers, downIndex);
                arrayChanged = true;
            }

            if (insertIndex != -1)
            {
                var newItem = elementIsValueType ? Activator.CreateInstance(elementType) : null;
                ChangeList(ref list, elementType, lst => lst.Insert(insertIndex, newItem));
                _drawers.Add(CreateArrayElementDrawer(newItem, elementType, parameter, context));
                arrayChanged = true;
            }

            if (cloneIndex != -1)
            {
                var newItem = Copier.Duplicate(list[cloneIndex]);
                ChangeList(ref list, elementType,
                           lst =>
                           {
                               int index = cloneIndex;
                               if (cloneAfter)
                                   index++;
                               if (index < lst.Count)
                                   lst.Insert(index, newItem);
                               else
                                   lst.Add(newItem);
                           });
                {
                    var drawer = CreateArrayElementDrawer(newItem, elementType, parameter, context);
                    int index = cloneIndex;
                    if (cloneAfter)
                        index++;
                    if (index < _drawers.Count)
                        _drawers.Insert(index, drawer);
                    else
                        _drawers.Add(drawer);
                }
                arrayChanged = true;
            }

            if (removeIndex != -1)
            {
                object el = list[removeIndex];
                JLScriptableHelper.Destroy(el);
                ChangeList(ref list, elementType, lst => lst.RemoveAt(removeIndex));
                _drawers[removeIndex].Dispose();
                _drawers.RemoveAt(removeIndex);
                arrayChanged = true;
            }

            if (dragCurrentIndex != -1)
            {
                DragAndDrop.visualMode = _dragInsertIndex != -1 ? DragAndDropVisualMode.Move : DragAndDropVisualMode.Rejected;

                if (Event.current.type == EventType.DragPerform)
                {
                    DragAndDrop.AcceptDrag();
                    DragAndDrop.PrepareStartDrag();
                    if (_dragInsertIndex != -1 && _dragInsertIndex != dragCurrentIndex)
                    {
                        ChangeList(ref list, elementType, lst => MoveElement(lst, dragCurrentIndex, _dragInsertIndex));
                        MoveElement(_drawers, dragCurrentIndex, _dragInsertIndex);
                        arrayChanged = true;
                    }
                    context.ScheduleRepaint();
                    _dragSeperatorRect = null;
                    _dragInsertIndex = -1;
                }
            }

            if (_dragSeperatorRect.HasValue)
            {
                if (!_dragSeperatorTexture)
                {
                    _dragSeperatorTexture = new Texture2D(1, 1) { hideFlags = HideFlags.HideAndDontSave };
                    _dragSeperatorTexture.SetPixel(0, 0, Color.black);
                    _dragSeperatorTexture.Apply();
                }
                GUI.DrawTexture(_dragSeperatorRect.Value, _dragSeperatorTexture);
            }

            if (arrayChanged)
                Value = list;

            return arrayChanged;
        }

        static Texture2D _dragSeperatorTexture;

        void SetDragSeperator(float x, float y, float width)
        {
            _dragSeperatorRect = new Rect(x, y, width, 1f);
        }

        static void ChangeList(ref IList currentValue, Type elementType, Action<ArrayList> action)
        {
            var list = new ArrayList(currentValue);
            action(list);
            currentValue = Array.CreateInstance(elementType, list.Count);
            list.CopyTo((Array)currentValue, 0);
        }

        private IParameterDrawer CreateArrayElementDrawer(object element, Type elementType, UnitParameter parameter, IDrawContext context)
        {
            return InitArgs.Factory.CreateDrawer(new DrawerInitArgs(this, elementType, InitArgs.Factory, InitArgs.ParameterInfo.Attributes, parameter, containerExpressionType: InitArgs.ExpressionType), element, context);
        }

        private static void MoveElement(IList lst, int currentIndex, int newIndex)
        {
            if (currentIndex == newIndex) return;
            var prevEl = lst[currentIndex];
            if (newIndex < currentIndex)
            {
                lst.RemoveAt(currentIndex);
                lst.Insert(newIndex, prevEl);
            }
            else
            {
                if (lst.Count == newIndex)
                    lst.Add(prevEl);
                else
                    lst.Insert(newIndex, prevEl);
                lst.RemoveAt(currentIndex);
            }
        }

        private static void MoveElementDown(IList lst, int downIndex)
        {
            var prevEl = lst[downIndex + 1];
            lst[downIndex + 1] = lst[downIndex];
            lst[downIndex] = prevEl;
        }

        private static void MoveElementUp(IList lst, int upIndex)
        {
            var prevEl = lst[upIndex - 1];
            lst[upIndex - 1] = lst[upIndex];
            lst[upIndex] = prevEl;
        }
    }
}