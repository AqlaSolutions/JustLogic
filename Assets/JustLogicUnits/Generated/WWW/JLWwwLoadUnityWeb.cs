//using JustLogic.Core;
//using System.Collections.Generic;
//using UnityEngine;

//[UnitMenu("WWW/Load Unity Web")]
//[UnitFriendlyName("WWW.Load Unity Web")]
//public class JLWwwLoadUnityWeb : JLAction
//{
//    [Parameter(ExpressionType = typeof(UnityEngine.WWW))]
//    public JLExpression OperandValue;

//    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
//    {
//        UnityEngine.WWW opValue = OperandValue.GetResult<UnityEngine.WWW>(context);
//        opValue.LoadUnityWeb();
//        return null;
//    }
//}
