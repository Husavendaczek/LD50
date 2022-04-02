using Helper;
using Inventory;
using ItemProperty;
using UnityEngine;
using World;

namespace RoomScene
{
    public class WorldMediator : MonoBehaviour, IMediator
    {
        private InventoryManager _inventoryManager;
        private InventoryKeyManager _inventoryKeyManager;
        private WorldItemManager _worldItemManager;
        private WorldItemsOfSceneLoader _worldItemsOfSceneLoader;

        private void Awake()
        {
            _inventoryManager = FindObjectOfType<InventoryManager>();
            _inventoryManager.mediator = this;
            _inventoryManager.inventoryStore = FindObjectOfType<InventoryStore>();
            _inventoryManager.inventoryCreator = FindObjectOfType<InventoryCreator>();
            _inventoryManager.inventoryCreator.ItemIcons = FindObjectOfType<ItemIcons>();

            _inventoryKeyManager = FindObjectOfType<InventoryKeyManager>();
            _inventoryKeyManager.Mediator = this;
            _inventoryKeyManager.inventoryCanvas = GameObject.FindWithTag("InventoryPanel");
            _inventoryKeyManager.ShowInventory(false);
            
            _worldItemsOfSceneLoader = FindObjectOfType<WorldItemsOfSceneLoader>();
            
            _worldItemManager = FindObjectOfType<WorldItemManager>();
            _worldItemManager.worldMediator = this;
            _worldItemManager.worldItemCreator = FindObjectOfType<WorldItemCreator>();
            _worldItemManager.worldItemCreator.itemIcons = FindObjectOfType<ItemIcons>();
            _worldItemManager.worldItemsOfSceneLoader = _worldItemsOfSceneLoader;
            
            SetBackground();
        }

        public void CollectItem(WorldItemMono worldItemMono)
        {
            _inventoryManager.Collect(worldItemMono.MapTo());
            _worldItemManager.SetCollected(worldItemMono);
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

        public void PauseMovement(bool pause)
        {
            Debug.Log("TODO should pause movement");
        }

        public void ShowInventory(bool show)
        {
            _inventoryKeyManager.ShowInventory(show);
        }

        public void SetBackground()
        {
            
        }
    }
}