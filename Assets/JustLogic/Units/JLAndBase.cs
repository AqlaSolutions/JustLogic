using JustLogic.Core;

public abstract class JLAndBase : JLBoolExpression
{
    [Parameter(ExpressionType = typeof(bool))]
    public JLExpression[] Operands = new JLExpression[0];

    public override object GetAnyResult(IExecutionContext context)
    {
        for (int i = 0; i < Operands.Length; i++)
        {
            if (!Operands[i].GetResult<bool>(context))
                return false;
        }
        return true;
    }
}
