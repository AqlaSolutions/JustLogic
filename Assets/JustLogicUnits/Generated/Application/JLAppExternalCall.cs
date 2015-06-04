using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Application/External Call")]
[UnitMenu("External/App External Call")]
[UnitFriendlyName("External Call")]
public class JLAppExternalCall : JLAction
{
    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression FunctionName;

    [Parameter(ExpressionType = typeof(object))]
    public JLExpression[] Args;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        Application.ExternalCall(FunctionName.GetResult<System.String>(context), Args.GetResult<object>(context));
        return null;    }
}
