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
using System.Collections.Generic;
using JustLogic.Core;
using UnityEngine;

/// <summary>
/// Base class for unit that does some action
/// </summary>
/// <remarks>
/// Actions are not available to be used as expression parameters. An action does not return a value, so it cannot be passed in the parameter.
/// </remarks>
public abstract class JLAction : JLUnitBase
{
    /// <summary>
    /// Weather the unit is enabled to be executed
    /// </summary>
    public bool On = true;

    /// <summary>
    /// Override it to provide your logic for the action
    /// </summary>
    /// <param name="context">Execution information</param>
    /// <returns>null or <see cref="YieldMode"/> to start coroutine</returns>
    protected abstract IEnumerator<YieldMode> OnExecute(IExecutionContext context);

    /// <summary>
    /// Executes the action if it's enabled, otherwise returns null
    /// </summary>
    public IEnumerator<YieldMode> Execute(IExecutionContext context)
    {
        if (!On)
            return null;

        return OnExecute(context);
    }

    /// <summary>
    /// Creates an action fluently
    /// </summary>
    public static T Build<T>(System.Action<T> initializer = null) where T : JLAction
    {
        var r = CreateInstanceFunc == null ? Library.Instantiator.CreateScriptable<T>() : (T)CreateInstanceFunc(typeof(T));
        if (initializer != null)
            initializer(r);
        return r;
    }

}

public static class JLActionExtensions
{
    /// <summary>
    /// Calls <see cref="JLAction.Execute"/> if the specified <paramref name="action"/> is not null, otherwise returns null
    /// </summary>
    public static IEnumerator<YieldMode> ExecuteSafe(this JLAction action, IExecutionContext context)
    {
        if (action == null) return null;
        return action.Execute(context);
    }

}