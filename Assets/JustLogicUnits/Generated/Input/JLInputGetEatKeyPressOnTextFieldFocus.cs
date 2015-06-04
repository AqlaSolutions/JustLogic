using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Input/Get Eat Key Press On Text Field Focus")]
[UnitFriendlyName("Get Eat Key Press On Text Field Focus")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLInputGetEatKeyPressOnTextFieldFocus : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return Input.eatKeyPressOnTextFieldFocus;
    }
}
