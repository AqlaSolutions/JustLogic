using System;
using JustLogic.Core;
using UnityEngine;

[UnitMenu("Time/Get Date Time")]
[UnitUsage(typeof(DateTime), HideExpressionInActionsList = true)]
public class JLGetDateTime : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return DateTime.Now;
    }
}
