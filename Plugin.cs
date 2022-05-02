using System;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using Configuration;
using HarmonyLib;
// Code By Asventi

namespace FreePrices
{
    [BepInPlugin("me.asventi.plugins.freeprices", "FreePrices", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        //ConfigFile
        private ConfigEntry<string> _configPrices;
        //Logging
        private readonly ManualLogSource mainLog = new ManualLogSource("MainLog");

        private void Awake()
        {
            //ConfigFile
            _configPrices = Config.Bind("General", "wip", "wip");
            //Logging
            BepInEx.Logging.Logger.Sources.Add(mainLog);
            
            
            mainLog.LogInfo($"Plugin FreePrices loaded !");
        }

        private void Start()
        {
            //Apply Patch
            Harmony.CreateAndPatchAll(typeof(Plugin));
        }

        [HarmonyPatch(typeof(PricesConfiguration), "GetPrice")]
        [HarmonyPrefix]
        static bool PatchPrice(ref float __result)
        {
            __result = 0f;
            return false;
        }
    }
}