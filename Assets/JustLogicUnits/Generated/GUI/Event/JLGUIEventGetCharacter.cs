using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUI/Event/Get Character")]
[UnitFriendlyName("GUIEvent.Get Character")]
[UnitUsage(typeof(System.Char), HideExpressionInActionsList = true)]
public class JLGUIEventGetCharacter : JLExpression
{
    [Parameter(ExpressionType = typeof(Event))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Event opValue = OperandValue.GetResult<Event>(context);
        return opValue.character;
    }
}
