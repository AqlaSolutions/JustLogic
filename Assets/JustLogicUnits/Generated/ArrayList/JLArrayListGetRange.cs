using JustLogic.Core;
using System.Collections.Generic;
using System.Collections;

[UnitMenu("ArrayList/Get Range")]
[UnitFriendlyName("ArrayList.Get Range")]
[UnitUsage(typeof(ArrayList), HideExpressionInActionsList = true)]
public class JLArrayListGetRange : JLExpression
{
    [Parameter(ExpressionType = typeof(ArrayList))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression Index;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression Count;

    public override object GetAnyResult(IExecutionContext context)
    {
        ArrayList opValue = OperandValue.GetResult<ArrayList>(context);
        return opValue.GetRange(Index.GetResult<System.Int32>(context), Count.GetResult<System.Int32>(context));
    }
}
