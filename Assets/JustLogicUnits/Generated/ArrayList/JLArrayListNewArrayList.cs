using JustLogic.Core;
using System.Collections.Generic;
using System.Collections;

[UnitMenu("ArrayList/New Array List")]
[UnitFriendlyName("ArrayList.New Array List")]
[UnitUsage(typeof(System.Collections.ArrayList), HideExpressionInActionsList = true)]
public class JLArrayListNewArrayList : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return new System.Collections.ArrayList();
    }
}
