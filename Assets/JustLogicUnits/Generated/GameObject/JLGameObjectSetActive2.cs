using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Object/Set Active")]
[UnitFriendlyName("Set Active")]
public class JLGameObjectSetActive2 : JLAction
{
    [Parameter(ExpressionType = typeof(GameObject))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Boolean))]
    public JLExpression Value;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        GameObject opValue = OperandValue.GetResult<GameObject>(context);
        opValue.SetActive(Value.GetResult<System.Boolean>(context));
        return null;    }
}
