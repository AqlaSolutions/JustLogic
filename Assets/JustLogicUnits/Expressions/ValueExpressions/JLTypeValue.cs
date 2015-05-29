using System;
using JustLogic.Core;

[UnitMenu("Value/Type")]
[UnitUsage(typeof(Type), HideExpressionInActionsList = true, IsDefaultExpression = true)]
public class JLTypeValue : JLExpression
{
    [Parameter(OverrideType = ParameterAttribute.OverrideTypes.Type)]
    public string Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Library.FindType(Value);
    }

}
