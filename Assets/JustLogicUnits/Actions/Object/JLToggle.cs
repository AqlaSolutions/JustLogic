/*
 * TODO array - paste button
 * TODO parameters to call asset script
 * TODO parameters to call expression
 * TODO calling asset script directly from event handler and jltimer
 * TODO event: camera raycast
 * TODO array method
*/
using System.Collections.Generic;
using JustLogic.Core;
using UnityEngine;

[UnitMenu("Object/Toggle")]
public class JLToggle : JLAction
{
    [Parameter(ExpressionType = typeof(Object))]
    public JLExpression Object;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        var obj = Object.GetResult<Object>(context);
        if (!obj) return null;
        var b = obj as Behaviour;
        if (b) b.enabled = !b.enabled;
        else
        {
            var r = obj as Renderer;
            if (r) r.enabled = !r.enabled;
            else
            {
                var g = (obj is Component) ? ((Component)obj).gameObject : obj as GameObject;
                if (g) g.SetActive(!g.activeSelf);
                else
                {
                    Debug.LogError("Toggle problem. " + obj);
                }
            }
        }
        return null;
    }
}
