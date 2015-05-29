using System;

namespace JustLogic.Core
{
    public static class EditorEventsMediator
    {
#if !JUSTLOGIC_FREE
        public static Action<JustLogicSceneExpressionBase> OnSceneExpressionDuplicated;
#endif

        public static Action<JustLogicScriptBase> OnSceneScriptDuplicated;
        public static Action<JustLogicEventHandlerCoreBase> OnEventHandlerDuplicated;
        
        public static Action<JustLogicScriptableContainerBase> OnConstructorCalled;
        public static Action<JustLogicScriptableContainerBase> OnAwakeCalled;
    }
}