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
  
using JustLogic;
using JustLogic.Editor;
using UnityEditor;
using UnityEngine;

public class JustLogicAboutWindow : EditorWindow
{
    [MenuItem("CONTEXT/JustLogicBehaviorBase/About JustLogic")]
    public static void Open()
    {
        var w = GetWindow<JustLogicAboutWindow>();
        if (!w) w = CreateInstance<JustLogicAboutWindow>();
        w.ShowUtility();
        w.Focus();
    }

    protected void OnEnable()
    {
        // ReSharper disable ArrangeThisQualifier
        var r = this.position;
        r.width = 285;
#if JUSTLOGIC_FREE
        r.height = 175;
#else
        r.height = 100;
#endif
        this.position = r;
        this.maxSize = new Vector2(r.width, r.height);
        this.minSize = this.maxSize;
        title = "About JustLogic";
        // ReSharper restore ArrangeThisQualifier
    }

    GUIStyle _centeredLabel;

    protected void OnGUI()
    {
        if (_centeredLabel == null)
            _centeredLabel = new GUIStyle(StylesCache.label) { alignment = TextAnchor.MiddleCenter };

        GUILayout.Label("Just Logic\nVisual Programming Extension", _centeredLabel);
#if !JUSTLOGIC_FREE
        GUILayout.Label("Thanks for your purchase!", _centeredLabel);
#else
        GUILayout.Label("You are using the free trial version of JustLogic. \nIt is provided for demonstration purposes only \n(no commerical use) for 30 days and with \nlimited functionality. ");

        var c = GUI.color;
        GUI.color = Color.red;
        GUILayout.Label(FreeVersion.IsExpired ? "License expired" : (FreeVersion.DaysToExpire + " days left"));
        if (GUILayout.Button("Buy the full version now"))
            Application.OpenURL("http://aqla.net/en/unity-3d-extensions/just-logic/order.html");
        GUI.color = c;
#endif

        GUILayout.Label("Author Vlad Taranov", _centeredLabel);
        GUILayout.Label("aqla.dev@gmail.com", _centeredLabel);
        if (GUILayout.Button("http://www.aqla.net")) Application.OpenURL("http://aqla.net/en/unity-3d-extensions/just-logic/features.html");
    }
}
