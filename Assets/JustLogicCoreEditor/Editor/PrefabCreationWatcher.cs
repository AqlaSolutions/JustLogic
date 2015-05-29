using System;
using System.Collections.Generic;
using JustLogic.Core;
using UnityEditor;
using UnityEngine;

namespace JustLogic.Editor
{
    [InitializeOnLoad]
    public class PrefabCreationWatcher
    {
        static PrefabCreationWatcher()
        {
            EditorEventsMediator.OnAwakeCalled += OnAwake;
            EditorEventsMediator.OnConstructorCalled += OnConstructor;
            EditorApplication.update += OnUpdateEditor;
        }

        private static void OnUpdateEditor()
        {
            for (int i = 0; i < CheckList.Count; i++)
            {
                try
                {
                    var prefabObj = CheckList[i];
                    if (!prefabObj) continue;
                    if (prefabObj.StoredInstanceId != 0 && EditorUtility.IsPersistent(prefabObj))
                    {
                        var orig = EditorUtility.InstanceIDToObject(prefabObj.StoredInstanceId) as JustLogicScriptableContainerBase;
                        if (orig && orig.EditorScriptData != null)
                        {
                            JLScriptableHelper.AssetsContainer = prefabObj;
                            prefabObj.EditorScriptData = Copier.Duplicate(orig.EditorScriptData, prefabObj.EditorRelativeReferences);
                            prefabObj.EditorRelativeReferences = Copier.CollectReferences(prefabObj.EditorScriptData);
                            var undoable = ((IUndoableBehavior)prefabObj);
                            undoable.UndoData.UndoPersistentIndex = undoable.UndoData.UndoIndex = 0;
                            prefabObj.StoredInstanceId = prefabObj.GetInstanceID();
                            EditorUtility.SetDirty(prefabObj);
                            JLScriptableHelper.AssetsContainer = null;
                            orig.EditorScriptData = prefabObj.EditorScriptData;
#if DEBUG
                            Debug.Log("Prefab created: " + prefabObj + " from " + orig);
#endif
                        }
                    }
                }
                catch (Exception e) { Debug.LogError(e); }
            }
            CheckList.Clear();
        }

        readonly static List<JustLogicScriptableContainerBase> CheckList = new List<JustLogicScriptableContainerBase>();

        private static void OnConstructor(JustLogicScriptableContainerBase obj)
        {
            CheckList.Add(obj);
        }

        private static void OnAwake(JustLogicScriptableContainerBase obj)
        {
            CheckList.Remove(obj);
        }
    }
}