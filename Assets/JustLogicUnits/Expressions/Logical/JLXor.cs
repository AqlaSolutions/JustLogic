using JustLogic.Core;

[UnitMenu("Logical/Xor")]
public class JLXor : JLBoolExpression
{
    [Parameter(ExpressionType = typeof(bool))]
    public JLExpression[] Operands = new JLExpression[0];

    public override object GetAnyResult(IExecutionContext context)
    {
        bool found = false;
        for (int i = 0; i < Operands.Length; i++)
        {
            if (Operands[i].GetResult<bool>(context))
            {
                if (found) return false;
                found = true;
            }
        }
        return found;
    }
}
