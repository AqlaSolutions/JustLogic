/*
	
	This file is a part of JustLogic product which is distributed under 
	the BSD 3-clause "New" or "Revised" License
	
	Copyright (c) 2015. All rights reserved. 
	Authors: Vladyslav Taranov.
	
	Redistribution and use in source and binary forms, with or without
	modification, are permitted provided that the following conditions are met:
	
	* Redistributions of source code must retain the above copyright notice, this
	  list of conditions and the following disclaimer.
	
	* Redistributions in binary form must reproduce the above copyright notice,
	  this list of conditions and the following disclaimer in the documentation
	  and/or other materials provided with the distribution.
	
	* Neither the name of JustLogic nor the names of its
	  contributors may be used to endorse or promote products derived from
	  this software without specific prior written permission.
	
	THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
	AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
	IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
	DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE
	FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
	DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
	SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
	CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
	OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
	OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

 */
  
#if !JUSTLOGIC_FREE
using System;
using System.Collections;
using System.Collections.Generic;
using JustLogic.Core;
using UnityEngine;

[UnitMenu("External/Trigger Script")]
public class JLTriggerJLScript : JLAction
{
    [Parameter]
    public JustLogicScriptBase Value;

    [Parameter(ExpressionType = typeof(float))]
    public JLExpression Timer;

    [Parameter]
    public bool TimerUsesRealTime;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        var t = Timer.GetResult<float>(context);
        if (t < float.Epsilon)
            Value.StartExecution();
        else
            context.ExecutorBehavior.StartCoroutine(Coroutine(Value, t, TimerUsesRealTime));
        yield break;
    }

    static IEnumerator Coroutine(JustLogicScriptBase script, float timer, bool realTime)
    {
        if (realTime)
        {
            float startTime = Time.realtimeSinceStartup;
            float newTime;
            do
            {
                yield return new WaitForEndOfFrame();
                newTime = Time.realtimeSinceStartup;
            }
            while ((newTime > startTime) && ((newTime - startTime) < timer));
        }
        else yield return new WaitForSeconds(timer);
        if (script)
            script.StartExecution();
    }
}

#endif
