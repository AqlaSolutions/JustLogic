using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Audio/Play One Shot")]
[UnitFriendlyName("Audio.Play One Shot")]
public class JLAudioSourcePlayOneShot : JLAction
{
    [Parameter(ExpressionType = typeof(UnityEngine.AudioSource))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.AudioClip))]
    public JLExpression Clip;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        UnityEngine.AudioSource opValue = OperandValue.GetResult<UnityEngine.AudioSource>(context);
        opValue.PlayOneShot(Clip.GetResult<UnityEngine.AudioClip>(context));
        return null;
    }
}
