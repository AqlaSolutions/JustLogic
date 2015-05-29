using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("WWW/New WWW")]
[UnitFriendlyName("WWW.New WWW")]
[UnitUsage(typeof(UnityEngine.WWW), HideExpressionInActionsList = true)]
public class JLWwwNewWWW : JLExpression
{
    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Url;

    public override object GetAnyResult(IExecutionContext context)
    {
        return new UnityEngine.WWW(Url.GetResult<System.String>(context));
    }
}
