using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Color/Set Item")]
[UnitFriendlyName("Color.Set Item")]
[UnitUsage(typeof(Color))]
public class JLColorSetItem : JLExpression
{
    [Parameter(ExpressionType = typeof(Color))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression Index;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        Color opValue = OperandValue.GetResult<Color>(context);
        opValue[Index.GetResult<System.Int32>(context)] = Value.GetResult<System.Single>(context);
        return opValue;
    }
}
