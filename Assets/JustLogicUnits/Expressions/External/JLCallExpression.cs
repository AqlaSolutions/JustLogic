#if !JUSTLOGIC_FREE
using System.Collections.Generic;
using JustLogic.Core;

[UnitMenu("External/Call Expression (scene or prefab)")]
public class JLCallExpression : JLExpression
{
    [Parameter]
    public JustLogicSceneExpressionBase Value;

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
