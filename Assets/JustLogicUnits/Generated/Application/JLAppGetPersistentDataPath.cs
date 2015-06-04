using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Application/Get Persistent Data Path")]
[UnitFriendlyName("Get Persistent Data Path")]
[UnitUsage(typeof(System.String), HideExpressionInActionsList = true)]
public class JLAppGetPersistentDataPath : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return Application.persistentDataPath;
    }
}
