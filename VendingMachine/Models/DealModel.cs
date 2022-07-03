namespace VendingMachine.Models
{
    using System.Collections.Generic;
    using System.ComponentModel;

    public class DealModel
    {
        public string SchematicName { get; set; }
        
        public Dictionary<int, ItemType> RequiredItems { get; set; }
        
        public Dictionary<int, List<ItemType>> Items { get; set; }
    }
}