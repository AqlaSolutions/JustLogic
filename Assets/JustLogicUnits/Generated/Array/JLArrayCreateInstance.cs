using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("Array/Create Instance")]
[UnitFriendlyName("Array.Create Instance")]
[UnitUsage(typeof(Array), HideExpressionInActionsList = true)]
public class JLArrayCreateInstance : JLExpression
{
    [Parameter(ExpressionType = typeof(Type))]
    public JLExpression ElementType;

    [Parameter(ExpressionType = typeof(Int32))]
    public JLExpression Length;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Array.CreateInstance(ElementType.GetResult<Type>(context), Length.GetResult<Int32>(context));
    }
}
