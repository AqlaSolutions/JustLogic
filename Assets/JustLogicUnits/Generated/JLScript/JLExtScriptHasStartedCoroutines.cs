using JustLogic.Core;

[UnitMenu("External/Has Started Coroutines (JLScript)")]
[UnitFriendlyName("JLScript.Has Started Coroutines")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLExtScriptHasStartedCoroutines : JLExpression
{
    [Parameter(ExpressionType = typeof(JustLogicScriptBase))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        JustLogicScriptBase opValue = OperandValue.GetResult<JustLogicScriptBase>(context);
        return opValue.EngineInstance.HasStartedCoroutines();
    }
}
