using JustLogic.Core;
using UnityEngine;

    [UnitMenu("Value/Vector4")]
    [UnitUsage(typeof(Vector4), HideExpressionInActionsList = true, IsDefaultExpression = true)]
    public class JLVector4Value : JLExpression
    {
        [Parameter]
        public Vector4 Value;

        public override object GetAnyResult(IExecutionContext context)
        {
            return Value;
        }
    }
