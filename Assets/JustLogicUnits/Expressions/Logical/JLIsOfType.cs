#if !JUSTLOGIC_FREE
using System;
using JustLogic.Core;

[UnitMenu("Logical/Is Of Type")]
public class JLIsOfType : JLBoolExpression
{
    [Parameter]
    public JLExpression Value;

    [Parameter(ExpressionType = typeof(Type))]
    public JLExpression Type;

    public override object GetAnyResult(IExecutionContext context)
    {
        var v = Value.GetAnyResultSafe(context);
        if (v == null) return false;
        var targetType = Type.GetResult<Type>(context);
        var vType = v.GetType();
        return ((vType == targetType) || vType.IsSubclassOf(targetType));
    }
}

#endif
