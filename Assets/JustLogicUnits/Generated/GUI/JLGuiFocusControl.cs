using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUI/FocusControl")]
[UnitFriendlyName("GUI.FocusControl")]
public class JLGuiFocusControl : JLAction
{
    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Name;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        UnityEngine.GUI.FocusControl(Name.GetResult<System.String>(context));
        return null;
    }
}
