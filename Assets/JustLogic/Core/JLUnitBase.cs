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
using UnityEngine;

/// <summary>
/// Base class for units
/// </summary>
/// <remarks>
/// A JL Script is composed of units - <see cref="JLAction"/> and <see cref="JLExpression"/>.
/// An expression differs from an action: it has returning value - the result of its work. This value can be immediately used as an argument for another unit.<br />
/// Examples of actions: move the object, load level, slow down time.<br />
/// Examples of expressions: find the main camera, compare two numbers, get the length of the string.<br />
/// </remarks>
public abstract class JLUnitBase : JLScriptable
{
    public static Func<Type, ScriptableObject> CreateInstanceFunc;


    /// <summary>
    /// ScriptableObject.CreateInstance shortcut
    /// </summary>
    public new static T CreateInstance<T>() where T : ScriptableObject
    {
        return (T)(CreateInstanceFunc == null ? Library.Instantiator.CreateScriptable<T>() : CreateInstanceFunc(typeof(T)));
    }
    
    /// <summary>
    /// ScriptableObject.CreateInstance shortcut
    /// </summary>
    public new static ScriptableObject CreateInstance(Type type)
    {
        return CreateInstanceFunc == null ? Library.Instantiator.CreateScriptable(type) : CreateInstanceFunc(type);
    }

    /// <summary>
    /// ScriptableObject.CreateInstance shortcut
    /// </summary>
    public new static ScriptableObject CreateInstance(string classname)
    {
        return CreateInstanceFunc == null ? Library.Instantiator.CreateScriptable(classname) : CreateInstanceFunc(Library.FindType(classname));
    }

    /// <summary>
    /// Weather unit is expanded in the inspector
    /// </summary>
    public bool Expanded = true;

}
