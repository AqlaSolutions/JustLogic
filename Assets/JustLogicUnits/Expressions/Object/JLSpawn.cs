using JustLogic.Core;
using UnityEngine;

[UnitMenu("Object/Spawn")]
[UnitMenu("Object/Instantiate")]
[UnitFriendlyName("Instantiate (Spawn)")]
[UnitUsage(typeof(Object))]
public class JLSpawn : JLExpression
{
    [Parameter(ExpressionType = typeof(Object))]
    public JLExpression Prefab;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Instantiate(Prefab.GetResult<Object>(context));
    }
}
