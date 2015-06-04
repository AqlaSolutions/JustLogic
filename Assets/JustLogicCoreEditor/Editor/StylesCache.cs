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
            }
        }

        public static bool InspectorMode { get; set; }

        public static void LookLikeInspector()
        {
#pragma warning disable 618
            EditorGUIUtility.LookLikeInspector();
#pragma warning restore 618
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