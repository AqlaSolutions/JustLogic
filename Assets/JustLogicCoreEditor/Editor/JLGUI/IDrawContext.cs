using System;
using JustLogic.Core;
using UnityEngine;

namespace JustLogic.Editor.JLGUI
{
    public interface IDrawContext
    {
        UnityEditor.Editor Inspector { get; }
        void BeginChangedCheck();
        bool EndChangedCheck();
        void ScheduleRepaint();
        void BeginEnabled(bool enabled);
        void EndEnabled();
        bool IsHorizontal { get; }
        int OutlinedIndent { get; }
        void BeginVerticalArea(bool outline, params GUILayoutOption[] options);
        void EndArea();
        void BeginHorizontalArea(params GUILayoutOption[] options);
        void BeginLook(bool likeControlsMode);
        void EndLook();
        IEventDescription CurrentEditingEvent { get; }
        IScriptVariablesDescriber CurrentVariablesDescriber { get; }
    }

    public static class DrawContextExtensions
    {
        public static bool CheckChanged(this IDrawContext context, Action action)
        {
            bool r;
            context.BeginChangedCheck();
            try
            {
                action();
            }
            finally
            {
                r = context.EndChangedCheck();
            }
            return r;
        }

        public static bool SetCheckChanged(this IDrawContext context, ref bool currentChanged, Action action)
        {
            bool r;
            context.BeginChangedCheck();
            try
            {
                action();
            }
            finally
            {
                r = context.EndChangedCheck();
                if (r) currentChanged = true;
            }
            return r;
        }

        public static void BeginVerticalArea(this IDrawContext context, params GUILayoutOption[] options)
        {
            context.BeginVerticalArea(false, options);
        }

        public static int EndAreasHorizontal(this IDrawContext context)
        {
            int c = 0;
            while (context.IsHorizontal)
            {
                context.EndArea();
                c++;
            }
            return c;
        }

        public static void BeginHorizontalAreas(this IDrawContext context, int areas)
        {
            while (--areas >= 0)
                context.BeginHorizontalArea();
        }
    }
}