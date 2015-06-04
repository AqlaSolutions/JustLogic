using JustLogic.Core;
using System.Collections.Generic;
using System.Collections;

[UnitMenu("ArrayList/Insert Range")]
[UnitFriendlyName("ArrayList.Insert Range")]
public class JLArrayListInsertRange : JLAction
{
    [Parameter(ExpressionType = typeof(ArrayList))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression Index;

    [Parameter(ExpressionType = typeof(ICollection))]
    public JLExpression C;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        ArrayList opValue = OperandValue.GetResult<ArrayList>(context);
        opValue.InsertRange(Index.GetResult<System.Int32>(context), C.GetResult<ICollection>(context));
        return null;
    }
}
