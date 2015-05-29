#if !JUSTLOGIC_FREE
using System.Collections.Generic;
using JustLogic.Core;
using UnityEngine;

[UnitMenu("Object/Move At Position")]
public class JLMoveObjectAtPosition : JLAction
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
        Vector3 start = tr.position;
        while (time < dur - float.Epsilon)
        {
            yield return UseFixedUpdate ? YieldMode.YieldForNextFixedUpdate : YieldMode.YieldForNextUpdate;
            time += Time.deltaTime;
            SetPosition(tr, pos, basePoint, start, Mathf.Clamp01(time / dur));
        }
        SetPosition(tr, pos, basePoint, start, 1f);
    }

    static void SetPosition(Transform tr, Vector3 position, Transform basePoint, Vector3 startPosition, float lerp)
    {
        if (basePoint)
            position += basePoint.position;
        tr.position = Vector3.Lerp(startPosition, position, lerp);
    }
}

#endif
