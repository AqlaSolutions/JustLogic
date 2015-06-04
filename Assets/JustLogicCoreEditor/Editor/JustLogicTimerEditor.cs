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
  
#if !JUSTLOGIC_FREE
using System;
using JustLogic.Core;
using JustLogic.Editor;
using JustLogic.Editor.JLGUI;
using UnityEditor;
using UnityEngine;

/// <tocexclude />
[CustomEditor(typeof(JustLogicTimerBase))]
public class JustLogicTimerEditor : JLInspectorBase
{
    [NonSerialized]
    IParameterDrawer _receiverDrawer;
    [NonSerialized]
    DrawContext _drawContext;

    protected override void OnEnable()
    {
        _drawContext = new DrawContext();
        base.OnEnable();
    }

    protected override void OnUndoableScriptReseting()
    {
        if (this)
            ResetDrawers();
    }

    protected override void OnDisable()
    {
        ResetDrawers();
        base.OnDisable();
    }

    private void ResetDrawers()
    {
        if (_receiverDrawer != null)
            _receiverDrawer.Dispose();
        _receiverDrawer = null;
    }

    protected override bool Draw()
    {
        var script = (JustLogicTimerBase)target;

        _drawContext.Reset();
        _drawContext.Inspector = this;

        _drawContext.BeginLook(false);

        bool needsUndo = false;



        if (_receiverDrawer == null)
        {
            _receiverDrawer = ParameterDrawersFactory.Default.CreateDrawer(
                new DrawerInitArgs(typeof(UnityEngine.Object)), script.Receiver, _drawContext);
        }

        _drawContext.BeginHorizontalArea();
        GUILayout.Label("Receiver", StylesCache.boldLabel);

        if (_receiverDrawer.SimpleDraw(_drawContext))
        {
            script.Receiver = (UnityEngine.Object)_receiverDrawer.Value;
            needsUndo = true;
        }
        _drawContext.EndArea();
        if (script.Receiver)
        {
            if (script.Receiver is JustLogicScriptBase)
                EditorGUILayout.HelpBox("The selected object is JL Script so it is called directly.", MessageType.Info);
            else if (script.Receiver is JustLogicEventHandlerCoreBase)
                EditorGUILayout.HelpBox("The selected object is JL Event Handler. You can specify conditons in its inspector.", MessageType.Info);
            else if (script.Receiver is GameObject)
                EditorGUILayout.HelpBox("The selected object is GameObject. All JL Event Handlers are triggered. None of JL Scripts are called directly.", MessageType.Info);
            else if (script.Receiver is MonoBehaviour)
                EditorGUILayout.HelpBox("The selected object is script. You can handle event OnJLTimerTick(JustLogicTimer timer) inside it.", MessageType.None);
            else EditorGUILayout.HelpBox("The selected object is not supported", MessageType.Warning);
        }

        GUI.changed = false;
        script.Interval = EditorGUILayout.FloatField("Interval", script.Interval);
        script.Once = EditorGUILayout.Toggle("Once", script.Once);
        if (GUI.changed)
            needsUndo = true;

        if (_drawContext.NeedsRepaint)
            Repaint();

        return needsUndo;
    }
}

#endif
