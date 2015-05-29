using JustLogic.Core;
using UnityEngine;

[UnitMenu("Object/Find With Tag")]
[UnitUsage(typeof(GameObject),HideExpressionInActionsList = true)]
public class JLFindObjectWithTag : JLExpression
{
    [Parameter(ExpressionType = typeof(string))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        return GameObject.FindGameObjectWithTag(Value.GetResult<string>(context));
    }
}
