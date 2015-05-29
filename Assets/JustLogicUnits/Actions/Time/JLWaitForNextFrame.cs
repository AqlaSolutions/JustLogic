#if !JUSTLOGIC_FREE
using System.Collections.Generic;
using JustLogic.Core;

[UnitMenu("Time/Wait for next frame")]
public class JLWaitForNextFrame : JLAction
{
    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        yield return YieldMode.YieldForNextUpdate;
    }
}

#endif
