using JustLogic.Core;
using UnityEditor;

namespace JustLogic.Editor
{
    [InitializeOnLoad]
    public class LibraryInitializer
    {
         static LibraryInitializer()
         {
             Library.BeginInitialize();
         }
    }
}