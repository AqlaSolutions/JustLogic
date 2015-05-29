using JustLogic.Core;
using UnityEditor;

namespace JustLogic.Editor
{
    [InitializeOnLoad]
    public class DuplicationHandler
    {
        static DuplicationHandler()
        {
#if !JUSTLOGIC_FREE
            EditorEventsMediator.OnSceneExpressionDuplicated += OnDuplicated;
#endif

            EditorEventsMediator.OnSceneScriptDuplicated += OnDuplicated;
            EditorEventsMediator.OnEventHandlerDuplicated += OnDuplicated;
        }

        private static void OnDuplicated(JustLogicEventHandlerCoreBase obj)
        {
            obj.EventHandlerData = (JustLogicEventHandlerCoreBase.EventHandlerDataHolder)Copier.Duplicate(obj.EventHandlerData, obj.EditorRelativeReferences);
            ProcessScriptBase(obj);
        }

        private static void OnDuplicated(JustLogicScriptBase obj)
        {
            obj.EngineInstance.Tree = (JLAction)Copier.Duplicate(obj.EngineInstance.Tree, obj.EditorRelativeReferences);
            ProcessScriptBase(obj);
        }

#if !JUSTLOGIC_FREE

        private static void OnDuplicated(JustLogicSceneExpressionBase obj)
        {
            obj.Value = (JLExpression)Copier.Duplicate(obj.Value, obj.EditorRelativeReferences);
            ProcessScriptBase(obj);
        }
        
#endif

        private static void ProcessScriptBase(JustLogicScriptableContainerBase obj)
        {
            obj.EditorRelativeReferences = Copier.CollectReferences(obj.EditorScriptData);
            var undoable = ((IUndoableBehavior)obj);
            undoable.UndoData.UndoPersistentIndex = undoable.UndoData.UndoIndex = 0;
            EditorUtility.SetDirty(obj);
        }
    }
}