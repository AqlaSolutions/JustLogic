using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Object/Get Audio")]
[UnitFriendlyName("Get Audio")]
[UnitUsage(typeof(AudioSource), HideExpressionInActionsList = true)]
public class JLGameObjectGetAudio : JLExpression
{
    [Parameter(ExpressionType = typeof(GameObject))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        GameObject opValue = OperandValue.GetResult<GameObject>(context);
        return opValue.GetComponent<AudioSource>();
    }
}
