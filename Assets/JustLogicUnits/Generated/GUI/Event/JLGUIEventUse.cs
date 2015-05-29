using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUI/Event/Use")]
[UnitFriendlyName("GUIEvent.Use")]
public class JLGUIEventUse : JLAction
{
    [Parameter(ExpressionType = typeof(UnityEngine.Event))]
    public JLExpression OperandValue;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        UnityEngine.Event opValue = OperandValue.GetResult<UnityEngine.Event>(context);
        opValue.Use();
        return null;
    }
}
