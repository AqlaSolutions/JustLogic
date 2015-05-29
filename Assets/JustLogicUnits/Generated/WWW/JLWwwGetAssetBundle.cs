using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("WWW/Get Asset Bundle")]
[UnitFriendlyName("WWW.Get Asset Bundle")]
[UnitUsage(typeof(UnityEngine.AssetBundle), HideExpressionInActionsList = true)]
public class JLWwwGetAssetBundle : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.WWW))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.WWW opValue = OperandValue.GetResult<UnityEngine.WWW>(context);
        return opValue.assetBundle;
    }
}
