#if !JUSTLOGIC_FREE
using System.Collections;
using System.Collections.Generic;
using JustLogic.Core;
using UnityEngine;

[UnitMenu("Time/Wait for real time")]
public class JLWaitForRealTime : JLAction
{
    [Parameter(ExpressionType = typeof(float))]
    public JLExpression Value;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        float startTime = Time.realtimeSinceStartup;
        float newTime;
        do
        {
            yield return YieldMode.YieldForNextUpdate;
            newTime = Time.realtimeSinceStartup;
        }
        while ((newTime > startTime) && ((newTime - startTime) < Value.GetResult<float>(context)));
    } 
}

#endif
