/*using JustLogic.Core;
using System.Collections.Generic;
using System.Collections;

[UnitMenu("ArrayList/Binary Search")]
[UnitFriendlyName("ArrayList.Binary Search")]
[UnitUsage(typeof(System.Int32), HideExpressionInActionsList = true)]
public class JLArrayListBinarySearch : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Collections.ArrayList))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(object))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        System.Collections.ArrayList opValue = OperandValue.GetResult<System.Collections.ArrayList>(context);
        return opValue.BinarySearch(Value.GetResult<object>(context));
    }
}
*/