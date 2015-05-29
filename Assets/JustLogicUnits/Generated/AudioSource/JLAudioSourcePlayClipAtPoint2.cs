using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Audio/Play Clip At Point")]
[UnitFriendlyName("Audio.Play Clip At Point")]
public class JLAudioSourcePlayClipAtPoint2 : JLAction
{
    [Parameter(ExpressionType = typeof(UnityEngine.AudioClip))]
    public JLExpression Clip;

    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression Position;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Volume;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        UnityEngine.AudioSource.PlayClipAtPoint(Clip.GetResult<UnityEngine.AudioClip>(context), Position.GetResult<UnityEngine.Vector3>(context), Volume.GetResult<System.Single>(context));
        return null;
    }
}
