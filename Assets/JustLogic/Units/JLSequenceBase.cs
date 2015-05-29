using System;
using System.Collections.Generic;
using System.Reflection;
using JustLogic.Core;
using UnityEngine;

public abstract class JLSequenceBase : JLAction
{
    [Parameter]
    public JLAction[] Actions;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        for (int i = 0; i < Actions.Length; i++)
        {
#if JUSTLOGIC_FREE
            if (i >= 5)
            {
                Debug.LogError("JustLogic: Maximum 5 actions in sequence are available for the free version");
                yield break;
            }
#endif

            using (var enumerator = Actions[i].ExecuteSafe(context))
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
#if JUSTLOGIC_FREE
        yield break;
#endif

    }
}
