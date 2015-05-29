using System;
using JustLogic.Core;

[UnitMenu("Value/Enum (auto type)")]
[UnitUsage(typeof(Enum), AllowBaseAssignability = true, HideExpressionInActionsList = true, IsDefaultExpression = true)]
public class JLEnumIntValue : JLExpression
{
    [Parameter(UseContainerExpressionType = true, OverrideType = ParameterAttribute.OverrideTypes.Enum)]
    public int Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Value;
    }
}
