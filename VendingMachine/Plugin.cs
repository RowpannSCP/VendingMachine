using System;
using Exiled.API.Features;
using MapEditorReborn.Events.Handlers;

namespace VendingMachine
{
    public class Plugin : Plugin<Config>
    {
        public override string Author { get; }
        public override string Name { get; }
        public override Version Version { get; }
        public override Version RequiredExiledVersion { get; }

        private EventHandlers _handlers;
        
        public override void OnEnabled()
        {
            _handlers = new EventHandlers(this);
            RegisterEvents();
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            UnRegisterEvents();
            _handlers = null;
            base.OnDisabled();
        }

        void RegisterEvents()
        {
            Schematic.ButtonInteracted += _handlers.ButtonInteracted;
        }

        void UnRegisterEvents()
        {
            Schematic.ButtonInteracted -= _handlers.ButtonInteracted;
        }
    }
}