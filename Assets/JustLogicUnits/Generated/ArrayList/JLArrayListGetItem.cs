using JustLogic.Core;
using System.Collections.Generic;
using System.Collections;

[UnitMenu("ArrayList/Get Item")]
[UnitFriendlyName("ArrayList.Get Item")]
[UnitUsage(typeof(object), HideExpressionInActionsList = true)]
public class JLArrayListGetItem : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Collections.ArrayList))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression Index;

    public override object GetAnyResult(IExecutionContext context)
    {
        System.Collections.ArrayList opValue = OperandValue.GetResult<System.Collections.ArrayList>(context);
        return opValue[Index.GetResult<System.Int32>(context)];
    }
}
