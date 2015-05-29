using System;
using JustLogic.Core;

public abstract class JLCompareEventArgumentBase : JLCompareBase
{
    [Parameter]
    public JLEventArgumentBase Argument;

    [Parameter]
    public ComparsionMode Operator;

    [Parameter]
    public JLExpression Comparand;

    public enum ComparsionMode
    {
        Equal,
        NotEqual,
        GreaterThan,
        SmallerThan,
        GreaterOrEqual,
        SmallerOrEqual,
    }

    
    protected override bool GetComparsionResult(int value, IExecutionContext context)
    {
        switch (Operator)
        {
            case ComparsionMode.Equal:
                return value == 0;
            case ComparsionMode.NotEqual:
                return value != 0;
            case ComparsionMode.GreaterThan:
                return value > 0;
            case ComparsionMode.SmallerThan:
                return value < 0;
            case ComparsionMode.GreaterOrEqual:
                return value >= 0;
            case ComparsionMode.SmallerOrEqual:
                return value <= 0;
            default:
                throw new InvalidOperationException();
        }
    }

    protected override bool FirstCheckEquals
    {
        get { return (Operator == ComparsionMode.Equal) || (Operator == ComparsionMode.NotEqual); }
    }

    protected override object GetOperand1(IExecutionContext context)
    {
        return Argument.GetAnyResult(context);
    }

    protected override object GetOperand2(IExecutionContext context)
    {
        return Comparand.GetAnyResultSafe(context);
    }
}
