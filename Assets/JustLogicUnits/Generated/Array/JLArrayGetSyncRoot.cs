using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("Array/Get Sync Root")]
[UnitFriendlyName("Array.Get Sync Root")]
[UnitUsage(typeof(object), HideExpressionInActionsList = true)]
public class JLArrayGetSyncRoot : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Array))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        System.Array opValue = OperandValue.GetResult<System.Array>(context);
        return opValue.SyncRoot;
    }
}
