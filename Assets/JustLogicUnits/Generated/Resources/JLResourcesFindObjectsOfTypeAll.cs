using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Object/Resources/Find Objects Of Type All")]
[UnitFriendlyName("Resources.Find Objects Of Type All")]
[UnitUsage(typeof(UnityEngine.Object[]), HideExpressionInActionsList = true)]
public class JLResourcesFindObjectsOfTypeAll : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Type))]
    public JLExpression Type;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Resources.FindObjectsOfTypeAll(Type.GetResult<System.Type>(context));
    }
}
