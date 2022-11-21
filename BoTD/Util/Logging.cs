﻿using System.Collections.Generic;
using static UnityModManagerNet.UnityModManager.ModEntry;

namespace BookoftheDamned.Util
{
    internal class Logging
    {
        private const string BaseChannel = "BOTD";

        private static readonly Dictionary<string, ModLogger> Loggers = new();

        internal static ModLogger GetLogger(string channel)
        {
            if (Loggers.ContainsKey(channel))
            {
                return Loggers[channel];
            }
            var logger = new ModLogger($"{BaseChannel}+{channel}");
            Loggers[channel] = logger;
            return logger;
        }
    }
}
