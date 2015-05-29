//using JustLogic.Core;
//using System.Collections.Generic;
//using UnityEngine;

//[UnitMenu("Object/Resources/Load Asset At Path")]
//[UnitFriendlyName("Resources.Load Asset At Path")]
//[UnitUsage(typeof(UnityEngine.Object), HideExpressionInActionsList = true)]
//public class JLResourcesLoadAssetAtPath : JLExpression
//{
//    [Parameter(ExpressionType = typeof(System.String))]
//    public JLExpression AssetPath;

//    [Parameter(ExpressionType = typeof(System.Type))]
//    public JLExpression Type;

//    public override object GetAnyResult(IExecutionContext context)
//    {
//        return UnityEngine.Resources.LoadAssetAtPath(AssetPath.GetResult<System.String>(context), Type.GetResult<System.Type>(context));
//    }
//}
