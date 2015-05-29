using JustLogic.Core;

[UnitMenu("External/Has Queued Starts (JLScript)")]
[UnitFriendlyName("JLScript.Has Queued Starts")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLExtScriptHasQueuedStarts : JLExpression
{
    [Parameter(ExpressionType = typeof(JustLogicScriptBase))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        JustLogicScriptBase opValue = OperandValue.GetResult<JustLogicScriptBase>(context);
        return opValue.EngineInstance.HasQueuedStarts();
    }
}
