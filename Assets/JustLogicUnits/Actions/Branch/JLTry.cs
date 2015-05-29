#if !JUSTLOGIC_FREE
using System;
using System.Collections;
using System.Collections.Generic;
using JustLogic.Core;

[UnitMenu("Branch/Exception/Try")]
public class JLTry : JLAction
{
    [Parameter]
    public JLAction Unit;

    [Parameter]
    public JLAction Catch;

    [Parameter]
    public JLAction Finally;

    bool Execute(Func<bool> action, IExecutionContext context)
    {
        try
        {
            return action();
        }
        catch (Exception ex)
        {
            JLLastException.Exception = ex;

            if (!Catch)
                throw;

            using (var enumerator = Catch.ExecuteSafe(context))
            {
                while (enumerator.SafeMoveNext())
                {
                    switch (enumerator.Current)
                    {
                        case YieldMode.None:
                            break;
                        default:
                            throw new InvalidOperationException();
                    }
                }
            }

            return false;
        }
        finally
        {
            if (Finally)
                using (var enumerator = Finally.ExecuteSafe(context))
                {
                    while (enumerator.SafeMoveNext())
                    {
                        switch (enumerator.Current)
                        {
                            case YieldMode.None:
                                break;
                            default:
                                throw new InvalidOperationException();
                        }
                    }
                }
        }
    }

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        IEnumerator<YieldMode> enumerator = null;
        if (!Execute(() => { enumerator = Unit.ExecuteSafe(context); return true; }, context))
            yield break;
        if (enumerator != null)
            using (enumerator)
            {
                // ReSharper disable AccessToDisposedClosure
                while (Execute(enumerator.MoveNext, context))
                // ReSharper restore AccessToDisposedClosure
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
                            yield break;
                        default:
                            throw new InvalidOperationException();
                    }
                }
            }
    }
}

#endif
