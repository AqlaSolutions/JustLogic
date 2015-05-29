using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Application/Get Data Path")]
[UnitFriendlyName("Get Data Path")]
[UnitUsage(typeof(System.String), HideExpressionInActionsList = true)]
public class JLAppGetDataPath : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Application.dataPath;
    }
}
