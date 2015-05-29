using JustLogic.Core;
using System.Collections.Generic;
using System.Collections;

[UnitMenu("ArrayList/Get Count")]
[UnitFriendlyName("ArrayList.Get Count")]
[UnitUsage(typeof(System.Int32), HideExpressionInActionsList = true)]
public class JLArrayListGetCount : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Collections.ArrayList))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        System.Collections.ArrayList opValue = OperandValue.GetResult<System.Collections.ArrayList>(context);
        return opValue.Count;
    }
}
