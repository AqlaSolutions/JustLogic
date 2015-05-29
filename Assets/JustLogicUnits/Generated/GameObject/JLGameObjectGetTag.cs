using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Object/Get Tag")]
[UnitFriendlyName("Get Tag")]
[UnitUsage(typeof(System.String), HideExpressionInActionsList = true)]
public class JLGameObjectGetTag : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.GameObject))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.GameObject opValue = OperandValue.GetResult<UnityEngine.GameObject>(context);
        return opValue.tag;
    }
}
