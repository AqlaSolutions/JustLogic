#if JUSTLOGIC_FREE
using System;
using System.Globalization;
using UnityEditor;
using UnityEngine;

namespace JustLogic
{
    [InitializeOnLoad]
    public class FreeVersion
    {
        private const string SettingTrialEnded = "JustLogicTrialEnded";
        private const string SettingFirstStart = "JustLogicFreeFirstStart";
        private const string SettingReminder = "JustLogicFreeReminder";

        static readonly bool _expired;
        internal static bool IsExpired { get { return _expired; } }

        static readonly int _daysToExpire = 30;
        internal static int DaysToExpire { get { return _daysToExpire; } }

        static FreeVersion()
        {
            var dateTime = DateTime.UtcNow;
            try
            {
                if (EditorPrefs.HasKey(SettingFirstStart))
                {
                    long dateBinary = long.Parse(EditorPrefs.GetString(SettingFirstStart), CultureInfo.InvariantCulture);
                    int diffDays = (int)dateTime.Subtract(DateTime.FromBinary(dateBinary)).TotalDays;
                    if (diffDays < 0)
                        EditorPrefs.SetString(SettingFirstStart, dateTime.ToBinary().ToString(CultureInfo.InvariantCulture));
                    else if (diffDays >= _daysToExpire)
                    {
                        EditorPrefs.SetBool(SettingTrialEnded, true);
                        _daysToExpire = 0;
                    }
                    else _daysToExpire -= diffDays;
                }
                else EditorPrefs.SetString(SettingFirstStart, dateTime.ToBinary().ToString(CultureInfo.InvariantCulture));
            }
            catch { EditorPrefs.SetBool(SettingTrialEnded, true); }

            _expired = EditorPrefs.GetBool(SettingTrialEnded, false);
            try
            {
                long reminderBinary = long.Parse(EditorPrefs.GetString(SettingReminder), CultureInfo.InvariantCulture);
                if (Math.Abs(dateTime.Subtract(DateTime.FromBinary(reminderBinary)).TotalDays) < 1.0) return;
            }
            catch { }
            EditorPrefs.SetString(SettingReminder, dateTime.ToBinary().ToString(CultureInfo.InvariantCulture));
            if (EditorUtility.DisplayDialog("JustLogic",
                IsExpired
                ? "Your free trial version of JustLogic is expired. Do you want to buy the full version now?"
                : "You are using the free trial version of JustLogic. It is provided for demonstration purposes only (no commerical use) for 30 days and with limited functionality.  Days left: " + DaysToExpire + ". Do you want to buy the full version now?", "Yes", "No"))
            {
                Application.OpenURL("http://aqla.net/en/unity-3d-extensions/just-logic/order.html");
            }
        }
    }
}
#endif
