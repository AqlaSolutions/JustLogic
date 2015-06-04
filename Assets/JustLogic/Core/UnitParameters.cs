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
using JustLogic.Editor.JLGUI;
using UnityEngine;

namespace JustLogic.Core
{
    /// <tocexclude />
    public class UnitParameters
    {
        public static readonly UnitParameters None = new UnitParameters();

        public IList<UnitParameter> List { get; private set; }
        public UnitParameter ValueParameter { get; private set; }

        public UnitParameters(params UnitParameter[] pars)
        {
            List = new ReadOnlyCollection<UnitParameter>(pars);
            foreach (var unitParameter in pars)
            {
                if (unitParameter.Name.Equals("value", StringComparison.OrdinalIgnoreCase))
                {
                    ValueParameter = unitParameter;
                    break;
                }
            }
        }

        readonly static Dictionary<Type, UnitParameters> Cache = new Dictionary<Type, UnitParameters>();

        public static UnitParameters Get(Type container)
        {
            UnitParameters parameters;
            if (Cache.TryGetValue(container, out parameters))
                return parameters;

            var list = new List<UnitParameter>();

            var fields = container.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            var properties = container.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            for (int i = 0; i < fields.Length; i++)
            {
                var field = fields[i];
                if (field.IsPublic || (Attribute.IsDefined(field, typeof(SerializeField))))
                    TryAddParameterInfo(list, field, field.FieldType, field.GetValue, field.SetValue);
            }

            for (int i = 0; i < properties.Length; i++)
            {
                var property = properties[i];
                TryAddParameterInfo(list, property, property.PropertyType, o => property.GetValue(o, BindingFlags.Default, null, null, null), (o, v) => property.SetValue(o, v, null));
            }

            Cache[container] = parameters = new UnitParameters(list.ToArray());

            return parameters;
        }

        readonly static string[] AutoNames = new[] { "value", "values", "expression", "expressions", "block", "action", "actions", "operands", "operand", "argument", "arguments", "parameter", "parameters", "operandvalue", "operand value", "unit" };

        static bool IsAutoName(string value)
        {
            for (int i = 0; i < AutoNames.Length; i++)
            {
                if (value.Equals(AutoNames[i], StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        static bool TryAddParameterInfo(IList<UnitParameter> list, MemberInfo element, Type propertyType, Func<object, object> getter, Action<object, object> setter)
        {
            var attr = (ParameterAttribute)Attribute.GetCustomAttribute(element, typeof(ParameterAttribute));
            if (attr == null) return false;
            var useDrawerAttr = (UseDrawerAttribute)Attribute.GetCustomAttribute(element, typeof(UseDrawerAttribute));
            string name = !string.IsNullOrEmpty(attr.Name) ? attr.Name : TypeInfo.GenerateMemberFriendlyName(element.Name);
            TypeInfo drawerType;
            if (useDrawerAttr != null)
                drawerType = Library.FindType(useDrawerAttr.TypeFullName);
            else
            {
                drawerType = attr.OverrideType != ParameterAttribute.OverrideTypes.None
                    ? Library.FindType("JustLogic.Editor.JLGUI.Drawers." + attr.OverrideType.ToString() + "Drawer")
                    : null;
            }
            list.Add(new UnitParameter(attr, propertyType, name,
                list.Count, getter, setter, drawerType, !propertyType.IsArray && IsAutoName(name), new ReadOnlyCollection<object>(element.GetCustomAttributes(true))));
            return true;
        }
    }

    /// <tocexclude />
    public class UnitParameter
    {
        private readonly IParameterAttribute _attr;
        public string Description { get { return _attr.Description; } }

        public int InspectorOrder { get { return _attr.InspectorOrder; } }

        public bool UseContainerExpressionType { get { return _attr.UseContainerExpressionType; } }

        public TypeInfo ExpressionType { get; private set; }

        public Type DefaultUnitType { get { return _attr.DefaultUnitType; } }

        public bool IsOptional { get { return _attr.IsOptional; } }

        [Obsolete("Use Drawer property to get appropriate drawer")]
        public ParameterAttribute.OverrideTypes OverrideType { get { return _attr.OverrideType; } }

        public Type Type { get; private set; }
        public TypeInfo TypeInfo { get; private set; }
        public string Name { get; private set; }
        public int Index { get; private set; }
        public Func<object, object> Getter { get; private set; }
        public Action<object, object> Setter { get; private set; }
        public bool IsAutoValue { get; private set; }
        public TypeInfo Drawer { get; private set; }
        public IList<object> Attributes { get; private set; }

        public UnitParameter(IParameterAttribute attr, Type type, string name, int index, Func<object, object> getter, Action<object, object> setter, TypeInfo drawerType, bool isAutoValue, IList<object> attributes)
        {
            _attr = attr;
            Attributes = attributes;
            ExpressionType = attr.ExpressionType;
            IsAutoValue = isAutoValue;
            Drawer = drawerType;
            Setter = setter;
            Getter = getter;
            Index = index;
            TypeInfo = Type = type;
            Name = name;
        }
    }


}