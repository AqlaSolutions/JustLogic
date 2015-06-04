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
  
using System.Linq;
using JustLogic.Core;
using UnityEngine;

/// <summary>
/// A container for your JL script units, access tree through <see cref="JustLogicScript.Engine"/>.<see cref="ExecutionEngineBase.Tree"/>
/// </summary>
/// <remarks>
/// To make a new JL Script, create a new game object (Game Object / Create Empty) and add to it the component JL Script (by pressing the button “Add Component” inspector and entering the component name in the search box).
/// </remarks>
[ExecuteInEditMode]
[AddComponentMenu("Just Logic/JL Script")]
public class JustLogicScript : JustLogicScriptBase, IScriptVariablesDescriber
{
    [SerializeField]
    EditorVariableInfo[] _ctorVariables = new EditorVariableInfo[0];

    [SerializeField]
    EditorVariableInfo[] _ctorStaticVariables = new EditorVariableInfo[0];

    EditorVariableInfoBase[] IScriptVariablesDescriber.CtorVariables { get { return _ctorVariables; } set { _ctorVariables = value.Select(v => (EditorVariableInfo)v).ToArray(); } }
    EditorVariableInfoBase[] IScriptVariablesDescriber.CtorStaticVariables { get { return _ctorStaticVariables; } set { _ctorStaticVariables = value.Select(v => (EditorVariableInfo)v).ToArray(); } }

    public UndoData _editorUndoDataHolder = new UndoData();
    protected override UndoDataBase UndoDataAccessor { get { return _editorUndoDataHolder; } set { _editorUndoDataHolder = (UndoData)value; } }
    protected override UndoDataBase CreateUndoData() { return new UndoData(); }

    /// <summary>
    /// Execution engine itself, use <see cref="ExecutionEngineBase.Tree"/> to access units
    /// </summary>
    public ExecutionEngine Engine = new ExecutionEngine();

    public override ExecutionEngineBase EngineInstance { get { return Engine; } set { Engine = (ExecutionEngine)value; } }

    protected override ExecutionEngineBase CreateExecutionEngine()
    {
        return new ExecutionEngine();
    }
}