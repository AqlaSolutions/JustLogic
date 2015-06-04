using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Application/Get Streamed Bytes")]
[UnitFriendlyName("Get Streamed Bytes")]
[UnitUsage(typeof(System.Int32), HideExpressionInActionsList = true)]
public class JLAppGetStreamedBytes : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return Application.streamedBytes;
    }
}
