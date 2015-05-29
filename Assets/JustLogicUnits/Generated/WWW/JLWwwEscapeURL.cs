using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("WWW/Escape URL")]
[UnitFriendlyName("WWW.Escape URL")]
[UnitUsage(typeof(System.String), HideExpressionInActionsList = true)]
public class JLWwwEscapeURL : JLExpression
{
    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression S;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.WWW.EscapeURL(S.GetResult<System.String>(context));
    }
}
