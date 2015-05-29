#if !JUSTLOGIC_FREE
using System.Collections;
using System.Collections.Generic;
using JustLogic.Core;
using UnityEngine;

[UnitFriendlyName("Invoke")]
[UnitMenu("External/Invoke")]
public class JLInvokeA : JLAction
{
    [Parameter]
    public MethodInvokation Invokation;

    [Parameter(ExpressionType = typeof(float))]
    public JLExpression Timer;

    [Parameter]
    public bool TimerUsesRealTime;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        var t = Timer.GetResult<float>(context);
        if (t < float.Epsilon)
            Invokation.Invoke(context);
        else
            context.ExecutorBehavior.StartCoroutine(Coroutine(Invokation, t, TimerUsesRealTime, context));
        yield break;
    }

    static IEnumerator Coroutine(MethodInvokationBase invokation, float timer, bool realTime, IExecutionContext context)
    {
        if (realTime)
        {
            float startTime = Time.realtimeSinceStartup;
            float newTime;
            do
            {
                yield return new WaitForEndOfFrame();
                newTime = Time.realtimeSinceStartup;
            }
            while ((newTime > startTime) && ((newTime - startTime) < timer));
        }
        else yield return new WaitForSeconds(timer);
        invokation.Invoke(context);
    }
}
#endif
