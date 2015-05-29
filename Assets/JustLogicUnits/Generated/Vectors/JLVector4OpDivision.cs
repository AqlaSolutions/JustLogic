using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Operations/Division (Vector4)")]
[UnitFriendlyName("Op Division")]
[UnitUsage(typeof(UnityEngine.Vector4), HideExpressionInActionsList = true)]
public class JLVector4OpDivision : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Vector4))]
    public JLExpression A;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression D;

    public override object GetAnyResult(IExecutionContext context)
    {
        return A.GetResult<UnityEngine.Vector4>(context) / D.GetResult<System.Single>(context);
    }
}
