using System;
using System.Linq;
using Verse;

namespace DocWalledVitals
{
    public class PlaceWorker_OnWall : PlaceWorker
    {
        public override AcceptanceReport AllowsPlacing(BuildableDef checkingDef, IntVec3 loc, Rot4 rot, Map map, Thing thingToIgnore = null)
        {
            var linkFlags = loc.GetEdifice(map)?.def.graphicData?.linkFlags;
            if (linkFlags == null || (linkFlags & LinkFlags.Wall) == 0)
            {
                return ResourceBank.Strings.PlacementMustBeOnWall;
            }

            return AcceptanceReport.WasAccepted;
        }
    }
}
