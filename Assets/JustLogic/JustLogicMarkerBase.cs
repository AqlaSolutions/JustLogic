#if !JUSTLOGIC_FREE
using JustLogic.Core;
using UnityEngine;

/// <tocexclude />
public abstract class JustLogicMarkerBase : JustLogicBehaviorBase
{
    public string GlobalVariableName;
    public UnityEngine.Object Target;

    protected override void Awake()
    {
        base.Awake();
        Mark();
    }

    public void Mark()
    {
        GlobalVariablesStorage.GetVariable(GlobalVariableName).Value = Target;
    }

    protected void Reset()
    {
        Target = gameObject;
    }
}
#endif