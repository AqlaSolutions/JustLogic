#if !JUSTLOGIC_FREE
using JustLogic.Core;
using UnityEngine;

[UnitMenu("Time/Set Time Scale")]
public class JLSetTimeScale : JLFadeActionBase
{
    protected override float ControlledValue
    {
        get
        {
            return Time.timeScale;
        }
        set
        {
            Time.timeScale = value;
        }
    }
}

#endif
