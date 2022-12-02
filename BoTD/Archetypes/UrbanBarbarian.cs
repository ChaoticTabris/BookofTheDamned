using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.BasicEx;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using BookoftheDamned.Util;
using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.UnitLogic.FactLogic;
using System;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.ActivatableAbilities.Restrictions;
using Kingmaker.Designers.Mechanics.Buffs;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using BookoftheDamned.MechanicsChanges;
using Kingmaker.UI.UnitSettings.Blueprints;
using static UnityModManagerNet.UnityModManager.ModEntry;
using static BookoftheDamned.MechanicsChanges.ExtraActivatableAbilityGroups;
using Kingmaker.UnitLogic.Mechanics.Conditions;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.ElementsSystem;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic.Mechanics;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using HarmonyLib;
using Kingmaker.Blueprints.JsonSystem;
using BlueprintCore.Conditions.Builder.ContextEx;
using Kingmaker.Blueprints.Classes.Prerequisites;
using System.Linq;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using Kingmaker.Utility;

namespace BookoftheDamned.Archetypes
{
    internal class UrbanBarbarian
    {
        private const string ArchetypeName = "UrbanBarbarian";

        internal const string ArchetypeDisplayName = "UrbanBarbarian.Name";
        private const string ArchetypeDescription = "UrbanBarbarian.Description";

        private const string Proficiencies = "UrbanBarbarian.Proficiencies";
        private const string ProficienciesDisplayName = "UrbanBarbarian.Proficiencies.Name";
        private const string ProficienciesDescription = "UrbanBarbarian.Proficiencies.Description";

        private const string CrowdControlName = "UrbanBarbarian.CrowdControl";
        private const string CrowdControlDisplayName = "UrbanBarbarian.CrowdControl.Name";
        private const string CrowdControlDescription = "UrbanBarbarian.CrowdControl.Description";
        private const string CrowdControlEffectBuff = "UrbanBarbarian.CrowdControl.EffectBuff";
        private const string CrowdControlArea = "UrbanBarbarian.CrowdControl.Area";
        private const string CrowdControlBuff = "UrbanBarbarian.CrowdControl.Buff";

        internal const string ControlledRageFeature = "UrbanBarbarian.ControlledRage";
        private const string ControlledRageAbility = "UrbanBarbarian.ControlledRage.Ability";
        private const string ControlledRageBuff = "UrbanBarbarian.ControlledRage.Buff";
        private const string ControlledRageDisplayName = "UrbanBarbarian.ControlledRage.Name";
        internal const string ControlledRageDescription = "UrbanBarbarian.ControlledRage.Description";

        private const string GreaterControlledRageFeature = "UrbanBarbarian.GreaterControlledRage";
        private const string GreaterControlledRageDisplayName = "UrbanBarbarian.GreaterControlledRage.Name";
        private const string GreaterControlledRageDescription = "UrbanBarbarian.GreaterControlledRage.Description";

        private const string MightyControlledRageFeature = "UrbanBarbarian.MightyControlledRage";
        private const string MightyControlledRageDisplayName = "UrbanBarbarian.MightyControlledRage.Name";
        private const string MightyControlledRageDescription = "UrbanBarbarian.MightyControlledRage.Description";

        private static readonly ModLogger Logger = Logging.GetLogger(ArchetypeName);

        private const string IconPrefix = "assets/icons/";
        private const string IconNameCR = IconPrefix + "controlledrage.png";
        private const string IconNameCRGreater = IconPrefix + "greatercontrolledrage.png";
        private const string IconNameCRMighty = IconPrefix + "mightycontrolledrage.png";
        private const string IconNameCrowdControl = IconPrefix + "crowdcontrol.png";

