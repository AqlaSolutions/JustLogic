using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUI/Event/Get Raw Type")]
[UnitFriendlyName("GUIEvent.Get Raw Type")]
[UnitUsage(typeof(UnityEngine.EventType), HideExpressionInActionsList = true)]
public class JLGUIEventGetRawType : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Event))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Event opValue = OperandValue.GetResult<UnityEngine.Event>(context);
        return opValue.rawType;
    }
}
