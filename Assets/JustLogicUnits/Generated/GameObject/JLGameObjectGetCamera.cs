using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Object/Get Camera")]
[UnitFriendlyName("Get Camera")]
[UnitUsage(typeof(UnityEngine.Camera), HideExpressionInActionsList = true)]
public class JLGameObjectGetCamera : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.GameObject))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.GameObject opValue = OperandValue.GetResult<UnityEngine.GameObject>(context);
        return opValue.GetComponent<Camera>();
    }
}
