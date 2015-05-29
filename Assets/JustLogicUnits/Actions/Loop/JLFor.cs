#if !JUSTLOGIC_FREE
using System;
using System.Collections.Generic;
using JustLogic.Core;
using UnityEngine;

[UnitMenu("Loop/For")]
public class JLFor : JLAction
{
    [Parameter]
    public SelectedVariableInfo Variable;

    [Parameter(ExpressionType = typeof(int))]
    public JLExpression From;

    [Parameter(ExpressionType = typeof(int))]
    public JLExpression To;

    [Parameter]
    public bool StoreTo = true;

    [Parameter]
    public bool DecrementMode;

    [Parameter(ExpressionType = typeof(int), IsOptional = true)]
    public JLExpression Step;

    [Parameter]
    public JLAction Unit;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        int c = 0;
        int indexer = From.GetResult<int>(context);
        var v = context.GetVariable(Variable);
        v.Value = indexer;
        int to = StoreTo ? To.GetResult<int>(context) : 0;
        Func<int, int, bool> comparer = DecrementMode
            ? (Func<int, int, bool>)
             ((index, till) => index >= till)
            : (index, till) => index <= till;
        while (comparer(indexer, StoreTo ? to : To.GetResult<int>(context)))
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
                                c = 0;
                                break;
                            default:
                                throw new InvalidOperationException();
                        }
                    }
                }
            }

            if (Step)
                indexer += Mathf.Abs(Step.GetResult<int>(context)) * (DecrementMode ? -1 : 1);
            else
                indexer += DecrementMode ? -1 : 1;
            v.Value = indexer;
            if (++c > 100000)
                throw new TimeoutException();
        }
    }
}

#endif
