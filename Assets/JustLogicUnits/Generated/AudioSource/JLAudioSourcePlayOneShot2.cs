using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Audio/Play One Shot")]
[UnitFriendlyName("Audio.Play One Shot")]
public class JLAudioSourcePlayOneShot2 : JLAction
{
    [Parameter(ExpressionType = typeof(AudioSource))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(AudioClip))]
    public JLExpression Clip;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression VolumeScale;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        AudioSource opValue = OperandValue.GetResult<AudioSource>(context);
        opValue.PlayOneShot(Clip.GetResult<AudioClip>(context), VolumeScale.GetResult<System.Single>(context));
        return null;
    }
}
