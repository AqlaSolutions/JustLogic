using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUI/Event/Get Caps Lock")]
[UnitFriendlyName("GUIEvent.Get Caps Lock")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLGUIEventGetCapsLock : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Event))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Event opValue = OperandValue.GetResult<UnityEngine.Event>(context);
        return opValue.capsLock;
    }
}
