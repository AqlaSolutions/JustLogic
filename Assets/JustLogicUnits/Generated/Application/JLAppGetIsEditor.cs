using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Application/Get Is Editor")]
[UnitFriendlyName("Get Is Editor")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLAppGetIsEditor : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Application.isEditor;
    }
}
