using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Input/Set Eat Key Press On Text Field Focus")]
[UnitFriendlyName("Set Eat Key Press On Text Field Focus")]
[UnitUsage(typeof(System.Boolean))]
public class JLInputSetEatKeyPressOnTextFieldFocus : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Boolean))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
#pragma warning disable 618
        return Input.eatKeyPressOnTextFieldFocus = Value.GetResult<System.Boolean>(context);
#pragma warning restore 618
    }
}
