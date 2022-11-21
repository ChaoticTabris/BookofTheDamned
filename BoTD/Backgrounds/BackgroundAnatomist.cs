using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BookoftheDamned.Util;
using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Stats;
using Microsoft.Build.Utilities;
using System;
using static UnityModManagerNet.UnityModManager.ModEntry;

namespace BookoftheDamned.Backgrounds
{
    public class Anatomist
    {
        internal const string BackgroundName = "Anatomist";

        internal const string BackgroundDisplayName = "Anatomist.Name";
        private const string BackgroundDescription = "Anatomist.Description";

        private static readonly ModLogger Logger = Logging.GetLogger(BackgroundName);
        internal static void Configure()
        {
            try
            {
                if (Settings.IsEnabled(Guids.BackgroundAnatomist))
                    ConfigureEnabled();
                else
                    ConfigureDisabled();
            }
            catch (Exception e)
            {
                Logger.LogException("BackgroundAnatomist.Configure", e);
            }
        }

        private static void ConfigureDisabled()
        {
            Logger.Log($"Configuring {BackgroundName} (disabled)");

            FeatureConfigurator.New(BackgroundName, Guids.BackgroundAnatomist)
                .SetDisplayName(BackgroundDisplayName)
                .SetDescription(BackgroundDescription)
                .Configure();
        }

        private static void ConfigureEnabled()
        {
            Logger.Log($"Configuring {BackgroundName}");
            FeatureConfigurator.New(BackgroundName, Guids.BackgroundAnatomist, FeatureGroup.BackgroundSelection, FeatureGroup.Trait)
                    .SetDisplayName(BackgroundDisplayName)
                    .SetDescription(BackgroundDescription)
                    .AddClassSkill(StatType.SkillLoreReligion)
                    .AddClassSkill(StatType.SkillLoreNature)
                    .AddBackgroundClassSkill(StatType.SkillLoreReligion)
                    .AddBackgroundClassSkill(StatType.SkillLoreNature)
                    .AddCriticalConfirmationBonus(value: 1)
                    .Configure(delayed: true);
        }
    }
}
