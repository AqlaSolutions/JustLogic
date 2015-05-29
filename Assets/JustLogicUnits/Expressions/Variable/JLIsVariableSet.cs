#if !JUSTLOGIC_FREE
using JustLogic.Core;
[UnitUsage(typeof(bool), HideExpressionInActionsList = true)]
[UnitMenu("Variable/Is Set")]
public class JLIsVariableSet : JLExpression
{
    [Parameter]
    public SelectedVariableInfo Variable;

    public override object GetAnyResult(IExecutionContext context)
    {
        return context.GetVariable(Variable).Value != null;
    }
}
#endif
