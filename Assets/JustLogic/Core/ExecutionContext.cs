using System;
using System.Collections.Generic;

using UnityEngine;

namespace JustLogic.Core
{
    /// <summary>
    /// Execution context data container
    /// </summary>
    [Serializable]
    public class ExecutionContext : IExecutionContext
    {
        /// <summary>
        /// Local script variables
        /// </summary>
        public Dictionary<string, Variable> Variables { get; set; }

        /// <summary>
        /// Variables which data is preserved between executions
        /// </summary>
        public Dictionary<string, Variable> StaticVariables { get; set; }

        /// <inheritdoc />
        public Variable GetVariable(SelectedVariableInfoBase info)
        {
            if ((info == null) || string.IsNullOrEmpty(info.Name))
                return new Variable();
            if (info.Scope == SelectedVariableInfoBase.VariableScope.Global)
                return GlobalVariablesStorage.GetVariable(info.Name);
            var d = info.IsStatic ? StaticVariables : Variables;
            if (d == null)
            {
                d = new Dictionary<string, Variable>();
                if (info.IsStatic)
                    StaticVariables = d;
                else
                    Variables = d;
            }
            Variable v;
            if (d.TryGetValue(info.Name, out v))
                return v;
            d.Add(info.Name, v = new Variable());
            return v;
        }

        /// <inheritdoc />
        public GameObject ExecutorObject { get; set; }

        /// <inheritdoc />
        public MonoBehaviour ExecutorBehavior { get; set; }

        /// <inheritdoc />
        public EventData CurrentEvent { get; set; }
    }
}