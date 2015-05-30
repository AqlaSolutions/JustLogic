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
