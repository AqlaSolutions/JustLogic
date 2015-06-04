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
using System.Diagnostics;
using JustLogic;
using JustLogic.Core;
using JustLogic.Editor;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;

public abstract class JLInspectorBase : Editor
{
    [NonSerialized]
    bool? _isTargetUndoableCache;
    public bool IsTargetUndoable { get { return (_isTargetUndoableCache.HasValue ? _isTargetUndoableCache : (_isTargetUndoableCache = target is IUndoableBehavior)).Value; } }
    public JustLogicScriptableContainerBase UndoableScript { get { return target as JustLogicScriptableContainerBase; } }
    public IUndoableBehavior Undoable { get { return target as IUndoableBehavior; } }

    protected virtual void OnEnable()
    {
        if (UndoableScript)
        {
            UndoableScript.EditorOnReseting += OnUndoableScriptReseting;
            UndoableScript.EditorOnAfterDuplicated += script_OnAfterDuplicated;
        }
        if (IsTargetUndoable)
            EditorApplication.update += ServiceUndoable;
    }

    #region Script

    private void script_OnAfterDuplicated()
    {
        if (this) Repaint();
    }

    protected virtual void OnUndoableScriptReseting()
    {
        if (!this) return;
        _snapshotScheduled = true;
        _snapshotScheduledTimer = Stopwatch.StartNew();
        UndoableScript.EditorRelativeReferences = null;
        EditorUtility.SetDirty(target);
        Repaint();
    }

    #endregion

    private void ServiceUndoable()
    {
        var undo = Undoable.UndoData;
        if ((undo.UndoIndex != undo.UndoPersistentIndex) || (undo.CurrentSnapshot == null))
            Repaint();
        RegisterUndoSnapshotIfScheduled();
    }


    bool _snapshotScheduled;
    Stopwatch _snapshotScheduledTimer;

    protected void RegisterUndoSnapshotIfScheduled(bool ignoreTimer = false)
    {
        if (_snapshotScheduled && (ignoreTimer || (_snapshotScheduledTimer.ElapsedMilliseconds > 100)))
        {
            _snapshotScheduled = false;

            RegisterUndoSnapshot();
        }
    }

    private void RegisterUndoSnapshot()
    {
        var undo = Undoable.UndoData;
        if (undo.CurrentSnapshot == null) return;

        // remove redos
        while (undo.Snapshots.Count - 1 >= undo.UndoIndex)
            undo.Snapshots.RemoveAt(undo.UndoIndex);

        undo.Snapshots.Add(undo.CurrentSnapshot);

        Undo.RegisterUndo(target, "JL Editor");

        undo.UndoIndex = ++undo.UndoPersistentIndex;
#if DEBUG
        Debug.Log("register snapshot, " + undo.CurrentSnapshot + ", i " + undo.UndoIndex);
#endif

        undo.CurrentSnapshot = null;

        //Debug.Log("--snapshot");
        Repaint();
    }

    protected virtual void OnDisable()
    {
        if (UndoableScript) UndoableScript.EditorOnReseting -= OnUndoableScriptReseting;
        if (IsTargetUndoable)
        {
            // ReSharper disable once DelegateSubtraction
            EditorApplication.update -= ServiceUndoable;
            RegisterUndoSnapshotIfScheduled(true);
        }
    }

    protected void ServiceUndoRedo(Type undoDataType, object currentUndoData, Action<object> setUndoData)
    {
        var script = Undoable;
        if (script == null)
            throw new InvalidOperationException(typeof(IUndoableBehavior).Name + " target interface is required");
        UndoDataBase undo = script.UndoData;
        if (undo.UndoIndex != undo.UndoPersistentIndex)
        {
            _snapshotScheduled = false;

            if ((undo.UndoIndex >= 0) && (undo.UndoIndex < undo.Snapshots.Count))
            {
                // if is undo and it is previous
                if ((undo.UndoIndex == undo.UndoPersistentIndex - 1) && (undo.UndoIndex == undo.Snapshots.Count - 1))
                    undo.Snapshots.Add(undo.CurrentSnapshot); // register redo
                undo.CurrentSnapshot = undo.Snapshots[undo.UndoIndex];
                // it's redo and it is last
                if ((undo.UndoIndex == undo.UndoPersistentIndex + 1) && (undo.UndoIndex == undo.Snapshots.Count - 1))
                    undo.Snapshots.RemoveAt(undo.Snapshots.Count - 1);
                setUndoData(currentUndoData = Copier.RestoreSnapshot((Copier.CopiedData)undo.CurrentSnapshot));
                undo.UndoPersistentIndex = undo.UndoIndex;
            }
            else
            {
                Debug.LogError("JLScript: Undo/Redo operation can not be performed");
                undo.UndoIndex = undo.UndoPersistentIndex = 0;
                undo.Snapshots.Clear();
                undo.CurrentSnapshot = null;
            }
            UpdateRelativeReferences();
            EditorUtility.SetDirty(target);
        }
        if (undo.CurrentSnapshot == null)
        {
            undo.CurrentSnapshot = Copier.CreateSnapshot(currentUndoData, undoDataType);
#if DEBUG
            Debug.Log("Created new current snapshot");
#endif
        }
    }

