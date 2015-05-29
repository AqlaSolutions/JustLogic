#if !JUSTLOGIC_FREE
using System.Collections.Generic;
using JustLogic.Core;

[UnitMenu("Loop/Break")]
public class JLBreakLoop : JLAction
{
    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        yield return YieldMode.BreakLoop;
    }
}

#endif
