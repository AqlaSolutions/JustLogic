using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Object/Get Rigidbody")]
[UnitFriendlyName("Get Rigidbody")]
[UnitUsage(typeof(Rigidbody), HideExpressionInActionsList = true)]
public class JLGameObjectGetRigidbody : JLExpression
{
    [Parameter(ExpressionType = typeof(GameObject))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        GameObject opValue = OperandValue.GetResult<GameObject>(context);
        return opValue.GetComponent<Rigidbody>();
    }
}
