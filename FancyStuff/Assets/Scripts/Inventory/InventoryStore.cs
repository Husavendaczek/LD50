using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Inventory
{
    public class InventoryStore : MonoBehaviour
    {
        public readonly List<InventoryItem> InventoryItems = new List<InventoryItem>();
        public List<InventoryItemSlot> inventorySlots = new List<InventoryItemSlot>();

        public void AddToInventory(InventoryItem inventoryItem)
        {
            InventoryItems.Add(inventoryItem);
        }

        public void RemoveFromInventory(int id)
        {
            var itemToDelete = InventoryItems.FirstOrDefault(inventoryItem => inventoryItem.ID == id);
            if(itemToDelete == null) return;
            
            //TODO remove from inventoryslots
            
            InventoryItems.Remove(itemToDelete);
        }
        
        public InventoryItemSlot GetStoredInventoryItemPairsForItemType(ItemType itemType)
        {
            return inventorySlots
                .FirstOrDefault(inventoryPair =>
                    inventoryPair.Item.ItemType == itemType);
        }
        
        public bool IsInInventory(int id)
        {
            var inventoryItem = InventoryItems.FirstOrDefault(inventoryItem =>
                inventoryItem.ID == id);
            return inventoryItem != null;
        }
        
        public InventoryItem FirstItem(ItemType itemType)
        {
            var inventorySlot = inventorySlots.First(inventoryPair =>
                inventoryPair.Item.ItemType == itemType);
            
            return inventorySlot.Item;
        }
    }
}