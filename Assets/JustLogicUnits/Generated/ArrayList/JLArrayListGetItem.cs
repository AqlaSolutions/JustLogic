using JustLogic.Core;
using System.Collections.Generic;
using System.Collections;

[UnitMenu("ArrayList/Get Item")]
[UnitFriendlyName("ArrayList.Get Item")]
[UnitUsage(typeof(object), HideExpressionInActionsList = true)]
public class JLArrayListGetItem : JLExpression
{
    [Parameter(ExpressionType = typeof(ArrayList))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression Index;

    public override object GetAnyResult(IExecutionContext context)
    {
        ArrayList opValue = OperandValue.GetResult<ArrayList>(context);
        return opValue[Index.GetResult<System.Int32>(context)];
    }
}
