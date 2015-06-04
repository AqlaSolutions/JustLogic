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
  
using System;
using JustLogic.Core;

public abstract class JLCompareBase2 : JLCompareBase
{
    [Parameter]
    public JLExpression Operand1;

    [Parameter]
    public ComparsionMode Operator;

    [Parameter]
    public JLExpression Operand2;

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
        return Operand1.GetAnyResultSafe(context);
    }

    protected override object GetOperand2(IExecutionContext context)
    {
        return Operand2.GetAnyResultSafe(context);
    }
}
