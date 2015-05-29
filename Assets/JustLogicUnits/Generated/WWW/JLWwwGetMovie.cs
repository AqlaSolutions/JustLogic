/*using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("WWW/Get Movie")]
[UnitFriendlyName("WWW.Get Movie")]
[UnitUsage(typeof(UnityEngine.MovieTexture), HideExpressionInActionsList = true)]
public class JLWwwGetMovie : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.WWW))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.WWW opValue = OperandValue.GetResult<UnityEngine.WWW>(context);
        return opValue.movie;
    }
}
*/