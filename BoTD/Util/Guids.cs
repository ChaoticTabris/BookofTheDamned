using BookoftheDamned.Backgrounds;
using BookoftheDamned.Feats;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using static UnityModManagerNet.UnityModManager.ModEntry;

namespace BookoftheDamned.Util
{
    internal static class Guids
    {
        private static readonly ModLogger Logger = Logging.GetLogger(nameof(Guids));

        #region Backgrounds
        internal const string BackgroundAnatomist = "56a35356-40d7-4449-a94e-d065cfdc16b1";

        internal static readonly (string guid, string displayName)[] Backgrounds =
            new (string, string)[]
            {
                (BackgroundAnatomist, Anatomist.BackgroundDisplayName),
            };
        #endregion

        #region Feats
        internal const string UltimateMercyAbility = "44575d64-10d4-427f-a441-55ed3b9bcac8";
        internal const string GreaterMercyFeat = "38c1a917-0782-48e1-b565-26da9738912d";
        internal const string UltimateMercyFeat = "77634f91-cb27-411e-bad8-dcc27349a52b";

        internal static readonly (string guid, string displayName)[] Feats =
            new (string, string)[]
            {
                (GreaterMercyFeat, GreaterMercy.FeatDisplayName),
                (UltimateMercyFeat, GreaterMercy.UltimateFeatDisplayName)
            };
        #endregion


    }
}