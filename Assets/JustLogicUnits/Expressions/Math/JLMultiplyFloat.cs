using JustLogic.Core;

[UnitMenu("Math/Multiply (float)")]
[UnitUsage(typeof(float),HideExpressionInActionsList = true)]
public class JLMultiplyFloat : JLExpression
{
    [Parameter(ExpressionType = typeof(float))]
    public JLExpression[] Operands;

    public override object GetAnyResult(IExecutionContext context)
    {
        float v = 1f;
        for (int i = 0; i < Operands.Length; i++)
        {
            v *= Operands[i].GetResult<float>(context);
        }
        return v;
    }
}
