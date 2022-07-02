﻿using Exiled.API.Interfaces;

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

        [Description("The deals, use ItemType.None for random item")]
        public List<DealModel> Deals = new List<DealModel>()
        {
            new DealModel()
            {
                SchematicName = "VendingMachine",

                RequiredItems = new Dictionary<int, ItemType>()
                {
                    {1, ItemType.Coin}
                },

                Items = new Dictionary<int, ItemType>()
                {
                    {1, ItemType.None}
                }
            }
        };
    }
}