        internal static void Configure()
        {
            {
                try
                {
                    if (Settings.IsEnabled(Guids.UrbanBarbarianArchetype))
                        ConfigureEnabled();
                    else
                        ConfigureDisabled();
                }
                catch (Exception e)
                {
                    Logger.LogException("UrbanBarbarian.Configure", e);
                }
            }
        }
        private static void ConfigureDisabled()
        {
            Logger.Log($"Configuring {ArchetypeName} (disabled)");
            ArchetypeConfigurator.New(ArchetypeName, Guids.UrbanBarbarianArchetype)
                .SetLocalizedName(ArchetypeDisplayName)
                .SetLocalizedDescription(ArchetypeDescription)
                .Configure();

            BuffConfigurator.New(ControlledRageBuff, Guids.UrbanBarbarianControlledRageBuff).Configure();
            ActivatableAbilityConfigurator.New(ControlledRageAbility, Guids.UrbanBarbarianControlledRageAbility).Configure();

            FeatureConfigurator.New(Proficiencies, Guids.UrbanBarbarianProficiencies)
                .SetDisplayName(ProficienciesDisplayName)
                .SetDescription(ProficienciesDescription)
                .Configure();

            FeatureConfigurator.New(CrowdControlName, Guids.UrbanBarbarianCrowdControl)
                .SetDisplayName(CrowdControlDisplayName)
                .SetDescription(CrowdControlDescription)
                .Configure();
        }

        private static void ConfigureEnabled()
        {
            Logger.Log($"Configuring {ArchetypeName}");

            ArchetypeConfigurator.New(ArchetypeName, Guids.UrbanBarbarianArchetype, CharacterClassRefs.BarbarianClass)
                .SetLocalizedName(ArchetypeDisplayName)
                .SetLocalizedDescription(ArchetypeDescription)
                .AddToRemoveFeatures(1, FeatureRefs.BarbarianProficiencies.ToString(), FeatureRefs.FastMovement.ToString(), FeatureRefs.RageFeature.ToString())
                .AddToRemoveFeatures(11, FeatureRefs.GreaterRageFeature.ToString())
                .AddToRemoveFeatures(20, FeatureRefs.MightyRage.ToString())
                .AddToAddFeatures(1, CreateProficiencies(), CreateCrowdControl(), CreateControlledRage())
                .AddToAddFeatures(11, CreateGreaterControlledRage())
                .AddToAddFeatures(20, CreateMightyControlledRage())
                .SetReplaceStartingEquipment(true)
                .SetStartingItems(ItemArmorRefs.StuddedStandard.Reference.Get())
                .SetReplaceClassSkills(true)
                .SetClassSkills(StatType.SkillAthletics, StatType.SkillMobility, StatType.SkillKnowledgeWorld, StatType.SkillPerception, StatType.SkillPersuasion)
                .Configure();

            Logger.Log($"Configuring {ArchetypeName}'s main buff");

            var buff = BuffConfigurator.New(ControlledRageBuff, Guids.UrbanBarbarianControlledRageBuff)
                .CopyFrom(BuffRefs.StandartRageBuff,
                    typeof(BuffParticleEffectPlay),
                    typeof(AddFactContextActions),
                    typeof(ContextCalculateSharedValue),
                    typeof(ForbidSpellCasting),
                    typeof(SpellDescriptorComponent))
                .SetDisplayName(ControlledRageDisplayName)
                .SetDescription(ControlledRageDescription)
                .SetIcon(IconNameCR)
                .Configure();

            Logger.Log($"Configuring {ArchetypeName}'s main activatable ability");

            ActivatableAbilityConfigurator.New(ControlledRageAbility, Guids.UrbanBarbarianControlledRageAbility)
                .CopyFrom(ActivatableAbilityRefs.StandartRageActivateableAbility,
                    typeof(ActivatableAbilityResourceLogic),
                    typeof(RestrictionHasUnitCondition),
                    typeof(RestrictionHasFact),
                    typeof(ActionPanelLogic))
                .SetDisplayName(ControlledRageDisplayName)
                .SetDescription(ControlledRageDescription)
                .SetIcon(IconNameCR)
                .SetBuff(buff)
                .Configure();

            var crFeatRef = BlueprintTool.Get<SimpleBlueprint>(Guids.UrbanBarbarianControlledRageFeature);   //.ToReference<BlueprintFeatureReference>();
            var limitlessRage = BlueprintTool.Get<BlueprintFeature>("5cb58e6e406525342842a073fb70d068").GetComponent<PrerequisiteFeaturesFromList>();
            FeatureConfigurator.For(FeatureRefs.LimitlessRage)
                .EditComponent<PrerequisiteFeaturesFromList>(
                c =>
                {
                    c.m_Features = limitlessRage.m_Features.AppendToArray(crFeatRef.ToReference<BlueprintFeatureReference>());
                })
                .Configure();

            //var ccRankConfig = ContextRankConfigs.BuffRank(buff: Guids.CrowdControlEffectBuff.ToString(), type: AbilityRankType.Default, min: 0, max: 20).WithCustomProgression((1, 0), (100, 1)).m_StartLevel = 2;

            var ccEffectBuff = BuffConfigurator.New(CrowdControlEffectBuff, Guids.CrowdControlEffectBuff)
                .SetDisplayName(CrowdControlDisplayName)
                .SetDescription(CrowdControlDescription)
                .SetIcon(IconNameCrowdControl)
                .SetStacking(StackingType.Rank)
                .SetRanks(100)
                .AddContextStatBonus(stat: StatType.AC, value: ContextValues.Rank(), descriptor: ModifierDescriptor.Dodge)
                .AddContextStatBonus(stat: StatType.AdditionalAttackBonus, value: ContextValues.Rank(), descriptor: ModifierDescriptor.None)
                .AddContextRankConfig(ContextRankConfigs.BuffRank(buff: Guids.CrowdControlEffectBuff.ToString(), type: AbilityRankType.Default).WithCustomProgression((1, 0), (100, 1)))
                .Configure();

            var ccAreaEffect = AbilityAreaEffectConfigurator.New(CrowdControlArea, Guids.CrowdControlArea)
                .AddAbilityAreaEffectRunAction(
                unitEnter: ActionsBuilder.New()
                .ApplyBuffPermanent(ccEffectBuff, toCaster: true, asChild: true).Build(),
                unitExit: ActionsBuilder.New()
                .RemoveBuff(ccEffectBuff, removeRank: true, toCaster: true).Build())
                .SetTargetType(BlueprintAbilityAreaEffect.TargetType.Enemy)
                .SetShape(AreaEffectShape.Cylinder)
                .SetSize(5.Feet())
                .Configure();

            BuffConfigurator.New(CrowdControlBuff, Guids.CrowdControlBuff)
                .AddAreaEffect(ccAreaEffect)
                .SetFlags(BlueprintBuff.Flags.HiddenInUi)
                .Configure();
        }

