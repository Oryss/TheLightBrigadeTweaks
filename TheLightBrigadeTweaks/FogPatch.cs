using System;
using System.Collections.Generic;
using HarmonyLib;
using LB;

namespace TheLightBrigadeTweaks
{

    [HarmonyPatch(typeof(EnvironmentRenderingSettingsData), "UploadShaderVariables")]
    public static class UploadShaderVariablesPatch
    {
        static void Prefix(ref OverrideSettings overrides, ref EnvironmentRenderingSettingsData __instance)
        {
            overrides.weight = Main.Instance.settings.GetEntry<float>("Weight").Value;

            foreach (KeyValuePair<string, string> kvp in Main.Instance.GetFogMapping())
            {
                SetFogField(ref overrides, kvp.Key, kvp.Value);
            }
        }

        public static void SetFogField(ref OverrideSettings overrides, string fieldName, string entryKey)
        {
            float? valueFromSettings = Main.Instance.fog.GetEntry<float?>(entryKey).Value;
            if (null == valueFromSettings)
            {
                return;
            }

            var finalValue = (float)valueFromSettings;

            switch (fieldName)
            {
                case "directionalFalloff":
                    overrides.Fog.directionalFalloff = finalValue;
                    break;
                case "directionalFogDistanceOffset":
                    overrides.Fog.directionalFogDistanceOffset = finalValue;
                    break;
                case "directionalIntensity":
                    overrides.Fog.directionalIntensity = finalValue;
                    break;
                case "envDirLightIntensity":
                    overrides.Fog.envDirLightIntensity = finalValue;
                    break;
                case "fogDistanceStart":
                    overrides.Fog.fogDistanceStart = finalValue;
                    break;
                case "fogDistanceEnd":
                    overrides.Fog.fogDistanceEnd = finalValue;
                    break;
                case "windContrast":
                    overrides.Fog.windContrast = finalValue;
                    break;
                case "windScale":
                    overrides.Fog.windScale = finalValue;
                    break;
                default:
                    throw new Exception("fieldName not supported");
            }
        }
    }


}
