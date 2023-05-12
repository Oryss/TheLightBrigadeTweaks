using HarmonyLib;
using LB;
using System.Reflection;
using System;
using UnityEngine;

namespace TheLightBrigadeTweaks
{
    [HarmonyPatch(typeof(PlayerActor), "DoEnemiesClearBlend")]
    public static class DoEnemiesClearBlendPatch
    {
        static void Postfix(ref PlayerActor __instance)
        {
            if (!Main.Instance.settings.GetEntry<bool>("Disable traps after clearing level").Value)
            {
                return;
            }

            var traps = UnityEngine.Object.FindObjectsOfType<TrapDevice>();

            if (traps.Length > 0)
            {
                foreach (TrapDevice trap in traps)
                {
                    UnityEngine.Object.Destroy(trap);
                }
            }
        }
    }
}
