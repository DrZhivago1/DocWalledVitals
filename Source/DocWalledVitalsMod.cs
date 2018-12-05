using System.Collections.Generic;
using RimWorld;
using UnityEngine;
using Verse;

namespace DocWalledVitals
{
    public class DocWalledVitalsMod : Mod
    {
        public DocWalledVitalsMod(ModContentPack content) : base(content)
        {
            LongEventHandler.ExecuteWhenFinished(Inject);

            GetSettings<Settings>();
        }

        public override string SettingsCategory() => ResourceBank.Strings.DocWalledVitals;
        public override void DoSettingsWindowContents(Rect inRect) => Settings.DoSettingsWindowContents(inRect);

        // This runs after Defs are loaded
        static void Inject() {
            // It may exist if certain mod is loaded, don't error if missing.
            var WalledVitalsMonitorSpacer = DefDatabase<ThingDef>.GetNamed("WalledVitalsMonitorSpacer", false);

            foreach(var thing in DefDatabase<ThingDef>.AllDefs) {

                // Only beds here
                if (!thing.IsBed) {
                    continue;
                }

                if (Settings.addToAllBeds) {
                    // Not spot
                    if (!thing.useHitPoints) {
                        continue;
                    }

                    // add missing comp/linkableFacilities if necessary
                    var comp = thing.GetCompProperties<CompProperties_AffectedByFacilities>();
                    if (comp == null) {
                        comp = new CompProperties_AffectedByFacilities();
                        thing.comps.Add(comp);
                    }
                    if (comp.linkableFacilities == null) {
                        comp.linkableFacilities = new List<ThingDef>();
                    }

                    comp.linkableFacilities.Add(ResourceBank.ThingDefOf.WalledVitalsMonitor);

                    if (WalledVitalsMonitorSpacer != null)
                    {
                        comp.linkableFacilities.Add(WalledVitalsMonitorSpacer);
                    }
                } else {
                    // ... that can be affected by
                    var comp = thing.GetCompProperties<CompProperties_AffectedByFacilities>();
                    if (comp == null || comp.linkableFacilities == null) {
                        continue;
                    }

                    // ... vanilla vitals monitor
                    int index = comp.linkableFacilities.IndexOf(ResourceBank.ThingDefOf.VitalsMonitor);
                    if (index < 0) {
                        continue;
                    }

                    // ... will use our walled vitals
                    comp.linkableFacilities.Insert(index, ResourceBank.ThingDefOf.WalledVitalsMonitor);

                    // ... optionally adding the spacer type
                    if (WalledVitalsMonitorSpacer != null)
                    {
                        comp.linkableFacilities.Insert(index, WalledVitalsMonitorSpacer);
                    }
                }

            }
        }
    }
}
