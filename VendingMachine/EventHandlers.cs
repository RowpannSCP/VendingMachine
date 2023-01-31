using MapEditorReborn.Events.EventArgs;

namespace VendingMachine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Exiled.API.Enums;
    using Exiled.API.Extensions;
    using Exiled.API.Features;
    using Random = UnityEngine.Random;

    public class EventHandlers
    {
        private Config _cfg;
        public EventHandlers(Plugin plugin) => _cfg = plugin.Config;

        public void ButtonInteracted(ButtonInteractedEventArgs ev)
        {
            Log.Debug($"Button pressed: {ev.Player}; {ev.Button}; {ev.Schematic.Name}");
            var deal = _cfg.Deals.FirstOrDefault(x => x.SchematicName == ev.Schematic.Name);

            if (deal is null)
            {
                return;
            }
            Log.Debug($"Deal: {deal.SchematicName}; {deal.RequiredItems}; {deal.Items}");
            var ply = ev.Player;

            foreach (var item in deal.RequiredItems)
            {
                var amount = ply.Items.Count(x => x.Type == item.Value);
                if (amount < item.Key)
                {
                    ply.Broadcast(_cfg.BroadcastTime, "Missing " + (item.Key - amount) + " " + item.Value
                        .ToString()
                        .Replace("ItemType.", ""));
                    return;
                }
            }
            
            if(ev.Player.Items.Count + deal.Items.Count > 8 && !_cfg.IgnoreSpace)
            {
                ply.Broadcast(5, "You don't have enough space in your inventory!");
                return;
            }

            var types = Enum.GetValues(typeof(ItemType)) as ItemType[];
            try
            {
                foreach (var item in deal.Items)
                {
                    for (int i = 0; i < item.Key; i++)
                    {
                        ItemType type = item.Value.RandomItem();
                        if (type == ItemType.None)
                        {
                            type = types.ElementAt(Random.Range(0, types.Count() - 1));
                        }
                        ev.Player.AddItem(type);
                    }
                }
            }
            catch (Exception e)
            {
                ev.Player.Broadcast(5, "An error occurred adding items!");
                throw;
            }
            
            foreach (var item in deal.RequiredItems)
            {
                for (int i = 0; i < item.Key; i++)
                {
                    var ToRemove = ev.Player.Items.FirstOrDefault(x => x.Type == item.Value);
                    if (ToRemove is null)
                    {
                        return;
                    }

                    ev.Player.RemoveItem(ToRemove);
                }
            }
            
            ev.Player.ShowHint("Purchase successful!");
        }
    }
}