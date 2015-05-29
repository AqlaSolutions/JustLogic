using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Object/Get Rigidbody")]
[UnitFriendlyName("Get Rigidbody")]
[UnitUsage(typeof(UnityEngine.Rigidbody), HideExpressionInActionsList = true)]
public class JLGameObjectGetRigidbody : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.GameObject))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.GameObject opValue = OperandValue.GetResult<UnityEngine.GameObject>(context);
        return opValue.GetComponent<Rigidbody>();
    }
}
