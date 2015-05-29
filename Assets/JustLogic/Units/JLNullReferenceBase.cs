using JustLogic.Core;

public abstract class JLNullReferenceBase : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return null;
    }
}
