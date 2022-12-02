using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BookoftheDamned.Util;
using System;
using BookoftheDamned.MechanicsChanges;
using static UnityModManagerNet.UnityModManager.ModEntry;
using Kingmaker.Enums;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Blueprints.Root;
using Kingmaker.ResourceLinks;
using static BookoftheDamned.MechanicsChanges.ExtraActivatableAbilityGroups;
using Kingmaker.UnitLogic.Buffs.Blueprints;

namespace BookoftheDamned.Archetypes.UrbanBarbarianRage
{
    internal class ControlledRage
    {
        #region Controlled Rage +8
        internal const string ControlledRageStr8Name = "UrbanBarbarian.ControlledRageStr8";
        internal const string ControlledRageStr8Buff = "UrbanBarbarian.ControlledRageStr8.Buff";
        internal const string ControlledRageSwitchStr8Buff = "UrbanBarbarian.ControlledRageStr8.SwitchBuff";
        private const string ControlledRageStr8DisplayName = "UrbanBarbarian.ControlledRageStr8.Name";

        internal const string ControlledRageDex8Name = "UrbanBarbarian.ControlledRageDex8";
        internal const string ControlledRageDex8Buff = "UrbanBarbarian.ControlledRageDex8.Buff";
        internal const string ControlledRageSwitchDex8Buff = "UrbanBarbarian.ControlledRageDex8.SwitchBuff";
        private const string ControlledRageDex8DisplayName = "UrbanBarbarian.ControlledRageDex8.Name";

        internal const string ControlledRageCon8Name = "UrbanBarbarian.ControlledRageCon8";
        internal const string ControlledRageCon8Buff = "UrbanBarbarian.ControlledRageCon8.Buff";
        internal const string ControlledRageSwitchCon8Buff = "UrbanBarbarian.ControlledRageCon8.SwitchBuff";
        private const string ControlledRageCon8DisplayName = "UrbanBarbarian.ControlledRageCon8.Name";
        #endregion

        #region Controlled Rage +6
        internal const string ControlledRageStr6Name = "UrbanBarbarian.ControlledRageStr6";
        internal const string ControlledRageStr6Buff = "UrbanBarbarian.ControlledRageStr6.Buff";
        internal const string ControlledRageSwitchStr6Buff = "UrbanBarbarian.ControlledRageStr6.SwitchBuff";
        private const string ControlledRageStr6DisplayName = "UrbanBarbarian.ControlledRageStr6.Name";
        private const string ControlledRageStr6Description = "UrbanBarbarian.ControlledRageStr6.Description";

        internal const string ControlledRageDex6Name = "UrbanBarbarian.ControlledRageDex6";
        internal const string ControlledRageDex6Buff = "UrbanBarbarian.ControlledRageDex6.Buff";
        internal const string ControlledRageSwitchDex6Buff = "UrbanBarbarian.ControlledRageDex6.SwitchBuff";
        private const string ControlledRageDex6DisplayName = "UrbanBarbarian.ControlledRageDex6.Name";
        private const string ControlledRageDex6Description = "UrbanBarbarian.ControlledRageDex6.Description";

        internal const string ControlledRageCon6Name = "UrbanBarbarian.ControlledRageCon6";
        internal const string ControlledRageCon6Buff = "UrbanBarbarian.ControlledRageCon6.Buff";
        internal const string ControlledRageSwitchCon6Buff = "UrbanBarbarian.ControlledRageCon6.SwitchBuff";
        private const string ControlledRageCon6DisplayName = "UrbanBarbarian.ControlledRageCon6.Name";
        private const string ControlledRageCon6Description = "UrbanBarbarian.ControlledRageCon6.Description";
        #endregion

        #region Controlled Rage +4
        internal const string ControlledRageStr4Name = "UrbanBarbarian.ControlledRageStr4";
        internal const string ControlledRageStr4Buff = "UrbanBarbarian.ControlledRageStr4.Buff";
        internal const string ControlledRageSwitchStr4Buff = "UrbanBarbarian.ControlledRageStr4.SwitchBuff";
        private const string ControlledRageStr4DisplayName = "UrbanBarbarian.ControlledRageStr4.Name";
        private const string ControlledRageStr4Description = "UrbanBarbarian.ControlledRageStr4.Description";

