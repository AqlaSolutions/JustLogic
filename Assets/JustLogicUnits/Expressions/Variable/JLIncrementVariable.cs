#if !JUSTLOGIC_FREE
using JustLogic.Core;
[UnitMenu("Variable/Increment")]
public class JLIncrementVariable : JLExpression
{
    [Parameter]
    public SelectedVariableInfo Variable;
    
    public override object GetAnyResult(IExecutionContext context)
    {
        var variable = context.GetVariable(Variable);
        object v = variable.Value;
        var expression = v as JLExpression;
        if (expression != null)
        {
            return expression.GetAnyResultSafe(context);
        }
        if (v is float)
        {
            variable.Value = (float)v + 1f;
            return variable.Value;
        }
        if (v is double)
        {
            variable.Value = (double)v + 1.0;
            return variable.Value;
        }
        int intV = (int)JLExpressionExtensions.ConvertType(v,typeof(int),context)+1;
        variable.Value = intV;
        return intV;
    }
}
#endif
