#if !JUSTLOGIC_FREE
using System;
using System.Collections.Generic;
using JustLogic.Core;

[UnitMenu("Branch/Switch element")]
[UnitUsage(StrictApplicability = true)]
public class JLSwitchElement : JLAction
{
    /// <summary>
    /// Compare to
    /// </summary>
    [Parameter]
    public JLExpression Value;

    [Parameter]
    public JLAction Unit;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
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
                    case YieldMode.BreakLoop:
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

#endif
