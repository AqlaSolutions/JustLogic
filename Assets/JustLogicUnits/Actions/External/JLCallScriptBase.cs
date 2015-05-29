#if !JUSTLOGIC_FREE
using System;
using System.Collections.Generic;
using JustLogic.Core;

public abstract class JLCallScriptBase : JLAction
{
    protected abstract IEnumerator<YieldMode> CreateEnumerator(IExecutionContext context);

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        using (var enumerator = CreateEnumerator(context))
        {
            while (enumerator.SafeMoveNext())
            {
                switch (enumerator.Current)
                {
                    case YieldMode.None:
                        break;

                    case YieldMode.ReturnScript:
                        yield break;
                    case YieldMode.ContinueLoop:
                    case YieldMode.BreakLoop:
                    case YieldMode.Return:
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
