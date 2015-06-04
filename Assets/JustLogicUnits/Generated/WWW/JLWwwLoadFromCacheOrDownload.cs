using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("WWW/Load From Cache Or Download")]
[UnitFriendlyName("WWW.Load From Cache Or Download")]
[UnitUsage(typeof(WWW), HideExpressionInActionsList = true)]
public class JLWwwLoadFromCacheOrDownload : JLExpression
{
    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Url;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression Version;

    public override object GetAnyResult(IExecutionContext context)
    {
        return WWW.LoadFromCacheOrDownload(Url.GetResult<System.String>(context), Version.GetResult<System.Int32>(context));
    }
}
