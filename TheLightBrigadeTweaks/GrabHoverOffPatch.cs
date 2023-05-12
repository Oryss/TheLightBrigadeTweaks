using HarmonyLib;
using LB;
using System.Reflection;
using System;

namespace TheLightBrigadeTweaks
{
    [HarmonyPatch(typeof(GrabPoint), "GrabHoverOff")]
    public class GrabPointPatch
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

            __instance.onGrabHoverOff.Invoke(controller);
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
