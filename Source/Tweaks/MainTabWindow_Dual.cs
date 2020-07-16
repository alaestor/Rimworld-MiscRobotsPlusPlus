using MiscRobotsPlusPlus.Core;
using RimWorld;
using RimWorld.Planet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Verse;

namespace MiscRobotsPlusPlus.Tweaks
{
    public class WorkWindow_Tab
    {
        public Func<IEnumerable<Pawn>> Pawns;
        public string Text { get; set; }
    }

    public abstract class MainTabWindow_Multiple : MainTabWindow
    {
        class WorkWindow_Table
        {
            public MainTabWindow_PawnTable Table { get; set; }
            public Func<IEnumerable<Pawn>> Pawns;
            public string Text { get; set; }
            public bool Initialized { get; set; }
        }

        private const int TopMargin = 12;
        protected abstract Type InnerTabType { get; }
        private List<WorkWindow_Table> Tables { get; set; } = new List<WorkWindow_Table>();
        private int currentTabIndex = 0;

        public MainTabWindow_Multiple()
        {
            AddTab(new WorkWindow_Tab
            {
                Text = "Colonists",
                Pawns = new Func<IEnumerable<Pawn>>(() => Find.CurrentMap.mapPawns.FreeColonists)
            });
            /*colonistTab = Activator.CreateInstance(InnerTabType) as MainTabWindow_PawnTable;
            prisonerTab = Activator.CreateInstance(InnerTabType) as MainTabWindow_PawnTable;
            if (colonistTab == null || prisonerTab == null)
                throw new Exception("PrisonLabor exception: wrong MainTabWindow_PawnTable type");*/
        }

        public void AddTab(WorkWindow_Tab tab)
        {
            Tables.Add(new WorkWindow_Table()
            {
                Pawns = tab.Pawns,
                Text = tab.Text,
                Table = Activator.CreateInstance(InnerTabType) as MainTabWindow_PawnTable
            });
        }

        public override void DoWindowContents(Rect rect)
        {
            base.DoWindowContents(rect);
            var tabs = Tables
                .Where(t => t.Pawns().Any() || Tables[0] == t)
                .Select(t => t.Text)
                .ToArray();
            /*if (prisoners.Count() > 0)
                tabs = new string[] { "PrisonLabor_ColonistsOnlyShort".Translate(), "PrisonLabor_PrisonersOnlyShort".Translate() };
            else
                tabs = new string[] { "PrisonLabor_ColonistsOnlyShort".Translate() };*/

            Text.Font = GameFont.Small;
            RobotsPlusPlusWidgets.BeginTabbedView(rect, tabs, ref currentTabIndex);
            rect.height -= RobotsPlusPlusWidgets.HorizontalSpacing - TopMargin;
            GUI.BeginGroup(new Rect(0, TopMargin, rect.width, rect.height));
            Tables[currentTabIndex].Table.DoWindowContents(rect);
            GUI.EndGroup();
            RobotsPlusPlusWidgets.EndTabbedView();
        }

        private void InitializeTablesIfNeeded()
        {
            var tableField = typeof(MainTabWindow_PawnTable).GetField("table", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);

            foreach (var tab in Tables.Where(t => !t.Initialized))
            {
                tableField.SetValue(tab.Table, CreateTable(tab.Table, tab.Pawns));
                tab.Initialized = true;
            }
        }

        private PawnTable CreateTable(MainTabWindow_PawnTable pawnTable, Func<IEnumerable<Pawn>> pawnsFunc)
        {
            var tableDef = pawnTable.GetType().GetProperty("PawnTableDef", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(pawnTable, null) as PawnTableDef;
            var bottomSpace = (float)pawnTable.GetType().GetProperty("ExtraBottomSpace", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(pawnTable, null);
            var topSpace = (float)pawnTable.GetType().GetProperty("ExtraTopSpace", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(pawnTable, null);

            return new PawnTable(tableDef, pawnsFunc, UI.screenWidth - (int)(this.Margin * 2f), (int)((float)(UI.screenHeight - 35) - bottomSpace - topSpace - this.Margin * 2f));
        }

        public override void Notify_ResolutionChanged()
        {
            InitializeTablesIfNeeded();
            base.Notify_ResolutionChanged();
        }

        public override void PostOpen()
        {
            InitializeTablesIfNeeded();
            var setDirtyMethod = typeof(MainTabWindow_PawnTable).GetMethod("SetDirty", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            foreach (var tab in Tables)
            {
                setDirtyMethod.Invoke(tab.Table, new object[] { });
            }
            Find.World.renderer.wantedMode = WorldRenderMode.None;
        }

        public override Vector2 RequestedTabSize
        {
            get
            {
                return new Vector2(Tables.Max(t => t.Table.RequestedTabSize.x), Tables.Max(t => t.Table.RequestedTabSize.y) + TopMargin + RobotsPlusPlusWidgets.TabHeight);
            }
        }

        protected override float Margin
        {
            get
            {
                return 6f;
            }
        }
    }
}
