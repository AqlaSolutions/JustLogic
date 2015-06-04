using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Object/Find Objects Of Type")]
[UnitFriendlyName("Find Objects Of Type")]
[UnitUsage(typeof(Object[]), HideExpressionInActionsList = true)]
public class JLGameObjectFindObjectsOfType : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Type))]
    public JLExpression Type;

    public override object GetAnyResult(IExecutionContext context)
    {
        return FindObjectsOfType(Type.GetResult<System.Type>(context));
    }
}
