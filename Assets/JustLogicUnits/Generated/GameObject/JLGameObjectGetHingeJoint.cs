using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Object/Get Hinge Joint")]
[UnitFriendlyName("Get Hinge Joint")]
[UnitUsage(typeof(HingeJoint), HideExpressionInActionsList = true)]
public class JLGameObjectGetHingeJoint : JLExpression
{
    [Parameter(ExpressionType = typeof(GameObject))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        GameObject opValue = OperandValue.GetResult<GameObject>(context);
        return opValue.GetComponent<HingeJoint>();
    }
}
