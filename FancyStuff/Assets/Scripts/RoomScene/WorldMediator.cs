using Achieving;
using Helper;
using Interaction;
using Interaction.Doors;
using Inventory;
using ItemProperty;
using Movement;
using States;
using UnityEngine;
using UnityEngine.SceneManagement;
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

        private DoorCreator _doorCreator;
        private DoorManager _doorManager;
        
        private InteractionManager _interactionManager;
        private ItemIcons _itemIcons;

        private PlayerStateManager _playerStateManager;
        private PlayerMover _playerMover;

        private AchievementCreator _achievementCreator;
        private AchievementManager _achievementManager;
        private TrashCollector _trashCollector;

        private void Awake()
        {
            _itemIcons = FindObjectOfType<ItemIcons>();
            
            _inventoryCreator = FindObjectOfType<InventoryCreator>();
            _inventoryCreator.ItemIcons = _itemIcons;
            
            _inventoryManager = FindObjectOfType<InventoryManager>();
            _inventoryManager.Mediator = this;
            _inventoryManager.inventoryStore = FindObjectOfType<InventoryStore>();
            _inventoryManager.inventoryCreator = _inventoryCreator;
            var inventoryPanel = FindObjectOfType<InventoryPanelManager>();
            _inventoryManager.inventoryCanvasTransform = inventoryPanel.InventoryPanel.transform;

            _inventoryKeyManager = FindObjectOfType<InventoryKeyManager>();
            _inventoryKeyManager.Mediator = this;
            _inventoryKeyManager.inventoryCanvas = inventoryPanel.InventoryPanel;

            _worldItemsOfSceneLoader = FindObjectOfType<WorldItemsOfSceneLoader>();

            _worldItemCreator = FindObjectOfType<WorldItemCreator>();
            _worldItemCreator.itemIcons = _itemIcons;
            
            _worldItemManager = FindObjectOfType<WorldItemManager>();
            _worldItemManager.worldItemCreator = _worldItemCreator;
            _worldItemManager.worldItemsOfSceneLoader = _worldItemsOfSceneLoader;

            _doorCreator = FindObjectOfType<DoorCreator>();
            _doorManager = FindObjectOfType<DoorManager>();
            _doorManager.doorCreator = _doorCreator;
            _doorManager.worldItemsOfSceneLoader = _worldItemsOfSceneLoader;

            _interactionManager = FindObjectOfType<InteractionManager>();
            _interactionManager.Mediator = this;
            _interactionManager.itemIcons = _itemIcons;

            _playerStateManager = FindObjectOfType<PlayerStateManager>();
            _playerMover = FindObjectOfType<PlayerMover>();
            _playerMover.Mediator = this;
            _playerMover.playerStateManager = _playerStateManager;

            _achievementCreator = FindObjectOfType<AchievementCreator>();
            _achievementManager = FindObjectOfType<AchievementManager>();
            _achievementManager.achievementCreator = _achievementCreator;
            _achievementManager.gameCanvasTransform = inventoryPanel.InventoryPanel.transform;

            _trashCollector = FindObjectOfType<TrashCollector>();
            _trashCollector.Mediator = this;
        }

        public void CreateItemInWorld(ItemType itemType)
        {
            var item = _worldItemManager.AddToWorldItems(itemType);
            _inventoryManager.Collect(item);
        }

        public void CollectItem(WorldItemMono worldItemMono)
        {
            _playerStateManager.Reset();
            _inventoryManager.Collect(worldItemMono.MapTo());
            _worldItemManager.CollectFromWorld(worldItemMono);
            
            // _playerStateManager.Take();
        }

        public void DropItemBackToWorld(int id, ItemType itemType)
        {
            _playerStateManager.Reset();
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
            _playerStateManager.Reset();
            
            _interactionManager.Interact(itemType);
            
            // _playerStateManager.StartInteraction();
        }

        public void ShouldMove(bool pause)
        {
            _playerMover.PauseMovement(pause);
        }

        public void ShowInventory(bool show)
        {
            _inventoryKeyManager.ShowInventory(show);
        }

        public void SceneSwitchFromDoor(DoorMono doorItem)
        {
            _playerStateManager.Reset();
            doorItem.GoTo();
            SceneManager.sceneLoaded += (scene, mode) => InitCurrentScene(doorItem.enteredRoomPosition);
        }

        public void ShowAchievement(AchievementType type)
        {
            _achievementManager.CompleteAchievement(type);
        }

        public void InitCurrentScene()
        {
            _worldItemsOfSceneLoader.InitCurrentScene();
            _worldItemManager.InitWorldItems();
            _doorManager.InitDoors();
        }

        private void InitCurrentScene(Vector3 position)
        {
            InitCurrentScene();
            _playerMover.ResetPlayerPosition(position);
        }
    }
}