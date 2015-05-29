using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Color/New Color32")]
[UnitFriendlyName("Color32.New Color32")]
[UnitUsage(typeof(UnityEngine.Color32), HideExpressionInActionsList = true)]
public class JLColor32NewColor32 : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Byte))]
    public JLExpression R;

    [Parameter(ExpressionType = typeof(System.Byte))]
    public JLExpression G;

    [Parameter(ExpressionType = typeof(System.Byte))]
    public JLExpression B;

    [Parameter(ExpressionType = typeof(System.Byte))]
    public JLExpression A;

    public override object GetAnyResult(IExecutionContext context)
    {
        return new UnityEngine.Color32(R.GetResult<System.Byte>(context), G.GetResult<System.Byte>(context), B.GetResult<System.Byte>(context), A.GetResult<System.Byte>(context));
    }
}
