#if !JUSTLOGIC_FREE
using System;
using System.Collections;
using System.Collections.Generic;
using JustLogic.Core;
using UnityEngine;

[UnitMenu("External/Trigger Script")]
public class JLTriggerJLScript : JLAction
{
    [Parameter]
    public JustLogicScriptBase Value;

    [Parameter(ExpressionType = typeof(float))]
    public JLExpression Timer;

    [Parameter]
    public bool TimerUsesRealTime;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        var t = Timer.GetResult<float>(context);
        if (t < float.Epsilon)
            Value.StartExecution();
        else
            context.ExecutorBehavior.StartCoroutine(Coroutine(Value, t, TimerUsesRealTime));
        yield break;
    }

    static IEnumerator Coroutine(JustLogicScriptBase script, float timer, bool realTime)
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
        if (script)
            script.StartExecution();
    }
}

#endif
