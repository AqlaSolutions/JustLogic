using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Debug/Log Error")]
[UnitFriendlyName("Log Error")]
public class JLDebugLogError : JLAction
{
    [Parameter(ExpressionType = typeof(object))]
    public JLExpression Message;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        UnityEngine.Debug.LogError(Message.GetResult<object>(context));
        return null;
    }
}
