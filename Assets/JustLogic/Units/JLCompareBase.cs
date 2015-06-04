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
using System.Collections;
using JustLogic.Core;

public abstract class JLCompareBase : JLBoolExpression
{
    protected abstract bool GetComparsionResult(int value, IExecutionContext context);

    protected abstract object GetOperand1(IExecutionContext context);

    protected abstract object GetOperand2(IExecutionContext context);

    protected abstract bool FirstCheckEquals { get; }

    public override object GetAnyResult(IExecutionContext context)
    {
        object value1 = GetOperand1(context);
        object value2 = GetOperand2(context);

        if (ReferenceEquals(value1, value2)) return GetComparsionResult(0, context);
        if (ReferenceEquals(value1, null))
        {
            if (value2 is UnityEngine.Object)
                return !(bool)(value2 as UnityEngine.Object);
            return GetComparsionResult(-1, context);
        }
        if (ReferenceEquals(value2, null))
        {
            if (value1 is UnityEngine.Object)
                return !(bool)(value1 as UnityEngine.Object);
            return GetComparsionResult(-1, context);
        }

        try
        {
            Type t2 = value2.GetType();
            value1 = JLExpressionExtensions.ConvertType(value1, t2, context);
        }
        catch
        {
            Type t1 = value1.GetType();
            value2 = JLExpressionExtensions.ConvertType(value2, t1, context);
        }

        if (FirstCheckEquals)
        {
            var list1 = value1 as IList;
            var list2 = value2 as IList;
            if ((list1 != null) && (list2 != null))
            {
                if (list1.Count != list2.Count)
                    return list1.Count.CompareTo(list2.Count);

                bool equals = true;
                for (int i = 0; i < list1.Count; i++)
                {
                    try
                    {
                        if (!list1[i].Equals(list2[i]))
                            equals = false;
                    }
                    catch { equals = false; }
                    if (!equals)
                        break;
                }

                return equals ? 0 : -1;
            }

            return GetComparsionResult(value1.Equals(value2) ? 0 : -1, context);
        }

        int r;
        if (TryCompare(value1 as IComparable, value2, out r)) return GetComparsionResult(r, context);
        if (TryCompare(value2 as IComparable, value1, out r)) return GetComparsionResult(r, context);

        {
            var list1 = value1 as IList;
            var list2 = value2 as IList;
            if ((list1 != null) && (list2 != null))
                return list1.Count.CompareTo(list2.Count);
        }

        throw new InvalidCastException();
    }

    private bool TryCompare(IComparable value1, object value2, out int result)
    {
        result = 0;
        if (value1 != null)
        {
            try
            {
                result = value1.CompareTo(value2);
                return true;
            }
            catch { }
        }
        return false;
    }
}
