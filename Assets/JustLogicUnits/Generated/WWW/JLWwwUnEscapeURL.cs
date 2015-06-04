using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("WWW/Un Escape URL")]
[UnitFriendlyName("WWW.Un Escape URL")]
[UnitUsage(typeof(System.String), HideExpressionInActionsList = true)]
public class JLWwwUnEscapeURL : JLExpression
{
    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression S;

    public override object GetAnyResult(IExecutionContext context)
    {
        return WWW.UnEscapeURL(S.GetResult<System.String>(context));
    }
}
