using JustLogic.Core;
using System.Collections.Generic;
using System.Collections;

[UnitMenu("ArrayList/Remove")]
[UnitFriendlyName("ArrayList.Remove")]
public class JLArrayListRemove : JLAction
{
    [Parameter(ExpressionType = typeof(ArrayList))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(object))]
    public JLExpression Obj;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        ArrayList opValue = OperandValue.GetResult<ArrayList>(context);
        opValue.Remove(Obj.GetResult<object>(context));
        return null;
    }
}
