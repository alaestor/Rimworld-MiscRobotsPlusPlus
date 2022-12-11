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
        public bool[,] isPrecent = null;
        public GuiType[,] gui;
        public RobotsData(string[] robotsData, StatDef[] statsData)
        {
            this.defThing = robotsData;
            this.statsData = statsData;
            settingsValue = new float[defThing.Length, statsData.Length];
            buffers = new string[defThing.Length, statsData.Length];
        }
        public RobotsData(string[] robotsData, StatDef[] statsData, bool[,] prec = null)
        {
            this.defThing = robotsData;
            this.statsData = statsData;
            settingsValue = new float[defThing.Length, statsData.Length];
            buffers = new string[defThing.Length, statsData.Length];
            if(prec != null)
            {
                prec = new bool[defThing.Length, statsData.Length];
            }
            isPrecent = prec;
        }
        public RobotsData(string[] robotsData, StatDef[] statsData, bool[,] prec = null, GuiType[,] g = null)
        {
            this.defThing = robotsData;
            this.statsData = statsData;
            settingsValue = new float[defThing.Length, statsData.Length];
            buffers = new string[defThing.Length, statsData.Length];
            isPrecent = prec;
            if (prec != null)
            {
                prec = new bool[defThing.Length, statsData.Length];
            }
            if (g != null)
            {
                g = new GuiType[defThing.Length, statsData.Length];
            }
            gui = g;
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
public enum GuiType
{
    Slider,
    SliderLabled,
    TextEntry,
    TextEntryLabled,
    TextEntryNumberic,
    TextEntryNumbericLabled,
    IntAdjuster,
    IntEntry,
    IntRange

}