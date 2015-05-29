using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Application/Level/Can Streamed Level Be Loaded By Index")]
[UnitFriendlyName("Can Streamed Level Be Loaded By Index")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLAppCanStreamedLevelBeLoaded : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression LevelIndex;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Application.CanStreamedLevelBeLoaded(LevelIndex.GetResult<System.Int32>(context));
    }
}
