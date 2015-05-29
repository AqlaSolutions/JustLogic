#if !JUSTLOGIC_FREE
using System.Collections.Generic;
using JustLogic.Core;

[UnitMenu("Branch/Return Script (stop asset script execution)")]
public class JLReturnScript : JLAction
{
    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        yield return YieldMode.ReturnScript;
    }
}

#endif
