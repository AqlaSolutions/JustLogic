#if !JUSTLOGIC_FREE
using System.Collections.Generic;
using JustLogic.Core;
using UnityEngine;


[UnitMenu("Object/Move")]
public class JLMoveObject : JLAction
{
    [Parameter(ExpressionType = typeof(Transform))]
    public JLExpression Object;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression Direction;

    [Parameter(ExpressionType = typeof(float))]
    public JLExpression Duration;

    [Parameter]
    public bool Relative = true;

    [Parameter]
    public bool UseFixedUpdate;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        var tr = Object.GetResult<Transform>(context);
        var dir = Direction.GetResult<Vector3>(context);

        float time = 0f;
        var dur = Duration.GetResult<float>(context);
        do
        {
            time += Time.deltaTime;
            var d = dir * Mathf.Clamp01(Time.deltaTime / dur);
            if (Relative)
                tr.position += tr.TransformDirection(d);
            else
                tr.position += d;
            if (time >= dur - float.Epsilon) break;
            yield return UseFixedUpdate ? YieldMode.YieldForNextFixedUpdate : YieldMode.YieldForNextUpdate;
        } while (true);
    }
}

#endif
