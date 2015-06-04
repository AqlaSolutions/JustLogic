using JustLogic.Core;
using System.Collections.Generic;
using System.Collections;

[UnitMenu("ArrayList/New Array List")]
[UnitFriendlyName("ArrayList.New Array List")]
[UnitUsage(typeof(ArrayList), HideExpressionInActionsList = true)]
public class JLArrayListNewArrayList : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return new ArrayList();
    }
}
