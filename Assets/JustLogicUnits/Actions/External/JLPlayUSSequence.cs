#if !JUSTLOGIC_FREE
using System.Collections.Generic;
using JustLogic.Core;
using UnityEngine;

[UnitMenu("External/Play US Sequence")]
public class JLPlayUSSequence : JLAction
{
    [Parameter(ExpressionType = typeof(GameObject))]
    public JLExpression Object;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        var obj = Object.GetResult<GameObject>(context);
        var sequencer = obj.GetComponent("USSequencer");
        sequencer.SendMessage("Play");
        yield break;
    }
}

#endif
