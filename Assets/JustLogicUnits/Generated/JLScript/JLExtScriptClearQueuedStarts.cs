using JustLogic.Core;
using System.Collections.Generic;

[UnitMenu("External/Clear Queued Starts (JLScript)")]
[UnitFriendlyName("JLScript.Clear Queued Starts")]
public class JLExtScriptClearQueuedStarts : JLAction
{
    [Parameter(ExpressionType = typeof(JustLogicScriptBase))]
    public JLExpression OperandValue;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        JustLogicScriptBase opValue = OperandValue.GetResult<JustLogicScriptBase>(context);
        opValue.EngineInstance.ClearQueuedStarts();
        return null;
    }
}
