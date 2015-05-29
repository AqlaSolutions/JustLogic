using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Collision/Get Contacts")]
[UnitFriendlyName("Collision.Get Contacts")]
[UnitUsage(typeof(UnityEngine.ContactPoint[]), HideExpressionInActionsList = true)]
public class JLCollisionGetContacts : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Collision))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Collision opValue = OperandValue.GetResult<UnityEngine.Collision>(context);
        return opValue.contacts;
    }
}
