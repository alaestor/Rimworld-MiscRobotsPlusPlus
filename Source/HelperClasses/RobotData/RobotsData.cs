using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Rendering;
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

       
        public RobotsData(string[] robotsData, StatDef[] statsData, float[,] defa, bool[,] prec = null) 
        {
            this.defThing = robotsData;
            this.statsData = statsData;
            settingsValue = new float[defThing.Length, statsData.Length];
            settingsValue = defa;
            buffers = new string[defThing.Length, statsData.Length];
            
            //Set Default Values
            defaultValues = settingsValue;
            isPrecent = prec;
        }
        public static void DrawingSettings(Listing_Standard listing, RobotsData data, float min = 0.1f, float max = 100f)
        {
            for (int i = 0; i < data.defThing.Length; i++)
            {
                listing.Label(data.defThing[i].Translate());
                for (int x = 0; x < data.statsData.Length; x++)
                {
                    if (data.isPrecent != null)
                    {
                        if (data.isPrecent[i, x])
                        {
                            listing.Label((data.defThing[i] + "_" + data.statsData[x].defName).Translate(data.settingsValue[i, x] * 100f));
                            data.settingsValue[i, x] = listing.Slider(data.settingsValue[i, x], min, max);
                        }
                        else
                        {
                            listing.Label((data.defThing[i] + "_" + data.statsData[x].defName).Translate(data.settingsValue[i, x]));
                            listing.TextFieldNumeric(ref data.settingsValue[i, x], ref data.buffers[i, x]);
                        }
                    }
                    else
                    {
                        listing.TextFieldNumeric(ref data.settingsValue[i, x], ref data.buffers[i, x]);

                    }
                }
                listing.GapLine();
            }
        }  
    }
}

