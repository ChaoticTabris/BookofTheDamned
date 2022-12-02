using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using BookoftheDamned.Util;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Abilities.Components.Base;
using Kingmaker.UnitLogic.Abilities.Components.TargetCheckers;
using System;
using static UnityModManagerNet.UnityModManager.ModEntry;

namespace BookoftheDamned.Feats.UltimateMercyUses
{
    internal class UMMaterial
    {
        private static readonly string FeatName = "UMMaterial";
        private static readonly string DisplayName = "UMMaterial.Name";
        private static readonly string Description = "UMMaterial.Description";

        private static readonly ModLogger Logger = Logging.GetLogger(FeatName);

        internal static void Configure()
        {
            {
                try
                {
                    if (Settings.IsEnabled(Guids.GreaterMercyFeat))
                        ConfigureEnabled();
                    else
                        ConfigureDisabled();
                }
                catch (Exception e)
                {
                    Logger.LogException("GreaterMercy.Configure", e);
                }
            }
        }
        public static void ConfigureDisabled()
        {
            AbilityConfigurator.New(FeatName, Guids.UMMaterialAbility).Configure();
        }

        public static void ConfigureEnabled()
        {
            var ummaterialability =
                AbilityConfigurator.New(FeatName, Guids.UMMaterialAbility)
                .CopyFrom(AbilityRefs.RaiseDead,
                    typeof(SpellComponent),
                    typeof(AbilityEffectRunAction),
                    typeof(AbilityTargetIsDeadCompanion),
                    typeof(AbilitySpawnFx),
                    typeof(AbilityTargetHasFact))
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon("assets/icons/ultimatemercyability.png")
                .SetParent(GreaterMercy.UMAbilityName)
                .AddAbilityResourceLogic(isSpendResource: true, requiredResource: AbilityResourceRefs.LayOnHandsResource.ToString(), amount: 10)
                .Configure();
        }
    }
}