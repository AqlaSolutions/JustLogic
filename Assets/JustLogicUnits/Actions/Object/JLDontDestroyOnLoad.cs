using System.Collections.Generic;
using JustLogic.Core;
using UnityEngine;

[UnitMenu("Object/Dont Destroy Object On Load")]
public class JLDontDestroyOnLoad : JLAction
{
    [Parameter(ExpressionType = typeof(GameObject))]
    public JLExpression Value;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        DontDestroyOnLoad(Value.GetResult<GameObject>(context));
        yield break;
    }
}
