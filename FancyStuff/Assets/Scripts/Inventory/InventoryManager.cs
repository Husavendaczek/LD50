using Helper;
using RoomScene;
using UnityEngine;
using World;

namespace Inventory
{
    public class InventoryManager : MonoBehaviour
    {
        public IMediator mediator;
        public InventoryStore inventoryStore;
        public InventoryCreator inventoryCreator;

        public void Collect(WorldItem worldItem)
        {
            var storedInventoryItemSlotsForItemType = inventoryStore.GetStoredInventoryItemSlotsForItemType(worldItem.ItemType);

            if (storedInventoryItemSlotsForItemType != null)
            {
                inventoryStore.SetAmountOfItemType(worldItem.ItemType, 1);
            }
            else
            {
                //TODO instantiate
                //TODO add to itemSlots
                var inventoryItemSlot = inventoryCreator.Create(worldItem, transform);
                inventoryItemSlot.remove = () => RemoveItem(worldItem.MapTo());
                inventoryItemSlot.interact = () => {}; //TODO
                
                inventoryStore.AddToInventoryItemSlot(inventoryItemSlot);
            }
        }

        public void RemoveItem(InventoryItem inventoryItem)
        {
            //TODO spawn in world

            var inventorySlotItem = inventoryStore.GetStoredInventorySlotById(inventoryItem.ID);

            if (inventorySlotItem == null) return;

            var newAmount = inventoryStore.SetAmountOfItemType(inventorySlotItem.Item.ItemType, -1);

            if (newAmount > 0) return;
            
            inventoryStore.RemoveFromInventory(inventorySlotItem.Item.ID);
            Destroy(inventorySlotItem.gameObject);
        }
    }
}