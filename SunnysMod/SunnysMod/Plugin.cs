using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using YippeeMod.Patches;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace YippeeMod
{

    [BepInPlugin(modGUID, modName, modVersion)]
    public class YippeeModBase : BaseUnityPlugin
    {
        private const string modGUID = "sunnobunno.YippeeMod";
        private const string modName = "Yippee tbh mod";
        private const string modVersion = "1.2.4";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static YippeeModBase? Instance;

        internal ManualLogSource? mls;

        internal static AudioClip[]? newSFX;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);
            mls.LogInfo($"{modGUID} is loading.");

            string dllPath = Instance.Info.Location;
            string dllName = "YippeeMod.dll";
            string pluginPath = dllPath.TrimEnd(dllName.ToCharArray());
            string assetPath = pluginPath + "yippeesound";

            //mls.LogInfo(assetPath);

            AssetBundle val = AssetBundle.LoadFromFile(assetPath);
            if (val == null)
            {
                mls.LogError("Failed to load audio assets!");
                return;
            }
            newSFX = val.LoadAssetWithSubAssets<AudioClip>("assets/yippee-tbh.mp3");

            //harmony.PatchAll();
            harmony.PatchAll(typeof(HoarderBugPatch));

            mls.LogInfo($"{modGUID} is loaded. Yippee!!!");
        }
    }
}