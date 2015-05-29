#if !JUSTLOGIC_FREE
using System;
using System.Collections.Generic;
using JustLogic.Core;

[UnitMenu("Branch/Exception/Throw")]
public class JLThrow : JLAction
{
    [Parameter(ExpressionType = typeof(Exception))]
    public JLExpression Exception;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        if (Exception == null)
            throw JLLastException.Exception;
        throw Exception.GetResult<Exception>(context);

    }
}

#endif
