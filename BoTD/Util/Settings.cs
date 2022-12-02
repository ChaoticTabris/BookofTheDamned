using BlueprintCore.Utils;
using Kingmaker.Localization;
using ModMenu.Settings;
using static UnityModManagerNet.UnityModManager.ModEntry;
using Menu = ModMenu.ModMenu;

namespace BookoftheDamned.Util
{
    internal static class Settings
    {
        private static readonly string RootKey = "botd.settings";
        private static readonly string RootStringKey = "BOTD.Settings";

        private static readonly ModLogger Logger = Logging.GetLogger(nameof(Settings));

        internal static bool IsEnabled(string key)
        {
            return Menu.GetSettingValue<bool>(GetKey(key));
        }

        internal static void Init()
        {
            Logger.Log("Initializing settings.");
            var settings =
                SettingsBuilder.New(RootKey, GetString("Title"))
                /*.AddImage(
                    ResourcesLibrary.TryGetResource<Sprite>)("assets/illustrations/botdlogo.png", height: 200, imageScale: 0.75f)*/
                .AddDefaultButton(OnDefaultsApplied);

            settings.AddSubHeader(GetString("Archetypes.Title"));
            foreach (var (guid, name) in Guids.Archetypes)
            {
                settings.AddToggle(
                    Toggle.New(GetKey(guid), defaultValue: true, GetString(name, usePrefix: false))
                        .WithLongDescription(GetString("EnableFeature")));
            }

                settings.AddSubHeader(GetString("Backgrounds.Title"));
            foreach (var (guid, name) in Guids.Backgrounds)
            {
                settings.AddToggle(
                    Toggle.New(GetKey(guid), defaultValue: true, GetString(name, usePrefix: false))
                        .WithLongDescription(GetString("EnableFeature")));
            }

            settings.AddSubHeader(GetString("Feats.Title"));
            foreach (var (guid, name) in Guids.Feats)
            {
                settings.AddToggle(
                    Toggle.New(GetKey(guid), defaultValue: true, GetString(name, usePrefix: false))
                        .WithLongDescription(GetString("EnableFeature")));
            }

            Menu.AddSettings(settings);
        }

        private static void OnDefaultsApplied()
        {
            Logger.Log($"Default settings restored.");
        }

        private static LocalizedString GetString(string key, bool usePrefix = true)
        {
            var fullKey = usePrefix ? $"{RootStringKey}.{key}" : key;
            return LocalizationTool.GetString(fullKey);
        }

        private static string GetKey(string partialKey)
        {
            return $"{RootKey}.{partialKey}";
        }
    }
}
