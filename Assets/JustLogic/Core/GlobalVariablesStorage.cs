using System.Collections.Generic;

namespace JustLogic.Core
{
    /// <summary>
    /// A static container for global script variables
    /// </summary>
    public static class GlobalVariablesStorage
    {
#if !JUSTLOGIC_FREE
        static readonly Dictionary<string, Variable> Variables = new Dictionary<string, Variable>();
#endif
        /// <summary>
        /// Retrieves a variable by its global name
        /// </summary>
        public static Variable GetVariable(string name)
        {
#if !JUSTLOGIC_FREE

            if (string.IsNullOrEmpty(name))
                return new Variable();
            Variable v;
            if (Variables.TryGetValue(name, out v))
                return v;

            Variables.Add(name, v = new Variable());
            return v;
#else
            return new Variable();
#endif

        }
    }
}