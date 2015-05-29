#if !JUSTLOGIC_FREE
using JustLogic.Core;
[UnitUsage]
[UnitMenu("Variable/Get")]
public class JLGetVariable : JLExpression
{
    [Parameter]
    public SelectedVariableInfo Variable;

    public override object GetAnyResult(IExecutionContext context)
    {
        object v = context.GetVariable(Variable).Value;
        var expression = v as JLExpression;
        if (expression != null)
        {
            return expression.GetAnyResultSafe(context);
        }
        return v;
    }
}
#endif
