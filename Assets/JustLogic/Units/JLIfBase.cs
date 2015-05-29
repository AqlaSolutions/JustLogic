using System;
using System.Collections.Generic;
using JustLogic.Core;

public abstract class JLIfBase : JLAction
{
    [Parameter(ExpressionType = typeof(bool), DefaultUnitTypeName = "JLCompare")]
    public JLExpression Value;

    [Parameter]
    public JLAction Then;

    [Parameter]
    public JLAction Else;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        if (Value.GetResult<bool>(context))
        {
            if (Then)
            {
                using (var enumerator = Then.ExecuteSafe(context))
                {
                    while (enumerator.SafeMoveNext())
                    {
                        switch (enumerator.Current)
                        {
                            case YieldMode.None:
                                break;
#if !JUSTLOGIC_FREE

                            case YieldMode.ContinueLoop:
                            case YieldMode.BreakLoop:
                            case YieldMode.Return:
                            case YieldMode.ReturnScript:
                            case YieldMode.YieldForNextFixedUpdate:
                            case YieldMode.YieldForNextUpdate:
                                yield return enumerator.Current;
                                break;
#endif
                            default:
                                throw new InvalidOperationException();
                        }
                    }
                }
            }
        }
        else
        {
            if (Else)
            {
                using (var enumerator = Else.ExecuteSafe(context))
                {
                    while (enumerator.SafeMoveNext())
                    {
                        switch (enumerator.Current)
                        {

                            case YieldMode.None:
                                break;
#if !JUSTLOGIC_FREE

                            case YieldMode.Return:
                            case YieldMode.ReturnScript:
                            case YieldMode.YieldForNextFixedUpdate:
                            case YieldMode.YieldForNextUpdate:
                                yield return enumerator.Current;
                                break;
#endif

                            default:
                                throw new InvalidOperationException();
                        }
                    }
                }
            }
        }
#if JUSTLOGIC_FREE
        yield break;
#endif

    }
}
