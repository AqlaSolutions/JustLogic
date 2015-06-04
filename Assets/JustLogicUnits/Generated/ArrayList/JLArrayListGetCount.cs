using JustLogic.Core;
using System.Collections.Generic;
using System.Collections;

[UnitMenu("ArrayList/Get Count")]
[UnitFriendlyName("ArrayList.Get Count")]
[UnitUsage(typeof(System.Int32), HideExpressionInActionsList = true)]
public class JLArrayListGetCount : JLExpression
{
    [Parameter(ExpressionType = typeof(ArrayList))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        ArrayList opValue = OperandValue.GetResult<ArrayList>(context);
        return opValue.Count;
    }
}
