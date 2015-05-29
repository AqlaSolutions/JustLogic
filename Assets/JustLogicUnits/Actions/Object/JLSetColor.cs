using System.Collections.Generic;
using JustLogic.Core;
using UnityEngine;

[UnitMenu("Object/Set Color")]
public class JLSetColor : JLAction
{
    [Parameter(ExpressionType = typeof(Object))]
    public JLExpression Object;

    [Parameter(ExpressionType = typeof(Color))]
    public JLExpression Color;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        var o = Object.GetResult<Object>(context);
        if (!o)
            yield break;

        SetColor(o, Color.GetResult<Color>(context));
    }

    static void SetColor(Object o, Color color)
    {
        var go = o as GameObject;
        if (go != null)
        {
            foreach (var c in go.GetComponents(typeof(Component)))
                SetColor(c, color);
            return;
        }
        var light = o as Light;
        if (light != null)
        {
            light.color = color;
            return;
        }

        var renderer = o as Renderer;
        if (renderer != null)
        {
            renderer.material.color = color;
        }
    }
}
