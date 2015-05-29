using System;
using System.Reflection;
using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("WWW/Prefetch Socket Policy")]
[UnitFriendlyName("Prefetch Socket Policy")]
[UnitUsage(typeof(System.Boolean))]
public class JLSecurityPrefetchSocketPolicy2 : JLExpression
{
    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Ip;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression AtPort;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression Timeout;

    public override object GetAnyResult(IExecutionContext context)
    {
        var t = typeof(MonoBehaviour).Assembly.GetType("UnityEngine.Security");
        if (t == null) return null;
        var m = t.GetMethod("PrefetchSocketPolicy", new Type[] { typeof(string), typeof(int), typeof(int) });
        if (m == null) return null;
        return m.Invoke(null, new object[] { Ip.GetResult<System.String>(context), AtPort.GetResult<System.Int32>(context), Timeout.GetResult<System.Int32>(context) });

    }
}
