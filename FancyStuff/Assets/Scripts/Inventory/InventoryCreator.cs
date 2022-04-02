using ItemProperty;
using UnityEngine;
using World;

namespace Inventory
{
    public class InventoryCreator : MonoBehaviour
    {
        public GameObject inventoryItemSlotPrefab;

        public ItemIcons ItemIcons;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public InventoryItemSlot Create(WorldItem worldItem, Transform inventoryTransform)
        {
            var inventoryItemSlotGameObject = Instantiate(inventoryItemSlotPrefab, inventoryTransform, true);
            var parentPosition = inventoryTransform.position;
            inventoryItemSlotGameObject.transform.position = parentPosition;
            inventoryItemSlotGameObject.name = worldItem.ItemType + "Slot";

            var itemTypeValue = (int) worldItem.ItemType;

            var inventoryItem = new InventoryItem
            {
                ID = worldItem.Id,
                ItemType = worldItem.ItemType
            };

            var inventoryItemSlot = inventoryItemSlotGameObject.GetComponent<InventoryItemSlot>();
            inventoryItemSlot.Item = inventoryItem;
            inventoryItemSlot.amount = 1;
            inventoryItemSlot.amountText.text = "1x";
            inventoryItemSlot.icon.sprite = ItemIcons.icons[itemTypeValue];

            return inventoryItemSlot;
        }
        
    }
}