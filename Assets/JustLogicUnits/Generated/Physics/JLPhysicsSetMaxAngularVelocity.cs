//using JustLogic.Core;
//using System.Collections.Generic;
//using UnityEngine;

//[UnitMenu("Physics/Settings/Set Max Angular Velocity")]
//[UnitFriendlyName("Physics.Set Max Angular Velocity")]
//[UnitUsage(typeof(System.Single))]
//public class JLPhysicsSetMaxAngularVelocity : JLExpression
//{
//    [Parameter(ExpressionType = typeof(System.Single))]
//    public JLExpression Value;

//    public override object GetAnyResult(IExecutionContext context)
//    {
//        return UnityEngine.Physics.maxAngularVelocity = Value.GetResult<System.Single>(context);
//    }
//}
