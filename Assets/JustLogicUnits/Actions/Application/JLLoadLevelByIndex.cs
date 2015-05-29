using System.Collections.Generic;
using JustLogic.Core;
using UnityEngine;

[UnitMenu("Application/Level/Load by index")]
public class JLLoadLevelByIndex : JLAction
{
    [Parameter(ExpressionType = typeof(int))]
    public JLExpression Value;

    [Parameter]
    public bool Additive;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        var level = Value.GetResult<int>(context);
        if (Additive)
            Application.LoadLevelAdditive(level);
        else
            Application.LoadLevel(level);
        yield break;
    }
}
