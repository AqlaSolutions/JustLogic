using JustLogic.Core;
using System.Collections.Generic;
using System.Collections;

[UnitMenu("ArrayList/Add Range")]
[UnitFriendlyName("ArrayList.Add Range")]
public class JLArrayListAddRange : JLAction
{
    [Parameter(ExpressionType = typeof(ArrayList))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(ICollection))]
    public JLExpression C;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        ArrayList opValue = OperandValue.GetResult<ArrayList>(context);
        opValue.AddRange(C.GetResult<ICollection>(context));
        return null;
    }
}
