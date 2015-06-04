using System;
using System.Reflection;
using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("WWW/Prefetch Socket Policy")]
[UnitFriendlyName("Prefetch Socket Policy")]
[UnitUsage(typeof(Boolean))]
public class JLSecurityPrefetchSocketPolicy2 : JLExpression
{
    [Parameter(ExpressionType = typeof(String))]
    public JLExpression Ip;

    [Parameter(ExpressionType = typeof(Int32))]
    public JLExpression AtPort;

    [Parameter(ExpressionType = typeof(Int32))]
    public JLExpression Timeout;

    public override object GetAnyResult(IExecutionContext context)
    {
        var t = typeof(MonoBehaviour).Assembly.GetType("UnityEngine.Security");
        if (t == null) return null;
        var m = t.GetMethod("PrefetchSocketPolicy", new Type[] { typeof(string), typeof(int), typeof(int) });
        if (m == null) return null;
        return m.Invoke(null, new object[] { Ip.GetResult<String>(context), AtPort.GetResult<Int32>(context), Timeout.GetResult<Int32>(context) });

    }
}
