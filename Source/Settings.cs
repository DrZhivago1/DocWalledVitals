using System;
using UnityEngine;
using Verse;

namespace DocWalledVitals
{
    public class Settings : ModSettings
    {
        public static bool addToAllBeds = false;

        public override void ExposeData()
        {
            Scribe_Values.Look(ref addToAllBeds, "AddToAllBeds", false, true);
        }

        public static void DoSettingsWindowContents(Rect rect)
        {
            Listing_Standard l = new Listing_Standard(GameFont.Small) {
                ColumnWidth = rect.width
            };

            l.Begin(rect);

            l.CheckboxLabeled(ResourceBank.Strings.AddToAllBeds, ref addToAllBeds, ResourceBank.Strings.AddToAllBedsTooltip);

            l.End();
        }
    }
}