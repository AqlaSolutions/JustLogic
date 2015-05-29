using System;
using JustLogic.Core;

[UnitMenu("Value/Enum (custom)")]
[UnitUsage(typeof(Enum), HideExpressionInActionsList = true)]
public class JLEnumCustomValue : JLExpression
{
    [Parameter]
    public SerializedEnum Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        return (Enum)Enum.ToObject(Value.RuntimeType, Convert.ChangeType(Value.Value, Enum.GetUnderlyingType(Value.RuntimeType)));
    }
}
