using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;
using System.Linq;

namespace JustLogic.Editor
{
    public class StylesCache
    {
        static GUISkin _darkSkin;
        static GUISkin _whiteSkin;

        public static GUISkin Skin
        {
            get
            {
                return GUI.skin;
                if (EditorGUIUtility.isProSkin)
                    return _darkSkin ?? (_darkSkin = (GUISkin)AssetDatabase.LoadAssetAtPath("Assets/JustLogic/DarkSkin.guiskin", typeof(GUISkin)));
                return _whiteSkin ?? (_whiteSkin = (GUISkin)AssetDatabase.LoadAssetAtPath("Assets/JustLogic/WhiteSkin.guiskin", typeof(GUISkin)));
            }
        }

        public static bool InspectorMode { get; set; }

        public static void LookLikeInspector()
        {
            EditorGUIUtility.LookLikeInspector();
            InspectorMode = true;
        }

        public static void LookLikeControls()
        {
            EditorGUIUtility.LookLikeControls();
            InspectorMode = false;
        }

        static GUIStyle GetStyleP(string style)
        {
            if (InspectorMode)
                style = "IN " + style;

            switch (style)
            {
                case "Toggle":
                case "toggle":
                    return Skin.toggle;
                case "textField":
                    return Skin.textField;

            }

            return Skin.GetStyle(style);
        }

        public static GUIStyle numberField { get { return GetStyleP("textField"); } }
        public static GUIStyle textField { get { return GetStyleP("textField"); } }
        public static GUIStyle objectField { get { return GetStyleP("ObjectField"); } }
        public static GUIStyle box { get { return Skin.box; } }

        public static GUIStyle label { get { return Skin.GetStyle(InspectorMode ? "IN Label" : "ControlLabel"); } }

        public static GUIStyle objectFieldThumb { get { return Skin.GetStyle(InspectorMode ? "IN ObjectField" : "ObjectFieldThumb"); } }

        public static GUIStyle foldoutPreDrop { get { return Skin.GetStyle("FoldoutPreDrop"); } }

        public static GUIStyle button { get { return Skin.button; } }

        public static GUIStyle boldLabel { get { return Skin.GetStyle("BoldLabel"); } }

        public static GUIStyle foldout { get { return GetStyleP("Foldout"); } }

        public static GUIStyle layerMaskField { get { return Skin.GetStyle(InspectorMode ? "IN Popup" : "MiniPopup"); } }

        static GUIStyle _toggleInspector;

        public static GUIStyle toggle
        {
            get
            {
                if (!InspectorMode)
                    return Skin.GetStyle("Toggle");
                return _toggleInspector ?? (_toggleInspector = new GUIStyle(Skin.GetStyle("Toggle")) { margin = { top = 0 }, padding = { top = 0 }, overflow = { top = 0 } });
            }
        }

        public static GUIStyle ColorField { get { return GetStyleP("ColorField"); } }

        static GUIStyle _inPopup;

        public static GUIStyle popup
        {
            get
            {
                if (_inPopup == null)
                {
                    _inPopup = new GUIStyle(Skin.GetStyle("IN Popup"))
                                          {
                                              fontStyle = FontStyle.Bold,
                                              alignment = TextAnchor.MiddleLeft
                                          };
                    GUIStyleState state = _inPopup.normal;
                    state.textColor = GUI.color;
                    _inPopup.active = _inPopup.onActive = _inPopup.onNormal = _inPopup.focused = _inPopup.onFocused = _inPopup.hover = _inPopup.onHover;
                }
                return InspectorMode ? _inPopup : Skin.GetStyle("MiniPopup");
            }
        }
    }
}