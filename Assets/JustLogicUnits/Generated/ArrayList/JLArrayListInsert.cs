using JustLogic.Core;
using System.Collections.Generic;
using System.Collections;

[UnitMenu("ArrayList/Insert")]
[UnitFriendlyName("ArrayList.Insert")]
public class JLArrayListInsert : JLAction
{
    [Parameter(ExpressionType = typeof(ArrayList))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression Index;

    [Parameter(ExpressionType = typeof(object))]
    public JLExpression Value;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        ArrayList opValue = OperandValue.GetResult<ArrayList>(context);
        opValue.Insert(Index.GetResult<System.Int32>(context), Value.GetResult<object>(context));
        return null;
    }
}
