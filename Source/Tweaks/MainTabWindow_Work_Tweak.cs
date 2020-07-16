using MiscRobotsPlusPlus.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using Verse;

namespace MiscRobotsPlusPlus.Tweaks
{
    public class MainTabWindow_Work_Tweak : MainTabWindow_Multiple
    {
        public static Type MainTabWindowType { get; set; }

        protected override Type InnerTabType => MainTabWindowType;

        private IEnumerable<Pawn> Robots
        {
            get
            {
                foreach (var pawn in Find.CurrentMap.mapPawns.AllPawnsSpawned)
                {
                    if (pawn is AIRobot.X2_AIRobot)
                    {
                        WorkSettings.InitWorkSettings(pawn);
                        yield return pawn;
                    }
                }
            }
        }

        public MainTabWindow_Work_Tweak()
        {
            AddTab(new WorkWindow_Tab
            {
                Text = "Robots",
                Pawns = new Func<IEnumerable<Pawn>>(() => Robots)
            });
            AddTab(new WorkWindow_Tab
            {
                Text = "More bots",
                Pawns = new Func<IEnumerable<Pawn>>(() => Robots.Where(r => r.ToString().Contains("Haul")))
            });
        }
    }
}
