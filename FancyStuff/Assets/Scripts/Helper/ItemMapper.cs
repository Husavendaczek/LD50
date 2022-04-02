using Inventory;
using World;

namespace Helper
{
    public static class ItemMapper
    {
        public static InventoryItem MapTo(this WorldItem worldItem)
        {
            return new InventoryItem
            {
                ID = worldItem.Id,
                ItemType = worldItem.ItemType
            };
        }
        
        public static WorldItem MapTo(this InventoryItem inventoryItem)
        {
            return new WorldItem
            {
                Id = inventoryItem.ID,
                ItemType = inventoryItem.ItemType
            };
        }
        
        public static WorldItem MapTo(this WorldItemMono worldItemMono)
        {
            return new WorldItem
            {
                Id = worldItemMono.id,
                ItemType = worldItemMono.itemType,
                Position = worldItemMono.position,
                Collected = false
            };
        }
    }
}