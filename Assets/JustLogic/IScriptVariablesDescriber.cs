using JustLogic.Core;

public interface IScriptVariablesDescriber
{
    EditorVariableInfoBase[] CtorVariables { get; set; }
    EditorVariableInfoBase[] CtorStaticVariables { get; set; }
}
