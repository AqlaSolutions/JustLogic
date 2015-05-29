using JustLogic.Core;
using System.Collections.Generic;
using System.Collections;

[UnitMenu("ArrayList/To Array")]
[UnitFriendlyName("ArrayList.To Array")]
[UnitUsage(typeof(System.Object[]), HideExpressionInActionsList = true)]
public class JLArrayListToArray : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Collections.ArrayList))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        System.Collections.ArrayList opValue = OperandValue.GetResult<System.Collections.ArrayList>(context);
        return opValue.ToArray();
    }
}
