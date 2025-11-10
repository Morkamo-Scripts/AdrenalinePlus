using System;
using System.Collections.Generic;
using Exiled.API.Enums;
using Exiled.API.Features;

namespace AdrenalinePlus
{
    public class Plugin : Plugin<Config>
    {
        public override string Name => "AdrenalinePlus";
        public override string Prefix => Name;
        public override string Author => "Morkamo";
        public override Version RequiredExiledVersion => new(9, 1, 0);
        public override Version Version => new(0, 0, 1);
        public override PluginPriority Priority => PluginPriority.Lowest;

        public static Plugin Instance;

        public override void OnEnabled()
        {
            Instance = this;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Instance = null;
            base.OnDisabled();
        }
    }
}