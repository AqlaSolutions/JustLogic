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
  
using System.Reflection;
using UnityEngine;

namespace JustLogic.Core
{
    public class ConcreteInstantiator : Instantiator
    {
        public override SerializableMethodBase CreateSerializableMethodBase(MethodInfo method)
        {
            return new SerializableMethod(method);
        }

        public override MethodInvokationArgumentBase CreateMethodInvokationArgumentBase(JLExpression value, SelectedVariableInfoBase outVariable = null)
        {
            return new MethodInvokationArgument(value, outVariable);
        }

        public override MethodInvokationBase CreateMethodInvokationBase()
        {
            return new MethodInvokation();
        }

        public override SerializedEnumBase CreateSerializedEnumBase()
        {
            return new SerializedEnum();
        }

        public override SelectedVariableInfoBase CreateSelectedVariableInfoBase()
        {
            return new SelectedVariableInfo();
        }

        public override ScriptableObject CreateScriptable(System.Type type)
        {
            if (type == typeof(JLAndBase)) return ScriptableObject.CreateInstance<JLAnd>();
            if (type == typeof(JLEvaluteBase)) return ScriptableObject.CreateInstance<JLEvalute>();
            if (type == typeof(JLIfBase)) return ScriptableObject.CreateInstance<JLIf>();
            if (type == typeof(JLNullReferenceBase)) return ScriptableObject.CreateInstance<JLNullReference>();
            if (type == typeof(JLPrintRetBase)) return ScriptableObject.CreateInstance<JLPrintRet>();
            if (type == typeof(JLSequenceBase)) return ScriptableObject.CreateInstance<JLSequence>();
            if (type == typeof(JLCompareEventArgumentBase)) return ScriptableObject.CreateInstance<JLCompareEventArgument>();
            if (type == typeof(JLCompareBase)) return ScriptableObject.CreateInstance<JLCompare>();
            if (type == typeof(JLNoopBase)) return ScriptableObject.CreateInstance<JLNoop>();
            if (type == typeof(JLStringValueBase)) return ScriptableObject.CreateInstance<JLStringValue>();
            if (type == typeof(JLEventArgumentBase)) return ScriptableObject.CreateInstance<JLEventArgument>();
            if (type == typeof(JLObjectValueBase)) return ScriptableObject.CreateInstance<JLObjectValue>();
            if (type == typeof(JLCustomScriptAssetBase)) return ScriptableObject.CreateInstance<JLCustomScriptAsset>();
            if (type == typeof(JLCustomExpressionAssetBase)) return ScriptableObject.CreateInstance<JLCustomExpressionAsset>();
            return base.CreateScriptable(type);
        }
    }
}