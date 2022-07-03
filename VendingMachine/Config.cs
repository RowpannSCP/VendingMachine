using Exiled.API.Interfaces;

namespace VendingMachine
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using Models;

    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        public bool ShowDebug { get; set; } = false;
        
        [Description("Will give items even if there is no space in the inventory.")]
        public bool IgnoreSpace { get; set; } = false;

        [Description("The deals, use ItemType.None for random item. A random item is chosen from the list.")]
        public List<DealModel> Deals { get; set; } = new List<DealModel>()
        {
            new DealModel()
            {
                SchematicName = "VendingMachine",

                RequiredItems = new Dictionary<int, ItemType>()
                {
                    {1, ItemType.Coin}
                },

                Items = new Dictionary<int, List<ItemType>>()
                {
                    {
                        1, new List<ItemType>()
                        {
                            ItemType.None
                        }
                    }
                }
            }
        };
    }
}