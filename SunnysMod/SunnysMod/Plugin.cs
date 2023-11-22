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
using LC_API;

namespace YippeeMod
{

    [BepInPlugin(modGUID, modName, modVersion)]
    public class YippeeModBase : BaseUnityPlugin
    {
        private const string modGUID = "YippeeMod";
        private const string modName = "Yippee tbh mod";
        private const string modVersion = "1.2.0";

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
            mls.LogInfo("Yippee Mod is awake");

            //videoPath = ((BaseUnityPlugin)Plugin.instance).Config.Bind<string>("CustomTelevisionVideo", "CustomVideoPath", "FlipMods-CustomTelevisionVideo/television_video.mp4", "Absolute or local video path. Use forward slashes in your path. Local paths are local to the BepInEx/plugins folder, and should not begin with a slash.");

            //string path = AppDomain.CurrentDomain.BaseDirectory;
            //mls.LogInfo(path);

            AssetBundle val = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, "yippeesound"));
            if (val == null)
            {
                mls.LogError((object)"Failed to load audio assets!");
                return;
            }
            newSFX = val.LoadAllAssets<AudioClip>();

            //harmony.PatchAll();
            //harmony.PatchAll(typeof(HoarderBugPatch));

            mls.LogInfo("Yippee Mod is loaded. Yippee!!!");
        }
    }
}