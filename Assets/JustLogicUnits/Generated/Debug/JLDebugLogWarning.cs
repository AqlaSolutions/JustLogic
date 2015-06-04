using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Debug/Log Warning")]
[UnitFriendlyName("Log Warning")]
public class JLDebugLogWarning : JLAction
{
    [Parameter(ExpressionType = typeof(object))]
    public JLExpression Message;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        Debug.LogWarning(Message.GetResult<object>(context));
        return null;
    }
}
