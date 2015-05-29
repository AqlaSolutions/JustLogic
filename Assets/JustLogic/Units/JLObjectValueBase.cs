using JustLogic.Core;
using UnityEngine;

public abstract class JLObjectValueBase : JLExpression
{

    [Parameter(UseContainerExpressionType = true)]
    public Object Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Value;
    }

    public static JLObjectValueBase Null { get { return CreateInstance<JLObjectValueBase>(); } }
}
