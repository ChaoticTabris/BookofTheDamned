using BookoftheDamned.Archetypes;
using BookoftheDamned.Backgrounds;
using BookoftheDamned.Feats;
using static UnityModManagerNet.UnityModManager.ModEntry;

namespace BookoftheDamned.Util
{
    internal static class Guids
    {
        private static readonly ModLogger Logger = Logging.GetLogger(nameof(Guids));

        #region Archetypes
        internal const string UrbanBarbarianArchetype = "599fa7c4-0b16-4942-b757-265589a09406";
        internal const string UrbanBarbarianProficiencies = "ea6ff202-44f7-4c13-9011-b4456e23cc68";

        internal const string UrbanBarbarianControlledRageFeature = "1ae6ea72-a73e-4537-8053-05019037e1c6";
        internal const string UrbanBarbarianControlledRageBuff = "b6a5e597-ddd8-41f7-8cbf-23afe05c9f94";
        internal const string UrbanBarbarianControlledRageAbility = "001413eb-3703-4322-b85d-b63f5684dc68";
        internal const string UrbanBarbarianGreaterControlledRageFeature = "51e8ffe9-3471-41d5-b874-7fd864ad9228";
        internal const string UrbanBarbarianMightyControlledRageFeature = "5749b116-a5c3-452d-a808-0e11b120b9c3";

        internal const string UrbanBarbarianCrowdControl = "e502f6fe-faed-44d2-9982-c2a7783e103c";
        internal const string CrowdControlEffectBuff = "e8f916c8-9b66-4065-9fd5-ef142d31a89d";
        internal const string CrowdControlArea = "a558a276-59d9-4836-aae7-50b585d47274";
        internal const string CrowdControlBuff = "e4ee30db-8733-4099-be11-5acf90b38352";

        internal const string ControlledRageStr8Ability = "b5ff45e2-8a07-43e1-987d-f0ac4fa3113e";
        internal const string ControlledRageStr8Buff = "2b292e0a-5f9e-4026-beac-a3717b56046d";
        internal const string ControlledRageSwitchStr8Buff = "678ecd89-c793-4959-ae95-5603940f1562";

        internal const string ControlledRageDex8Ability = "503c14d8-7fe7-44c8-8b57-15a169c7121e";
        internal const string ControlledRageDex8Buff = "24dc7d88-0863-4e3b-b7f4-14c8ec1f7293";
        internal const string ControlledRageSwitchDex8Buff = "807adaab-e19e-482e-97bd-661d8458f1ce";

        internal const string ControlledRageCon8Ability = "08fa1ea4-9aa4-4165-afb2-5373afd849dc";
        internal const string ControlledRageCon8Buff = "d8b43471-6b85-45b1-a524-0f30989b419a";
        internal const string ControlledRageSwitchCon8Buff = "de5f6aba-890a-4278-acea-3a5b85e58d31";

        internal const string ControlledRageStr6Ability = "3d4148f2-dec2-4499-bf36-cd4dd34e6857";
        internal const string ControlledRageStr6Buff = "2bb1f9d0-0767-4341-8499-47cad7786171";
        internal const string ControlledRageSwitchStr6Buff = "9a4a3bde-4261-4a2f-be82-6e6d90769788";

        internal const string ControlledRageDex6Ability = "0dd99141-1345-4b8d-a240-9e93164acd65";
        internal const string ControlledRageDex6Buff = "4f7a3063-b518-4d87-b436-49985ce8b7c0";
        internal const string ControlledRageSwitchDex6Buff = "6173fbbd-8f70-4308-9515-b7f45806d82f";

        internal const string ControlledRageCon6Ability = "cd821520-eba3-44bd-a4ce-df1ab5ca2ec3";
        internal const string ControlledRageCon6Buff = "34441c0b-3a26-4d79-a256-b282593f0d4c";
        internal const string ControlledRageSwitchCon6Buff = "d55bc4ae-adb7-427e-a85b-2fd7da4caa06";

        internal const string ControlledRageStr4Ability = "298faf33-cca5-4424-95cc-4bebdbc7e44a";
        internal const string ControlledRageStr4Buff = "3318da0c-b89d-4759-918f-4751c2e679f0";
        internal const string ControlledRageSwitchStr4Buff = "19e3b3c4-9eb3-40fe-b104-e7b5ec6153e5";

        internal const string ControlledRageDex4Ability = "63d5b2dc-f0ab-41b4-bdc1-2d2ed84b1fee";
        internal const string ControlledRageDex4Buff = "5245a7ad-3573-46e4-ac78-df2128e295e4";
        internal const string ControlledRageSwitchDex4Buff = "77dce6ff-962f-49b1-83c1-a838c86cf26d";

        internal const string ControlledRageCon4Ability = "de3b7013-b482-42a1-b367-43b8cea1eef0";
        internal const string ControlledRageCon4Buff = "bb8d2291-0caa-4f58-8b44-037e973b7bd6";
        internal const string ControlledRageSwitchCon4Buff = "8ae89a42-5e62-461a-97c9-4d3d5f63efee";

        internal const string ControlledRageStr2Ability = "3768628d-bfe4-476d-958c-8dc986ba3a5e";
        internal const string ControlledRageStr2Buff = "5fe402b8-5f5a-42e3-a10d-c31bce6635b8";
        internal const string ControlledRageSwitchStr2Buff = "449e2bf3-e756-4dc5-9335-aa9782ac341d";

        internal const string ControlledRageDex2Ability = "ec0f252b-a659-4822-9a3d-0fa5af136cda";
        internal const string ControlledRageDex2Buff = "5325fcf6-58f5-4646-96e1-af1679d4e807";
        internal const string ControlledRageSwitchDex2Buff = "f0a11799-4910-4868-84af-0ec3774c5c2b";

        internal const string ControlledRageCon2Ability = "9025ef1f-e94b-4e02-8346-09eb266c1fb6";
        internal const string ControlledRageCon2Buff = "08d34657-93da-4311-b8f6-85f91c3bc02b";
        internal const string ControlledRageSwitchCon2Buff = "49710f7e-7a94-4f74-8607-be98b959b4a6";

        internal static readonly (string guid, string displayName)[] Archetypes =
            new (string, string)[]
            {
                (UrbanBarbarianArchetype, UrbanBarbarian.ArchetypeDisplayName),
            };
        #endregion

        #region Backgrounds
        internal const string BackgroundAnatomist = "56a35356-40d7-4449-a94e-d065cfdc16b1";

        internal static readonly (string guid, string displayName)[] Backgrounds =
            new (string, string)[]
            {
                (BackgroundAnatomist, Anatomist.BackgroundDisplayName),
            };
        #endregion

        #region Feats
        internal const string UMAbility = "44575d64-10d4-427f-a441-55ed3b9bcac8";
        internal const string GreaterMercyFeat = "38c1a917-0782-48e1-b565-26da9738912d";
        internal const string UltimateMercyFeat = "77634f91-cb27-411e-bad8-dcc27349a52b";
        internal const string UMMaterialAbility = "56193666-cc61-4718-a2c7-8dd14853960e";
        internal const string UMNegLvlAbility = "76a1b56e-4bde-4247-bee1-42438c1b38b7";

        internal const string ExtraRageUrbanBarbarian = "447a5e66-b346-4ebc-b3dc-328b1e8c45e7";

        internal static readonly (string guid, string displayName)[] Feats =
            new (string, string)[]
            {
                (GreaterMercyFeat, GreaterMercy.FeatDisplayName),
                (UltimateMercyFeat, GreaterMercy.UltimateFeatDisplayName)
            };
        #endregion


    }
}