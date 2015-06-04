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
using JustLogic.Core;
using UnityEngine;

[UnitFriendlyName("Create Instance")]
[UnitMenu("Object/Create New")]
[UnitMenu("External/Construct")]
public class JLCreateNew : JLExpression
{
    [Parameter(ExpressionType = typeof(Type))]
    public JLExpression Type;

    [Parameter]
    public JLExpression[] ConstructorArguments;

    public override object GetAnyResult(IExecutionContext context)
    {
        var v = Type.GetResult<Type>(context);
        if (v.IsAbstract)
            return null;
        if (v.IsArray)
            return Array.CreateInstance(v.GetElementType(), 0);
        if (typeof(ScriptableObject).IsAssignableFrom(v))
            return Library.Instantiator.CreateScriptable(v);
        var args = new object[ConstructorArguments != null ? ConstructorArguments.Length : 0];
        if (args.Length != 0)
            for (int i = 0; i < args.Length; i++)
            {
                // ReSharper disable once PossibleNullReferenceException
                var arg = ConstructorArguments[i];
                args[i] = arg.GetAnyResultSafe(context);
            }
        return Activator.CreateInstance(v, args);
    }
}

#endif
