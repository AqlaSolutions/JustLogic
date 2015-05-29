using JustLogic.Core;

[UnitMenu("Math/Add or substract (float)")]
[UnitUsage(typeof(float), HideExpressionInActionsList = true)]
public class JLAddFloat : JLExpression
{
    [Parameter(ExpressionType = typeof(float))]
    public JLExpression[] Operands;

    public override object GetAnyResult(IExecutionContext context)
    {
        float v = 0;
        for (int i = 0; i < Operands.Length; i++)
        {
            v += Operands[i].GetResult<float>(context);
        }
        return v;
    }
}
