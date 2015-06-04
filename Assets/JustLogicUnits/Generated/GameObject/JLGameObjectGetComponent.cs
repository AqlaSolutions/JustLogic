using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Object/Get Component")]
[UnitFriendlyName("Get Component")]
[UnitUsage(typeof(Component), HideExpressionInActionsList = true)]
public class JLGameObjectGetComponent : JLExpression
{
    [Parameter(ExpressionType = typeof(GameObject))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Type))]
    public JLExpression Type;

    public override object GetAnyResult(IExecutionContext context)
    {
        GameObject opValue = OperandValue.GetResult<GameObject>(context);
        return opValue.GetComponent(Type.GetResult<System.Type>(context));
    }
}
