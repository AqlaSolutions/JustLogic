using JustLogic.Core;
public abstract class JLEventArgumentBase : JLExpression
{
    [Parameter(OverrideType = ParameterAttribute.OverrideTypes.EventArgument)]
    public int Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        return context.CurrentEvent != null ? context.CurrentEvent.GetArgumentOrNull(Value) : null;
    }
}
