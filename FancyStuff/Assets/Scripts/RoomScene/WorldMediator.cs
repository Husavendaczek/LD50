using Helper;
using Interaction;
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
        private InteractionManager _interactionManager;
        private ItemIcons _itemIcons;

        private void Awake()
        {
            _itemIcons = FindObjectOfType<ItemIcons>();
            
            _inventoryManager = FindObjectOfType<InventoryManager>();
            _inventoryManager.mediator = this;
            _inventoryManager.inventoryStore = FindObjectOfType<InventoryStore>();
            _inventoryManager.inventoryCreator = FindObjectOfType<InventoryCreator>();
            _inventoryManager.inventoryCreator.ItemIcons = _itemIcons;

            _inventoryKeyManager = FindObjectOfType<InventoryKeyManager>();
            _inventoryKeyManager.Mediator = this;
            _inventoryKeyManager.inventoryCanvas = GameObject.FindWithTag("InventoryPanel");
            _inventoryKeyManager.ShowInventory(false);
            
            _worldItemsOfSceneLoader = FindObjectOfType<WorldItemsOfSceneLoader>();
            
            _worldItemManager = FindObjectOfType<WorldItemManager>();
            _worldItemManager.worldMediator = this;
            _worldItemManager.worldItemCreator = FindObjectOfType<WorldItemCreator>();
            _worldItemManager.worldItemCreator.itemIcons = _itemIcons;
            _worldItemManager.worldItemsOfSceneLoader = _worldItemsOfSceneLoader;

            _interactionManager = FindObjectOfType<InteractionManager>();
            _interactionManager.Mediator = this;
            _interactionManager.itemIcons = _itemIcons;
            
            SetBackground();
        }

        public void CreateItemInWorld(ItemType itemType)
        {
            var item = _worldItemManager.AddToWorldItems(itemType);
            _inventoryManager.Collect(item);
        }

        public void CollectItem(WorldItemMono worldItemMono)
        {
            _inventoryManager.Collect(worldItemMono.MapTo());
            _worldItemManager.CollectFromWorld(worldItemMono);
        }

        public void DropItemBackToWorld(int id, ItemType itemType)
        {
            _worldItemManager.DropIntoWorld(id, itemType);
            _inventoryKeyManager.ShowInventory(false);
        }

        public void RemoveItemFromInventory(ItemType itemType)
        {
            _inventoryManager.RemoveLastItem(itemType);
        }

        public void RemoveAndHideInventory(InventoryItem item)
        {
            _inventoryManager.MoveItemFromInventoryToWorld(item);
            _inventoryKeyManager.ShowInventory(false);
        }

        public InventoryItem FirstInventoryItem(ItemType itemType)
        {
            return _inventoryManager.FirstItem(itemType);
        }

        public void StartInteraction(ItemType itemType)
        {
            _interactionManager.Interact(itemType);
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
            _worldItemsOfSceneLoader.SetBackgroundOfScene();
        }
    }
}