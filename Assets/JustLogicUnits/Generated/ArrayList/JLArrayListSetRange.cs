/*using JustLogic.Core;
using System.Collections.Generic;
using System.Collections;

[UnitMenu("ArrayList/Set Range")]
[UnitFriendlyName("ArrayList.Set Range")]
public class JLArrayListSetRange : JLAction
{
    [Parameter(ExpressionType = typeof(System.Collections.ArrayList))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression Index;

    [Parameter(ExpressionType = typeof(System.Collections.ICollection))]
    public JLExpression C;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        System.Collections.ArrayList opValue = OperandValue.GetResult<System.Collections.ArrayList>(context);
        opValue.SetRange(Index.GetResult<System.Int32>(context), C.GetResult<System.Collections.ICollection>(context));
        return null;
    }
}
*/