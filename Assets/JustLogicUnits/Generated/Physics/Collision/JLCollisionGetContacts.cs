using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Collision/Get Contacts")]
[UnitFriendlyName("Collision.Get Contacts")]
[UnitUsage(typeof(ContactPoint[]), HideExpressionInActionsList = true)]
public class JLCollisionGetContacts : JLExpression
{
    [Parameter(ExpressionType = typeof(Collision))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Collision opValue = OperandValue.GetResult<Collision>(context);
        return opValue.contacts;
    }
}
