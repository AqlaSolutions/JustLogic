using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Application/Get Src Value")]
[UnitFriendlyName("Get Src Value")]
[UnitUsage(typeof(System.String), HideExpressionInActionsList = true)]
public class JLAppGetSrcValue : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return Application.srcValue;
    }
}
