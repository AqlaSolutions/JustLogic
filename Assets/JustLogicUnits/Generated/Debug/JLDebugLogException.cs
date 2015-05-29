using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Debug/Log Exception")]
[UnitFriendlyName("Log Exception")]
public class JLDebugLogException : JLAction
{
    [Parameter(ExpressionType = typeof(System.Exception))]
    public JLExpression Exception;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        UnityEngine.Debug.LogException(Exception.GetResult<System.Exception>(context));
        return null;
    }
}
