using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Transform/Get Child")]
[UnitFriendlyName("Get Child")]
[UnitUsage(typeof(UnityEngine.Transform), HideExpressionInActionsList = true)]
public class JLTransformGetChild : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Transform))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression Index;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Transform opValue = OperandValue.GetResult<UnityEngine.Transform>(context);
        return opValue.GetChild(Index.GetResult<System.Int32>(context));
    }
}
