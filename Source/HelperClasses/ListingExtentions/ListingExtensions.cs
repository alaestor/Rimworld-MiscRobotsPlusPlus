using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Verse;

namespace MiscRobotsPlusPlus
{
    public static class ListingExtensions 
    {
        public static void DropDownSettings(this Listing_Standard listing, string name, string explanation, Enum pages, float width)
        {
            float curHeight = listing.CurHeight;
            Rect rect = listing.GetRect(Text.LineHeight + listing.verticalSpacing);
            Text.Font = GameFont.Small;
            GUI.color = Color.white;
            TextAnchor anchor = Text.Anchor;
            Text.Anchor = TextAnchor.MiddleLeft;
            Widgets.Label(rect, name);
            Text.Anchor = TextAnchor.MiddleRight; ;
            if (Widgets.ButtonText(new Rect(width - 150f, 9, 150, 29), pages.ToString().Replace("_", " ")))
            {
                List<FloatMenuOption> floatMenus = new List<FloatMenuOption>();
                foreach (var item in Enum.GetValues(typeof(SettingsPages)).Cast<SettingsPages>().ToList())
                {
                    floatMenus.Add(new FloatMenuOption(item.ToString().Replace("_", " "), delegate
                    {
                        MiscPlusPlusSettings.currentPage = item;
                    }));
                }
                Find.WindowStack.Add(new FloatMenu(floatMenus));
                
            }
            Text.Anchor = anchor;
            Text.Font = GameFont.Tiny;
            listing.ColumnWidth -= 34f;
            GUI.color = Color.gray;
            listing.Label(explanation);
            listing.ColumnWidth += 34f;
            Text.Font = GameFont.Small;
            rect = listing.GetRect(0f);
            rect.height = listing.CurHeight - curHeight;
            rect.y -= rect.height;
            GUI.color = Color.white;
            listing.Gap(6f);
        }
    }
}

