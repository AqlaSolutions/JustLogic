using System;
using JustLogic.Core;

[UnitUsage(HideExpressionInActionsList = true)]
[UnitMenu("Cast/To")]
public class JLCast : JLExpression
{
    [Parameter]
    public JLExpression Value;

    [Parameter(ExpressionType = typeof(Type))]
    public JLExpression TargetType;

    public override object GetAnyResult(IExecutionContext context)
    {
        return JLExpressionExtensions.ConvertType(Value.GetAnyResultSafe(context), TargetType.GetResult<Type>(context), context);
    }
}
