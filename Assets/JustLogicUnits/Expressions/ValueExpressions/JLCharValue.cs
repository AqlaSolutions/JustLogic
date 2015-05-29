using JustLogic.Core;
using UnityEngine;

[UnitMenu("Value/Char")]
[UnitUsage(typeof(char), HideExpressionInActionsList = true, IsDefaultExpression = true)]
public class JLCharValue : JLExpression
{
    [Parameter(OverrideType = ParameterAttribute.OverrideTypes.Char)]
    public string Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Value[0];
    }
}
