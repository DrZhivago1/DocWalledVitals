using System;
using System.Linq;
using Verse;

namespace DocWalledVitals
{
    public class PlaceWorker_OnWall : PlaceWorker
    {
        public override AcceptanceReport AllowsPlacing(BuildableDef checkingDef, IntVec3 loc, Rot4 rot, Map map, Thing thingToIgnore = null)
        {
            var def = loc.GetEdifice(map)?.def;
            if (def != null && def.IsSmoothed) {
                return AcceptanceReport.WasAccepted;
            }

            var linkFlags = def?.graphicData?.linkFlags;
            if (linkFlags != null && (linkFlags & LinkFlags.Wall) != 0) {
                return AcceptanceReport.WasAccepted;
            }

            return ResourceBank.Strings.PlacementMustBeOnWall;
        }
    }
}
