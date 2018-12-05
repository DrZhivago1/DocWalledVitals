using System;
using RimWorld;
using Verse;

namespace DocWalledVitals
{
    public static class ResourceBank
    {
        public static class Strings
        {
            const string PREFIX = "DocWalledVitals.";

            static string TL(string s) => (PREFIX + s).Translate();
            static string TL(string s, params object[] args) => (PREFIX + s).Translate(args);

            public static readonly string DocWalledVitals = "DocWalledVitals";
            public static readonly string AddToAllBeds = TL("AddToAllBeds");
            public static readonly string AddToAllBedsTooltip = TL("AddToAllBedsTooltip");

            public static readonly string PlacementMustBeOnWall = TL("PlacementMustBeOnWall");
        }

        [DefOf]
        public static class ThingDefOf {
            public static ThingDef VitalsMonitor;
            public static ThingDef WalledVitalsMonitor;
        }
    }
}
