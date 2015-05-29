using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("WWW/Get Progress")]
[UnitFriendlyName("WWW.Get Progress")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLWwwGetProgress : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.WWW))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.WWW opValue = OperandValue.GetResult<UnityEngine.WWW>(context);
        return opValue.progress;
    }
}
