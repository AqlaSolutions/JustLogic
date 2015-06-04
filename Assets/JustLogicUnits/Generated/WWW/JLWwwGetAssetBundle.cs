using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("WWW/Get Asset Bundle")]
[UnitFriendlyName("WWW.Get Asset Bundle")]
[UnitUsage(typeof(AssetBundle), HideExpressionInActionsList = true)]
public class JLWwwGetAssetBundle : JLExpression
{
    [Parameter(ExpressionType = typeof(WWW))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        WWW opValue = OperandValue.GetResult<WWW>(context);
        return opValue.assetBundle;
    }
}
