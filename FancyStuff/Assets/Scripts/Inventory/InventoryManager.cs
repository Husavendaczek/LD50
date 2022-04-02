using UnityEngine;

namespace Inventory
{
    public class InventoryManager : MonoBehaviour
    {
        private InventoryStore _inventoryStore;

        public void Start()
        {
            _inventoryStore = FindObjectOfType<InventoryStore>();
        }

        public void Collect(ItemType itemType)
        {
            var storedInventoryItemSlotsForItemType = _inventoryStore.GetStoredInventoryItemPairsForItemType(itemType);

            if (storedInventoryItemSlotsForItemType != null)
            {
                //TODO set amount
            }
            else
            {
                //TODO instantiate
                //TODO add to itemSlots
            }
        }
        
    }
}