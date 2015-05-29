using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Object/Get Audio")]
[UnitFriendlyName("Get Audio")]
[UnitUsage(typeof(UnityEngine.AudioSource), HideExpressionInActionsList = true)]
public class JLGameObjectGetAudio : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.GameObject))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.GameObject opValue = OperandValue.GetResult<UnityEngine.GameObject>(context);
        return opValue.GetComponent<AudioSource>();
    }
}