        private static BlueprintFeature CreateProficiencies()
        {
            return FeatureConfigurator.New(Proficiencies, Guids.UrbanBarbarianProficiencies)
                .SetDisplayName(ProficienciesDisplayName)
                .SetDescription(ProficienciesDescription)
                .SetIsClassFeature(true)
                .AddFacts(new() {
                    FeatureRefs.SimpleWeaponProficiency.Reference.Get(),
                    FeatureRefs.MartialWeaponProficiency.Reference.Get(),
                    FeatureRefs.ShieldsProficiency.Reference.Get(),
                    FeatureRefs.LightArmorProficiency.Reference.Get()})
                .Configure();
        }
        private static BlueprintFeature CreateCrowdControl()
        {
            return FeatureConfigurator.New(CrowdControlName, Guids.UrbanBarbarianCrowdControl)
                .SetDisplayName(CrowdControlDisplayName)
                .SetDescription(CrowdControlDescription)
                .SetIcon(IconNameCrowdControl)
                .SetIsClassFeature(true)
                .AddBuffActions(ActionsBuilder.New().ApplyBuffPermanent(Guids.CrowdControlBuff).Build())
                .AddContextRankConfig(ContextRankConfigs.SumClassLevelWithArchetype(
                    classes: new string[] { CharacterClassRefs.BarbarianClass.ToString() },
                    archetypes: new string[] { ArchetypeName.ToString() },
                    type: AbilityRankType.StatBonus)
                    .WithDiv2Progression())
                .AddContextStatBonus(StatType.CheckIntimidate, ContextValues.Rank(), ModifierDescriptor.UntypedStackable)
                .Configure();
        }
        private static BlueprintFeature CreateControlledRage()
        {
            return FeatureConfigurator.New(ControlledRageFeature, Guids.UrbanBarbarianControlledRageFeature)
                .SetDisplayName(ControlledRageDisplayName)
                .SetDescription(ControlledRageDescription)
                .SetIcon(IconNameCR)
                .SetIsClassFeature(true)
                .AddIncreaseActivatableAbilityGroupSize(ExtraActivatableAbilityGroup.ControlledRageGroup.Group())
                .AddFacts(new() {
                    "4b1f3dd0-f619-4624-9a65-4941fc417a89",
                    Guids.UrbanBarbarianControlledRageAbility,
                    Guids.ControlledRageStr4Ability,
                    Guids.ControlledRageDex4Ability,
                    Guids.ControlledRageCon4Ability,
                    Guids.ControlledRageStr2Ability,
                    Guids.ControlledRageDex2Ability,
                    Guids.ControlledRageCon2Ability
                })
                .Configure();
        }
        private static BlueprintFeature CreateGreaterControlledRage()
        {
            return FeatureConfigurator.New(GreaterControlledRageFeature, Guids.UrbanBarbarianGreaterControlledRageFeature)
                .SetDisplayName(GreaterControlledRageDisplayName)
                .SetDescription(GreaterControlledRageDescription)
                .SetIcon(IconNameCRGreater)
                .SetIsClassFeature(true)
                .AddIncreaseActivatableAbilityGroupSize(ExtraActivatableAbilityGroup.ControlledRageGroup.Group())
                .AddFacts(new() {
                    Guids.ControlledRageStr6Ability,
                    Guids.ControlledRageDex6Ability,
                    Guids.ControlledRageCon6Ability
                })
                .Configure();
        }
        private static BlueprintFeature CreateMightyControlledRage()
        {
            return FeatureConfigurator.New(MightyControlledRageFeature, Guids.UrbanBarbarianMightyControlledRageFeature)
                .SetDisplayName(MightyControlledRageDisplayName)
                .SetDescription(MightyControlledRageDescription)
                .SetIcon(IconNameCRMighty)
                .SetIsClassFeature(true)
                .AddIncreaseActivatableAbilityGroupSize(ExtraActivatableAbilityGroup.ControlledRageGroup.Group())
                .AddFacts(new() {
                    Guids.ControlledRageStr8Ability,
                    Guids.ControlledRageDex8Ability,
                    Guids.ControlledRageCon8Ability
                })
                .Configure();
        }

