using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("Array/Create Instance")]
[UnitFriendlyName("Array.Create Instance")]
[UnitUsage(typeof(System.Array), HideExpressionInActionsList = true)]
public class JLArrayCreateInstance : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Type))]
    public JLExpression ElementType;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression Length;

    public override object GetAnyResult(IExecutionContext context)
    {
        return System.Array.CreateInstance(ElementType.GetResult<System.Type>(context), Length.GetResult<System.Int32>(context));
    }
}
