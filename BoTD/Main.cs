
using BlueprintCore.Blueprints.Configurators.Root;
using BlueprintCore.Utils;
using BookoftheDamned.Backgrounds;
using BookoftheDamned.Feats;
using BookoftheDamned.Util;
using HarmonyLib;
using Kingmaker.PubSubSystem;
using System;
using UnityModManagerNet;
using static UnityModManagerNet.UnityModManager.ModEntry;

namespace BookoftheDamned
{
  public static class Main
  {
    public static bool Enabled;
    private static readonly ModLogger Logger = Logging.GetLogger(nameof(Main));

    public static bool Load(UnityModManager.ModEntry modEntry)
    {
      try
      {
        var harmony = new Harmony(modEntry.Info.Id);
        harmony.PatchAll();

        EventBus.Subscribe(new BlueprintCacheInitHandle());

        Logger.Log("Finished patching.");
      }
      catch (Exception e)
      {
        Logger.LogException("Failed to patch", e);
      }
      return true;
    }

        class BlueprintCacheInitHandle : IBlueprintCacheInitHandler
        {
            private static bool Initialized = false;
            private static bool InitializeDelayed = false;

            public void AfterBlueprintCachePatches()
            {
                try
                {
                    if (InitializeDelayed)
                    {
                        Logger.Log("Already initialized blueprints cache.");
                        return;
                    }
                    InitializeDelayed = true;

                    ConfigureFeatsDelayed();

                    RootConfigurator.ConfigureDelayedBlueprints();
                }
                catch (Exception e)
                {
                    Logger.LogException("Delayed blueprint configuration failed.", e);
                }
            }

            public void BeforeBlueprintCachePatches()
            {

            }

            public void BeforeBlueprintCacheInit()
            {

            }

            public void AfterBlueprintCacheInit()
            {
                try
                {
                    if (Initialized)
                    {
                        Logger.Log("Already initialized blueprints cache.");
                        return;
                    }
                    Initialized = true;

                    // Fist strings
                    LocalizationTool.LoadEmbeddedLocalizationPacks(
                        "BookoftheDamned.Strings.Backgrounds.json",
                        "BookoftheDamned.Strings.Feats.json",
                        "BookoftheDamned.Strings.Settings.json");

                    // Then settings
                    Settings.Init();

                    ConfigureBackgrounds();
                    ConfigureFeats();
                }
                catch (Exception e)
                {
                    Logger.LogException("Failed to initialize.", e);
                }
            }
            private static void ConfigureBackgrounds()
            {
                Logger.Log("Configuring backgrounds.");
                Anatomist.Configure();
            }
            private static void ConfigureFeats()
            {
                Logger.Log("configuring feats.");
                GreaterMercy.Configure();
            }
            private static void ConfigureFeatsDelayed()
            {
                Logger.Log($"Configuring feats delayed.");
            }
        }   
  }
}