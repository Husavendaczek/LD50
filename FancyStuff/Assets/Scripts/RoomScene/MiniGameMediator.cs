using Achieving;
using Interaction;
using Interaction.Doors;
using Inventory;
using ItemProperty;
using UnityEngine;
using World;

namespace RoomScene
{
    public class MiniGameMediator : MonoBehaviour, IMediator
    {
        private InventoryManager _inventoryManager;
        private AchievementManager _achievementManager;
        
        private void Awake()
        {
            _inventoryManager = FindObjectOfType<InventoryManager>();
            _inventoryManager.Mediator = this;
            _inventoryManager.inventoryStore = FindObjectOfType<InventoryStore>();
            _inventoryManager.inventoryCreator = FindObjectOfType<InventoryCreator>();
            _inventoryManager.inventoryCreator.ItemIcons = FindObjectOfType<ItemIcons>();

            _achievementManager = FindObjectOfType<AchievementManager>();
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

        public void ShowHappyEnd(bool happy)
        {
            throw new System.NotImplementedException();
        }

        public void InteractionManagerHasSelectedItem(IInteractable interactable)
        {
            throw new System.NotImplementedException();
        }
    }
}