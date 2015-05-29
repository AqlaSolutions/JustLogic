using System;
using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Application/External Eval")]
[UnitMenu("External/App External Eval")]
[UnitFriendlyName("External Eval")]
public class JLAppExternalEval : JLAction
{
    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Script;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        var m = typeof(Application).GetMethod("ExternalEval", new Type[] { typeof(string) });
        if (m != null)
            m.Invoke(null, new object[] { Script.GetResult<System.String>(context) });
        return null;
    }
}
