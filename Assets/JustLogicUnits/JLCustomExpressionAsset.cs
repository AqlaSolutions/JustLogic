#if !JUSTLOGIC_FREE

using System.Collections.Generic;
using JustLogic.Core;
using UnityEngine;
using System.Linq;

/// <summary>
/// An expression that is stored in the form of an asset; use the <see cref="JLCustomExpressionAssetBase.Value"/> field to access it
/// </summary>
public class JLCustomExpressionAsset : JLCustomExpressionAssetBase, IScriptVariablesDescriber
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
}

#endif
