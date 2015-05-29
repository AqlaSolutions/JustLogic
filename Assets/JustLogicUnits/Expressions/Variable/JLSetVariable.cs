#if !JUSTLOGIC_FREE
using JustLogic.Core;

[UnitMenu("Variable/Set")]
public class JLSetVariable : JLExpression
{
    [Parameter]
    public SelectedVariableInfo Variable;

    [Parameter]
    public JLExpression Value;

    [Parameter]
    public bool Delegate;

    public override object GetAnyResult(IExecutionContext context)
    {
        object v = (Delegate && (Variable.Scope != SelectedVariableInfoBase.VariableScope.Global)) ? Value : Value.GetAnyResultSafe(context);
        context.GetVariable(Variable).Value = v;
        return v;
    }
}
#endif
