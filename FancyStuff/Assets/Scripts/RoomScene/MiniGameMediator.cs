using Achieving;
using Interaction;
using Interaction.Doors;
using Inventory;
using ItemProperty;
using Messaging;
using Scoring;
using UnityEngine;
using World;

namespace RoomScene
{
    public class MiniGameMediator : MonoBehaviour, IMediator
    {
        private InventoryManager _inventoryManager;
        private AchievementManager _achievementManager;
        private MessageManager _messageManager;
        private ScoreManager _scoreManager;
        private GameStateLoader _gameStateLoader;
        
        private void Awake()
        {
            _inventoryManager = FindObjectOfType<InventoryManager>();
            _inventoryManager.Mediator = this;
            _inventoryManager.inventoryStore = FindObjectOfType<InventoryStore>();
            _inventoryManager.inventoryCreator = FindObjectOfType<InventoryCreator>();
            _inventoryManager.inventoryCreator.ItemIcons = FindObjectOfType<ItemIcons>();

            _achievementManager = FindObjectOfType<AchievementManager>();
            
            _messageManager = FindObjectOfType<MessageManager>();

            _scoreManager = FindObjectOfType<ScoreManager>();

            _gameStateLoader = FindObjectOfType<GameStateLoader>();
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

        public void ShouldMove(bool pause)
        {
            
        }

        public void ShowInventory(bool show)
        {
            
        }

        public void SceneSwitchFromDoor(DoorMono doorItem)
        {
            throw new System.NotImplementedException();
        }

        public void ShowAchievement(AchievementType type)
        {
            _achievementManager.CompleteAchievement(type);
        }

        public void ShowEnd()
        {
            var isHappyEnd = _scoreManager.IsHappyEnd();
            if (isHappyEnd)
            {
                _gameStateLoader.ShowHappyEnd();
            }
            else
            {
                _gameStateLoader.ShowSadEnd();
            }
        }

        public void InteractionManagerHasSelectedItem(IInteractable interactable)
        {
            throw new System.NotImplementedException();
        }

        public void ShowMessage(Message message)
        {
            _messageManager.ShowMessage(message);
        }
        
        public void ShowSimpleMessage(SimpleMessage message)
        {
            _messageManager.ShowSimpleMessage(message);
        }

        public void HideMessage()
        {
            _messageManager.HideMessage();
        }

        public void SetScore(int score)
        {
            _scoreManager.SetScore(score);
        }
    }
}