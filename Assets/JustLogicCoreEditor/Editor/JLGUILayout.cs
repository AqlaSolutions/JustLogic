using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace JustLogic.Editor
{
    static class JLGUILayout
    {
        static Rect GetControlRect(bool hasLabel, float height, GUIStyle style, params GUILayoutOption[] options)
        {
            float num = GUILayoutUtility.GetLastRect().width;
            if ((double)num < 1.0)
                num = (float)Screen.width;
            float num1 = GUILayoutUtility.GetLastRect().width;
            if ((double)num1 < 1.0)
                num1 = (float)Screen.width;
            return GUILayoutUtility.GetRect(!hasLabel ? 40f : (float)((double)num + (double)40f + 5.0), (float)((double)(num1 * 0.53f) + (double)40f + 5.0), height, height, style, options);
        }

        public static void LayerMaskField(GUIContent label, int mask, Action<object> setter, params GUILayoutOption[] options)
        {
            LayerMaskField(GetControlRect(true, 16f, StylesCache.layerMaskField, options), label, mask, setter);
        }

        public static void LayerMaskField(Rect position, GUIContent label, int mask, Action<object> setter)
        {
            LayerMaskField(position, label, mask, setter, StylesCache.layerMaskField);
        }

        public static void LayerMaskField(Rect position, GUIContent label, int mask, Action<object> setter, GUIStyle style)
        {
            int controlId = GUIUtility.GetControlID("s_LayerMaskField".GetHashCode(), EditorGUIUtility.native, position);
            if (label != null)
                position = EditorGUI.PrefixLabel(position, controlId, label);

            Event current = Event.current;

            string[] layerMaskNames = GetLayerMaskNames(mask);
            int[] layerMaskSelected = GetLayerMaskSelected(mask);

            if (current.type == EventType.Repaint)
            {
                //if (EditorGUI.showMixedValue)
                {
                    var mvTemp = GUI.contentColor;
                    GUI.contentColor = !EditorGUI.showMixedValue ? GUI.contentColor : GUI.contentColor * new Color(1f, 1f, 1f, 0.5f);
                    string layer;
                    if (layerMaskSelected.Length == 1)
                        layer = layerMaskNames[layerMaskSelected[0]];
                    else if (layerMaskSelected[layerMaskSelected.Length - 1] == 1)
                        layer = "Everything";
                    else
                        layer = "—";
                    style.Draw(position, new GUIContent(layer), controlId, false);
                    GUI.contentColor = mvTemp;
                }
                //else
                //  style.Draw(position, new GUIContent(property.layerMaskStringValue), controlId, false);
            }
            else
            {
                if ((current.type != EventType.MouseDown || !position.Contains(current.mousePosition)) && (current.type != EventType.KeyDown || GUIUtility.keyboardControl != controlId || (int)current.character != 32))
                    return;
                DrawCustomMenuMethod.Invoke(null, new object[]{
                    position, layerMaskNames, layerMaskSelected,
                    new EditorUtility.SelectMenuItemFunction(SetLayerMaskValueDelegate), 
                    new Action<int>(i => setter(ToggleLayerMask(mask,i)))
                });
                Event.current.Use();
            }
        }

        static int[] GetLayerMaskSelected(int mask)
        {
            bool isEverything = mask == -1;
            var layers = new List<int>();
            int index = 2;
            for (int i = 0; i < 32; i++)
            {
                bool noName = string.IsNullOrEmpty(LayerMask.LayerToName(i));
                if ((mask & (1 << i)) != 0)
                {
                    if (!noName || !isEverything)
                        layers.Add(index++);
                }
                else if (!noName)
                    index++;
            }
            if (isEverything)
                layers.Add(1);
            else if (layers.Count == 0)
                layers.Add(0);
            return layers.ToArray();
        }

        static string[] GetLayerMaskNames(int mask)
        {
            var layers = new List<string>();
            layers.Add("Nothing");
            layers.Add("Everything");
            bool isEverything = mask == -1;
            for (int i = 0; i < 32; i++)
            {
                string layerName = LayerMask.LayerToName(i);

                bool hasName = !string.IsNullOrEmpty(layerName);
                if (hasName || (!isEverything && ((mask & (1 << i)) != 0)))
                    layers.Add(hasName ? layerName : "Layer " + i);
            }
            return layers.ToArray();
        }

        static int ToggleLayerMask(int mask, int index)
        {
            bool isEverything = mask == -1;
            if (index == 0)
                return 0;

            if (index == 1)
                return -1;

            int ind = 2;
            for (int i = 0; i < 32; i++)
            {
                string layerName = LayerMask.LayerToName(i);

                bool hasName = !string.IsNullOrEmpty(layerName);
                if (hasName || (!isEverything && ((mask & (1 << i)) != 0)))
                {
                    /*if (index == 1)
                        mask = mask | (1 << i);
                    else*/
                    if (ind == index)
                    {
                        return mask ^ (1 << i);
                    }
                    ind++;
                }
            }
            return mask;
        }

        public static string DebugLayerMask(int mask)
        {
            string r = "";
            int ind = 0;
            for (int i = 0; i < 32; i++)
            {
                string layerName = LayerMask.LayerToName(i);

                bool hasName = !string.IsNullOrEmpty(layerName);
                if ((mask & (1 << i)) != 0)
                {
                    r += (hasName ? layerName : "Layer " + i) + " ";
                    ind++;
                }
            }
            return r;
        }



        static void SetLayerMaskValueDelegate(object userData, string[] options, int selected)
        {
            var toggle = (Action<int>)userData;
            toggle(selected);
        }

        static MethodInfo DrawCustomMenuMethod = typeof(EditorUtility).GetMethod("DisplayCustomMenu",
            BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null,
            new[] { typeof(Rect), typeof(string[]), typeof(int[]), typeof(EditorUtility.SelectMenuItemFunction), typeof(object) }, null);

        readonly static string[] LabelsVector2 = new string[] { "X", "Y" };
        readonly static string[] LabelsVector3 = new string[] { "X", "Y", "Z" };
        readonly static string[] LabelsVector4 = new string[] { "X", "Y", "Z", "W" };

        public static Vector2 Vector2Field(Vector2 value)
        {
            string[] labels = LabelsVector2;
            var values = new float[labels.Length];
            for (int i = 0; i < labels.Length; i++)
                values[i] = value[i];
            MultiFloatField(labels, values);
            for (int i = 0; i < labels.Length; i++)
                value[i] = values[i];
            return value;
        }

        public static Vector3 Vector3Field(Vector3 value)
        {
            string[] labels = LabelsVector3;
            var values = new float[labels.Length];
            for (int i = 0; i < labels.Length; i++)
                values[i] = value[i];
            MultiFloatField(labels, values);
            for (int i = 0; i < labels.Length; i++)
                value[i] = values[i];
            return value;
        }

        public static Vector4 Vector4Field(Vector4 value)
        {
            string[] labels = LabelsVector4;
            var values = new float[labels.Length];
            for (int i = 0; i < labels.Length; i++)
                values[i] = value[i];
            MultiFloatField(labels, values);
            for (int i = 0; i < labels.Length; i++)
                value[i] = values[i];
            return value;
        }

        public static void MultiFloatField(string[] labels, float[] values)
        {
            GUILayout.BeginHorizontal();
            int length = values.Length;
            for (int index = 0; index < length; ++index)
            {
                GUILayout.Label(labels[index], GUILayout.Width(12f));
                values[index] = EditorGUILayout.FloatField(values[index], GUILayout.ExpandWidth(true));
                GUILayout.Space(5f);
            }
            GUILayout.EndHorizontal();
        }
    }
}