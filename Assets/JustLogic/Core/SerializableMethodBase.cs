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
using System.Collections.ObjectModel;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace JustLogic.Core
{
    /// <tocexclude />
    [Serializable]
    public abstract class SerializableMethodBase
    {
        public bool IsValid { get { return _isValid; } }
        public string MethodName { get { return _methodName; } }
        public string Signature { get { return _signature; } }

        MethodInfo _methodCache;

        [SerializeField]
        [ObfuscationAttribute(Feature = "renaming", Exclude = true, StripAfterObfuscation = true)]
        string _type;

        public MethodInfo MethodInfo
        {
            get
            {
                if (_methodCache != null) return _methodCache;
                TypeInfo t = Library.FindType(_type);
                if (t == null) return null;
                return _methodCache = t.TryLookupMethod(this);
            }
        }

        IList<ParameterInfo> _parametersCache;
        public IList<ParameterInfo> Parameters
        {
            get
            {
                if (_parametersCache != null) return _parametersCache;
                var method = MethodInfo;
                if (method == null) return null;
                return _parametersCache = new ReadOnlyCollection<ParameterInfo>(method.GetParameters());
            }
        }

        public int TypeArguments { get { return _typeArguments; } }
        public int RefOrOutParameters { get { return _refOrOutParameters; } }

        [SerializeField]
        [ObfuscationAttribute(Feature = "renaming", Exclude = true, StripAfterObfuscation = true)]
        int _refOrOutParameters;
        [SerializeField]
        [ObfuscationAttribute(Feature = "renaming", Exclude = true, StripAfterObfuscation = true)]
        int _typeArguments;
        [SerializeField]
        [ObfuscationAttribute(Feature = "renaming", Exclude = true, StripAfterObfuscation = true)]
        bool _isValid;
        [SerializeField]
        [ObfuscationAttribute(Feature = "renaming", Exclude = true, StripAfterObfuscation = true)]
        string _methodName;
        [SerializeField]
        [ObfuscationAttribute(Feature = "renaming", Exclude = true, StripAfterObfuscation = true)]
        string _signature;
        [SerializeField]
        [ObfuscationAttribute(Feature = "renaming", Exclude = true, StripAfterObfuscation = true)]
        int _hashCode;
        [SerializeField]
        [ObfuscationAttribute(Feature = "renaming", Exclude = true, StripAfterObfuscation = true)]
        byte[] _stamp;

        public SerializableMethodBase()
        {
        }

        public static int GetTypeParametersCount(MethodInfo method)
        {
            if (method.ContainsGenericParameters)
            {
                int i = 0;
                for (int j = 0; j < method.GetGenericArguments().Length; j++)
                {
                    var genericArgument = method.GetGenericArguments()[j];
                    if (genericArgument.IsGenericParameter)
                        i++;
                }
                return i;
            }
            return 0;
        }

        public static implicit operator SerializableMethodBase(MethodInfo method)
        {
            return Library.Instantiator.CreateSerializableMethodBase(method);
        }

        protected SerializableMethodBase(MethodInfo method)
        {
            _methodName = method.Name;
            var sb = new StringBuilder();
            if (method.IsStatic)
                sb.Append("static");
            sb.Append(method.ReturnType.FullName);
            sb.Append(" ");
            sb.Append(_methodName);
            if (method.ContainsGenericParameters)
            {
                int count = GetTypeParametersCount(method);
                _typeArguments = count;
                if (count != 0)
                {
                    sb.Append("~");
                    sb.Append(count);
                }

            }
            sb.Append("(");
            for (int i = 0; i < method.GetParameters().Length; i++)
            {
                if (i != 0)
                    sb.Append(", ");
                var parameter = method.GetParameters()[i];
                if (parameter.IsOut)
                {
                    _refOrOutParameters++;
                    sb.Append("out ");
                }
                Type type = parameter.ParameterType;
                if (type.IsByRef)
                {
                    _refOrOutParameters++;
                    sb.Append("ref ");
                    // ReSharper disable once PossibleNullReferenceException
                    sb.Append(type.GetElementType().FullName);
                }
                else sb.Append(type.FullName);
            }
            _signature = sb.ToString();
            _stamp = Encoding.UTF8.GetBytes(_signature);
            _hashCode = _signature.GetHashCode();
            // ReSharper disable once PossibleNullReferenceException
            _type = method.ReflectedType.FullName;
            _isValid = true;
        }

        public override bool Equals(object obj)
        {
            var mp = obj as SerializableMethodBase;
            if (mp == null) return false;
            var otherStamp = mp._stamp;
            int length = _stamp.Length;
            if (otherStamp.Length != length)
                return false;
            for (int i = 0; i < length; i++)
            {
                if (otherStamp[i] != _stamp[i])
                    return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            // should be serializable so can't be read only
            // ReSharper disable once NonReadonlyMemberInGetHashCode
            return _hashCode;
        }

        Type _typeCache;
        public Type DeclaringType { get { return _typeCache ?? (_typeCache = Library.FindType(_type)); } }
    }

    public static class MethodPointerExtensions
    {
        public static bool IsExistAndValid(this SerializableMethodBase mp, Type checkDeclaringType)
        {
            return mp != null && mp.IsValid && mp.DeclaringType.IsAssignableFrom(checkDeclaringType);
        }
    }
}