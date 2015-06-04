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
using System.Reflection;
using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("WWW/Prefetch Socket Policy")]
[UnitFriendlyName("Prefetch Socket Policy")]
[UnitUsage(typeof(Boolean))]
public class JLSecurityPrefetchSocketPolicy2 : JLExpression
{
    [Parameter(ExpressionType = typeof(String))]
    public JLExpression Ip;

    [Parameter(ExpressionType = typeof(Int32))]
    public JLExpression AtPort;

    [Parameter(ExpressionType = typeof(Int32))]
    public JLExpression Timeout;

    public override object GetAnyResult(IExecutionContext context)
    {
        var t = typeof(MonoBehaviour).Assembly.GetType("UnityEngine.Security");
        if (t == null) return null;
        var m = t.GetMethod("PrefetchSocketPolicy", new Type[] { typeof(string), typeof(int), typeof(int) });
        if (m == null) return null;
        return m.Invoke(null, new object[] { Ip.GetResult<String>(context), AtPort.GetResult<Int32>(context), Timeout.GetResult<Int32>(context) });

    }
}
