using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Inventory
{
    public class InventoryStore : MonoBehaviour
    {
        public readonly List<InventoryItem> InventoryItems = new List<InventoryItem>();
        public List<InventoryItemSlot> inventoryItemSlots = new List<InventoryItemSlot>();
        
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public void AddToInventoryItemSlot(InventoryItemSlot inventoryItemSlot)
        {
            inventoryItemSlots.Add(inventoryItemSlot);
            InventoryItems.Add(inventoryItemSlot.Item);
        }

        public void RemoveFromInventory(int id)
        {
            var slotToDelete = inventoryItemSlots.FirstOrDefault(slotItem => slotItem.Item.ID == id);
            if(slotToDelete == null) return;
            
            inventoryItemSlots.Remove(slotToDelete);
            Destroy(slotToDelete);
            
            var itemToDelete = InventoryItems.FirstOrDefault(inventoryItem => inventoryItem.ID == id);
            if(itemToDelete == null) return;

            InventoryItems.Remove(itemToDelete);
        }
        
        public InventoryItemSlot GetStoredInventoryItemSlotsForItemType(ItemType itemType)
        {
            return inventoryItemSlots
                .FirstOrDefault(inventoryPair =>
                    inventoryPair.Item.ItemType == itemType);
        }
        
        public int SetAmountOfItemType(ItemType itemType, int addAmount)
        {
            var storedInventoryItemPairForItemType = GetStoredInventoryItemSlotsForItemType(itemType);
            if(storedInventoryItemPairForItemType == null) { 
                return 100;
            }
            
            var currentAmount = storedInventoryItemPairForItemType.amount;
            var newAmount = currentAmount + addAmount;
            
            storedInventoryItemPairForItemType.amount = newAmount;
            
            storedInventoryItemPairForItemType.amountText.text = newAmount + "x " + itemType;
            
            return newAmount;
        }

        public InventoryItem FirstItem(ItemType itemType)
        {
            var inventorySlot = inventoryItemSlots.First(inventoryPair =>
                inventoryPair.Item.ItemType == itemType);
            
            return inventorySlot.Item;
        }

        public InventoryItemSlot GetStoredInventorySlotById(int id)
        {
            return inventoryItemSlots.FirstOrDefault(inventoryItemSlot => inventoryItemSlot.Item.ID == id);
        }
    }
}