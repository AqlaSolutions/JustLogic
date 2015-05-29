
using JustLogic.Core;

public abstract class JLStringValueBase : JLExpression
{
    [Parameter]
    public string Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Value;
    }
}
