using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Object/Get Gui Texture")]
[UnitFriendlyName("Get Gui Texture")]
[UnitUsage(typeof(GUITexture), HideExpressionInActionsList = true)]
public class JLGameObjectGetGuiTexture : JLExpression
{
    [Parameter(ExpressionType = typeof(GameObject))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        GameObject opValue = OperandValue.GetResult<GameObject>(context);
        return opValue.GetComponent<GUITexture>();
    }
}
