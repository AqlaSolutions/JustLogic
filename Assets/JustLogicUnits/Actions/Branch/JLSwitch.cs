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
        var compare = CreateInstance<JLCompareBase2>();
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
