using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Quaternion/Set")]
[UnitFriendlyName("Set")]
[UnitUsage(typeof(Quaternion), HideExpressionInActionsList = true)]
public class JLQuaternionSet : JLExpression
{
    [Parameter(ExpressionType = typeof(Quaternion))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression NewX;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression NewY;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression NewZ;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression NewW;

    public override object GetAnyResult(IExecutionContext context)
    {
        Quaternion opValue = OperandValue.GetResult<Quaternion>(context);
        opValue.Set(NewX.GetResult<System.Single>(context), NewY.GetResult<System.Single>(context), NewZ.GetResult<System.Single>(context), NewW.GetResult<System.Single>(context));
        return opValue;
    }
}
