using JustLogic.Core;
using UnityEngine;

[UnitMenu("Object/Spawn At")]
[UnitUsage(typeof(Object))]
public class JLSpawnAt : JLExpression
{
    [Parameter(ExpressionType = typeof(Object))]
    public JLExpression Prefab;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression Position;

    [Parameter(ExpressionType = typeof(Quaternion))]
    public JLExpression Rotation;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Instantiate(Prefab.GetResult<Object>(context), Position.GetResult<Vector3>(context), Rotation.GetResult<Quaternion>(context));
    }
}
