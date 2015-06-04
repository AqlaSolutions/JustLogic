using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Object/Get Constant Force")]
[UnitFriendlyName("Get Constant Force")]
[UnitUsage(typeof(ConstantForce), HideExpressionInActionsList = true)]
public class JLGameObjectGetConstantForce : JLExpression
{
    [Parameter(ExpressionType = typeof(GameObject))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        GameObject opValue = OperandValue.GetResult<GameObject>(context);
        return opValue.GetComponent<ConstantForce>();
    }
}
