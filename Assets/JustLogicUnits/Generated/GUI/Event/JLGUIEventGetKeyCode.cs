using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUI/Event/Get Key Code")]
[UnitFriendlyName("GUIEvent.Get Key Code")]
[UnitUsage(typeof(UnityEngine.KeyCode), HideExpressionInActionsList = true)]
public class JLGUIEventGetKeyCode : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Event))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Event opValue = OperandValue.GetResult<UnityEngine.Event>(context);
        return opValue.keyCode;
    }
}
