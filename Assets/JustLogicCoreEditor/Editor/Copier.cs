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
using System.Collections.Generic;
using System.Reflection;
using JustLogic.Core;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace JustLogic.Editor
{
    public static class Copier
    {
        interface ICopiedElementsContainer
        {
            List<CopiedElement> List { get; }
            List<UnityEngine.Object> References { get; }
            int MaxDeep { get; set; }
        }

        /// <tocexclude />
        public struct CopiedElement
        {
            public readonly Type Type;
            public readonly object Data;
            public readonly bool IsDirect;
            public readonly int ArrayCount;
            public CopiedElement(Type type, object data = null, bool isDirect = false, int arrayCount = 0)
            {
                Type = type;
                Data = data;
                IsDirect = isDirect;
                ArrayCount = arrayCount;
            }
        }

        /// <tocexclude />
        public class CopiedData : ICopiedElementsContainer
        {
            DateTime _time;
            public CopiedData()
            {
                _time = DateTime.Now;
            }

            private readonly List<CopiedElement> _list = new List<CopiedElement>();
            private readonly List<UnityEngine.Object> _references = new List<UnityEngine.Object>();

            public int Complexity { get { return _list.Count; } }

            public Type Type { get { return _list[0].Type; } }

            List<Object> ICopiedElementsContainer.References { get { return _references; } }

            public UnityEngine.Object[] References { get { return _references.ToArray(); } }

            public int MaxDeep { get; set; }
            List<CopiedElement> ICopiedElementsContainer.List { get { return _list; } }

            public override string ToString()
            {
                return "{Snapshot " + _time + "}";
            }
        }

        /// <summary>
        /// Warning: does full copy-operation
        /// </summary>
        public static int GetCompexity(object obj)
        {
            return CreateSnapshot(obj).Complexity;
        }

        static CopiedData _buffer;
        public static void Store(object obj, Type type)
        {
            _buffer = CreateSnapshot(obj, type);
        }

        public static object Restore()
        {
            return RestoreSnapshot(_buffer);
        }

        public static Type StoredObjectType { get { return _buffer != null ? _buffer.Type : null; } }


        public static CopiedData CreateSnapshot(object obj, Type type = null)
        {
            if (type == null)
                type = obj == null ? typeof(object) : obj.GetType();
            var data = new CopiedData();
            CopyRecursively(obj, type, data, 0);
            return data;
        }

        static void CopyRecursively(object obj, Type type, ICopiedElementsContainer data, int deep)
        {
            if (data.MaxDeep < deep)
                data.MaxDeep = deep;
            if (obj != null)
                type = obj.GetType();
            if ((obj == null) || IsDirectType(type))
            {
                data.List.Add(new CopiedElement(type, obj, true));
                if (typeof(UnityEngine.Object).IsAssignableFrom(type))
                    data.References.Add((UnityEngine.Object)obj);
                return;
            }

            TypeInfo typeInfo = type;
            if (typeof(JLUnitBase).IsAssignableFrom(type))
            {
                data.List.Add(new CopiedElement(type));
                foreach (var p in typeInfo.JustLogicParameters.List)
                    CopyRecursively(p.Getter(obj), p.Type, data, deep + 1);
                if (typeof(JLAction).IsAssignableFrom(type))
                    CopyRecursively(((JLAction)obj).On, typeof(bool), data, deep + 1);
            }
            else if (type.IsArray || typeof(IList).IsAssignableFrom(type))
            {
                var lst = (IList)obj;
                int count;
                if ((lst == null) || ((count = lst.Count) == 0))
                    data.List.Add(new CopiedElement(type));
                else
                {
                    var elementType = type.IsArray ? type.GetElementType() : null;
                    data.List.Add(new CopiedElement(type, arrayCount: count));
                    for (int i = 0; i < count; i++)
                        CopyRecursively(lst[i], elementType, data, deep + 1);
                }
            }
            else
            {
                data.List.Add(new CopiedElement(type));
                foreach (var field in typeInfo.Fields)
                {
                    if ((!field.IsPublic && field.GetCustomAttributes(typeof(SerializeField), true).Length == 0) || field.IsNotSerialized)
                        continue;
                    CopyRecursively(field.GetValue(obj), field.FieldType, data, deep + 1);
                }
            }
        }

        public static UnityEngine.Object[] CollectReferences(object obj)
        {
            var lst = new List<UnityEngine.Object>();
            CollectReferencesRecursively(obj, null, lst);
            return lst.ToArray();
        }

        static void CollectReferencesRecursively(object obj, Type type, List<UnityEngine.Object> references)
        {
            if (obj != null)
                type = obj.GetType();
            if ((obj == null) || IsDirectType(type))
            {
                if (typeof(UnityEngine.Object).IsAssignableFrom(type))
                    references.Add((UnityEngine.Object)obj);
                return;
            }

            TypeInfo typeInfo = type;
            if (typeof(JLUnitBase).IsAssignableFrom(type))
            {
                foreach (var p in typeInfo.JustLogicParameters.List)
                    CollectReferencesRecursively(p.Getter(obj), p.Type, references);
            }
            else if (type.IsArray || typeof(IList).IsAssignableFrom(type))
            {
                var lst = (IList)obj;
                int count;
                if ((lst != null) && ((count = lst.Count) != 0))
                {
                    var elementType = type.IsArray ? type.GetElementType() : null;
                    for (int i = 0; i < count; i++)
                        CollectReferencesRecursively(lst[i], elementType, references);
                }
            }
            else
            {
                foreach (var field in typeInfo.Fields)
                {
                    if ((!field.IsPublic && field.GetCustomAttributes(typeof(SerializeField), true).Length == 0) || field.IsNotSerialized)
                        continue;
                    CollectReferencesRecursively(field.GetValue(obj), field.FieldType, references);
                }
            }
        }

        private static bool IsDirectType(Type type)
        {
            return !type.IsArray
                   && (
                        type.IsValueType
                     || (!typeof(IList).IsAssignableFrom(type)
                   && ((!type.IsPublic && !type.IsNestedPublic)
                      || (!typeof(JLUnitBase).IsAssignableFrom(type) &&
                         (typeof(Object).IsAssignableFrom(type) ||
                          !Attribute.IsDefined(type, typeof(SerializableAttribute)))
                         )
                      || (type.GetConstructor(new Type[0]) == null))
                      )
                     );
        }

        public static object RestoreSnapshot(CopiedData data, IList<UnityEngine.Object> references = null)
        {
            int iterator = 0;
            int refIndex = 0;
            if (references != null && (references.Count == 0)) references = null;
            return PasteRecursively(data, ref iterator, ref refIndex, references);
        }

        static object PasteRecursively(ICopiedElementsContainer data, ref int iterator, ref int referencesIndex, IList<UnityEngine.Object> references = null)
        {
            var el = data.List[iterator++];
            if (el.IsDirect)
            {
                if (references != null && typeof(UnityEngine.Object).IsAssignableFrom(el.Type))
                {
                    var r = references[referencesIndex++];
                    return r ? r : null;
                }
                return el.Data;
            }

            var type = el.Type;
            var isUnit = typeof(JLUnitBase).IsAssignableFrom(type);

            TypeInfo typeInfo = type;

            object obj;

            if (isUnit)
            {
                obj = JLScriptableHelper.CreateNew(type);
                foreach (var p in typeInfo.JustLogicParameters.List)
                {
                    JLScriptableHelper.Destroy(p.Getter(obj));
                    p.Setter(obj, PasteRecursively(data, ref iterator, ref referencesIndex, references));
                }
                if (typeof(JLAction).IsAssignableFrom(type))
                    ((JLAction)obj).On = (bool)PasteRecursively(data, ref iterator, ref referencesIndex, references);
            }
            else if (type.IsArray || typeof(IList).IsAssignableFrom(type))
            {
                int count = el.ArrayCount;
                obj = null;
                try
                {
                    obj = type.IsArray ? Array.CreateInstance(type.GetElementType(), count) : Activator.CreateInstance(type);
                }
                catch
                {
                    if (count == 0)
                        return obj;
                    throw;
                }
                var lst = (IList)obj;
                for (int i = 0; i < count; i++)
                {
                    var v = PasteRecursively(data, ref iterator, ref referencesIndex, references);
                    if (!type.IsArray)
                        lst.Add(v);
                    else
                        lst[i] = v;
                }
            }
            else
            {
                obj = Activator.CreateInstance(type);
                foreach (var field in typeInfo.Fields)
                {
                    if ((!field.IsPublic && field.GetCustomAttributes(typeof(SerializeField), true).Length == 0) || field.IsNotSerialized)
                        continue;
                    field.SetValue(obj, PasteRecursively(data, ref iterator, ref referencesIndex, references));
                }
            }
            return obj;
        }

        public static object Duplicate(object obj, IList<UnityEngine.Object> references = null)
        {
            if (obj == null) return null;
            return RestoreSnapshot(CreateSnapshot(obj, obj.GetType()), references);
        }
    }
}