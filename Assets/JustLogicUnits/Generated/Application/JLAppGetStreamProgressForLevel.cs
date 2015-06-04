using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Application/Level/Get Stream Progress For Level By Name")]
[UnitFriendlyName("Get Stream Progress For Level")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLAppGetStreamProgressForLevel : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression LevelIndex;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Application.GetStreamProgressForLevel(LevelIndex.GetResult<System.Int32>(context));
    }
}
