#if !JUSTLOGIC_FREE
using System.Collections.Generic;
using JustLogic.Core;
using UnityEngine;

/// <tocexclude />
public abstract class JLCustomScriptAssetBase : JLScriptable, IUndoableBehavior
{
    UndoDataBase IUndoableBehavior.UndoData { get { return UndoDataAccessor; } }
    protected abstract UndoDataBase UndoDataAccessor { get; set; }
    protected abstract UndoDataBase CreateUndoData();

    protected override void OnEnable()
    {
        UndoDataAccessor = CreateUndoData();
        base.OnEnable();
    }
    public Dictionary<string, Variable> StaticVariables { get; set; }

    public JLSequenceBase Value;
}

#endif
