using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;
using JustLogic.Core;
using UnityEditor;
using UnityEngine;
using System.Linq;

namespace JustLogic.Editor
{
    public class UnitsUsageStats
    {
        readonly List<TypeInfo> _recentUsedUnits = new List<TypeInfo>();
        readonly Dictionary<TypeInfo, UnitSelectedStatElement> _unitUsageStats = new Dictionary<TypeInfo, UnitSelectedStatElement>();
        readonly List<UnitSelectedStatElement> _mostUsedUnitsList = new List<UnitSelectedStatElement>();

        static readonly TypeInfo[] EmptyList = new TypeInfo[0];
        public IList<TypeInfo> MostUsedUnits
        {
            get
            {
                if (_mostUsedUnitsList.Count < 20)
                    return EmptyList;
                return _mostUsedUnitsList.Select(el => el.Unit).ToArray();
            }
        }

        public IList<TypeInfo> RecentUsedUnits { get; private set; }

        class UnitSelectedStatElement : IComparable<UnitSelectedStatElement>
        {
            public int Counter { get; set; }
            public TypeInfo Unit { get; private set; }

            public UnitSelectedStatElement(TypeInfo unit)
            {
                Unit = unit;
            }

            public int CompareTo(UnitSelectedStatElement other)
            {
                if (other == null)
                    return -1;
                return -Counter.CompareTo(other.Counter);
            }
        }

        public UnitsUsageStats()
        {
            RecentUsedUnits = new ReadOnlyCollection<TypeInfo>(_recentUsedUnits);

            _mostUsedUnitsList.Clear();
            _unitUsageStats.Clear();
            try
            {
                foreach (var els in EditorPrefs.GetString(MostUsedUnitsSettingName, string.Empty).Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    string[] elsSplitted = els.Split(new[] { "=" }, 2, StringSplitOptions.RemoveEmptyEntries);
                    string typeName = elsSplitted[0];
                    var t = Library.FindType(typeName);
                    if (t != null)
                    {
                        int count = int.Parse(elsSplitted[1], CultureInfo.InvariantCulture);
                        var statEl = new UnitSelectedStatElement(t) { Counter = count };
                        _mostUsedUnitsList.Add(statEl);
                        _unitUsageStats.Add(t, statEl);
                    }
                }
                _mostUsedUnitsList.Sort();
            }
            catch { EditorPrefs.SetString(MostUsedUnitsSettingName, string.Empty); }


            _recentUsedUnits.Clear();
            try
            {
                foreach (var typeName1 in EditorPrefs.GetString(RecentUsedUnitsSettingName, string.Empty).Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    var t1 = Library.FindType(typeName1);
                    if (t1 != null)
                        _recentUsedUnits.Add(t1);
                }
            }
            catch { EditorPrefs.SetString(RecentUsedUnitsSettingName, string.Empty); }
        }

        public void HandleUsage(TypeInfo t)
        {
            _recentUsedUnits.Remove(t);
            _recentUsedUnits.Insert(0, t);
            if (_recentUsedUnits.Count > 100)
                _recentUsedUnits.RemoveAt(_recentUsedUnits.Count - 1);
            SaveRecentUsedUnits();

            UnitSelectedStatElement counter;
            if (_unitUsageStats.TryGetValue(t, out counter))
                counter.Counter++;
            else
            {
                _unitUsageStats.Add(t, counter = new UnitSelectedStatElement(t) { Counter = 1 });
                _mostUsedUnitsList.Add(counter);
            }
            SaveMostUsedUnits();
            _mostUsedUnitsList.Sort();
        }


        private const string MostUsedUnitsSettingName = "JustLogic_MostUsedBlocks";
        private const string RecentUsedUnitsSettingName = "JustLogic_RecentUsedBlocks";

        void SaveMostUsedUnits()
        {
            var sb = new StringBuilder();
            foreach (KeyValuePair<TypeInfo, UnitSelectedStatElement> element in _unitUsageStats)
                sb.Append(element.Key.Type.FullName + "=" + element.Value.Counter.ToString(CultureInfo.InvariantCulture) + ";");
            try
            {
                EditorPrefs.SetString(MostUsedUnitsSettingName, sb.ToString());
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
        }

        void SaveRecentUsedUnits()
        {
            var sb = new StringBuilder();
            foreach (TypeInfo type in _recentUsedUnits)
                sb.Append(type.Type.FullName + ";");
            try
            {
                EditorPrefs.SetString(RecentUsedUnitsSettingName, sb.ToString());
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
        }
    }
}