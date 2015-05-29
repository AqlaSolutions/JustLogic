//using JustLogic.Core;
//using System.Collections.Generic;
//using UnityEngine;

//[UnitMenu("Physics/Settings/Set Min Penetration For Penalty")]
//[UnitFriendlyName("Physics.Set Min Penetration For Penalty")]
//[UnitUsage(typeof(System.Single))]
//public class JLPhysicsSetMinPenetrationForPenalty : JLExpression
//{
//    [Parameter(ExpressionType = typeof(System.Single))]
//    public JLExpression Value;

//    public override object GetAnyResult(IExecutionContext context)
//    {
//        return UnityEngine.Physics.minPenetrationForPenalty = Value.GetResult<System.Single>(context);
//    }
//}
