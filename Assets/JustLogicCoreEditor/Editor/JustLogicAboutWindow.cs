using JustLogic;
using JustLogic.Editor;
using UnityEditor;
using UnityEngine;

public class JustLogicAboutWindow : EditorWindow
{
    [MenuItem("CONTEXT/JustLogicBehaviorBase/About JustLogic")]
    public static void Open()
    {
        var w = GetWindow<JustLogicAboutWindow>();
        if (!w) w = CreateInstance<JustLogicAboutWindow>();
        w.ShowUtility();
        w.Focus();
    }

    protected void OnEnable()
    {
        var r = this.position;
        r.width = 285;
#if JUSTLOGIC_FREE
        r.height = 175;
#else
        r.height = 100;
#endif
        this.position = r;
        this.maxSize = new Vector2(r.width, r.height);
        this.minSize = this.maxSize;
        title = "About JustLogic";

    }

    GUIStyle _centeredLabel;

    protected void OnGUI()
    {
        if (_centeredLabel == null)
            _centeredLabel = new GUIStyle(StylesCache.label) { alignment = TextAnchor.MiddleCenter };

        GUILayout.Label("Just Logic\nVisual Programming Extension", _centeredLabel);
#if !JUSTLOGIC_FREE
        GUILayout.Label("Thanks for your purchase!", _centeredLabel);
#else
        GUILayout.Label("You are using the free trial version of JustLogic. \nIt is provided for demonstration purposes only \n(no commerical use) for 30 days and with \nlimited functionality. ");

        var c = GUI.color;
        GUI.color = Color.red;
        GUILayout.Label(FreeVersion.IsExpired ? "License expired" : (FreeVersion.DaysToExpire + " days left"));
        if (GUILayout.Button("Buy the full version now"))
            Application.OpenURL("http://aqla.net/en/unity-3d-extensions/just-logic/order.html");
        GUI.color = c;
#endif

        GUILayout.Label("Author Vlad Taranov", _centeredLabel);
        GUILayout.Label("aqla.dev@gmail.com", _centeredLabel);
        if (GUILayout.Button("http://www.aqla.net")) Application.OpenURL("http://aqla.net/en/unity-3d-extensions/just-logic/features.html");
    }
}
