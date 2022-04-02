using Helper;
using UnityEngine;
using World;

namespace Inventory
{
    public class InventoryManager : MonoBehaviour
    {
        private InventoryStore _inventoryStore;
        private InventoryCreator _inventoryCreator;

        public void Start()
        {
            _inventoryStore = FindObjectOfType<InventoryStore>();
            _inventoryCreator = FindObjectOfType<InventoryCreator>();
        }

        public void Collect(WorldItem worldItem)
        {
            var storedInventoryItemSlotsForItemType = _inventoryStore.GetStoredInventoryItemSlotsForItemType(worldItem.ItemType);

            if (storedInventoryItemSlotsForItemType != null)
            {
                _inventoryStore.SetAmountOfItemType(worldItem.ItemType, 1);
            }
            else
            {
                //TODO instantiate
                //TODO add to itemSlots
                var inventoryItemSlot = _inventoryCreator.Create(worldItem, transform);
                inventoryItemSlot.remove = () => RemoveItem(worldItem.MapTo());
                inventoryItemSlot.interact = () => {}; //TODO
                
                _inventoryStore.AddToInventoryItemSlot(inventoryItemSlot);
            }
        }

        public void RemoveItem(InventoryItem inventoryItem)
        {
            //TODO spawn in world

            var inventorySlotItem = _inventoryStore.GetStoredInventorySlotById(inventoryItem.ID);

            if (inventorySlotItem == null) return;

            var newAmount = _inventoryStore.SetAmountOfItemType(inventorySlotItem.Item.ItemType, -1);

            if (newAmount > 0) return;
            
            _inventoryStore.RemoveFromInventory(inventorySlotItem.Item.ID);
            Destroy(inventorySlotItem.gameObject);
        }
    }
}