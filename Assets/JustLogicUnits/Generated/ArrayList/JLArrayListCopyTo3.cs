/*using JustLogic.Core;
using System.Collections.Generic;
using System.Collections;

[UnitMenu("ArrayList/Copy To")]
[UnitFriendlyName("ArrayList.Copy To")]
public class JLArrayListCopyTo3 : JLAction
{
    [Parameter(ExpressionType = typeof(System.Collections.ArrayList))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression Index;

    [Parameter(ExpressionType = typeof(System.Array))]
    public JLExpression Array;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression ArrayIndex;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression Count;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        System.Collections.ArrayList opValue = OperandValue.GetResult<System.Collections.ArrayList>(context);
        opValue.CopyTo(Index.GetResult<System.Int32>(context), Array.GetResult<System.Array>(context), ArrayIndex.GetResult<System.Int32>(context), Count.GetResult<System.Int32>(context));
        return null;
    }
}
*/