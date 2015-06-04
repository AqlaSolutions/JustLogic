using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Object/Compare Tag")]
[UnitFriendlyName("Compare Tag")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLGameObjectCompareTag : JLExpression
{
    [Parameter(ExpressionType = typeof(GameObject))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Tag;

    public override object GetAnyResult(IExecutionContext context)
    {
        GameObject opValue = OperandValue.GetResult<GameObject>(context);
        return opValue.CompareTag(Tag.GetResult<System.String>(context));
    }
}
