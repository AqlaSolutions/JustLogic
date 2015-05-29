using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("WWW/Get Audio Clip")]
[UnitFriendlyName("WWW.Get Audio Clip")]
[UnitUsage(typeof(UnityEngine.AudioClip), HideExpressionInActionsList = true)]
public class JLWwwGetAudioClip4 : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.WWW))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Boolean))]
    public JLExpression ThreeD;

    [Parameter(ExpressionType = typeof(System.Boolean))]
    public JLExpression Stream;

    [Parameter(ExpressionType = typeof(UnityEngine.AudioType))]
    public JLExpression AudioType;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.WWW opValue = OperandValue.GetResult<UnityEngine.WWW>(context);
        return opValue.GetAudioClip(ThreeD.GetResult<System.Boolean>(context), Stream.GetResult<System.Boolean>(context), AudioType.GetResult<UnityEngine.AudioType>(context));
    }
}
