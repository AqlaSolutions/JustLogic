using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Object/Get Components")]
[UnitFriendlyName("Get Components")]
[UnitUsage(typeof(Component[]), HideExpressionInActionsList = true)]
public class JLGameObjectGetComponents : JLExpression
{
    [Parameter(ExpressionType = typeof(GameObject))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Type))]
    public JLExpression Type;

    public override object GetAnyResult(IExecutionContext context)
    {
        GameObject opValue = OperandValue.GetResult<GameObject>(context);
        return opValue.GetComponents(Type.GetResult<System.Type>(context));
    }
}
