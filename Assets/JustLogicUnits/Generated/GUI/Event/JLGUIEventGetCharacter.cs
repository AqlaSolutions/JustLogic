using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUI/Event/Get Character")]
[UnitFriendlyName("GUIEvent.Get Character")]
[UnitUsage(typeof(System.Char), HideExpressionInActionsList = true)]
public class JLGUIEventGetCharacter : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Event))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Event opValue = OperandValue.GetResult<UnityEngine.Event>(context);
        return opValue.character;
    }
}