        internal const string ControlledRageDex4Name = "UrbanBarbarian.ControlledRageDex4";
        internal const string ControlledRageDex4Buff = "UrbanBarbarian.ControlledRageDex4.Buff";
        internal const string ControlledRageSwitchDex4Buff = "UrbanBarbarian.ControlledRageDex4.SwitchBuff";
        private const string ControlledRageDex4DisplayName = "UrbanBarbarian.ControlledRageDex4.Name";
        private const string ControlledRageDex4Description = "UrbanBarbarian.ControlledRageDex4.Description";

        internal const string ControlledRageCon4Name = "UrbanBarbarian.ControlledRageCon4";
        internal const string ControlledRageCon4Buff = "UrbanBarbarian.ControlledRageCon4.Buff";
        internal const string ControlledRageSwitchCon4Buff = "UrbanBarbarian.ControlledRageCon4.SwitchBuff";
        private const string ControlledRageCon4DisplayName = "UrbanBarbarian.ControlledRageCon4.Name";
        private const string ControlledRageCon4Description = "UrbanBarbarian.ControlledRageCon4.Description";
        #endregion

        #region Controlled Rage +2
        internal const string ControlledRageStr2Name = "UrbanBarbarian.ControlledRageStr2";
        internal const string ControlledRageStr2Buff = "UrbanBarbarian.ControlledRageStr2.Buff";
        internal const string ControlledRageSwitchStr2Buff = "UrbanBarbarian.ControlledRageStr2.SwitchBuff";
        private const string ControlledRageStr2DisplayName = "UrbanBarbarian.ControlledRageStr2.Name";
        private const string ControlledRageStr2Description = "UrbanBarbarian.ControlledRageStr2.Description";

        internal const string ControlledRageDex2Name = "UrbanBarbarian.ControlledRageDex2";
        internal const string ControlledRageDex2Buff = "UrbanBarbarian.ControlledRageDex2.Buff";
        internal const string ControlledRageSwitchDex2Buff = "UrbanBarbarian.ControlledRageDex2.SwitchBuff";
        private const string ControlledRageDex2DisplayName = "UrbanBarbarian.ControlledRageDex2.Name";
        private const string ControlledRageDex2Description = "UrbanBarbarian.ControlledRageDex2.Description";

        internal const string ControlledRageCon2Name = "UrbanBarbarian.ControlledRageCon2";
        internal const string ControlledRageCon2Buff = "UrbanBarbarian.ControlledRageCon2.Buff";
        internal const string ControlledRageSwitchCon2Buff = "UrbanBarbarian.ControlledRageCon2.SwitchBuff";
        private const string ControlledRageCon2DisplayName = "UrbanBarbarian.ControlledRageCon2.Name";
        private const string ControlledRageCon2Description = "UrbanBarbarian.ControlledRageCon2.Description";
        #endregion

        private const string IconPrefix = "assets/icons/";
        private const string IconNameStr8 = IconPrefix + "controlledragestr8.png";
        private const string IconNameStr6 = IconPrefix + "controlledragestr6.png";
        private const string IconNameStr4 = IconPrefix + "controlledragestr4.png";
        private const string IconNameStr2 = IconPrefix + "controlledragestr2.png";
        private const string IconNameDex8 = IconPrefix + "controlledragedex8.png";
        private const string IconNameDex6 = IconPrefix + "controlledragedex6.png";
        private const string IconNameDex4 = IconPrefix + "controlledragedex4.png";
        private const string IconNameDex2 = IconPrefix + "controlledragedex2.png";
        private const string IconNameCon8 = IconPrefix + "controlledragecon8.png";
        private const string IconNameCon6 = IconPrefix + "controlledragecon6.png";
        private const string IconNameCon4 = IconPrefix + "controlledragecon4.png";
        private const string IconNameCon2 = IconPrefix + "controlledragecon2.png";

