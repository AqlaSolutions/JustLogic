#if !JUSTLOGIC_FREE
using System;
using JustLogic.Core;

[UnitMenu("Branch/Exception/Get Last")]
[UnitUsage(typeof(Exception),HideExpressionInActionsList = true)]
public class JLLastException : JLExpression
{
    public static Exception Exception;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Exception;
    }
}

#endif
