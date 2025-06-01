using HarmonyLib;
using PDYay;

public class CommandPDAToggle_Patches
{
  [HarmonyPatch(typeof(CommandPDAToggle), nameof(CommandPDAToggle.Execute))]
  [HarmonyPrefix]
  internal static bool Execute_Prefix(CommandPDAToggle __instance)
  {

    PDYayPlugin.Log.LogInfo("Running Execute():Prefix");

    if (!(CanvasManager.instance == null) && !CrewSim.bRaiseUI && CrewSim.objInstance != null && __instance.Down)
    {
      CrewSim.guiPDA.ToggleHome();
    }

    //Cancel the original method
    return false;
  }
}
