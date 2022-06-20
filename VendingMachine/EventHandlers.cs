using MapEditorReborn.Events.EventArgs;

namespace VendingMachine
{
    public class EventHandlers
    {
        private Config _cfg;
        public EventHandlers(Plugin plugin) => _cfg = plugin.Config;

        public void ButtonInteracted(ButtonInteractedEventArgs ev)
        {
            throw new System.NotImplementedException();
        }
    }
}