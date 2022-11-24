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
using BlueprintCore.Actions.Builder.BasicEx;
using Kingmaker.RuleSystem.Rules;
using System;
using Newtonsoft.Json;
using Kingmaker.Settings;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.Mechanics.Conditions;
using TinyJson;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.RuleSystem;
using BlueprintCore.Utils.Types;
using Kingmaker.UnitLogic.Mechanics.Actions;
using System.Net.NetworkInformation;
using Kingmaker.RuleSystem.Rules.Damage;

namespace BookoftheDamned.Feats.UltimateMercyUses
{
    internal class UMNegLvl
    {
        private static readonly string FeatName = "UMNegLvl";
        private static readonly string DisplayName = "UMNegLvl.Name";
        private static readonly string Description = "UMNegLvl.Description";

        private static readonly ModLogger Logger = Logging.GetLogger(FeatName);

        //private DifficultyPresetAsset Core;
        //private DifficultyPreset DeathDoor;

        public static void ConfigureDisabled()
        {
            AbilityConfigurator.New(FeatName, Guids.UMNegLvlAbility).Configure();
        }

        public static void Configure()
        {
            Logger.Log($"Configuring {FeatName}");
            var CheckDeathDoor = new DifficultyPreset() { DeathDoor = true };
            var CheckPreset = new DifficultyPresetAsset() {
                Preset = CheckDeathDoor};
            var umneglvlability =
                AbilityConfigurator.New(FeatName, Guids.UMNegLvlAbility)
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
