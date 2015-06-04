using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("WWW/Get Upload Progress")]
[UnitFriendlyName("WWW.Get Upload Progress")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLWwwGetUploadProgress : JLExpression
{
    [Parameter(ExpressionType = typeof(WWW))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        WWW opValue = OperandValue.GetResult<WWW>(context);
        return opValue.uploadProgress;
    }
}
