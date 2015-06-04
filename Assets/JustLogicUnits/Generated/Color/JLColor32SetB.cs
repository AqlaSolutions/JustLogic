using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Color/Set B (Color32)")]
[UnitFriendlyName("Color32.Set B")]
[UnitUsage(typeof(System.Byte))]
public class JLColor32SetB : JLExpression
{
    [Parameter(ExpressionType = typeof(Color32))]
    public JLExpression Target;

    [Parameter(ExpressionType = typeof(System.Byte))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        Color32 opValue = Target.GetResult<Color32>(context);
        return opValue.b = Value.GetResult<System.Byte>(context);
    }
}
