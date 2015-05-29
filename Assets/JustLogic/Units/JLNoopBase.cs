using System.Collections.Generic;
using JustLogic.Core;

public abstract class JLNoopBase : JLAction
{
    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        yield break;
    }
}
