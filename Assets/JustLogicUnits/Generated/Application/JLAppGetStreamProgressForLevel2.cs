using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Application/Level/Get Stream Progress For Level By Index")]
[UnitFriendlyName("Get Stream Progress For Level")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLAppGetStreamProgressForLevel2 : JLExpression
{
    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression LevelName;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Application.GetStreamProgressForLevel(LevelName.GetResult<System.String>(context));
    }
}
