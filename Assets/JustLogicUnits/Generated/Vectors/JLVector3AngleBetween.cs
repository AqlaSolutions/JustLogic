/*using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Angle Between (Vector3)")]
[UnitFriendlyName("Angle Between")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLVector3AngleBetween : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression From;

    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression To;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Vector3.AngleBetween(From.GetResult<UnityEngine.Vector3>(context), To.GetResult<UnityEngine.Vector3>(context));
    }
}
*/