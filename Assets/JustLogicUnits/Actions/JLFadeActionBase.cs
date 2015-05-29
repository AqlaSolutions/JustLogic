#if !JUSTLOGIC_FREE
using System.Collections.Generic;
using JustLogic.Core;
using UnityEngine;

public abstract class JLFadeActionBase : JLAction
{
    [Parameter(ExpressionType = typeof(float))]
    public JLExpression Value;

    [Parameter(ExpressionType = typeof(float))]
    public JLExpression Duration;

    protected abstract float ControlledValue { get; set; }

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        float time = 0f;
        var dur = Duration.GetResult<float>(context);
        float start = ControlledValue;
        float end = Value.GetResult<float>(context);
        while (time < dur - float.Epsilon)
        {
            yield return YieldMode.YieldForNextUpdate;
            time += Time.deltaTime;
            ControlledValue = Mathf.Lerp(start, end, Mathf.Clamp01(time / dur));
        }
        ControlledValue = end;
    }
}

#endif
