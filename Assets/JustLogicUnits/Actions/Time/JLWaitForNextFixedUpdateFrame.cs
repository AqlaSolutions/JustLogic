#if !JUSTLOGIC_FREE
using System.Collections.Generic;
using JustLogic.Core;

[UnitMenu("Time/Wait for next fixed update frame")]
public class JLWaitForNextFixedUpdateFrame : JLAction
{
    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        yield return YieldMode.YieldForNextFixedUpdate;
    }
}

#endif
