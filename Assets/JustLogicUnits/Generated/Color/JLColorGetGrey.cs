using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Color/Get Grey")]
[UnitFriendlyName("Color.Get Grey")]
[UnitUsage(typeof(UnityEngine.Color), HideExpressionInActionsList = true)]
public class JLColorGetGrey : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Color.grey;
    }
}
