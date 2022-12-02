using HarmonyLib;
using JetBrains.Annotations;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.EntitySystem;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Kingmaker.UnitLogic.Parts;
using Kingmaker.EntitySystem.Stats;
using static BookoftheDamned.MechanicsChanges.ExtraActivatableAbilityGroups;

namespace BookoftheDamned.MechanicsChanges
{

    public class UnitPartExtraActivatableAbilityGroup : OldStyleUnitPart
    {

        public const int ExtraActivatableGroupStart = 7_600;
        public const int ExtraActivatableGroupEnd = 10_199;

        [JsonProperty]
        [UsedImplicitly]
        private int[] PersistentGroupsSizeIncreases
        {
            get
            {
                return this.m_GroupsSizeIncreases;
            }
            set
            {
                this.m_GroupsSizeIncreases = (this.m_GroupsSizeIncreases ?? new int[(EnumUtils.GetMaxValue<ExtraActivatableAbilityGroup>() - ExtraActivatableGroupStart)]);
                for (int i = 0; i < Math.Min(this.m_GroupsSizeIncreases.Length, value.Length); i++)
                {
                    this.m_GroupsSizeIncreases[i] = value[i];
                }
            }
        }

        public void IncreaseGroupSize(ActivatableAbilityGroup group)
        {
            this.m_GroupsSizeIncreases[(int)(group - ExtraActivatableGroupStart)]++;
        }

        public void DecreaseGroupSize(ActivatableAbilityGroup group)
        {
            this.m_GroupsSizeIncreases[(int)(group - ExtraActivatableGroupStart)]--;
        }

        public int GetGroupSize(ActivatableAbilityGroup group)
        {
            return this.m_GroupsSizeIncreases[(int)(group - ExtraActivatableGroupStart)] + 1;
        }


        [HarmonyPatch(typeof(UnitPartActivatableAbility))]
        static class UnitPartActivatableAbilityExtraGroupPatch
        {
            [HarmonyPatch("IncreaseGroupSize", MethodType.Normal)]
            [HarmonyPrefix]
            static bool IncreaseGroupSize_Prefix(UnitPartActivatableAbility __instance, ActivatableAbilityGroup group)
            {
                if (group.IsExtra())
                {
                    __instance.Owner.Ensure<UnitPartExtraActivatableAbilityGroup>().IncreaseGroupSize(group);
                    return false;
                }

                return true;
            }




            [HarmonyPatch("DecreaseGroupSize", MethodType.Normal)]
            [HarmonyPrefix]
            static bool DecreaseGroupSize_Prefix(UnitPartActivatableAbility __instance, ActivatableAbilityGroup group)
            {
                if (group.IsExtra())
                {
                    __instance.Owner.Ensure<UnitPartExtraActivatableAbilityGroup>().DecreaseGroupSize(group);
                    return false;
                }

                return true;
            }


            [HarmonyPatch("GetGroupSize", MethodType.Normal)]
            [HarmonyPrefix]
            static bool GetGroupSize_Prefix(UnitPartActivatableAbility __instance, ActivatableAbilityGroup group, ref int __result)
            {
                if (group.IsExtra())
                {
                    __result = __instance.Owner.Ensure<UnitPartExtraActivatableAbilityGroup>().GetGroupSize(group);
                    return false;
                }

                return true;
            }

        }

        private int[] m_GroupsSizeIncreases = new int[(EnumUtils.GetMaxValue<ExtraActivatableAbilityGroup>() - ExtraActivatableGroupStart)];

        public readonly Dictionary<ExtraActivatableAbilityGroup, ActivatableAbilityGroup> ActivatableAbilityGroups = new Dictionary<ExtraActivatableAbilityGroup, ActivatableAbilityGroup>();

    }

    public static class ExtraActivatableAbilityGroups
    {
        //The last ActivatableAbilityGroup in Kingmaker.Blueprints.Classes is "ShifterAspect" [ 0x000000030 = 48 ]
        public enum ExtraActivatableAbilityGroup : int
        {
            ControlledRageGroup = 7_600
        }

        public static ActivatableAbilityGroup Group(this ExtraActivatableAbilityGroup group)
        {
            return (ActivatableAbilityGroup)group;
        }
        public static ExtraActivatableAbilityGroup ExtraGroup(this ActivatableAbilityGroup group)
        {
            return (ExtraActivatableAbilityGroup)group;
        }
        public static bool IsExtra(this ActivatableAbilityGroup group)
        {
            return (int)group >= UnitPartExtraActivatableAbilityGroup.ExtraActivatableGroupStart && (int)group <= UnitPartExtraActivatableAbilityGroup.ExtraActivatableGroupEnd;
        }


    }
}