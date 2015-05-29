#if !JUSTLOGIC_FREE

using System;
using System.Collections.Generic;
using JustLogic.Core;
using JustLogic.Core.Events;
using UnityEngine;
using Object = UnityEngine.Object;

/// <summary>
/// Starts the specified JL script (or sends "OnJLTimerTick" event) every the specified <see cref="JustLogicTimerBase.Interval"/> 
/// </summary>
[AddComponentMenu("Just Logic/JL Timer")]
public class JustLogicTimer : JustLogicTimerBase
{

}

#endif
