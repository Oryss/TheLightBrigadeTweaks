using MelonLoader;
using Microsoft.SqlServer.Server;
using System.Collections.Generic;
using static LB.ControllerTutorial;

namespace TheLightBrigadeTweaks
{
    public class Main : MelonMod
    {
        private static Main instance;

        public MelonPreferences_Category settings;
        public MelonPreferences_Entry<int> reduceFogBy;
        public MelonPreferences_Entry<bool> disableTrapsAfterClearingLevel;
        public MelonPreferences_Entry<bool> disableAllVibrations;
        public MelonPreferences_Entry<bool> disableInventoryVibrations;
        public MelonPreferences_Entry<bool> disableAmmoPouchVibrations;

        public static Main Instance { get => instance; set => instance = value; }

        public override void OnEarlyInitializeMelon()
        {
            Instance = this;
        }

        public override void OnInitializeMelon()
        {
            settings = MelonPreferences.CreateCategory("Settings");
            reduceFogBy = settings.CreateEntry("Reduce fog by percent", 20);
            disableTrapsAfterClearingLevel = settings.CreateEntry("Disable traps after clearing level", false);
            disableAllVibrations = settings.CreateEntry("Disable all vibrations", false);
            disableInventoryVibrations = settings.CreateEntry("Disable inventory vibrations", false);
            disableAmmoPouchVibrations = settings.CreateEntry("Disable ammo pouch vibrations", false);
        }

        public void SavePreferences()
        {
            settings.SaveToFile();
        }

        public static void Log(string str)
        {
            Instance.LoggerInstance.Msg(str);
        }
    }
}
