using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Object/Get Layer")]
[UnitFriendlyName("Get Layer")]
[UnitUsage(typeof(System.Int32), HideExpressionInActionsList = true)]
public class JLGameObjectGetLayer : JLExpression
{
    [Parameter(ExpressionType = typeof(GameObject))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        GameObject opValue = OperandValue.GetResult<GameObject>(context);
        return opValue.layer;
    }
}
