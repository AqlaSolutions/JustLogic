using System.Linq;
using JustLogic.Core;
using UnityEngine;

/// <summary>
/// A container for your JL script units, access tree through <see cref="JustLogicScript.Engine"/>.<see cref="ExecutionEngineBase.Tree"/>
/// </summary>
/// <remarks>
/// To make a new JL Script, create a new game object (Game Object / Create Empty) and add to it the component JL Script (by pressing the button “Add Component” inspector and entering the component name in the search box).
/// </remarks>
[ExecuteInEditMode]
[AddComponentMenu("Just Logic/JL Script")]
public class JustLogicScript : JustLogicScriptBase, IScriptVariablesDescriber
{
    [SerializeField]
    EditorVariableInfo[] _ctorVariables = new EditorVariableInfo[0];

    [SerializeField]
    EditorVariableInfo[] _ctorStaticVariables = new EditorVariableInfo[0];

    EditorVariableInfoBase[] IScriptVariablesDescriber.CtorVariables { get { return _ctorVariables; } set { _ctorVariables = value.Select(v => (EditorVariableInfo)v).ToArray(); } }
    EditorVariableInfoBase[] IScriptVariablesDescriber.CtorStaticVariables { get { return _ctorStaticVariables; } set { _ctorStaticVariables = value.Select(v => (EditorVariableInfo)v).ToArray(); } }

    public UndoData _editorUndoDataHolder = new UndoData();
    protected override UndoDataBase UndoDataAccessor { get { return _editorUndoDataHolder; } set { _editorUndoDataHolder = (UndoData)value; } }
    protected override UndoDataBase CreateUndoData() { return new UndoData(); }

    /// <summary>
    /// Execution engine itself, use <see cref="ExecutionEngineBase.Tree"/> to access units
    /// </summary>
    public ExecutionEngine Engine = new ExecutionEngine();

    public override ExecutionEngineBase EngineInstance { get { return Engine; } set { Engine = (ExecutionEngine)value; } }

    protected override ExecutionEngineBase CreateExecutionEngine()
    {
        return new ExecutionEngine();
    }
}