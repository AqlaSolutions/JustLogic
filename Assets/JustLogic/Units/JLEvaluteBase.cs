using System;
using System.Collections.Generic;
using JustLogic.Core;

public abstract class JLEvaluteBase : JLAction
{
    [Parameter]
    public JLExpression Expression;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        Expression.GetAnyResultSafe(context);
        yield break;
    }
}
