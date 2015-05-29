/*using JustLogic.Core;
using System.Collections.Generic;
using System.Collections;

[UnitMenu("ArrayList/Repeat")]
[UnitFriendlyName("ArrayList.Repeat")]
[UnitUsage(typeof(System.Collections.ArrayList), HideExpressionInActionsList = true)]
public class JLArrayListRepeat : JLExpression
{
    [Parameter(ExpressionType = typeof(object))]
    public JLExpression Value;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression Count;

    public override object GetAnyResult(IExecutionContext context)
    {
        return System.Collections.ArrayList.Repeat(Value.GetResult<object>(context), Count.GetResult<System.Int32>(context));
    }
}
*/