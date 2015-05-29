using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/String To Hash")]
[UnitFriendlyName("Animator.String To Hash")]
[UnitUsage(typeof(System.Int32), HideExpressionInActionsList = true)]
public class JLAnimatorStringToHash : JLExpression
{
    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Name;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Animator.StringToHash(Name.GetResult<System.String>(context));
    }
}
