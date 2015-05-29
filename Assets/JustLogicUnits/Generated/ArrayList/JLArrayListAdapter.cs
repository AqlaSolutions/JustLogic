/*using JustLogic.Core;
using System.Collections.Generic;
using System.Collections;

[UnitMenu("ArrayList/Adapter")]
[UnitFriendlyName("ArrayList.Adapter")]
[UnitUsage(typeof(System.Collections.ArrayList), HideExpressionInActionsList = true)]
public class JLArrayListAdapter : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Collections.IList))]
    public JLExpression List;

    public override object GetAnyResult(IExecutionContext context)
    {
        return System.Collections.ArrayList.Adapter(List.GetResult<System.Collections.IList>(context));
    }
}
*/