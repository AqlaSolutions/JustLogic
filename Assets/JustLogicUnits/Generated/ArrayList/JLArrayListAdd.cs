using JustLogic.Core;
using System.Collections.Generic;
using System.Collections;

[UnitMenu("ArrayList/Add")]
[UnitFriendlyName("ArrayList.Add")]
[UnitUsage(typeof(System.Int32), HideExpressionInActionsList = true)]
public class JLArrayListAdd : JLExpression
{
    [Parameter(ExpressionType = typeof(ArrayList))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(object))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        ArrayList opValue = OperandValue.GetResult<ArrayList>(context);
        return opValue.Add(Value.GetResult<object>(context));
    }
}
