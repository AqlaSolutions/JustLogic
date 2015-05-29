#if !JUSTLOGIC_FREE
using System;
using System.Collections.Generic;
using JustLogic.Core;
using UnityEngine;

[UnitMenu("Branch/Switch")]
public class JLSwitch : JLAction
{
    [Parameter]
    public JLExpression CompareValue;

    [Parameter]
    public JLSwitchElement[] Branches;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        var compare = JLUnitBase.CreateInstance<JLCompareBase2>();
        compare.Operand1 = CompareValue;

        for (int i = 0; i < Branches.Length; i++)
        {
            JLSwitchElement el = Branches[i];

            compare.Operand2 = el.Value;

            if (compare.GetResult<bool>(context))
            {
                using (var enumerator = el.ExecuteSafe(context))
                {
                    while (enumerator.SafeMoveNext())
                    {
                        switch (enumerator.Current)
                        {
                            case YieldMode.ContinueLoop:
                            case YieldMode.BreakLoop:
                            case YieldMode.Return:
                            case YieldMode.ReturnScript:
                            case YieldMode.YieldForNextFixedUpdate:
                            case YieldMode.YieldForNextUpdate:
                                yield return enumerator.Current;
                                break;
                            default:
                                throw new InvalidOperationException();
                        }
                    }
                }
                break;
            }
        }

        DestroyImmediate(compare);
    }
}

#endif
