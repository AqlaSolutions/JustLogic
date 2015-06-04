using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Color/Set G (Color32)")]
[UnitFriendlyName("Color32.Set G")]
[UnitUsage(typeof(System.Byte))]
public class JLColor32SetG : JLExpression
{
    [Parameter(ExpressionType = typeof(Color32))]
    public JLExpression Target;

    [Parameter(ExpressionType = typeof(System.Byte))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        Color32 opValue = Target.GetResult<Color32>(context);
        return opValue.g = Value.GetResult<System.Byte>(context);
    }
}