        [HarmonyPatch(typeof(BlueprintsCache), "Init")]
        static class BlueprintsCache_Init_Patch
        {
            static bool Initialized;
            static void Postfix()
            {
                if (Initialized) return;
                Initialized = true;

                PatchDemonRage();
            }
            static void PatchDemonRage()
            {
                var demonRageBuff = BlueprintTool.Get<BlueprintBuff>("36ca5ecd8e755a34f8da6b42ad4c965f");

                AddControlledRage(demonRageBuff);
            }

            private static void AddControlledRage(BlueprintBuff demonRageBuff)
            {
                var crFeature = BlueprintTool.Get<BlueprintFeature>(Guids.UrbanBarbarianControlledRageFeature).ToReference<BlueprintUnitFactReference>();
                var crBuff = BlueprintTool.Get<BlueprintBuff>(Guids.UrbanBarbarianControlledRageBuff);
                var crBuffRef = BlueprintTool.Get<BlueprintBuff>(Guids.UrbanBarbarianControlledRageBuff).ToReference<BlueprintBuffReference>(); ;

                var hasControlledRageCondition = new Condition[] {
                            new ContextConditionHasFact
                            {
                                m_Fact = crFeature,
                                Not = false
                            }
                };

                var hasControlledRageConditionsChecker = new ConditionsChecker()
                {
                    Conditions = hasControlledRageCondition
                };

                var applyControlledRageBuff = new ContextActionApplyBuff()
                {
                    m_Buff = crBuffRef,
                    Permanent = true,
                    DurationValue = new ContextDurationValue(),
                    AsChild = true,
                    IsFromSpell = false,
                    IsNotDispelable = true,
                    ToCaster = false,
                    SameDuration = false,
                    UseDurationSeconds = false,
                    DurationSeconds = 0
                };

                var conditionalControlledRage = new Conditional()
                {
                    ConditionsChecker = hasControlledRageConditionsChecker,
                    IfTrue = new ActionList()
                    {
                        Actions = new GameAction[] { applyControlledRageBuff }
                    },
                    IfFalse = new ActionList()
                };

                demonRageBuff.EditComponent<AddFactContextActions>(c => { c.Activated.Actions = c.Activated.Actions.AppendToArray(conditionalControlledRage); });
            }
        }
    }
}