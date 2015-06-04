using JustLogic.Core;
using System.Collections.Generic;
using System.Collections;

[UnitMenu("ArrayList/To Array")]
[UnitFriendlyName("ArrayList.To Array")]
[UnitUsage(typeof(System.Object[]), HideExpressionInActionsList = true)]
public class JLArrayListToArray : JLExpression
{
    [Parameter(ExpressionType = typeof(ArrayList))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        ArrayList opValue = OperandValue.GetResult<ArrayList>(context);
        return opValue.ToArray();
    }
}
