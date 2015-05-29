using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUI/SetNextControlName")]
[UnitFriendlyName("GUI.SetNextControlName")]
public class JLGuiSetNextControlName : JLAction
{
    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Name;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        UnityEngine.GUI.SetNextControlName(Name.GetResult<System.String>(context));
        return null;
    }
}
