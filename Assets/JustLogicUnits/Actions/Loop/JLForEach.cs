#if !JUSTLOGIC_FREE
using System;
using System.Collections;
using System.Collections.Generic;
using JustLogic.Core;
using UnityEngine;

[UnitMenu("Loop/For Each")]
public class JLForEach : JLAction
{
    [Parameter(ExpressionType = typeof(IEnumerable))]
    public JLExpression Enumerable;

    [Parameter]
    public SelectedVariableInfo Storage;

    [Parameter]
    public JLAction Unit;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        var enumerable = Enumerable.GetResult<IEnumerable>(context).GetEnumerator();

        while (enumerable.MoveNext())
        {
            context.GetVariable(Storage).Value = enumerable.Current;
            if (!Unit) continue;
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
    }
}

#endif
