using System;
using Helper;
using ItemProperty;
using RoomScene;
using UnityEngine;
using UnityEngine.UI;
using World;

namespace Inventory
{
    public class InventoryManager : MonoBehaviour
    {
        public IMediator Mediator;
        public InventoryStore inventoryStore;
        public InventoryCreator inventoryCreator;
        public Transform inventoryCanvasTransform;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public void Collect(WorldItem worldItem)
        {
            var storedInventoryItemSlotsForItemType = inventoryStore.GetStoredInventoryItemSlotsForItemType(worldItem.ItemType);

            if (storedInventoryItemSlotsForItemType != null)
            {
                inventoryStore.SetAmountOfItemType(worldItem.ItemType, 1);
            }
            else
            {
                var inventoryItemSlot = inventoryCreator.Create(worldItem, inventoryCanvasTransform);
                inventoryItemSlot.removeButton.GetComponent<Button>().onClick.AddListener(() => MoveItemFromInventoryToWorld(worldItem.MapTo()));
                inventoryItemSlot.interactionButton.GetComponent<Button>().onClick.AddListener(() => Mediator.StartInteraction(worldItem.ItemType));

                inventoryStore.AddToInventoryItemSlot(inventoryItemSlot);
            }
        }

        public void MoveItemFromInventoryToWorld(InventoryItem inventoryItem)
        {
            Debug.Log("Remove " + inventoryItem.ItemType + " from inventory");
            Mediator.DropItemBackToWorld(inventoryItem.ID, inventoryItem.ItemType);

            var inventorySlotItem = inventoryStore.GetStoredInventorySlotById(inventoryItem.ID);

            if (inventorySlotItem == null) return;

            var newAmount = inventoryStore.SetAmountOfItemType(inventorySlotItem.Item.ItemType, -1);

            if (newAmount > 0) return;
            
            inventoryStore.RemoveFromInventory(inventorySlotItem.Item.ID);
            Destroy(inventorySlotItem.gameObject);
        }

        public void RemoveLastItem(ItemType itemType)
        {
            var inventorySlotItem = inventoryStore.FirstItem(itemType);

            var newAmount = inventoryStore.SetAmountOfItemType(itemType, -1);

            if (newAmount > 0) return;
            
            inventoryStore.RemoveFromInventory(inventorySlotItem.ID);
        }

        public InventoryItem FirstItem(ItemType itemType)
        {
            return inventoryStore.FirstItem(itemType);
        }
    }
}