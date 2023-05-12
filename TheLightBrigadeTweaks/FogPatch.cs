using HarmonyLib;
using LB;

namespace TheLightBrigadeTweaks
{

    [HarmonyPatch(typeof(FogSettings), "Blend")]
    public static class FogSettingsPatch
    {
        static void Postfix(ref FogSettings __result)
        {
            int reduceFogBy = Main.Instance.settings.GetEntry<int>("Reduce fog by percent").Value;
            var multiplier = (float) ((float)reduceFogBy / 100);

            if (multiplier > 0.2)
            {
                __result.fogDistanceStart = 1f;
            }
            __result.fogDistanceStart += (__result.fogDistanceStart * multiplier);
            __result.fogDistanceEnd += (__result.fogDistanceEnd * multiplier);
            __result.directionalFalloff += (__result.directionalFalloff * multiplier);
        }
    }
}
