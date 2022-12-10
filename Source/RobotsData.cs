using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace MiscRobotsPlusPlus
{
    public class RobotsData
    {
        public string[] defThing;
        public StatDef[] statsData;
        public float[,] settingsValue;
        public string[,] buffers;
        public float[,] defaultValues;
        public RobotsData(string[] robotsData, StatDef[] statsData)
        {
            this.defThing = robotsData;
            this.statsData = statsData;
            settingsValue = new float[defThing.Length, statsData.Length];
            buffers = new string[defThing.Length, statsData.Length];
        }


    }
}
