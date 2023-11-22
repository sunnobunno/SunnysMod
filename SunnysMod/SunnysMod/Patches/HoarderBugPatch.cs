﻿using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using LC_API.BundleAPI;

namespace YippeeMod.Patches
{
    [HarmonyPatch(typeof(HoarderBugAI))]
    internal class HoarderBugPatch
    {
        [HarmonyPatch(nameof(HoarderBugAI.Start))]
        [HarmonyPostfix]
        public static void hoarderBugAudioPatch(ref AudioClip[] ___chitterSFX)
        {
            AudioClip newChitterSFX = BundleLoader.GetLoadedAsset<AudioClip>("assets/yippee-tbh.mp3");
            AudioClip[] array = new AudioClip[1];
            array[0] = newChitterSFX;
            ___chitterSFX = array;
        }
    }
}