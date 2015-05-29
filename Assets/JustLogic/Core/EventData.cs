using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace JustLogic.Core
{
    /// <summary>
    /// Contains the data of the handled event
    /// </summary>
    public class EventData
    {
        /// <summary>
        /// Event description
        /// </summary>
        public IEventDescription EventInfo { get; private set; }
        /// <summary>
        /// Indicates how many times the event handler was activated
        /// </summary>
        public int Counter { get; private set; }
        /// <summary>
        /// Event handler which received the event
        /// </summary>
        public JustLogicEventHandlerCoreBase Handler { get; private set; }
        /// <summary>
        /// Event concrete arguments of the <see cref="IEventDescription.Arguments"/> types
        /// </summary>
        public IList<object> Arguments { get; private set; }

        /// <summary>
        /// Returns argument by the specified index or null if it does not specified or index is incorrect
        /// </summary>
        public object GetArgumentOrNull(int index)
        {
            if ((Arguments.Count <= index) || (index < 0))
                return null;
            return Arguments[index];
        }

        public EventData(IEventDescription eventInfo, IEnumerable<object> arguments, JustLogicEventHandlerCoreBase handler, int counter)
        {
            EventInfo = eventInfo;
            Counter = counter;
            Handler = handler;
            Arguments = new ReadOnlyCollection<object>(arguments.ToArray2());
        }
    }
}