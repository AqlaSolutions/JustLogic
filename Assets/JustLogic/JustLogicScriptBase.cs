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
using System.Collections;
using JustLogic.Core;
using UnityEngine;

/// <tocexclude />
[ExecuteInEditMode]
public abstract class JustLogicScriptBase : JustLogicScriptableContainerBase
{
    [NonSerialized]
    bool _editorInited;

    private void EnsureEditorInited()
    {
        if (!_editorInited && Application.isEditor)
        {
            _editorInited = true;
            EditorOnAfterDuplicated += () => EditorEventsMediator.OnSceneScriptDuplicated(this);
        }
    }

    public abstract ExecutionEngineBase EngineInstance { get; set; }
    public ExecutionEngineBase.ReentranceMode CtorReentrance;

    bool _initialized;

    public void InitEngine()
    {
        if (_initialized) return;
        _initialized = true;
        EngineInstance.Initialize(CtorReentrance);
        EngineInstance.Context.ExecutorObject = gameObject;
        EngineInstance.Context.ExecutorBehavior = this;
    }

    public override object EditorScriptData
    {
        get { if (EngineInstance == null)return null; return EngineInstance.Tree; }
        set
        {

            if (EngineInstance == null)
                EngineInstance = CreateExecutionEngine();
            EngineInstance.Tree = (JLAction)value;
        }
    }

    protected abstract ExecutionEngineBase CreateExecutionEngine();

    protected override void Awake()
    {
        EnsureEditorInited();
        base.Awake();
    }

    protected override void OnEnable()
    {
        EnsureEditorInited();
        base.OnEnable();
    }

    protected override void Update()
    {
        base.Update();
        if (Application.isPlaying)
            EngineInstance.Continue(false);
    }

    protected void FixedUpdate()
    {
        if (Application.isPlaying)
            EngineInstance.Continue(true);
    }

    protected override void Reset()
    {
        base.Reset();
#if DEBUG
        Debug.Log("Reset, tree: " + EngineInstance.Tree);
#endif
        if (EngineInstance.Tree)
            Destroy(EngineInstance.Tree);
        EngineInstance.Tree = JLAction.Build<JLIfBase>(
        v =>
        {
            v.Value = JLExpression.Build<JLAndBase>(a => a.Operands = new JLExpression[0]);
            v.Then = JLAction.Build<JLSequenceBase>(b => b.Actions = new JLAction[]
                                                                     {
                                                                         JLAction.Build<JLEvaluteBase>(
                                                                         ev=>ev.Expression=JLExpression.Build<JLPrintRetBase>
                                                                             (p => p.Value = 
                                                                                 JLExpression.Build<JLStringValueBase>(s => s.Value = "Hello world!")))
                                                                     });
        });
    }

    [ContextMenu("Start execution")]
    public void StartExecution()
    {
        if (!Application.isPlaying)
        {
            Debug.LogError("Execution can be started only in play mode");
            return;
        }
        InitEngine();
        EngineInstance.Start(new ExecutionEngineBase.StartArguments(null));
    }

    public void StartExecutionByEvent(EventData currentEvent)
    {
        InitEngine();
        EngineInstance.Start(new ExecutionEngineBase.StartArguments(currentEvent));
    }
}
