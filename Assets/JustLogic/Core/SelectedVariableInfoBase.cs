using System;

namespace JustLogic.Core
{
    /// <tocexclude />
    [Serializable]
    public abstract class SelectedVariableInfoBase
    {
        [Parameter]
        public string Name = string.Empty;


        public bool IsStatic
        {
            get { return Scope == VariableScope.Static; }
            set
            {
                Scope = value ? VariableScope.Static : VariableScope.Local;
            }
        }

        [Parameter]
        public VariableScope Scope;

        public Variable Get(IExecutionContext context)
        {
            switch (Scope)
            {
                case VariableScope.Local:
                case VariableScope.Global:
                    return context.GetVariable(this);
                default:
                    return GlobalVariablesStorage.GetVariable(Name);
            }
        }

        /// <tocexclude />
        [Serializable]
        public enum VariableScope
        {
            Local,
            Static,
            Global
        }
    }

}
