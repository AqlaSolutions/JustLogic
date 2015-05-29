using System;

namespace JustLogic.Core
{
    /// <summary>
    /// Mark your unit parameters with this attribute to be shown in the inspector
    /// </summary>
    /// <tocexclude />
    public interface IParameterAttribute
    {
        /// <summary>
        /// Overrides parameter name
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Help text
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Parameter sort order in the unit inspector
        /// </summary>
        int InspectorOrder { get; }

        /// <summary>
        /// Determinates weather an expression return type should be retrieved from the container unit return type
        /// </summary>
        bool UseContainerExpressionType { get; }

        /// <summary>
        /// Expression return type
        /// </summary>
        Type ExpressionType { get; }

        /// <summary>
        /// A unit to be used as a default value
        /// </summary>
        Type DefaultUnitType { get; }

        /// <summary>
        /// Optional parameter names are shown in the inspector inside square brackets
        /// </summary>
        bool IsOptional { get; }

        /// <summary>
        /// Overrides inspector display type
        /// </summary>
        ParameterAttribute.OverrideTypes OverrideType { get; }
    }

    public class ParameterRuntimeAttribute : IParameterAttribute
    {
        /// <inheritdoc />
        public string Name { get; private set; }
        /// <inheritdoc />
        public string Description { get; private set; }
        /// <inheritdoc />
        public int InspectorOrder { get; private set; }
        /// <inheritdoc />
        public bool UseContainerExpressionType { get; private set; }
        /// <inheritdoc />
        public Type ExpressionType { get; private set; }
        /// <inheritdoc />
        public Type DefaultUnitType { get; private set; }
        /// <inheritdoc />
        public bool IsOptional { get; private set; }
        /// <inheritdoc />
        public ParameterAttribute.OverrideTypes OverrideType { get; private set; }


        public ParameterRuntimeAttribute(IParameterAttribute other)
        {
            Name = other.Name;
            Description = other.Description;
            InspectorOrder = other.InspectorOrder;
            UseContainerExpressionType = other.UseContainerExpressionType;
            ExpressionType = other.ExpressionType;
            DefaultUnitType = other.DefaultUnitType;
            IsOptional = other.IsOptional;
            OverrideType = other.OverrideType;
        }

        public ParameterRuntimeAttribute(string name, string description, int inspectorOrder, bool useContainerExpressionType, Type expressionType, Type defaultUnitType, bool isOptional, ParameterAttribute.OverrideTypes overrideType)
        {
            Name = name;
            Description = description;
            InspectorOrder = inspectorOrder;
            UseContainerExpressionType = useContainerExpressionType;
            ExpressionType = expressionType;
            DefaultUnitType = defaultUnitType;
            IsOptional = isOptional;
            OverrideType = overrideType;
        }
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class ParameterAttribute : Attribute, IParameterAttribute
    {
        private Type _defaultUnitType;
        private string _defaultUnitTypeName;

        /// <inheritdoc />
        public string Name { get; set; }
        /// <inheritdoc />
        public string Description { get; set; }
        /// <inheritdoc />
        public int InspectorOrder { get; set; }
        /// <inheritdoc />
        public bool UseContainerExpressionType { get; set; }
        /// <inheritdoc />
        public Type ExpressionType { get; set; }
        /// <inheritdoc />
        public Type DefaultUnitType
        {
            get { return _defaultUnitType ?? (_defaultUnitType = _defaultUnitTypeName != null ? Library.FindType(_defaultUnitTypeName) : null); }
            set { _defaultUnitType = value; }
        }

        /// <summary>
        /// The full name of the default unit type (specify instead of <see cref="DefaultUnitType"/>)
        /// </summary>
        public string DefaultUnitTypeName
        {
            get { return _defaultUnitType != null ? _defaultUnitType.FullName : _defaultUnitTypeName; }
            set
            {
                if (_defaultUnitType != null && _defaultUnitType.FullName != value)
                    throw new InvalidOperationException("DefaultUnitType is already set");
                _defaultUnitTypeName = value;
            }
        }

        /// <inheritdoc />
        public bool IsOptional { get; set; }

        /// <tocexclude />
        public enum OverrideTypes
        {
            None,
            Type,
            Enum,
            EventArgument,
            OneLineString,
            LayerMask,
            Layer,
            Char
        }

        /// <inheritdoc />
        public OverrideTypes OverrideType { get; set; }

        public ParameterAttribute()
        {
            Name = Description = string.Empty;
        }
    }
}