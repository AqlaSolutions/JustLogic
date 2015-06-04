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
    /// For hashtables, supports aliases
    /// </summary>
    public class TypeKey
    {
        public Type Type { get; private set; }
        public TypeInfo InternalType { get { return _internalType; } }

        TypeKey(Type type)
        {
            Type = type;
            _internalType = GetMainAlias(type);
            _hashCode = _internalType.GetHashCode();
        }

        public static Type GetMainAlias(Type type)
        {
            if ((type == typeof(long))
              || (type == typeof(ulong))
              || (type == typeof(short))
              || (type == typeof(ushort))
              || (type == typeof(byte))
              || (type == typeof(sbyte)))
                return typeof(int);
            else if ((type == typeof(decimal))
                     || (type == typeof(double)))
                return typeof(float);
            else
                return type;
        }

        public static implicit operator TypeKey(Type type)
        {
            return new TypeKey(type);
        }

        public static implicit operator Type(TypeKey type)
        {
            return type.Type;
        }

        readonly TypeInfo _internalType;
        readonly int _hashCode;

        public override int GetHashCode()
        {
            return _hashCode;
        }

        public override bool Equals(object obj)
        {
            Type t;
            var tk = obj as TypeKey;
            if (tk != null)
                t = tk.InternalType;
            else
            {
                t = obj as Type;
                if (t == null) return false;
                t = GetMainAlias(t);
            }
            return _internalType == t;
        }
    }
}