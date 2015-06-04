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