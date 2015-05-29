using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(JustLogicScript))]
public class JustLogicScriptEditor : JustLogicScriptEditorBase
{
    [MenuItem("GameObject/Create Other/JL Script", priority = 2049)]
    public static void CreateGameObject()
    {
        Undo.RegisterSceneUndo("New JL Script");
        var go = new GameObject("JL Script");
        go.AddComponent<JustLogicScript>();
        go.AddComponent<JustLogicEventHandler>();
        if (Selection.activeTransform)
        {
            var t = go.transform;
            t.parent = Selection.activeTransform;
            t.localPosition = new Vector3();
            t.localRotation = Quaternion.identity;
            t.localScale = Vector3.one;
        }
        Selection.activeGameObject = go;
        EditorGUIUtility.PingObject(go);
    }
}
