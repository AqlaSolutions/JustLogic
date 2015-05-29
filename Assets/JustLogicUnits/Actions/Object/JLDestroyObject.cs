using System.Collections.Generic;
using JustLogic.Core;
using UnityEngine;

[UnitMenu("Object/Destroy")]
public class JLDestroyObject : JLAction
{
    [Parameter(ExpressionType = typeof(Object))]
    public JLExpression Object;

    [Parameter(ExpressionType = typeof(float))]
    public JLExpression Timer;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        var o = Object.GetResult<Object>(context);
        if (o)
        {
            var t = Timer.GetResult<float>(context);
            if (t < float.Epsilon)
                UnityEngine.Object.Destroy(o);
            else
                UnityEngine.Object.Destroy(o, t);
        }
        yield break;
    }
}
