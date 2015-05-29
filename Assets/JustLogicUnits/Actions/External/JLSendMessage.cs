#if !JUSTLOGIC_FREE
using System.Collections.Generic;
using JustLogic.Core;
using UnityEngine;

[UnitMenu("External/Send Message")]
public class JLSendMessage : JLAction
{
    [Parameter(ExpressionType = typeof(Object))]
    public JLExpression Object;

    [Parameter(ExpressionType = typeof(string))]
    public JLExpression Value;

    [Parameter]
    public bool WithArgument;

    [Parameter]
    public JLExpression Argument;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        var obj = Object.GetResult<Object>(context);
        var go = obj as GameObject;
        if (go != null)
        {
            if (WithArgument)
                go.SendMessage(Value.GetResult<string>(context), Argument.GetAnyResultSafe(context), SendMessageOptions.DontRequireReceiver);
            else
                go.SendMessage(Value.GetResult<string>(context), SendMessageOptions.DontRequireReceiver);
        }
        else
        {
            var c = obj as Component;
            if (c != null)
            {
                if (WithArgument)
                    c.SendMessage(Value.GetResult<string>(context), Argument.GetAnyResultSafe(context), SendMessageOptions.DontRequireReceiver);
                else
                    c.SendMessage(Value.GetResult<string>(context), SendMessageOptions.DontRequireReceiver);
            }
        }
        yield break;
    }
}

#endif
