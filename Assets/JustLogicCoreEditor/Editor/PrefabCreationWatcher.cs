/*
	
	This file is a part of JustLogic product which is distributed under 
	the BSD 3-clause "New" or "Revised" License
	
	Copyright (c) 2015. All rights reserved. 
	Authors: Vladyslav Taranov.
	
	Redistribution and use in source and binary forms, with or without
	modification, are permitted provided that the following conditions are met:
	
	* Redistributions of source code must retain the above copyright notice, this
	  list of conditions and the following disclaimer.
	
	* Redistributions in binary form must reproduce the above copyright notice,
	  this list of conditions and the following disclaimer in the documentation
	  and/or other materials provided with the distribution.
	
	* Neither the name of JustLogic nor the names of its
	  contributors may be used to endorse or promote products derived from
	  this software without specific prior written permission.
	
	THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
	AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
	IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
	DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE
	FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
	DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
	SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
	CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
	OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
	OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

 */
  
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