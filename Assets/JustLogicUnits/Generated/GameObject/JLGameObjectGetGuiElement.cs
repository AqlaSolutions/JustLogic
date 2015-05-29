/*using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Object/Get Gui Element")]
[UnitFriendlyName("Get Gui Element")]
[UnitUsage(typeof(UnityEngine.GUIElement), HideExpressionInActionsList = true)]
public class JLGameObjectGetGuiElement : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.GameObject))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.GameObject opValue = OperandValue.GetResult<UnityEngine.GameObject>(context);
        return opValue.guiElement;
    }
}
*/