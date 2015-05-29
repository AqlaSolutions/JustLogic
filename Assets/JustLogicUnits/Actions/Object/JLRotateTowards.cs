#if !JUSTLOGIC_FREE
using System.Collections.Generic;
using JustLogic.Core;
using UnityEngine;

[UnitMenu("Object/Rotate Towards")]
public class JLRotateTowards : JLAction
{
    [Parameter(ExpressionType = typeof(Transform))]
    public JLExpression Object;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression Position;

    [Parameter(ExpressionType = typeof(Transform), IsOptional = true)]
    public JLExpression RelativeTo;

    [Parameter(ExpressionType = typeof(float))]
    public JLExpression Duration;

    [Parameter]
    public bool UseFixedUpdate;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        var basePoint = RelativeTo.GetResult<Transform>(context);
        var tr = Object.GetResult<Transform>(context);
        var pos = Position.GetResult<Vector3>(context);

        float time = 0f;
        var dur = Duration.GetResult<float>(context);
        Quaternion start = tr.rotation;
        while (time < dur - float.Epsilon)
        {
            yield return UseFixedUpdate ? YieldMode.YieldForNextFixedUpdate : YieldMode.YieldForNextUpdate;
            time += Time.deltaTime;
            SetRotation(tr, pos, basePoint, start, Mathf.Clamp01(time / dur));
        }
        SetRotation(tr, pos, basePoint, start, 1f);
    }

    static void SetRotation(Transform tr, Vector3 position, Transform basePoint, Quaternion startRotation, float lerp)
    {
        if (basePoint)
            position += basePoint.position;
        tr.rotation = Quaternion.Lerp(startRotation, Quaternion.LookRotation(position - tr.position), lerp);

    }
}

#endif
