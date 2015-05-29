using JustLogic.Core;

[UnitMenu("Math/Add or substract (int)")]
[UnitUsage(typeof(int), HideExpressionInActionsList = true)]
public class JLAddInt : JLExpression
{
    [Parameter(ExpressionType = typeof(int))]
    public JLExpression[] Operands;

    public override object GetAnyResult(IExecutionContext context)
    {
        int v = 0;
        for (int i = 0; i < Operands.Length; i++)
        {
            v += Operands[i].GetResult<int>(context);
        }
        return v;
    }
}
