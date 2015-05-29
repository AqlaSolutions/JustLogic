using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace JustLogic.Core
{
    [Serializable]
    public class SerializableMethod : SerializableMethodBase
    {
        public SerializableMethod()
        {
        }

        public SerializableMethod(MethodInfo method)
            : base(method)
        {
        }
    }
}