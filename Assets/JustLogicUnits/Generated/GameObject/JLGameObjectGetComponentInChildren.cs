using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Object/Get Component In Children")]
[UnitFriendlyName("Get Component In Children")]
[UnitUsage(typeof(UnityEngine.Component), HideExpressionInActionsList = true)]
public class JLGameObjectGetComponentInChildren : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.GameObject))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Type))]
    public JLExpression Type;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.GameObject opValue = OperandValue.GetResult<UnityEngine.GameObject>(context);
        return opValue.GetComponentInChildren(Type.GetResult<System.Type>(context));
    }
}
