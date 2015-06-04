using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUI/Event/Use")]
[UnitFriendlyName("GUIEvent.Use")]
public class JLGUIEventUse : JLAction
{
    [Parameter(ExpressionType = typeof(Event))]
    public JLExpression OperandValue;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        Event opValue = OperandValue.GetResult<Event>(context);
        opValue.Use();
        return null;
    }
}
