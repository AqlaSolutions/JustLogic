using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Color/Get Gray")]
[UnitFriendlyName("Color.Get Gray")]
[UnitUsage(typeof(Color), HideExpressionInActionsList = true)]
public class JLColorGetGray : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return Color.gray;
    }
}
