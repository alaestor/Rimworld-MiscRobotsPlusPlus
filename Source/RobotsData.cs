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

        public static void SetBuffers(RobotsData data)
        {
            for (int i = 0; i < data.defThing.Length; i++)
            {
                for (int x = 0; x < data.statsData.Length; x++)
                {
                    data.buffers[i, x] = data.defaultValues[i, x].ToString();
                }
            }
        }

       



    }
}
