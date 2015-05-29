using JustLogic.Core;
using System.Collections.Generic;
using System.Collections;

[UnitMenu("ArrayList/Add Range")]
[UnitFriendlyName("ArrayList.Add Range")]
public class JLArrayListAddRange : JLAction
{
    [Parameter(ExpressionType = typeof(System.Collections.ArrayList))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Collections.ICollection))]
    public JLExpression C;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        System.Collections.ArrayList opValue = OperandValue.GetResult<System.Collections.ArrayList>(context);
        opValue.AddRange(C.GetResult<System.Collections.ICollection>(context));
        return null;
    }
}
