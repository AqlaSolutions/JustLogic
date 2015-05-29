using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUI/Event/Get Type For Control")]
[UnitFriendlyName("GUIEvent.Get Type For Control")]
[UnitUsage(typeof(UnityEngine.EventType), HideExpressionInActionsList = true)]
public class JLGUIEventGetTypeForControl : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Event))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression ControlID;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Event opValue = OperandValue.GetResult<UnityEngine.Event>(context);
        return opValue.GetTypeForControl(ControlID.GetResult<System.Int32>(context));
    }
}
