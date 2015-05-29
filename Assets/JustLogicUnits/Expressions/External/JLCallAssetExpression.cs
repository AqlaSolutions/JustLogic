#if !JUSTLOGIC_FREE
using JustLogic.Core;

[UnitMenu("External/Call Expression (asset)")]
public class JLCallAssetExpression : JLExpression
{
    [Parameter]
    public JLCustomExpressionAssetBase Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        var c = (ExecutionContext)context;
        var dVars = c.Variables;
        var dStVars = c.StaticVariables;
        c.Variables = null;
        c.StaticVariables = Value.StaticVariables;
        try
        {
            return Value.Value.GetAnyResultSafe(context);
        }
        finally
        {
            Value.StaticVariables = c.StaticVariables;
            c.StaticVariables = dStVars;
            c.Variables = dVars;
        }
    }
}

#endif
