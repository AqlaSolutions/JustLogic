#if !JUSTLOGIC_FREE
using System;
using System.Collections.Generic;
using JustLogic.Core;

[UnitMenu("Loop/While")]
public class JLWhile : JLAction
{
    [Parameter(ExpressionType = typeof(bool))]
    public JLExpression PreCondition;

    [Parameter]
    public JLAction Unit;

    [Parameter(ExpressionType = typeof(bool))]
    public JLExpression PostCondition;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        int i = 0;
        while (!PreCondition || PreCondition.GetResult<bool>(context))
        {
            if (!PreCondition && !PostCondition) yield break;
            if (Unit)
            {
                using (var enumerator = Unit.ExecuteSafe(context))
                {
                    while (enumerator.SafeMoveNext())
                    {
                        switch (enumerator.Current)
                        {
                            case YieldMode.None:
                                break;
                            case YieldMode.ContinueLoop:
                                continue;
                            case YieldMode.BreakLoop:
                                yield break;
                            case YieldMode.Return:
                            case YieldMode.ReturnScript:
                            case YieldMode.YieldForNextFixedUpdate:
                            case YieldMode.YieldForNextUpdate:
                                yield return enumerator.Current;
                                i = 0;
                                break;
                            default:
                                throw new InvalidOperationException();
                        }
                    }
                }
            }

            if (++i > 10000)
                throw new TimeoutException();

            if (PostCondition && !PostCondition.GetResult<bool>(context))
                yield break;
        }
    }
}

#endif
