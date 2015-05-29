using System.Collections.Generic;
using JustLogic.Core;
using UnityEngine;

[UnitMenu("Audio/Play or Pause Audio Source")]
public class JLPlayPauseAudio : JLAction
{
    [Parameter(ExpressionType = typeof(AudioSource))]
    public JLExpression AudioSource;

    [Parameter(ExpressionType = typeof(bool))]
    public JLExpression Play;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        var source = AudioSource.GetResult<AudioSource>(context);
        if (!Play.GetResult<bool>(context))
        {
            if (source.isPlaying)
                source.Pause();
        }
        else source.Play();
        yield break;
    }
}
