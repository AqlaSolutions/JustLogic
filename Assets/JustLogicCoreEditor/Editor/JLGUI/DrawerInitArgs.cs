using System;
using System.Collections.Generic;
using UnityEngine;
using JustLogic.Core;

namespace JustLogic.Editor.JLGUI
{
    public struct DrawerInitArgs
    {
        private readonly GUIContent _label;
        private readonly IParameterDrawer _container;
        private readonly TypeInfo _containerExpressionType;
        private readonly TypeInfo _supportedType;
        private readonly UnitParameter _parameterInfo;
        private readonly IParameterDrawersFactory _factory;
        private readonly IList<object> _containerAttributes;
        private readonly bool _noHeader;

        public DrawerInitArgs(Type supportedType, string label = null, bool noHeader = false, Type expressionType = null, Type defaultUnitType = null, bool useContainerExpressionType = false, TypeInfo drawerType = null, IParameterDrawersFactory factory = null, TypeInfo containerExpressionType = null)
            : this()
        {
            if (factory == null)
                factory = ParameterDrawersFactory.Default;
            if (label != null)
            {
                var labelContent = new GUIContent(label ?? string.Empty);
                _label = labelContent;
            }
            _supportedType = supportedType;
            _factory = factory;
            _containerExpressionType = containerExpressionType;
            _noHeader = noHeader;
            var name = _label != null ? (!string.IsNullOrEmpty(_label.text) ? _label.text : string.Empty) : string.Empty;
            _parameterInfo = new UnitParameter(
                new ParameterRuntimeAttribute(name, string.Empty, 0, useContainerExpressionType, expressionType,
                    defaultUnitType, false, ParameterAttribute.OverrideTypes.None),
                    supportedType, name, 0, null, null, drawerType, false, new object[0]);
        }

        public DrawerInitArgs(string label, IParameterDrawer container, TypeInfo supportedType, IParameterDrawersFactory factory, IList<object> containerAttributes = null, UnitParameter parameterInfo = null, bool noHeader = false, TypeInfo containerExpressionType = null)
            : this(new GUIContent(label ?? string.Empty, supportedType.Type.GetSimpleName()), container, supportedType, factory, containerAttributes, parameterInfo, noHeader, containerExpressionType)
        {
        }

        public DrawerInitArgs(IParameterDrawer container, Type supportedType, IParameterDrawersFactory factory, IList<object> containerAttributes = null, UnitParameter parameterInfo = null, bool noHeader = false, TypeInfo containerExpressionType = null)
            : this(null, container, supportedType, factory, containerAttributes, parameterInfo, noHeader, containerExpressionType)
        {
        }

        public DrawerInitArgs(GUIContent label, IParameterDrawer container, Type supportedType, IParameterDrawersFactory factory, IList<object> containerAttributes = null, UnitParameter parameterInfo = null, bool noHeader = false, TypeInfo containerExpressionType = null)
        {
            if (label != null && string.IsNullOrEmpty(label.text))
            {
                if (string.IsNullOrEmpty(label.tooltip) || (label.tooltip == supportedType.Name) || (label.tooltip == supportedType.FullName) || (label.tooltip == supportedType.GetSimpleName()))
                    label = null;
                else
                {
                    label = new GUIContent(label);
                    label.text = label.tooltip;
                    label.tooltip = string.Empty;
                }
            }
            _label = label;
            _container = container;
            _supportedType = supportedType;
            _factory = factory;
            _containerAttributes = containerAttributes;
            _parameterInfo = parameterInfo;
            _noHeader = noHeader;
            _containerExpressionType = containerExpressionType;
        }

        public TypeInfo ExpressionType
        {
            get
            {
                if (ParameterInfo == null)
                    return null;

                if (ParameterInfo.ExpressionType != null)
                {
                    if (!ParameterInfo.UseContainerExpressionType || ContainerExpressionType == null
                        || ParameterInfo.ExpressionType.Type.IsSubclassOf(ContainerExpressionType))
                        return ParameterInfo.ExpressionType;
                }
                return ParameterInfo.UseContainerExpressionType ? ContainerExpressionType : null;
            }
        }

        public TypeInfo ContainerExpressionType { get { return _containerExpressionType; } }
        public UnitParameter ParameterInfo { get { return _parameterInfo; } }
        public IList<object> ContainerAttributes { get { return _containerAttributes; } }
        public GUIContent Label { get { return _label; } }
        public IParameterDrawer Container { get { return _container; } }
        public TypeInfo SupportedType { get { return _supportedType; } }
        public IParameterDrawersFactory Factory { get { return _factory; } }
        public bool NoHeader { get { return _noHeader; } }
    }
}