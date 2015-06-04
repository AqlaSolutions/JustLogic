using JustLogic.Core;
using System.Collections.Generic;
using System.Collections;

[UnitMenu("ArrayList/Set Item")]
[UnitFriendlyName("ArrayList.Set Item")]
[UnitUsage(typeof(System.Int32))]
public class JLArrayListSetItem : JLExpression
{
    [Parameter(ExpressionType = typeof(ArrayList))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression Index;

    [Parameter(ExpressionType = typeof(object))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        ArrayList opValue = OperandValue.GetResult<ArrayList>(context);
        return opValue[Index.GetResult<System.Int32>(context)] = Value.GetResult<object>(context);
    }
}
