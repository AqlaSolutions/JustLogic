using System;

namespace JustLogic.Core
{
    /// <summary>
    /// Inherit this interface to make your custom event
    /// </summary>
    /// <remarks>It's recommended to make your event description as singleton</remarks>
    public interface IEventDescription
    {
        /// <summary>
        /// The name which should be displayed in the inspector
        /// </summary>
        string Name { get; }

        /// <summary>
        /// The event parameters information
        /// </summary>
        EventDescriptionArguments Arguments { get; }

        /// <summary>
        /// Should be typeof(your inheritor of <see cref="JustLogicEventHandlerCoreBase"/>).FullName
        /// </summary>
        string RequiredEventHandler { get; }
    }
}