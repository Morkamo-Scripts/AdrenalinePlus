using System;
using Exiled.API.Enums;
using Exiled.API.Features;

namespace AdrenalinPlusLite
{
    public class Plugin : Plugin<Config>
    {
        public override string Name => "AdrenalinePlusLite";
        public override string Prefix => Name;
        public override string Author => "Morkamo";
        public override Version RequiredExiledVersion => new(9, 1, 0);
        public override Version Version => new(1, 0, 0);

        public static Plugin Instance;
        public Handler Handler;

        public override void OnEnabled()
        {
            Instance = this;
            Handler = Config.Handler;
            RegisterEvents();
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            UnregisterEvents();
            Handler = null;
            Instance = null;
            base.OnDisabled();
        }

        private void RegisterEvents()
        {
            LabApi.Events.Handlers.PlayerEvents.UsingItem += Handler.OnAdrenalineUsed;
        }

        private void UnregisterEvents()
        {
            LabApi.Events.Handlers.PlayerEvents.UsingItem -= Handler.OnAdrenalineUsed;
        }
    }
}