        private static readonly ModLogger Logger = Logging.GetLogger(UrbanBarbarian.ControlledRageFeature);

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
            Logger.Log($"Configuring Controlled Rage Abilities (disabled)");
            #region Controlled Rage +8
            ActivatableAbilityConfigurator.New(ControlledRageStr8Name, Guids.ControlledRageStr8Ability).Configure();
            BuffConfigurator.New(ControlledRageStr8Buff, Guids.ControlledRageStr8Buff).Configure();
            BuffConfigurator.New(ControlledRageSwitchStr8Buff, Guids.ControlledRageSwitchStr8Buff).Configure();
            ActivatableAbilityConfigurator.New(ControlledRageDex8Name, Guids.ControlledRageDex8Ability).Configure();
            BuffConfigurator.New(ControlledRageDex8Buff, Guids.ControlledRageDex8Buff).Configure();
            BuffConfigurator.New(ControlledRageSwitchDex8Buff, Guids.ControlledRageSwitchDex8Buff).Configure();
            ActivatableAbilityConfigurator.New(ControlledRageCon8Name, Guids.ControlledRageCon8Ability).Configure();
            BuffConfigurator.New(ControlledRageCon8Buff, Guids.ControlledRageCon8Buff).Configure();
            BuffConfigurator.New(ControlledRageSwitchCon8Buff, Guids.ControlledRageSwitchCon8Buff).Configure();
            #endregion

            #region Controlled Rage +6
            ActivatableAbilityConfigurator.New(ControlledRageStr6Name, Guids.ControlledRageStr6Ability).Configure();
            BuffConfigurator.New(ControlledRageStr6Buff, Guids.ControlledRageStr6Buff).Configure();
            BuffConfigurator.New(ControlledRageSwitchStr6Buff, Guids.ControlledRageSwitchStr6Buff).Configure();
            ActivatableAbilityConfigurator.New(ControlledRageDex6Name, Guids.ControlledRageDex6Ability).Configure();
            BuffConfigurator.New(ControlledRageDex6Buff, Guids.ControlledRageDex6Buff).Configure();
            BuffConfigurator.New(ControlledRageSwitchDex6Buff, Guids.ControlledRageSwitchDex6Buff).Configure();
            ActivatableAbilityConfigurator.New(ControlledRageCon6Name, Guids.ControlledRageCon6Ability).Configure();
            BuffConfigurator.New(ControlledRageCon6Buff, Guids.ControlledRageCon6Buff).Configure();
            BuffConfigurator.New(ControlledRageSwitchCon6Buff, Guids.ControlledRageSwitchCon6Buff).Configure();
            #endregion

            #region Controlled Rage +4
            ActivatableAbilityConfigurator.New(ControlledRageStr4Name, Guids.ControlledRageStr4Ability).Configure();
            BuffConfigurator.New(ControlledRageStr4Buff, Guids.ControlledRageStr4Buff).Configure();
            BuffConfigurator.New(ControlledRageSwitchStr4Buff, Guids.ControlledRageSwitchStr4Buff).Configure();
            ActivatableAbilityConfigurator.New(ControlledRageDex4Name, Guids.ControlledRageDex4Ability).Configure();
            BuffConfigurator.New(ControlledRageDex4Buff, Guids.ControlledRageDex4Buff).Configure();
            BuffConfigurator.New(ControlledRageSwitchDex4Buff, Guids.ControlledRageSwitchDex4Buff).Configure();
            ActivatableAbilityConfigurator.New(ControlledRageCon4Name, Guids.ControlledRageCon4Ability).Configure();
            BuffConfigurator.New(ControlledRageCon4Buff, Guids.ControlledRageCon4Buff).Configure();
            BuffConfigurator.New(ControlledRageSwitchCon4Buff, Guids.ControlledRageSwitchCon4Buff).Configure();
            #endregion

