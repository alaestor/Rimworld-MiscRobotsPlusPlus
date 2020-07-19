using AIRobot;
using RimWorld;
using RimWorld.Planet;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Verse;

namespace MiscRobotsPlusPlus.GUITweaks
{
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
        private List<WorkWindow_Table> Tables { get; set; } = new List<WorkWindow_Table>();
        private int currentTabIndex = 0;
        private HashSet<Pawn> initializedPawns = new HashSet<Pawn>();

        public MainTabWindow_Multiple()
        {
            var originalTab = Activator.CreateInstance(typeof(X2_MainTabWindow_Robots)) as MainTabWindow_PawnTable;
            var originalPawnsFunc = typeof(X2_MainTabWindow_Robots).GetProperty("Pawns", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            var pawnsFunc = new Func<IEnumerable<Pawn>>(() =>
            {
                var pawns = originalPawnsFunc.GetValue(originalTab) as IEnumerable<Pawn>;
                foreach (var p in pawns.Where(p => p is X2_AIRobot && !initializedPawns.Contains(p)))
                {
                    InitWorkSettings(p);
                    initializedPawns.Add(p);
                }
                return pawns;
            });

            
            AddTab(pawnsFunc, "MiscRobotsPlusPlus_Schedule".Translate(), originalTab);

            var workTag = DefDatabase<MainButtonDef>.GetNamed("Work");
            AddTab(pawnsFunc, "MiscRobotsPlusPlus_Work".Translate(), Activator.CreateInstance(workTag.tabWindowClass) as MainTabWindow_PawnTable);
        }

        public void AddTab(Func<IEnumerable<Pawn>> pawnsFunc, string text, MainTabWindow_PawnTable table)
        {
            Tables.Add(new WorkWindow_Table()
            {
                Pawns = pawnsFunc,
                Text = text,
                Table = table
            });
        }

        public override void DoWindowContents(Rect rect)
        {
            base.DoWindowContents(rect);
            var tabs = Tables
                .Where(t => t.Pawns().Any() || Tables[0] == t)
                .Select(t => t.Text)
                .ToArray();

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

        private static void InitWorkSettings(Pawn pawn)
        {
            // Reflect robot priorities to work priorities
            foreach (var def in DefDatabase<WorkTypeDef>.AllDefs)
            {
                var robotWorkType = (pawn as AIRobot.X2_AIRobot)?.def2?.robotWorkTypes
                    ?.FirstOrDefault(rwt => rwt.workTypeDef == def);
                pawn.workSettings.SetPriority(def, robotWorkType?.priority ?? 0);
            }
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
                return new Vector2(Tables.Max(t => t.Table.RequestedTabSize.x) + Margin, Tables.Max(t => t.Table.RequestedTabSize.y) + TopMargin + RobotsPlusPlusWidgets.TabHeight);
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
