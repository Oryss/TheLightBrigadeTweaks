using HarmonyLib;
using LB;
using System.Reflection;
using System;

namespace TheLightBrigadeTweaks
{
    [HarmonyPatch(typeof(GrabPoint), "GrabHoverOn")]
    public class GrabHoverOnPatch
    {
        static bool Prefix(XRController controller, GrabPoint __instance)
        {
            bool disableInventoryVibrations = Main.Instance.settings.GetEntry<bool>("Disable inventory vibrations").Value;
            bool disableAmmoPouchVibrations = Main.Instance.settings.GetEntry<bool>("Disable ammo pouch vibrations").Value;
            if (!disableInventoryVibrations && !disableAmmoPouchVibrations)
            {
                return true;
            }

            if (!((__instance.type == GrabPoint.GrabPointType.Inventory && disableInventoryVibrations) || (__instance.type == GrabPoint.GrabPointType.AmmoPouch && disableAmmoPouchVibrations)))
            {
                return true;
            }

            __instance.onGrabHoverOn.Invoke(controller);
            if (__instance.sfxOnHoverRef.IsValid())
            {
                Services.audio.PlaySound(__instance.sfxOnHoverRef, __instance.transform.position, 1f, 0f, null, false, false, false, AudioMixerType.None, 0f, null);
            }

            if (controller != null)
            {
                if (__instance.hoverRenderer != null)
                {
                    __instance.hoverRenderer.enabled = true;
                }
            }

            return false;
        }
    }
}
