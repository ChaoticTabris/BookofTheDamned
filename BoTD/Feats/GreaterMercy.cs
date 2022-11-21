using BlueprintCore.Blueprints.Configurators.Collections;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using BookoftheDamned.Util;
using JetBrains.Annotations;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Buffs;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using static UnityModManagerNet.UnityModManager.ModEntry;

namespace BookoftheDamned.Feats
{
    public class GreaterMercy
    {
        internal const string FeatName = "GreaterMercy";

        internal const string FeatDisplayName = "GreaterMercy.Name";
        private static readonly string FeatDescription = "GreaterMercy.Description";

        internal const string UltimateFeatName = "UltimateMercy";

        internal const string UltimateFeatDisplayName = "UltimateMercy.Name";
        private static readonly string UltimateFeatDescription = "UltimateMercy.Description";

        internal const string AbilityName = "UltimateMercy.Ability";

        private static readonly ModLogger Logger = Logging.GetLogger(FeatName);
        public static void Configure()
        {
            Logger.Log($"Configuring {FeatName}");
            var ability =
                AbilityConfigurator.New(AbilityName, Guids.UltimateMercyAbility)
                .SetDisplayName(UltimateFeatDisplayName)
                .SetDescription(UltimateFeatDescription)
                .AddAbilityResourceLogic(isSpendResource: true, requiredResource: AbilityResourceRefs.LayOnHandsResource.ToString(), amount: 10)
                .CopyFrom(AbilityRefs.RaiseDead)
                .Configure();

            FeatureConfigurator.New(FeatName, Guids.GreaterMercyFeat, FeatureGroup.Feat)
             .SetDisplayName(FeatDisplayName)
             .SetDescription(FeatDescription)
             .AddPrerequisiteStatValue(Kingmaker.EntitySystem.Stats.StatType.Charisma, 13)
             .AddPrerequisiteFeature(FeatureRefs.LayOnHandsFeature.ToString())
             .AddPrerequisiteFeature(FeatureSelectionRefs.SelectionMercy.ToString())
             .AddToIsPrerequisiteFor(Guids.UltimateMercyFeat)
             .AddComponent(new GreaterMercyComponent())
             .Configure(delayed: true);

            Logger.Log($"Configuring {UltimateFeatName}");
            FeatureConfigurator.New(UltimateFeatName, Guids.UltimateMercyFeat, FeatureGroup.Feat)
               .SetDisplayName(UltimateFeatDisplayName)
               .SetDescription(UltimateFeatDescription)
               .AddPrerequisiteStatValue(Kingmaker.EntitySystem.Stats.StatType.Charisma, 19)
               .AddPrerequisiteFeature(FeatureRefs.LayOnHandsFeature.ToString())
               .AddPrerequisiteFeature(FeatureSelectionRefs.SelectionMercy.ToString())
               .AddPrerequisiteFeature(FeatName)
               .AddFacts(new() { ability })
               .Configure(delayed: true);
        }

        private class GreaterMercyComponent : UnitFactComponentDelegate, IInitiatorRulebookHandler<RuleHealDamage>
        {
            static List<(BlueprintFeature mercy, SpellDescriptor descriptor)> mercyList = new List<(BlueprintFeature mercy, SpellDescriptor descriptor)>()
        {
            new (FeatureRefs.MercyBlinded.Reference.Get(), SpellDescriptor.Blindness),
            new (FeatureRefs.MercyConfused.Reference.Get(), SpellDescriptor.Confusion),
            new (FeatureRefs.MercyCursed.Reference.Get(), SpellDescriptor.Curse),
            new (FeatureRefs.MercyDazed.Reference.Get(), SpellDescriptor.Daze),
            new (FeatureRefs.MercyDiseased.Reference.Get(), SpellDescriptor.Disease),
            new (FeatureRefs.MercyExhausted.Reference.Get(), SpellDescriptor.Exhausted),
            new (FeatureRefs.MercyFatigued.Reference.Get(), SpellDescriptor.Fatigue),
            new (FeatureRefs.MercyFrightened.Reference.Get(), SpellDescriptor.Frightened),
            new (FeatureRefs.MercyNauseated.Reference.Get(), SpellDescriptor.Nauseated),
            new (FeatureRefs.MercyParalyzed.Reference.Get(), SpellDescriptor.Paralysis),
            new (FeatureRefs.MercyPoisoned.Reference.Get(), SpellDescriptor.Poison),
            new (FeatureRefs.MercyShaken.Reference.Get(), SpellDescriptor.Shaken),
            new (FeatureRefs.MercySickened.Reference.Get(), SpellDescriptor.Sickened),
            new (FeatureRefs.MercyStaggered.Reference.Get(), SpellDescriptor.Staggered),
            new (FeatureRefs.MercyStunned.Reference.Get(), SpellDescriptor.Stun)
        };
            public void OnEventAboutToTrigger(RuleHealDamage evt) { }

            public void OnEventDidTrigger(RuleHealDamage evt)
            {
                try
                {
                    Logger.NativeLog("Attempting OnEventDidTrigger operation");
                //Return if Healing is NOT being done by a form of Lay On Hands
                if (evt.Reason.Ability.Fact.Blueprint == null)
                    return;
                if ((evt.Reason.Ability.Fact.Blueprint != AbilityRefs.LayOnHandsSelf.Reference.Get()) && (evt.Reason.Ability.Fact.Blueprint != AbilityRefs.LayOnHandsOthers.Reference.Get()) && (evt.Reason.Ability.Fact.Blueprint != AbilityRefs.LayOnHandsSelfOrTroth.Reference.Get()))
                {
                    Logger.NativeLog("Skipped: Heal not being done by Lay On Hands");
                    return;
                }
                    UnitEntityData caster = evt.Reason.Caster;
                    UnitEntityData target = evt.Reason.Context.MainTarget.Unit;

                    //Check for use of Mercies
                    BuffCollection buffs = evt.Target.Buffs;
                    FeatureCollection paladinFeatures = Owner.Progression.Features;
                    var descriptorSum = SpellDescriptor.None;
                    foreach ((BlueprintFeature mercy, SpellDescriptor descriptor) in mercyList)
                    {
                        if (paladinFeatures.HasFact(mercy)) descriptorSum = descriptorSum | descriptor;
                    };
                    if (buffs.Enumerable.Any(b => b.Blueprint.SpellDescriptor.HasAnyFlag(descriptorSum)))
                    {
                        Logger.NativeLog("Skipped: Mercy was used");
                        return;
                    }
                    Logger.NativeLog("Buff Applied (Hopefully)");
                    Context.TriggerRule<RuleHealDamage>(new RuleHealDamage(evt.Initiator, evt.Target, new DiceFormula(1, DiceType.D6), 0));
                }
                catch (Exception e)
                {
                    Logger.LogException("OnEventDidTrigger", e);
                }
            }
        }
    }
}
