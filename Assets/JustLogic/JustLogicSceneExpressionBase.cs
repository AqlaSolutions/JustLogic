#if !JUSTLOGIC_FREE
using System;
using System.Collections.Generic;
using JustLogic.Core;

using UnityEngine;

/// <tocexclude />
[ExecuteInEditMode]
public abstract class JustLogicSceneExpressionBase : JustLogicScriptableContainerBase, IExpressionHolder
{
    [NonSerialized]
    bool _editorInited;

    private void EnsureEditorInited()
    {
        if (!_editorInited && Application.isEditor)
        {
            _editorInited = true;
            EditorOnAfterDuplicated += () => EditorEventsMediator.OnSceneExpressionDuplicated(this);
        }
    }

    public override object EditorScriptData { get { return Value; } set { Value = (JLExpression)value; } }

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

    public Dictionary<string, Variable> StaticVariables { get; set; }
    public JLExpression Value;
    JLExpression IExpressionHolder.Value { get { return Value; } set { Value = value; } }
}

#endif
