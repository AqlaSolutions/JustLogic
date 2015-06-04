using JustLogic.Core;
using System.Collections.Generic;
using System.Collections;

[UnitMenu("ArrayList/Sort")]
[UnitFriendlyName("ArrayList.Sort")]
public class JLArrayListSort : JLAction
{
    [Parameter(ExpressionType = typeof(ArrayList))]
    public JLExpression OperandValue;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        ArrayList opValue = OperandValue.GetResult<ArrayList>(context);
        opValue.Sort();
        return null;
    }
}
