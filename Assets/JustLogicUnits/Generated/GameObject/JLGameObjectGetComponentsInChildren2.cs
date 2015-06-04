using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Object/Get Components In Children")]
[UnitFriendlyName("Get Components In Children")]
[UnitUsage(typeof(Component[]), HideExpressionInActionsList = true)]
public class JLGameObjectGetComponentsInChildren2 : JLExpression
{
    [Parameter(ExpressionType = typeof(GameObject))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Type))]
    public JLExpression Type;

    [Parameter(ExpressionType = typeof(System.Boolean))]
    public JLExpression IncludeInactive;

    public override object GetAnyResult(IExecutionContext context)
    {
        GameObject opValue = OperandValue.GetResult<GameObject>(context);
        return opValue.GetComponentsInChildren(Type.GetResult<System.Type>(context), IncludeInactive.GetResult<System.Boolean>(context));
    }
}
