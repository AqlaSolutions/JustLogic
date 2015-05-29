#if !JUSTLOGIC_FREE
using System;
using System.Collections.Generic;
using JustLogic.Core;


[UnitMenu("External/Call JL Script (asset)")]
public class JLCallAssetScript : JLCallScriptBase
{
    [Parameter]
    public JLCustomScriptAssetBase Value;

    protected override IEnumerator<YieldMode> CreateEnumerator(IExecutionContext context)
    {
        var c = (ExecutionContext)context;
        var dVars = c.Variables;
        var dStVars = c.StaticVariables;
        c.Variables = null;
        c.StaticVariables = Value.StaticVariables;
        try
        {
            return Value.Value.ExecuteSafe(context);
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
