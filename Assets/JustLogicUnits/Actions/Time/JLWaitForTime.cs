#if !JUSTLOGIC_FREE
using System.Collections.Generic;
using JustLogic.Core;
using UnityEngine;

[UnitMenu("Time/Wait for game time")]
public class JLWaitForTime : JLAction
{
    [Parameter(ExpressionType = typeof(float))]
    public JLExpression Value;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        float duration=0f;
        do
        {
            yield return YieldMode.YieldForNextUpdate;
            duration += Time.deltaTime;
        }
        while (duration < Value.GetResult<float>(context));
    }
}

#endif
