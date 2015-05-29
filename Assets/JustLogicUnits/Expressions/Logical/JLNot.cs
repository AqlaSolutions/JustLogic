using JustLogic.Core;

[UnitMenu("Logical/Not")]
public class JLNot : JLBoolExpression
{
    [Parameter(ExpressionType = typeof(bool))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        return !Value.GetResult<bool>(context);
    }
}
