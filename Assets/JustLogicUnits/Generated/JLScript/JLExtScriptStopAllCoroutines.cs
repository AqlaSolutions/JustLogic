using JustLogic.Core;
using System.Collections.Generic;

[UnitMenu("External/Stop All Coroutines (JLScript)")]
[UnitFriendlyName("JLScript.Stop All Coroutines")]
public class JLExtScriptStopAllCoroutines : JLAction
{
    [Parameter(ExpressionType = typeof(JustLogicScriptBase))]
    public JLExpression OperandValue;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        JustLogicScriptBase opValue = OperandValue.GetResult<JustLogicScriptBase>(context);
        opValue.EngineInstance.StopAllCoroutines();
        return null;
    }
}
