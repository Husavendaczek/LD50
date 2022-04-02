using Helper;
using Interaction;
using Inventory;
using ItemProperty;
using Movement;
using States;
using UnityEngine;
using World;

namespace RoomScene
{
    public class WorldMediator : MonoBehaviour, IMediator
    {
        private InventoryCreator _inventoryCreator;
        private InventoryManager _inventoryManager;
        private InventoryKeyManager _inventoryKeyManager;

        private WorldItemCreator _worldItemCreator;
        private WorldItemManager _worldItemManager;
        private WorldItemsOfSceneLoader _worldItemsOfSceneLoader;
        
        private InteractionManager _interactionManager;
        private ItemIcons _itemIcons;

        private PlayerStateManager _playerStateManager;
        private PlayerMover _playerMover;

        private void Awake()
        {
            _itemIcons = FindObjectOfType<ItemIcons>();
            
            _inventoryCreator = FindObjectOfType<InventoryCreator>();
            _inventoryCreator.ItemIcons = _itemIcons;
            
            _inventoryManager = FindObjectOfType<InventoryManager>();
            _inventoryManager.Mediator = this;
            _inventoryManager.inventoryStore = FindObjectOfType<InventoryStore>();
            _inventoryManager.inventoryCreator = _inventoryCreator;

            _inventoryKeyManager = FindObjectOfType<InventoryKeyManager>();
            _inventoryKeyManager.Mediator = this;
            _inventoryKeyManager.inventoryCanvas = GameObject.FindWithTag("InventoryPanel");

            _worldItemsOfSceneLoader = FindObjectOfType<WorldItemsOfSceneLoader>();

            _worldItemCreator = FindObjectOfType<WorldItemCreator>();
            _worldItemCreator.itemIcons = _itemIcons;
            
            _worldItemManager = FindObjectOfType<WorldItemManager>();
            _worldItemManager.worldItemCreator = _worldItemCreator;
            _worldItemManager.worldItemsOfSceneLoader = _worldItemsOfSceneLoader;

            _interactionManager = FindObjectOfType<InteractionManager>();
            _interactionManager.Mediator = this;
            _interactionManager.itemIcons = _itemIcons;

            _playerStateManager = FindObjectOfType<PlayerStateManager>();
            _playerMover = FindObjectOfType<PlayerMover>();
            _playerMover.Mediator = this;
            _playerMover.playerStateManager = _playerStateManager;
        }

        public void CreateItemInWorld(ItemType itemType)
        {
            var item = _worldItemManager.AddToWorldItems(itemType);
            _inventoryManager.Collect(item);
        }

        public void CollectItem(WorldItemMono worldItemMono)
        {
            Debug.Log("Collect world item with type" + worldItemMono.itemType);
            _inventoryManager.Collect(worldItemMono.MapTo());
            _worldItemManager.CollectFromWorld(worldItemMono);
            
            // _playerStateManager.Take();
        }

        public void DropItemBackToWorld(int id, ItemType itemType)
        {
            _worldItemManager.DropIntoWorld(id, itemType);
            _inventoryKeyManager.ShowInventory(false);
            
            // _playerStateManager.Drop();
        }

        public void RemoveItemFromInventory(ItemType itemType)
        {
            _inventoryManager.RemoveLastItem(itemType);
            
            // _playerStateManager.Drop();
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
            
            // _playerStateManager.StartInteraction();
        }

        public void PauseMovement(bool pause)
        {
            _playerMover.PauseMovement(pause);
        }

        public void ShowInventory(bool show)
        {
            _inventoryKeyManager.ShowInventory(show);
        }
    }
}