using JustLogic.Core;

[UnitMenu("Math/Multiply (int)")]
[UnitUsage(typeof(int),HideExpressionInActionsList = true)]
public class JLMultiplyInt : JLExpression
{
    [Parameter(ExpressionType = typeof(int))]
    public JLExpression[] Operands;

    public override object GetAnyResult(IExecutionContext context)
    {
        int v = 1;
        for (int i = 0; i < Operands.Length; i++)
        {
            v *= Operands[i].GetResult<int>(context);
        }
        return v;
    }
}
