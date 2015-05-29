using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace JustLogic.Core
{
    [Serializable]
    public class MethodInvokation : MethodInvokationBase
    {
        public SerializableMethod Method;
        public override SerializableMethodBase MethodAccessor { get { return Method; } set { Method = (SerializableMethod)value; } }

        public MethodInvokationArgument[] Arguments;
        public override MethodInvokationArgumentBase[] ArgumentsAccessor { get { return Arguments; } set { Arguments = value != null ? value.Select(a => (MethodInvokationArgument)a).ToArray() : null; } }
    }
}