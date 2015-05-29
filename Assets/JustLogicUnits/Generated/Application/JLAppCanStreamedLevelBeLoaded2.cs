using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Application/Level/Can Streamed Level Be Loaded By Name")]
[UnitFriendlyName("Can Streamed Level Be Loaded By Name")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLAppCanStreamedLevelBeLoaded2 : JLExpression
{
    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression LevelName;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Application.CanStreamedLevelBeLoaded(LevelName.GetResult<System.String>(context));
    }
}
