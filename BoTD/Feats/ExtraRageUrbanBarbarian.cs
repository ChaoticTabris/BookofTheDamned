using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BookoftheDamned.Util;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.UnitLogic.FactLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UnityModManagerNet.UnityModManager.ModEntry;

namespace BookoftheDamned.Feats
{
    internal class ExtraRageUrbanBarbarian
    {
        internal const string FeatName = "ExtraRageUrbanBarbarian";

        internal const string FeatDisplayName = "ExtraRageUrbanBarbarian.Name";
        //private static readonly string FeatDescription = "ExtraRageUrbanBarbarian.Description";

        private static readonly ModLogger Logger = Logging.GetLogger(FeatName);

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
            FeatureConfigurator.New(FeatName, Guids.ExtraRageUrbanBarbarian).Configure();
        }
        private static void ConfigureEnabled()
        {
            FeatureConfigurator.New(FeatName, Guids.ExtraRageUrbanBarbarian)
            .CopyFrom(FeatureRefs.ExtraRage,
                typeof(IncreaseResourceAmount),
                typeof(FeatureTagsComponent))
            .AddPrerequisiteFeature(Guids.UrbanBarbarianControlledRageFeature)
            .Configure();
        }
    }
}
