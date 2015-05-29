using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Rect/Set")]
[UnitFriendlyName("Rect.Set")]
[UnitUsage(typeof(UnityEngine.Rect), HideExpressionInActionsList = true)]
public class JLRectSet : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Rect))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Left;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Top;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Width;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Height;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Rect opValue = OperandValue.GetResult<UnityEngine.Rect>(context);
        opValue.Set(Left.GetResult<System.Single>(context), Top.GetResult<System.Single>(context), Width.GetResult<System.Single>(context), Height.GetResult<System.Single>(context));
        return opValue;
    }
}
