using System;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace PDYay;

[BepInPlugin(LCMPluginInfo.PLUGIN_GUID, LCMPluginInfo.PLUGIN_NAME, LCMPluginInfo.PLUGIN_VERSION)]
public class PDYayPlugin : BaseUnityPlugin
{
  internal static ManualLogSource Log = null!;

  private void Awake()
  {
    Log = Logger;

    // Log our awake here so we can see it in LogOutput.txt file
    Log.LogInfo($"Plugin {LCMPluginInfo.PLUGIN_NAME} version {LCMPluginInfo.PLUGIN_VERSION} is loaded!");

    try
    {
      Harmony patcher = new(LCMPluginInfo.PLUGIN_GUID);
      patcher.PatchAll(typeof(CommandPDAToggle_Patches));
      Log.LogInfo("Applied PDYay! Patches");
    }
    catch (Exception ex)
    {
      Log.LogWarning($"Failed to apply PDYay! Patches:\n {ex}\n");
    }

  }

}
