using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Audio/Get Spectrum Data")]
[UnitFriendlyName("Audio.Get Spectrum Data")]
public class JLAudioSourceGetSpectrumData : JLAction
{
    [Parameter(ExpressionType = typeof(UnityEngine.AudioSource))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression[] Samples;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression Channel;

    [Parameter(ExpressionType = typeof(UnityEngine.FFTWindow))]
    public JLExpression Window;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        UnityEngine.AudioSource opValue = OperandValue.GetResult<UnityEngine.AudioSource>(context);
        opValue.GetSpectrumData(Samples.GetResult<System.Single>(context), Channel.GetResult<System.Int32>(context), Window.GetResult<UnityEngine.FFTWindow>(context));
        return null;
    }
}