            #region Controlled Rage +2
            ActivatableAbilityConfigurator.New(ControlledRageStr2Name, Guids.ControlledRageStr2Ability).Configure();
            BuffConfigurator.New(ControlledRageSwitchStr2Buff, Guids.ControlledRageSwitchStr2Buff).Configure();
            BuffConfigurator.New(ControlledRageStr2Buff, Guids.ControlledRageStr2Buff).Configure();
            ActivatableAbilityConfigurator.New(ControlledRageDex2Name, Guids.ControlledRageDex2Ability).Configure();
            BuffConfigurator.New(ControlledRageDex2Buff, Guids.ControlledRageDex2Buff).Configure();
            BuffConfigurator.New(ControlledRageSwitchDex2Buff, Guids.ControlledRageSwitchDex2Buff).Configure();
            ActivatableAbilityConfigurator.New(ControlledRageCon2Name, Guids.ControlledRageCon2Ability).Configure();
            BuffConfigurator.New(ControlledRageCon2Buff, Guids.ControlledRageCon2Buff).Configure();
            BuffConfigurator.New(ControlledRageSwitchCon2Buff, Guids.ControlledRageSwitchCon2Buff).Configure();
            #endregion
        }

        private static void ConfigureEnabled()
        {
            Logger.Log($"Configuring Controlled Rage Abilities");
            #region Controlled Rage +8
            var buffStr8 = BuffConfigurator.New(ControlledRageStr8Buff, Guids.ControlledRageStr8Buff)
                .SetDisplayName(ControlledRageStr8DisplayName)
                .SetDescription(UrbanBarbarian.ControlledRageDescription)
                .SetIcon(IconNameStr8)
                .AddBuffParticleEffectPlay("3b42d149d55dfe5469d9967f22d7e020", playOnActivate: true)
                .AddStatBonus(descriptor: ModifierDescriptor.Morale, stat: StatType.Strength, value: 8)
                .SetFlags(BlueprintBuff.Flags.HiddenInUi)
                .Configure();

            var buffSwStr8 = BuffConfigurator.New(ControlledRageSwitchStr8Buff, Guids.ControlledRageSwitchStr8Buff)
                .AddBuffExtraEffects(checkedBuff: Guids.UrbanBarbarianControlledRageBuff, extraEffectBuff: buffStr8)
                .SetFlags(BlueprintBuff.Flags.HiddenInUi)
                .Configure();

            ActivatableAbilityConfigurator.New(ControlledRageStr8Name, Guids.ControlledRageStr8Ability)
                .SetDisplayName(ControlledRageStr8DisplayName)
                .SetDescription(UrbanBarbarian.ControlledRageDescription)
                .SetGroup(ExtraActivatableAbilityGroup.ControlledRageGroup.Group())
                .SetIcon(IconNameStr8)
                .SetWeightInGroup(4)
                .SetBuff(buffSwStr8)
                .Configure();

            var buffDex8 = BuffConfigurator.New(ControlledRageDex8Buff, Guids.ControlledRageDex8Buff)
                .SetDisplayName(ControlledRageDex8DisplayName)
                .SetDescription(UrbanBarbarian.ControlledRageDescription)
                .SetIcon(IconNameDex8)
                .AddBuffParticleEffectPlay("b5fc8209a9e75ff47acfd132540e0ba6", playOnActivate: true)
                .AddStatBonus(descriptor: ModifierDescriptor.Morale, stat: StatType.Dexterity, value: 8)
                .SetFlags(BlueprintBuff.Flags.HiddenInUi)
                .Configure();

            var buffSwDex8 = BuffConfigurator.New(ControlledRageSwitchDex8Buff, Guids.ControlledRageSwitchDex8Buff)
                .AddBuffExtraEffects(checkedBuff: Guids.UrbanBarbarianControlledRageBuff, extraEffectBuff: buffDex8)
                .SetFlags(BlueprintBuff.Flags.HiddenInUi)
                .Configure();

            ActivatableAbilityConfigurator.New(ControlledRageDex8Name, Guids.ControlledRageDex8Ability)
                .SetDisplayName(ControlledRageDex8DisplayName)
                .SetDescription(UrbanBarbarian.ControlledRageDescription)
                .SetIcon(IconNameDex8)
                .SetGroup(ExtraActivatableAbilityGroup.ControlledRageGroup.Group())
                .SetWeightInGroup(4)
                .SetBuff(buffSwDex8)
                .Configure();

            var buffCon8 = BuffConfigurator.New(ControlledRageCon8Buff, Guids.ControlledRageCon8Buff)
                .SetDisplayName(ControlledRageCon8DisplayName)
                .SetDescription(UrbanBarbarian.ControlledRageDescription)
                .SetIcon(IconNameCon8)
                .AddBuffParticleEffectPlay("b1aeb1fb651d0584bb12244f64a64e9a", playOnActivate: true)
                .AddStatBonus(descriptor: ModifierDescriptor.Morale, stat: StatType.Constitution, value: 8)
                .SetFlags(BlueprintBuff.Flags.HiddenInUi)
                .Configure();

            var buffSwCon8 = BuffConfigurator.New(ControlledRageSwitchCon8Buff, Guids.ControlledRageSwitchCon8Buff)
                .AddBuffExtraEffects(checkedBuff: Guids.UrbanBarbarianControlledRageBuff, extraEffectBuff: buffCon8)
                .SetFlags(BlueprintBuff.Flags.HiddenInUi)
                .Configure();

            ActivatableAbilityConfigurator.New(ControlledRageCon8Name, Guids.ControlledRageCon8Ability)
                .SetDisplayName(ControlledRageCon8DisplayName)
                .SetDescription(UrbanBarbarian.ControlledRageDescription)
                .SetIcon(IconNameCon8)
                .SetGroup(ExtraActivatableAbilityGroup.ControlledRageGroup.Group())
                .SetWeightInGroup(4)
                .SetBuff(buffSwCon8)
                .Configure();
            #endregion

            #region Controlled Rage +6
            var buffStr6 = BuffConfigurator.New(ControlledRageStr6Buff, Guids.ControlledRageStr6Buff)
                .SetDisplayName(ControlledRageStr6DisplayName)
                .SetDescription(UrbanBarbarian.ControlledRageDescription)
                .SetIcon(IconNameStr6)
                .AddBuffParticleEffectPlay("3b42d149d55dfe5469d9967f22d7e020", playOnActivate: true)
                .AddStatBonus(descriptor: ModifierDescriptor.Morale, stat: StatType.Strength, value: 6)
                .SetFlags(BlueprintBuff.Flags.HiddenInUi)
                .Configure();

            var buffSwStr6 = BuffConfigurator.New(ControlledRageSwitchStr6Buff, Guids.ControlledRageSwitchStr6Buff)
                .AddBuffExtraEffects(checkedBuff: Guids.UrbanBarbarianControlledRageBuff, extraEffectBuff: buffStr6)
                .SetFlags(BlueprintBuff.Flags.HiddenInUi)
                .Configure();

            ActivatableAbilityConfigurator.New(ControlledRageStr6Name, Guids.ControlledRageStr6Ability)
                .SetDisplayName(ControlledRageStr6DisplayName)
                .SetDescription(UrbanBarbarian.ControlledRageDescription)
                .SetIcon(IconNameStr6)
                .SetGroup(ExtraActivatableAbilityGroup.ControlledRageGroup.Group())
                .SetWeightInGroup(3)
                .SetBuff(buffSwStr6)
                .Configure();

            var buffDex6 = BuffConfigurator.New(ControlledRageDex6Buff, Guids.ControlledRageDex6Buff)
                .SetDisplayName(ControlledRageDex6DisplayName)
                .SetDescription(UrbanBarbarian.ControlledRageDescription)
                .SetIcon(IconNameDex6)
                .AddBuffParticleEffectPlay("b5fc8209a9e75ff47acfd132540e0ba6", playOnActivate: true)
                .AddStatBonus(descriptor: ModifierDescriptor.Morale, stat: StatType.Dexterity, value: 6)
                .SetFlags(BlueprintBuff.Flags.HiddenInUi)
                .Configure();

            var buffSwDex6 = BuffConfigurator.New(ControlledRageSwitchDex6Buff, Guids.ControlledRageSwitchDex6Buff)
                .AddBuffExtraEffects(checkedBuff: Guids.UrbanBarbarianControlledRageBuff, extraEffectBuff: buffDex6)
                .SetFlags(BlueprintBuff.Flags.HiddenInUi)
                .Configure();

            ActivatableAbilityConfigurator.New(ControlledRageDex6Name, Guids.ControlledRageDex6Ability)
                .SetDisplayName(ControlledRageDex6DisplayName)
                .SetDescription(UrbanBarbarian.ControlledRageDescription)
                .SetIcon(IconNameDex6)
                .SetGroup(ExtraActivatableAbilityGroup.ControlledRageGroup.Group())
                .SetWeightInGroup(3)
                .SetBuff(buffSwDex6)
                .Configure();

            var buffCon6 = BuffConfigurator.New(ControlledRageCon6Buff, Guids.ControlledRageCon6Buff)
                .SetDisplayName(ControlledRageCon6DisplayName)
                .SetDescription(UrbanBarbarian.ControlledRageDescription)
                .SetIcon(IconNameCon6)
                .AddBuffParticleEffectPlay("b1aeb1fb651d0584bb12244f64a64e9a", playOnActivate: true)
                .AddStatBonus(descriptor: ModifierDescriptor.Morale, stat: StatType.Constitution, value: 6)
                .SetFlags(BlueprintBuff.Flags.HiddenInUi)
                .Configure();

            var buffSwCon6 = BuffConfigurator.New(ControlledRageSwitchCon6Buff, Guids.ControlledRageSwitchCon6Buff)
                .AddBuffExtraEffects(checkedBuff: Guids.UrbanBarbarianControlledRageBuff, extraEffectBuff: buffCon6)
                .SetFlags(BlueprintBuff.Flags.HiddenInUi)
                .Configure();

            ActivatableAbilityConfigurator.New(ControlledRageCon6Name, Guids.ControlledRageCon6Ability)
                .SetDisplayName(ControlledRageCon6DisplayName)
                .SetDescription(UrbanBarbarian.ControlledRageDescription)
                .SetIcon(IconNameCon6)
                .SetGroup(ExtraActivatableAbilityGroup.ControlledRageGroup.Group())
                .SetWeightInGroup(3)
                .SetBuff(buffSwCon6)
                .Configure();
            #endregion

            #region Controlled Rage +4
            var buffStr4 = BuffConfigurator.New(ControlledRageStr4Buff, Guids.ControlledRageStr4Buff)
                .SetDisplayName(ControlledRageStr4DisplayName)
                .SetDescription(UrbanBarbarian.ControlledRageDescription)
                .SetIcon(IconNameStr4)
                .AddBuffParticleEffectPlay("3b42d149d55dfe5469d9967f22d7e020", playOnActivate: true)
                .AddStatBonus(descriptor: ModifierDescriptor.Morale, stat: StatType.Strength, value: 4)
                .SetFlags(BlueprintBuff.Flags.HiddenInUi)
                .Configure();

            var buffSwStr4 = BuffConfigurator.New(ControlledRageSwitchStr4Buff, Guids.ControlledRageSwitchStr4Buff)
                .AddBuffExtraEffects(checkedBuff: Guids.UrbanBarbarianControlledRageBuff, extraEffectBuff: buffStr4)
                .SetFlags(BlueprintBuff.Flags.HiddenInUi)
                .Configure();

            ActivatableAbilityConfigurator.New(ControlledRageStr4Name, Guids.ControlledRageStr4Ability)
                .SetDisplayName(ControlledRageStr4DisplayName)
                .SetDescription(UrbanBarbarian.ControlledRageDescription)
                .SetIcon(IconNameStr4)
                .SetGroup(ExtraActivatableAbilityGroup.ControlledRageGroup.Group())
                .SetWeightInGroup(2)
                .SetBuff(buffSwStr4)
                .Configure();

            var buffDex4 = BuffConfigurator.New(ControlledRageDex4Buff, Guids.ControlledRageDex4Buff)
                .SetDisplayName(ControlledRageDex4DisplayName)
                .SetDescription(UrbanBarbarian.ControlledRageDescription)
                .SetIcon(IconNameDex4)
                .AddBuffParticleEffectPlay("b5fc8209a9e75ff47acfd132540e0ba6", playOnActivate: true)
                .AddStatBonus(descriptor: ModifierDescriptor.Morale, stat: StatType.Dexterity, value: 4)
                .SetFlags(BlueprintBuff.Flags.HiddenInUi)
                .Configure();

            var buffSwDex4 = BuffConfigurator.New(ControlledRageSwitchDex4Buff, Guids.ControlledRageSwitchDex4Buff)
                .AddBuffExtraEffects(checkedBuff: Guids.UrbanBarbarianControlledRageBuff, extraEffectBuff: buffDex4)
                .SetFlags(BlueprintBuff.Flags.HiddenInUi)
                .Configure();

            ActivatableAbilityConfigurator.New(ControlledRageDex4Name, Guids.ControlledRageDex4Ability)
                .SetDisplayName(ControlledRageDex4DisplayName)
                .SetDescription(UrbanBarbarian.ControlledRageDescription)
                .SetIcon(IconNameDex4)
                .SetGroup(ExtraActivatableAbilityGroup.ControlledRageGroup.Group())
                .SetWeightInGroup(2)
                .SetBuff(buffSwDex4)
                .Configure();

            var buffCon4 = BuffConfigurator.New(ControlledRageCon4Buff, Guids.ControlledRageCon4Buff)
                .SetDisplayName(ControlledRageCon4DisplayName)
                .SetDescription(UrbanBarbarian.ControlledRageDescription)
                .SetIcon(IconNameCon4)
                .AddBuffParticleEffectPlay("b1aeb1fb651d0584bb12244f64a64e9a", playOnActivate: true)
                .AddStatBonus(descriptor: ModifierDescriptor.Morale, stat: StatType.Constitution, value: 4)
                .SetFlags(BlueprintBuff.Flags.HiddenInUi)
                .Configure();

            var buffSwCon4 = BuffConfigurator.New(ControlledRageSwitchCon4Buff, Guids.ControlledRageSwitchCon4Buff)
                .AddBuffExtraEffects(checkedBuff: Guids.UrbanBarbarianControlledRageBuff, extraEffectBuff: buffCon4)
                .SetFlags(BlueprintBuff.Flags.HiddenInUi)
                .Configure();

            ActivatableAbilityConfigurator.New(ControlledRageCon4Name, Guids.ControlledRageCon4Ability)
                .SetDisplayName(ControlledRageCon4DisplayName)
                .SetDescription(UrbanBarbarian.ControlledRageDescription)
                .SetIcon(IconNameCon4)
                .SetGroup(ExtraActivatableAbilityGroup.ControlledRageGroup.Group())
                .SetWeightInGroup(2)
                .SetBuff(buffSwCon4)
                .Configure();
            #endregion

            #region Controlled Rage +2
            var buffStr2 = BuffConfigurator.New(ControlledRageStr2Buff, Guids.ControlledRageStr2Buff)
                .SetDisplayName(ControlledRageStr2DisplayName)
                .SetDescription(UrbanBarbarian.ControlledRageDescription)
                .SetIcon(IconNameStr2)
                .AddBuffParticleEffectPlay("3b42d149d55dfe5469d9967f22d7e020", playOnActivate: true)
                .AddStatBonus(descriptor: ModifierDescriptor.Morale, stat: StatType.Strength, value: 2)
                .SetFlags(BlueprintBuff.Flags.HiddenInUi)
                .Configure();

            var buffSwStr2 = BuffConfigurator.New(ControlledRageSwitchStr2Buff, Guids.ControlledRageSwitchStr2Buff)
                .AddBuffExtraEffects(checkedBuff: Guids.UrbanBarbarianControlledRageBuff, extraEffectBuff: buffStr2)
                .SetFlags(BlueprintBuff.Flags.HiddenInUi)
                .Configure();

            ActivatableAbilityConfigurator.New(ControlledRageStr2Name, Guids.ControlledRageStr2Ability)
                .SetDisplayName(ControlledRageStr2DisplayName)
                .SetDescription(UrbanBarbarian.ControlledRageDescription)
                .SetGroup(ExtraActivatableAbilityGroup.ControlledRageGroup.Group())
                .SetIcon(IconNameStr2)
                .SetWeightInGroup(1)
                .SetBuff(buffSwStr2)
                .Configure();

            var buffDex2 = BuffConfigurator.New(ControlledRageDex2Buff, Guids.ControlledRageDex2Buff)
                .SetDisplayName(ControlledRageDex2DisplayName)
                .SetDescription(UrbanBarbarian.ControlledRageDescription)
                .SetIcon(IconNameDex2)
                .AddBuffParticleEffectPlay("b5fc8209a9e75ff47acfd132540e0ba6", playOnActivate: true)
                .AddStatBonus(descriptor: ModifierDescriptor.Morale, stat: StatType.Dexterity, value: 2)
                .SetFlags(BlueprintBuff.Flags.HiddenInUi)
                .Configure();

            var buffSwDex2 = BuffConfigurator.New(ControlledRageSwitchDex2Buff, Guids.ControlledRageSwitchDex2Buff)
                .AddBuffExtraEffects(checkedBuff: Guids.UrbanBarbarianControlledRageBuff, extraEffectBuff: buffDex2)
                .SetFlags(BlueprintBuff.Flags.HiddenInUi)
                .Configure();

            ActivatableAbilityConfigurator.New(ControlledRageDex2Name, Guids.ControlledRageDex2Ability)
                .SetDisplayName(ControlledRageDex2DisplayName)
                .SetDescription(UrbanBarbarian.ControlledRageDescription)
                .SetIcon(IconNameDex2)
                .SetGroup(ExtraActivatableAbilityGroup.ControlledRageGroup.Group())
                .SetWeightInGroup(1)
                .SetBuff(buffSwDex2)
                .Configure();

            var buffCon2 = BuffConfigurator.New(ControlledRageCon2Buff, Guids.ControlledRageCon2Buff)
                .SetDisplayName(ControlledRageCon2DisplayName)
                .SetDescription(UrbanBarbarian.ControlledRageDescription)
                .SetIcon(IconNameCon2)
                .AddBuffParticleEffectPlay("b1aeb1fb651d0584bb12244f64a64e9a", playOnActivate: true)
                .AddStatBonus(descriptor: ModifierDescriptor.Morale, stat: StatType.Constitution, value: 2)
                .SetFlags(BlueprintBuff.Flags.HiddenInUi)
                .Configure();

            var buffSwCon2 = BuffConfigurator.New(ControlledRageSwitchCon2Buff, Guids.ControlledRageSwitchCon2Buff)
                .AddBuffExtraEffects(checkedBuff: Guids.UrbanBarbarianControlledRageBuff, extraEffectBuff: buffCon2)
                .SetFlags(BlueprintBuff.Flags.HiddenInUi)
                .Configure();

            ActivatableAbilityConfigurator.New(ControlledRageCon2Name, Guids.ControlledRageCon2Ability)
                .SetDisplayName(ControlledRageCon2DisplayName)
                .SetDescription(UrbanBarbarian.ControlledRageDescription)
                .SetIcon(IconNameCon2)
                .SetGroup(ExtraActivatableAbilityGroup.ControlledRageGroup.Group())
                .SetWeightInGroup(1)
                .SetBuff(buffSwCon2)
                .Configure();
            #endregion
        }
    }
}