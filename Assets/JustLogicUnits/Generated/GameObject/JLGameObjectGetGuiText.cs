using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Object/Get Gui Text")]
[UnitFriendlyName("Get Gui Text")]
[UnitUsage(typeof(GUIText), HideExpressionInActionsList = true)]
public class JLGameObjectGetGuiText : JLExpression
{
    [Parameter(ExpressionType = typeof(GameObject))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        GameObject opValue = OperandValue.GetResult<GameObject>(context);
        return opValue.GetComponent<GUIText>();
    }
}
