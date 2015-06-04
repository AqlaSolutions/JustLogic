using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Transform/Translate")]
[UnitFriendlyName("Translate")]
public class JLTransformTranslate : JLAction
{
    [Parameter(ExpressionType = typeof(Transform))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression Translation;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        Transform opValue = OperandValue.GetResult<Transform>(context);
        opValue.Translate(Translation.GetResult<Vector3>(context));
        return null;    }
}
