using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Object/Get Component")]
[UnitFriendlyName("Get Component")]
[UnitUsage(typeof(UnityEngine.Component), HideExpressionInActionsList = true)]
public class JLGameObjectGetComponent : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.GameObject))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Type))]
    public JLExpression Type;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.GameObject opValue = OperandValue.GetResult<UnityEngine.GameObject>(context);
        return opValue.GetComponent(Type.GetResult<System.Type>(context));
    }
}
