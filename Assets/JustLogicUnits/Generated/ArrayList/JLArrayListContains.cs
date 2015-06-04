using JustLogic.Core;
using System.Collections.Generic;
using System.Collections;

[UnitMenu("ArrayList/Contains")]
[UnitFriendlyName("ArrayList.Contains")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLArrayListContains : JLExpression
{
    [Parameter(ExpressionType = typeof(ArrayList))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(object))]
    public JLExpression Item;

    public override object GetAnyResult(IExecutionContext context)
    {
        ArrayList opValue = OperandValue.GetResult<ArrayList>(context);
        return opValue.Contains(Item.GetResult<object>(context));
    }
}
