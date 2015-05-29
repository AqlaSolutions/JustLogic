using System.Collections.Generic;
using JustLogic.Core;
using UnityEngine;

[UnitMenu("Audio/Play")]
public class JLPlayClip : JLAction
{
    [Parameter(ExpressionType = typeof(AudioClip))]
    public JLExpression Value;

    [Parameter]
    public float Volume = 1f;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        var script = ((JustLogicScriptBase)context.ExecutorBehavior);
        var go = context.ExecutorObject;
        var source = go.GetComponent<AudioSource>() ?? go.AddComponent<AudioSource>();
        source.PlayOneShot(Value.GetResult<AudioClip>(context));
        yield break;
    }
}
