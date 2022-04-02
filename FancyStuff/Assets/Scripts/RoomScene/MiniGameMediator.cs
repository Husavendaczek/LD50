using Inventory;
using ItemProperty;
using UnityEngine;
using World;

namespace RoomScene
{
    public class MiniGameMediator : MonoBehaviour, IMediator
    {
        private InventoryManager _inventoryManager;
        
        private void Awake()
        {
            _inventoryManager = FindObjectOfType<InventoryManager>();
            _inventoryManager.Mediator = this;
            _inventoryManager.inventoryStore = FindObjectOfType<InventoryStore>();
            _inventoryManager.inventoryCreator = FindObjectOfType<InventoryCreator>();
            _inventoryManager.inventoryCreator.ItemIcons = FindObjectOfType<ItemIcons>();
        }

        public void CreateItemInWorld(ItemType itemType)
        {
            throw new System.NotImplementedException();
        }

        public void CollectItem(WorldItemMono worldItemMono)
        {
            throw new System.NotImplementedException();
        }

        public void DropItemBackToWorld(int id, ItemType itemType)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveItemFromInventory(ItemType itemType)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveAndHideInventory(InventoryItem item)
        {
            throw new System.NotImplementedException();
        }

        public InventoryItem FirstInventoryItem(ItemType itemType)
        {
            throw new System.NotImplementedException();
        }

        public void StartInteraction(ItemType itemType)
        {
            throw new System.NotImplementedException();
        }

        public void PauseMovement(bool pause)
        {
            
        }

        public void ShowInventory(bool show)
        {
            
        }
    }
}