    [NonSerialized]
    bool _repainting;

    void CheckInitialized()
    {
        if (!this)
        {
            // ReSharper disable once DelegateSubtraction
            EditorApplication.update -= CheckInitialized;
        }
        else if (Library.Initialized)
        {
            Repaint();
            // ReSharper disable once DelegateSubtraction
            EditorApplication.update -= CheckInitialized;
        }
    }



    struct StoredStyleInfo
    {
        public readonly GUIStyle Style;
        public readonly RectOffset Margin;
        public readonly RectOffset Padding;

        public StoredStyleInfo(GUIStyle style)
        {
            Margin = new RectOffset(style.margin.left, style.margin.right, style.margin.top, style.margin.bottom);
            Padding = new RectOffset(style.padding.left, style.padding.right, style.padding.top, style.padding.bottom);
            Style = style;
        }
    }

    public sealed override void OnInspectorGUI()
    {
#if JUSTLOGIC_FREE
        if (FreeVersion.IsExpired)
        {
            GUILayout.Label("License expired");
            if (GUILayout.Button("Buy JustLogic"))
                Application.OpenURL("http://aqla.net/en/unity-3d-extensions/just-logic/order.html");
            return;
        }
        EditorGUILayout.HelpBox("You are using the trial version of JustLogic with limited functionlity.", MessageType.Warning);
#endif

        if (UndoableScript && UndoableScript.EditorRelativeReferences == null)
            UpdateRelativeReferences();
        if ((Event.current.type == EventType.ValidateCommand) && (Event.current.commandName == "UndoRedoPerformed"))
        {
            Repaint();
            return;
        }
        StylesCache.LookLikeInspector();

        if (!Library.Initialized || EditorApplication.isCompiling)
        {
            if (!EditorApplication.isCompiling)
                Library.BeginInitialize();
            // ReSharper disable once DelegateSubtraction
            EditorApplication.update -= CheckInitialized;
            EditorApplication.update += CheckInitialized;
            GUILayout.Label("Initializing, please wait...");
            return;
        }

        if (Event.current.type == EventType.repaint)
        {
            const string FOCUS_OUT_UID = "sfdf_focus_afkslfjlegdfgdf";
            GUI.SetNextControlName(FOCUS_OUT_UID);
            new GUIStyle().Draw(new Rect(-100, -100, 1, 1), new GUIContent(), FOCUS_OUT_UID.GetHashCode());
            if (GUIUtility.keyboardControl == 0)
                GUI.FocusControl(FOCUS_OUT_UID);

        }
        //Debug.Log("Painting, " + Event.current.type);
        bool needRepaint = false;

        bool changed = true;

        var styles = new List<StoredStyleInfo>();
        foreach (GUIStyle style in EditorGUIUtility.GetBuiltinSkin(EditorSkin.Inspector))
        {
            styles.Add(new StoredStyleInfo(style));
            //style.margin.top /= 10;
            //style.margin.bottom /= 10;
        }
        var originalSkin = GUI.skin;
        //GUI.skin = StylesCache.Skin;
        try
        {
            changed = Draw();
        }
        catch (ArgumentException e)
        {
            if (!e.Message.StartsWith("Getting control ")) throw;
            needRepaint = true;
        }
        finally
        {
            GUI.skin = originalSkin;
            foreach (var el in styles)
            {
                GUIStyle style = el.Style;
                style.margin = el.Margin;
                style.padding = el.Padding;
            }

            if (target)
            {
                if (changed)
                {
                    EditorUtility.SetDirty(target);
                    if (IsTargetUndoable)
                    {
                        _snapshotScheduledTimer = Stopwatch.StartNew();
                        _snapshotScheduled = true;
                    }
                    if (UndoableScript)
                        UpdateRelativeReferences();
                }

                if ((changed && !_repainting) || needRepaint)
                {
                    _repainting = true;
                    Repaint();
                    Repaint();
                    _repainting = false;
                }
            }
        }
    }

    private void UpdateRelativeReferences()
    {
        if (!UndoableScript) return;
        var data = UndoableScript.EditorScriptData;
        if ((data is UnityEngine.Object) && !((UnityEngine.Object)data))
            data = null;
        UndoableScript.EditorRelativeReferences = data != null ? Copier.CollectReferences(data) : null;
        EditorUtility.SetDirty(UndoableScript);
    }

    protected abstract bool Draw();
}
