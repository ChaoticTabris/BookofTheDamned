using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using BookoftheDamned.Util;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.UnitLogic.Abilities.Components.Base;
using Kingmaker.UnitLogic.Abilities.Components.TargetCheckers;
using static UnityModManagerNet.UnityModManager.ModEntry;
using static Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility;
using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using Kingmaker.UnitLogic.Abilities.Components;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.MiscEx;
using Kingmaker.Settings.Difficulty;
using Kingmaker.RuleSystem;
using System;

namespace BookoftheDamned.Feats.UltimateMercyUses
{
    internal class UMNegLvl
    {
        private static readonly string FeatName = "UMNegLvl";
        private static readonly string DisplayName = "UMNegLvl.Name";
        private static readonly string Description = "UMNegLvl.Description";

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
            AbilityConfigurator.New(FeatName, Guids.UMNegLvlAbility).Configure();
        }

        public static void ConfigureEnabled()
        {
            Logger.Log($"Configuring {FeatName}");
            var CheckDeathDoor = new DifficultyPreset() { DeathDoor = true };
            var CheckPreset = new DifficultyPresetAsset() {
                Preset = CheckDeathDoor};
            var umneglvlability =
                AbilityConfigurator.New(FeatName, Guids.UMNegLvlAbility)
                .CopyFrom(AbilityRefs.RaiseDead,
                    typeof(SpellComponent),
                    typeof(AbilityTargetIsDeadCompanion),
                    typeof(AbilitySpawnFx),
                    typeof(AbilityTargetHasFact))
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon("assets/icons/ultimatemercyability.png")
                .SetParent(GreaterMercy.UMAbilityName)
                .AddAbilityResourceLogic(isSpendResource: true, requiredResource: AbilityResourceRefs.LayOnHandsResource.ToString(), amount: 10)
                .SetMaterialComponent(new MaterialComponentData())
                .AddAbilityEffectRunAction(ActionsBuilder.New()
                .ApplyBuffWithDurationSeconds(BuffRefs.TemporaryNegativeLevel.ToString(), durationSeconds: 86400, isNotDispelable: true, toCaster: true)
                .Conditional(ConditionsBuilder.New().DifficultyHigherThan(difficulty: CheckPreset, negate: false, reverse: false),
                ifTrue: ActionsBuilder.New().DealDamagePermanentNegativeLevels(value: new() { DiceType = DiceType.Zero, DiceCountValue = 0, BonusValue = 2})
                .Build())
                .Resurrect()
                .Build())
                .Configure();
        }
    }
}
