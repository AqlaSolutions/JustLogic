using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Application/Open URL")]
[UnitFriendlyName("Open URL")]
public class JLAppOpenURL : JLAction
{
    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Url;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        Application.OpenURL(Url.GetResult<System.String>(context));
        return null;    }
}
