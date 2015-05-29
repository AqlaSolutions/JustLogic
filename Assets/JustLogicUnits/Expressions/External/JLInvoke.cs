#if !JUSTLOGIC_FREE
using JustLogic.Core;

[UnitMenu("External/Invoke")]
[UnitUsage(HideExpressionInActionsList = true)]
public class JLInvoke : JLExpression
{
    [Parameter]
    public MethodInvokation Invokation;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Invokation.Invoke(context);
    }
}

#endif
