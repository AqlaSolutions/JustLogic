#if !JUSTLOGIC_FREE
using System;
using System.Collections.Generic;
using JustLogic.Core;
using UnityEngine;

[UnitMenu("Loop/Simple For")]
public class JLSimpleFor : JLAction
{
    [Parameter(ExpressionType = typeof(int))]
    public JLExpression Count;

    [Parameter]
    public JLAction Unit;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        int indexer = 0;
        int to = Count.GetResult<int>(context) - 1;
        while (indexer <= to)
        {
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
                                break;
                            default:
                                throw new InvalidOperationException();
                        }
                    }
                }
            }

            indexer++;
        }
    }
}

#endif
