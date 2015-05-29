using JustLogic.Core;
using UnityEngine;

public abstract class JLPrintRetBase : JLExpression
{
    [Parameter(DefaultUnitTypeName = "JLStringValue")]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        object result = Value.GetAnyResultSafe(context);
        Debug.Log(result);
        return result;
    }
}
