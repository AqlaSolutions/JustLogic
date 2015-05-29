#if !JUSTLOGIC_FREE
using System.Collections.Generic;
using JustLogic.Core;

using UnityEngine;

[UnitMenu("Audio/Set Global Audio Volume")]
public class JLSetGlobalAudioVolume : JLFadeActionBase
{
    protected override float ControlledValue
    {
        get
        {
            return AudioListener.volume;
        }
        set
        {
            AudioListener.volume = value;
        }
    }
}

#endif
