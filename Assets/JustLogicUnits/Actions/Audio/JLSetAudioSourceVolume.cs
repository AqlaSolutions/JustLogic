#if !JUSTLOGIC_FREE
using System.Collections.Generic;
using JustLogic.Core;

using UnityEngine;

[UnitMenu("Audio/Set Audio Source Volume")]
public class JLSetAudioSourceVolume : JLFadeActionBase
{
    [Parameter]
    public AudioSource AudioSource;

    protected override float ControlledValue
    {
        get
        {
            return AudioSource.volume;
        }
        set
        {
            AudioSource.volume = value;
        }
    }
}

#endif
