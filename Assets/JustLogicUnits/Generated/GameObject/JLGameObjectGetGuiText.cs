using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Object/Get Gui Text")]
[UnitFriendlyName("Get Gui Text")]
[UnitUsage(typeof(UnityEngine.GUIText), HideExpressionInActionsList = true)]
public class JLGameObjectGetGuiText : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.GameObject))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.GameObject opValue = OperandValue.GetResult<UnityEngine.GameObject>(context);
        return opValue.GetComponent<GUIText>();
    }
}
