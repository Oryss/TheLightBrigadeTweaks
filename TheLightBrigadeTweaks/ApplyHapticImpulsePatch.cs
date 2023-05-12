using HarmonyLib;
using LB;
using System.Reflection;
using System;

namespace TheLightBrigadeTweaks
{
    [HarmonyPatch(typeof(XRControllerHaptics), "ApplyHapticImpulse")]
    public class ApplyHapticImpulsePatch
    {
        static bool Prefix(XRControllerHaptics.InputHapticLayerType layer, float value)
        {
            return !Main.Instance.settings.GetEntry<bool>("Disable all vibrations").Value;
        }
    }
}
