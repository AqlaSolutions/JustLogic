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

namespace JustLogic.Core
{
    /// <summary>
    /// Specifies unit usage information
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class UnitUsageAttribute : Attribute
    {
        /// <summary>
        /// Sort order in the units selection window
        /// </summary>
        public int EditorOrder { get; set; }

        /// <summary>
        /// Specifies weather an expression should not be shown in actions list. If false, an expression can be insert with automatic "Evaluate" action wrapper.
        /// </summary>
        public bool HideExpressionInActionsList { get; set; }

        /// <summary>
        /// If set, indicates possible return type of an expression (can be concrete, abstract or interface)
        /// </summary>
        public Type ExpressionReturnType { get; set; }

        TypeInfo _expressionReturnTypeInfo;
        private bool _isDefaultForReturnType;

        /// <summary>
        /// TypeInfo of the specified expression return type; can be null
        /// </summary>
        public TypeInfo ExpressionReturnTypeInfo
        {
            get
            {
                if (ExpressionReturnType == null)
                    return null;
                return _expressionReturnTypeInfo ?? (_expressionReturnTypeInfo = ExpressionReturnType);
            }
        }

        /// <summary>
        /// Only applied to parameters of this type (not fits for base type)
        /// </summary>
        public bool StrictApplicability { get; set; }

        /// <summary>
        /// Can be assigned to subclass (of return type) type
        /// </summary>
        public bool AllowBaseAssignability { get; set; }

        /// <summary>
        /// Determinates weather an expression can be created by an editor as a default value for the specified type; see also <see cref="EditorOrder"/>
        /// </summary>
        public bool IsDefaultExpression { get { return ExpressionReturnType != null && _isDefaultForReturnType; } set { _isDefaultForReturnType = value; } }

        public UnitUsageAttribute(Type expressionReturnType)
        {
            ExpressionReturnType = expressionReturnType;
        }

        public UnitUsageAttribute(bool strictApplicability)
        {
            StrictApplicability = strictApplicability;
        }

        public UnitUsageAttribute()
        {
        }
    }
}