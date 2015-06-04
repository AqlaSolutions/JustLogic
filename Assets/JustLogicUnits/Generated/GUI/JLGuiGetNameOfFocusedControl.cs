using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUI/GetNameOfFocusedControl")]
[UnitFriendlyName("GUI.GetNameOfFocusedControl")]
[UnitUsage(typeof(System.String))]
public class JLGuiGetNameOfFocusedControl : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return GUI.GetNameOfFocusedControl();
    }
}
