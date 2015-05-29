using System;
using System.Collections.Generic;
using System.Linq;
using JustLogic;
using JustLogic.Core;
using JustLogic.Core.Events;

using UnityEngine;

/// <tocexclude />
[ExecuteInEditMode]
public class JustLogicEventHandlerBase : JustLogicEventHandlerCoreBase, IScriptVariablesDescriber
{
    [SerializeField]
    EditorVariableInfo[] _ctorVariables = new EditorVariableInfo[0];

    [SerializeField]
    EditorVariableInfo[] _ctorStaticVariables = new EditorVariableInfo[0];

    EditorVariableInfoBase[] IScriptVariablesDescriber.CtorVariables { get { return _ctorVariables; } set { _ctorVariables = value != null ? value.Select(v => (EditorVariableInfo)v).ToArray() : null; } }
    EditorVariableInfoBase[] IScriptVariablesDescriber.CtorStaticVariables { get { return _ctorStaticVariables; } set { _ctorStaticVariables = value != null ? value.Select(v => (EditorVariableInfo)v).ToArray() : null; } }

    public UndoData _editorUndoDataHolder = new UndoData();
    protected override UndoDataBase UndoDataAccessor { get { return _editorUndoDataHolder; } set { _editorUndoDataHolder = (UndoData)value; } }
    protected override UndoDataBase CreateUndoData() { return new UndoData(); }

    // also we could use MethodBase.GetCurrentMethod to parse name and parameters...
    // and seek for event by methodname in library

    public void Awake2() { Awake(); }

    public void OnEnable2() { OnEnable(); }

}
