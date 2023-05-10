using MelonLoader;
using System.Collections.Generic;

namespace TheLightBrigadeTweaks
{
    public class Main : MelonMod
    {
        private static Main instance;

        // General settings

        public MelonPreferences_Category settings;
        public MelonPreferences_Entry<float> weight;

        // Fog settings
        public MelonPreferences_Category fog;
        public MelonPreferences_Entry<float?> directionalFalloff;
        public MelonPreferences_Entry<float?> directionalFogDistanceOffset;
        public MelonPreferences_Entry<float?> directionalIntensity;
        public MelonPreferences_Entry<float?> distanceStart;
        public MelonPreferences_Entry<float?> distanceEnd;
        public MelonPreferences_Entry<float?> distanceFalloff;

        public MelonPreferences_Entry<float?> floorFogDistanceFromCamera;

        public MelonPreferences_Entry<float?> envDirLightIntensity;

        public MelonPreferences_Entry<float?> windContrast;
        public MelonPreferences_Entry<float?> windScale;

        public static Main Instance { get => instance; set => instance = value; }

        public override void OnEarlyInitializeMelon()
        {
            Instance = this;
        }

        public override void OnInitializeMelon()
        {
            settings = MelonPreferences.CreateCategory("Settings");
            weight = settings.CreateEntry("Weight", 0.5f);

            // Fog settings

            fog = MelonPreferences.CreateCategory("Fog Settings");

            directionalFalloff = fog.CreateEntry<float?>("Directional falloff", null); // 1.5f
            directionalFogDistanceOffset = fog.CreateEntry<float?>("Directional distance offset", null); // 0.0f
            directionalIntensity = fog.CreateEntry<float?>("Directional intensity", null); // 0.329f

            envDirLightIntensity = fog.CreateEntry<float?>("Environment directional light intensity", null); // 1.0f

            distanceStart = fog.CreateEntry<float?>("Distance start", null); // 0f
            distanceEnd = fog.CreateEntry<float?>("Distance end", null); // 22.4f
            distanceFalloff = fog.CreateEntry<float?>("Distance falloff", null); // 0.22f

            floorFogDistanceFromCamera = fog.CreateEntry<float?>("Floor fog distance from camera", null); // 0.0f

            windContrast = fog.CreateEntry<float?>("Wind contrast", null); // 0.0f
            windScale = fog.CreateEntry<float?>("Wind scale", null); // 0.43f
        }

        public void SavePreferences()
        {
            settings.SaveToFile();
        }

        public Dictionary<string, string> GetFogMapping()
        {
            return new Dictionary<string, string>() {
                { "directionalFalloff", "Directional falloff" },
                { "directionalFogDistanceOffset", "Directional distance offset" },
                { "directionalIntensity", "Directional intensity" },
                { "envDirLightIntensity", "Environment directional light intensity" },
                { "fogDistanceStart", "Distance start" },
                { "fogDistanceEnd", "Distance end" },
                { "windContrast", "Wind contrast" },
                { "windScale", "Wind scale" }
            };
        }

        public static void Log(string str)
        {
            Instance.LoggerInstance.Msg(str);
        }
    }
}
