#if !JUSTLOGIC_FREE
using System;
using System.Collections.Generic;
using JustLogic.Core;


[UnitMenu("External/Call JL Script (scene or prefab)")]
public class JLCallScript : JLCallScriptBase
{
    [Parameter]
    public JustLogicScriptBase Value;

    [Parameter]
    public bool IgnoreConditions;

    protected override IEnumerator<YieldMode> CreateEnumerator(IExecutionContext context)
    {
        Value.InitEngine();
        if ((Value.EngineInstance != null) && (Value.EngineInstance.Tree))
        {
            var c = (ExecutionContext)context;
            var dVars = c.Variables;
            var dStVars = c.StaticVariables;
            c.Variables = null;
            c.StaticVariables = Value.EngineInstance.Context.StaticVariables;
            try
            {
                var ifUnit = Value.EngineInstance.Tree as JLIfBase;
                if (!IgnoreConditions || !ifUnit)
                    return Value.EngineInstance.Tree.ExecuteSafe(context);

                if (ifUnit.Then)
                    return ifUnit.Then.ExecuteSafe(context);
            }
            finally
            {
                Value.EngineInstance.Context.StaticVariables = c.StaticVariables;
                c.StaticVariables = dStVars;
                c.Variables = dVars;
            }

        }
        return (new YieldMode[0] as IEnumerable<YieldMode>).GetEnumerator();
    }
}

#endif
