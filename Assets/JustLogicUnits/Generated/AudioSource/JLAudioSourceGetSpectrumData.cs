using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Audio/Get Spectrum Data")]
[UnitFriendlyName("Audio.Get Spectrum Data")]
public class JLAudioSourceGetSpectrumData : JLAction
{
    [Parameter(ExpressionType = typeof(AudioSource))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression[] Samples;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression Channel;

    [Parameter(ExpressionType = typeof(FFTWindow))]
    public JLExpression Window;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        AudioSource opValue = OperandValue.GetResult<AudioSource>(context);
        opValue.GetSpectrumData(Samples.GetResult<System.Single>(context), Channel.GetResult<System.Int32>(context), Window.GetResult<FFTWindow>(context));
        return null;
    }
}
