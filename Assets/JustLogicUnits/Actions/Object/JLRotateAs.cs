#if !JUSTLOGIC_FREE
using System.Collections.Generic;
using JustLogic.Core;
using UnityEngine;

[UnitMenu("Object/Rotate As")]
public class JLRotateAs : JLAction
{
    [Parameter(ExpressionType = typeof(Transform))]
    public JLExpression Object;

    [Parameter(ExpressionType = typeof(Transform))]
    public JLExpression As;

    [Parameter(ExpressionType = typeof(float))]
    public JLExpression Duration;

    [Parameter]
    public bool UseFixedUpdate;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        var tr = Object.GetResult<Transform>(context);
        var @as = As.GetResult<Transform>(context);

        float time = 0f;
        var dur = Duration.GetResult<float>(context);
        do
        {
            time += Time.deltaTime;
            tr.rotation = Quaternion.Lerp(tr.rotation, @as.rotation, Mathf.Clamp01(time / dur));

            if (time >= dur - float.Epsilon) break;
            yield return UseFixedUpdate ? YieldMode.YieldForNextFixedUpdate : YieldMode.YieldForNextUpdate;
        } while (true);
    }
}

#endif
