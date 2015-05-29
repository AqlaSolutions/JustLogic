#if !JUSTLOGIC_FREE
using System.Collections.Generic;
using JustLogic.Core;

[UnitMenu("Branch/Return (stop execution)")]
public class JLReturn : JLAction
{
    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        yield return YieldMode.Return;
    }
}

#endif
