using UnityEngine;

namespace JustLogic.Core
{
    public interface IExecutionContext
    {
        /// <summary>
        /// Retreives a reference to the variable by the specified "selected in the inspector" variable info
        /// </summary>
        Variable GetVariable(SelectedVariableInfoBase info);

        /// <summary>
        /// The owner game object of the <see cref="ExecutionContext"/> instance
        /// </summary>
        GameObject ExecutorObject { get; set; }
        
        /// <summary>
        /// The owner behavior component of the <see cref="ExecutionContext"/> instance
        /// </summary>
        MonoBehaviour ExecutorBehavior { get; set; }

        /// <summary>
        /// Contains the event from which the execution has been raised
        /// </summary>
        EventData CurrentEvent { get; set; }
    }
}