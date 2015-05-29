using JustLogic.Core;
using System.Collections.Generic;
using System.Collections;

[UnitMenu("ArrayList/Get Range")]
[UnitFriendlyName("ArrayList.Get Range")]
[UnitUsage(typeof(System.Collections.ArrayList), HideExpressionInActionsList = true)]
public class JLArrayListGetRange : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Collections.ArrayList))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression Index;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression Count;

    public override object GetAnyResult(IExecutionContext context)
    {
        System.Collections.ArrayList opValue = OperandValue.GetResult<System.Collections.ArrayList>(context);
        return opValue.GetRange(Index.GetResult<System.Int32>(context), Count.GetResult<System.Int32>(context));
    }
}
