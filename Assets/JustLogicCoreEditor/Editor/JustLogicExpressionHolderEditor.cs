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
public class JustLogicExpressionHolderEditor : JLInspectorBase
{
    [NonSerialized]
    IParameterDrawer _mainDrawer;
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
        base.OnUndoableScriptReseting();
        if (this)
        {
            var script = (JustLogicSceneExpressionBase)target;
            JLScriptableHelper.Destroy(script.Value);
        }
    }

    protected override void OnDisable()
    {
        ResetDrawers();
        base.OnDisable();
    }

    private void ResetDrawers()
    {
        if (_mainDrawer != null)
            _mainDrawer.Dispose();
        _mainDrawer = null;
    }

    protected override bool Draw()
    {
        var script = (IExpressionHolder)target;

        var expression = script.Value;

        ServiceUndoRedo(typeof(JLExpression), expression,
            o =>
            {
                ResetDrawers();

                // ReSharper disable once AccessToModifiedClosure
                JLScriptableHelper.Destroy(expression);

                script.Value = expression = (JLExpression)o;
            });

        _drawContext.Reset();
        _drawContext.Inspector = this;
        var describer = script as IScriptVariablesDescriber;
        if (describer != null)
            _drawContext.CurrentVariablesDescriber = describer;
        _drawContext.BeginLook(false);

        bool needsUndo = false;
        GUI.changed = false;

        if (_mainDrawer == null)
        {
            _mainDrawer = ParameterDrawersFactory.Default.CreateDrawer(
                new DrawerInitArgs(typeof(JLExpression)), expression, _drawContext);
        }

        _drawContext.BeginVerticalArea(true);
        GUILayout.Label("Expression", StylesCache.boldLabel);

        if (_mainDrawer.SimpleDraw(_drawContext))
        {
            script.Value = expression = (JLExpression)_mainDrawer.Value;
            needsUndo = true;
        }

        _drawContext.EndArea();

        if (_drawContext.NeedsRepaint)
            Repaint();

        return needsUndo;
    }
}

#endif
