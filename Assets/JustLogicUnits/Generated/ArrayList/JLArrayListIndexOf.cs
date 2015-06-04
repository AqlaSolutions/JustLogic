using JustLogic.Core;
using System.Collections.Generic;
using System.Collections;

[UnitMenu("ArrayList/Index Of")]
[UnitFriendlyName("ArrayList.Index Of")]
[UnitUsage(typeof(System.Int32), HideExpressionInActionsList = true)]
public class JLArrayListIndexOf : JLExpression
{
    [Parameter(ExpressionType = typeof(ArrayList))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(object))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        ArrayList opValue = OperandValue.GetResult<ArrayList>(context);
        return opValue.IndexOf(Value.GetResult<object>(context));
    }
}
