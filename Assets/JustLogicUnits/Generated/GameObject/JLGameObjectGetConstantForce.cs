using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Object/Get Constant Force")]
[UnitFriendlyName("Get Constant Force")]
[UnitUsage(typeof(UnityEngine.ConstantForce), HideExpressionInActionsList = true)]
public class JLGameObjectGetConstantForce : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.GameObject))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.GameObject opValue = OperandValue.GetResult<UnityEngine.GameObject>(context);
        return opValue.GetComponent<ConstantForce>();
    }
}
