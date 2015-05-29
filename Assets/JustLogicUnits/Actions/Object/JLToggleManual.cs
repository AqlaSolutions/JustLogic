using System.Collections.Generic;
using JustLogic.Core;
using UnityEngine;

[UnitMenu("Object/Toggle Manual")]
public class JLToggleManual : JLAction
{
    [Parameter(ExpressionType = typeof(Object))]
    public JLExpression Object;

    [Parameter(ExpressionType = typeof(bool))]
    public JLExpression Value;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        var obj = Object.GetResult<Object>(context);
        var enabled = Value.GetResult<bool>(context);
        if (!obj) return null;
        var b = obj as Behaviour;
        if (b) b.enabled = enabled;
        else
        {
            var r = obj as Renderer;
            if (r) r.enabled = enabled;
            else
            {
                var g = (obj is Component) ? ((Component)obj).gameObject : obj as GameObject;
                if (g) g.SetActive(enabled);
                else
                {
                    Debug.LogError("Toggle problem. " + obj);
                }
            }
        }
        return null;
    }
}
