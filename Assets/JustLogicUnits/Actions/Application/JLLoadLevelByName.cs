using System.Collections.Generic;
using JustLogic.Core;
using UnityEngine;

[UnitMenu("Application/Level/Load by name")]
public class JLLoadLevelByName : JLAction
{
    [Parameter(ExpressionType = typeof(string))]
    public JLExpression Value;

    [Parameter]
    public bool Additive;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        var level = Value.GetResult<string>(context);
        if (Additive)
            Application.LoadLevelAdditive(level);
        else
            Application.LoadLevel(level);
        yield break;
    }
}
