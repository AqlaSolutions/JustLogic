using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("External/Broadcast Message")]
[UnitFriendlyName("Broadcast Message")]
public class JLGameObjectBroadcastMessage2 : JLAction
{
    [Parameter(ExpressionType = typeof(GameObject))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression MethodName;

    [Parameter]
    public bool WithArgument;

    [Parameter(ExpressionType = typeof(object))]
    public JLExpression Argument;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        GameObject opValue = OperandValue.GetResult<GameObject>(context);
        if (WithArgument)
            opValue.BroadcastMessage(MethodName.GetResult<System.String>(context), Argument.GetResult<object>(context), SendMessageOptions.DontRequireReceiver);
        else
            opValue.BroadcastMessage(MethodName.GetResult<System.String>(context), SendMessageOptions.DontRequireReceiver);
        return null;
    }
}
